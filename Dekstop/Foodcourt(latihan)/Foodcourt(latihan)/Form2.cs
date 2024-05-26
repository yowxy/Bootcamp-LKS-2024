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
    public partial class Form2 : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        Users user;
        public Form2(Users userrrr)
        {
            InitializeComponent();
            this.user = userrrr;
            label1.Text = $"Welcome ,{userrrr.FirstName + userrrr.LastName}";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
