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
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class KhachHangc : DevExpress.XtraEditors.XtraUserControl
    {
        DALL_BALL_KhachHang kh = new DALL_BALL_KhachHang();
        DALL_BALl_LoaiKhachHang loaikh = new DALL_BALl_LoaiKhachHang();
        DALL_BALL_DonHang dh = new DALL_BALL_DonHang();
        DALL_BALL_PhanQuyencs pq = new DALL_BALL_PhanQuyencs();
        bool add = false, update = false;
        public KhachHangc()
        {
            InitializeComponent();
        }

        public void hienthi(bool t)
        {
            
        }
        public void loadview()
        {
          
            dskhachang.DataSource = kh.getdskhachhang();
             
        }

        private void KhachHangc_Load(object sender, EventArgs e)
        {
            txtMaKhachHang.Enabled = false;


            loadview();
            loadcomboxmaloaikh();
           
            btnLuu.Enabled = false;
        
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
           // bind(true);

            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
            bind(true);
        }

        public void resetvalue()
        {
            txtMaKhachHang.Focus();
            txtMaKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTenKhachHang.Text = "";
            txtTenKhachHang.Focus();

        }
        public void bind(bool t)
        {
            if (t)
            {
                txtMaKhachHang.DataBindings.Clear();
                txtMaKhachHang.DataBindings.Add("Text", dskhachang.DataSource, "MAKH");
                txtTenKhachHang.DataBindings.Clear();
                txtTenKhachHang.DataBindings.Add("Text", dskhachang.DataSource, "TenKH");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text",dskhachang.DataSource, "DiaChi");
                txtSoDienThoai.DataBindings.Clear();
                txtSoDienThoai.DataBindings.Add("Text", dskhachang.DataSource, "SDT");
                cboLoaikh.DataBindings.Clear();
                cboLoaikh.DataBindings.Add("Text", dskhachang.DataSource, "Tenloaikh");
                dateNgaySinh.DataBindings.Clear();
                dateNgaySinh.DataBindings.Add("Text",dskhachang.DataSource,"Ngaysinh");
            }
            else
            {
                txtMaKhachHang.DataBindings.Clear();
                txtTenKhachHang.DataBindings.Clear();
                txtDiaChi.DataBindings.Clear();
                txtSoDienThoai.DataBindings.Clear();
                dateNgaySinh.DataBindings.Clear();
                cboLoaikh.DataBindings.Clear();

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            kh.xoa1khachhang(txtMaKhachHang.Text);
            XtraMessageBox.Show("Thanh Cong");
            KhachHangc_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            hienthi(true);
            txtMaKhachHang.Enabled = false;
            add = false;
            update = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            bind(false);
            btnLuu.Enabled = true;
        }
        public bool kiemtraso(string x)
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
        private void Btnluu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            KhachHangc_Load(sender, e);
        }

        private void txtSoDienThoai_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKhachHang_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemNhomKh_Click(object sender, EventArgs e)
        {
            LoaiKhachHang frm = new LoaiKhachHang();
            frm.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            btnThem.Enabled = false;
            resetvalue();
            hienthi(true);
         

        

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTenKhachHang.Text = "";
            txtTenKhachHang.Focus();
            txtMaKhachHang.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
  
           
           if(gridView1.RowCount<=0)
            {
                txtMaKhachHang.Text = "KH001";

            }
            else
            {
                txtMaKhachHang.Text = kh.getmakhachhang("KH00");
            }
            bind(false);
            add = true;
            update = false;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            hienthi(true);
            //txtMaKhachHang.Enabled = false;
            add = false;
            update = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            bind(false);
        }

 

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
          
            if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> madh = new List<string>();
                madh = kh.getmadh(txtMaKhachHang.Text);
                for (int i = 0; i < madh.Count; i++)
                {
                    dh.deletechitietdh(madh[i].ToString());
                    dh.deletedonhang(madh[i].ToString());
                }
                kh.xoa1userkhachhang(txtMaKhachHang.Text);
                kh.xoa1khachhang(txtMaKhachHang.Text);
                XtraMessageBox.Show("Thanh Cong");
                KhachHangc_Load(sender, e);
            }

         
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {



        }

        private void txtMaKhachHang_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ckNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKhachHang_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_2(object sender, EventArgs e)
        {
            string gioitinh = "";

            if (rdNam.Checked)
            {
                gioitinh = "Nam";
            }
            else
                gioitinh = "Nữ";
            DateTime ngaysinh = DateTime.Parse(dateNgaySinh.EditValue.ToString());
            if (txtTenKhachHang.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Bỏ Trống Tên Khách Hàng");
                return;

            }
            else if (txtSoDienThoai.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Bỏ Trống SĐT");
                return;
            }
            else if (!kiemtraso(txtSoDienThoai.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập số tại mục số điện thoại");
                return;
            }
            if (add)
            {
         


                DialogResult rs;
                rs = XtraMessageBox.Show("Bạn có muốn thêm  không", "Đồng ý thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (rs == DialogResult.Yes)
                {

                    kh.them1khachhang(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSoDienThoai.Text, gioitinh, cboLoaikh.SelectedValue.ToString(), ngaysinh);
                    XtraMessageBox.Show("Thêm Thành Công");
                    KhachHangc_Load(sender, e);
                }

                
            }
            if (update)
            {
                
                    DialogResult rs;
                    rs = XtraMessageBox.Show("Bạn có muốn sửa  không", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (rs == DialogResult.Yes)
                    {

                        kh.sua1khachhang(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSoDienThoai.Text, gioitinh, cboLoaikh.SelectedValue.ToString(),ngaysinh);
                        XtraMessageBox.Show("Sửa Thành Công");
                        KhachHangc_Load(sender, e);

                    }
                }

            }
        
        private void btnIn_Click(object sender, EventArgs e)
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


            worksheet.Cells[1, 1] = "Dach sách  Khách Hàng";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã  Khách Hàng";
            worksheet.Cells[3, 3] = "Tên  Khách Hàng";
            worksheet.Cells[3, 4] = "Ngày Sinh";
            worksheet.Cells[3, 5] = "Giới tính";
            worksheet.Cells[3, 6] = "Số Điện Thoại";
            worksheet.Cells[3, 7] = "Địa chỉ Khách Hàng";
            worksheet.Cells[3, 8] = "Tổng Tiền Đã Mua Hàng";
            worksheet.Cells[3, 9] = "Số Tiền Nợ";
            /// int j = 1;
            //
            List<KhachHang> lst2 = new List<KhachHang>();
            lst2 = kh.loadallkh();

            //list = kh.laydulieutongtien("KH007");
            //string a = list[0].tongtien.ToString();
            List<String> lsttongtientt = new List<string>();
            List<String> lsttongtienno = new List<String>();
           

            for (int i = 0; i < lst2.Count; i++)
            {
                lsttongtientt.Add(kh.laytienkhachhangthanhtoan(lst2[i].MaKH));
                lsttongtienno.Add(kh.laytienkhachhangno(lst2[i].MaKH));
            }
            for (int i = 0; i < lst2.Count; i++)
            {


                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = lst2[i].MaKH;
                worksheet.Cells[i + 4, 3] = lst2[i].TenKH;
                worksheet.Cells[i + 4, 4] = lst2[i].Ngaysinh;
                worksheet.Cells[i + 4, 5] = lst2[i].GioiTinh;
                worksheet.Cells[i + 4, 6] = lst2[i].SDT;

                worksheet.Cells[i + 4, 7] = lst2[i].DiaChi;

                if (lsttongtientt[i].ToString() == "0")
                {
                    CellExcel cell = new CellExcel();
                    worksheet.Cells[i + 4, 8] = lsttongtientt[i].ToString();
                    cell.dong = i + 4;
                    cell.cot = 8;
                  
                }
                else
                {
                    worksheet.Cells[i + 4, 8] = lsttongtientt[i].ToString();

                }
                if (lsttongtienno[i].ToString() == "0")
                {
                    CellExcel cell = new CellExcel();
                    worksheet.Cells[i + 4, 9] = lsttongtienno[i].ToString();
                    cell.dong = i + 4;
                    cell.cot = 9;
                 
                }
                else
                {
                    worksheet.Cells[i + 4, 9] = lsttongtienno[i].ToString();

                }

            }

            // định dạng trang
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            worksheet.PageSetup.TopMargin = 0;

            //định dạng cột

            worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "I100"].Font.Size = 14;
            worksheet.Range["A1", "I1"].MergeCells = true;
            worksheet.Range["A1", "I3"].Font.Bold = true;

            // kẻ bảng nhân viên
            worksheet.Range["A3", "I" + (lst2.Count + 3)].Borders.LineStyle = 1;
        


            // định dạng các dòng
            worksheet.Range["A1", "G1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "I3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "I4" + lst2.Count.ToString()].HorizontalAlignment = 3;
            worksheet.Range["H4", "I4" + lst2.Count.ToString()].NumberFormat = "#,##0\" VNĐ\"";
            worksheet.Columns.AutoFit();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gridView1.RowCount>0)
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GioiTinh").ToString()=="Nam") 

                rdNam.Checked = true;
                
                
                else
                
                {
                    rdNu.Checked = true;
                }
            }
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            KhachHangc_Load(sender, e);
         
        }

        private void KhachHangc_VisibleChanged(object sender, EventArgs e)
        {
            //KhachHangc_Load(sender, e);
        //    bind(true);
            
        }

        public void loadcomboxmaloaikh()
        {
            cboLoaikh.DataSource = loaikh.getloaikh();
            cboLoaikh.DisplayMember = "Tenloaikh";
            cboLoaikh.ValueMember = "Maloaikh";

        }
    }
}
