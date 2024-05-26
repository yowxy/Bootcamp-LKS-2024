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
    public partial class MenuUtamaAdmin : Form
    {
        public MenuUtamaAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Apakkah anda yakin ingin ke pemungutan suara?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                PemungutanSuaraAdmin adm = new PemungutanSuaraAdmin();  
                adm.ShowDialog();    
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("apakah anda yakin ke menu pengguna?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                PenggunaAdmin adm = new PenggunaAdmin();
                adm.ShowDialog();   
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("apakah anda yakin ingin ke menu laporan?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                LaporanAdmin adm = new LaporanAdmin();
                adm.ShowDialog();   
            }
        }
    }
}
