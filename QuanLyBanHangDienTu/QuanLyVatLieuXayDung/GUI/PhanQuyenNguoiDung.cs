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
    public partial class PhanQuyenNguoiDung : DevExpress.XtraEditors.XtraUserControl

    {
        bool hienthi = false;
        DALL_QuantriNguoiDung qt = new DALL_QuantriNguoiDung();
        public PhanQuyenNguoiDung()
        {
            InitializeComponent();
        }
        public void load_phanquyennguoidung(object sender, EventArgs e)
        {
            loaduser();
         //   loadusernhomnguoidung();
            loadcomboxnhom();
           if(hienthi)
            cboNhomND.SelectedIndex = 0;
            loadusernhomnguoidung();
        }
        public void loaduser()
        {

            dsNguoiDung.DataSource = qt.loaduserall();

            } 

        public void loadusernhomnguoidung()
        {       if(hienthi)
           dsNhomND.DataSource = qt.loadnhomnguoidung(cboNhomND.SelectedValue.ToString());
        }

        public void loadcomboxnhom()
        {
            cboNhomND.DataSource = qt.loadnhoom();
            cboNhomND.DisplayMember = "Tennhomnguoidung";
            cboNhomND.ValueMember = "Manhomnguoidung";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(gridView1.RowCount>0)
            {
                string user = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserName").ToString();
                
                if (qt.kiemtrakhoachinh(user,cboNhomND.SelectedValue.ToString()))
                {
                    XtraMessageBox.Show("Đã Tồn Tại User "+user+" Vui Lòng Kiểm Tra Các Nhóm Người Dùng");
                    return;
                }
                if (XtraMessageBox.Show("Bạn có muốn Thêm vào nhóm quyền "+cboNhomND.SelectedText.ToString(), "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    

                    qt.themuservaonhomnd(user, cboNhomND.SelectedValue.ToString());
                    dsNhomND.DataSource = qt.loadnhomnguoidung(cboNhomND.SelectedValue.ToString());

                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa user này ra khỏi nhóm quyền " + cboNhomND.SelectedText.ToString(), "Đồng Ý Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string user = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "UserName").ToString();
                    string mand = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Manhomnguoidung").ToString();
                    qt.xoa1nguoidungrahomnd(user, mand);
                    XtraMessageBox.Show("Đã Loại" + user+"Ra Khỏi Nhóm"+cboNhomND.SelectedText.ToString());
                    dsNhomND.DataSource = qt.loadnhomnguoidung(cboNhomND.SelectedValue.ToString());

                }
            }
        }

        private void cboNhomND_SelectedValueChanged(object sender, EventArgs e)
        {
            if(hienthi)
                  dsNhomND.DataSource = qt.loadnhomnguoidung(cboNhomND.SelectedValue.ToString());
        }

        private void PhanQuyenNguoiDung_VisibleChanged(object sender, EventArgs e)
        {
            load_phanquyennguoidung(sender, e);
            hienthi = true;
        }
    }
}
