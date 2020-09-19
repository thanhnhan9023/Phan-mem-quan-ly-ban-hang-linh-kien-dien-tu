using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DALL_BALL;
using Excel = Microsoft.Office.Interop.Excel;
using DALL_BALL.DTO;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class cnNhanVien : UserControl
    {

        DALL_BALL_NhanVien nm = new DALL_BALL_NhanVien();
        DALL_BALL_Hoadonxuat hdxuat = new DALL_BALL_Hoadonxuat();
        HoaDonNhapDALL_BALL hdnhap = new HoaDonNhapDALL_BALL();
        DALL_QuantriNguoiDung qtngd = new DALL_QuantriNguoiDung();
        bool add = false, update = false ;
        string tinhtrang = "";
        


        //Lấy Thông tin Thể loại


        public cnNhanVien()
        {
            InitializeComponent();
        }
        public void loaddulieunv()
        {
            dsNhanVien.DataSource = nm.loaddulieuNhanVien();
        }
        public void loadcomboxgioitinh()
        {

        }

        public void hienthi(bool t)
        {
            if (t)
            {
                txtMaNV.Enabled = false;
                txtSdt.Enabled = false;
                dateNgaySinh.Enabled = false;
                txtDiaChi.Enabled = false;
                ckTrangthai.Enabled = false;
                txtHoTenNV.Enabled = false;
                dateNgayVaoLam.Enabled = false;
                btnLuu.Enabled = false;

            }
            else
            {


                txtSdt.Enabled = true;
                dateNgaySinh.Enabled = true;
                txtDiaChi.Enabled = true;
                ckTrangthai.Enabled = true;
                txtHoTenNV.Enabled = true;
                dateNgayVaoLam.Enabled = true;
                btnLuu.Enabled = true;

            }
        }
        public void loadcomboxchucvu()
        {
            cboChuVu.DataSource = nm.LoadChucVu();
            cboChuVu.DisplayMember = "Tencv";
            cboChuVu.ValueMember = "Macv";
        }

        private void ckTrangthai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTrangthai.Checked)
            {
                tinhtrang = "Còn Làm";
            }
            else
                tinhtrang = "Nghĩ Việc";
        }
        public void binds(bool t)

        {
            if (t)
            {
                txtMaNV.DataBindings.Clear();
                txtMaNV.DataBindings.Add("Text", dsNhanVien.DataSource, "MANV");
                txtHoTenNV.DataBindings.Clear();
                txtHoTenNV.DataBindings.Add("Text", dsNhanVien.DataSource, "TenNV");
                cboGioiTinh.DataBindings.Clear();
                cboGioiTinh.DataBindings.Add("Text", dsNhanVien.DataSource, "GioiTinh");
                dateNgaySinh.DataBindings.Clear();
                dateNgaySinh.DataBindings.Add("Text", dsNhanVien.DataSource, "NgaySinh");
                cboChuVu.DataBindings.Clear();
                cboChuVu.DataBindings.Add("Text", dsNhanVien.DataSource, "TenCv");
                dateNgayVaoLam.DataBindings.Clear();
                dateNgayVaoLam.DataBindings.Add("Text", dsNhanVien.DataSource, "NgayVaoLam");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", dsNhanVien.DataSource, "DiaChi");
                txtSdt.DataBindings.Clear();
                txtSdt.DataBindings.Add("Text", dsNhanVien.DataSource, "SDT");
            }
            else
            {
                txtMaNV.DataBindings.Clear();
                txtHoTenNV.DataBindings.Clear();
                cboGioiTinh.DataBindings.Clear();
                dateNgaySinh.DataBindings.Clear();
                txtDiaChi.DataBindings.Clear();
                txtSdt.DataBindings.Clear();
                cboChuVu.DataBindings.Clear();

            }




        }
        public void resetValues()
        {


            txtSdt.Text = "";
            cboGioiTinh.SelectedIndex = 0;
            cboChuVu.SelectedIndex = 0;
            txtHoTenNV.Text = "";
            txtMaNV.Text = "";
            txtDiaChi.Text = "";

            dateNgayVaoLam.EditValue = DateTime.Now.ToShortDateString();

        }
        public bool kiemtradulieuhop()
        {
            if (txtHoTenNV.Text == string.Empty)
            {
                XtraMessageBox.Show("Tên Nhân Viên Không Để Trống");
                return false;
            }
            if (txtDiaChi.Text == string.Empty)
            {
                XtraMessageBox.Show("Địa Chỉ Không Để Trống");
                return false;
            }
            if (txtSdt.Text == string.Empty)
            {

                XtraMessageBox.Show("Số Điện Thoại Không Để Trống");
                return false;
            }
            if (!kiemtrasso(txtSdt.Text))
            {
                XtraMessageBox.Show("Nhập Số Cho Thông Tin Điện Thoại");
                return false;
            }
            return true;
        }
        public bool kiemtrasso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x, out a);
            if (t)
            {
                return true;
            }
            else
                return false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {

            DateTime ns = DateTime.Parse(dateNgaySinh.EditValue.ToString());
            DateTime nvl = DateTime.Parse(dateNgaySinh.EditValue.ToString());
            if (add)
            {
                if (kiemtradulieuhop())
                {

                    if (XtraMessageBox.Show("Bạn có muốn  thêm  nhân viên này", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        nm.them1NhanVien(txtMaNV.Text, txtHoTenNV.Text,
                        cboGioiTinh.Text, ns,
                        txtDiaChi.Text, txtSdt.Text, nvl,
                        cboChuVu.SelectedValue.ToString(), "Còn Làm");
                        XtraMessageBox.Show("Thêm Thành công");
                        cnNhanVien_Load(sender, e);
                    }

                }

            }
            if (update)
            {
                if (kiemtradulieuhop())
                {

                    if (XtraMessageBox.Show("Bạn có muốn  sửa nhân viên này", "Đồng Ý Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        nm.sua1NhanVien(txtMaNV.Text, txtHoTenNV.Text,
                        cboGioiTinh.Text, ns,
                        txtDiaChi.Text, txtSdt.Text, nvl, cboChuVu.SelectedValue.ToString(), tinhtrang);
                        XtraMessageBox.Show("Sửa Thành công");
                        cnNhanVien_Load(sender, e);
                    }

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            hienthi(false);
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnSua.Enabled = false;
            binds(false);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            cnNhanVien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(gridView1.RowCount<=0)
            {
                XtraMessageBox.Show("Không có nhân viên");
                return;
            }


            if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> dsmahoadonxuat = new List<string>();
                dsmahoadonxuat = nm.mahdxuattheonv(txtMaNV.Text);
                List<string> dsmahoadonnhap = new List<string>();
              
                dsmahoadonnhap = nm.mahdnhaptheonv(txtMaNV.Text);
                for (int i = 0; i < dsmahoadonnhap.Count; i++)
                {
                    hdnhap.xoachitiethoadonnhap(dsmahoadonnhap[i].ToString());
                    hdnhap.xoanhd(dsmahoadonnhap[i].ToString());
                }        
                for (int i = 0; i < dsmahoadonxuat.Count; i++)
                {
                    hdxuat.xoa1chitethoadonall(dsmahoadonxuat[i].ToString());
                    hdxuat.xoa1HoadonNhap(dsmahoadonxuat[i].ToString());
                }
                qtngd.xoa1nguoidungTheoNV(txtMaNV.Text);
                nm.xoa1NhanVien(txtMaNV.Text);
               
                XtraMessageBox.Show("Thành công");
                cnNhanVien_Load(sender, e);
            }
      
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            string manv = gridView1.GetFocusedRowCellValue("MANV").ToString();
            string tennv = gridView1.GetFocusedRowCellValue("TenNV").ToString();
            string gioitinh = gridView1.GetFocusedRowCellValue("GioiTinh").ToString();
            string diachi = gridView1.GetFocusedRowCellValue("DiaChi").ToString();
            string ngayvaolam = gridView1.GetFocusedRowCellValue("NgayVaoLam").ToString();
            string chucvu = gridView1.GetFocusedRowCellValue("TenCv").ToString();
           
         
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Chucvu cv = new Chucvu();
            cv.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if(gridView1.RowCount<=0)
            {
                XtraMessageBox.Show("Không có nhân viên nào");
                return;
            }
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;

            workbook = application.Workbooks.Add(Type.Missing);
            application.Visible = true;
            application.WindowState = Excel.XlWindowState.xlMaximized;
            //getdatabase   
            workbook.Worksheets.Add();
            worksheet = workbook.Sheets[1];

                 worksheet.Cells[1, 1] = "Dach sách nhân viên";
                 worksheet.Cells[3, 1] = "STT";
                 worksheet.Cells[3, 2] = "Mã  nhân viên";
                 worksheet.Cells[3, 3] = "Họ tên viên";
                 worksheet.Cells[3, 4] = "Ngày Sinh";
                 worksheet.Cells[3, 5] = "Địa chỉ";
                 worksheet.Cells[3, 6] = "Số  điện thoại";
                 worksheet.Cells[3, 7] = "Ngày vào làm";
                 worksheet.Cells[3, 8] = "Chức Vụ";
                 worksheet.Cells[3, 9] = "Tình Trạng";
            List<NhanVienDTO> lstnv = new List<NhanVienDTO>();
            lstnv = nm.dsnhanvien();
            for (int i = 0; i < lstnv.Count; i++)
            {
                worksheet.Cells[i+4, 1] = i+1;
                worksheet.Cells[i + 4, 2] = lstnv[i].MANV1;
                worksheet.Cells[i + 4, 3] = lstnv[i].TenNV1;
                worksheet.Cells[i + 4, 4] = lstnv[i].NgaySinh1;
                worksheet.Cells[i + 4, 5] = lstnv[i].DiaChi1;
                worksheet.Cells[i + 4, 6] = lstnv[i].SDT1;
                worksheet.Cells[i + 4, 7] = lstnv[i].NgayVaoLam1;
                worksheet.Cells[i + 4, 8] = lstnv[i].TenCV1;
                worksheet.Cells[i + 4, 9] = lstnv[i].TinhTrang1;
            
            
              

            }


            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            worksheet.PageSetup.TopMargin = 0;

            //định dạng cột

            worksheet.Range["A1", "H3" + lstnv.Count].Font.Name = "Times New Roman";
            worksheet.Range["A1", "H1"].Font.Size = 17;
            worksheet.Range["A1", "H1"].Font.Bold = true;

       
            worksheet.Range["A3", "I3" + lstnv.Count].Font.Name = "Times New Roman";
            worksheet.Range["A3", "I3"].Font.Size = 14;

            worksheet.Range["A1", "I1"].MergeCells = true;
            worksheet.Range["A3", "I3"].Font.Bold = true;
      

            // kẻ bảng nhân viên
            worksheet.Range["A3", "I" + (lstnv.Count + 3)].Borders.LineStyle = 1;


            // định dạng các dòng
            worksheet.Range["A1", "G1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "I3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "I4" + lstnv.Count.ToString()].HorizontalAlignment = 3;
            worksheet.Range["A4", "I4" + lstnv.Count].Font.Size = 12;

            worksheet.Columns.AutoFit();






        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetValues();
            hienthi(false);    
            add = true;
            update = false;
            binds(false);
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            if(gridView1.RowCount<=0)
            {
                txtMaNV.Text = "NV001";
            }
            else
            txtMaNV.Text = nm.getmaNhanVien(txtMaNV.Text);

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gridView1.RowCount>0)
            {
                string s = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TinhTrang").ToString();
                if (s == "Còn Làm")
                {
                    ckTrangthai.Checked = true;
                }
                else
                    ckTrangthai.Checked = false;
            }
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void loadnhanvien_VisibleChanged(object sender, EventArgs e)
        {
            cnNhanVien_Load(sender, e);
           
        }

        private void cnNhanVien_Load(object sender, EventArgs e)
        {
            //Load DataGrid
            loadcomboxgioitinh();
            loadcomboxchucvu();
            loaddulieunv();
            hienthi(true);
            dateNgaySinh.EditValue = DateTime.Now;
            
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnIn.Enabled = true;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
            binds(true);


        }


    }
}
