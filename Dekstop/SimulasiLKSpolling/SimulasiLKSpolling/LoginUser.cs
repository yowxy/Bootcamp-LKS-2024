using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulasiLKSpolling
{
    public partial class LoginUser : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int user;
        public LoginUser(int user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            var g =  db.Users.First(f=> f.UserID == user || f.IdentityCode == textBox1.Text);
            if (g != null)
            {

                if (MessageBox.Show("apakah yakin anda ke form selanjut nya?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    MenuUtamaUser usr = new MenuUtamaUser();    
                    usr.Show(); 

                }




            }




        }

        private void LoginUser_Load(object sender, EventArgs e)
        {
            textBox1.Text = "99185";
        }
    }
}
