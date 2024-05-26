using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaFoodcourtV1
{
    public partial class AdminMainForm : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        Users users;

        public AdminMainForm(Users userss)
        {
            InitializeComponent();
            this.users = userss;
            label1.Text = $" Welcome { userss.FirstName + userss.LastName }";
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"apakah anda ingin Logout?", "infprmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Logout berhasil");
                new Form1().Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ManageMemberForm().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ManageMenu().Show();
            Hide(); 
        }
    }
}
