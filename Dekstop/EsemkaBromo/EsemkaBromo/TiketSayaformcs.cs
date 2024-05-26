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
    public partial class TiketSayaformcs : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities();
        int id;



        public TiketSayaformcs()
        {
            InitializeComponent();
        }

        private void TiketSayaformcs_Load(object sender, EventArgs e)
        {
            jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.ToList();  
        }

        private void jadwalPenerbanganDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jb)
            {
                var negara = jb.Bandara ?? db.Bandara.Find(jb.BandaraTujuanID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn9.Index)
                {
                    e.Value = negara.Nama;
                }


            }
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jdwl)
            {
                var negara = jdwl.Maskapai ?? db.Maskapai.Find(jdwl.MaskapaiID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn13.Index)
                {
                    e.Value = negara.Nama;
                }


            }
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwal)
            {
                var negara = jadwal.Bandara ?? db.Bandara.Find(jadwal.BandaraTujuanID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = negara.Nama;
                }


            }
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jaw)
            {
                var negara = db.StatusPenerbangan.Where(f => f.PerubahanStatusJadwalPenerbangan == jaw);

                if (e.ColumnIndex == dataGridViewTextBoxColumn11.Index)
                {
                    e.Value = jaw.PerubahanStatusJadwalPenerbangan;
                }


            }








        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new CustomerMainFormcs().Show();
            Hide();
        }
    }
}
