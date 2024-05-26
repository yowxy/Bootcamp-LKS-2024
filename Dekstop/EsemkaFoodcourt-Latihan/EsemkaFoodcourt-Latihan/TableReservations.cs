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
    public partial class TableReservations : UserControl
    {
        int i;
        Reservations reser = null;
        public TableReservations(int i, Reservations reser)
        {
            InitializeComponent();
            this.i = i;
            this.reser = reser;
        }

        private void TableReservations_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = reser == null ? Properties.Resources.table_free : Properties.Resources.table_reserved;
            label2.Text = i.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Parent.Parent.Parent is ViewReservation reservation)
            {
                reservation.clickselect(reser);
            }
        }
    }
}
