using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulasiLKSpolling
{
    public partial class LoginAdmin : Form
    {

        EsemkaPollingEntities db = new EsemkaPollingEntities();     
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            string hashead = gethash(password);
            var admin = db.Admins.FirstOrDefault(a => a.UserName == username);
            if (admin != null && admin.Password == hashead)
            {
                new MenuUtamaAdmin().Show();
            }
            else MessageBox.Show("Login gagal,username atau password salah ");

        }

        static string gethash (string a)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(a)).Select(f => f.ToString("x2")));
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {
            textBox1.Text = "admin1";
            textBox2.Text = "admin1"; 
        }
    }
}
