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
    public partial class NhaCungCap1: DevExpress.XtraEditors.XtraUserControl
    {
      
        DALL_BALL_NhaCungCap NCC = new DALL_BALL_NhaCungCap();
        HoaDonNhapDALL_BALL hdnhap = new HoaDonNhapDALL_BALL();
        DALL_BALL_PhanQuyencs pq = new DALL_BALL_PhanQuyencs();
        WordExport export = new WordExport();
        bool add = false, update = false;
        public NhaCungCap1()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            hienthi(true);
            loadnhacc();
            bind(true);
            Error.Clear();
            btnLuu.Enabled = false;
            string mand = Login.nhomng;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
        }
        public void hienthi(bool t)
        {
            if (t)
            {
                txtMaNhaCC.Enabled = false;
                txtDiaChi.Enabled = false;
                txtSDT.Enabled = false;
                txtTenNCC.Enabled = false;
                btnLuu.Enabled = false;
            }
            else
            {

                txtDiaChi.Enabled = true;
                txtSDT.Enabled = true;
                txtTenNCC.Enabled = true;
                btnLuu.Enabled = true;
            }
        }
        public void loadnhacc()
        {

          
            dsNhacc.DataSource = NCC.loaddataNCC();

        }
        public void bind(bool t)
        {
            if (t)
            {
                txtMaNhaCC.DataBindings.Clear();
                txtMaNhaCC.DataBindings.Add("Text", dsNhacc.DataSource, "MaNC");
                txtTenNCC.DataBindings.Clear();
                txtTenNCC.DataBindings.Add("Text", dsNhacc.DataSource, "TenNCC");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", dsNhacc.DataSource, "DIACHI");
                txtSDT.DataBindings.Clear();
                txtSDT.DataBindings.Add("Text", dsNhacc.DataSource, "SDT");
           
            }
            else
            {
                txtMaNhaCC.DataBindings.Clear();
                txtTenNCC.DataBindings.Clear();
                txtDiaChi.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
             


            }
        }

        public void resetvalues()
        {
            txtMaNhaCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            
            txtTenNCC.Focus();
            Error.Clear();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            NhaCungCap_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {


        }

        public bool kiemtradulieuso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x, out a);
            if (t)
            {
                return true;
            }
            return false;
        }
        public bool kiemtradulieu()
        {
            if (txtTenNCC.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Để Trống Tên Nhà Cung Cấp");
                return false;
            }
            else if (txtSDT.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Để Trống Số Điện Thoại");
                return false;
            }
            else if (!kiemtradulieuso(txtSDT.Text))
            {
                XtraMessageBox.Show("Số Điện Thoại Phải Nhập Số");
                return false;
            }
            else
                return true;

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
           
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            if (kiemtradulieuso(txtSDT.Text))
            {
                Error.Clear();
            }
            else
            {
                Error.SetError(txtSDT, "Bạn Phải Nhập Số");
            }

        }

        private void txtDiaChi_EditValueChanged(object sender, EventArgs e)
        {

        }
        public void timkiemnhacungcap(string x)
        {
            dsNhacc.DataSource = NCC.timkiemnhacuncap(x);
        }
        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            XtraMessageBox.Show("Thành Công là : " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNC").ToString());
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
          //  w.QuyetDinhKhenThuong(txtMaNhaCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
        }

        private void btnHuyBo_Click_1(object sender, EventArgs e)
        {
            NhaCungCap_Load(sender, e);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (add)
            {

                if (kiemtradulieu())
                {
                    NCC.themNhaCC(txtMaNhaCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, "Đang giao dịch");
                    XtraMessageBox.Show("Thành Công ");
                    NhaCungCap_Load(sender, e);
                    DialogResult rs;
                    rs = XtraMessageBox.Show("Bạn Có Muốn in hợp đồng nhà cung cấp hog", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.Yes)
                    {
                        export.QuyetDinhKhenThuong(txtMaNhaCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text);
                        
                    }
                }
            }
            if (update)
            {
                DialogResult rs;
                rs = XtraMessageBox.Show("Bạn Có Muốn Sửa Nhà Cung Cấp Không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (kiemtradulieu())
                {
                    if (rs == DialogResult.Yes)
                    {
                        if (NCC.sua1NCC(txtMaNhaCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, "Đang giao dịch"))
                        {
                            XtraMessageBox.Show("Thành Công");
                            NhaCungCap_Load(sender, e);

                      
                        }
                    }
                }
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            add = true;
            update = false;
            resetvalues();
            bind(false);
            hienthi(false);
            txtMaNhaCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenNCC.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            if (gridView1.RowCount <= 0)
            {
                txtMaNhaCC.Text = "NC001";
            }
            else
            {
                txtMaNhaCC.Text = NCC.getmaNhaCC();
            }

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if(gridView1.RowCount<=0)
            {
                XtraMessageBox.Show("Không có nhà cung cấp nào");
                return;
            }
            DialogResult rs;
            rs = XtraMessageBox.Show("ban có muôn xóa không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.Yes)
            {

                List<string> dshoadon = new List<string>();
                dshoadon = NCC.mahdnhaptheonhacc(txtMaNhaCC.Text);
                for (int i = 0; i < dshoadon.Count; i++)
                {
                    hdnhap.xoanhd(dshoadon[i].ToString());
                }
                if (NCC.xoa1NCC(txtMaNhaCC.Text))
                {
                    XtraMessageBox.Show(" Xóa thành Công");
                    NhaCungCap_Load(sender, e);
                }

            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            Error.Clear();
            update = true;
            add = false;
            hienthi(false);
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
           
               
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;





            workbook = application.Workbooks.Add(Type.Missing);
            application.Visible = true;
            application.WindowState = Excel.XlWindowState.xlMaximized;
            //getdatabase   
            workbook.Worksheets.Add();
            worksheet = workbook.Sheets[1];


            worksheet.Cells[1, 1] = "Dach sách  Nhà Cung Cấp";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã  nhà cung cấp";
            worksheet.Cells[3, 3] = "Tên nhà cung cấp";
            worksheet.Cells[3, 4] = "Số điện thoại nhà cung cấp";
            worksheet.Cells[3, 5] = "Địa chỉ nhà cung cấp";
            worksheet.Cells[3, 6] = "Tình trạng thanh toán";
            worksheet.Cells[3, 7] = "Tổng tiền đã trả";
            worksheet.Cells[3, 8] = "Tổng Tiền còn nợ";
         
            /// int j = 1;
            //
            List<NhaCungCap>lst2 = new List<NhaCungCap>();
            lst2 = NCC.loadnhacclist();

            //list = kh.laydulieutongtien("KH007");
            //string a = list[0].tongtien.ToString();
            List<String> lsttongtientt = new List<string>();
            List<String> lsttongtienno = new List<String>();
      

            for (int i = 0; i < lst2.Count; i++)
            {
                lsttongtientt.Add(NCC.laytienthanhtoanncc(lst2[i].MaNC));
                lsttongtienno.Add(NCC.laytiennonhacungcap(lst2[i].MaNC));
            }
            for (int i = 0; i < lst2.Count; i++)
            {


                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = lst2[i].MaNC;
                worksheet.Cells[i + 4, 3] = lst2[i].TenNCC;
                worksheet.Cells[i + 4, 4] = lst2[i].SDT;
                worksheet.Cells[i + 4, 5] = lst2[i].DIACHI;
                worksheet.Cells[i + 4, 6] = lst2[i].Trangthai;

               

                if (lsttongtientt[i].ToString() == "0")
                {
                  
                    worksheet.Cells[i + 4, 7] = lsttongtientt[i].ToString();
                  
                }
                else
                {
                    worksheet.Cells[i + 4, 7] = lsttongtientt[i].ToString();

                }
                if (lsttongtienno[i].ToString() == "0")
                {
                  
                    worksheet.Cells[i + 4, 8] = lsttongtienno[i].ToString();
                  
                }
                else
                {
                    worksheet.Cells[i + 4, 8] = lsttongtienno[i].ToString();

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

            worksheet.Range["A1", "H3"+lst2.Count].Font.Name = "Times New Roman";
            worksheet.Range["A1", "H1" + lst2.Count].Font.Size = 17;
            worksheet.Range["A1", "H1"].Font.Bold = true;

            worksheet.Range["A4", "H4"+lst2.Count.ToString()].Font.Size = 13;
            worksheet.Range["A4", "H4" + lst2.Count.ToString()].Font.Name = "Times New Roman";
            worksheet.Range["A1", "I1"].MergeCells = true;
            worksheet.Range["A2", "H3"].Font.Bold = true;
            worksheet.Range["A2", "H3"].Font.Size = 15;


            // kẻ bảng nhân viên
            worksheet.Range["A3", "H" + (lst2.Count + 3)].Borders.LineStyle = 1;
          

            // định dạng các dòng
            worksheet.Range["A1", "G1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "I3"].HorizontalAlignment = 3;
            worksheet.Range["A3", "I3" + lst2.Count.ToString()].HorizontalAlignment = 3;
            worksheet.Range["G4", "H4" + lst2.Count.ToString()].NumberFormat = "#,##0\" VNĐ\"";
            worksheet.Columns.AutoFit();
        }
        
        private void NhaCC_VisibleChanged(object sender, EventArgs e)
        {
            NhaCungCap_Load(sender, e);
        }

    }
}