using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaPolling
{
    public partial class Pengguna_Admin_cs : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities();
        private int id = -1;
        public Pengguna_Admin_cs()
        {
            InitializeComponent();
        }

        private void Pengguna_Admin_cs_Load(object sender, EventArgs e)
        {
            userBindingSource.DataSource = db.Users.Where(x=> x.Name.Contains(textBox1.Text)||x.IdentityCode.Contains(textBox1.Text)).ToList();
            TextBinding.AddNew();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TextBinding.Current is User usr  )
            {
                db.Users.AddOrUpdate(usr);
                db.SaveChanges();
                button4.PerformClick();
                OnLoad(EventArgs.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) MessageBox.Show("Mohon isi data terlebih dahulu!");
            else if (dataGridView1.SelectedRows[0].DataBoundItem is User usr) 
            {
                if (MessageBox.Show("Yakin nih mau ngehapus?","informasi",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    db.Users.Remove(usr);
                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userBindingSource.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) MessageBox.Show("Mohon isi terlebih dahulu");
            else if (dataGridView1.SelectedRows[0].DataBoundItem is User us)
            {
                TextBinding.DataSource = db.Users.AsNoTracking().First(x=> x.UserID == us.UserID);    
                identityCodeMaskedTextBox.Enabled = false;  
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnLoad(EventArgs.Empty);        
        }
    }
}
