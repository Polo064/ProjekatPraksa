using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodavnica_Filmova2.Tools;

namespace Prodavnica_Filmova2.Repository
{
    public class AdminRepository
    {
        private string _workbookPath;

        public AdminRepository(string workbookPath)
        {
            _workbookPath = workbookPath;
        }

        public bool IsAdministrator(string username, string password)
        {
            WorkBook wb = WorkBook.Load(_workbookPath);
            WorkSheet ws = wb.GetWorkSheet(Consts.AdminWorksheet);

            int i = 1;
            bool usernameCheck = false;
            bool passwordCheck = false;

            while (i < 100)
            {
                if (ws[$"A{i}"].Value.ToString() == username)
                {
                    usernameCheck = true;
                    break;
                }
                i++;
            }
            i = 1;
            while (i < 100)
            {
                if (ws[$"B{i}"].Value.ToString() == password)
                {
                    passwordCheck = true;
                    break;
                }
                i++;
            }

            return usernameCheck && passwordCheck;
        }
    }
}
