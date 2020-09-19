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
using DevExpress.XtraEditors.Controls;
using QuanLyVatLieuXayDung.Report;
using DevExpress.XtraReports.UI;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class TaoHoaDonXuat : DevExpress.XtraEditors.XtraUserControl
    {
        bool add = false, update = false, add2 = false, update2 = false;
      
        public static int maxacnhan=0;
        public  TaoHoaDonXuat()
        {
            InitializeComponent();
           
        }
        
        bool coxoa = false;
        DALL_BALL_Hoadonxuat hdxuat = new DALL_BALL_Hoadonxuat();
        DALL_BALL_KhachHang kh = new DALL_BALL_KhachHang();
        DALL_BALL_HangHoa hh = new DALL_BALL_HangHoa();
        DALL_BALL_Phieuthu pt = new DALL_BALL_Phieuthu();

        private string tinhtrang = "Đang giao dịch", tenhhtam
            , tinhtrang2="";
        float vat;
        
        
       
       
        public void load_hoadonxuat(object sender, EventArgs e)
        {

            loadhoadon();
            loadhanghoa();
            loadkhachhang();
            txtNgaySinh.DateTime = DateTime.Now;
            txtTenNv.Text = Login.tennv;
            txtTenNv.Enabled = false;
            seteditValuebyindex();
            btnLuu.Enabled = false;
            update = false;
            add = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaHDXuat.Enabled = false;
            

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();

            MenuLuuPhieunhap.Enabled = false;
            menuThemPhieuxuat.Enabled = true;
            Menuxoaphieuxuat.Enabled = true;

            if (gridView1.RowCount
                <= 0)
            {
               dsChitietHd.DataSource = null;
            }






        }


        public void loadkhachhang()
        {
            cboKhachHang.Properties.DataSource = kh.getdskhachhang();
            cboKhachHang.Properties.DisplayMember = "TenKH";
            cboKhachHang.Properties.ValueMember = "MaKH";
        }

        public void loadhoadon()
        {
            dshoadonhap.DataSource = hdxuat.loadataHoaDonXuat(Login.manv);


        

        }
        public void loadhanghoa()
        {

            cboHangHoa.Properties.DataSource = hh.loadkho();
            cboHangHoa.Properties.DisplayMember = "TenHH";
            cboHangHoa.Properties.ValueMember = "MaHH";

        
        }

        public void loaddulieuhoadonxuat(string mahdxuat)
        {

         dsChitietHd.DataSource= hdxuat.loadchitiethoadonxuat(mahdxuat);
            if(gridView2.RowCount<=0)
            {

                txtSoLuong.Text = "";
                txtGiaNhap.Text = "";

            }
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            databindchitiet(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lsttam.Count>0)
            {
                coxoa = true;
            }
            if(coxoa)
            {
                lsttam.Remove(lsttam.Single(x => x.MaHH == gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaHH").ToString()));

            }
            if(dsChitietHd.DataSource!=null)
            {
                if (XtraMessageBox.Show("Bạn có muốn Xóa ", "Đồng Ý Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mahh = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAHH").ToString();
                    
                    hdxuat.xoa1chitiethoadon(mahh,txtMaHDXuat.Text);
                    loaddulieuhoadonxuat(txtMaHDXuat.Text);
                    loadhoadon();
                   // loadhoadon();
                    XtraMessageBox.Show("Thành công");
                }
            }
        }

        private void btnTaoPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                txtMaHDXuat.Text = "HDX001";
            }
            else
            {
                txtMaHDXuat.Text = hdxuat.getmaHoadonxuat();
            }
            txtNgaySinh.EditValue = DateTime.Now;
            Menuxoaphieuxuat.Enabled = false;
            MenuLuuPhieunhap.Enabled = true;
            

            add = true;
            update = false;
           
            

        }

      
        

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gridView3.RowCount<0)
            {
                return;
            }

            
            var donvi = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "DonViTinh");
            if (donvi==null)
            {
                return;
            }
            string soluongton = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "SoLuong").ToString();
            txtSoLuongKho.Text = soluongton;
           txtDonVi.Text = donvi.ToString();

           // txtDonVi.DataBindings.Clear();
          //  txtDonVi.DataBindings.Add("Text", cboHangHoa.Properties.DataSource, "DonViTinh");
        }

        private void g(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {

        }
        public void databinds()
        {

           
            

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (gridView1.RowCount > 0)
            {
                if(add)
                {
                    return;

                }
                if(update)
                {
                    return;

                }
                    
                        
                txtMaHDXuat.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAHD_Xuat").ToString();
                txtNgaySinh.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayLap_Xuat");
                loaddulieuhoadonxuat(txtMaHDXuat.Text);
              
                tinhtrang2= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TinhTrangXuat").ToString();
                if(tinhtrang2=="Đang giao dịch")
                {
                    txtTongtien.DataBindings.Clear();
                    txtTongtien.DataBindings.Add("Text",dshoadonhap.DataSource,"TongTien");
                }
                
                


                //  binds ten khach hang
                for (int i = 0; i < kh.loadallkh().Count; i++)
                {
                    var ds = cboKhachHang.Properties.GetKeyValue(i);
                      var ds2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAKH");
                    if (ds2 == null)
                    {
                        return;
                    }
                    if (ds == null)
                    {
                        return;
                    }
                    if (ds.ToString() == ds2.ToString())
                    {
                        cboKhachHang.EditValue = cboKhachHang.Properties.GetKeyValue(i);
                        return;
                    }
                }
               // bind ngaylap



            }
        }

        private void btnTaoPhieuXuat_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void barDockingMenuItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string mahdxuat = txtMaHDXuat.Text;
            string makh = cboKhachHang.EditValue.ToString();
            // DateTime ngaylap =DateTime.Parse(txtNgaySinh.EditValue.ToString());
            string manv = Login.manv;

            int ngay = txtNgaySinh.DateTime.Day, thang = txtNgaySinh.DateTime.Month, nam = txtNgaySinh.DateTime.Year;

            DateTime ngaylap = DateTime.Parse(ngay+"/"+thang+"/"+nam);
            


            if (add)
            {
                if (XtraMessageBox.Show("Bạn có muốn Thêm ", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    hdxuat.them1HoaDonXuat(mahdxuat, makh, manv, ngaylap, tinhtrang,0);
                    load_hoadonxuat(sender, e);
                    XtraMessageBox.Show("Thành công");
                }

            }
            if (update)
            {
                if (XtraMessageBox.Show("Bạn có muốn Thêm ", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    hdxuat.sua1hopdonxuat(txtMaHDXuat.Text,DateTime.Parse(txtNgaySinh.EditValue.ToString()), cboKhachHang.EditValue.ToString());
                    load_hoadonxuat(sender, e);
                    XtraMessageBox.Show("Thành công");
                }
            }
                
        }
        List<Chitiethoadonxuattam> lsttam = new List<Chitiethoadonxuattam>();
        private void btnThem_Click(object sender, EventArgs e)
        {
            add2 = true;
            update2 = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            databindchitiet(false);
            


            if (txtSoLuong.Text.Length <= 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập số lượng");
                return;
            }
            if (txtGiaNhap.Text.Length <= 0)
            {
                XtraMessageBox.Show("Bạn chưa giá nhập");
                return;
            }
            int soluong = int.Parse(txtSoLuong.Text);
            int tonkho = int.Parse(txtSoLuongKho.Text);
            if(soluong>tonkho)
            {
                XtraMessageBox.Show("Số lượng vượt số lượng kho");
                return;
            }
            
                Chitiethoadonxuattam ct = new Chitiethoadonxuattam();
                ct.MAHD_Xuat = txtMaHDXuat.Text;
                ct.MaHH = cboHangHoa.EditValue.ToString();
                 ct.TenHH = tenhhtam;
                ct.DonGia_Xuat = double.Parse(txtGiaNhap.Text);
                ct.SoLuong_Xuat = int.Parse(txtSoLuong.Text);
                ct.ThanhTienXuat = long.Parse(txtThanhTien.Text);
                ct.DonVi = txtDonVi.Text;
                ct.Vat = vat;
                int s = 1;
                if (lsttam.Count == 0)
                {
                    s = 1;
                }
                else
                {
                    for (int i = 0; i < lsttam.Count; i++)
                    {
                        if (tenhhtam == lsttam[i].TenHH)
                        {
                            s++;
                        }
                    }
                }
                if (s == 1)
                {

                int soluongkho = int.Parse(txtSoLuongKho.Text);

                if(soluongkho==0)
                {
                    XtraMessageBox.Show("Hết hàng");
                    return;
                }

                    lsttam.Add(ct);

                    loadtam();
                }
            

        }

        private void loadtam()
        {
            dsChitietHd.DataSource = "";
            dsChitietHd.DataSource = lsttam;
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
        }

        private void cboHangHoa_EditValueChanged(object sender, EventArgs e)
        {

            if (gridView3.RowCount > 0)
            {

              //  List<Kho> lst = new List<Kho>();
              // /lst = hh.loadsoluongtonkho(cboHangHoa.EditValue.ToString());
               // txtSoLuongKho.Text = lst[0].SoLuong.ToString();
                txtGiaNhap.Text = hh.loadgiaban(cboHangHoa.EditValue.ToString());
                object tenhhhienthi = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "TenHH").ToString();
                if (tenhhhienthi == null)
                {
                    return;
                }
                tenhhtam = tenhhhienthi.ToString();
                
            }

           
        }

      public void databindchitiet(bool t)
        {
            if(t)
            {
                txtSoLuong.DataBindings.Clear();
                txtSoLuong.DataBindings.Add("Text",dsChitietHd.DataSource,"SoLuong_Xuat");
                txtDonVi.DataBindings.Clear();
                txtDonVi.DataBindings.Add("Text",dsChitietHd.DataSource,"DonVi"); 
                
                txtGiaNhap.DataBindings.Clear();
                txtGiaNhap.DataBindings.Add("Text",dsChitietHd.DataSource,"DonGia_Xuat");
            }
            else
            {
                txtDonVi.DataBindings.Clear();
                txtSoLuong.DataBindings.Clear();
                txtGiaNhap.DataBindings.Clear();
            }
        }
   

      

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

           
         

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update2 = true;
            add2 = false;
        }

        private void gridView2_RowCountChanged(object sender, EventArgs e)
        {

        }

        private void btnXoaNhap_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void btnXoaNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa hóa đơn", "Đồng Ý Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


             


                hdxuat.xoa1chitethoadonall(txtMaHDXuat.Text);
                hdxuat.xoa1HoadonNhap(txtMaHDXuat.Text);
                loaddulieuhoadonxuat(txtMaHDXuat.Text);
                loadhoadon();
                XtraMessageBox.Show("Thành công");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            load_hoadonxuat(sender,e);
        }

        private void txtBoxSo1_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length <= 0 || txtGiaNhap.Text.Length <= 0)
            {
                return;
            }
            else
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * double.Parse(txtGiaNhap.Text) * (1 - vat)).ToString();
        }

        private void txtGiaNhap_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length <= 0 || txtGiaNhap.Text.Length <= 0)
            {
                return;
            }
            else
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * double.Parse(txtGiaNhap.Text) * (1 - vat)).ToString();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            update2 = true;
            add2 = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            databindchitiet(false);
          
        }

        private void btnXoaNhap_ListItemClick_1(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void btnXoaNhap_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                hdxuat.xoa1chitethoadonall(txtMaHDXuat.Text);
                hdxuat.xoa1HoadonNhap(txtMaHDXuat.Text);
                load_hoadonxuat(sender, e);
                XtraMessageBox.Show("Thành công");
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if(gridView1.RowCount<=0)
            {
                XtraMessageBox.Show("Chưa có hóa đơn nào");
                return;
                
            }
            if(gridView2.RowCount<=0)
            {
                XtraMessageBox.Show("Chưa mua hàng hóa nào");
                return;
               

            }

            string ngaylap= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayLap_Xuat").ToString();
            DateTime ngaylaphoadon = DateTime.Parse(ngaylap);
            

           
            ChiTietHDXuat2 rpt = new ChiTietHDXuat2(ngaylaphoadon.Day.ToString(),ngaylaphoadon.Month.ToString(),ngaylaphoadon.Year.ToString());

            rpt.DataSource = hdxuat.loadchitiethdxuat(txtMaHDXuat.Text);
            ReportPrintTool tool = new ReportPrintTool(rpt);
            tool.ShowPreview();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            long tongtien;
           if(cboThue.SelectedText=="5%")
            {
                vat = 5;
                tongtien = (long)(long.Parse(txtTongtien.Text) * (1 - 0.05));
                txtTongtien.Text = tongtien.ToString();
            }
           else
            {
                vat = 10;
                tongtien = (long)(long.Parse(txtTongtien.Text) * (1 - 0.1));
                txtTongtien.Text = tongtien.ToString();
            }
        }

        private void btnHuyBo_Click_1(object sender, EventArgs e)
        {
            load_hoadonxuat(sender, e);
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            menuThemPhieuxuat.Enabled = false;
            Menuxoaphieuxuat.Enabled = false;
            MenuLuuPhieunhap.Enabled = true;
            MenuSuaphieuxuat.Enabled = false;
          //  MenuXoa.Enabled = false;
            add = false;
            update = true;
          
        }

        private void txtKhachDua_EditValueChanged(object sender, EventArgs e)
        {
            if(txtKhachDua.Text.Length<=0)
            {
                return;
            }
            long tienkhanhdua;
            tienkhanhdua=long.Parse(txtKhachDua.Text)-long.Parse(txtTongtien.Text);
            if(tienkhanhdua!=0)
            {
                txtTienThua.Text = tienkhanhdua.ToString();
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {

           
            
            long tongtienxuat =long.Parse(txtTongtien.Text);

            DateTime ngaylap = (DateTime)txtNgaySinh.EditValue;
            if(tinhtrang2=="Đang giao dịch")

            {
                if(txtKhachDua.Text.Length<=0)
                {
                    XtraMessageBox.Show("Tiền khách cần đưa");
                    return;
                }
                long tientra = long.Parse(txtKhachDua.Text);
                if(tientra<tongtienxuat)
                {
                    XtraMessageBox.Show("Không được nhập số tiền trả nhỏ hơn mức cần thanh toán");
                    return;
                }

                if (XtraMessageBox.Show("Bạn có muốn thanh toán hóa đơn này", "Đồng Ý Thanh Toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (pt.loadphieuthulist().Count <= 0)
                    {
                        pt.them1phieuthu("PT001", "Khách Hàng", "Đã Thanh Toán", Login.manv, tongtienxuat, ngaylap, "Bán Hàng");
                    }
                    else
                        pt.them1phieuthu(pt.getmaphieuthu(), "Khách Hàng", "Đã Thanh Toán", Login.manv, tongtienxuat, ngaylap, "Bán Hàng");
                    hdxuat.sua1hoadonnhapxuat(txtMaHDXuat.Text);

                    load_hoadonxuat(sender, e);
                    MessageBox.Show("Thanh toán thành công");
                }
            }
            
            
         
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (add2 )
            {
                if (hdxuat.kiemtracohoadonxuat(txtMaHDXuat.Text).Count <= 0)
                {


                    if (XtraMessageBox.Show("Bạn có muốn Thêm", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (lsttam.Count > 0)
                        {
                            for (int i = 0; i < lsttam.Count; i++)
                            {
                                hdxuat.them1chitiethoadonxuat(lsttam[i].MAHD_Xuat, lsttam[i].MaHH, lsttam[i].SoLuong_Xuat, lsttam[i].DonGia_Xuat, lsttam[i].ThanhTienXuat, lsttam[i].Vat, lsttam[i].DonVi);
                            }

                            lsttam.Clear();
                        }

                        load_hoadonxuat(sender, e);
                        XtraMessageBox.Show("Thành công");
                    }
                }else
                {
                    XtraMessageBox.Show("Không được thêm");
                }

            }
           
            if(update2)
            {
                if (XtraMessageBox.Show("Bạn có muốn sửa", "Đồng Ý sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    string mahh = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAHH").ToString();
                    int soluong = int.Parse(txtSoLuong.Text);
                    double giaxuat = double.Parse(txtGiaNhap.Text);
                    long thanhtienxuat = long.Parse(txtThanhTien.Text);
                    float vat = 0;
                    string donvi = txtDonVi.Text;
                    hdxuat.sua1chitiethoadonxuat(txtMaHDXuat.Text,mahh, soluong, thanhtienxuat, giaxuat);
                    loaddulieuhoadonxuat(txtMaHDXuat.Text);
                    loadhanghoa();
                    XtraMessageBox.Show("Thành công");
                }
            }


        }

        private void barDockingMenuItem5_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            
        }

       
         public void seteditValuebyindex()
            {
                var ds = cboHangHoa.Properties.GetKeyValue(0);
                cboHangHoa.EditValue = ds;
                var ds2 = cboKhachHang.Properties.GetKeyValue(0);
                cboKhachHang.EditValue = ds2;
            }

        private void HoaDonXuat_VisibleChanged(object sender, EventArgs e)
        {
            load_hoadonxuat(sender, e);
        }




    }
}
