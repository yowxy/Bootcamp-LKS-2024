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
    public partial class Form4 : Form
    {
       EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstNameTextBox.Text == string.Empty || lastNameTextBox.Text  == string.Empty || emailTextBox.Text == string.Empty || phoneNumberTextBox.Text == string.Empty || passwordTextBox.Text ==string.Empty)
            {
                MessageBox.Show("pastikan kolom terisi");
                return;
            }
            else
            {
                if (!password(passwordTextBox.Text))
                {
                    MessageBox.Show("Password length must be at least 8 characters.");
                    return;
                }
                if (!phone(phoneNumberTextBox.Text))
                {
                    MessageBox.Show("Phone number should be a digit (between 10-15 digits)");
                    return;
                }
                if (!email(emailTextBox.Text))
                {
                    MessageBox.Show("The email should be unique and in a correct format (valid)");
                    return;
                }


                Users user = new Users()
                {
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,
                    Email = emailTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text,
                    Password = passwordTextBox.Text,
                    DateJoined = DateTime.Now,
                    RoleID = 2,

                   
                };

                db.SaveChanges();
                db.Users.Add(user);
                OnLoad(EventArgs.Empty);
                MessageBox.Show("login berhasil");
                new Form3().Show();
                Hide();
            }
        }
        private bool password (string password)
        {
            return password.Length > 8;
        }
        private bool phone (string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >=10 && phone.Length <=15;
        }
        private bool email (string email)
        {
            try
            {
                var conn = new System.Net.Mail.MailAddress(email);
                return conn.Address == (email);
            }
            catch
            {
                return false;
            }
    
        }
    }
}
