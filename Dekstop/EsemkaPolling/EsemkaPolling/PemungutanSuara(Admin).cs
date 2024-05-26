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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace EsemkaPolling
{
    public partial class PemungutanSuara_Admin_ : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities();
       
       
        public PemungutanSuara_Admin_(int id)
        {
            InitializeComponent();
        }

        private void PemungutanSuara_Admin__Load(object sender, EventArgs e)
        {

            pollBindingSource.DataSource = db.Polls.ToList();
            load();
        }

        void load()
        {

            bindingSource1.Clear();
            bindingSource2.Clear();
            pollOptionBindingSource.Clear();
            bindingSource1.AddNew();
            bindingSource2.AddNew();    
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
                MessageBox.Show("coba cek data dengan benar || isi semua data");
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is Poll pol)
            {
                if (Caleg.Index == e.ColumnIndex)
                {
                    e.Value = pol.PollOptions.Count;
                }
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0) MessageBox.Show("Mohon di isi terlebih dahulu data nya!");
           
            else if (pollBindingSource.Current is Poll polls)
            {
                db.Entry(polls).Collection(p => p.PollOptions).Load();
                foreach (var pollOption in polls.PollOptions.ToList())
                {
                    db.PollOptions.Remove(pollOption);
                }
                db.Polls.Remove(polls);
                db.SaveChanges();
                OnLoad(EventArgs.Empty);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows[0].DataBoundItem is Poll pol)
            {
                //pollBindingSource.DataSource = db.Polls.FirstOrDefault(g => g.PollID == pol.PollID);
                pollOptionBindingSource.DataSource = db.PollOptions.Where(x => x.PollID == pol.PollID).ToList();
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == butt.Index)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is PollOption po)
                {
                    pollOptionBindingSource.Remove(po);
                }
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
