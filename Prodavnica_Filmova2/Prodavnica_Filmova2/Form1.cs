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
using System.Configuration;
using Prodavnica_Filmova2.Tools;

namespace Prodavnica_Filmova2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Film film = new Film();
        Reziser reziser = new Reziser();
        Producent producent = new Producent();
        Zanr zanr = new Zanr();
        public string selectedFilm;
        public string LoggedUser;
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button_kupi.Visible == false)
            {
                button_kupi.Visible = true;
            }
            UnosFilma();
            label1.Text = string.Empty;
            label1.Text = film.ToString();
            label2.Text = film.ispisiOpis();
        }
        void UnosFilma()
        {
            film.Director = reziser;
            film.Producer = producent;
            film.Genre = zanr;
            string ime_filma = listBox1.SelectedItem.ToString();
            WorkBook wb = WorkBook.Load(ConfigUtil.GetWorksheetPath());
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
                        if(w_reziser[$"A{i}"].Value.ToString() == reziser[0].ToString())
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
                        if(w_producent[$"A{i}"].Value.ToString() == producent[0].ToString())
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

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //ispis filmova pri ucitavanju forme            
            WorkBook wb = WorkBook.Load(ConfigUtil.GetWorksheetPath());
            WorkSheet ws = wb.GetWorkSheet(Consts.FilmWorksheet);
            int i = 2;
            while(ws[$"A{i}"].Value.ToString() != "0")
            {                
                listBox1.Items.Add(ws[$"A{i}"].Value);
                i++;
            }
            //Ispis ulogovanog korisnika
            label3.Text += LoggedUser;
        }

        private void button_kupi_Click(object sender, EventArgs e)
        {
            FilmPurchase filmPurchase = new FilmPurchase();
            selectedFilm = listBox1.SelectedItem.ToString();
            filmPurchase.ime_filma = selectedFilm;
            filmPurchase.LoggedUser = LoggedUser;
            this.Hide();
            filmPurchase.Show();
        }
    }
}
