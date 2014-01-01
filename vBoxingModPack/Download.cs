using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechZoneModPack
{
    public partial class Download : Form
    {
        bool backup = false;
        bool first = true;
        bool downloading = false;
        bool canceled = false;
        jsonClasses.modpacks modPackList;
        int id;
        int downloads = 0;
        bool replaceFiles = false;

        public jsonClasses.modpacks list
        { 
          get { return modPackList; }
          set { modPackList = value; }
        }

        public int tmpId
        {
            get { return id; }
            set { id = value; }
        }

        public bool replace
        {
            get { return replaceFiles; }
            set { replaceFiles = value; }
        }

        public Download()
        {
            InitializeComponent();
        }
        
        private void Download_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            
        }

        private void Download_Shown(object sender, EventArgs e)
        {
            downloadFile(modPackList.list[id].modsFile,vb.appdata() + "\\modpacks\\" + modPackList.list[id].tag + "\\temp\\mods.json", null);
            downloadFile(modPackList.list[id].configFile, vb.appdata() + "\\modpacks\\" + modPackList.list[id].tag + "\\temp\\config.json", null);
            downloadFile(modPackList.list[id].librariesFile, vb.appdata() + "\\modpacks\\" + modPackList.list[id].tag + "\\temp\\libraries.json", null);
            downloadFile(modPackList.list[id].assetsFile, vb.appdata() + "\\modpacks\\" + modPackList.list[id].tag + "\\temp\\assets.json", null);
            jsonClasses.filesList mods = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + modPackList.list[id].tag + "\\temp\\mods.json"));
        }

        #region downlaod File
        private void downloadFile(string url, string save, string md5)
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
                    downloading = true;
                    progressBar2.Value = 0;
                    WebClient client = new WebClient();
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileAsync(new Uri(url), save);
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
                        if (first)
                        {
                            DialogResult result = MessageBox.Show("Es gibt veraltete Dateien\nMöchtest du ein Backup machen bevor die Datei überschrieben wird?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            first = false;
                            if (result == DialogResult.Yes)
                            {
                                backup = true;
                            }
                            else
                            {
                                backup = false;
                            }
                        }
                        
                        if (backup)
                        {                           
                            backup = true;
                            string path = (vb.appdata() + "\\" + modPackList.list[id].tag + "\\backup\\" + DateTime.Now.ToString("HH-mm-ss") + "_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + Path.GetFileName(save)).Replace(" ", "_");

                            string outputFolder = Path.GetDirectoryName(path);
                            if (!Directory.Exists(outputFolder))
                            {
                                Directory.CreateDirectory(outputFolder);
                            }
                            //Console.WriteLine(save);
                            //Console.WriteLine(path);
                            File.Copy(save, path);
                        }
                        File.Delete(save);
                        downloadFile(url, save, md5);
                    }
                }
                else
                {
                    Properties.Settings.Default.finishedFiles++;
                }
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("DownloadFinished");
            Application.DoEvents();
            progressBar2.Value = e.ProgressPercentage;
            Console.WriteLine(e.ProgressPercentage);
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            downloading = false;
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

        private void cancel_Click(object sender, EventArgs e)
        {
            canceled = true;
            this.Close();
        }

    }
}
