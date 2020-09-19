using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
 public   class TuDongTang
    {
        public string laymatudongtang(string x, string intput)
        {
            string z = x.Substring(x.Length - 1, 1);
            string t = x.Substring(0, x.Length - 1);
            return t + (int.Parse(z) + 1).ToString();


        }

    }
}
