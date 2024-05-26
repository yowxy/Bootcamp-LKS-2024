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

    
    public partial class Laporan_Admin_cs : Form
    {
        EsemkaPollingEntities    db = new EsemkaPollingEntities();      
        private int id = -1; 

        public Laporan_Admin_cs()
        {
            InitializeComponent();
        }

        private void Laporan_Admin_cs_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.Polls.ToList();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                

            if (comboBox1.SelectedItem is Poll po)
            {
                var data = po.PollOptions.ToList().Select(x => new
                {
                    Label = x.OptionText,
                    Nilai = x.Poll.PollResponses.Count != 0
                    ? (double)x.PollResponses.Count / x.Poll.PollResponses.Count  : 0,


                });
                chart1.Series[0].LabelFormat = "P0";
                chart1.Series[0].Points.DataBind(data, "Label", "Nilai", null);

            }


        }
    }
}
