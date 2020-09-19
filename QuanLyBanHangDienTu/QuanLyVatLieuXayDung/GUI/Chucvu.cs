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

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class Chucvu : DevExpress.XtraEditors.XtraForm
    {

        DALl_BALL_Cv cv = new DALl_BALL_Cv();
        bool add = false, update = false;
     
        
        public Chucvu()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        public void laydulieuchucvu()
        {
         
        }
        private void Chucvu_Load(object sender, EventArgs e)
        {
            hienthi(true);
            laydulieuchucvu();
            loadsachcv();
            bind(true);
            BtnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaCv.Enabled = false;


        }
        public void khoitao()
        {
           
         
        }

        public void hienthi(bool t)
        {
            if (t)
            {
              
                BtnLuu.Enabled = false;
                txtTencV.Enabled = false;
                txtLCB.Enabled = false;
            }
            else
            {
               
                BtnLuu.Enabled = true;
                txtTencV.Enabled = true;
                txtLCB.Enabled = true;
            }
        }
        public bool kiemtraso(string x)
        {
            double a = 0;

            bool t = double.TryParse(x,out a );
            if(t)
            {
                return true;
            }
            else
            return false;
        }
            public bool kiemtradulieu()
           {
                if(txtTencV.Text.Length<=0)
                {
                XtraMessageBox.Show("Chưa nhập tên chức vụ");
                return false;
                 }
             if (txtLCB.Text.Length <= 0)
             {
                XtraMessageBox.Show("Chưa nhập Lương Cơ Bản");
                return false;
             }
            if (!kiemtraso(txtLCB.Text))
            {
                XtraMessageBox.Show("Bạn Phải Nhập Số");
                return false;
            }
          
            return true;

        }

        
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if(txtTencV.Text.Length<=0)
            {
                XtraMessageBox.Show("Bạn phải nhập tên chức vụ");
                return;
            }
            if(add)
            {


                if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cv.them1cv(txtMaCv.Text, txtTencV.Text);
                    Chucvu_Load(sender,e);
                    XtraMessageBox.Show("Thành công");
                }


            }
            if(update)
            {


                if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cv.sua1cv(txtMaCv.Text, txtTencV.Text);
                    Chucvu_Load(sender, e);
                    XtraMessageBox.Show("Thành Công");
                }
            }

         
        }

        public void bind(bool t)
        {
            if(t)
            {
                txtMaCv.DataBindings.Clear();
                txtMaCv.DataBindings.Add("Text",dschucvu.DataSource,"MaCv");
                txtTencV.DataBindings.Clear();
                txtTencV.DataBindings.Add("Text",dschucvu.DataSource,"TenCv");
                
            }
            else
            {
                txtMaCv.DataBindings.Clear();
                txtTencV.DataBindings.Clear();

            }

        }
        public void resetvalues()
        {
            txtLCB.Text = "";
            txtMaCv.Text = "";
            txtTencV.Text = "";
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            add = false;
            update = true;
            hienthi(false);
            
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            BtnLuu.Enabled = true;
            
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            Chucvu_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cv.xoa1cv(txtMaCv.Text);
                Chucvu_Load(sender, e);
                XtraMessageBox.Show("Thành công");
            }
        
  

        }

        private void dschucvu_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            resetvalues();
            hienthi(false);
            add = true;
            update = false;
            BtnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            if(gridView1.RowCount<=0)
            {
                txtMaCv.Text = "CV001";
            }
            else
            {
                txtMaCv.Text = cv.getmachucvu();
            }

        }

        public void loadsachcv()
        {
            dschucvu.DataSource = cv.loadcv();
        }


    }
}