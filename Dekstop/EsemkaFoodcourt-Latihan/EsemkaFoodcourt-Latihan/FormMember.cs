using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaFoodcourt_Latihan
{
    public partial class FormMember : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        private readonly Users users;

        public FormMember(Users user)
        {
            InitializeComponent();
            label1.Text = $"{user.FirstName},{user.LastName}";
            this.users = user;
        }

        

        private void FormMember_Load(object sender, EventArgs e)
        {
            timer1.Start();
            usrcntrl();
        }
        void openForm<T>(T form) where T : Form
        {
            form.Show();
            form.FormClosed += FormClosed;
            Hide();
        }

        void FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = " current time : " + DateTime.Now.ToString("HH-MMM-ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openForm(new ReservationTableHistory());
        }
        void usrcntrl()
        {
            flowLayoutPanel1.Controls.Clear();
            var list = new List<Reservations>();

            for (int i = 0; i < 12; i++)
            {
                list.Add(null);
            }

            db.Reservations.Where(x => x.ReservationDate == DateTime.Today).ToList().ForEach(x => {
                list[x.TableID - 1] = x;
            });

            var l = 0;
            foreach (var item in list)
            {
                flowLayoutPanel1.Controls.Add(new tbl_layout(l + 1, item));
                l++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("apakah anda yakin keluar ?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                new Form1().Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openForm(new ReservationTablecs(users));
        }
    }
}
