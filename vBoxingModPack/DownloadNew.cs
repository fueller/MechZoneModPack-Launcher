using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class DownloadNew : Form
    {
        //bool backup = false;
        //bool first = true;
        bool downloading = false;
        bool canceled = false;
        jsonClasses.modpacks packs;
        int id;
        Stopwatch sw = new Stopwatch();
        int count = 0;
        List<bool> selected;        
        WebClient client = new WebClient();
                        

        public jsonClasses.modpacks modPackList
        {
            get { return packs; }
            set { packs = value; }
        }

        public int packID
        {
            get { return id; }
            set { id = value; }
        }

        public List<bool> select
        {
            get { return selected; }
            set { selected = value; }
        }

        public DownloadNew()
        {
            InitializeComponent();
        }

        private void DownloadNew_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            client.Proxy = null;
        }

        private void DownloadNew_Shown(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.toDownloadFiles = 5;
                downloadFile(packs.list[id].modsFile, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\mods.json", null, true, false);
                while (downloading) { this.Update(); Application.DoEvents(); }
                downloadFile(packs.list[id].configFile, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\config.json", null, true, false);
                while (downloading) { this.Update(); Application.DoEvents(); }
                downloadFile(packs.list[id].librariesFile, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\libraries.json", null, true, false);
                while (downloading) { this.Update(); Application.DoEvents(); }
                downloadFile(packs.list[id].nativesFile, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\natives.json", null, true, false);
                while (downloading) { this.Update(); Application.DoEvents(); }
                downloadFile(packs.list[id].assetsFile, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\assets.json", null, true, false);
                while (downloading) { this.Update(); Application.DoEvents(); }
                downloadFile(packs.list[id].deleteFile, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\delete.json", null, true, false);
                while (downloading) { this.Update(); Application.DoEvents(); }

                jsonClasses.filesList mods = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\mods.json"));
                jsonClasses.filesList config = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\config.json"));
                jsonClasses.filesList libraries = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\libraries.json"));
                jsonClasses.filesList natives = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\natives.json"));
                jsonClasses.filesList assets = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\assets.json"));
                jsonClasses.deleteFiles delete = JsonConvert.DeserializeObject<jsonClasses.deleteFiles>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\temp\\delete.json"));

                downloadFile(packs.list[id].jar, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\versions\\" + packs.list[id].versionsPath + "\\" + packs.list[id].versionsPath + ".jar", null, false, false);

                progressBar1.Maximum = mods.files.Count() + assets.files.Count() + config.files.Count() + libraries.files.Count() + natives.files.Count();
                progressBar2.Maximum = 100;
                progressBar2.Value = 0;

                try
                {
                    //delete
                    for (int i = 0; i < delete.files.Count(); i++)
                    {
                        string file = vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\" + delete.files[i];
                        if (File.Exists(file))
                        {
                            try
                            {
                                //Console.WriteLine("Datei " + file + " existiert und wird gelöscht");
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
                            //Console.WriteLine("Datei " + file + " existiert nicht und wird nicht gelöscht");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorWindow err = new ErrorWindow();
                    err.ex = ex;
                    err.ShowDialog();
                }

                if (!selected[4])
                {
                    try
                    {
                        //assets                
                        for (int i = 0; i < assets.files.Count(); i++)
                        {


                            int j = i + 1;
                            label2.Text = "Lade Datei " + j + " von " + assets.files.Count() + " Dateien herunter!";
                            label1.Text = assets.files[i].path;
                            this.Update();
                            Application.DoEvents();                            
                            progressBar1.Value++;
                            count = 0;
                            downloadFile(vb.downloadLocation() + "modpack/modpacks/" + packs.list[id].tag + assets.files[i].url, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + assets.files[i].path, assets.files[i].md5, false, !selected[4]);
                            while (this.downloading)
                            {
                                this.Update();
                                Application.DoEvents();
                                if (canceled)
                                {
                                    break;
                                }
                            }
                            if (canceled)
                            {
                                break;
                            }
                        }
                        this.Update();
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
                    progressBar1.Value += mods.files.Count;
                }

                if (!selected[5])
                {
                    try
                    {
                        //natives                
                        for (int i = 0; i < natives.files.Count(); i++)
                        {
                            int j = i + 1;
                            label2.Text = "Lade Datei " + j + " von " + natives.files.Count() + " Dateien herunter!";
                            label1.Text = natives.files[i].path;
                            this.Update();
                            Application.DoEvents();
                            
                            progressBar1.Value++;
                            count = 0;
                            downloadFile(vb.downloadLocation() + "modpack/modpacks/" + packs.list[id].tag + natives.files[i].url, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + "\\versions\\" + packs.list[id].versionsPath + "\\" + packs.list[id].versionsPath + "-natives " + natives.files[i].path, natives.files[i].md5, false, !selected[5]);
                            while (downloading)
                            {
                                this.Update();
                                Application.DoEvents();
                                if (canceled)
                                {
                                    break;
                                }
                            }
                            if (canceled)
                            {
                                break;
                            }
                        }
                        this.Update();
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
                    progressBar1.Value += natives.files.Count;
                }

                if (!selected[6])
                {
                    try
                    {
                        //libraries                
                        for (int i = 0; i < libraries.files.Count(); i++)
                        {

                            int j = i + 1;
                            label2.Text = "Lade Config " + j + " von " + libraries.files.Count() + " Libraries herunter!";
                            label1.Text = libraries.files[i].path;
                            this.Update();
                            Application.DoEvents();
                            
                            progressBar1.Value++;
                            count = 0;
                            downloadFile(vb.downloadLocation() + "modpack/modpacks/" + packs.list[id].tag + libraries.files[i].url, vb.appdata() + "\\modpacks\\" + packs.list[id].tag +  libraries.files[i].path, libraries.files[i].md5, false, !selected[6]);
                            while (downloading)
                            {
                                this.Update();
                                Application.DoEvents();
                                if (canceled)
                                {
                                    break;
                                }
                            }
                            if (canceled)
                            {
                                break;
                            }
                        }
                        this.Update();
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
                    progressBar1.Value += libraries.files.Count;
                }

                if (!selected[0])
                {
                    try
                    {
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
                                
                                progressBar1.Value++;
                                count = 0;
                                downloadFile(vb.downloadLocation() + "modpack/modpacks/" + packs.list[id].tag + mods.files[i].url, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + mods.files[i].path, mods.files[i].md5, false, !selected[0]);
                                while (downloading)
                                {
                                    this.Update();
                                    Application.DoEvents();
                                    if (canceled)
                                    {
                                        break;
                                    }
                                }
                            }
                            if (canceled)
                            {
                                break;
                            }
                        }
                        this.Update();
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
                    progressBar1.Value += mods.files.Count;
                }

                if (!selected[1])
                {
                    try
                    {
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
                                
                                progressBar1.Value++;
                                count = 0;
                                downloadFile(vb.downloadLocation() + "modpack/modpacks/" + packs.list[id].tag + config.files[i].url, vb.appdata() + "\\modpacks\\" + packs.list[id].tag + config.files[i].path, config.files[i].md5, false, !selected[2]);
                                while (downloading)
                                {
                                    this.Update();
                                    Application.DoEvents();
                                    if (canceled)
                                    {
                                        break;
                                    }
                                }
                            }
                            if (canceled)
                            {
                                break;
                            }
                        }
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
                    progressBar1.Value += config.files.Count;
                }

                downloading = false;
                this.Update();
                this.Close();

            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }

            #region alt

            /*
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
                    while (this.downloading)
                    {
                        this.Update();
                        Application.DoEvents();
                    }
                    progressBar1.Value++;
                    downloadFile(assets.files[i].url, vb.appdata() + assets.files[i].path, assets.files[i].md5, false);
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
                    downloadFile(sonstiges.files[i].url, vb.appdata() + sonstiges.files[i].path, sonstiges.files[i].md5, false);
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
                    downloadFile(libraries.files[i].url, vb.appdata() + libraries.files[i].path, libraries.files[i].md5, false);
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
                        downloadFile(mods.files[i].url, vb.appdata() + mods.files[i].path, mods.files[i].md5, false);
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
                        downloadFile(config.files[i].url, vb.appdata() + config.files[i].path, config.files[i].md5, false);
                    }
                    if (canceled)
                    {
                        break;
                    }
                }
                downloading = false;
                this.Update();
                this.Close();
            }*/

            #endregion
        }

        #region downlaod File
        private void downloadFile(string url, string save, string md5, bool overrideFile, bool update)
        {
            try
            {                
                if (overrideFile)
                {
                    vb.debug("Overwriting File: " + save, "Downloading");
                    if (File.Exists(save))
                    {
                        File.Delete(save);
                    }
                }

                if (!File.Exists(save) || overrideFile)
                {
                    try
                    {
                        vb.debug("Downloading File: " + save + " | " + overrideFile.ToString() + " | " + File.Exists(save).ToString(), "Downloading");
                        string outputFolder = Path.GetDirectoryName(save);

                        if (!Directory.Exists(outputFolder))
                        {
                            Directory.CreateDirectory(outputFolder);
                        }

                        //MessageBox.Show("StartDownload");
                        downloading = true;
                        progressBar2.Value = 0;
                        sw.Start();
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        client.DownloadFileAsync(new Uri(url), save);
                    }
                    catch (Exception ex)
                    {
                        downloading = false;
                        Properties.Settings.Default.finishedFiles++;
                        ErrorWindow err = new ErrorWindow();
                        err.ex = ex;
                        err.ShowDialog();
                    }
                }
                else if (File.Exists(save) && update)
                {
                    vb.debug("Checking MD5 of: " + save, "Downloading");
                    string md51 = getMD5fromFile(save);
                    if (md51 != md5)
                    {
                        vb.debug("Updating File: " + save, "Downloading");
                        downloadFile(url, save, md5, true, false);
                    }
                }
                else
                {
                    File.Delete(save);
                    count++;
                    if (count > 1)
                    {
                        MessageBox.Show("Fehler bei datei " + url);
                    }
                    else
                    {
                        Console.WriteLine(count);
                        downloadFile(url, save, md5, overrideFile, update);
                    }                    
                    Properties.Settings.Default.finishedFiles++;
                }
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("DownloadFinished");
            Application.DoEvents();
            downloadSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            labelDownload.Text = string.Format("{0} MB / {1} MB",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            progressBar2.Value = e.ProgressPercentage;
            //Console.WriteLine(e.ProgressPercentage);
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                vb.debug(e.Error.StackTrace, "Download ERROR");
                //Console.WriteLine(currentDL);
            }
            else
            {
                vb.debug("Download finished", "Downloading");
            }
            downloading = false;
            sw.Reset();
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
