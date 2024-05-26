using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EsemkaFoodcourt_Latihan
{
    public partial class MenuIngredientsFormcs : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        int op = -1;

        public MenuIngredientsFormcs()
        {
            InitializeComponent();
        }

        private void MenuIngredientsFormcs_Load(object sender, EventArgs e)
        {

            groupBox1.Enabled = false;  
            //disable();
            unitsBindingSource.DataSource = db.Units.ToList();
            ingredientsBindingSource.DataSource = db.Ingredients.ToList();  


            menusBindingSource.DataSource = db.Menus.ToList();
            menuIngredientsBindingSource.DataSource = db.MenuIngredients.ToList();
        }


        void disable()
        {

            groupBox1.Enabled = false;
            menuIngredientsDataGridView.Enabled = false;
            nameComboBox.Enabled = false;
            nameComboBox1.Enabled = false;
            qtyNumericUpDown.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

        }

        private void menuIngredientsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (menuIngredientsDataGridView.Rows[e.RowIndex].DataBoundItem is MenuIngredients menu)
            {
                if(e.ColumnIndex == dataGridViewTextBoxColumn14.Index)
                {
                    e.Value = menu.Ingredients.Name;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn16.Index)
                {
                    e.Value = menu.Units.Name;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menusDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (menuIngredientsDataGridView.Rows[e.RowIndex].DataBoundItem is Menus menus)
            {
                if(e.ColumnIndex == Action.Index)
                {
                    groupBox1.Enabled = true;
                  //  bindingSource1.Clear();
                    bindingSource1.AddNew();

                }
            }
        }

        private void menusBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if(menusBindingSource.Current is Menus menu)
            {
                menuIngredientsBindingSource.DataSource = menu.MenuIngredients.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;    
            button2.Enabled = false;
            button3.Enabled = false;

            nameComboBox.Enabled = false;   
            qtyNumericUpDown.Enabled = false;
            nameComboBox1.Enabled = false;  
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(this.op == -1)
            {
                DialogResult dr = MessageBox.Show($"Apakah Anda Yakin Ingin Menambahkan Bahan Ini {nameComboBox.Text}", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                DialogResult dr = MessageBox.Show($"Apakah Anda Yakin Ingin Menghapus Bahan Ini {nameComboBox.Text}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cari = textBox1.Text.ToLower();
            var s = db.Menus.Where(f => f.Name.Contains(cari) || f.Categories.Name.ToLower().Contains(cari)).ToList();


            menusBindingSource.DataSource = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
