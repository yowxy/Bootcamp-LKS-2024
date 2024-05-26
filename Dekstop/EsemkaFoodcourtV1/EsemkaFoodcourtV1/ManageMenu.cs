using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaFoodcourtV1
{
    public partial class ManageMenu : Form
    {

        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        bool isnsert = true;

        public ManageMenu()
        {
            InitializeComponent();
        }

        private void ManageMenu_Load(object sender, EventArgs e)
        {
            menusBindingSource.DataSource = db.Menus.ToList();
            bindingSource1.AddNew();
            categories.DataSource = db.Categories.ToList();
            enabled();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nameTextBox.Enabled = true;
            categoriesComboBox.Enabled = true;
            descriptionTextBox.Enabled = true;
            priceNumericUpDown.Enabled = true;

            button4.Enabled = true;
            button5.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        void enabled()
        {
            nameTextBox.Enabled = false;
            categoriesComboBox.Enabled = false;
            descriptionTextBox.Enabled = false;
            priceNumericUpDown.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = true; 
            button3.Enabled = true;

            button4.Enabled = false;
            button5.Enabled = false;    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Current is Menus menu)
            {
                if(nameTextBox.Text == string.Empty || categoriesComboBox.Text == string.Empty || descriptionTextBox.Text == string.Empty)
                {
                    MessageBox.Show("pastikan semua kolom di isi!");
                    return;
                }
                else
                {
                    if (isnsert)
                    {
                        db.Menus.Add(menu);
                        MessageBox.Show("Data berhasil ditambahkan");
                    }
                    else
                    {
                        db.Menus.AddOrUpdate(menu);
                        MessageBox.Show("data berhasil di update");
                    }
                }

                db.SaveChanges();
                OnLoad(EventArgs.Empty);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(menusBindingSource.Current is Menus menusss)
            {

                var conn = db.Menus.Where(f => f.ID == menusss.ID).FirstOrDefault();
                if (conn != null)
                {

                    string nama = conn.Name;
                    DialogResult dr = MessageBox.Show("apakah anda yakin ingin menghapus ini?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        db.Menus.Remove(menusss);
                        MessageBox.Show("data berhasil dihapus");
                        db.SaveChanges();
                        OnLoad(EventArgs.Empty);
                    }

                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(menusBindingSource.Current is Menus menussss)
            {
                var conn = db.Menus.Where(f=> f.ID == menussss.ID).FirstOrDefault();
                if(conn != null)
                {

                    string uu= conn.Name;
                    DialogResult dr = MessageBox.Show($"apakah anda ingin merubah ini ?, {conn}", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        bindingSource1.DataSource = conn;

                        nameTextBox.Enabled = true;
                        categoriesComboBox.Enabled = true;
                        descriptionTextBox.Enabled = true;
                        priceNumericUpDown.Enabled = true;

                        button4.Enabled = true;
                        button5.Enabled = true;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;    
                    }

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            //string searchtext = textBox1.Text.ToLower();


            //var searchResults = db.Users
            //   .Where(u => u.FirstName.ToLower().Contains(searchtext) ||
            //               u.LastName.ToLower().Contains(searchtext) ||
            //               u.Email.ToLower().Contains(searchtext))
            //   .ToList();

            //bindingSource1.DataSource = searchResults;

        }

        private void menusDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (menusDataGridView.Rows[e.RowIndex].DataBoundItem is Menus menu)
            {
                if(e.ColumnIndex == dataGridViewTextBoxColumn6.Index)
                {
                    e.Value = menu.Categories.Name;
                }
                else if(e.ColumnIndex == dataGridViewTextBoxColumn5.Index)
                {
                    e.Value = menu.Price.ToString("C2");
                }
            }
        }
    }
}
