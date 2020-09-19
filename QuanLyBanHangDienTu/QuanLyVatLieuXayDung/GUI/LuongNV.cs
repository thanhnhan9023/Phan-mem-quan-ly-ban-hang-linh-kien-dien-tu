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


namespace QuanLyVatLieuXayDung.GUI
{
    public partial class LuongNV : DevExpress.XtraEditors.XtraForm
    {
        string manv = "";
        bool add = false,update=false;
        public LuongNV(string manv,string tennv,string gioitinh,string ngayvaolam,string diachi,string chucvu)
        {
            InitializeComponent();
            lblTenNv.Text = tennv;
            lblNgayVaoLam.Text = ngayvaolam;
            lblDiaChi.Text = diachi;
            lblChucVu.Text = chucvu;
         
            this.manv = manv;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void dateNgayKetThuc_EditValueChanged(object sender, EventArgs e)
        {
            //DateTime ngayvaolam = DateTime.Parse(lblNgayVaoLam.Text);
            //DateTime ngaykethuc = Convert.ToDateTime(dateNgayKetThuc.EditValue.ToString());
            if (dateNgayKetThuc.EditValue.ToString() != null)
            {
                DateTime ngayvaolam = DateTime.Parse(lblNgayVaoLam.Text);
                DateTime ngaykethuc = DateTime.Parse(dateNgayKetThuc.EditValue.ToString());
                TimeSpan diff2 = ngaykethuc - ngayvaolam;
                int songaylam = (int)diff2.TotalDays;
                if (songaylam <= 0)
                {
                    XtraMessageBox.Show("Ngày Kết Thúc Phải Lớn Hơn Ngày Làm");
                }
                else
                {
                    txtLuongNV.Text = (double.Parse(lblLCb.Text) *songaylam).ToString();
                }
            }
        }
        public void hienthi(bool t)
        {
            if(t)
            {
                dateNgayKetThuc.Enabled = false;
            }
            else

            {
                dateNgayKetThuc.Enabled = true;
            }
        }


    
        public void loadulieuluong()
        {
           
        }
        private void LuongNV_Load(object sender, EventArgs e)
        {
            loadulieuluong();
            hienthi(true);
            txtLuongNV.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            hienthi(false);
            dateNgayKetThuc.EditValue = DateTime.Now;
        }
        public void binds()
        {
            lblTenNv.DataBindings.Clear();
            lblTenNv.DataBindings.Add("Text", dsnhanvien.DataSource, "TenNV");
            lblDiaChi.DataBindings.Clear();
            lblNgayVaoLam.DataBindings.Clear();
            lblNgayVaoLam.DataBindings.Add("Text",dsnhanvien.DataSource,"NgayVaoLam");
            dateNgayKetThuc.DataBindings.Clear();
            dateNgayKetThuc.DataBindings.Add("Text",dsnhanvien.DataSource,"NgayKetThuc");
       }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (add)
            {
               
                    
                
            

            }
            
        }

        private void txtLuongNV_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LuongNV_Load(sender, e);
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            hienthi(false);
            
            binds();
        }
    }
}