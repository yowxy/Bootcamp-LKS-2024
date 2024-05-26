using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaFoodcourt_Latihan
{
    public partial class Form1 : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            emailTextBox.Text = "dgannyt@squidoo.com";
            passwordTextBox.Text = "dN1|qg!,xuZ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(emailTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("kolom harus di isi!");
                return;
            }
            if (string.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("kolom email harus di isi!");
                return;
            }
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("kolom passowrd harus di isi");
                return;
            }


            var conn = db.Users.Where(f => f.Email == emailTextBox.Text || f.Password == passwordTextBox.Text).FirstOrDefault();
            if (conn != null)
            {

                if(conn.RoleID == 1)
                {

                    MessageBox.Show($"Login sukses{conn.FirstName +conn.LastName}");
                    new AdminForm(conn.ID).Show();
                    Hide(); 
                }
                if(conn.RoleID == 2)
                {
                    MessageBox.Show("selamat anda masuk ke menu member");
                    new FormMember(conn).Show();
                    Hide();
                }
               
            }
            else
            {
                MessageBox.Show("gagal login");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().Show();
            Hide();
        }
    }
}
