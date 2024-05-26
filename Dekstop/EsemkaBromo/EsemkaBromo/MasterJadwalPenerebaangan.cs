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
    public partial class MasterJadwalPenerebaangan : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities(); 

        public MasterJadwalPenerebaangan()
        {
            InitializeComponent();
        }

        private void MasterJadwalPenerebaangan_Load(object sender, EventArgs e)
        {
            jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.ToList();
            bindingSource1.AddNew();
           
            Tujuan.DataSource = db.Bandara.ToList();    
            Keberangkatan.DataSource = db.Bandara.ToList();
            Maskapai.DataSource = db.Maskapai.ToList();
        }

        private void jadwalPenerbanganDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jb)
            {
                var negara = jb.Bandara ?? db.Bandara.Find(jb.BandaraTujuanID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = negara.Nama;
                }


            }
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwal)
            {
                var negara = jadwal.Maskapai ?? db.Maskapai.Find(jadwal.MaskapaiID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn9.Index)
                {
                    e.Value = negara.Nama;
                }


            }
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jdwl)
            {
                var negara = jdwl.Bandara1 ?? db.Bandara.Find(jdwl.BandaraKeberangkatanID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn13.Index)
                {
                    e.Value = negara.Nama;
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if(bindingSource1.Current is JadwalPenerbangan jadwal)
            {
                db.JadwalPenerbangan.Add(jadwal);
                db.SaveChanges();
                OnLoad(EventArgs.Empty);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new MasterKodePromo().Show();
            Hide();
        }

        private void bandaraKeberangkatanIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
