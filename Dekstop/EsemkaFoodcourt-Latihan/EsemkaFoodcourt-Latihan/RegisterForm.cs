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
    public partial class RegisterForm : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private bool password (string password)
        {
           return password.Length > 8;
        }

        private bool phone (string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 8 && phone.Length <=10;
        }

        private bool email (string email)
        {
            try
            {
                var db = new System.Net.Mail.MailAddress(email);
                return db.Address == email;
            }
            catch
            {
                return false;   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(tb_firstname.Text == string.Empty || tb_lastname.Text == string.Empty || tb__email.Text == string.Empty || tb_phone.Text == string.Empty || tb_password.Text == string.Empty || tb_confirm.Text == string.Empty)
            {
                MessageBox.Show("kolom harus di isi!");
                return;
            }
            else
            {
                if (!email(tb__email.Text))
                {
                    MessageBox.Show("kolom email harus di isi");
                    return;
                }
                if (!phone(tb_phone.Text))
                {
                    MessageBox.Show("kolom nomor telepon minimal 8 digit!");
                    return;
                }
                if (!password(tb_password.Text))
                {
                    MessageBox.Show("password yang di isi minimal 8 karakter dan maksimal 10 karakter!");
                    return;
                }
                if (tb_confirm.Text != tb_password.Text)
                {
                    MessageBox.Show("pastikan password sesuai");
                    return;
                }




                Users user = new Users()
                {

                    FirstName = tb_firstname.Text,
                    LastName = tb_lastname.Text,
                    Email = tb__email.Text,
                    PhoneNumber = tb_phone.Text,
                    Password = tb_password.Text,
                    RoleID = 2,
                    DateJoined = DateTime.Now,
                };

                db.Users.Add(user); 
                db.SaveChanges();
                OnLoad(EventArgs.Empty);
                MessageBox.Show($"Register berhasil , {tb_firstname.Text}");
                new FormMember(user).Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Hide();
        }
    }
}
