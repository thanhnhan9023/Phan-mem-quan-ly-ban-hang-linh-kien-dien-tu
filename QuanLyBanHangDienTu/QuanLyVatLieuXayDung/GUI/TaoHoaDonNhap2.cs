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
using QuanLyVatLieuXayDung.Report;
using DevExpress.XtraReports.UI;


namespace QuanLyVatLieuXayDung.GUI
{
    public partial class TaoHoaDonNhap2 : DevExpress.XtraEditors.XtraUserControl


    {
        bool add = false, update = false, update2 = false, add2 = false;
        HoaDonNhapDALL_BALL hdnhap = new HoaDonNhapDALL_BALL();
        DALL_BALL_HangHoa hanghoa = new DALL_BALL_HangHoa();
        DALL_BALL_NhaCungCap ncc = new DALL_BALL_NhaCungCap();
        DALl_BALl_Phieuchics pc = new DALl_BALl_Phieuchics();
        DALL_BALl_Khocs kh = new DALL_BALl_Khocs();
        double vat;
        string tenhhtam, tinhtrang, nhacc;
        string mahh = "";

        public static int xacnhandon = 0;
        public TaoHoaDonNhap2()
        {
            InitializeComponent();

        }
        public void hoadonnhap_load(object sender, EventArgs e)
        {
            // loadgiaodien
            txtMaHDNhap.Enabled = false;
            txtThanhTien.Enabled = false;
            txtDonVi.Enabled = false;
            txtTongTien.Enabled = false;
            txtTiencantra.Enabled = true;
            MenuLuu.Enabled = false;
            MenuXoa.Enabled = true;
          //  txtDonGiaNhap.Enabled = false;
            MenuSua.Enabled = true;
            MenuNhapkho.Enabled = true;
            update = false;
            add = false;
            // hienthi(false);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            // load combox
            loadhoandon();
            loadhanghoa();
            loanghandnhacc();
            txtTenNv.Text = Login.tennv;
            txtTenNv.Enabled = false;
            datatbinds(true);
            seteditValuebyindex();
          
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();

            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView2.OptionsView.BestFitMaxRowCount = -1;
            gridView2.BestFitColumns();
            if (gridView1.RowCount <= 0)
            {
                dschitiethoadon.DataSource = null;
            }
        }
        public void loadhoandon()
        {
            dshoadonhap.DataSource = hdnhap.loadhoadonhap2(Login.manv);
        }
        public void hienthi(bool t)
        {


        }

        private void loadhanghoa()
        {
            cboHangHoa.Properties.DataSource = hanghoa.loadkho();
            cboHangHoa.Properties.DisplayMember = "TenHH";
            cboHangHoa.Properties.ValueMember = "MaHH";


        }
        public void loanghandnhacc()
        {
            cboNCC.Properties.DataSource = ncc.loaddataNCC();
            cboNCC.Properties.DisplayMember = "TenNCC";
            cboNCC.Properties.ValueMember = "MaNC";

        }
        private void labelControl2_Click(object sender, EventArgs e)
        {

            txtTenNv.Text = "";


        }



        private void barDockingMenuItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)

            {
                txtMaHDNhap.Text = "HDN001";
            }
            else
                txtMaHDNhap.Text = hdnhap.getmatudongtanhdnhap();

            hienthi(true);
            add = true;
            update = false;
            MenuLuu.Enabled = true;
            MenuXoa.Enabled = false;
            MenuSua.Enabled = false;
            MenuNhapkho.Enabled = false;
            txtTongTien.Text = "";
            datatbinds(false);
            dateNgayLapHoaDon.Value = DateTime.Now;


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // txtDonGiaNhap.Text = hdnhap.getmatudongtanhdnhap();
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {


            if (update)
            {
                return;
            }
            if (add)
            {
                return;
            }
            loanghandnhacc();
            if (gridView1.RowCount <= 0)
            {
                return;
            }
            txtMaHDNhap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAHD_Nhap").ToString();
            //string mhd = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAHD_Nhap").ToString();

            loadchitiethoadon(txtMaHDNhap.Text);



            object mancc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNC").ToString();
            if (mancc == null)
            {
                return;
            }
            nhacc = mancc.ToString();
            //object tongtien2= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TongTien").ToString();
            //if(tongtien2==null)
            //{
            //    return;
            //}
            object tinhtrang2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TinhTrangNhap").ToString();

            if (tinhtrang2 == null)
            {
                return;
            }
            tinhtrang = tinhtrang2.ToString();
            if (tinhtrang == "Đang giao dịch")
            {
                txtTiencantra.DataBindings.Clear();
                txtTiencantra.DataBindings.Add("Text", dshoadonhap.DataSource, "TongTien");
            }
            else
            {
                txtTiencantra.Text = "";
            }

            //  txtTongTien.Text = tongtien2.ToString();
            //txtTiencantra.Text = tongtien2.ToString();

            //tongtien = long.Parse(tongtien2.ToString());


            for (int i = 0; i < ncc.loadnhacclist().Count; i++)
            {
                var ds = cboNCC.Properties.GetKeyValue(i);
                var ds2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNC").ToString();
                if (ds.ToString() == ds2.ToString())
                {
                    cboNCC.EditValue = cboNCC.Properties.GetKeyValue(i);
                    return;
                }
            }




        }


        private void barDockingMenuItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                XtraMessageBox.Show("Không có hóa đơn nhập nào");
                return;
            }
            if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                hdnhap.xoa1chitiethoadon(txtMaHDNhap.Text);
                hdnhap.xoanhd(txtMaHDNhap.Text);

                hoadonnhap_load(sender, e);
                if (gridView1.RowCount <= 0)
                {
                    dschitiethoadon.DataSource = "";
                }
                XtraMessageBox.Show("Thành công");
            }


        }

        private void barDockingMenuItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string MAHD_Nhap = txtMaHDNhap.Text;
            DateTime NgayLapHD = dateNgayLapHoaDon.Value;
            string manv = Login.manv;
            string MaNC = cboNCC.EditValue.ToString();
            //chi tiet hoa don
            string MAHH;
            MAHH = cboHangHoa.EditValue.ToString();
            // so luong nhap

            string DonVi = txtDonVi.Text;

            string TinhTrangNhap = "Đang giao dịch";



            if (add)
            {

                if (XtraMessageBox.Show("Bạn có muốn thêm  1 phiếu nhập mới không", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    hdnhap.them1hoadonhap(MAHD_Nhap, MaNC, manv, NgayLapHD, TinhTrangNhap, 0, "Chưa nhập kho");

                    hoadonnhap_load(sender, e);

                    XtraMessageBox.Show("Thêm Thành Công");
                }

            }
            if (update)
            {
                if (gridView1.RowCount <= 0)
                {
                    XtraMessageBox.Show("Không tồn tại phiếu nhập nào");
                    return;
                }

                if (XtraMessageBox.Show("Bạn có muốn thêm  1 phiếu nhập mới không", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    hdnhap.sua1hoadonnhap(txtMaHDNhap.Text, cboNCC.EditValue.ToString(), Login.manv, dateNgayLapHoaDon.Value);

                    hoadonnhap_load(sender, e);
                    XtraMessageBox.Show("Sửa Thành Công");


                }
            }



        }
        public void databinds2()
        {


        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (gridView2.RowCount > 0)
            {

                txtSoLuong.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SoLuong_Nhap").ToString();
                txtDonGiaNhap.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DonGia_Nhap").ToString();

                object mah = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAHH");


                if (mah == null)
                    return;
                mahh = mah.ToString();


                // cboThue.SelectedText = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Vat").ToString() + "%";
            }



        }

        public void loadthe()
        {
            List<String> lits = new List<string>();
            lits.Add("5%");
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            cboNCC.EditValue = cboNCC.Properties.GetKeyValue(0);

        }



        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView3.RowCount > 0)
            {
                txtDonVi.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "DonViTinh").ToString();
                tenhhtam = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "TenHH").ToString();
                txtSoLuong.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "SoLuong").ToString();
                txtDonGiaNhap.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Gianhap").ToString();
            }
        }





        private void txtDonGiaNhap_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length <= 0 || txtDonGiaNhap.Text.Length <= 0)
            {
                return;
            }
            else
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * double.Parse(txtDonGiaNhap.Text) * (1 - vat)).ToString();
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length <= 0 || txtDonGiaNhap.Text.Length <= 0)
            {
                return;
            }
            else
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * double.Parse(txtDonGiaNhap.Text)).ToString();
        }

        private void cboVat_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboThue.SelectedIndex == 0)
            {
                vat = 5;
            }
            else
                vat = 10;

        }

        private void barDockingMenuItem4_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }
        // sua chitiethoadon
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            update2 = true;
            btnSua.Enabled = false;
            hienthi(true);
            add2 = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
           
            


        }

        public void datatbinds(bool t)
        {

            if (t)
            {

                dateNgayLapHoaDon.DataBindings.Clear();
                dateNgayLapHoaDon.DataBindings.Add("Text", dshoadonhap.DataSource, "NgayLapHD");
                txtTongTien.DataBindings.Clear();
                txtTongTien.DataBindings.Add("Text", dshoadonhap.DataSource, "TongTien");




            }
            else
            {
                txtTongTien.DataBindings.Clear();
                dateNgayLapHoaDon.DataBindings.Clear();


            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            hoadonnhap_load(sender, e);
        }
        public void loadchitiethoadon(string mahd)
        {

            dschitiethoadon.DataSource = hdnhap.loadhoadonhapchitiet(mahd);
            if (gridView2.RowCount <= 0)
            {
                txtSoLuong.Text = "";
                txtDonGiaNhap.Text = "";
            }
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                hdnhap.xoachitiethoadonnhap(mahh);
                loadchitiethoadon(txtMaHDNhap.Text);
                loadhoandon();
                XtraMessageBox.Show("Thành công");
            }
        }

        private void barDockingMenuItem5_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        List<Chitiethoadontamcs> lst = new List<Chitiethoadontamcs>();
        public void loadtam()
        {
            dschitiethoadon.DataSource = "";
            dschitiethoadon.DataSource = lst;
            txtSoLuong.Text = "";
            //    txtDonGiaNhap.Text = "";
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void barDockingMenuItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void cboThue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }


        private void gridLookUpEdit1View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void cboNCC_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void griviewlockup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ngay = DateTime.Now.Day.ToString();
            string thang = DateTime.Now.Month.ToString();
            string nam = DateTime.Now.Year.ToString();
            RptInChiTietHDNhap rpt = new RptInChiTietHDNhap(ngay, nam, thang);
            List<ChiTietHD_Nhap> lst = hdnhap.loadhoadonchitiet(txtMaHDNhap.Text);
            rpt.DataSource = lst;
            ReportPrintTool tool = new ReportPrintTool(rpt);
            tool.ShowPreview();
        }

        private void txtTientra_EditValueChanged(object sender, EventArgs e)
        {
            long a = long.Parse(txtTiencantra.Text);
            if (txtTientra.Text.Length > 0)
            {

                long tientra = long.Parse(txtTientra.Text);
                if (tientra >= a) ;
                {

                    txtTienThua.Text = (tientra - a).ToString();
                }
            }
        }

        private void cboHangHoa_EditValueChanged(object sender, EventArgs e)
        {
            txtDonGiaNhap.Text = hanghoa.loadgianhap(cboHangHoa.EditValue.ToString());
        }

        private void dschitiethoadon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void ckNhapkho_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void barCheckItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (hdnhap.loadhoadonchitiet(txtMaHDNhap.Text).Count <= 0)
            {
                XtraMessageBox.Show("Hóa đơn này không có đơn hàng nào để nhập kho");
                return;

            }
            if (XtraMessageBox.Show("Bạn có muốn thanh toán hóa đơn này", "Đồng Ý Thanh Toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> lst = new List<string>();
                lst = hdnhap.loadmahhtheohdnhap(txtMaHDNhap.Text);
                foreach (string item in lst)
                {
                    kh.updatekho(item, txtMaHDNhap.Text);
                }

                hdnhap.updatetinhtrangnhapkho(txtMaHDNhap.Text, "Đã Nhập Kho");
                hoadonnhap_load(sender, e);

                XtraMessageBox.Show("Nhập Kho Thành Công");

            }
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MenuLuu.Enabled = true;
            MenuThem.Enabled = false;
            MenuNhapkho.Enabled = false;
            MenuSua.Enabled = false;
            MenuXoa.Enabled = false;
            add = false;
            update = true;
            datatbinds(false);


        }

        private void MenuNhapkho_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    

        private void TaoHoaDonNhap2_VisibleChanged(object sender, EventArgs e)
        {
            hoadonnhap_load(sender, e);
        }



        private void btnThanhToan_Click(object sender, EventArgs e)
        {


            long tongtien = long.Parse(txtTiencantra.Text);

            if (tinhtrang == "Đang giao dịch")
            {

                if (txtTientra.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Can nhập tiền trả");
                    return;
                }

                long tientra = long.Parse(txtTientra.Text);
                if (tientra < tongtien)
                {
                    XtraMessageBox.Show("Tiền trả nhỏ hơn tổng tiền hóa đơn");
                    return;
                }
              
                if (XtraMessageBox.Show("Bạn có muốn thanh toán hóa đơn này", "Đồng Ý Thanh Toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (pc.loadphieuchilist().Count <= 0)
                    {
                        pc.them1phieuchi("PC001", Login.manv, "Nhà Cung Cấp", dateNgayLapHoaDon.Value, "Đã Thanh Toán", tongtien, "Đã Thanh Toán");
                    }
                    else
                    {
                        pc.them1phieuchi(pc.getmaphieuthu(), Login.manv, "Nhà Cung Cấp", dateNgayLapHoaDon.Value, "Đã Thanh Toán",
                          tongtien, "Đã Thanh Toán");
                    }
                    hdnhap.updatehoadonhapkhithanhtoan(txtMaHDNhap.Text, "Đã Thanh Toán", 0);
                    ncc.updatenhacckhithanthoan(nhacc);
                    loadhoandon();
                    XtraMessageBox.Show("Hoàn Thành Thanh Toán");
                }
            }



            //DateTime ngaylap = DateTime.Parse(dateNgayLapHoaDon.Value.ToString());
            //pc.them1phieuchi("",null,"Nhà Cung Cấp",ngaylap,"Đã Thanh Toán",tongtien);
            //xacnhandon = 1;
            //XtraMessageBox.Show("Hoàn Thành Thanh Toán");



        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            add2 = true;
            update2 = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;


            string mahd = txtMaHDNhap.Text;
            //chi tiet hoa don


            // so luong nhap
            int SoLuong_Nhap1;
            if (txtSoLuong.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập só lượng");
                return;
            }
            else
            {
                SoLuong_Nhap1 = int.Parse(txtSoLuong.Text);
            }
            // đơn giá nhập
            float DonGia_Nhap;
            if (txtDonGiaNhap.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập đơn giá nhập");
                return;
            }

            else
            {
                DonGia_Nhap = float.Parse(txtDonGiaNhap.Text);
            }

            // thanh tien
            double Thanhtien;
            if (txtThanhTien.Text.Length == 0)
            {
                return;
            }
            else
            {
                Thanhtien = double.Parse(txtThanhTien.Text);
            }

            string DonVi1 = txtDonVi.Text;


            if (SoLuong_Nhap1 == 0)
            {
                XtraMessageBox.Show("Số lượng lớn hơn không");
                return;
            }
            if (DonGia_Nhap == 0)
            {
                XtraMessageBox.Show("Đơn giá nhập lớn hơn không");
                return;
            }


            Chitiethoadontamcs ct = new Chitiethoadontamcs();
            ct.MAHD_Nhap = txtMaHDNhap.Text;
            ct.MaHH = cboHangHoa.EditValue.ToString();
            ct.TenHH = tenhhtam;
            ct.DonGia_Nhap = DonGia_Nhap;
            ct.SoLuong_Nhap = SoLuong_Nhap1;
            ct.Thanhtien = Thanhtien;
            ct.DonVi = DonVi1;
            ct.Vat = vat;
            int s = 1;
            if (lst.Count == 0)
            {
                s = 1;
            }
            else
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    if (tenhhtam == lst[i].TenHH)
                    {
                        s++;
                    }
                }
            }
            if (s == 1)
            {
                lst.Add(ct);

                loadtam();
            }





        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {



            if (add2)
            {

                if (hdnhap.kiemtradulieuhoadonnhap(txtMaHDNhap.Text).Count <= 0)
                {



                    if (XtraMessageBox.Show("Bạn có muốn Thêm", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (lst.Count > 0)
                        {
                            for (int i = 0; i < lst.Count; i++)
                            {
                                hdnhap.them1chitiethoadon(lst[i].MAHD_Nhap, lst[i].MaHH, lst[i].SoLuong_Nhap, lst[i].DonGia_Nhap, lst[i].Thanhtien, lst[i].DonVi, lst[i].Vat);

                                // loadchitiethoadon(mahd);
                            }
                            lst.Clear();
                        }

                        loadchitiethoadon(txtMaHDNhap.Text);
                        loadhoandon();
                        XtraMessageBox.Show("Thành công");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không được thêm");
                }


            }
            if (update2)
            {
                string mahd = txtMaHDNhap.Text;
                //chi tiet hoa don
                string MAHH;
                MAHH = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAHH").ToString();
                // so luong nhap
                int SoLuong_Nhap;
                if (txtSoLuong.Text.Length == 0)
                {
                    return;
                }
                else
                {
                    SoLuong_Nhap = int.Parse(txtSoLuong.Text);
                }
                // đơn giá nhập
                float DonGia_Nhap;
                if (txtDonGiaNhap.Text.Length == 0)
                {
                    return;
                }

                else
                {
                    DonGia_Nhap = float.Parse(txtDonGiaNhap.Text);
                }

                // thanh tien
                double Thanhtien;
                if (txtThanhTien.Text.Length == 0)
                {
                    return;
                }
                else
                {
                    Thanhtien = double.Parse(txtThanhTien.Text);
                }

                string DonVi = txtDonVi.Text;


                string TinhTrangNhap;

                if (XtraMessageBox.Show("Bạn có muốn Sửa", "Đồng Ý Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    hdnhap.sua1chitiethoadon(mahd, MAHH, SoLuong_Nhap, DonGia_Nhap, Thanhtien, DonVi, vat);
                    loadchitiethoadon(mahd);

                    XtraMessageBox.Show("Thành công");
                }

            }
        }

        public void seteditValuebyindex()
        {
            var ds = cboNCC.Properties.GetKeyValue(0);
            cboNCC.EditValue = ds;
            var ds2 = cboHangHoa.Properties.GetKeyValue(0);
            cboHangHoa.EditValue = ds2;
        }
    
    }

}
