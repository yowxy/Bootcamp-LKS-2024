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
    public partial class LanjutanFlowLayout : Form
    {

        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int id;
        int user;
        public LanjutanFlowLayout(int id , int user)
        {
            InitializeComponent();
            this.id = id;
            this.user = user;
        }

        private void LanjutanFlowLayout_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var data = db.PollResponses.FirstOrDefault(f => f.UserID == user && f.PollID == id);
            if (data != null)
            {

                var polloptionlist = db.PollOptions.Where(poll=> poll.PollID == id).ToList();
                foreach (PollOption poll in polloptionlist)
                {

                    Button btn = new Button
                    {

                        Width=100,
                        Height = 100,
                        Text = poll.OptionText,

                    };

                    btn.Click += (o, p) =>
                    {
                        if (MessageBox.Show($"apakah anda yakin ingin pilih {poll.OptionText}", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            db.PollResponses.Add(new PollRespons
                            {

                                OptionID= poll.OptionID,
                                UserID=user,
                                PollID=id,
                                RespondedAt=DateTime.Now,       

                            });

                            db.SaveChanges();   
                            this.Close();       




                        }

                        else
                        {
                            return;

                        }
                    };
                    flowLayoutPanel1.Controls.Add(btn);     
                }
              

            }
            else
            {
                this.Close();
                MessageBox.Show("Anda sudah memilih,silahkan kembali");
                return;
            }
        }
    }
}
