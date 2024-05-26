using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoairlinessV1
{
    public partial class UbahStatusPenerbangan : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities(); 
        public UbahStatusPenerbangan()
        {
            InitializeComponent();
        }

        private void jadwalPenerbanganDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwal)
            {
                if (e.ColumnIndex == dataGridViewTextBoxColumn7.Index)
                {
                    TimeSpan time = TimeSpan.FromMinutes(jadwal.DurasiPenerbangan);
                    e.Value = $"{time.Hours:00} jam {time.Minutes:00} menit";
                }
                else if (e.ColumnIndex == dataGridViewTextBoxColumn9.Index)
                {
                    e.Value = jadwal.Bandara.Nama;
                }
                else if (e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = jadwal.Bandara1.Nama;
                }
                else if (e.ColumnIndex == dataGridViewTextBoxColumn13.Index)
                {
                    e.Value = jadwal.Maskapai.Nama;
                }
                else if (e.ColumnIndex == WaktuKberangkatn.Index)
                {
                    e.Value = jadwal.TanggalWaktuKeberangkatan.ToString("dd-MMM-yyyy");
                }
                else if (e.ColumnIndex == dataGridViewTextBoxColumn6.Index)
                {
                    e.Value = jadwal.TanggalWaktuKeberangkatan.ToString("dd-MM-yyy");
                }
                else if(e.ColumnIndex == Terakhirdiubah.Index)
                {


                    var terakhirdiubah = jadwal.PerubahanStatusJadwalPenerbangan.Max(q => (DateTime?)q.WaktuPerubahanTerjadi);
                    if (terakhirdiubah.HasValue)
                    {
                        e.Value = terakhirdiubah.Value.ToString("dd-MM-yyy   HH:MM:SS");
                    }
                    else
                    {
                        e.Value = "-";
                    }

                }


                else if(e.ColumnIndex == Statusterakhir.Index)
                {


                    var c = jadwal.PerubahanStatusJadwalPenerbangan;

                    if (c != null && c.Any())
                    {
                        var b = c.OrderByDescending(f => f.WaktuPerubahanTerjadi).First();
                        e.Value = b.StatusPenerbangan.Nama;
                    }
                    else
                    {
                        e.Value = "Sesuai Jadwal";
                    }
                }

            }
        }

        private void UbahStatusPenerbangan_Load(object sender, EventArgs e)
        {
            jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.AsNoTracking().ToList();
            bindingSource1.DataSource = db.StatusPenerbangan.AsNoTracking().ToList();
            namaComboBox.DataSource = bindingSource1;
            maskedTextBox1.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            namaComboBox.Visible = false;




        }

        private void jadwalPenerbanganDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwa)
            {
                if(e.ColumnIndex == Ubah.Index)
                {
                    maskedTextBox1.Visible = true;
                    label11.Visible = true;
                    label10.Visible = true;
                    namaComboBox.Visible = true;


                    var x = jadwa.PerubahanStatusJadwalPenerbangan;
                    if(x != null && x.Any())
                    {

                        var f = x.OrderByDescending(v => v.WaktuPerubahanTerjadi).First();
                        namaComboBox.SelectedValue = f.StatusPenerbangan.ID;
                        namaComboBox.Items.ToString();

                    }
                    else
                    {
                        namaComboBox.SelectedIndex = 0;
                    }


                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (jadwalPenerbanganDataGridView.CurrentRow?.DataBoundItem is JadwalPenerbangan jadwalll)
            {
                var perubahanstatus = new PerubahanStatusJadwalPenerbangan
                {
                    JadwalPenerbanganID = jadwalll.ID,  
                    StatusPenerbanganID =(int) namaComboBox.SelectedValue,
                    WaktuPerubahanTerjadi = DateTime.Now,
                    PerkiraanDurasiDelay = null

                };

                db.PerubahanStatusJadwalPenerbangan.Add(perubahanstatus);
                db.SaveChanges();
                OnLoad(EventArgs.Empty);    
            }
        }
    }
}
