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
    public partial class CustomerMainFormcs : Form
    {


        BromoAirlinesEntities db = new BromoAirlinesEntities();

        public CustomerMainFormcs()
        {
            InitializeComponent();
        }

        private void CustomerMainFormcs_Load(object sender, EventArgs e)
        {
            Berangkat.DataSource = db.Bandara.ToList();
            Tujuan.DataSource = db.Bandara.ToList();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            new TiketSayaformcs().Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Runtime.tglkeberangkatan = dateTimePicker1.Value;
            new ListPenerbangan ().Show();
            Hide();
        }
    }
}
