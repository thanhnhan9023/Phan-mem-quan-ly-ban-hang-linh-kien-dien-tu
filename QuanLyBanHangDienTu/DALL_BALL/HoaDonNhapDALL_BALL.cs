    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
  public  class HoaDonNhapDALL_BALL
    {

        QLBanHangDataContext data = new QLBanHangDataContext();
        public List<HoaDon_Nhap> loadhoadonhap()
        {
            var ds = data.HoaDon_Nhaps.ToList();
            return ds;
                
           
        }
        public  List<ChiTietHD_Nhap> kiemtradulieuhoadonnhap(string mahdn)
        {
            return data.ChiTietHD_Nhaps.Where(t => t.MAHD_Nhap == mahdn).ToList();
        }
        public IQueryable loadhoadonhap2(string manv)
        {
            var ds = from HoaDon_Nhaps in data.HoaDon_Nhaps.Where(t=>t.MANV==manv)
                     select new
                     {
                         HoaDon_Nhaps.MAHD_Nhap,
                         HoaDon_Nhaps.NhaCungCap.TenNCC,
                         HoaDon_Nhaps.NhanVien.TenNV,
                         HoaDon_Nhaps.TinhTrangNhap,
                         HoaDon_Nhaps.MaNC,
                         HoaDon_Nhaps.NgayLapHD,
                         HoaDon_Nhaps.TongTien,
                         HoaDon_Nhaps.TinhTrangNhapKho,
                         
                         
                     };
            return ds;
        }


      


        public IQueryable loadhoadonhapchitiet(string mahd)
        {
            var ds = from ChiTietHD_Nhaps in data.ChiTietHD_Nhaps
                     where
                       ChiTietHD_Nhaps.MAHD_Nhap == mahd
                     select new
                     {
                         ChiTietHD_Nhaps.MAHD_Nhap,
                         ChiTietHD_Nhaps.HangHoa.TenHH,
                         ChiTietHD_Nhaps.SoLuong_Nhap,
                         ChiTietHD_Nhaps.DonGia_Nhap,
                         ChiTietHD_Nhaps.Thanhtien,
                         ChiTietHD_Nhaps.DonVi,
                         ChiTietHD_Nhaps.MAHH
                      
                     };
            return ds;
        }
        public  List<ChiTietHD_Nhap> loadhoadonchitiet(string mahd)
        {
            var ds = from k in data.ChiTietHD_Nhaps.Where(t => t.MAHD_Nhap == mahd) select k;
            return ds.ToList();
        }

        
        public void them1hoadonhap(string mahdnhap,string mancc,string manv,DateTime ngaylaphoadon,string tinhtrangnhap,long tongtien,string tinhtrangnhapkho)
            {
            HoaDon_Nhap iHoaDon_Nhaps = new HoaDon_Nhap
            {
                MAHD_Nhap =mahdnhap,
                MaNC = mancc,
                MANV = manv,
                NgayLapHD = ngaylaphoadon,
                TinhTrangNhap = tinhtrangnhap,
                TongTien=tongtien,
                TinhTrangNhapKho=tinhtrangnhapkho,
              
                
            };
            data.HoaDon_Nhaps.InsertOnSubmit(iHoaDon_Nhaps);
            data.SubmitChanges();


        }
        public void them1hoadonhap1(HoaDon_Nhap hdnhap)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                HoaDon_Nhap iHoaDon_Nhaps = new HoaDon_Nhap
                {
                    MAHD_Nhap = hdnhap.MAHD_Nhap,
                    MaNC = hdnhap.MaNC,
                    MANV = hdnhap.MANV,
                    NgayLapHD = hdnhap.NgayLapHD,
                    TinhTrangNhap = hdnhap.TinhTrangNhap
                };
                data.HoaDon_Nhaps.InsertOnSubmit(iHoaDon_Nhaps);
                data.SubmitChanges();
            }

        }

        public void sua1hoadonnhap(string mahdnhap, string mancc, string manv, DateTime ngaylaphoadon)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                var queryHoaDon_Nhaps =
                            from HoaDon_Nhaps in data.HoaDon_Nhaps
                            where
                              HoaDon_Nhaps.MAHD_Nhap == mahdnhap
                            select HoaDon_Nhaps;
                foreach (var HoaDon_Nhaps in queryHoaDon_Nhaps)
                {
                    HoaDon_Nhaps.NgayLapHD = ngaylaphoadon;
                    HoaDon_Nhaps.MaNC = mancc;
               //     HoaDon_Nhaps.TinhTrangNhap = tinhtrangnhap;
                   // HoaDon_Nhaps.TinhTrangNhapKho = tinhtrangnhapkho;
                }
                data.SubmitChanges();
            }
        }

        public string getmatudongtanhdnhap()
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                string x = data.HoaDon_Nhaps.Max(t => t.MAHD_Nhap);
                int ma = int.Parse(x.Substring(x.Length - 3, 3));

                if (ma >= 0 && ma < 9)
                {
                    return "HDN00" + (ma + 1).ToString();
                }
                else if (ma >= 9)
                {
                    return "HDN" + (ma + 1).ToString();
                }
                else
                    return "";
            }


        }
        public void xoanhd(string mahd) // xóa hóa đơn nhập
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                var queryHoaDon_Nhaps =
             from HoaDon_Nhaps in data.HoaDon_Nhaps
             where
               HoaDon_Nhaps.MAHD_Nhap == mahd
             select HoaDon_Nhaps;
                foreach (var del in queryHoaDon_Nhaps)
                {
                    data.HoaDon_Nhaps.DeleteOnSubmit(del);
                }
                data.SubmitChanges();
            }
            
        }
       
        public void xoachitiethoadonnhap(string mahh)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                var queryChiTietHD_Nhaps =
             from ChiTietHD_Nhaps in data.ChiTietHD_Nhaps
             where
               ChiTietHD_Nhaps.MAHH == mahh
             select ChiTietHD_Nhaps;
                foreach (var del in queryChiTietHD_Nhaps)
                {
                    data.ChiTietHD_Nhaps.DeleteOnSubmit(del);
                }
                data.SubmitChanges();
            }

        }


        // them 1 chitiethodonnhap
        public void them1chitiethoadon(string mahdnhap,string mahanghoa,int soluong,double dongia,double thanhtien,string donvi,double vat)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                ChiTietHD_Nhap iChiTietHD_Nhaps = new ChiTietHD_Nhap
                {
                    MAHD_Nhap = mahdnhap,
                    MAHH = mahanghoa,
                    SoLuong_Nhap = soluong,
                    DonGia_Nhap = dongia,
                    Thanhtien = thanhtien,
                    DonVi = donvi,

                };
                data.ChiTietHD_Nhaps.InsertOnSubmit(iChiTietHD_Nhaps);
                data.SubmitChanges();

            }


         

        }
        //sua1chiiethoadonnhap

        public void sua1chitiethoadon(string mahdnhap, string mahanghoa, int soluong, double dongia, double thanhtien, string donvi, double vat)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                ChiTietHD_Nhap chiTietHD_Nhap = new ChiTietHD_Nhap();
                chiTietHD_Nhap = data.ChiTietHD_Nhaps.Where(t => t.MAHD_Nhap == mahdnhap && t.MAHH == mahanghoa).FirstOrDefault();
                if (chiTietHD_Nhap != null)
                {
                    chiTietHD_Nhap.SoLuong_Nhap = soluong;
                    chiTietHD_Nhap.DonGia_Nhap = dongia;
                    data.SubmitChanges();
                }
            }
        }
        public void xoa1chitiethoadon(string mahd)
        {


            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                var queryChiTietHD_Nhaps =
           from ChiTietHD_Nhaps in data.ChiTietHD_Nhaps
           where
             ChiTietHD_Nhaps.MAHD_Nhap == mahd
           select ChiTietHD_Nhaps;
                foreach (var del in queryChiTietHD_Nhaps)
                {
                    data.ChiTietHD_Nhaps.DeleteOnSubmit(del);
                }
                data.SubmitChanges();
            }
            
          

        }

        public void updatehoadonhapkhithanhtoan(string mahdn,string tinhtrang,float vat)
        {
           


            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                HoaDon_Nhap hdn = new HoaDon_Nhap();
                hdn = db.HoaDon_Nhaps.Where(t => t.MAHD_Nhap == mahdn).FirstOrDefault();


                if (hdn != null)
                {
                    hdn.TinhTrangNhap = tinhtrang;
                    hdn.Vat = vat;
                    db.SubmitChanges();
                }

            }
           
            
        }
        public List<string> loadmahhtheohdnhap(string mahdnhap)
        {
            
            
                List<string> lst = new List<string>();
               

            var ds = from ChiTietHD_Nhaps in data.ChiTietHD_Nhaps
                     where
                       ChiTietHD_Nhaps.MAHD_Nhap == mahdnhap
                     select ChiTietHD_Nhaps.MAHH;

            lst = ds.ToList();
            return lst;
            
            
        }
        public void updatetinhtrangnhapkho(string mahdnhap,string tinhtrangnhapkho)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {

                HoaDon_Nhap hdnhap = new HoaDon_Nhap();
                hdnhap = data.HoaDon_Nhaps.Where(t => t.MAHD_Nhap == mahdnhap).FirstOrDefault();
                if (hdnhap != null)
                {
                    hdnhap.TinhTrangNhapKho = tinhtrangnhapkho;
                    data.SubmitChanges();
                }
            }
        }
            
        
    }
}
