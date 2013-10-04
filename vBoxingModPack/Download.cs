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

namespace vBoxingModPack
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }
        
        private void Download_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar2.Maximum = 100;
            progressBar2.Value = 0;
        }

        private void Download_Shown(object sender, EventArgs e)
        {
            this.Update();
            vBoxingModPack.mainForm.monitor.TrackFeatureStart("downloadFiles");
            var j = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\temp\\files.json"));
            progressBar1.Maximum = j.files.Count;
            for (int i = 0; i < j.files.Count(); i++)
            {
                progressBar2.Value = 0;
                label2.Text = "Lade Datei " + i + " von " + j.files.Count() + " Dateien herunter!";
                label1.Text = j.files[i].path;
                progressBar1.Value = i;
                this.Update();
                vb.downloadFile(j.files[i].url, vb.appdata() + j.files[i].path, j.files[i].md5);                
            }
            this.Close();
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
                    WebClient client = new WebClient();
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFile(new Uri(url), save);
                }
                catch (Exception ex)
                {
                    Properties.Settings.Default.finishedFiles++;
                    MessageBox.Show(ex.Message);
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
                        MessageBox.Show("Datei " + save + " ist veraltet");
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

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("DownloadFinished");
            
            progressBar2.Value = e.ProgressPercentage;
            Console.WriteLine(e.ProgressPercentage);
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
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

    }
}
