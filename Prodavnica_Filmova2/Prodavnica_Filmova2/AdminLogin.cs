﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using Prodavnica_Filmova2.Repository;
using Prodavnica_Filmova2.Tools;
using Prodavnica_Filmova2.ValidationClasses;

namespace Prodavnica_Filmova2
{
    public partial class AdminLogin : Form
    {
        private AdminRepository _adminRepository;
        private AdminLoginValidation _adminLoginValidation;
        public AdminLogin()
        {
            InitializeComponent();
            _adminRepository = new AdminRepository(ConfigUtil.GetWorksheetPath());
            _adminLoginValidation = new AdminLoginValidation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_adminLoginValidation.IsEmpty(textBox_username.Text, textBox_password.Text))
            {
                label3.Text = "Niste uneli sve podatke";
            }
            else
            {
                if (_adminRepository.IsAdministrator(textBox_username.Text, textBox_password.Text))
                {
                    string message = "Uspesno ste se ulogovali!";
                    string title = "Uspeh";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, button);
                    if (result == DialogResult.OK)
                    {
                        var adminWindow = new AdminWindow();
                        this.Hide();
                        adminWindow.Show();
                    }
                    else { }
                }
                else
                {
                    label3.Text = "Niste uneli dobar username ili password";
                    textBox_username.Text = string.Empty;
                    textBox_password.Text = string.Empty;
                }
            }
        }
    }
}
