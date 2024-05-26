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
    public partial class AdminForm : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        int id;
        public AdminForm(int id)
        {
            InitializeComponent();
            var conn = db.Users.Where(f => f.ID == id).FirstOrDefault();
            label1.Text = $"Welcome,{conn.FirstName} {conn.LastName}";
            this.id = id;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Apakah anda yakin Akan Logout dari From ini? ", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Form1 f = new Form1();
                this.Hide();
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ManageMemberFormcs().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ManageMenu().Show();
            Hide(); 
        }
    }
}
