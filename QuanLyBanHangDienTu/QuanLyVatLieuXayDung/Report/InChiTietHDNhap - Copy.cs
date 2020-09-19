using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace QuanLyVatLieuXayDung.Report
{
    public partial class InChiTietHDNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public InChiTietHDNhap(string mahd,string tenncc,string ngaylap,string xuatxu )
        {
            InitializeComponent();
            lblXuatXu.Text = xuatxu;
            lblNgayNhap.Text = ngaylap;
            lblhoadon.Text = mahd;
            lblTenNhaCc.Text = tenncc;
            this.chiTietHDNhapTableAdapter.Fill(this.dataSet11.ChiTietHDNhap, mahd);
           
        }

    }
}
