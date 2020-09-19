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
    public partial class Phanquyenchonhom : DevExpress.XtraEditors.XtraUserControl
    {

        DALL_QuantriNguoiDung qt = new DALL_QuantriNguoiDung();
        DALL_BALL_PhanQuyencs pq = new DALL_BALL_PhanQuyencs();
        string mand;
        public Phanquyenchonhom()
        {
            InitializeComponent();
        }

        public void load_nhomnquyennhom(object sender, EventArgs e)
        {
            loadnhom();
          //  loadquyendaco();
          //  loadquyenchuaco();
        }
        public void loadnhom()
        {
            gridControl1.DataSource = qt.loadnhoom();

            } 
        public void loadquyendaco(string mand)
        {

         
              
                gridControl2.DataSource = pq.loadallquyendaco(mand);
            
                }
        public void loadquyenchuaco(string mand)
        {
           
           
                gridControl3.DataSource = pq.loadallquyenchuaco(mand);
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                mand = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Manhomnguoidung").ToString();
                gridControl3.DataSource = pq.loadallquyenchuaco(mand);
                gridControl2.DataSource = pq.loadallquyendaco(mand);

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn  thêm  quyền này cho người dùng", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
             
              if(gridView3.RowCount>0)
                {
                    string maquyenn = gridView3.GetRowCellValue(gridView3.FocusedRowHandle,"Maquyen").ToString();
                    pq.them1quyenchonhomnd(mand, maquyenn, true);
                    XtraMessageBox.Show("Thêm Thành công");
                    loadquyendaco(mand);
                    loadquyenchuaco(mand);
                    
                }
           
              
            }





        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn  loại bỏ  quyền này ", "Đồng Ý Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               

                    string maquyenn = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Maquyen").ToString();
                    string tenquyen = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Chucnangquyen").ToString();
                    pq.xoa1quyenchonhomnd(mand, maquyenn);
                    XtraMessageBox.Show("Đã bỏ quyền " + tenquyen);
                    loadquyendaco(mand);
                    loadquyenchuaco(mand);
                
                


            }

        }

        private void Phanquyenchonhom_VisibleChanged(object sender, EventArgs e)
        {
            load_nhomnquyennhom(sender, e);
        }
    }
}
