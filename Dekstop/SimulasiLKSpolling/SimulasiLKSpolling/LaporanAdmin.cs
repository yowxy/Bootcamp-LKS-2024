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
    public partial class LaporanAdmin : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities();
        private int id;
        public LaporanAdmin()
        {
            InitializeComponent();
        }

        private void LaporanAdmin_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.Polls.ToList();  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem is Poll poll)
            {

                var data = poll.PollOptions.ToList().Select(o => new
                {

                    Label = o.OptionText,
                    Nilai = o.Poll.PollResponses.Count != 0
                    ?(double)o.PollResponses.Count/ o.Poll.PollResponses.Count : 0, 

                });

                chart1.Series[0].LabelFormat = "P0";
                chart1.Series[0].Points.DataBind(data, "Label", "Nilai", null);

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
