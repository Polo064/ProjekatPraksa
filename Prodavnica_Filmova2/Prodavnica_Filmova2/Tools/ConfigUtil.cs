using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Prodavnica_Filmova2.Tools
{
    class ConfigUtil
    {
        public static string GetWorksheetPath()
        {
            return Environment.ExpandEnvironmentVariables(ConfigurationManager.AppSettings["Path"]);
        }
    }
}
