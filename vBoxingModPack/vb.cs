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


namespace vBoxingModPack
{
    class vb
    {
        #region get Session Key
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Objekte nicht mehrmals verwerfen")]
        public static string getSessionKey(string username, string password)
        {
            try
            {
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
                        return "token:" + j.accessToken + ":" + j.selectedProfile.id;
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Benutzername oder Passwort stimmt nicht\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return "error";
            }
        }
        #endregion

        #region downlaod File
        public static void downloadFile(string url, string save)
        {
            if (!File.Exists(save))
            {
                WebClient client = new WebClient();
                client.DownloadFileAsync(new Uri(url), save);
            }
            else
            {
                if (checkMD5(save, getMD5(null)))
	            {
		            //datei ist aktuell
                }
                else
                {
                    //datei stimmt nicht / ist veraltet
                }
            }
        }
        #endregion

        #region appdata
        public static string appdata(/*string file*/)
        {
            string pfad = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            return pfad;
        }
        #endregion

        #region checkMD5
        public static bool checkMD5(string file, string md5)
        {
            return true;
        }
        #endregion

        #region getMD5
        public static string getMD5(string url)
        {
            return null;
        }
        #endregion

        #region getUrls
        public static void getUrls()
        {

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
                WebClient client = new WebClient();
                client.Proxy = null;
                var response = client.DownloadString(new Uri("http://xpaw.ru/mcstatus/status.json"));
                dynamic data = new JsonFx.Json.JsonReader().Read(response);
                
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
                return null;
            }
        }
        #endregion

        
    }
}
