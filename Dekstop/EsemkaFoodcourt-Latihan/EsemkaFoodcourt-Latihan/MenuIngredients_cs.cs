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
    public partial class MenuIngredients_cs : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        int op = -1;

        public MenuIngredients_cs()
        {
            InitializeComponent();
        }

        private void MenuIngredients_cs_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.Menus.ToList();
            bindingSource4.DataSource = db.Ingredients.ToList();
            bindingSource5.DataSource = db.Units.ToList();
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

          public void ResetState()
        {
            
            bindingSource3.Clear();
            bindingSource3.AddNew();
        }
        public void rstop()
        {
            this.op = -1;
        }

        private void cari(string textname)
        {
            var d = db.Menus.Where(f => f.Name.StartsWith(textname)).ToList();
            bindingSource1.DataSource = d;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            this.cari(textBox6.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Menu m)
            {
                if (e.ColumnIndex == EditIngredients.Index)
                {
                    groupBox1.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    numericUpDown1.Enabled = true;
                    button1.Enabled = true;
                    //bindingSource2.DataSource = db.MenuIngredients.Where(f => f.MenuID == m.ID).ToList();
                    bindingSource3.Clear();
                    bindingSource3.AddNew();
                }


            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is MenuIngredient menu)
            {
                if (e.ColumnIndex == action.Index)
                {
                    bindingSource2.Remove(menu);
                   // db.MenuIngredients.Remove(menu);
                    button3.Enabled = true;
                    button2.Enabled = true;
                    this.op = 1;
                }

            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is MenuIngredient m)
            {
                if (e.ColumnIndex == ingredient.Index)
                {
                    var nama = m.IngredientID;
                    e.Value = db.Ingredients.FirstOrDefault(f => f.ID == nama).Name;
                }
                if (e.ColumnIndex == unit.Index)
                {
                    var nama = m.UnitID;
                    e.Value = db.Units.FirstOrDefault(f => f.ID == nama).Name;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            numericUpDown1.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
