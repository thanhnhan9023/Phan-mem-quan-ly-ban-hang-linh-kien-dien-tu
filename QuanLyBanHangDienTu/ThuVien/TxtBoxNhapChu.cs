using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace ThuVien
{
  public  class TxtBoxNhapChu:DevExpress.XtraEditors.TextEdit
    {
        public TxtBoxNhapChu()
        {
            this.KeyPress += TxtBoxNhapChu_KeyPress;
        }

        private void TxtBoxNhapChu_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
