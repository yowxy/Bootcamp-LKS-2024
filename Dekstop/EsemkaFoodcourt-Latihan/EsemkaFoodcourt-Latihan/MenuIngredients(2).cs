using EsemkaFoodcourt_Latihan;
using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EsemkaFoodcourt_Latihan
{
    public partial class MenuIngredients_2_ : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();

        int op = -1;
        public MenuIngredients_2_()
        {
            InitializeComponent();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void ShowIngredients(int menuId)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmManageMenuIngredients_Load(object sender, EventArgs e)
        {



            groupBox1.Enabled = false;

            bindingSource2.DataSource = db.Ingredients.ToList();

            bindingSource1.DataSource = db.Menus.ToList();
            bindingSource4.DataSource = db.Units.ToList();
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is MenuIngredients its)
            {
                if (e.ColumnIndex == IngColumn.Index)
                {
                    var nama = its.IngredientID;

                    e.Value = db.Ingredients.FirstOrDefault(f => f.ID == nama).Name;
                }
                else if (e.ColumnIndex == UnitCol.Index)
                {
                    var units = its.UnitID;
                    e.Value = db.Units.FirstOrDefault(f => f.ID == units).Name;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Menus m)
            {
                if (e.ColumnIndex == ActionColumn.Index)
                {
                    groupBox1.Enabled = true;
                    bindingSource5.Clear();
                    bindingSource5.AddNew();

                    //    menuIngredientsBindingSource.DataSource = db.MenuIngredients.OrderBy(f=> f.ID == m.ID).ToList();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].DataBoundItem is Menus m)
            {
                if (bindingSource5.Current is MenuIngredients ss)
                {
                    ss.MenuID = m.ID;
                    bindingSource3.Add(ss);
                    db.MenuIngredients.Add(ss);
                    // db.MenuIngredients.Add(ss);
                }

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            qtyNumericUpDown.Enabled = false;
            unitIDComboBox.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cari = textBox1.Text.ToLower();
            var s = db.Menus.Where(f => f.Name.Contains(cari) || f.Categories.Name.ToLower().Contains(cari)).ToList();


            bindingSource1.DataSource = s;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is MenuIngredients ms)
            {
                if (e.ColumnIndex == RemoveColumn.Index)
                {


                    bindingSource3.Remove(ms);
                    db.MenuIngredients.Remove(ms);
                    this.op = 1;
                    // db.MenuIngredients.Add(ss);

                }
            }

        }

        private void menuIngredientsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Menus m)
            {
                bindingSource3.DataSource = m.MenuIngredients.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.op == -1)
            {
                DialogResult dr = MessageBox.Show($"Apakah Anda Yakin Ingin Menambahkan Bahan Ini {comboBox1.Text}", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    db.SaveChanges();
                    groupBox1.Enabled = false;
                }
                else
                {
                    return;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show($"Apakah Anda Yakin Ingin Menghapus Bahan Ini {comboBox1.Text}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    db.SaveChanges();
                    groupBox1.Enabled = false;
                }
                else
                { return; }

            }
            this.op = -1;

        }
    }
}
