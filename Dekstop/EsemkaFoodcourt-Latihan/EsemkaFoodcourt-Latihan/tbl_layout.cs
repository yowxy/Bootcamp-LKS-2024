using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaFoodcourt_Latihan
{
    public partial class tbl_layout : UserControl
    {
        int i;
        Reservations reservation;
        public tbl_layout(int i, Reservations reservation)
        {
            InitializeComponent();
            this.i = i;
            this.reservation = reservation;
        }

        private void tbl_layout_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = reservation == null ? Properties.Resources.table_free : Properties.Resources.table_reserved;
            label1.Text = i.ToString();
        }
    }
}
