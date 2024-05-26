using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BromoairlinessV1
{
    public partial class DaftarAkunForm : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities(); 

        public DaftarAkunForm()
        {
            InitializeComponent();
        }

        private void DaftarAkunForm_Load(object sender, EventArgs e)
        {
            akunBindingSource.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty || namaTextBox.Text == string.Empty || nomorTeleponTextBox.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
                return;
            }
            else if (!username(usernameTextBox.Text))
            {
                MessageBox.Show("username harus unik dan tidak boleh sama!");
                return;
            }
            else
            {

                int jumlah = nomorTeleponTextBox.Text.Length;
                if (!phone(nomorTeleponTextBox.Text) || jumlah < 10 || jumlah > 15)
                {
                    MessageBox.Show("nomor telepon yang di inputkan minimal 10 digit dan maksimal 15 digit ", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (!password(passwordTextBox.Text))
                {
                    MessageBox.Show("kolom password harus kurang dari 8 karakter!");
                    return;
                }
             


                else
                {

                    Akun acc = new Akun()
                    {
                        
                        Username = usernameTextBox.Text,
                        Password = passwordTextBox.Text,
                        Nama = namaTextBox.Text,
                        NomorTelepon = nomorTeleponTextBox.Text,
                        TanggalLahir = tanggalLahirDateTimePicker.Value,

                    };

                    db.Akun.Add(acc);
                    db.SaveChanges();
                    MessageBox.Show($"Register berhasil ,{acc.Username}");
                    new CustomerMainForm(acc.ID).Show();
                    Hide();




                }


            }
        }

        private bool password ( string password )
        {
            return password.Length < 8;
        }
        private bool username (string username)
        {
            return !db.Akun.Any(a => a.Username == username);
        }
        private bool phone ( string phone)
        {
            return int.TryParse(phone, out int _);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form1().Show();
            Hide();
        }
    }
}
