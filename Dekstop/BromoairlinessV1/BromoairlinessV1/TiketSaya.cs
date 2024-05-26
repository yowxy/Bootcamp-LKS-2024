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
    public partial class TiketSaya : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities(); 

        public TiketSaya()
        {
            InitializeComponent();
        }

        private void transaksiHeaderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (transaksiHeaderDataGridView.Rows[e.RowIndex].DataBoundItem is TransaksiHeader hau)
            {
                if (e.ColumnIndex == Kodepenerbangan.Index)
                {
                    e.Value = hau.JadwalPenerbangan.KodePenerbangan;
                }
                else if (e.ColumnIndex == Maskapai.Index)
                {
                    e.Value = hau.JadwalPenerbangan.Maskapai.Nama;
                }
                else if (e.ColumnIndex == Bndarakeberangkatab.Index)
                {
                    e.Value = hau.JadwalPenerbangan.Bandara.Nama;
                }
                else if (e.ColumnIndex == Bndaratujuan.Index)
                {
                    e.Value = hau.JadwalPenerbangan.Bandara1.Nama;
                }
                else if (e.ColumnIndex == TanggalKberangjatanb.Index)
                {
                    e.Value = hau.JadwalPenerbangan.TanggalWaktuKeberangkatan.ToString("dd-MMM-yyyy");
                }
                else if(e.ColumnIndex == Waktukeberangkatan.Index)
                {
                    int durasi = Convert.ToInt32(e.Value);

                    DateTime waktuKeberangkatan = hau.JadwalPenerbangan.TanggalWaktuKeberangkatan;

                    int durasidelay = hau.JadwalPenerbangan.DurasiPenerbangan;

                    int total = durasi + durasidelay;


                    DateTime waktukedatangan = waktuKeberangkatan.AddMinutes(total);
                    e.Value = $"{waktuKeberangkatan.ToString("HH:mm")} - {waktukedatangan.ToString("HH:mm")}";
                }
                else if(e.ColumnIndex == StatusTerakhir.Index)
                {
                    var orderedStatusChanges = hau.JadwalPenerbangan.PerubahanStatusJadwalPenerbangan
                 .OrderBy(sp => sp.WaktuPerubahanTerjadi) // Order status changes by time in ascending order
                 .ToList();

                    if (orderedStatusChanges.Any())
                    {
                        var latestStatusChange = orderedStatusChanges.Last(); // Get the latest status change

                        string status = latestStatusChange.StatusPenerbangan.Nama; // Assuming the status is a string property
                        if (status == "Delay")
                        {
                            int? perkiraanDurasiDelay = latestStatusChange.PerkiraanDurasiDelay;

                            if (perkiraanDurasiDelay.HasValue)
                            {
                                TimeSpan delayDuration = TimeSpan.FromMinutes(perkiraanDurasiDelay.Value);
                                e.Value = $"Delay (selama ±{delayDuration.TotalHours} jam {delayDuration.Minutes} menit)";
                            }
                            else
                            {
                                e.Value = "Delay (durasi tidak diketahui)";
                            }
                        }

                        else
                        {
                            e.Value = status;
                        }
                    }
                    else
                    {
                        e.Value = "Sesuai Jadwal";
                    }
                }
            }
        }

        private void TiketSaya_Load(object sender, EventArgs e)
        {

        }
    }
}
