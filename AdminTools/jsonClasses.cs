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

        #region version
        public class version
        {
            public string natives { get; set; }
            public string mods { get; set; }
            public string config { get; set; }
            public string libraries { get; set; }
            public string forge { get; set; }
            public string minecraft { get; set; }
            public bool update { get; set; }
        }
        #endregion

        #region mcmodInfo
        public class mcmod
        {
            public List<mcmod02> infos { get; set; }
            public string modinfoversion { get; set; }
        }

        public class mcmod02
        {
            public string modid { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string version { get; set; }
            public string mcversion { get; set; }
            public string url { get; set; }
            public string updateUrl { get; set; }
            public List<string> authors { get; set; }
            public string credits { get; set; }
            public string logoFile { get; set; }
            public List<object> screenshots { get; set; }
            public string parent { get; set; }
            public List<object> requiredMods { get; set; }
            public List<object> dependencies { get; set; }
            public List<object> dependants { get; set; }
            public string useDependencyInformation { get; set; }
            public string modinfoversion { get; set; }
        }
        #endregion
    }
}
