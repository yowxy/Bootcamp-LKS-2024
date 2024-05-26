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
    public partial class PemungutanSuara_User_ : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities();
        int id;
  
        public PemungutanSuara_User_(int id)
        {
            this.id = id;
 
            InitializeComponent();
        }

        private void PemungutanSuara_User__Load(object sender, EventArgs e)
        {


            flowLayoutPanel1.Controls.Clear();
            var pollOptionsList = db.Polls.Where(poll => !poll.IsClosed ?? false).ToList();
            foreach (var poll in pollOptionsList)
            {
                Button btn = new Button
                {
                    Width = 100,
                    Height = 100,
                    Text = poll.Question,

                };

                btn.Click += (f, g) =>
                {
                    new ButtonUser(poll.PollID, id).ShowDialog();
                    // Menampilkan notifikasi saat tombol diklik
                    string message = $"Anda memilih opsi untuk pertanyaan: {poll.Question}";
                    MessageBox.Show(message, "Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                flowLayoutPanel1.Controls.Add(btn);
            }



            //var pol = db.Polls.ToList();
            //flowLayoutPanel1.Controls.Clear();  
            //foreach (var p in pol)
            //{
            //    Button btn = new Button();
            //    {

            //        btn.Text = p.Question;
            //        btn.Height = 100;
            //        btn.Width = 100;

            //    };
            //    btn.Click += (f, g) =>
            //    {
            //        if (MessageBox.Show($"Apakah anda yakin ingin pilih{} ", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //        {
            //            db.PollResponses.Add(new PollRespons
            //            {

            //                UserID = user,  
            //                PollID = id,
            //                RespondedAt = DateTime.Now,     



            //            });
            //        }


            //    };
            //    flowLayoutPanel1.Controls.Add(btn);         


            //}

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
