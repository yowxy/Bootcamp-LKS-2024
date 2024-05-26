using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace EsemkaPolling
{
    public partial class RegistAdmin : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities(); 
        public RegistAdmin()
        {
            InitializeComponent();
        }

        private void RegistAdmin_Load(object sender, EventArgs e)
        {
            textBox1.Text = "admin1";
            textBox2.Text = "admin1";


    
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
            string username = textBox1.Text;
            string password = textBox2.Text;

            string hashedPassword = GetHash(password);

            var admin = db.Admins.FirstOrDefault(a=> a.UserName == username);

            if (admin != null && admin.Password == hashedPassword)
            {
                new HalamanUtama_Admin_().Show();
            }
            else MessageBox.Show("Login gagal,Username atau password salah");


        }
        
        static string GetHash (string a)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(a)).Select(f => f.ToString("x2")));
        }
    }
}
