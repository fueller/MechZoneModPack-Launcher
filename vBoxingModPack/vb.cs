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
using MechZoneModPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EQATEC.Analytics.Monitor;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Zip;

namespace MechZoneModPack
{
    public class vb
    {
        #region get Session Key
        public static string getSessionKey(string username, string password)
        {
            try
            {
                MechZoneModPack.mainForm.monitor.TrackFeatureStart("getSessionKey");
                WebRequest.DefaultWebProxy = null;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://authserver.mojang.com/authenticate");
                
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"clientToken\":\"MechZoneModPack" + vb.RandomString(4) + vb.RandomString(4) + vb.RandomString(4) + "\"}";
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
                        MechZoneModPack.mainForm.monitor.TrackFeatureStop("getSessionKey");
                        return "token:" + j.accessToken + ":" + j.selectedProfile.id;
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Benutzername oder Passwort stimmt nicht\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MechZoneModPack.mainForm.monitor.TrackFeatureCancel("getSessionKey");
                MechZoneModPack.mainForm.monitor.TrackException(ex, "noLogin");
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
                    client.DownloadFile(new Uri(url), save);
                }
                catch (Exception ex)
                {
                    Properties.Settings.Default.finishedFiles++;
                    ErrorWindow err = new ErrorWindow();
                    err.ex = ex;
                    err.ShowDialog();
                }
            }
            else
            {
                
                if (md5 != null)
                {
                    if (checkMD5(md5, getMD5fromFile(save)))
                    {
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Datei " + save + " ist veraltet\nMöchtest du ein Backup machen bevor die Datei überschrieben wird?","Error",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                        if (result == DialogResult.Yes)
                        {
                            
                            string path = (vb.appdata() + "\\backup\\" + DateTime.Now.ToString("HH-mm-ss") + "_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + Path.GetFileName(save)).Replace(" ","_");
                            
                            string outputFolder = Path.GetDirectoryName(path);
                            if (!Directory.Exists(outputFolder))
                            {
                                Directory.CreateDirectory(outputFolder);
                            }
                            Console.WriteLine(save);
                            Console.WriteLine(path);
                            File.Copy(save, path);
                        }
                        File.Delete(save);
                        vb.downloadFile(url, save, md5);
                    }
                }
                else
                {
                    Properties.Settings.Default.finishedFiles++;
                }
            }
        }

        private static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("DownloadFinished");
            //Console.WriteLine(e.ProgressPercentage);
        }

        private static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
                       
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
                Console.WriteLine(e.Error.HelpLink);
                ++Properties.Settings.Default.finishedFiles;
            }
            else
            {
                Console.WriteLine("Download finished");
                ++Properties.Settings.Default.finishedFiles;
            }
        }

        #endregion

        #region appdata
        public static string appdata(/*string file*/)
        {
            string pfad = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.MechZoneModPack");
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
            try
            {
                //return null;
                if (File.Exists(Properties.Settings.Default.javaPath))
                {
                    return Properties.Settings.Default.javaPath;
                }
                else
                {
                    if (File.Exists(@"C:\Program Files\Java\jre7\bin\javaw.exe"))
                    {
                        return @"C:\Program Files\Java\jre7\bin\javaw.exe";
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
                MechZoneModPack.mainForm.monitor.TrackException(ex, "GetJavaPath");
                return null;
            }
        }
        #endregion

        #region get Server Status
        public static dynamic getServerStatus()
        {
            try
            {
                MechZoneModPack.mainForm.monitor.TrackFeatureStart("getServerStatus");
                WebClient client = new WebClient();
                client.Proxy = null;
                var response = client.DownloadString(new Uri("http://xpaw.ru/mcstatus/status.json"));
                dynamic data = new JsonFx.Json.JsonReader().Read(response);
                MechZoneModPack.mainForm.monitor.TrackFeatureStop("getServerStatus");
                return data;
            }
            catch (Exception /*ex*/)
            {
                //ErrorWindow err = new ErrorWindow();
                //err.ex = ex;
                //err.ShowDialog();
                MechZoneModPack.mainForm.monitor.TrackFeatureCancel("getServerStatus");
                //MechZoneModPack.mainForm.monitor.TrackException(ex, "noServerStatus");
                return null;
            }
        }
        #endregion

        #region getLibraries
        public static void getLibraries()
        {

            //try
            //{
                jsonClasses.filesList list = new jsonClasses.filesList();
                string[] output = new string[21];

                var j = JsonConvert.DeserializeObject<jsonClasses.minecraftDetails>(File.ReadAllText(vb.appdata() + "\\versions\\1.6.4-Forge\\1.6.4-Forge.json"));
                for (int i = 0; i < j.libraries.Count(); i++)
                {
                    jsonClasses.files2 list2 = new jsonClasses.files2();
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
                        list2.url = file;
                        list2.path = save;
                        
                        vb.downloadFile(file, save, null);
                        list2.md5 = vb.getMD5fromFile(save);
                    }
                    output[i] = JsonConvert.SerializeObject(list2);

                    
                    //vb.downloadFile("http://files.minecraftforge.net/minecraftforge/minecraftforge-universal-" + Properties.version.Default.minecraftVer + "-" + Properties.version.Default.forgeVer + ".jar", vb.appdata() + "\\libraries\\minecraftforge\\minecraftforge\\minecraftforge-" + Properties.version.Default.forgeVer + ".jar", null);
                    
                }
                StreamWriter fileXY = new StreamWriter(vb.appdata() + "\\temp\\test.json");
                foreach (string str in output)
                {
                    fileXY.WriteLine(str);
                }
                fileXY.Close();
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        #endregion

        #region getNative
        public static void getNatives(string version)
        {
            vb.downloadFile("http://s3.amazonaws.com/MinecraftDownload/windows_natives.jar", vb.appdata() + "\\temp\\windows_natives.jar", null);
            string jarPath = vb.appdata() + "\\temp\\windows_natives.jar";
            string saveFolderPath = vb.appdata() + "\\versions\\" + version + "\\" + version + "-natives\\";
            Directory.CreateDirectory(saveFolderPath);
            FastZip fz = new FastZip();
            fz.ExtractZip(jarPath, saveFolderPath, "");
            try
            {
                Directory.Delete(vb.appdata() + "\\versions\\1.6.4-Forge\\1.6.4-Forge-natives\\META-INF\\", true);
                File.Delete(vb.appdata() + "\\temp\\windows_natives.jar");
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
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
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }
        #endregion

        #region delete natives
        public static void deleteNatives()
        {
            try
            {
                Directory.Delete(vb.appdata() + "\\versions\\1.6.4-Forge\\1.6.4-Forge-Natives", true);
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }
        #endregion

        #region check Version
        public static jsonClasses.filesList checkVersion()
        {
            try
            {
                MechZoneModPack.mainForm.monitor.TrackFeatureStart("checkVersion");
                WebClient client = new WebClient();
                client.Proxy = null;
                if (Directory.Exists(Path.Combine(vb.appdata(), "temp")))
                {
                    Directory.Delete(Path.Combine(vb.appdata(), "temp"), true);
                    Directory.CreateDirectory(Path.Combine(vb.appdata(), "temp"));
                }
                Directory.CreateDirectory(Path.Combine(vb.appdata(), "temp"));
                
                //client.DownloadFile(downloadLocation() + "modpack/files/mods.json", vb.appdata() + "\\temp\\mods.json");
                //client.DownloadFile(downloadLocation() + "modpack/files/config.json", vb.appdata() + "\\temp\\config.json");
                //client.DownloadFile(downloadLocation() + "modpack/files/assets.json", vb.appdata() + "\\temp\\assets.json");
                //client.DownloadFile(downloadLocation() + "modpack/files/libraries.json", vb.appdata() + "\\temp\\libraries.json");
                //client.DownloadFile(downloadLocation() + "modpack/files/sonstiges.json", vb.appdata() + "\\temp\\sonstiges.json");
                //client.DownloadFile(downloadLocation() + "modpack/files/delete.json", vb.appdata() + "\\temp\\delete.json");
                client.DownloadFile(downloadLocation() + "modpack/modpacks/modpacks.json", vb.appdata() + "\\temp\\modpacks.json");
               
                jsonClasses.filesList j = null; // = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\temp\\mods.json"));

                MechZoneModPack.mainForm.monitor.TrackFeatureStop("checkVersion");
                return j;
            }
            catch (Exception ex)
            {
                MechZoneModPack.mainForm.monitor.TrackFeatureCancel("checkVersion");
                MessageBox.Show("Konnte Version nicht prüfen!\nBenutze letzte heruntergeladene");
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
                return null;
            }
        }
        #endregion

        #region random string
        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        #endregion     

        #region variables
        public static string downloadLocation()
        {
            return "http://mechzone.net/";
        }
        #endregion

        #region send error log
        public static void sendErrorLog(string Error, Exception ex)
        {
            try
            {
                string apiKey = "1c28f9526330ebefa9f7b38f2020d05b";
                var client = new PasteBinClient(apiKey);

                var entry = new PasteBinEntry
                {
                    Title = "MechZoneModPack Error Report",
                    Text = Error,
                    Expiration = PasteBinExpiration.OneDay,
                    Private = true,
                    Format = "csharp"
                };

                string pasteUrl = client.Paste(entry);
                if (ex != null)
                {
                    MechZoneModPack.mainForm.addBugToSpreadsheet(ex.Message, pasteUrl);
                }
                else
                {
                    MechZoneModPack.mainForm.addBugToSpreadsheet("Pastebin", pasteUrl);
                }
                
                MessageBox.Show("Der Error Link wurde in deine Zwischenablage Kopiert!\nBitte schicke ihn einem Admin!\n" + pasteUrl, "Link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Windows.Forms.Clipboard.SetText(pasteUrl);
                Console.WriteLine(pasteUrl);
            }
            catch (Exception exx)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = exx;
                err.ShowDialog();
            }
        }
        #endregion

        #region createFolderStructure
        public static void createFolderStructure(int id, jsonClasses.modpacks modPackInfo)
        {
            if (!Directory.Exists(Path.Combine(vb.appdata(), "modpacks", modPackInfo.list[id].tag)))
            {
                Directory.CreateDirectory(Path.Combine(vb.appdata(), "modpacks", modPackInfo.list[id].tag));
            }

            for (int i = 0; i < modPackInfo.list[id].folders.Count; i++)
            {
                if (!Directory.Exists(Path.Combine(vb.appdata(), "modpacks", modPackInfo.list[id].tag, modPackInfo.list[id].folders[i])))
                {
                    Directory.CreateDirectory(Path.Combine(vb.appdata(), "modpacks", modPackInfo.list[id].tag, modPackInfo.list[id].folders[i]));
                }
            }
        }
        #endregion
    }
}
