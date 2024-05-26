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

namespace SimulasiLKSpolling
{
    public partial class PenggunaAdmin : Form
    {
        EsemkaPollingEntities db = new EsemkaPollingEntities(); 
        public PenggunaAdmin()
        {
            InitializeComponent();
        }

        private void PenggunaAdmin_Load(object sender, EventArgs e)
        {
            userBindingSource.DataSource = db.Users.ToList();
            bindingSource1.AddNew();
        }

        private void identityCodeLabel_Click(object sender, EventArgs e)
        {

        }

        private void identityCodeMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnLoad(EventArgs.Empty);    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is User usr)
            {
                db.Users.AddOrUpdate(usr);
                db.SaveChanges();   
                button4.PerformClick();     
                OnLoad(EventArgs.Empty);    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) MessageBox.Show("Mohon isi terlebih dahulu!");
            else if (dataGridView1.SelectedRows[0].DataBoundItem is User usr)
            {
                if (MessageBox.Show("Yakin nih mau ngehapus?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Users.Remove(usr);
                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) MessageBox.Show("Mohon  isi terlebih dahulu");
            else if (dataGridView1.SelectedRows[0].DataBoundItem is User usr)
            {
                bindingSource1.DataSource = db.Users.AsNoTracking().FirstOrDefault(x => x.UserID == usr.UserID);
                identityCodeMaskedTextBox.Enabled= false;       
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userBindingSource.Clear();  
        }
    }
}
