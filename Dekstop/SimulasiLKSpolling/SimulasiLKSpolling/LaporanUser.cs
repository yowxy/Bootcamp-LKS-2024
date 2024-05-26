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
    public partial class LaporanUser : Form
    {

        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int user;

        public LaporanUser(int user)
        {
            InitializeComponent();
            this.user = user;  
        }

        private void LaporanUser_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.Polls.Where(x => x.PollResponses.Any(r => r.UserID == user)).ToList();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

            if (bindingSource1.Current is Poll po)
            {

                textBox2.Text = po.PollResponses.Count.ToString();  
                var data = po.PollOptions.Select(f=> new
                {

                       nama =$"{f.OptionText}{f.PollResponses.Count()}/{f.Poll.PollResponses.Count}",
                       f.PollResponses.Count,   

                }).ToList();

                textBox1.Text = po.PollOptions.First(f => f.PollResponses.Any(g => g.UserID == user)).OptionText;

                chart1.Series[0].Points.DataBind(data, "nama", "Count", null);





            }




        }
    }
}
