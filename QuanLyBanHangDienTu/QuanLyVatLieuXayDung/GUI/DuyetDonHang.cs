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
using System.Net;
using System.IO;
using DALL_BALL;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class DuyetDonHang : DevExpress.XtraEditors.XtraUserControl
    {
        DALL_BALL_DonHang donhang = new DALL_BALL_DonHang();
       
        public DuyetDonHang()
        {
            InitializeComponent();
        }
        public void loaddonhang()
        {
            dsDonhang.DataSource = donhang.loaddonhang();
        }

        public void duyetdonhangload(object sender, EventArgs e)
        {
     
    
            loaddonhang();
        
            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView2.OptionsView.BestFitMaxRowCount = -1;
            gridView2.BestFitColumns();

        }
        public void loadchitietdathang(String madh)
        {
            dschitietdcdathang.DataSource = donhang.loaddschitietdondathang(madh);
        }
       


        private  void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string madh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaDH").ToString();
            loadchitietdathang(madh);
         txtTenKhachHang.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenKH").ToString();
           txtSoDienThoai.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SDT").ToString();
         txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DiaChi").ToString();
            txtMaKhachHang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaKH").ToString();
            txtTongTien.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tongtien").ToString();
            txtMaDonHang.Text = madh;



        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var link = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Duongdan").ToString();

            if (link == null)
                return;
            pictureEdit1.LoadAsync(link.ToString());
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn duyệt đơn hàng này", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                donhang.update(txtMaDonHang.Text,"true");
                loaddonhang();
                XtraMessageBox.Show("Duyệt Thành công");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn duyệt xóa đơn hơn này", "Đồng Ý Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                donhang.deletedonhang(txtMaDonHang.Text);
                loaddonhang();
                XtraMessageBox.Show("Xóa thành Công");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            loaddonhang();
        }
    }
}
