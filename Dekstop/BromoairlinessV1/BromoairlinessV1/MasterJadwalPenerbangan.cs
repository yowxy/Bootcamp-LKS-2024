using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoairlinessV1
{
    public partial class MasterJadwalPenerbangan : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities();
        bool simpan = true;

        public MasterJadwalPenerbangan()
        {
            InitializeComponent();
        }

        private void MasterJadwalPenerbangan_Load(object sender, EventArgs e)
        {
            jadwalPenerbanganBindingSource.DataSource = db.JadwalPenerbangan.ToList();
            Keberangkatan.DataSource = db.Bandara.ToList();
            Tujuan.DataSource = db .Bandara.ToList();
            Maskapai.DataSource = db.Maskapai.ToList();
            bindingSource1.AddNew();
        }

        private void jadwalPenerbanganDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jadweal)
            {
                if(e.ColumnIndex == dataGridViewTextBoxColumn9.Index)
                {
                    e.Value = jadweal.Bandara.Nama;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = jadweal.Bandara1.Nama;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn13.Index)
                {
                    e.Value = jadweal.Maskapai.Nama;
                }
                else if(e.ColumnIndex == waktukebernagkatan.Index)
                {
                    e.Value = jadweal.TanggalWaktuKeberangkatan.ToString("HH-MM");
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn6.Index)
                {
                    e.Value = jadweal.TanggalWaktuKeberangkatan.ToString("dd-MM-yyyy");
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn7.Index)
                {
                    int durasipenerbagan = Convert.ToInt32(e.Value);

                    int jam = durasipenerbagan / 60;
                    int menit = durasipenerbagan % 60;

                    e.Value = $"{jam:D2} jam {menit:D2}";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kodePenerbanganMaskedTextBox.Text == string.Empty || bandaraKeberangkatanIDComboBox.Text == string.Empty || bandaraTujuanIDComboBox.Text == string.Empty || maskapaiComboBox.Text == string.Empty || durasiPenerbanganMaskedTextBox.Text == string.Empty || maskedTextBox1.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
                return;
            }
            else if (bandaraKeberangkatanIDComboBox.Text == bandaraTujuanIDComboBox.Text)
            {
                MessageBox.Show("bandara keberangkatan dan tujuan tidak boleh sama!");
                return;
            }
            else
            {
                if(bindingSource1.Current is JadwalPenerbangan jadwal)
                {
                    if(!DateTime.TryParse(maskedTextBox1.Text,out DateTime waktukebrangkatan))
                    {
                        MessageBox.Show("Format waktu keberangkatan tidak valid. Masukkan waktu dalam format 24 jam (00:00 - 23:59).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    string duration = durasiPenerbanganMaskedTextBox.Text;

                    jadwal.TanggalWaktuKeberangkatan = waktukebrangkatan;
                    jadwal.DurasiPenerbangan = ParseDuration(duration); 


                    if (simpan)
                    {
                        db.JadwalPenerbangan.Add(jadwal);
                        MessageBox.Show("databerhasil ditambahkan!");

                    }
                    else
                    {
                        db.JadwalPenerbangan.AddOrUpdate(jadwal);
                    }

                    try
                    {
                        db.SaveChanges();
                        OnLoad(EventArgs.Empty);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Error during SaveChanges: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private int ParseDuration(string durationString)
        {
            // memisahkan string berdasarkan jam dan menit
            string[] parts = durationString.Split(new string[] { "jam", "menit" }, StringSplitOptions.RemoveEmptyEntries);
            //parsing jam dan menit dari array hasil pemmisahan
            int hours = int.Parse(parts[0].Trim());
            int minutes = int.Parse(parts[1].Trim());
            //mengembalikan total menit
            return hours * 60 + minutes;
        }

        private void kodePenerbanganMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            kodePenerbanganMaskedTextBox.Text = kodePenerbanganMaskedTextBox.Text.ToUpper();
            kodePenerbanganMaskedTextBox.SelectionStart = kodePenerbanganMaskedTextBox.Text.Length;
        }

        private void jadwalPenerbanganDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jadwalPenerbanganDataGridView.Rows[e.RowIndex].DataBoundItem is JadwalPenerbangan jdwl)
            {
                if(e.ColumnIndex == Batal.Index)
                {
                    bindingSource1.DataSource = db.JadwalPenerbangan.AsNoTracking().First(f => f.ID == jdwl.ID);
                    simpan = false;
                }
                else if(e.ColumnIndex == Hapus.Index)
                {

                    var del = db.JadwalPenerbangan.Where(f=> f.ID == jdwl.ID).FirstOrDefault();
                    if(del != null)
                    {
                        DialogResult dr = MessageBox.Show("apakah anda yakin ingin menghapus ini?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            db.JadwalPenerbangan.Remove(del);
                            db.SaveChanges();
                            OnLoad(EventArgs.Empty);
                            MessageBox.Show("data berhasil dihapus","infoprasi",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }


                }
            }
        }
    }
}
