using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ThuVien
{
   public class Txtboxngaythangnam:MaskedTextBox
    {

        ErrorProvider error = new ErrorProvider();
        public Txtboxngaythangnam()
        {
            //ErrorProvider err = new ErrorProvider();
            //DateTime date = DateTime.ParseExact(this.Text, "dd/MM/yyyy",null);

            //DateTime a = DateTime.Now ;
            this.KeyDown += Txtboxngaythangnam_KeyDown;
            
          
        }

        private void Txtboxngaythangnam_KeyDown(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"^((((0[13578])|([13578])|(1[02]))[\/](([1-9])|([0-2][0-9])|(3[01])))|(((0[469])|([469])|(11))[\/](([1-9])|([0-2][0-9])|(30)))|((2|02)[\/](([1-9])|([0-2][0-9]))))[\/]\d{4}$|^\d{4}$");

            if (regex.IsMatch(this.Text))
            {
                error.Clear();
            }
            else
                error.Clear();
        }
    }
}
