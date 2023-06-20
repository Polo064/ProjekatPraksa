using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_Filmova2.ValidationClasses
{
    class UserLoginValidation
    {
        public UserLoginValidation()
        {

        }
        public bool IsEmpty(string name, string surname)
        {
            if (name == "" || surname == "")
            {
                return true;
            }
            else return false;
        }
        public bool IsNumber(string name, string surname)
        {
            if (name.Any(char.IsDigit) || surname.Any(char.IsDigit))
            {
                return true;
            }
            else return false;
        }
    }
}
