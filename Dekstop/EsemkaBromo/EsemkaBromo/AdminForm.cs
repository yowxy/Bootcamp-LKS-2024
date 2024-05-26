using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaBromo
{
    public partial class AdminForm : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities();
        int id;

        public AdminForm(int iD)
        {
            InitializeComponent();
            this.id = id;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
    

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("apakah anda yakin mau logout?","informasi",MessageBoxButtons.YesNo,MessageBoxIcon.Question); 
            if (dr == DialogResult.Yes)
            {
                new Form1().Show();
                Hide(); 
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new MasterBandara().Show();
            Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new MasterMaskapai().Show();    
            Hide();     
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new MasterJadwalPenerebaangan().Show();
            Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new MasterKodePromo().Show();   
            Hide();     
        }
    }
}
