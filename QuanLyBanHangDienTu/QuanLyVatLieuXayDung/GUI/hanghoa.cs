using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DALL_BALL;

namespace QuanLyVatLieuXayDung
{
    public partial class hanghoa : DevExpress.XtraEditors.XtraUserControl
    {
        DALL_BALL_HangHoa data = new DALL_BALL_HangHoa();
        public hanghoa()
        {
            InitializeComponent();
          
        }

        public void loadhanghoa(object sender, EventArgs e)
        {
           
        }

        private void dshanghoa_Click(object sender, EventArgs e)
        {

        }
    }
}
