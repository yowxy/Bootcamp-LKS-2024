using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaPolling
{
    public partial class HalamanUtama_User_cs : Form
    {
        
        int id;
        int users;
        public HalamanUtama_User_cs(int users)
        {
            InitializeComponent();
            this.users = users;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
           PemungutanSuara_User_ adm = new PemungutanSuara_User_(users);
            adm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LaporanUser usr = new LaporanUser(users);    
            usr.ShowDialog();   
        }

        private void HalamanUtama_User_cs_Load(object sender, EventArgs e)
        {

        }
    }
}
