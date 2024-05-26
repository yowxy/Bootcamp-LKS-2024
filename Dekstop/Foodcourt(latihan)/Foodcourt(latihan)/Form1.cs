using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodcourt_latihan_
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
                MessageBox.Show("pastikasn kolom terisi semua");
                return;
            }
            else
            {
                var connn = db.Users.Where(f => f.Email == emailTextBox.Text && f.Password == passwordTextBox.Text).FirstOrDefault();
                if(connn != null)
                {
                    if(connn.RoleID == 1)
                    {
                        MessageBox.Show("login sebgai admin");
                        new Form2(connn).Show();
                        Hide();
                    }
                    if(connn.RoleID == 2)
                    {
                        MessageBox.Show("login sebagai user");
                        new Form3().Show();
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show("gagal login");
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            emailTextBox.Text = "dgannyt@squidoo.com";
            passwordTextBox.Text = "dN1|qg!,xuZ";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form4().Show();
            Hide();
        }
    }
}
