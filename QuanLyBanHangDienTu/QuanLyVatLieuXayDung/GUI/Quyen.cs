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
    public partial class Quyen : DevExpress.XtraEditors.XtraUserControl
    {

        bool add, update;
        DALL_BALL_PhanQuyencs pq = new DALL_BALL_PhanQuyencs();
        DALL_QuantriNguoiDung qt = new DALL_QuantriNguoiDung();
        public Quyen()
        {
            InitializeComponent();
        }
        public void load_quyen(object sendẻ,EventArgs e)
        {
            txtMaquyen.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            loadsquyen();
            databinds(true);
        }
        public void databinds(bool t)
        {
            if (t)
            {
                txtMaquyen.DataBindings.Clear();
                txtMaquyen.DataBindings.Add("Text", dsquyen.DataSource, "Maquyen");
                txtChucnangquyen.DataBindings.Clear();
                txtChucnangquyen.DataBindings.Add("Text", dsquyen.DataSource, "Chucnangquyen");
                txtMota.DataBindings.Clear();
                txtMota.DataBindings.Add("Text", dsquyen.DataSource, "Mota");
            }
            else
            {
                txtMaquyen.DataBindings.Clear();
                txtChucnangquyen.DataBindings.Clear();
                txtMota.DataBindings.Clear();
            }
        }
        public void loadsquyen()
        {
            dsquyen.DataSource = pq.loadquyen();
        }
            
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            add = false;
            btnXoa.Enabled = false;
            update = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            databinds(false);


            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(add)
            {

                if (XtraMessageBox.Show("Bạn có muốn thêm quyền này không ", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qt.them1quyen(txtMaquyen.Text, txtChucnangquyen.Text, txtMota.Text);
                    load_quyen(sender, e);
                    XtraMessageBox.Show("Thêm thành công");
                }
            }
            if(update)
            {

                if (XtraMessageBox.Show("Bạn có muốn sửa quyền này không ", "Đồng Ý Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qt.sua1quyen(txtMaquyen.Text, txtChucnangquyen.Text, txtMota.Text);
                    load_quyen(sender, e);
                    XtraMessageBox.Show("Thêm thành công");
                }
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            load_quyen(sender, e);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa quyền này không " , "Đồng Ý Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                qt.xoa1quyen(txtMaquyen.Text);
                load_quyen(sender, e);
                XtraMessageBox.Show("Thành công");
                load_quyen(sender, e);

            }
        }

        private void Quyen_VisibleChanged(object sender, EventArgs e)
        {
            load_quyen(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            txtMaquyen.Text="";
            txtChucnangquyen.Text = "";
            txtMota.Text = "";
            txtMaquyen.Focus();
            if(gridView1.RowCount<=0)
            {
                txtMaquyen.Text = "QH001";
            }
            else
            {
               txtMaquyen.Text=qt.getmaquyentutang();
            }
                    
            
        }


    }
}
