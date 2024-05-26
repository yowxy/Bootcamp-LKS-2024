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
    public partial class MasterKodePromo : Form
    {

        BromoAirlinesEntities db = new BromoAirlinesEntities(); 


        public MasterKodePromo()
        {
            InitializeComponent();
        }

        private void MasterKodePromo_Load(object sender, EventArgs e)
        {
            kodePromoBindingSource.DataSource = db.KodePromo.ToList();
            TextKode.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TextKode.Current is KodePromo kode)
            {
                db.KodePromo.Add(kode); 
                db.SaveChanges();
                OnLoad(EventArgs.Empty); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextKode.Clear();
        }
    }
}
