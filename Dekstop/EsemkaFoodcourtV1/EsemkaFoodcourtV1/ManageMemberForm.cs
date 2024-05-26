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

namespace EsemkaFoodcourtV1
{
    public partial class ManageMemberForm : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        bool isinsert = true;

        public ManageMemberForm()
        {
            InitializeComponent();
        }

        private void ManageMemberForm_Load(object sender, EventArgs e)
        {
            usersBindingSource.DataSource = db.Users.ToList();
            bindingSource1.AddNew();
            enabled();
        }


        void enabled()
        {
            firstNameTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            phoneNumberTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            
            button4.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            button4.Enabled = true;
            button5.Enabled = true;

            firstNameTextBox.Enabled = true;
            lastNameTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            phoneNumberTextBox.Enabled = true;
            passwordTextBox.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if(bindingSource1.Current is Users user)
            {
                if (firstNameTextBox.Text == string.Empty || lastNameTextBox.Text == string.Empty || emailTextBox.Text == string.Empty || phoneNumberTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty)
                {
                    MessageBox.Show("kolom tidak boleh kosong!");
                    return;
                }
                else
                {
                    if (!password(passwordTextBox.Text))
                    {
                        MessageBox.Show("password minimal 8 karakter!");
                        return;
                    }
                    if (phoneNumber(phoneNumberTextBox.Text))
                    {
                        MessageBox.Show("password minimal 10 karakter dan maksimal 15 karakter !");
                        return;
                    }

                    if (!email(emailTextBox.Text))
                    {
                        MessageBox.Show("email harus sesuai!");
                        return;
                    }

                    if (isinsert)
                    {
                        db.Users.Add(user);
                        user.RoleID = 2;
                        user.DateJoined = DateTime.Now;
                        OnLoad(EventArgs.Empty);
                        MessageBox.Show("Data berhasil di tambahkan!");
                        return;
                    }
                    else
                    {
                        db.Users.AddOrUpdate(user);
                        MessageBox.Show("data berhasil di update!");
                        isinsert = false;
                    }

                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);


                }
            }

            
        }

        private bool password (string password)
        {
            return password.Length > 8;
        }

        private bool phoneNumber (string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length >=10 && phoneNumber.Length <=15;
        }

        private bool email ( string email)
        {
            var db = new System.Net.Mail.MailAddress(email);
            return db.Address == email;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Current is Users user)
            {


                var conn = db.Users.Where(f=> f.ID == user.ID).FirstOrDefault();
                if(conn != null)
                {

                    string nama = conn.FirstName + conn.LastName;
                    DialogResult dr = MessageBox.Show("apakah anda yakin untuk menghapus ini?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dr == DialogResult.Yes)
                    {
                        MessageBox.Show("data berhasil di hapus!");
                        db.Users.Remove(conn);
                        db.SaveChanges();
                        OnLoad(EventArgs.Empty);
                    }

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usersBindingSource.Current is Users user)
            {
                var conn = db.Users.Where(d => d.ID == user.ID).FirstOrDefault();
                if (conn != null)
                {

                    string nama = conn.FirstName + conn.LastName;
                    DialogResult dr = MessageBox.Show("apakah anda ingin merubah ini?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == dr)
                    {
                        bindingSource1.Clear();
                        bindingSource1.DataSource = conn;

                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = true;
                        button5.Enabled = true;

                        firstNameTextBox.Enabled = true;
                        emailTextBox.Enabled = true;
                        lastNameTextBox.Enabled = true;
                        passwordTextBox.Enabled = true;
                        phoneNumberTextBox.Enabled = true;

                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text.ToLower();
            var cari = db.Users.Where(f => f.FirstName.ToLower().Contains(search) || f.LastName.ToLower().Contains(search) || f.Email.ToLower().Contains(search) );
        }

        private void usersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //relasi datejoined atau membersince
            if (usersDataGridView.Rows[e.RowIndex].DataBoundItem is Users user)
            {
                if(e.ColumnIndex == dataGridViewTextBoxColumn7.Index)
                {
                    DateTime membersince = (DateTime)user.DateJoined;

                    int age = DateTime.Now.Year - membersince.Year;

                    e.Value = $"{membersince:dd/MMM/yyyy}  {{  {age} years  }}   ";
                }
            }
        }
    }
}
