using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoairlinessV1
{

    public partial class BeliTicket : Form
    {


        private int jumlahPenumpang;
        private string BandaraASal;
        private string bandaratj;
        private string kodeIATAasal;
        private string kodeIATA2;
        int id;
        int jadwalid;
        private DateTime tanggalKeberangkatan;
        private double hargaPertiket;
        private string maskapai;
        private string waktuPenerbangan;

        BromoAirlinesEntities db = new BromoAirlinesEntities(); 
        public BeliTicket(int jumlahPenumpang, string BandaraASal, string bandaratj, string kodeIATAasal, string kodeIATA2, DateTime tanggalKeberangkatan, double hargaPertiket, string maskapai, string waktuPenerbangan, int id, int jadwalid)
        {
            InitializeComponent();
            this.jumlahPenumpang = jumlahPenumpang;
            this.id = id;
            this.jadwalid = jadwalid;
            this.BandaraASal = BandaraASal;
            this.bandaratj = bandaratj;
            this.kodeIATA2 = kodeIATA2;
            this.kodeIATAasal = kodeIATAasal;
            this.tanggalKeberangkatan = tanggalKeberangkatan;
            this.hargaPertiket = hargaPertiket; // Inisialisasi hargaPertiket
            this.maskapai = maskapai; // Inisialisasi maskapai
            this.waktuPenerbangan = waktuPenerbangan; // 

            label4.Text = $"{BandaraASal}  ({kodeIATAasal})";
            label5.Text = $"{bandaratj}  ({kodeIATA2})";
            label6.Text = maskapai;
            label9.Text = waktuPenerbangan;
            label8.Text = tanggalKeberangkatan.ToString("ddd, dd MMM yyyy");

            label10.Text = jumlahPenumpang + " Penumpang";
            double total = hargaPertiket * jumlahPenumpang;


            string formattedTotal = total.ToString("C0", new CultureInfo("id-ID"));


            label13.Text = formattedTotal;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        void usercntrl()
        {
            flowLayoutPanel1.Controls.Clear();
            for(int i =0; i<jumlahPenumpang; i++)
            {
                DetailPenumpang penumpangControl = new DetailPenumpang(i + 1);
                flowLayoutPanel1.Controls.Add(penumpangControl);
            }
        }

        private void BeliTicket_Load(object sender, EventArgs e)
        {
            usercntrl();
        }

        bool adakodepromo(string text)
        {
            return db.KodePromo.Any(f=> f.Kode == text);
        }

        bool ispromocodevalid(KodePromo promo)
        {
            return promo.BerlakuSampai >= DateTime.Now;
        }

        private void btnPakaiKodePromo_Click(object sender, EventArgs e)
        {
            if (adakodepromo(textBox1.Text))
            {
                var kpm = db.KodePromo.SingleOrDefault(x=> x.Kode == textBox1.Text);
                if(kpm != null)
                {
                    if (ispromocodevalid(kpm))
                    {
                        double persentasediskon = kpm.PersentaseDiskon;
                        double maksimumdiskon = kpm.MaksimumDiskon;

                        double total = hargaPertiket * jumlahPenumpang;
                        double diskon = Math.Min(total * persentasediskon / 100, maksimumdiskon);
                        double set = total - diskon;

                        string format = set.ToString("C0", new CultureInfo("id-ID"));
                        label13.Text = format;
                    }
                    else
                    {
                        MessageBox.Show("kode promo sudah berlaku!");
                    }
                }
                else
                {
                    MessageBox.Show("kode promo tidak valid!");
                }
            }
        }

        private void btnKonfirmasiPembayaran_Click(object sender, EventArgs e)
        {
            int? kodepromoid = null;
            bool kodepromodipakai = !string.IsNullOrWhiteSpace(textBox1.Text);


            if (kodepromodipakai)
            {
                var kodepromo = db.KodePromo.SingleOrDefault(f => f.Kode == textBox1.Text);
                if(kodepromo !=null)
                {
                    kodepromoid = kodepromo.ID;
                }
            }

            TransaksiHeader transaksi = new TransaksiHeader()
            {


                AkunID = id,
                TanggalTransaksi = DateTime.Now,
                JadwalPenerbanganID = jadwalid,
                JumlahPenumpang = jumlahPenumpang,


                KodePromoID = kodepromoid,
            };


            if (double.TryParse(label13.Text.Replace("IDR", "").Trim(), NumberStyles.Currency, new CultureInfo("id-ID"), out double totalHarga))
            {
                transaksi.TotalHarga = totalHarga;
            }

            db.TransaksiHeader.Add(transaksi);
            db.SaveChanges();

            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control is DetailPenumpang penumpang)
                {
                    TransaksiDetail bb = new TransaksiDetail
                    {
                        TransaksiHeaderID = transaksi.ID,
                        TitelPenumpang = penumpang.titel(),
                        NamaLengkapPenumpang = penumpang.nama()
                    };
                    db.TransaksiDetail.Add(bb);
                };
            }
            db.SaveChanges();
            this.Close();

            CustomerMainForm cs = new CustomerMainForm(id);
            cs.Show();

        }   
    }
}
