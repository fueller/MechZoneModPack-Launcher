using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace helpTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var j = JsonConvert.DeserializeObject<files01>(File.ReadAllText(@"H:\tmp\test.json"));
            files2 output = new files2();
            string[] test = new string[j.Contents.Count];
            for (int i = 0; i < j.Contents.Count; i++)
			{
			    output.path = "\\assets\\" + j.Contents[i].Key.Replace("/","\\");
                output.url = "http://s3.amazonaws.com/Minecraft.Resources/" + j.Contents[i].Key;

                downloadFile(output.url, "H:\\tmp" + output.path, null);
                output.md5 = getMD5fromFile("H:\\tmp" + output.path);
                test[i] = JsonConvert.SerializeObject(output);
			}
            foreach (string str in test)
            {
                Debug.Print(str);
            }
            
        }

        public class files01
        {
            public string Name { get; set; }
            public string Prefix { get; set; }
            public string Marker { get; set; }
            public string MaxKeys { get; set; }
            public string IsTruncated { get; set; }
            public List<files02> Contents { get; set; }
        }

        public class files02
        {
            public string Key { get; set; }
            public string LastModified { get; set; }
            public string ETag { get; set; }
            public string Size { get; set; }
            public string StorageClass { get; set; }
        }

        public class filesOutput
        {
            public List<files2> files { get; set; }
        }
        public class files2
        {
            public string url { get; set; }
            public string path { get; set; }
            public string md5 { get; set; }
        }

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
                    client.DownloadFile(new Uri(url), save);
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
                    }
                    else
                    {
                        MessageBox.Show("Datei " + save + " ist veraltet");
                        File.Delete(save);
                        downloadFile(url, save, md5);
                    }
                }
                else
                {
                    
                }
            }
        }
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
        public static string getMD5fromFile(string path)
        {
            System.IO.FileStream FileCheck = System.IO.File.OpenRead(path);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Hash = md5.ComputeHash(FileCheck);
            FileCheck.Close();
            return BitConverter.ToString(md5Hash).Replace("-", "").ToLower();
        }
    }
}
