using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaBromo
{
    public partial class Form1 : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities();
        int id;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usernameTextBox.Text = "admin";
            passwordTextBox.Text = "admin123";
            akunBindingSource.DataSource = db.Akun.ToList();
      
      
       
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(usernameTextBox.Text))
            {
                MessageBox.Show("Kolom nama harus di isi");
                return;
            }

            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("kolom password harus di isi");
                return;
            }

            var users = db.Akun.Where(f => f.Username == usernameTextBox.Text && f.Password == passwordTextBox.Text).FirstOrDefault();

            if (users != null)
            {
                if (users.MerupakanAdmin == true)
                {
                    MessageBox.Show($"Login success, welcome back {users.Username + users.Password}");
                    AdminForm admin = new AdminForm(users.ID);
                    admin.Show();
                    this.Hide();
                }
                else if(users.MerupakanAdmin == false) // Note: Remove the unnecessary check for users == null here
                {
                    MessageBox.Show($"Login success, welcome back {users.Username + users.Password}");
                    new CustomerMainFormcs().Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Gagal login!");
                return;
            }










            //    if (akunBindingSource.Current is Akun akn )
            //    {
            //        var data = db.Akun.Where(f=> f.Nama == akn.Nama && f.Password == akn.Password);

            //        if (akn.Username == null && akn.Password == null)
            //        {
            //            MessageBox.Show("data tidak boleh kosng!");
            //            return;
            //        }

            //        if(data != null)
            //        {
            //            id = akn.ID;
            //            MessageBox.Show("login sukses", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            new AdminForm(1).Show();
            //            this.Hide();   

            //        }
            //        else if (data != null)
            //        {

            //        }
            //        else MessageBox.Show("gagal login");





            //}



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().Show();
            Hide();
        }
    }
}
