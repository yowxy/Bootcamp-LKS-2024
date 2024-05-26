using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoairlinessV1
{
    public partial class ListPenerbangan : Form
    {

        string BandaraAsal;
        string BandaraTj;
        string kodeIATAasal;
        string kodeTj;

        DateTime tanggalKeberangkatan;
        int id;
        int jumlahpenumpang;

        BromoAirlinesEntities db = new BromoAirlinesEntities();

        public ListPenerbangan(string BandaraASal, string kodeIATAasal, string bandaratj, string kodeIATA2, DateTime tanggalKeberangkatan, int jumlahpenumpang, int id)
        {

            InitializeComponent();
            this.BandaraAsal = BandaraASal;
            this.BandaraTj = bandaratj;
            this.tanggalKeberangkatan = tanggalKeberangkatan.Date;
            this.jumlahpenumpang = jumlahpenumpang;
            this.kodeIATAasal = kodeIATAasal;

            this.kodeTj = kodeIATA2;
            this.id = id;


            label2.Text = $"{BandaraASal} ,{kodeIATAasal}";
            label3.Text = $"{bandaratj} , {kodeIATA2}";
            label4.Text = tanggalKeberangkatan.ToString("ddd, dd MMM yyyy");
            label5.Text = jumlahpenumpang + "penumpang";
        }

        private void ListPenerbangan_Load(object sender, EventArgs e)
        {
            jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan
                .Where(f=> f.Bandara.Nama == BandaraAsal && f.Bandara1.Nama == BandaraTj
                 && DbFunctions.TruncateTime(f.TanggalWaktuKeberangkatan) == tanggalKeberangkatan.Date)
                        .OrderByDescending(f => f.TanggalWaktuKeberangkatan)
                          .ToList();

        }

        private void jadwalPenerbanganDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwal)
            {
                if(e.ColumnIndex == dataGridViewTextBoxColumn13.Index)
                {
                    e.Value = jadwal.Maskapai.Nama;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn9.Index)
                {
                    e.Value = jadwal.Bandara.Nama;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = jadwal.Bandara1.Nama;
                }
                else if (e.ColumnIndex == dataGridViewTextBoxColumn6.Index)
                {
                    e.Value = jadwal.TanggalWaktuKeberangkatan.ToString("ddd-MMM-yyyy");
                }
                else if(e.ColumnIndex == Waktupenerbangan.Index)
                {
                    DateTime waktuKeberangkatan = jadwal.TanggalWaktuKeberangkatan;
                    // Ambil nilai Durasi Penerbangan dari DataGridView
                    int durasiPenerbangan = Convert.ToInt32(e.Value);
                    // Ambil durasi delay dari entitas JadwalPenerbangan
                    int durasiDelay = jadwal.DurasiPenerbangan;
                    // Hitung total durasi penerbangan termasuk delay
                    int totalDurasi = durasiPenerbangan + durasiDelay;
                    // Hitung waktu kedatangan
                    DateTime waktuKedatangan = waktuKeberangkatan.AddMinutes(totalDurasi);
                    // Format string untuk waktu keberangkatan dan kedatangan
                    e.Value = $"{waktuKeberangkatan.ToString("HH:mm")} - {waktuKedatangan.ToString("HH:mm")}";
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DateTime startdatetime = tanggalKeberangkatan.Date.AddHours(0);
                DateTime endDatetime = tanggalKeberangkatan.Date.AddHours(6);

                jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan
                   .Where(f => f.Bandara.Nama == BandaraAsal
                           && f.Bandara1.Nama == BandaraTj
                           && DbFunctions.TruncateTime(f.TanggalWaktuKeberangkatan) == startdatetime
                           && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) >= startdatetime.TimeOfDay
                           && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) <= endDatetime.TimeOfDay)
                   .OrderByDescending(f => f.TanggalWaktuKeberangkatan)
                   .ToList();
            }
            else if (checkBox2.Checked)
            {
                DateTime s = tanggalKeberangkatan.Date.AddHours(6);
                DateTime end = tanggalKeberangkatan.Date.AddHours(12);

                jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.Where(f => f.Bandara.Nama == BandaraAsal && f.Bandara1.Nama == BandaraTj
                && DbFunctions.TruncateTime(f.TanggalWaktuKeberangkatan) == tanggalKeberangkatan.Date
                && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) >= s.TimeOfDay
                && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) <= end.TimeOfDay).OrderByDescending(f => f.TanggalWaktuKeberangkatan).ToList();
            }
            else if (checkBox3.Checked)
            {
                DateTime s = tanggalKeberangkatan.Date.AddHours(12);
                DateTime end = tanggalKeberangkatan.Date.AddHours(18);

                jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.Where(f => f.Bandara.Nama == BandaraAsal && f.Bandara1.Nama == BandaraTj
                && DbFunctions.TruncateTime(f.TanggalWaktuKeberangkatan) == tanggalKeberangkatan.Date
                && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) >= s.TimeOfDay
                && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) <= end.TimeOfDay).OrderByDescending(f => f.TanggalWaktuKeberangkatan).ToList();
            }
            else if (checkBox4.Checked)
            {
                DateTime s = tanggalKeberangkatan.Date.AddHours(18);
                DateTime end = tanggalKeberangkatan.Date.AddHours(24);

                jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.Where(f => f.Bandara.Nama == BandaraAsal && f.Bandara1.Nama == BandaraTj
                && DbFunctions.TruncateTime(f.TanggalWaktuKeberangkatan) == tanggalKeberangkatan.Date
                && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) >= s.TimeOfDay
                && DbFunctions.CreateTime(f.TanggalWaktuKeberangkatan.Hour, f.TanggalWaktuKeberangkatan.Minute, f.TanggalWaktuKeberangkatan.Second) <= end.TimeOfDay).OrderByDescending(f => f.TanggalWaktuKeberangkatan).ToList();
            }
            else if (comboBox1.SelectedItem != null)
            {
                string cb = comboBox1.SelectedItem.ToString();


                var query = db.JadwalPenerbangan.Where(f => f.Bandara.Nama == BandaraAsal && f.Bandara1.Nama == BandaraTj && DbFunctions.TruncateTime(f.TanggalWaktuKeberangkatan) == tanggalKeberangkatan.Date).OrderByDescending(f => f.TanggalWaktuKeberangkatan);
                switch (cb)
                {
                    case "Harga Terendah":
                        query = query.OrderBy(f => f.HargaPerTiket);
                        break;
                    case "Keberangkatan Paling Awal":
                        query = query.OrderBy(f => f.TanggalWaktuKeberangkatan);
                        break;
                    case "Keberangkatan Paling Akhir":
                        query = query.OrderByDescending(f => f.TanggalWaktuKeberangkatan);
                        break;
                    case "Kedatangan Paling Awal":
                        query = query.OrderBy(f => DbFunctions.AddMinutes(f.TanggalWaktuKeberangkatan, f.DurasiPenerbangan));
                        break;
                    case "Kedatangan Paling Akhir":
                        query = query.OrderByDescending(f => DbFunctions.AddMinutes(f.TanggalWaktuKeberangkatan, f.DurasiPenerbangan));
                        break;
                    case "Durasi Tercepat":
                        query = query.OrderBy(f => f.DurasiPenerbangan);
                        break;
                }
                jadwalPenerbanganBindingSource.DataSource = query.ToList();
            }
            else
            {
                jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.Where(f => f.Bandara.Nama == BandaraAsal && f.Bandara1.Nama == BandaraTj
                && DbFunctions.TruncateTime(f.TanggalWaktuKeberangkatan) == tanggalKeberangkatan.Date).OrderByDescending(f => f.TanggalWaktuKeberangkatan).ToList();
            }
        }

        private void jadwalPenerbanganDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadwal)
            {
                if(e.ColumnIndex == BeliTicket.Index)
                {
                    double hargaPertiket = jadwal.HargaPerTiket;
                    string maskapai = jadwal.Maskapai.Nama;
                    int durasiPenerbangan = Convert.ToInt32(jadwalPenerbanganDataGridView.Rows[e.RowIndex].Cells[Waktupenerbangan.Index].Value);
                    int jadwalid = Convert.ToInt32(jadwalPenerbanganDataGridView.Rows[e.RowIndex].Cells[dataGridViewTextBoxColumn1.Index].Value);

                    int durasiDelay = jadwal.DurasiPenerbangan;
                    int totalDurasi = durasiPenerbangan + durasiDelay;
                    DateTime waktuKeberangkatan = jadwal.TanggalWaktuKeberangkatan;

                    DateTime waktuKedatangan = waktuKeberangkatan.AddMinutes(totalDurasi);
                    string waktuPenerbangan = $"{waktuKeberangkatan.ToString("HH:mm")} - {waktuKedatangan.ToString("HH:mm")}";
                   // openForm(new BeliTiket(jumlahpenumpang, BandaraASal, bandaratj, kodeIATAasal, kodeIATA2, TanggalKeberangkatan, hargaPertiket, maskapai, waktuPenerbangan, id, jadwalid));
                }
            }
        }
    }
}
