using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prodavnica_Filmova2.Repository;
using Prodavnica_Filmova2.Tools;
using Prodavnica_Filmova2.ValidationClasses;

namespace Prodavnica_Filmova2
{
    public partial class KorinsikLogin : Form
    {
        private UserRepository _userRepository;
        private UserLoginValidation _userLoginValidation;
        public KorinsikLogin()
        {
            InitializeComponent();
            _userRepository = new UserRepository(ConfigUtil.GetWorksheetPath());
            _userLoginValidation = new UserLoginValidation();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(_userLoginValidation.IsEmpty(textBox_ime.Text, textBox_prezime.Text))
            {
                label6.Text = "Niste uneli sve podatke";
            }
            else if (_userLoginValidation.IsNumber(textBox_ime.Text, textBox_prezime.Text))
            {
                label6.Text = "Ime i Prezime nesmeju da imaju broj";
            }
            else
            {
                if (_userRepository.IsUser(textBox_ime.Text, textBox_prezime.Text))
                {
                    string message = "Uspesno ste se ulogovali!";
                    string title = "Uspeh";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, button);
                    if (result == DialogResult.OK)
                    {
                        var form1 = new Form1();
                        form1.LoggedUser = textBox_ime.Text;
                        this.Hide();
                        form1.Show();
                    }
                    else{}
                }
                else
                {
                    label6.Text = "Vasi podaci nisu registrovani" + "\n" + "Molim vas registruj te se";
                    textBox_ime.Text = string.Empty;
                    textBox_prezime.Text = string.Empty;
                }
            }           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login register = new Login();
            this.Hide();
            register.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            this.Hide();
            adminLogin.Show();
        }
    }
}
