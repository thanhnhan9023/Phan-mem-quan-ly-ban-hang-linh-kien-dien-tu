using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThuVien
{
   public class KiemtraString
    {

        public  bool IsValidPhone(string value)
        {
            string pattern = @"^-*[0-9,\.?\-?\(?\)?\ ]+$";
            return Regex.IsMatch(value, pattern);
        }
        public  bool IsValidEmail(string email)
        {

            if (email.Contains("@") && email.Contains(".com"))
                return true;
            return false;
        }
    }
}
