using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyVatLieuXayDung.GUI;
using DALL_BALL;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {

        DALL_BALL_Login logintt = new DALL_BALL_Login();
        DALL_BALL_PhanQuyencs pq = new DALL_BALL_PhanQuyencs();
        public static string macv="";
        public static string manv = "";
        public static string tennv = "";
        public static string nhomng = "";
        public static string username = "";
           
      
        public static string tendangnhap;
        public Login()
        {
            InitializeComponent();
            skins();
            
        }

      
      
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Springtime";

        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
                

            if (txtMatKhau.Text.Length <= 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập mật khẩu");
                return;
            }
             if (txtDangNhap.Text.Length <= 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập tên đăng nhập");
            }

            List<NguoiDung> nd = new List<NguoiDung>();
            nd = logintt.login(txtDangNhap.Text,logintt.SHA256(txtMatKhau.Text));
             if(nd.Count>0)
            {


              //  macv = logintt.laymacvtuusser(txtDangNhap.Text);

                manv = nd[0].MaNV;
                tennv = nd[0].NhanVien.TenNV;
                macv = nd[0].NhanVien.MaCV;
                nhomng = pq.nhomnguoidung(txtDangNhap.Text);
                Program.quit = false;
                this.Hide();
                s s = new s();
                s.Show();

            }
            else
                XtraMessageBox.Show("Sai tài khoản");





        }
              
            
        
       
  

        private void Login_Load(object sender, EventArgs e)
        {
            txtMatKhau.Properties.UseSystemPasswordChar = true;

        }

        private void checkhienthi_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkhienthi.Checked)
            {

                txtMatKhau.Properties.UseSystemPasswordChar = true;

            }
            else
            {
                txtMatKhau.Properties.UseSystemPasswordChar = false;
            }
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtDangNhap.Text = "";
            txtMatKhau.Text = "";
          
            Program.quit = true;
         

        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (txtMatKhau.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập mật khẩu");
                    return;
                }
                if (txtDangNhap.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên đăng nhập");
                }

                List<NguoiDung> nd = new List<NguoiDung>();
                nd = logintt.login(txtDangNhap.Text, logintt.SHA256(txtMatKhau.Text));
                if (nd.Count > 0)
                {


                    macv = logintt.laymacvtuusser(txtDangNhap.Text);

                    manv = nd[0].MaNV;
                    tennv = nd[0].NhanVien.TenNV;
                    macv = nd[0].NhanVien.MaCV;
                    nhomng = pq.nhomnguoidung(txtDangNhap.Text);
                  
                    Program.quit = false;
                    this.Hide();
                    s s = new s();
                    s.Show();


                }
                else
                {
                    Program.quit = true;
                    XtraMessageBox.Show("Sai tài khoản");
                }

            }

        }

        private void btnDangnhap_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void btnDangnhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.quit = true;
        }
    }
}