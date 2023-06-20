using System;
using System.Windows.Forms;
using IronXL;
using Prodavnica_Filmova2.Repository;
using Prodavnica_Filmova2.Tools;

namespace Prodavnica_Filmova2
{
    public partial class AdminWindow : Form
    {
        private AdminWindowRepository _adminWindowRepository;
        public AdminWindow()
        {
            InitializeComponent();
            _adminWindowRepository = new AdminWindowRepository(ConfigUtil.GetWorksheetPath());
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {
            _adminWindowRepository.DataBaseLoadFilm(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Da li ste sigurni";
            string title = "Upozorenje";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if(result == DialogResult.Yes)
            {
                _adminWindowRepository.DeleteRow(dataGridView1);
                _adminWindowRepository.DataBaseLoadFilm(dataGridView1);
            }
            else{}
        }       
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _adminWindowRepository.CellValueChange(dataGridView1);
        }

        private void button_film_Click(object sender, EventArgs e)
        {
            _adminWindowRepository.DataBaseLoadFilm(dataGridView1);
        }

        private void button_prodaje_Click(object sender, EventArgs e)
        {
            _adminWindowRepository.DataBaseLoadSales(dataGridView1);
        }
    }
}
