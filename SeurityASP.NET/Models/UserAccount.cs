using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeurityASP.NET.Models
{
    public class UserAccount
    {
        public string ID { get; set; }

        public string UiD { get; set; }
        public string Pwd { get; set; }

        public string FullName { get; set; }
    }
}