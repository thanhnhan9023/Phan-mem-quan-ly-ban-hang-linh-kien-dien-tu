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
    public partial class Nhomnguoidung : DevExpress.XtraEditors.XtraUserControl
    {
        DALL_QuantriNguoiDung qt = new DALL_QuantriNguoiDung();
        DALL_BALL_PhanQuyencs pq = new DALL_BALL_PhanQuyencs();
        bool add, update;
        public Nhomnguoidung()
        {
            InitializeComponent();
        }


        public void load_nhomn(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            loadngngoidung();
            datatbinds(true);
            txtManhonnd.Enabled = false;
            
            
            
        }
        public void loadngngoidung()
        {

           dsNhomNd.DataSource=pq.loadnhomnguoidung();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        public void datatbinds(bool t)
        {
            if (t)
            {
                txtManhonnd.DataBindings.Clear();
                txtManhonnd.DataBindings.Add("Text", dsNhomNd.DataSource, "Manhomnguoidung");
                txtTennhomnd.DataBindings.Clear();
                txtTennhomnd.DataBindings.Add("Text", dsNhomNd.DataSource, "Tennhomnguoidung");
                txtMota.DataBindings.Clear();
                txtMota.DataBindings.Add("Text", dsNhomNd.DataSource, "Mota");
            }
            else
            {
                txtManhonnd.DataBindings.Clear();
                txtTennhomnd.DataBindings.Clear();
                txtMota.DataBindings.Clear();


            }

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            add = false;
            update = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;   
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(add)
            {
                if(txtTennhomnd.Text.Length<=0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên nhóm người dùng");
                    return;

                }
                if (XtraMessageBox.Show("Bạn có muốn thêm nhóm người dùng này không ", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qt.them1nhomnd(txtManhonnd.Text, txtTennhomnd.Text, txtMota.Text);
                    load_nhomn(sender, e);
                    XtraMessageBox.Show("Thêm thành công nhóm người dùng "+txtTennhomnd.Text);
                }
            
            }
            if(update)
            {

                if (XtraMessageBox.Show("Bạn có muốn sửa nhóm người dùng này không ", "Đồng Ý Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qt. sua1nhomnd(txtManhonnd.Text, txtTennhomnd.Text, txtMota.Text);
                    load_nhomn(sender, e);
                    XtraMessageBox.Show("Sửa thành công");

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if(gridView1.RowCount<=0)
            {

                XtraMessageBox.Show("Không có nhóm quyền nào");
                return;
            }
            if (XtraMessageBox.Show("Bạn có muốn xóa người dùng này không ", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                qt.xoa1nhomnd(txtManhonnd.Text);
                load_nhomn(sender, e);
                XtraMessageBox.Show("Xóa thành công "+txtTennhomnd.Text);
            }
        }

        private void Nhomnguoidung_VisibleChanged(object sender, EventArgs e)
        {
            load_nhomn(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            datatbinds(false);

            txtManhonnd.Text = "";
            txtTennhomnd.Text = "";
            txtMota.Text = "";
            if (gridView1.RowCount <= 0)
            {
                txtManhonnd.Text = "ND001";
            }
            else
              txtManhonnd.Text=qt.getmanhomndtutang();
            

            
        }
    }
}
