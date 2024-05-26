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
    public partial class PemungutanSuaraUsercs : Form
    {

        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int id;

        public PemungutanSuaraUsercs(int id)
        {
            InitializeComponent();
            this.id = id;   
        }

        private void PemungutanSuaraUsercs_Load(object sender, EventArgs e)
        {


            flowLayoutPanel1.Controls.Clear(); ;
            var polloptiion = db.Polls.Where(op=> !op.IsClosed ?? false).ToList();  
            foreach (var op in polloptiion)
            {

                Button btn = new Button
                {

                    Width = 100,
                    Height = 100,   
                    Text = op.Question,
                };

                btn.Click += (f, g) =>
                {

                    new LanjutanFlowLayout(op.PollID, id).ShowDialog();
                    string messaga = $"Anda memilih opsi untuk pertanyaan:{op.Question}";
                    MessageBox.Show(messaga, "notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Information);



                };

                flowLayoutPanel1.Controls.Add(btn); 

                
            }







        }
    }
}
