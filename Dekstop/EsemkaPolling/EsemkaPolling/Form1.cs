    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaPolling
{
    public partial class Form1 : Form
    {
        EsemkaPollingEntities poll = new EsemkaPollingEntities();
        int users;
   

        public Form1(int users)
        {
            InitializeComponent();
           this.users = users;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = poll.Users.First(f => f.UserID == users);
            // login link ke menu halaman masuk

            //HalamanMasuk masuk = new HalamanMasuk(users); 
            //masuk.ShowDialog();


            // sama aja
            HalamanMasuk ms = new HalamanMasuk(users);
            ms.ShowDialog();    



        }

        private void Form1_Load(object sender, EventArgs e)
        {
                    
            var data = poll.PollOptions.Select(pol => new
            {
                NamaPolling = pol.Poll.Question,
                NamaCalon = pol.OptionText,
                Suara = pol.PollResponses.Count,
                AllSuara = pol.Poll.PollResponses.Count,

            }).ToList();
            dataGridView1.DataSource = data;


        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > 0)
            {
                var previousRow = dataGridView1.Rows[e.RowIndex - 1];

                if (previousRow != null && previousRow.Cells[0] != null && previousRow.Cells[0].Value != null &&
                    previousRow.Cells[0].Value.Equals(e.Value))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridView1.RowCount - 1 && dataGridView1.Rows[e.RowIndex].DataBoundItem is PollOption po)
            {
                
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                
            }

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
