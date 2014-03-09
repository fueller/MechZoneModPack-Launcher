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
using System.Web;
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
                StreamWriter file = new StreamWriter(@"d:\debug.txt",true);
                file.WriteLine(ex.Message);
                file.Close();
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region get files in dir
        List<string> getFilesInDir(string sDir)
        {
            List<string> files = new List<string>();
            List<string> newFiles = new List<string>();
            List<string> duplicates = new List<string>();
            
            try
            {
                
                foreach (string f in Directory.EnumerateFiles(sDir, "*.*", SearchOption.AllDirectories))
                {
                    //Console.WriteLine(f.Replace(appdata() + replace, ""));
                    files.Add(f);                
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
            folderBrowserDialog1.SelectedPath = appdata() + "\\.MechZoneModPack\\";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string dir = folderBrowserDialog1.SelectedPath;
                List<string> output = new List<string>();
                List<string> files = getFilesInDir(dir);

                for (int i = 0; i < files.Count; i++)
                {
                    jsonClasses.files2 list = new jsonClasses.files2();
                    list.path = "\\assets\\" + files[i].Replace(dir + "\\", "");
                    list.md5 = getMD5fromFile(files[i]);
                    list.url = "/assets/" + files[i].Replace(dir + "\\", "").Replace("\\", "/");
                    list.server = false;
                    list.enabled = true;

                    output.Add(JsonConvert.SerializeObject(list));
                }

                #region save file
                saveFileDialog1.Filter = "json Files (*.json)|*.json";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        string fileStart = "{\"files\": [";
                        string fileEnd = "]}";
                        string file = "";
                        file += fileStart;
                        for (int i = 0; i < output.Count; i++)
                        {
                            string add = ",";
                            if (i == output.Count - 1)
                            {
                                add = "";
                            }
                            file += output[i] + add;
                            file += "\n";
                        }
                        file += fileEnd;
                        Console.WriteLine(file);
                        StreamWriter file2 = new StreamWriter(@"d:\debug.txt",true);
                        file2.WriteLine(file);
                        file2.Close();
                        jsonClasses.filesList filesList = JsonConvert.DeserializeObject<jsonClasses.filesList>(file);
                        string done = JsonConvert.SerializeObject(filesList, Formatting.Indented);

                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                        fs.Write(StringToByteArray(done), 0, StringToByteArray(done).Length);
                        fs.Close();
                    }
                }
                #endregion
            }
        }
        #endregion

        #region mods
        private void generateModList_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = appdata() + "\\.MechZoneModPack\\";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string dir = folderBrowserDialog1.SelectedPath;
                List<string> output = new List<string>();
                List<string> files = getFilesInDir(dir);

                for (int i = 0; i < files.Count; i++)
                {
                    jsonClasses.files2 list = new jsonClasses.files2();
                    list.path = "\\mods\\" + files[i].Replace(dir + "\\", "");
                    list.md5 = getMD5fromFile(files[i]);
                    list.url = "/mods/" + files[i].Replace(dir + "\\", "").Replace("\\", "/");
                    list.server = true;
                    list.enabled = true;
                    #region mcmod.info
                    try
                    {
                        FastZip fz = new FastZip();
                        fz.ExtractZip(files[i], @"D:\temp\mods\", "mcmod.info");
                        List<jsonClasses.mcmod02> itemList = JsonConvert.DeserializeObject<List<jsonClasses.mcmod02>>(File.ReadAllText(@"D:\temp\mods\mcmod.info"));

                        list.version += itemList[0].version;
                        list.name += itemList[0].name;
                        list.description += itemList[0].description;
                        if (itemList[0].url == null || itemList[0].url == "")
                        {
                            list.forumLink += "http://gog.is/" + list.name;
                        }
                        else
                        {
                            list.forumLink += itemList[0].url;
                        }
                        
                        for (int j = 0; j < itemList[0].authors.Count; j++)
                        {
                            string add = ", ";
                            if (j == itemList[0].authors.Count-1)
                            {
                                add = "";
                            }
                            list.authors += itemList[0].authors[j] + add;
                        }
                        
                        for (int j = 0; j < itemList[0].authorList.Count; j++)
                        {
                            string add = ", ";
                            if (j == itemList[0].authorList.Count - 1)
                            {
                                add = "";
                            }
                            list.authors += itemList[0].authorList[j] + add;
                        }

                        File.Delete(@"D:\temp\mods\mcmod.info");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + " | " + files[i]);
                        StreamWriter file2 = new StreamWriter(@"d:\debug.txt",true);
                        file2.WriteLine(ex.Message + " | " + files[i]);
                        file2.Close();
                        list.name = files[i].Replace(dir + "\\", "").Replace(".zip", "").Replace(".jar", "").Replace("\\", "");
                        if (list.forumLink == null || list.forumLink == "")
                        {
                            list.forumLink += "http://gog.is/" + list.name;
                        }
                        File.Delete(@"D:\temp\mods\mcmod.info");
                    }
                    #endregion
                    output.Add(JsonConvert.SerializeObject(list));

                }
                #region savefile
                saveFileDialog1.Filter = "json Files (*.json)|*.json";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        string fileStart = "{\"files\": [";
                        string fileEnd = "]}";
                        string file = "";
                        file += fileStart;
                        for (int i = 0; i < output.Count; i++)
                        {
                            string add = ",";
                            if (i == output.Count-1)
                            {
                                add = "";
                            }
                            file += output[i] + add;
                            file += "\n";
                        }
                        file += fileEnd;
                        Console.WriteLine(file);
                        StreamWriter file2 = new StreamWriter(@"d:\debug.txt",true);
                        file2.WriteLine(file);
                        file2.Close();
                        jsonClasses.filesList filesList = JsonConvert.DeserializeObject<jsonClasses.filesList>(file);
                        string done = JsonConvert.SerializeObject(filesList, Formatting.Indented);
                        
                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                        fs.Write(StringToByteArray(done), 0, StringToByteArray(done).Length);
                        fs.Close();
                    }
                }
                #endregion
            }
        }
        #endregion

        #region config
        private void generateConfigList_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = appdata() + "\\.MechZoneModPack\\";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string dir = folderBrowserDialog1.SelectedPath;
                List<string> output = new List<string>();
                List<string> files = getFilesInDir(dir);

                for (int i = 0; i < files.Count; i++)
                {
                    jsonClasses.files2 list = new jsonClasses.files2();
                    list.path = "\\config\\" + files[i].Replace(dir + "\\", "");
                    list.md5 = getMD5fromFile(files[i]);
                    list.url = "/config/" + files[i].Replace(dir + "\\", "").Replace("\\", "/");
                    list.server = true;
                    list.config = true;
                    list.enabled = true;
                    output.Add(JsonConvert.SerializeObject(list));
                }
                #region save file
                saveFileDialog1.Filter = "json Files (*.json)|*.json";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        string fileStart = "{\"files\": [";
                        string fileEnd = "]}";
                        string file = "";
                        file += fileStart;
                        for (int i = 0; i < output.Count; i++)
                        {
                            string add = ",";
                            if (i == output.Count - 1)
                            {
                                add = "";
                            }
                            file += output[i] + add;
                            file += "\n";
                        }
                        file += fileEnd;
                        Console.WriteLine(file);
                        StreamWriter file2 = new StreamWriter(@"d:\debug.txt",true);
                        file2.WriteLine(file);
                        file2.Close();
                        jsonClasses.filesList filesList = JsonConvert.DeserializeObject<jsonClasses.filesList>(file);
                        string done = JsonConvert.SerializeObject(filesList, Formatting.Indented);

                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                        fs.Write(StringToByteArray(done), 0, StringToByteArray(done).Length);
                        fs.Close();
                    }
                }
                #endregion
            }
        }
        #endregion

        #region libraries
        private void generateLibrariesList_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = appdata() + "\\.MechZoneModPack\\";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string dir = folderBrowserDialog1.SelectedPath;
                List<string> output = new List<string>();
                List<string> files = getFilesInDir(dir);

                for (int i = 0; i < files.Count; i++)
                {
                    jsonClasses.files2 list = new jsonClasses.files2();
                    list.path = "\\libraries\\" + files[i].Replace(dir + "\\", "");
                    list.md5 = getMD5fromFile(files[i]);
                    list.url = "/libraries/" + files[i].Replace(dir + "\\", "").Replace("\\", "/");
                    list.server = true;

                    output.Add(JsonConvert.SerializeObject(list));
                }

                #region save file
                saveFileDialog1.Filter = "json Files (*.json)|*.json";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        string fileStart = "{\"files\": [";
                        string fileEnd = "]}";
                        string file = "";
                        file += fileStart;
                        for (int i = 0; i < output.Count; i++)
                        {
                            string add = ",";
                            if (i == output.Count - 1)
                            {
                                add = "";
                            }
                            file += output[i] + add;
                            file += "\n";
                        }
                        file += fileEnd;
                        Console.WriteLine(file);
                        StreamWriter file2 = new StreamWriter(@"d:\debug.txt",true);
                        file2.WriteLine(file);
                        file2.Close();
                        jsonClasses.filesList filesList = JsonConvert.DeserializeObject<jsonClasses.filesList>(file);
                        string done = JsonConvert.SerializeObject(filesList, Formatting.Indented);

                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                        fs.Write(StringToByteArray(done), 0, StringToByteArray(done).Length);
                        fs.Close();
                    }
                }
                #endregion
            }
        }
        #endregion

        #region string to byte
        private byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(str);
        }
        #endregion

        private void itempanelToJson_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = appdata() + "\\dumps";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] file = File.ReadAllLines(openFileDialog1.FileName);
                string[] finish = new string[file.Length];
                
                for (int i = 1; i < file.Length; i++)
                {
                    char[] seperator = { ',' };
                    string[] item = file[i].Split(seperator);
                    //Console.WriteLine("\"" + item[0] + ":" + item[1] + "\": \"" + item[3].Replace(" ", "_") + "\",");
                    finish[i] = "\"" + item[0] + ":" + item[1] + "\": \"" + item[3].Replace(" ", "_").Replace("\"","") + "\",";
                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    fs.Write(StringToByteArray("{"), 0, StringToByteArray("{").Length);
                    for (int i = 1; i < finish.Length; i++)
                    {
                        fs.Write(StringToByteArray(finish[i] + ","), 0, StringToByteArray(finish[i]).Length);
                        fs.Write(StringToByteArray("\n"), 0, 1);
                    }
                    fs.Write(StringToByteArray("}"), 0, StringToByteArray("}").Length);
                    fs.Close();
                }
            }
            
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
