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

namespace EsemkaFoodcourt_Latihan
{
    public partial class ReservationTableHistory : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities(); 


        public ReservationTableHistory()
        {
            InitializeComponent();
        }

        private void ReservationTableHistory_Load(object sender, EventArgs e)
        {
            reservationDetailsBindingSource.DataSource = db.ReservationDetails.ToList();
            reservationsBindingSource.DataSource = db.Reservations.ToList();
        }

        private void reservationsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (reservationsDataGridView.Rows[e.RowIndex].DataBoundItem is Reservations reser)
            {
                var formatRupiah = CultureInfo.CreateSpecificCulture("id-ID");
                if (e.ColumnIndex == Tableno.Index)
                {
                    e.Value = reser.Tables.Name;
                }
                if(e.ColumnIndex == Price.Index)
                {
                    if(reser.ReservationDetails !=null && reser.ReservationDetails.Any())
                    {
                        e.Value = reser.ReservationDetails.First().Menus.Price.ToString("C2",formatRupiah);
                    }
                }
            }
        }

        private void reservationDetailsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (reservationDetailsDataGridView.Rows[e.RowIndex].DataBoundItem is ReservationDetails reser)
            {
                var formatRupiah = CultureInfo.CreateSpecificCulture("id-ID");
                if(e.ColumnIndex == dataGridViewTextBoxColumn17.Index)
                {
                    e.Value = reser.Menus.Name;
                }
                if (e.ColumnIndex == Price.Index)
                {
                    e.Value = reser.Menus.Price.ToString("C2", formatRupiah);
                }
                if (e.ColumnIndex == Subtotal.Index)
                {
                    var total = reser.Menus.Price * reser.Qty;

                    e.Value = total.ToString("C2", formatRupiah);
        }
                }
            }
    }
}
