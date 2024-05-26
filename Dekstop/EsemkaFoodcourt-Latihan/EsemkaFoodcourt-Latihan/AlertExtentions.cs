using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaFoodcourt_Latihan
{
    public static class AlertExtensions
    {
        public static DialogResult Dialoginfo(this string text)
        {
            return MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult DialogError(this string text)
        {
            return MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult DialogConfirm(this string text)
        {
            return MessageBox.Show(text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void SetError(this string text, ErrorProvider provider, Control control)
        {
            provider.SetError(control, text);
            if (!string.IsNullOrEmpty(text)) SystemSounds.Exclamation.Play();
        }
    }
}
