using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyVatLieuXayDung.Report
{
    public partial class ChiTietHDXuat2 : DevExpress.XtraReports.UI.XtraReport
    {
        public ChiTietHDXuat2(string ngay,string thang,string nam)
        {
            InitializeComponent();
            lblNgay.Text = ngay;
            lblThang.Text = thang;
            lblNam.Text = nam;
          
        }

    }
}
