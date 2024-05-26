using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaBromo
{
    public partial class MasterMaskapai : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities();     

        public MasterMaskapai()
        {
            InitializeComponent();
        }

        private void MasterMaskapai_Load(object sender, EventArgs e)
        {
            maskapaiBindingSource.DataSource = db.Maskapai.ToList();
            bindingSource1.AddNew();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Current is Maskapai maskapai)
            {
                db.Maskapai.Add(maskapai);  
                db.SaveChanges();   
                OnLoad(EventArgs.Empty);    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new MasterJadwalPenerebaangan().Show();
            Hide();
        }
    }
}
