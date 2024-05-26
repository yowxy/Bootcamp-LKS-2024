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

namespace EsemkaFoodcourt_Latihan
{
    public partial class ManageMemberFormcs : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        bool isInsert = true;

        public ManageMemberFormcs()
        {
            InitializeComponent();
        }

        private void ManageMemberFormcs_Load(object sender, EventArgs e)
        {
            enabled();
            bindingSource1.Clear();
            bindingSource1.AddNew();
            usersBindingSource.DataSource = db.Users.Where(f=> f.RoleID == 2).ToList();
        }



        private bool email (string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool phone (string phonenu)
        {
            return phonenu.All(char.IsDigit) && phonenu.Length >=8 && phonenu.Length<=10 ;
        }

        private bool passwordIsvalid (string password)
        {
            return password.Length > 8;
        }


        void enabled ()
        {
            button1 .Enabled = true;
            button2 .Enabled = true;
            button3 .Enabled = true;  
            button4 .Enabled = false;
            button5.Enabled = false;
            firstNameTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;    
            passwordTextBox.Enabled = false;
            phoneNumberTextBox.Enabled = false; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string cari = textBox1.Text.ToLower();


            var carii = db.Users.Where(p => p.FirstName.ToLower().Contains(cari) || p.LastName.ToLower().Contains(cari) || p.Email.ToLower().Contains(cari)).ToList();
            usersBindingSource.DataSource = carii;
        }

        private void usersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (usersDataGridView.Rows[e.RowIndex].DataBoundItem is Users usr)
            {

                if (e.ColumnIndex == MembeSince.Index)
                {

                    DateTime memberSinceDate = (DateTime)usr.DateJoined;


                    int age = DateTime.Now.Year - memberSinceDate.Year;


                    e.Value = $"{memberSinceDate:dd/MM/yyyy} {{ {age} years }}";

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false; button3.Enabled = false;
            firstNameTextBox.Enabled = true;
            lastNameTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            passwordTextBox.Enabled = true;
            phoneNumberTextBox.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Current is Users user)
            {

                if(firstNameTextBox.Text == string.Empty || lastNameTextBox.Text == string.Empty || emailTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty || phoneNumberTextBox.Text == string.Empty)
                {
                    MessageBox.Show("data harus di isi!");
                    return;
                }
                else
                {

                    if (!email(user.Email))
                    {
                        MessageBox.Show(" Email should be unique and in a correct format ");
                        return;
                    }
                    if (!passwordIsvalid(user.Password))
                    {
                        MessageBox.Show("Password length must be at least 8 characters", "informasi");
                        return;
                    }
                    if (!phone(user.PhoneNumber))
                    {
                        MessageBox.Show("Phone number should be a digit (between 10-15 digits).");
                    }

                    if(db.Users.Any(x=> x.Email == user.Email))
                    {
                        MessageBox.Show("Email Sudah Digunakan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (isInsert)
                    {
                        user.RoleID = 2;
                        user.DateJoined = DateTime.Now;
                        db.Users.Add(user);
                        MessageBox.Show("Data Berhasil Disimpan");
                    }
                    else
                    {
                        db.Users.AddOrUpdate(user);
                        MessageBox.Show("data berhasil diubah");
                        isInsert = false;
                    }

                    db.SaveChanges();
                    enabled();
                    OnLoad(EventArgs.Empty);

                }
               


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            button2.Enabled = true;
            button2.Enabled = false;
            enabled();
            reset();
            bindingSource1.AddNew();
        }

        void reset()
        {
            firstNameTextBox.Text = lastNameTextBox.Text = emailTextBox.Text = phoneNumberTextBox.Text = passwordTextBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (usersBindingSource.Current is Users user)
            {

                var conn = db.Users.Where(x => x.ID == user.ID).FirstOrDefault();
                if (conn != null)
                {
                    string nama = conn.FirstName + conn.LastName;
                    DialogResult dr = MessageBox.Show($"Yakin Akan Menghapus Data Ini {nama} ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        db.Users.Remove(conn);
                        db.SaveChanges();
                        MessageBox.Show("Data Berhasil Dihapus");
                        OnLoad(EventArgs.Empty);

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(usersBindingSource.Current is Users user)
            {

                var ubah = db.Users.Where(f => f.ID == user.ID).FirstOrDefault();

                if (ubah != null)
                {
                    string nama = ubah.FirstName + ubah.LastName;
                    DialogResult dr = MessageBox.Show($"Yakin Akan Mengubah Data Ini  {nama}?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        button1.Enabled = false;
                        button3.Enabled = false;
                        firstNameTextBox.Enabled = true;
                        lastNameTextBox.Enabled = true;
                        emailTextBox.Enabled = true;
                        passwordTextBox.Enabled = true;
                        phoneNumberTextBox.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        isInsert = false;
                        bindingSource1.Clear();
                        bindingSource1.DataSource = ubah;
                    }
                }
            }
        }
    }
}
