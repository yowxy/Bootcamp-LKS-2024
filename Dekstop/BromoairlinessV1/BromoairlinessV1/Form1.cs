using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoairlinessV1
{
    public partial class Form1 : Form
    {


       BromoAirlinesEntities db = new BromoAirlinesEntities();  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usernameTextBox.Text = "admin";
            passwordTextBox.Text = "admin123";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty)
            {
                MessageBox.Show("kolom username dan password tidak boleh kosong!");
                return;
            }
            else
            {
                if(string.IsNullOrEmpty(usernameTextBox.Text))
                {
                    MessageBox.Show("kolom username tidak boleh kosong!");
                    return;
                }


                var conn = db.Akun.Where(f => f.Username == usernameTextBox.Text || f.Password == passwordTextBox.Text).FirstOrDefault();
                if(conn != null)
                {

                    if(conn.MerupakanAdmin == true)
                    {
                        MessageBox.Show($"Login berhasil ,{conn.Username}");
                        new AdminMainForm().Show();
                        Hide();

                    }
                    if(conn.MerupakanAdmin == false)
                    {
                        MessageBox.Show($"Login berhasil ,{conn.Username}");
                        new CustomerMainForm(conn.ID).Show();
                        Hide();
                    }
                }

                else
                {
                    MessageBox.Show("login gagal!");
                    return; 
                }


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DaftarAkunForm().Show();
        }
    }
}
