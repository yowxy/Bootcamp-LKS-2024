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
    public partial class MemberMainForm : Form
    {
        EsemkaFoodcourtEntities db = new EsemkaFoodcourtEntities();
        Users user;
        public MemberMainForm(Users user)
        {
            InitializeComponent();
            this.user = user;
            label1.Text = $"Welcome ,{user.FirstName + user.LastName}";
        }

        private void MemberMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
