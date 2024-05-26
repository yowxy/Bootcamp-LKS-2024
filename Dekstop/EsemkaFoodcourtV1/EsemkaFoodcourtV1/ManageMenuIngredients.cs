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
    public partial class ManageMenuIngredients : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();

        public ManageMenuIngredients()
        {
            InitializeComponent();
        }

        private void ManageMenuIngredients_Load(object sender, EventArgs e)
        {
            menusBindingSource.DataSource = db.Menus.ToList();
            menuIngredientsBindingSource.DataSource = db.MenuIngredients.ToList();
            bindingSource1.DataSource = db.Ingredients.ToList();
            bindingSource2.DataSource = db.Units.ToList();
            groupBox1.Enabled = false;
        }

        private void menusDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (menusDataGridView.Rows[e.RowIndex].DataBoundItem is Menus menu)
            {
                if(e.ColumnIndex == Action.Index)
                {
                    groupBox1.Enabled = true;
                }
            }
        }

        private void menuIngredientsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (menuIngredientsDataGridView.Rows[e.RowIndex].DataBoundItem is MenuIngredients menuing)
            {
                if(e.ColumnIndex == dataGridViewTextBoxColumn11.Index)
                {
                    e.Value = menuing.Ingredients.Name;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn12.Index)
                {
                    e.Value = menuing.Units.Name;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn13.Index)
                {
                    e.Value = menuing.Qty;
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void cari(string textname)
        {
            var d = db.Menus.Where(f => f.Name.StartsWith(textname)).ToList();
            bindingSource1.DataSource = d;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.cari(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
