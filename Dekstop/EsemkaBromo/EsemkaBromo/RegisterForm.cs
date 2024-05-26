using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaBromo
{
    public partial class RegisterForm : Form
    {
        BromoAirlinesEntities db = new BromoAirlinesEntities();
        int id;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            akunBindingSource.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((usernameTextBox.Text == string.Empty) || (namaTextBox.Text == string.Empty) || (nomorTeleponTextBox.Text == string.Empty) ||  (passwordTextBox.Text == string.Empty ))
            {

                MessageBox.Show("Kolom harus di isi terlebih dahulu");
                return;
            }
            else
            {
                if (!password(passwordTextBox.Text))
                {
                    MessageBox.Show("password minimal 8 digiit", "informasi");
                    return;
                }
                if (!phone(nomorTeleponTextBox.Text))
                {
                    MessageBox.Show("nomor telepon 10 digit - 15 digit ");
                    return;
                }

                if (usernameTextBox.Text != usernameTextBox.Text)
                {
                    MessageBox.Show("email dan password anda harus unik", "informasi");
                    return;
                }
            }


            if(akunBindingSource.Current is Akun akun)
            {
                db.Akun.AddOrUpdate(akun);
                db.SaveChanges();
                MessageBox.Show("regist berhasiil ");
                new CustomerMainFormcs().Show();
                Hide();
            }
        
    
         
        }




        private bool password(string password)
        {
            return password.Length >= 8;
        }
        private bool phone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 10 && phone.Length <= 15;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form1().Show();
            Hide();
        }
    }
}
