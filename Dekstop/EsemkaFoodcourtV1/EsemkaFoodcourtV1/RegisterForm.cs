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

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstNameTextBox.Text == string.Empty || lastNameTextBox.Text == string.Empty || emailTextBox.Text == string.Empty || phoneNumberTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty|| Confirmpw.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
                return;
            }
            else
            {
                if (!password(passwordTextBox.Text))
                {
                    MessageBox.Show("paswword minimal 8 karakter!");
                    return; 
                }
                if (!phoneNumber(phoneNumberTextBox.Text))
                {
                    MessageBox.Show("password minimal 10 karakter dan maksimal 15 karakter");
                    return;
                }
                if (!email(emailTextBox.Text))
                {
                    MessageBox.Show("pastikan email unik dan valid");
                    return;
                }


                Users user = new Users()
                {
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,
                    Email = emailTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text,
                    Password = passwordTextBox.Text,
                    RoleID =2,
                    DateJoined = DateTime.Now,
                };

                db.SaveChanges();
                db.Users.Add(user);
                MessageBox.Show($"Register berhasil, {user.FirstName + user.LastName} ");
                OnLoad(EventArgs.Empty);
                new MemberMainForm(user).Show();
                Hide();


            }
        }


        private bool password (string password)
        {
            return password.Length > 8;
        }

        private bool phoneNumber (string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) &&phoneNumber.Length >=10 && phoneNumber.Length<=15;
        }

        private bool email (string email)
        {
            var db = new System.Net.Mail.MailAddress(email);
            return db.Address == email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Hide();
        }

        private void Confirmpw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
