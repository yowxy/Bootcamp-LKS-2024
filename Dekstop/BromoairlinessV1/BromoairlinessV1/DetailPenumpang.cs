using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoairlinessV1
{
    public partial class DetailPenumpang : UserControl
    {
        public DetailPenumpang(int a)
        {
            InitializeComponent();
            label1.Text = $"Penumpang #{a}";
        }

        private void DetailPenumpang_Load(object sender, EventArgs e)
        {

        }
        public string titel()
        {
            return comboBox1.SelectedItem?.ToString();
        }

        public string nama()
        {
            return textBox1.Text;
        }
    }
}
