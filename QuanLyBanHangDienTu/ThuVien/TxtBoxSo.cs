using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace ThuVien
{
 public   class TxtBoxSo:DevExpress.XtraEditors.TextEdit

    {

        public TxtBoxSo()
        {
            this.KeyPress += TxtSoDienThoai_KeyPress;
        }

        public static bool IsValidPhone(string value)
        {
            string pattern = @"^-*[0-9,\.?\-?\(?\)?\ ]+$";
            return Regex.IsMatch(value, pattern);
        }


        private void TxtSoDienThoai_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
          if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            

        }

    }
}
