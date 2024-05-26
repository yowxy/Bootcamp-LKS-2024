using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaFoodcourtV1
{
    public partial class Form1 : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities(); 


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(emailTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty)
            {
                MessageBox.Show("kolom email dan password tidak boleh kosong!");
                return;
            }
            else
            {
                var conn = db.Users.Where(f => f.Email == emailTextBox.Text || f.Password == passwordTextBox.Text).FirstOrDefault();
                if(conn != null)
                {
                    if(conn.RoleID == 1)
                    {
                        MessageBox.Show($"Login berhasil , {conn.FirstName + conn.LastName}");
                        new AdminMainForm(conn).Show();
                        Hide();
                    }
                    else if(conn.RoleID == 2)
                    {
                        MessageBox.Show($"Login berhasil , {conn.FirstName + conn.LastName}");
                        new MemberMainForm(conn).Show();
                        Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("gagal login!");
                        return;
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().Show();
            Hide();
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            emailTextBox.Text = "dgannyt@squidoo.com";
            passwordTextBox.Text = "dN1|qg!,xuZ";
        }
    }
}
