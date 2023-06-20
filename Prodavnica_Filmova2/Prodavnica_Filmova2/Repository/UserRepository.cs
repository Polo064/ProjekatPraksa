using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using Prodavnica_Filmova2.Tools;

namespace Prodavnica_Filmova2.Repository
{
    public class UserRepository
    {
        private string _workbookPath;

        public UserRepository(string workbookPath)
        {
            _workbookPath = workbookPath;
        }
        public bool IsUser(string name, string surname)
        {
            WorkBook wb = WorkBook.Load(_workbookPath);
            WorkSheet ws = wb.GetWorkSheet(Consts.UserWorksheet);

            int i = 1;
            bool nameCheck = false;
            bool surnameCheck = false;
            while (ws[$"A{i}"].Value.ToString() != "0")
            {
                if (ws[$"A{i}"].Value.ToString() == name)
                {
                    nameCheck = true;
                    break;
                }
                i++;
            }
            while (ws[$"B{i}"].Value.ToString() == surname)
            {
                if (ws[$"B{i}"].Value.ToString() == surname)
                {
                    surnameCheck = true;
                    break;
                }
                i++;
            }

            return nameCheck && surnameCheck;
        }
    }
}
