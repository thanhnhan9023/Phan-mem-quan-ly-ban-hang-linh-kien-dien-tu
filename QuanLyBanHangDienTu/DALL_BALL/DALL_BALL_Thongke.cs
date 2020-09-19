using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
   public class DALL_BALL_Thongke
    {

        QLBanHangDataContext data = new QLBanHangDataContext();


        public IQueryable XemThongkeThang(string thang, string nam)
        {
            var a = from HoaDon_Xuats in  data.HoaDon_Xuats
                    where
                      Convert.ToString(HoaDon_Xuats.NgayLap_Xuat.Value.Month) == thang &&
                       Convert.ToString(HoaDon_Xuats.NgayLap_Xuat.Value.Year) == nam
                    select new
                    {
                        HoaDon_Xuats.MAHD_Xuat,
                        HoaDon_Xuats.MAKH,
                        HoaDon_Xuats.MANV,
                        HoaDon_Xuats.NgayLap_Xuat,
                        HoaDon_Xuats.TinhTrangXuat
                    };
            return a;
        }
        public IQueryable XemThongkeNgay(DateTime ngay)
        {
            var a = from HoaDon_Xuats in data.HoaDon_Xuats
                    where
                      HoaDon_Xuats.NgayLap_Xuat == ngay
                    select new
                    {
                        HoaDon_Xuats.MAHD_Xuat,
                        HoaDon_Xuats.MAKH,
                        HoaDon_Xuats.MANV,
                        HoaDon_Xuats.NgayLap_Xuat,
                        HoaDon_Xuats.TinhTrangXuat
                    };
            return a;
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


        public IQueryable loadthongke()
        {
            var a = from HoaDon_Xuats in data.HoaDon_Xuats
                  
                    select new
                    {
                        HoaDon_Xuats.MAHD_Xuat,
                        HoaDon_Xuats.MAKH,
                        HoaDon_Xuats.MANV,
                        HoaDon_Xuats.NgayLap_Xuat,
                        HoaDon_Xuats.TinhTrangXuat
                    };
            return a;
        }
    }
}
