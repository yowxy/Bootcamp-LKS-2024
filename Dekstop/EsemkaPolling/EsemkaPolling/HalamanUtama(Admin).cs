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
    public partial class HalamanUtama_Admin_ : Form
    {
        public HalamanUtama_Admin_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PemungutanSuara_Admin_ adm = new PemungutanSuara_Admin_(1);  
            adm.ShowDialog();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pengguna_Admin_cs adm = new Pengguna_Admin_cs();    
            adm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Laporan_Admin_cs adm = new Laporan_Admin_cs();
            adm.ShowDialog();   
        }

        private void HalamanUtama_Admin__Load(object sender, EventArgs e)
        {

        }
    }
}
