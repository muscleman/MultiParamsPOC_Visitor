using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiParamsPOC.Entities
{
    public class User
    {
        public int? id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_guid { get; set; }
        public string username { get; set; }
        public string legacy_username { get; set; }

    }
}
