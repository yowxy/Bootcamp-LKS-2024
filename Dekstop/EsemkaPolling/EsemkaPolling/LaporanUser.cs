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
            bindingSource1.DataSource = db.Polls.Where(f => f.PollResponses.Any(g => g.UserID == user)).ToList();

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if(bindingSource1.Current is Poll poll)
            {
                textBox2.Text = poll.PollResponses.Count.ToString();
                var data = poll.PollOptions.Select(f => new
                {
                    Nama = $"{f.OptionText} {f.PollResponses.Count()} / {f.Poll.PollResponses.Count}",
                    f.PollResponses.Count
                }).ToList();

                textBox1.Text = poll.PollOptions.First(f=> f.PollResponses.Any(g=> g.UserID == user)).OptionText;
                chart1.Series[0].Points.DataBind(data, "Nama", "Count", null);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
