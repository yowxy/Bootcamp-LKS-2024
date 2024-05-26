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
    public partial class ListPenerbangan : Form
    {
        BromoAirlinesEntities db = new BromoAirlinesEntities();
         private bool filter = false;
        int id;


        public ListPenerbangan()
        {
            InitializeComponent();
        }

        private void ListPenerbangan_Load(object sender, EventArgs e)
        {
            jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.ToList();
        }

        private void jadwalPenerbanganDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwal)
            {
                var data = jadwal.Maskapai ?? db.Maskapai.Find(jadwal.MaskapaiID);
                if (e.ColumnIndex == dataGridViewTextBoxColumn13.Index)
                {
                    e.Value = data.Nama;
                }
            }


            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan ja)
            {
                var d = ja.Bandara ?? db.Bandara.Find(ja.BandaraKeberangkatanID);
                if(e.ColumnIndex == dataGridViewTextBoxColumn9.Index)
                {
                    e.Value = d.Nama;
                }
            }

            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jdwl)
            {
                var a = jdwl.Bandara1 ?? db.Bandara.Find(jdwl.BandaraTujuanID);
                if(e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = a.Nama;
                } 
            }




        }

        private void jadwalPenerbanganDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // link ke  form beli tiket 

            if(e.ColumnIndex == jadwalPenerbanganDataGridView.Columns["tiket"].Index && e.RowIndex >= 0)
            {
                string rowData = jadwalPenerbanganDataGridView.Rows[e.RowIndex].Cells["tiket"].Value.ToString();

                // Open the new form (SecondForm in this example)
                new BeliTicketFormcs().Show();
                Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                var test = db.JadwalPenerbangan.FirstOrDefault();
                var tanggal = $"{Runtime.tglkeberangkatan.Date} 00:00";
                var tanggal2 = $"{Runtime.tglkeberangkatan.Date} 00:00";
                var convert = DateTime.Parse(tanggal);

                // Add 60 minutes to the convert DateTime
                var convert2 = convert.AddMinutes(60);

                jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan
                    .Where(f => f.TanggalWaktuKeberangkatan >= convert && f.TanggalWaktuKeberangkatan <= convert2)
                    .ToList();

            }

        }
    }
}
