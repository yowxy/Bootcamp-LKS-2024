using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodcourt_latihan_
{
    public partial class Form5 : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities(); 

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            usersBindingSource.DataSource = db.Users.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var search = textBox1.Text.ToLower();
            
            var cari = db.Users.Where(f=> f.FirstName.ToLower().Contains(search) || f.Password.ToLower().Contains(search) || f.Email.ToLower().Contains(search)).ToList();
            usersBindingSource.DataSource = cari;
        }
    }
}
