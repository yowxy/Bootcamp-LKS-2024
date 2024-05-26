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
    public partial class MasterKodepromo : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities();
        bool simpan = true;

        public MasterKodepromo()
        {
            InitializeComponent();
        }

        private void MasterKodepromo_Load(object sender, EventArgs e)
        {
            kodePromoBindingSource.DataSource = db.KodePromo.ToList();
            bindingSource1.AddNew();
            berlakuSampaiDateTimePicker.CustomFormat = "dd-MMM-yyyy";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentid = (kodePromoBindingSource.Current as KodePromo)?.ID ?? 0;

            if((kodeTextBox.Text == string.Empty) || (deskripsiTextBox.Text == string.Empty))
            {
                MessageBox.Show("kolom tidak boleh kosong!");
                return;
            }
            else if (!unik(kodeTextBox.Text, currentid))
            {
                MessageBox.Show("kode tersebut sudah terdaftar , silahkan pilih kode yang lain","informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
               
            }
            else
            {
                if(bindingSource1.Current is KodePromo kode)
                {
                    if (simpan)
                    {
                        db.KodePromo.Add(kode);
                        MessageBox.Show("data berhasil di tambahkan!");
                    }
                    else
                    {
                        db.KodePromo.AddOrUpdate(kode);
                        MessageBox.Show("data berhasil di update!");
                    }

                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);
                }
            }
        }

        private void kodeTextBox_TextChanged(object sender, EventArgs e)
        {
            kodeTextBox.Text = kodeTextBox.Text.ToUpper();  
            kodeTextBox.SelectionStart = kodeTextBox.Text.Length;   
        }

        private bool unik(string kode, int id)
        {
            if (id == 0)
            {
                return !db.KodePromo.Any(f => f.Kode == kode);

            }
            else
            {
                return !db.KodePromo.Any(f => f.Kode == kode && f.ID != id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            bindingSource1.AddNew();
            simpan = true;
        }
    }
}
