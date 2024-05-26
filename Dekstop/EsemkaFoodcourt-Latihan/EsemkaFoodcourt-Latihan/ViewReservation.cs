using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EsemkaFoodcourt_Latihan
{
    public partial class ViewReservation : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();

        public ViewReservation()
        {
            InitializeComponent();
        }

        private void ViewReservation_Load(object sender, EventArgs e)
        {
            reset();
            reservationDetailsBindingSource.DataSource = db.ReservationDetails.ToList();
        }
        public void clickselect(Reservations reser)
        {
            bindingSource1.Clear();
            bindingSource1.Add(reser);
            if (reser != null)
                reservationDetailsBindingSource.DataSource = reser.ReservationDetails;
            else
                reservationDetailsBindingSource.Clear();
        }



        void reset()
        {

            flowLayoutPanel1.Controls.Clear();
            bindingSource1.DataSource = db.Reservations.Where(x => x.ReservationDate == reservationDateDateTimePicker.Value).ToList();


            var list_table = new List<Reservations>();

            for (int i = 0; i < 12; i++)
            {
                list_table.Add(null);
            }

            db.Reservations.Where(x => x.ReservationDate == reservationDateDateTimePicker.Value.Date).ToList().ForEach(x =>
            {
                list_table[x.TableID - 1] = x;
            });


            var l = 0;
            foreach (var item in list_table)
            {
                flowLayoutPanel1.Controls.Add(new TableReservations(l + 1, item));
                l++;
            }

        }

        private void reservationDetailsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (reservationDetailsDataGridView.Rows[e.RowIndex].DataBoundItem is ReservationDetails rsser)
            {
                var formatRupiah = CultureInfo.CreateSpecificCulture("id-ID");
                if (e.ColumnIndex == dataGridViewTextBoxColumn5.Index)
                {
                    e.Value = rsser.Menus.Name;
                } 
                if(e.ColumnIndex == price.Index)
                {
                    e.Value = rsser.Menus.Price.ToString("C2", formatRupiah);
                }
                if(e.ColumnIndex == Subtotal.Index)
                {
                    e.Value = (rsser.Menus.Price * rsser.Qty).ToString("C2", formatRupiah);
                }
            }
        }

        private void reservationDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            reset();
        }
    }
}
