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

namespace EsemkaFoodcourt_Latihan
{
    public partial class ManageMenu : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        bool Isinsert = true;

        public ManageMenu()
        {
            InitializeComponent();
        }

        private void ManageMenu_Load(object sender, EventArgs e)
        {
            menusBindingSource.DataSource = db.Menus.ToList();  
            bindingSource1.DataSource = db.Categories.ToList();
            textmenu.AddNew();

            nameTextBox.Enabled = false;
            categoriesComboBox.Enabled = false;
            descriptionTextBox.Enabled = false;
            priceNumericUpDown.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = true; button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;

        }

        private void menusDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (menusDataGridView.Rows[e.RowIndex].DataBoundItem is Menus menu)
            {
                if(e.ColumnIndex == dataGridViewTextBoxColumn6.Index)
                {
                    e.Value = menu.Categories.Name;
                }
                if(e.ColumnIndex == dataGridViewTextBoxColumn5.Index)
                {
                    e.Value = menu.Price.ToString("C2");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Enabled = true;
            button2.Enabled = false; button3.Enabled = false;
            nameTextBox.Enabled = true;
            categoriesComboBox.Enabled = true;
            descriptionTextBox.Enabled = true;
            priceNumericUpDown.Enabled = true;
            reset();
            button4.Enabled = true;
            button5.Enabled = true;
        }

        void reset()
        {
            nameTextBox.Text = categoriesComboBox.Text = descriptionTextBox.Text = priceNumericUpDown.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((nameTextBox.Text == string.Empty) || (categoriesComboBox.Text == string.Empty) || (descriptionTextBox.Text == string.Empty) || (priceNumericUpDown.Text == string.Empty))
            {
                MessageBox.Show("Data Tidak Boleh Kosong");
            }
            else
            {
                if(textmenu.Current is Menus menu)
                {
                    if (Isinsert)
                    {
                        db.Menus.Add(menu);
                        MessageBox.Show("Data berhasil ditambahkan");
                    }
                    else
                    {
                        db.Menus.AddOrUpdate(menu);
                        MessageBox.Show("Data Berhasil Diubah");
                    }
                    db.SaveChanges();
                    OnLoad(EventArgs.Empty);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            nameTextBox.Enabled = false;
            categoriesComboBox.Enabled = false;
            descriptionTextBox.Enabled = false;
            priceNumericUpDown.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = true; button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(menusBindingSource.Current is Menus menu)
            {
                var del = db.Menus.Where(c=> c.ID == menu.ID).FirstOrDefault();
                if (del != null)
                {
                    string nama = del.Name;
                    DialogResult dr = MessageBox.Show($"Yakin Akan Menghapus Data Ini {nama} ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        db.Menus.Remove(del);
                        db.SaveChanges();
                        MessageBox.Show("Data Berhasil Dihapus");
                        OnLoad(EventArgs.Empty);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Menus mm)
            {
                var ubah = db.Menus.Where(f => f.ID == mm.ID).FirstOrDefault();

                if (ubah != null)
                {
                    string nama = ubah.Name;
                    DialogResult dr = MessageBox.Show($"Yakin Akan Mengubah Data Ini ?{nama} ", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        button1.Enabled = false;
                        button3.Enabled = false;
                        nameTextBox.Enabled = true;
                        categoriesComboBox.Enabled = true;
                        descriptionTextBox.Enabled = true;
                        priceNumericUpDown.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        Isinsert = false;

                        menusBindingSource.DataSource = ubah;
                        Isinsert = false;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchtext = textBox1.Text.ToLower();


            var searchResults = db.Users
               .Where(u => u.FirstName.ToLower().Contains(searchtext) ||
                           u.LastName.ToLower().Contains(searchtext) ||
                           u.Email.ToLower().Contains(searchtext))
               .ToList();

           bindingSource1.DataSource = searchResults;
        }
    }
}
