using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulasiLKSpolling
{
    public partial class Form1 : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int users;
        public Form1(int users)
        {
            InitializeComponent();
            this.users = users; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              

            var data = db.PollOptions.Select(po=> new
            {

                NamaPolling = po.Poll.Question,
                NamaCalon = po.OptionText,
                suara = po.PollResponses.Count,
                AllSuara = po.Poll.PollResponses.Count, 
            }).ToList();    

            dataGridView1.DataSource = data;    
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var useer = db.Users.First(x => x.UserID == users);

            HalamanMasuk msk = new HalamanMasuk();
            msk.ShowDialog();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.ColumnIndex == 0 && e.RowIndex > 0 &&
            e.RowIndex - 1 < dataGridView1.Rows.Count &&
              dataGridView1.Rows[e.RowIndex - 1].Cells.Count > 0 &&
                 dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value != null &&
                 dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value.Equals(e.Value))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
