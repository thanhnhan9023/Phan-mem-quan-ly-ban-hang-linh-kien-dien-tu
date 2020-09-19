using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace QuanLyVatLieuXayDung.Report
{
    public partial class RptInChiTietHDNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public RptInChiTietHDNhap(string ngay,string nam,string thang)
        {
            InitializeComponent();

            lblNgay.Text = ngay;
            lblThang.Text = thang;
            lblNam.Text = nam;


        }

    }
}
