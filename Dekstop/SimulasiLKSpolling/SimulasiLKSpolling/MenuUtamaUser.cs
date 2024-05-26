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
    public partial class MenuUtamaUser : Form
    {
        public MenuUtamaUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PemungutanSuaraUsercs usr = new PemungutanSuaraUsercs(1);    
            usr.ShowDialog();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LaporanUser la = new LaporanUser(1);
            la.ShowDialog();    
        }
    }
}
