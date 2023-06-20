using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Data.Common;
using IronXL;
using Prodavnica_Filmova2.Repository;
using System.Configuration;
using Prodavnica_Filmova2.Tools;

namespace Prodavnica_Filmova2
{
    public partial class Login : Form
    {
        private TextBox textBox_ime;
        private TextBox textBox_prezime;
        private TextBox textBox_adresa;
        private TextBox textBox_grad;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;

        private UserRegistrationRepository _userRegistrationRepository;

        public Login()
        {
            InitializeComponent();
            _userRegistrationRepository = new UserRegistrationRepository(ConfigUtil.GetWorksheetPath());
        }

        private void InitializeComponent()
        {
            this.textBox_ime = new System.Windows.Forms.TextBox();
            this.textBox_prezime = new System.Windows.Forms.TextBox();
            this.textBox_adresa = new System.Windows.Forms.TextBox();
            this.textBox_grad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_ime
            // 
            this.textBox_ime.Location = new System.Drawing.Point(124, 133);
            this.textBox_ime.Name = "textBox_ime";
            this.textBox_ime.Size = new System.Drawing.Size(125, 27);
            this.textBox_ime.TabIndex = 0;
            // 
            // textBox_prezime
            // 
            this.textBox_prezime.Location = new System.Drawing.Point(124, 207);
            this.textBox_prezime.Name = "textBox_prezime";
            this.textBox_prezime.Size = new System.Drawing.Size(125, 27);
            this.textBox_prezime.TabIndex = 1;
            // 
            // textBox_adresa
            // 
            this.textBox_adresa.Location = new System.Drawing.Point(124, 359);
            this.textBox_adresa.Name = "textBox_adresa";
            this.textBox_adresa.Size = new System.Drawing.Size(125, 27);
            this.textBox_adresa.TabIndex = 2;
            // 
            // textBox_grad
            // 
            this.textBox_grad.Location = new System.Drawing.Point(124, 433);
            this.textBox_grad.Name = "textBox_grad";
            this.textBox_grad.Size = new System.Drawing.Size(125, 27);
            this.textBox_grad.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prezime";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(124, 279);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Datum rodjenja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Adresa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Grad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 55);
            this.button1.TabIndex = 10;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(56, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(378, 46);
            this.label6.TabIndex = 11;
            this.label6.Text = "Registruj se kao korisnik";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(310, 581);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Uloguj se kao admin";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(477, 610);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_grad);
            this.Controls.Add(this.textBox_adresa);
            this.Controls.Add(this.textBox_prezime);
            this.Controls.Add(this.textBox_ime);
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMM yyyy";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _userRegistrationRepository.Registration(textBox_ime.Text, textBox_prezime.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), textBox_adresa.Text, textBox_grad.Text);
            string message = "Uspesno ste se registrovali!";
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

        private void label7_Click(object sender, EventArgs e)
        {
            AdminLogin adminlogin = new AdminLogin();
            this.Hide();
            adminlogin.Show();
        }
    }
}
