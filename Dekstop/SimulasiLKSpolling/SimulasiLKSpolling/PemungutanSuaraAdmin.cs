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

namespace SimulasiLKSpolling
{
    public partial class PemungutanSuaraAdmin : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities(); 
        public PemungutanSuaraAdmin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void load()
        {

            bindingSource1.Clear();
            bindingSource2.Clear();
            pollOptionBindingSource.Clear();
            bindingSource1.AddNew();
            bindingSource2.AddNew();    

        }

        private void PemungutanSuaraAdmin_Load(object sender, EventArgs e)
        {
            pollBindingSource.DataSource = db.Polls.ToList();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (bindingSource1.Current is Poll pemilu)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("pemilu harap di isi");
                    return;
                }
                if (bindingSource2.Current is PollOption caleg)
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("caleg harap di isi");
                        return;
                    }

                    pollOptionBindingSource.Add(new PollOption
                    {
                        OptionText = caleg.OptionText,
                        PollID = pemilu.PollID,
                    });

                    bindingSource2.Clear();
                    bindingSource2.AddNew();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingSource2.Count == 0) throw new Exception();
                if (bindingSource1.Current is Poll pemilu)
                {


                    var user = db.Admins.FirstOrDefault();
                    pemilu.AdminID = user.AdminID;  
                    pemilu.PollOptions = pollOptionBindingSource.List as ICollection<PollOption>;
                    pemilu.IsClosed = false;
                    pemilu.CreatedAt = DateTime.Now;
                    db.Polls.AddOrUpdate(pemilu);
                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);

                }



            }
            catch (Exception ex) 
            {

                MessageBox.Show("coba cek ulang username dan password anda! || isi semua data ");


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 0) MessageBox.Show("Mohon di isi terlebih dahulu!");

            else if (pollBindingSource.Current is Poll pemilu)
            {

               db.Entry(pemilu).Collection (x=> x.PollOptions).Load ();
                foreach (var polloption in pemilu.PollOptions.ToList())
                {

                    db.Polls.Remove(pemilu);
                }

                db.Polls.Remove(pemilu);
                db.SaveChanges();
                OnLoad(EventArgs.Empty);

            }





        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows[0].DataBoundItem is Poll po)
            {
                pollOptionBindingSource.DataSource = db.PollOptions.Where(w => w.PollID == po.PollID).ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Delete.Index)
            {

                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Poll po)
                {

                    pollOptionBindingSource.Remove(po);



                }


            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is Poll po)
            {
                if (Column1.Index == e.ColumnIndex)
                {
                    e.Value = po.PollOptions.Count; 

                }



            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
