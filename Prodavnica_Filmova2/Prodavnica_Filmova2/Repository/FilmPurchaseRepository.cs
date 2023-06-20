using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using Prodavnica_Filmova2.Tools;
using Prodavnica_Filmova2.Repository;

namespace Prodavnica_Filmova2.Repository
{
    class FilmPurchaseRepository
    {
        public Film film = new Film();
        Reziser reziser = new Reziser();
        Producent producent = new Producent();
        Zanr zanr = new Zanr();
        public Korisnik user = new Korisnik();
        private string _workbookPath;
        public string LoggedUser;
        public FilmPurchaseRepository(string workbookPath)
        {
            _workbookPath = workbookPath;
        }
        public void LoadSelectedFilm(string ime_filma)
        {
            film.Director = reziser;
            film.Producer = producent;
            film.Genre = zanr;
            WorkBook wb = WorkBook.Load(_workbookPath);
            WorkSheet ws = wb.GetWorkSheet(Consts.FilmWorksheet);
            for (int i = 0; i < 100; i++)
            {
                if (ws[$"A{i}"].Value.ToString() == ime_filma)
                {
                    //unos baze
                    WorkSheet w_reziser = wb.GetWorkSheet(Consts.DirectorWorksheet);
                    WorkSheet w_producent = wb.GetWorkSheet(Consts.ProducerWorksheet);
                    WorkSheet w_zanr = wb.GetWorkSheet(Consts.GenreWorksheet);


                    //unos imena
                    film.Name = ws[$"A{i}"].Value.ToString();

                    //unos rezisera
                    string s = ws[$"B{i}"].Value.ToString();
                    string[] reziser = s.Split(" ");
                    film.Director.d_name = reziser[0].ToString();
                    for (int j = 0; j < 100; j++)
                    {
                        if (w_reziser[$"A{i}"].Value.ToString() == reziser[0].ToString())
                        {
                            film.Director.d_surname = w_reziser[$"B{i}"].Value.ToString();
                            film.Director.d_age = w_reziser[$"C{i}"].Int32Value;
                            film.Director.BirthPlace = w_reziser[$"D{i}"].Value.ToString();
                            break;
                        }
                    }

                    //unos producenta
                    s = ws[$"C{i}"].Value.ToString();
                    string[] producent = s.Split(" ");
                    film.Producer.p_name = producent[0];
                    for (int k = 0; k < 50; k++)
                    {
                        if (w_producent[$"A{i}"].Value.ToString() == producent[0].ToString())
                        {
                            film.Producer.p_surname = w_producent[$"B{i}"].Value.ToString();
                            film.Producer.age = w_producent[$"C{i}"].Int32Value;
                            film.Producer.BirthPlace = w_producent[$"D{i}"].Value.ToString();
                            break;
                        }
                    }

                    //unos zanra
                    film.Genre.Name = ws[$"D{i}"].Value.ToString();

                    //unos godine izdavanja
                    film.DateOfRelease = ws[$"E{i}"].Int32Value;

                    //unos ocene
                    film.Rating = ws[$"F{i}"].DoubleValue;

                    //unos opisa
                    film.Description = ws[$"G{i}"].Value.ToString();

                    //unos kolicine
                    film.StockAmount = ws[$"H{i}"].Int32Value;

                    //unos cene
                    film.Price = ws[$"I{i}"].Int32Value;
                    break;
                }
            }
        }
        public void LoadUser(string loggedUser, ListBox listBox)
        {
            WorkBook wb = WorkBook.Load(_workbookPath);
            WorkSheet ws = wb.GetWorkSheet(Consts.UserWorksheet);

            for (int i = 0; i < 100; i++)
            {
                if(ws[$"A{i}"].Value.ToString() == loggedUser)
                {
                    user.Name = ws[$"A{i}"].Value.ToString();
                    user.Surname = ws[$"B{i}"].Value.ToString();
                    user.DateOfBirth = ws[$"C{i}"].Value.ToString();
                    user.Adress = ws[$"D{i}"].Value.ToString();
                    user.City = ws[$"E{i}"].Value.ToString();
                    break;
                }
            }
            listBox.Items.Add(user.Name);
            listBox.Items.Add(user.Surname);
            listBox.Items.Add(user.DateOfBirth);
            listBox.Items.Add(user.Adress);
            listBox.Items.Add(user.City);
        }
        public void Purchase(int kolicina, int cena)
        {
            WorkBook wb = WorkBook.Load(_workbookPath);
            WorkSheet ws = wb.GetWorkSheet(Consts.Purchasing);
            FilmPurchase filmPurchase = new FilmPurchase();
            for (int i = 1; i < 100; i++)           
            {
                if (ws[$"A{i}"].Value.ToString() == "0")
                {
                    ws[$"A{i}"].Value = user.Name + " " + user.Surname;
                    ws[$"B{i}"].Value = film.Name;
                    ws[$"C{i}"].Value = kolicina;
                    ws[$"D{i}"].Value = cena;
                    ws[$"E{i}"].Value = DateTime.Now;
                    break;
                }
            }
            wb.SaveAs(ConfigUtil.GetWorksheetPath());
        }
    }
}
