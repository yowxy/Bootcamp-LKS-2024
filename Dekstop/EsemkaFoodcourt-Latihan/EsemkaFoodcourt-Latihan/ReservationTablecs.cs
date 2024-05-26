using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EsemkaFoodcourt_Latihan
{
    public partial class ReservationTablecs : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        private readonly Users user;

        public ReservationTablecs(Users user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ReservationTablecs_Load(object sender, EventArgs e)
        {

            reservationsBindingSource.Add(new Reservations
            {
                Users = user,
                UserID = user.ID,
                CustomerFirstName = user.FirstName,
                CustomerLastName = user.LastName,
                CustomerEmail = user.Email,
                CustomerPhoneNumber = user.PhoneNumber,
                ReservationDate = DateTime.Today
            });
            QtyForm.DataSource = new ReservationDetails();
            menusBindingSource.DataSource = db.Menus.ToList();
            categoriesComboBox.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (reservationsBindingSource.Current is Reservations rs)
            {
                rs.Users = null;
                db.Reservations.AddOrUpdate(rs);
                if (reservationsBindingSource.Count > 0)
                {
                    foreach (ReservationDetails detail in Details.List)

                    {
                        detail.Reservations = rs;
                        db.ReservationDetails.AddOrUpdate(detail);
                    }


                    int result = db.SaveChanges();

                    if (result > 0)
                    {
                        MessageBox.Show("Your reservation is saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new FormMember(user).Show();
                        this.Hide();
                    }
                    else
                    {
                        "Cannot save your reservation".DialogError();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (QtyForm.Current is ReservationDetails detail)
            {
                // bool isValid = true;

                ReservationDetails x = Details.List.Cast<ReservationDetails>().Where(ex => ex.MenuID == detail.MenuID).FirstOrDefault();
                if (x != null)
                {
                    x.Qty += x.Qty;
                    Details.EndEdit();
                    Details.ResetBindings(false);
                }
                else
                {
                    QtyForm.EndEdit();
                    detail.Menus = categoriesComboBox.SelectedItem as Menus;
                    Details.Add(detail);
                }
                QtyForm.Clear();
                QtyForm.AddNew();

                qtyNumericUpDown.Value = 0;
                categoriesComboBox.SelectedIndex = -1;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            customerEmailTextBox.ReadOnly =
            customerFirstNameTextBox.ReadOnly =
            customerLastNameTextBox.ReadOnly =
            customerPhoneNumberTextBox.ReadOnly = checkBox1.Checked;
        }

        private void reservationDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = reservationDateDateTimePicker.Value.Date;

            Table.DataSource = db.Tables.Where(f=> f.Reservations.Where(e1 => e1.ReservationDate == date).Count()==0).ToList(); 
        }

        private void reservationDetailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == Action.Index)
            {
                Details.Remove(reservationDetailsDataGridView.Rows[e.RowIndex].DataBoundItem); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormMember(user).Show();
            Hide();
        }

        private void reservationDetailsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.RowIndex <Details.Count)
            {
                ReservationDetails detail = reservationDetailsDataGridView.Rows[e.RowIndex].DataBoundItem as ReservationDetails;
                if(e.ColumnIndex == dataGridViewTextBoxColumn5.Index)
                {
                    e.Value = detail.Menus.Name;
                }
                if(e.ColumnIndex == price.Index)
                {
                    e.Value = detail.Menus.Price.ToString("C", new CultureInfo("id-ID"));
                }
                if(e.ColumnIndex == subtotal.Index)
                {
                    e.Value = (detail.Menus.Price * detail.Qty).ToString("C", new CultureInfo("id-ID"));
                }
            }
        }

        private void reservationDetailsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (Details.List is BindingList<ReservationDetails> reservations)
            {
                double totalPrice = 0;
                foreach (ReservationDetails detail in reservations)
                {
                    totalPrice += detail.Menus.Price * detail.Qty;
                }
                label2.Text = $"Menu Total: {totalPrice.ToString("C", new CultureInfo("id-ID"))}";
                label3.Text = $"Total Price : {(totalPrice + 50000).ToString("C", new CultureInfo("id-ID"))}";

            }
        }
    }
}
