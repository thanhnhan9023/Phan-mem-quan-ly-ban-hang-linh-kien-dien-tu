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
    public partial class QuanTriNgD : DevExpress.XtraEditors.XtraUserControl
    {
       
        bool add = false, update = false;
   
        DALL_QuantriNguoiDung qtringdung = new DALL_QuantriNguoiDung();
        DALL_BALL_Login login = new DALL_BALL_Login();
        DALL_BALL_NhanVien nv = new DALL_BALL_NhanVien();
        public QuanTriNgD()
        {
            InitializeComponent();
        }

        public void QuanTriNgD_Load(object sender, EventArgs e)
        {
          //  hienthi(true);
                
           
            txtPassWord.Properties.UseSystemPasswordChar = true;
            txtPasswordX2.Properties.UseSystemPasswordChar = true;
            loaddstk();
            loadcomboxnv();
            
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            databind(true);
            txtTaiKhoan.Enabled = true;
            cboNhanVien.Enabled = true;
            
            
        }

        public void loaddstk()
        {
           dstaikhoan.DataSource=qtringdung.loaddachsachtaikhoan();
        }
        public void khoitao()
        {

           
            
       
        }
        public void xemtaikhoan()
        {

           

        }
        public void loadcomboxtk()
        {

        }
      
        public void hienthi(bool t)
        {
            if (t)
            {
                txtPassWord.Enabled = false;
                txtTaiKhoan.Enabled = false;
                btnLuu.Enabled = false;
                
              
                txtPasswordX2.Enabled = false;
             
            }
            else
            {
                if(gridView1.RowCount>=0)
                {
                    cboNhanVien.Enabled = true;
                   
                }
                txtPasswordX2.Enabled = true;
                txtPassWord.Enabled = true;
                txtTaiKhoan.Enabled = true;
                btnLuu.Enabled = true;
              
            }
        }
        public void hienthi2(bool t)
        {

            if (t)
            {
            
                txtPassWord.Enabled = false;
                
                
                txtPasswordX2.Enabled = false;

                btnLuu.Enabled = true;

            }
            else
            {
                txtTaiKhoan.Enabled = false;
                txtPasswordX2.Enabled = true;
                txtPassWord.Enabled = true;
                txtTaiKhoan.Enabled = true;
                btnLuu.Enabled = true;
             
            }


        }
        public void loadtheocombox()
        {
         
       }
        public bool hamkiemtrahople(string x)
        {
            x = txtPassWord.Text;
            if(txtPasswordX2.Text==x)
            {
                return true;
            }
            return false;
        }



        private void cboNguoiDung_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
         
       
        }
    

          

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            
            DialogResult rs;
            rs = XtraMessageBox.Show("Bạn Có Muốn ResetPassWord","Có",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if(rs==DialogResult.Yes)
            {
                qtringdung.resetpassword(txtTaiKhoan.Text,ckhoatdong.Checked);
                XtraMessageBox.Show("Reset password thành công");
                QuanTriNgD_Load(sender, e);

            }
        }

        public void resetvalues()
        {
            txtTaiKhoan.Text = "";
            txtPasswordX2.Text = "";
            txtPassWord.Text = "";
            txtTaiKhoan.Focus();
            
        }
        public void loadcomboxnv()
        {
            cboNhanVien.DataSource = nv.loaddulieuNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool hoatdong=false;
            if(ckhoatdong.Checked)
            {
                hoatdong = true;
            }
           
           
            if (add)
            {
                if (txtTaiKhoan.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tài khoản");
                    return;
                }
                if (txtPassWord.Text.Length <= 0)
                {

                    XtraMessageBox.Show("Bạn chưa nhập password");
                    return;
                }
                if (txtPasswordX2.Text.Length <= 0)
                {

                    XtraMessageBox.Show("Bạn chưa xác nhận password");
                    return;
                }
                if (qtringdung.kiemtrakhoachinh(txtTaiKhoan.Text))
                {
                    XtraMessageBox.Show("Tên đăng nhập đã tồn tại");
                    return;
                }
                if (txtPassWord.Text != txtPasswordX2.Text)
                {
                    XtraMessageBox.Show("Mật khẩu không khớp");
                    return;
                }
                string s = txtPasswordX2.Text;
                if (XtraMessageBox.Show("Bạn có muốn Thêm", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qtringdung.them1nguoidung(txtTaiKhoan.Text, cboNhanVien.SelectedValue.ToString(), login.SHA256(s), hoatdong);
                    QuanTriNgD_Load(sender, e);


                    XtraMessageBox.Show("Thành công");
                }
               
             }
            if(update)
            {
                if (txtPassWord.Text.Length <= 0)
                {

                    XtraMessageBox.Show("Bạn chưa nhập password");
                    return;
                }
                if (txtPasswordX2.Text.Length <= 0)
                {

                    XtraMessageBox.Show("Bạn chưa xác nhận password");
                    return;
                }
                if(txtPassWord.Text!=txtPasswordX2.Text)
                {
                    XtraMessageBox.Show("Mật khẩu không khớp");
                    return;
                }
                if (XtraMessageBox.Show("Bạn có muốn Sửa", "Đồng Ý Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    qtringdung.sua1nguoidung(txtTaiKhoan.Text, login.SHA256(txtPasswordX2.Text), hoatdong);
                    QuanTriNgD_Load(sender, e);
                    XtraMessageBox.Show("Thành công");
                }
            }
               
        }

        private void cboNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
       //     cohieu = true;
            add = false;
            txtTaiKhoan.Enabled = false;
       
            txtPassWord.Text = "";
            txtPasswordX2.Text = "";
            
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTaiKhoan.Enabled = false;
            cboNhanVien.Enabled = false;
            databind(false);
            cboNhanVien.Enabled = false;
            
          
            
            
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            QuanTriNgD_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            DialogResult rs;
            if(gridView1.RowCount<=0)
            {
                XtraMessageBox.Show("Không có user nào");
                return;
            }
            rs = XtraMessageBox.Show("Bạn Có Muốn Xóa Không", "Có", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Yes)
            {

                qtringdung.xoa1nguoidung(txtTaiKhoan.Text);

                QuanTriNgD_Load(sender, e);
            }
        }
        public void databind(bool t)
        {
            if (t)
            {
                txtTaiKhoan.DataBindings.Clear();
                txtTaiKhoan.DataBindings.Add("Text", dstaikhoan.DataSource, "UserName");
                cboNhanVien.DataBindings.Clear();
                cboNhanVien.DataBindings.Add("Text", dstaikhoan.DataSource, "TenNV");
            }
            else
            {
                txtTaiKhoan.DataBindings.Clear();
                txtTaiKhoan.DataBindings.Clear();
            }
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string s = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"Hoatdong").ToString();
            if (s == "True")
            {
                ckhoatdong.Checked = true;
            }
            else
                ckhoatdong.Checked = false;
           
        }

        private void QuanTriNgD_VisibleChanged(object sender, EventArgs e)
        {
            QuanTriNgD_Load(sender, e);
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            resetvalues();
          //  hienthi(false);
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            databind(false);
        }
    }
}
