using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using System.Configuration;
using System.IO;
using Prodavnica_Filmova2.Tools;

namespace Prodavnica_Filmova2.Repository
{
    class UserRegistrationRepository
    {
        private string _workbookPath;
        public UserRegistrationRepository(string workbookPath)
        {
            _workbookPath = workbookPath;
        }
        public void Registration(string name, string surname, string dateOfBirth, string adress, string city)
        {
            Korisnik korisnik = new Korisnik();
            korisnik.Name = name;
            korisnik.Surname = surname;
            korisnik.DateOfBirth = dateOfBirth;
            korisnik.Adress = adress;
            korisnik.City = city;

            WorkBook wb = WorkBook.Load(_workbookPath);
            WorkSheet ws = wb.GetWorkSheet(Consts.UserWorksheet);

            int i = 1;
            while (i < 100)
            {
                if (ws[$"A{i}"].Value.ToString() == "0")
                {
                    ws[$"A{i}"].Value = korisnik.Name;
                    ws[$"B{i}"].Value = korisnik.Surname;
                    ws[$"C{i}"].Value = korisnik.DateOfBirth;
                    ws[$"D{i}"].Value = korisnik.Adress;
                    ws[$"E{i}"].Value = korisnik.City;
                    break;
                }
                i++;
            }            
            wb.SaveAs(ConfigUtil.GetWorksheetPath());
        }
    }
}
