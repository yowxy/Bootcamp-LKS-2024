using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaPolling
{
    public partial class HalamanMasuk : Form
    {
        int user;
        public HalamanMasuk(int user)
        {
            InitializeComponent();
         
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistUsercs usr = new RegistUsercs(user);  
            usr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistAdmin admm = new RegistAdmin();
            admm.ShowDialog();   

        }

        private void HalamanMasuk_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
