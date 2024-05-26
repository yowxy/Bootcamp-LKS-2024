using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BromoairlinessV1
{
    public partial class CustomerMainForm : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities();
        int id;

        public CustomerMainForm(int id)
        {
            InitializeComponent();
            this.id = id;
            var namaakun = db.Akun.FirstOrDefault(f => f.ID == id);
            label2.Text = $"Mau terbang kemana hari ini , {namaakun.Nama} ?";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void CustomerMainForm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.Bandara.ToList();
            bindingSource2.DataSource = db.Bandara.ToList();    
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var conn = db.Akun.FirstOrDefault(f => f.ID == id);
            DialogResult dr = MessageBox.Show($"apakah anda yakin ingin Logut dari form ini? ,{conn.Nama}", "infornmasu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == dr)
            {
                new Form1().Show();
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((comboBox1.Text == string.Empty) || (comboBox2.Text == string.Empty))
            {
                MessageBox.Show("data tidak boleh kosong!");
                return;
            }
            else if(comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("keberangkatan dan tujuan tidak boleh sama", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string BandaraASal = comboBox1.Text.Split(',')[0].Trim();
                string kodeIATAasal = comboBox1.Text.Split('(', ')')[1];

                string bandaratj = comboBox2.Text.Split(',')[0].Trim();
                string kodeIATA2 = comboBox2.Text.Split('(', ')')[1];

               openForm(new ListPenerbangan(BandaraASal, kodeIATAasal, bandaratj, kodeIATA2, dateTimePicker1.Value, (int)numericUpDown1.Value, id));
            }
        }

        void openForm<T>(T form) where T : Form
        {
            form.Show();
            form.FormClosed += formClosed;
            Hide();
        }
        void formClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}
