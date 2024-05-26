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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BromoairlinessV1
{
    public partial class MasterBandara : Form
    {


        BromoAirlinesEntities db = new BromoAirlinesEntities();
        bool simpan = true;

        public MasterBandara()
        {
            InitializeComponent();
        }

        private void MasterBandara_Load(object sender, EventArgs e)
        {
            bandaraBindingSource.DataSource = db.Bandara.ToList();
            bindingSource2.DataSource = db.Negara.ToList();
            bindingSource1.AddNew();
           // bindingSource1.Clear();
      
        }

        private void bandaraDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (bandaraDataGridView.Rows[e.RowIndex].DataBoundItem is Bandara bandara)
            {
                if (e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = bandara.Negara.Nama;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int jumlah = kodeIATATextBox.Text.Length;
            int currntid = (bindingSource1.Current as Bandara)?.ID ?? 0;


            if (namaTextBox.Text == string.Empty || kodeIATATextBox.Text == string.Empty || kotaTextBox.Text == string.Empty || negaraComboBox.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
                return;
            }
            else if (!unik(namaTextBox.Text, currntid))
            {
                MessageBox.Show("nama bandara sudah dipilh atau sudah ada!");
                return; 
            }
            else if (!iata(kodeIATATextBox.Text ,currntid) || jumlah >3) 
            {
                MessageBox.Show("kode diatas sudah digukana silahkan pilih kode yang lain!");
                return;
            }
            else if(jumlah > 3)
            {
                MessageBox.Show("kode iata minimal 3 gigit");
                return;
            }


            else
            {


                if(bindingSource1.Current is Bandara bandara)
                {
                    if (simpan)
                    {
                        db.Bandara.Add(bandara);
                        MessageBox.Show("data berhasil di tambahkan");

                    }
                    else
                    {
                        MessageBox.Show("data berhasil di update!");
                        db.Bandara.AddOrUpdate(bandara);
                    }

                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);
                }

            }
         
        }

        private bool unik(string nama, int id)
        {
            if (id == 0)
            {
                return !db.Bandara.Any(f => f.Nama == nama);
            }
            else
            {
                return!db.Bandara.Any(x=> x.Nama == nama && x.ID ==  id);   
            }
        }

        private bool iata (string kodeiata ,int id)
        {
            if(id == 0)
            {
                return !db.Bandara.Any(c => c.KodeIATA == kodeiata);
            }
            else
            {
                return!db.Bandara.Any(e=> e.KodeIATA ==kodeiata && e.ID == id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            bindingSource1.AddNew();
            simpan = true;
        }
        void clear()
        {
            namaTextBox.Text = kodeIATATextBox.Text = kotaTextBox.Text = negaraComboBox.Text = alamatTextBox.Text = string.Empty;
            jumlahTerminalNumericUpDown.Value = 1;
        }

        private void bandaraDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bandaraDataGridView.Rows[e.RowIndex].DataBoundItem is Bandara bandar)
            {
                if(e.ColumnIndex == ubah.Index)
                {
                    bindingSource1.DataSource = db.Bandara.AsNoTracking().First(f=> f.ID ==  bandar.ID);
                    simpan = false;
                }

                else if(e.ColumnIndex == Hapus.Index)
                {


                    var del = db.Bandara.Where(g=> g.ID ==  bandar.ID).FirstOrDefault(); 
                    if(del != null)
                    {
                        DialogResult dr = MessageBox.Show("apakah anda yakin untuk menghapus ini!", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(DialogResult.Yes == dr)
                        {
                            db.Bandara.Remove(del);
                            MessageBox.Show("dta berhasil di hapus!");
                            db.SaveChanges();
                            OnLoad(EventArgs.Empty);
                        }
                    }


                }
            }
        }

        private void kodeIATATextBox_TextChanged(object sender, EventArgs e)
        {
            kodeIATATextBox.Text = new string(kodeIATATextBox.Text.Where(char.IsLetter).ToArray()).ToUpper();


            kodeIATATextBox.SelectionStart = kodeIATATextBox.Text.Length;
            kodeIATATextBox.MaxLength = 3;
        }
    }
}
