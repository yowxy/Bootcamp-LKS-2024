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
    public partial class ButtonUser : Form
    {

        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int id;
        int user;
        public ButtonUser(int id, int user)
        {
            InitializeComponent();
            this.id = id;
            this.user = user;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ButtonUser_Load(object sender, EventArgs e)
        {
                    

            flowLayoutPanel1.Controls.Clear();
            var data = db.PollResponses.FirstOrDefault(f => f.UserID == user && f.PollID == id);
            if (data == null)
            {
                var pollOptionsList = db.PollOptions.Where(poll => poll.PollID == id).ToList();
                foreach (PollOption poll in pollOptionsList)
                {
                    Button btn = new Button
                    {
                        Width = 100,
                        Height = 100,
                        Text = poll.OptionText,

                    };

                    btn.Click += (f, g) =>
                    {
                        if (MessageBox.Show($"apakah anda yakin ingin pilih {poll.OptionText}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.PollResponses.Add(new PollRespons
                            {
                                OptionID = poll.OptionID,
                                UserID = user,
                                PollID = id,
                                RespondedAt = DateTime.Now
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
                MessageBox.Show("Anda Sudah Memilih, Silahkan Kembali");
                return;
            }



        }
    }
}
