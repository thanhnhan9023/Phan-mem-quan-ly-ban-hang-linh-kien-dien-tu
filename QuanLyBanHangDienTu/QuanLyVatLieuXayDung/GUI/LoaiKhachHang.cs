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
using DALL_BALL;

namespace QuanLyVatLieuXayDung
{
    public partial class LoaiKhachHang : DevExpress.XtraEditors.XtraForm
    {

        DALL_BALl_LoaiKhachHang loaiKhach = new DALL_BALl_LoaiKhachHang();
        bool add, update;
        public LoaiKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            databind(false);
            add = true;
            update = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoas.Enabled = false;
            txtMaLoaiKH.Text = loaiKhach.laymatudongtangkhachhang();
            txtTenLoaiKH.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            add = false;
            update = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoas.Enabled = false;
        }

        private void btnXoas_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn Sửa", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loaiKhach.xoa1loaikhachang(txtMaLoaiKH.Text);
                LoaiKhachHang_Load(sender, e);
                XtraMessageBox.Show("Thành công");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (add)
            {
                //   databind(false);

                if (XtraMessageBox.Show("Bạn có muốn Thêm", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    loaiKhach.them1loaikhachhang(txtMaLoaiKH.Text, txtTenLoaiKH.Text);
                    btnSua.Enabled = true;
                    btnXoas.Enabled = true;
                    LoaiKhachHang_Load(sender, e);
                    XtraMessageBox.Show("Thành công");
                }

            }
            if (update)
            {


                if (XtraMessageBox.Show("Bạn có muốn Sửa", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    loaiKhach.sua1loaikhachhang(txtMaLoaiKH.Text, txtTenLoaiKH.Text);
                    btnThem.Enabled = true;
                    btnXoas.Enabled = true;
                    LoaiKhachHang_Load(sender, e);
                    XtraMessageBox.Show("Thành công");
                    databind(false);
                }

            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LoaiKhachHang_Load(sender, e);
        }
        public void hienthi(bool t)
        {

            txtTenLoaiKH.Enabled = t;

        }

        public void loadloaikh()
        {
            dsloaikh.DataSource = loaiKhach.getloaikh();

        }
            public void databind(bool t)

           
        {

            if(t)
            {
                txtTenLoaiKH.DataBindings.Clear();
                txtTenLoaiKH.DataBindings.Add("Text", dsloaikh.DataSource, "Tenloaikh");

                txtMaLoaiKH.DataBindings.Clear();
                txtMaLoaiKH.DataBindings.Add("Text", dsloaikh.DataSource, "Maloaikh");
            }
            else 
            {
                txtTenLoaiKH.DataBindings.Clear();
                txtMaLoaiKH.DataBindings.Clear();

            }

        }


        private void LoaiKhachHang_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoas.Enabled = true;
            loadloaikh();
            databind(true);
            txtMaLoaiKH.Enabled = false;
        }
    }
}