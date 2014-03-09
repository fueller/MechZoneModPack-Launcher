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

        public Download()
        {
            InitializeComponent();
        }

        private void Download_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

        }

        private void Download_Shown(object sender, EventArgs e)
        {

            //MessageBox.Show(Properties.Settings.Default.updateFiles.ToString());
            if (Properties.Settings.Default.updateFiles)
            {
                this.Close();
            }
            else
            {
                this.Update();
                MechZoneModPack.mainForm.monitor.TrackFeatureStart("downloadFiles");

                var mods = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\temp\\mods.json"));
                var assets = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\temp\\assets.json"));
                var config = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\temp\\config.json"));
                var libraries = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\temp\\libraries.json"));
                var sonstiges = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\temp\\sonstiges.json"));
                var delete = JsonConvert.DeserializeObject<jsonClasses.deleteFiles>(File.ReadAllText(vb.appdata() + "\\temp\\delete.json"));


                progressBar1.Maximum = mods.files.Count() + assets.files.Count() + config.files.Count() + libraries.files.Count() + sonstiges.files.Count();
                progressBar2.Maximum = 100;
                progressBar2.Value = 0;

                //delete
                for (int i = 0; i < delete.files.Count(); i++)
                {
                    string file = vb.appdata() + "\\" + delete.files[i];

                    if (File.Exists(file))
                    {
                        try
                        {
                            Console.WriteLine("Datei " + file + " existiert und wird gelöscht");
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            ErrorWindow err = new ErrorWindow();
                            err.ex = ex;
                            err.ShowDialog();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Datei " + file + " existiert nicht und wird nicht gelöscht");
                    }
                }

                //assets                
                for (int i = 0; i < assets.files.Count(); i++)
                {

                    int j = i + 1;
                    label2.Text = "Lade Datei " + j + " von " + assets.files.Count() + " Dateien herunter!";
                    label1.Text = assets.files[i].path;
                    this.Update();
                    Application.DoEvents();
                    while (downloading)
                    {
                        this.Update();
                        Application.DoEvents();
                    }
                    progressBar1.Value++;
                    downloadFile(assets.files[i].url, vb.appdata() + assets.files[i].path, assets.files[i].md5);
                    if (canceled)
                    {
                        break;
                    }
                }
                this.Update();

                //Sonstiges                
                for (int i = 0; i < sonstiges.files.Count(); i++)
                {
                    int j = i + 1;
                    label2.Text = "Lade Datei " + j + " von " + sonstiges.files.Count() + " Dateien herunter!";
                    label1.Text = sonstiges.files[i].path;
                    this.Update();
                    Application.DoEvents();
                    while (downloading)
                    {
                        this.Update();
                        Application.DoEvents();
                    }
                    progressBar1.Value++;
                    downloadFile(sonstiges.files[i].url, vb.appdata() + sonstiges.files[i].path, sonstiges.files[i].md5);
                    if (canceled)
                    {
                        break;
                    }
                }
                this.Update();

                //libraries                
                for (int i = 0; i < libraries.files.Count(); i++)
                {

                    int j = i + 1;
                    label2.Text = "Lade Config " + j + " von " + libraries.files.Count() + " Libraries herunter!";
                    label1.Text = libraries.files[i].path;
                    this.Update();
                    Application.DoEvents();
                    while (downloading)
                    {
                        this.Update();
                        Application.DoEvents();
                    }
                    progressBar1.Value++;
                    downloadFile(libraries.files[i].url, vb.appdata() + libraries.files[i].path, libraries.files[i].md5);
                    if (canceled)
                    {
                        break;
                    }
                }
                this.Update();

                //mods                
                for (int i = 0; i < mods.files.Count(); i++)
                {

                    int j = i + 1;
                    label2.Text = "Lade Mod " + j + " von " + mods.files.Count() + " Mods herunter!";
                    label1.Text = mods.files[i].path;
                    this.Update();
                    Application.DoEvents();
                    if (mods.files[i].enabled)
                    {
                        while (downloading)
                        {
                            this.Update();
                            Application.DoEvents();
                        }
                        progressBar1.Value++;
                        downloadFile(mods.files[i].url, vb.appdata() + mods.files[i].path, mods.files[i].md5);
                    }
                    if (canceled)
                    {
                        break;
                    }
                }
                this.Update();

                //configs                
                for (int i = 0; i < config.files.Count(); i++)
                {

                    int j = i + 1;
                    label2.Text = "Lade Config " + j + " von " + config.files.Count() + " Configs herunter!";
                    label1.Text = config.files[i].path;
                    this.Update();
                    Application.DoEvents();
                    if (config.files[i].enabled)
                    {
                        while (downloading)
                        {
                            this.Update();
                            Application.DoEvents();
                        }
                        progressBar1.Value++;
                        downloadFile(config.files[i].url, vb.appdata() + config.files[i].path, config.files[i].md5);
                    }
                    if (canceled)
                    {
                        break;
                    }
                }
                downloading = false;
                this.Update();
                this.Close();
            }
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
                            string path = (vb.appdata() + "\\backup\\" + DateTime.Now.ToString("HH-mm-ss") + "_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + Path.GetFileName(save)).Replace(" ", "_");

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
