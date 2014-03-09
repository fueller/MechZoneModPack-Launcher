using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MechZoneModPack
{
    public class jsonClasses
    {
        #region Minecraft Login
        public class minecraftLogonJson1
        {
            public string accessToken { get; set; }
            public string clientToken { get; set; }
            public List<minecraftLogonJson2> availableProfiles { get; set; }
            public minecraftLogonJson2 selectedProfile { get; set; }
        }

        public class minecraftLogonJson2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class minecraftLogonJson3
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        #endregion

        #region get Files Folders
        public class filesList
        {
            public List<files2> files { get; set; }
        }

        public class files2
        {
            public string name { get; set; }
            public bool enabled { get; set; }
            public bool server { get; set; }
            public string forumLink { get; set; }
            public string version { get; set; }
            public bool config { get; set; }
            public string url { get; set; }
            public string path { get; set; }
            public string md5 { get; set; }
            public string description { get; set; }
            public string authors { get; set; }
        }
        #endregion

        #region minecraft Details

        public class minecraftDetails
        {
            public string id { get; set; }
            public string time { get; set; }
            public string releaseTime { get; set; }
            public string type { get; set; }
            public string processArguments { get; set; }
            public string minecraftArguments { get; set; }
            public int minimumLauncherVersion { get; set; }
            public List<libraries> libraries { get; set; }
            public string mainClass { get; set; }
        }

        public class libraries
        {
            public string name { get; set; }
            public List<rules> rules { get; set; }
            public natives natives { get; set; }
            public extract extract { get; set; }
        }

        public class rules
        {
            public string action { get; set; }
            public os os { get; set; }
        }

        public class os
        {
            public string name { get; set; }
            public string version { get; set; }
        }

        public class natives
        {
            public string linux { get; set; }
            public string windows { get; set; }
            public string osx { get; set; }
        }

        public class extract
        {
            public string[] exclude { get; set; } 
        }

        public class exclude
        {
            public string things { get; set; }
        }
        #endregion

        #region mcmodInfo
        public class mcmod
        {
            public string modid { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string version { get; set; }
            public string mcversion { get; set; }
            public string url { get; set; }
            public string updateUrl { get; set; }
            public string[] authors { get; set; }
            public string credits { get; set; }
            public string logoFile { get; set; }
            public string[] ascreenshots { get; set; }
            public string parent { get; set; }
            public string[] dependencies { get; set; }
        }
        #endregion

        #region deletefiles
        public class deleteFiles
        {
            public string[] files { get; set; }
        }
        #endregion

        #region modpacks
        public class modpacks
        {
            public List<modpacks2> list { get; set; }
        }

        public class modpacks2
        {
            public string name { get; set; }
            public string tag { get; set; }
            public string shortDescription { get; set; }
            public string longDescription { get; set; }
            public string modsVersion { get; set; }
            public string configVersion { get; set; }
            public string deleteVersion { get; set; }
            public string sonstigesVersion { get; set; }
            public string assetsVersion { get; set; }
            public string nativesVersion { get; set; }
            public string librariesVersion { get; set; }
            public string modsFile { get; set; }
            public string configFile { get; set; }
            public string assetsFile { get; set; }
            public string librariesFile { get; set; }
            public string nativesFile { get; set; }
            public string changelogUrl { get; set; }
            public string versionsPath { get; set; }
            public string jar { get; set; }
            public string logo { get; set; }
            public string mainLogo { get; set; }
            public List<string> folders { get; set; }
            public string deleteFile { get; set; }
            public string arguments { get; set; }
        }
        #endregion

        #region version
        public class version
        {
            public string modsVersion { get; set; }
            public string configVersion { get; set; }
            public string deleteVersion { get; set; }
            public string sonstigesVersion { get; set; }
            public string assetsVersion { get; set; }
            public string nativesVersion { get; set; }
            public string librariesVersion { get; set; }
        }
        #endregion
    }
}
