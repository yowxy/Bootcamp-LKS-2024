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
    public partial class HalamanMasuk : Form
    {
        public HalamanMasuk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginUser usr = new LoginUser(1);    
            usr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginAdmin admin = new LoginAdmin();    
            admin.ShowDialog(); 
        }
    }
}
