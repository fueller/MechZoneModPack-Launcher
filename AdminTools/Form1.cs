using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using AdminTools;
using MechZoneModPack;
using Ionic.Zip;
using Newtonsoft.Json.Linq;
using ICSharpCode.SharpZipLib.Zip;

namespace AdminTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fileStart = "{\n\"files\": [";
        string fileEnd = "]}";

        #region getMD5fromFile
        public static string getMD5fromFile(string path)
        {
            //MessageBox.Show(path);
            try
            {
                System.IO.FileStream FileCheck = System.IO.File.OpenRead(path);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] md5Hash = md5.ComputeHash(FileCheck);
                FileCheck.Close();
                return BitConverter.ToString(md5Hash).Replace("-", "").ToLower();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region get files in dir
        List<string> getFilesInDir(string sDir, string replace, string subDir)
        {
            List<string> files = new List<string>();
            List<string> newFiles = new List<string>();
            List<string> duplicates = new List<string>();
            
            try
            {
                
                foreach (string f in Directory.EnumerateFiles(sDir, "*.*", SearchOption.AllDirectories))
                {
                    //Console.WriteLine(f.Replace(appdata() + replace, ""));
                    files.Add(f.Replace(appdata() + subDir + replace, ""));                
                }

                
                foreach (string s in files)
                {
                    if (!newFiles.Contains(s))
                    {
                        newFiles.Add(s);
                    }
                    else
                    {
                        duplicates.Add(s);
                    }
                }
                
                MessageBox.Show("Count getFiles: " + newFiles.Count);
                MessageBox.Show("Count Duplicates: " + duplicates.Count);
                return newFiles;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion

        #region appdata
        public static string appdata()
        {
            string pfad = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            return pfad;
        }
        #endregion

        #region assets
        private void generateAssetsList_Click(object sender, EventArgs e)
        {
            string dir = @"C:\Users\Philip\AppData\Roaming\.minecraft\assets";
            List<string> output = new List<string>();
            List<string> files = getFilesInDir(dir, "\\assets", "\\.minecraft");
            jsonClasses.filesList mainList = new jsonClasses.filesList();

            MessageBox.Show("Assets start: " + files.Count);
            foreach (string str in files)
            {
                jsonClasses.files2 list = new jsonClasses.files2();
                list.path = "\\assets" + str;
                list.md5 = getMD5fromFile(appdata() + "\\.minecraft\\assets" + str);
                list.url = "http://mechzone.net/modpack/files/minecraft/assets" + str.Replace("\\", "/");
                list.server = false;
                list.enabled = true;

                output.Add(JsonConvert.SerializeObject(list));
            }

            saveFileDialog1.Filter = "json Files (*.json)|*.json";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    fs.Write(StringToByteArray(fileStart), 0, StringToByteArray(fileStart).Length);
                    MessageBox.Show("Assets Count: " + output.Count);
                    for (int i = 0; i < output.Count; i++)
                    {
                        fs.Write(StringToByteArray(output[i] + ","), 0, StringToByteArray(output[i] + ",").Length);
                        fs.Write(StringToByteArray("\n"), 0, 1);
                    }
                    fs.Write(StringToByteArray(fileEnd), 0, StringToByteArray(fileEnd).Length);
                    fs.Close();
                }
            }
            MessageBox.Show("Done");
        }
        #endregion

        #region mods
        private void generateModList_Click(object sender, EventArgs e)
        {
            string dir = @"C:\Users\Philip\AppData\Roaming\.MechZoneModPack\mods";
            List<string> output = new List<string>();
            List<string> files = getFilesInDir(dir, "\\mods", "\\.MechZoneModPack");
            jsonClasses.filesList mainList = new jsonClasses.filesList();

            foreach (string str in files)
            {
                Console.WriteLine(str);
                jsonClasses.files2 list = new jsonClasses.files2();
                string path = appdata() + "\\.MechZoneModPack\\mods" + str;
                list.path = "\\mods" + str;
                list.md5 = getMD5fromFile(path);
                list.url = "http://mechzone.net/modpack/files/minecraft/mods" + str.Replace("\\", "/");
                list.server = true;
                list.enabled = true;
                string strMod = str;

                try
                {

                    FastZip fz = new FastZip();
                    fz.ExtractZip(path, @"D:\temp\mods\", "mcmod.info");
                    var itemList = JsonConvert.DeserializeObject<List<jsonClasses.mcmod02>>(File.ReadAllText(@"D:\temp\mods\mcmod.info"));

                    list.version += itemList[0].version;
                    list.name += itemList[0].name;
                    list.description += itemList[0].description;
                    list.forumLink += itemList[0].url;
                    for (int j = 0; j < itemList[0].authors.Count; j++)
                    {
                        list.authors += itemList[0].authors[j] + " "; 
                    }

                    File.Delete(@"D:\temp\mods\mcmod.info");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message + " | " + strMod);
                    list.name = str.Replace(".zip", "").Replace(".jar", "").Replace("\\", ""); ;
                }

                output.Add(JsonConvert.SerializeObject(list));
            }

            saveFileDialog1.Filter = "json Files (*.json)|*.json";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    fs.Write(StringToByteArray(fileStart), 0, StringToByteArray(fileStart).Length);
                    for (int i = 0; i < output.Count; i++)
                    {
                        fs.Write(StringToByteArray(output[i] + ","), 0, StringToByteArray(output[i] + ",").Length);
                        fs.Write(StringToByteArray("\n"), 0, 1);
                    }
                    fs.Write(StringToByteArray(fileEnd), 0, StringToByteArray(fileEnd).Length);
                    fs.Close();
                }
            }
            MessageBox.Show("Done");
        }
        #endregion

        #region config
        private void generateConfigList_Click(object sender, EventArgs e)
        {
            string dir = @"C:\Users\Philip\AppData\Roaming\.MechZoneModPack\config";
            List<string> output = new List<string>();
            List<string> files = getFilesInDir(dir, "\\config", "\\.MechZoneModPack");
            jsonClasses.filesList mainList = new jsonClasses.filesList();

            foreach (string str in files)
            {
                jsonClasses.files2 list = new jsonClasses.files2();
                list.path = "\\config" + str;
                list.md5 = getMD5fromFile(appdata() + "\\.MechZoneModPack\\config" + str);
                list.url = "http://mechzone.net/modpack/files/minecraft/config" + str.Replace("\\", "/");
                list.server = true;
                list.config = true;
                list.enabled = true;

                output.Add(JsonConvert.SerializeObject(list));
            }

            saveFileDialog1.Filter = "json Files (*.json)|*.json";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    fs.Write(StringToByteArray(fileStart), 0, StringToByteArray(fileStart).Length);
                    for (int i = 0; i < output.Count; i++)
                    {
                        fs.Write(StringToByteArray(output[i] + ","), 0, StringToByteArray(output[i] + ",").Length);
                        fs.Write(StringToByteArray("\n"), 0, 1);
                    }
                    fs.Write(StringToByteArray(fileEnd), 0, StringToByteArray(fileEnd).Length);
                    fs.Close();
                }
            }
            MessageBox.Show("Done");
        }
        #endregion

        #region libraries
        private void generateLibrariesList_Click(object sender, EventArgs e)
        {
            string dir = @"C:\Users\Philip\AppData\Roaming\.MechZoneModPack\libraries";
            List<string> output = new List<string>();
            List<string> files = getFilesInDir(dir, "\\libraries", "\\.MechZoneModPack");
            jsonClasses.filesList mainList = new jsonClasses.filesList();

            foreach (string str in files)
            {
                jsonClasses.files2 list = new jsonClasses.files2();
                list.path = "\\libraries" + str;
                list.md5 = getMD5fromFile(appdata() + "\\.MechZoneModPack\\libraries" + str);
                list.url = "http://mechzone.net/modpack/files/minecraft/libraries" + str.Replace("\\", "/");
                list.server = true;

                output.Add(JsonConvert.SerializeObject(list));
            }

            saveFileDialog1.Filter = "json Files (*.json)|*.json";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    fs.Write(StringToByteArray(fileStart), 0, StringToByteArray(fileStart).Length);
                    for (int i = 0; i < output.Count; i++)
                    {
                        fs.Write(StringToByteArray(output[i] + ","), 0, StringToByteArray(output[i] + ",").Length);
                        fs.Write(StringToByteArray("\n"), 0, 1);
                    }
                    fs.Write(StringToByteArray(fileEnd), 0, StringToByteArray(fileEnd).Length);
                    fs.Close();
                }
            }
            MessageBox.Show("Done");
        }
        #endregion

        #region string to byte
        private byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(str);
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

    }
    public class encappedListOfStrings
    {
        public encappedListOfStrings() { }
        public encappedListOfStrings(List<string> the_list)
        {
            _listOfStrings = the_list;
        }
        private List<string> _listOfStrings;
        public List<string> ListOfStrings
        {
            get { return _listOfStrings; }
        }
    }
}
