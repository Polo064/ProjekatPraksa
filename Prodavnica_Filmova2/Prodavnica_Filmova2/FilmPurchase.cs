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

namespace Prodavnica_Filmova2
{
    public partial class FilmPurchase : Form
    {
        private FilmPurchaseRepository _filmPurchaseRepository;
        public FilmPurchase()
        {
            InitializeComponent();
            _filmPurchaseRepository = new FilmPurchaseRepository(ConfigUtil.GetWorksheetPath());
        }
        public string ime_filma;
        public int cena = 0;
        public string LoggedUser;
        public int kolicina = 0;
        private void FilmPurchase_Load(object sender, EventArgs e)
        {
            _filmPurchaseRepository.LoadSelectedFilm(ime_filma);
            _filmPurchaseRepository.LoadUser(LoggedUser, listBox1);
            label1.Text = _filmPurchaseRepository.film.ToString();
            label2.Text = _filmPurchaseRepository.film.ispisiOpis();
            cena = _filmPurchaseRepository.film.Price;
            label4.Text += cena;
        }                  
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            cena = (int)(numericUpDown1.Value * _filmPurchaseRepository.film.Price);
            label4.Text = $"Konacna cena: {cena}";
            kolicina = (int)numericUpDown1.Value;
        }

        private void button_purchase_Click(object sender, EventArgs e)
        {
            string message = "Da li ste sigurni";
            string title = "Upozorenje";
            string message2 = "Uspesno ste kupili film";
            string title2 = "Uspeh";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                _filmPurchaseRepository.Purchase(kolicina, cena);
                MessageBox.Show(message2, title2);
            }
            else { }
        }
    }
}
