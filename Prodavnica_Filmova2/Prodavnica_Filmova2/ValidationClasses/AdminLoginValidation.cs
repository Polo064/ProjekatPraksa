using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_Filmova2.ValidationClasses
{
    class AdminLoginValidation
    {
        public AdminLoginValidation()
        {

        }
        public bool IsEmpty(string username, string password)
        {
            if (username == "" || password == "")
            {
                return true;
            }
            else return false;
        }
    }
}
