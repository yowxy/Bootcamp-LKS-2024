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

namespace EsemkaPolling
{
    public partial class RegistUsercs : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int user;
        public RegistUsercs(int user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void RegistUsercs_Load(object sender, EventArgs e)
        {
            textBox2.Text = "99185";
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g =  db.Users.First(f=> f.UserID == user || f.IdentityCode == textBox2.Text);
            if (g != null)
            {
                if (MessageBox.Show("apakah yakin anda ke form selanjut nya?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    HalamanUtama_User_cs userg = new HalamanUtama_User_cs(user); 
                    userg.ShowDialog();                      
                }
            }
        }
    }
}
