using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vBoxingModPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EQATEC.Analytics.Monitor;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Zip;

namespace vBoxingModPack
{
    public class vb
    {
        public event Action<int> ProgressChanged;
        internal delegate void UpdateProgressDelegate(int ProgressPercentage);
        internal event UpdateProgressDelegate UpdateProgress;

        private void OnProgressChanged(int progress)
        {
            var eh = ProgressChanged;
            if (eh != null)
            {
                eh(progress);
            }
        }

        #region get Session Key
        public static string getSessionKey(string username, string password)
        {
            try
            {
                vBoxingModPack.mainForm.monitor.TrackFeatureStart("getSessionKey");
                WebRequest.DefaultWebProxy = null;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://authserver.mojang.com/authenticate");
                
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"clientToken\":\"vBoxingModPack\"}";
                    //MessageBox.Show(json);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string response = streamReader.ReadToEnd();
                        var j = JsonConvert.DeserializeObject<jsonClasses.minecraftLogonJson1>(response);
                        Properties.Settings.Default.nickname = j.selectedProfile.name;
                        Properties.Settings.Default.Save();
                        vBoxingModPack.mainForm.monitor.TrackFeatureStop("getSessionKey");
                        return "token:" + j.accessToken + ":" + j.selectedProfile.id;
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Benutzername oder Passwort stimmt nicht\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                vBoxingModPack.mainForm.monitor.TrackFeatureCancel("getSessionKey");
                vBoxingModPack.mainForm.monitor.TrackException(ex, "noLogin");
                return "error";
            }
        }
        #endregion

        #region downlaod File
        public static void downloadFile(string url, string save, string md5)
        {
            if (!File.Exists(save))
            {
                try
                {
                    string outputFolder = Path.GetDirectoryName(save);
                    if (!Directory.Exists(outputFolder))
                    {
                        Directory.CreateDirectory(outputFolder);
                    }
                    
                    //MessageBox.Show("StartDownload");
                    WebClient client = new WebClient();
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileAsync(new Uri(url), save);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

                if (md5 != null)
                {
                    if (checkMD5(md5, getMD5fromFile(save)))
                    {
                        //datei ist aktuell
                        MessageBox.Show("Datei " + save + " ist aktuell");
                    }
                    else
                    {
                        //datei stimmt nicht / ist veraltet
                        MessageBox.Show("Datei " + save + " ist veraltet");
                        File.Delete(save);
                        vb.downloadFile(url, save, md5);
                    } 
                }
            }
        }

        internal void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("DownloadFinished");
            //Console.WriteLine(e.ProgressPercentage);
            UpdateProgress(e.ProgressPercentage);
        }

        private static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
                       
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
                Console.WriteLine(e.Error.HelpLink);
            }
            else
            {
                Console.WriteLine("Download finished"); 
            }
        }

        #endregion

        #region appdata
        public static string appdata(/*string file*/)
        {
            string pfad = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.vboxing");
            return pfad;
        }
        #endregion

        #region checkMD5
        public static bool checkMD5(string onlineMd5, string fileMd5)
        {
            if (onlineMd5 == fileMd5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region getMD5fromFile
        public static string getMD5fromFile(string path)
        {
            System.IO.FileStream FileCheck = System.IO.File.OpenRead(path);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Hash = md5.ComputeHash(FileCheck);
            FileCheck.Close();
            return BitConverter.ToString(md5Hash).Replace("-", "").ToLower();
        }
        #endregion

        #region create Folders
        public static void createFolders(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        #endregion

        #region getJavaPath
        public static string GetJavaInstallationPath()
        {
            String javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
            {
                String currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                using (var homeKey = baseKey.OpenSubKey(currentVersion))
                    return homeKey.GetValue("JavaHome").ToString() + "\\bin\\";
            }
        }
        #endregion

        #region get Server Status
        public static dynamic getServerStatus()
        {
            try
            {
                vBoxingModPack.mainForm.monitor.TrackFeatureStart("getServerStatus");
                WebClient client = new WebClient();
                client.Proxy = null;
                var response = client.DownloadString(new Uri("http://xpaw.ru/mcstatus/status.json"));
                dynamic data = new JsonFx.Json.JsonReader().Read(response);
                vBoxingModPack.mainForm.monitor.TrackFeatureStop("getServerStatus");
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                vBoxingModPack.mainForm.monitor.TrackFeatureCancel("getServerStatus");
                vBoxingModPack.mainForm.monitor.TrackException(ex, "noServerStatus");
                return null;
            }
        }
        #endregion

        #region getLibraries
        public static void getLibraries()
        {

            try
            {
                var j = JsonConvert.DeserializeObject<jsonClasses.minecraftDetails>(File.ReadAllText(vb.appdata() + "\\versions\\1.6.4-Forge\\1.6.4-Forge.json"));
                for (int i = 0; i < j.libraries.Count(); i++)
                {
                    string[] temp = j.libraries[i].name.Split(':');
                    string file = "http://s3.amazonaws.com/Minecraft.Download/libraries/";
                    file += temp[0].Replace('.', '/');
                    file += "/";
                    file += temp[1];
                    file += "/";
                    file += temp[2];
                    file += "/";
                    file += temp[1];
                    file += "-";
                    file += temp[2];
                    if (j.libraries[i].natives != null)
                    {
                        file += "-";
                        file += j.libraries[i].natives.windows;
                    }

                    file += ".jar";

                    //Console.WriteLine("[" + i + "] " + file);

                    string save = vb.appdata() + "\\libraries\\";
                    save += temp[0].Replace('.', '\\');
                    save += "\\";
                    save += temp[1];
                    save += "\\";
                    save += temp[2];
                    save += "\\";
                    save += temp[1];
                    save += "-";
                    save += temp[2];
                    if (j.libraries[i].natives != null)
                    {
                        save += "-";
                        save += j.libraries[i].natives.windows;
                    }
                    save += ".jar";
                    //Console.WriteLine(save);

                    
                    string os = "";
                    string action = "allow";

                    try
                    {
                        os = j.libraries[i].rules[0].os.name.ToString();
                        action = j.libraries[i].rules[0].action.ToString();                        
                    }catch (Exception){}

                    Console.WriteLine("[" + i + "] " + os + " " + action);
                    
                    if (os == "" && action == "allow")
                    {
                        Console.WriteLine("dl File " + i);
                        vb.downloadFile(file, save, null); 
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region getNative
        public static void getNatives()
        {
            WebClient client = new WebClient();
            client.Proxy = null;
            client.DownloadFile("http://s3.amazonaws.com/MinecraftDownload/windows_natives.jar", vb.appdata() + "\\temp\\windows_natives.jar");
            string jarPath = vb.appdata() + "\\temp\\windows_natives.jar";
            string saveFolderPath = vb.appdata() + "\\versions\\1.6.4-Forge\\1.6.4-Forge-natives\\";
            FastZip fz = new FastZip();
            fz.ExtractZip(jarPath, saveFolderPath, "");
            System.Diagnostics.Process.Start("explorer", saveFolderPath);
            try
            {
                Directory.Delete(vb.appdata() + "\\versions\\1.6.4-Forge\\1.6.4-Forge-natives\\META-INF\\", true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region delete libraries
        public static void deleteLibraries()
        {
            try
            {
                Directory.Delete(vb.appdata() + "\\libraries", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public static Dictionary<string, bool> checkVersion()
        {
            Dictionary<string, bool> versions = new Dictionary<string, bool>();
            versions.Add("mods", false);
            versions.Add("config", false);
            versions.Add("libraries", false);
            versions.Add("natives", false);
            versions.Add("minecraft", false);
            versions.Add("forge", false);
            
            try
            {
                WebClient client = new WebClient();
                client.Proxy = null;
                client.DownloadFile("http://lawall.punpic.de/modpack/files/version.json", vb.appdata() + "\\temp\\version.json");
                var j = JsonConvert.DeserializeObject<jsonClasses.version>(File.ReadAllText(vb.appdata() + "\\temp\\version.json"));
                if (j.mods == "")
                {
                    versions["mods"] = true;
                }
                if (j.config == "")
                {
                    versions["config"] = true;
                }
                if (j.libraries == "")
                {
                    versions["libraries"] = true;
                }
                if (j.natives == "")
                {
                    versions["natives"] = true;
                }
                if (j.minecraft == "")
                {
                    versions["minecraft"] = true;
                }
                if (j.forge == "")
                {
                    versions["forge"] = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Konnte Version nicht prüfen!\nBenutze letzte heruntergeladene");
            }

            return versions;
        }
    }
}
