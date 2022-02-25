using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriemnayaKomissia.Controller
{
    class ConnectionString
    {
        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["PriemnayaKomissia.Properties.Settings.ConnStr"].ConnectionString;
            }
        }
    }
}
