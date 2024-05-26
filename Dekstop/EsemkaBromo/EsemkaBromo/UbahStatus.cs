using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaBromo
{
    public partial class UbahStatus : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities(); 



        public UbahStatus()
        {
            InitializeComponent();
        }

        private void UbahStatus_Load(object sender, EventArgs e)
        {
            jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.ToList();
            bindingSource1.AddNew();
        }

        private void jadwalPenerbanganDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jb)
            {
                var negara = jb.Bandara ?? db.Bandara.Find(jb.BandaraTujuanID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn11.Index)
                {
                    e.Value = negara.Nama;
                }


            }
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwal)
            {
                var negara = jadwal.Maskapai ?? db.Maskapai.Find(jadwal.MaskapaiID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn15.Index)
                {
                    e.Value = negara.Nama;
                }


            }
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jdwl)
            {
                var negara = jdwl.Bandara1 ?? db.Bandara.Find(jdwl.BandaraKeberangkatanID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn12.Index)
                {
                    e.Value = negara.Nama;
                }


            }

            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is PerubahanStatusJadwalPenerbangan perubahan)
            {


                var gege = perubahan.JadwalPenerbangan ?? db.JadwalPenerbangan.Find(perubahan.StatusPenerbanganID);

                if(e.ColumnIndex == Statusterakhir.Index)
                {
                    e.Value = gege;

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Current is  JadwalPenerbangan jadwal)
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
    }
}
