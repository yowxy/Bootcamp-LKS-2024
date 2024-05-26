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
    public partial class MasterBandara : Form
    {
        BromoAirlinesEntities db = new BromoAirlinesEntities();
        int id;


        public MasterBandara()
        {
            InitializeComponent();
        }

        private void MasterBandara_Load(object sender, EventArgs e)
        {
            
            bindingSource1.DataSource = db.Negara.ToList();         
            bandaraBindingSource.DataSource = db.Bandara.ToList();
            textbandara.AddNew();
            
           // bandaraBindingSource.AddNew();
            //textbandara.DataSource= db.Negara.ToList(); 
        }

        private void bandaraDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


              //relasi kolom negara
            if (bandaraDataGridView.Rows[e.RowIndex].DataBoundItem is Bandara bandara)
            {
                var negara = bandara.Negara ?? db.Negara.Find(bandara.NegaraID);

                if (e.ColumnIndex == dataGridViewTextBoxColumn10.Index)
                {
                    e.Value = negara.Nama;
                }

        
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

          

        


            if(textbandara.Current is Bandara bandara)
            {
                db.Bandara.Add(bandara);
                db.SaveChanges();
                OnLoad(EventArgs.Empty);
            }
        }

        private void negaraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new MasterMaskapai().Show();
            Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new MasterJadwalPenerebaangan().Show();
            Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
          
        }
    }
}
