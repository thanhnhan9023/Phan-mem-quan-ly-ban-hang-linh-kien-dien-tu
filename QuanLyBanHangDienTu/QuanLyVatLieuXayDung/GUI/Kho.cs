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
    public partial class Kho1 : DevExpress.XtraEditors.XtraUserControl
    {
        DALL_BALl_Khocs kho = new DALL_BALl_Khocs();
        DALL_BALL_Loaihang lh = new DALL_BALL_Loaihang();

        string makho="";
        public Kho1()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        public void laydulieukho()
        {
          
        }
        public void Kho_Load(object sender,EventArgs e)
        {
            loadkho();
            loadcomboxhh();
        }
        public void loadkho()
        {
            dskho.DataSource = kho.loadulieukho();
        }
        public void loadcomboxhh()
        {
            cboHangHoa.DataSource = lh.loaddulieuloaihang();
            cboHangHoa.DisplayMember = "TenLoai";
            cboHangHoa.ValueMember = "MaLoai";
        }
        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Kho_Load(sender, e);
        }

        private void cboHangHoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dskho.DataSource = kho.loadkhotheoloai(cboHangHoa.SelectedValue.ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            kho.xoa1kho(makho);
            Kho_Load(sender, e);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gridView1.RowCount<0)
            {
                return;
            }
            
            object mk = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDKho");
            if(mk==null)
            {
                return;
            }
            makho = mk.ToString();
                
        }

        private void Kho1_VisibleChanged(object sender, EventArgs e)
        {
            Kho_Load(sender, e);
        }
    }
}
