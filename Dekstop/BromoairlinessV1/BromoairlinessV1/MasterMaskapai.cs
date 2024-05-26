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
    public partial class MasterMaskapai : Form
    {


        BromoAirlinesEntities db = new BromoAirlinesEntities();
        bool simpan = true;

        public MasterMaskapai()
        {
            InitializeComponent();
        }

        private void MasterMaskapai_Load(object sender, EventArgs e)
        {
            maskapaiBindingSource.DataSource = db.Maskapai.OrderBy(d => d.Nama).ToList();
            bindingSource1.AddNew();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            if(namaTextBox.Text == string.Empty || perusahaanTextBox.Text == string.Empty || deskripsiTextBox.Text == string.Empty)
            {
                MessageBox.Show("Kolom harus di isi!");
                return;
            }
            else
            {
                if(bindingSource1.Current is Maskapai maskpai)
                {
                    if (simpan)
                    {
                        MessageBox.Show("data berhasil di simpan");
                        db.Maskapai.Add(maskpai);

                    }
                    else
                    {
                        db.Maskapai.AddOrUpdate(maskpai);
                        MessageBox.Show("data berhasil di update");
                    }

                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);
                }

                else
                {
                    MessageBox.Show("gagal menambahkan data!");
                    return;
                }
            }
        }

        private void jumlahKruNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void jumlahKruNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
        }

        private void maskapaiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (maskapaiDataGridView.Rows[e.RowIndex].DataBoundItem is Maskapai maskapau)
            {
                if(e.ColumnIndex == Ubah.Index)
                {
                    bindingSource1.DataSource = db.Maskapai.AsNoTracking().First(f=> f.ID == maskapau.ID);
                    simpan = false;
                }
                else if(e.ColumnIndex == Hapus.Index)
                {
                    var del = db.Maskapai.Where(f=> f.ID == maskapau.ID).FirstOrDefault();
                    if(del != null)
                    {
                        DialogResult dr = MessageBox.Show("apakah anda yakin ingin menghapus ini?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(DialogResult.Yes == dr)
                        {
                            db.Maskapai.Remove(del);
                            db.SaveChanges();
                            OnLoad(EventArgs.Empty);
                            MessageBox.Show("dtaa berhasil di hapus!");
                        }
                    }
                }
            }
        }
    }
}
