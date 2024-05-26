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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EsemkaCinema
{
    public partial class Form1 : Form
    { 
        EsemkaCinemaEntities cinema= new EsemkaCinemaEntities();
        private int id = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
     
            bindingSource2.DataSource = cinema.Movies.ToList();
            movieBindingSource.AddNew();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movieBindingSource.Current is Movie mov)
            {
                mov.ReleaseDate = releaseDateDateTimePicker.Value;

                cinema.Movies.AddOrUpdate(mov);

                cinema.SaveChanges();

                OnLoad(EventArgs.Empty);    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            movieBindingSource.Clear(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (movieDataGridView.SelectedRows.Count == 0) MessageBox.Show("Mohon isi  terlebih dahulu");
            else if (movieDataGridView.SelectedRows[0].DataBoundItem is Movie mov)
            {
                movieBindingSource.DataSource = cinema.Movies.AsNoTracking().First(f => f.ID == mov.ID);     
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (movieDataGridView.SelectedRows.Count == 0) MessageBox.Show("Mohon isi  terlebih dahulu");
            else if (movieDataGridView.SelectedRows[0].DataBoundItem is Movie mov)
            {
                if (MessageBox.Show("yakiningin mengahpus?","confirmation",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    cinema.Movies.Remove(mov);  
                    cinema.SaveChanges();   
                    OnLoad(EventArgs.Empty);        
                }
            }
        }
    }
}
