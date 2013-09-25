using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vBoxingModPack
{
    class jsonClasses
    {
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
    }
}
