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

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class Phieuchi : DevExpress.XtraEditors.XtraUserControl
    {
        DALl_BALl_Phieuchics dpc = new DALl_BALl_Phieuchics();
        public Phieuchi()
        {
            InitializeComponent();
        }

        public void load_phieuthu(object sender,EventArgs e)
        {
            gridControl1.DataSource = dpc.loadphieuchi();

        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
