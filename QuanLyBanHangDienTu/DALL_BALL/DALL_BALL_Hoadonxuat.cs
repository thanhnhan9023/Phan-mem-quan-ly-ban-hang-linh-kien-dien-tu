using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class DALL_BALL_Hoadonxuat
    {
        QLBanHangDataContext db = new QLBanHangDataContext();

        TuDongTang tt = new TuDongTang();
        public IQueryable loaddataHoaDonXuatALL()
        {
            var dsncc = from ds in db.HoaDon_Xuats select ds;
            return dsncc;
        }

        public IQueryable loadataHoaDonXuat(string manv)
        {
            var ds = from HoaDon_Xuats in db.HoaDon_Xuats.Where(t=>t.MANV==manv)
                     select new
                     {
                         HoaDon_Xuats.MAHD_Xuat,
                         HoaDon_Xuats.KhachHang.TenKH,
                         HoaDon_Xuats.NhanVien.TenNV,
                         HoaDon_Xuats.NgayLap_Xuat,
                         HoaDon_Xuats.TinhTrangXuat,
                         HoaDon_Xuats.MAKH,
                         HoaDon_Xuats.Vat,
                         HoaDon_Xuats.TongTien,

                     };

            return ds;
        }
        //  load chitiethoadonxuat
        public IQueryable loadchitiethoadonxuat(string mahdxuat)
        {

            var ds = from ChiTietHD_Xuats in db.ChiTietHD_Xuats
                     where
                       ChiTietHD_Xuats.MAHD_Xuat == mahdxuat
                     select new
                     {
                         ChiTietHD_Xuats.HangHoa.TenHH,
                         ChiTietHD_Xuats.SoLuong_Xuat,
                         ChiTietHD_Xuats.DonGia_Xuat,
                         ChiTietHD_Xuats.ThanhTienXuat,

                         ChiTietHD_Xuats.DonVi,
                         ChiTietHD_Xuats.MAHH,

                     };
            return ds;
        }
                public List<ChiTietHD_Xuat> loadchitiethdxuat(string mahdxuat)
        {
            var ds = from k in db.ChiTietHD_Xuats.Where(t=>t.MAHD_Xuat==mahdxuat) select k;
            return ds.ToList();
        }




        public string getmaHoadonxuat()
        {



            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                string x = data.HoaDon_Xuats.Max(m => m.MAHD_Xuat);
                int ma = int.Parse(x.Substring(x.Length - 3, 3));

                if (ma >= 0 && ma < 9)
                {
                    return "HDX00" + (ma + 1).ToString();
                }
                else if (ma >= 9)
                {
                    return "HDX0" + (ma + 1).ToString();
                }
                else
                    return "";
            }
           


        }
        public void them1HoaDonXuat(string maHDN, string MaKH, string MaNV, DateTime NgayLap, string Tinhtrang, float vat)
        {




            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                HoaDon_Xuat hdXuat = new HoaDon_Xuat();
                hdXuat.MAHD_Xuat = maHDN;
                hdXuat.MAKH = MaKH;
                hdXuat.MANV = MaNV;
                hdXuat.NgayLap_Xuat = NgayLap;
                hdXuat.TinhTrangXuat = Tinhtrang;
                hdXuat.TongTien = 0;
                hdXuat.Vat = vat;
                data.HoaDon_Xuats.InsertOnSubmit(hdXuat);
                data.SubmitChanges();
            }
          



        }

        public IQueryable XemThongkeNgay(DateTime ngay)
        {
            var a = from HoaDon_Nhaps in db.HoaDon_Nhaps
                    where
                      HoaDon_Nhaps.NgayLapHD == ngay
                    select new
                    {
                        HoaDon_Nhaps.MAHD_Nhap,
                        HoaDon_Nhaps.MaNC,
                        HoaDon_Nhaps.MANV,
                        HoaDon_Nhaps.NgayLapHD,
                        HoaDon_Nhaps.TinhTrangNhap
                    };
            return a;
        }
        public IQueryable XemThongkeThang(string thang, string nam)
        {
            var a = from HoaDon_Nhaps in db.HoaDon_Nhaps
                    where
                      Convert.ToString(HoaDon_Nhaps.NgayLapHD.Value.Month) == thang &&
                       Convert.ToString(HoaDon_Nhaps.NgayLapHD.Value.Year) == nam
                    select new
                    {
                        HoaDon_Nhaps.MAHD_Nhap,
                        HoaDon_Nhaps.MaNC,
                        HoaDon_Nhaps.MANV,
                        HoaDon_Nhaps.NgayLapHD,
                        HoaDon_Nhaps.TinhTrangNhap
                    };
            return a;
        }

        public void sua1hoadonnhapxuat(string mahdx)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                HoaDon_Xuat HoaDon = new HoaDon_Xuat();

                HoaDon = data.HoaDon_Xuats.Where(t => t.MAHD_Xuat == mahdx).SingleOrDefault();

                if (HoaDon != null)
                {

                    HoaDon.TinhTrangXuat = "Đã  Thanh Toán";

                    data.SubmitChanges();
                }
            }

        }

        public void xoa1HoadonNhap(string maHD)
        {
      



            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                HoaDon_Xuat HoaDon = new HoaDon_Xuat();

              

               
                HoaDon = data.HoaDon_Xuats.Where(t => t.MAHD_Xuat == maHD).FirstOrDefault();

                if (HoaDon != null)
                {

                    data.HoaDon_Xuats.DeleteOnSubmit(HoaDon);
                    data.SubmitChanges();
                }
                else
                    return;
            }

         
           
            

        }
        public void sua1hopdonxuat(string mahdxuat,DateTime ngaylaphoadon,string makh)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                HoaDon_Xuat hdxuat = new HoaDon_Xuat();
                hdxuat = data.HoaDon_Xuats.Where(t => t.MAHD_Xuat == mahdxuat).FirstOrDefault();
                if (hdxuat != null)
                {
                    hdxuat.NgayLap_Xuat = ngaylaphoadon;
                    hdxuat.MAKH = makh;
                    data.SubmitChanges();
                }
            }
        }
        public  void them1chitiethoadonxuat(string mahdx,string mahh,int soluongxuat,double dongiaxuat,long thanhtienxuat,float vat,string donvi)
        {




            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {

                ChiTietHD_Xuat cthdx = new ChiTietHD_Xuat();

                cthdx.MAHD_Xuat = mahdx;
                cthdx.MAHH = mahh;
                cthdx.SoLuong_Xuat = soluongxuat;
                cthdx.ThanhTienXuat = thanhtienxuat;
                cthdx.DonGia_Xuat = dongiaxuat;
                cthdx.DonVi = donvi;
                data.ChiTietHD_Xuats.InsertOnSubmit(cthdx);
                data.SubmitChanges();
            }
            
           

        }
        public void xoa1chitiethoadon(string mahh, string mahdxuat) // theo mahh
        {


            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                ChiTietHD_Xuat cthdx = new ChiTietHD_Xuat();
                cthdx = data.ChiTietHD_Xuats.Where(t => t.MAHH == mahh && t.MAHD_Xuat==mahdxuat).FirstOrDefault();

                if (cthdx != null)
                {
                    data.ChiTietHD_Xuats.DeleteOnSubmit(cthdx);
                    data.SubmitChanges();
                }
            }
          
        }
        public void sua1chitiethoadonxuat(string mahdxuat,string mahh,int soluongxuat,long thanhtienxuat, double dongiaxuat)
        {



            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                            var queryChiTietHD_Xuats =
                   from ChiTietHD_Xuats in db.ChiTietHD_Xuats
                   where
                     ChiTietHD_Xuats.MAHD_Xuat ==mahdxuat &&
                     ChiTietHD_Xuats.MAHH == mahh
                   select ChiTietHD_Xuats;
                            foreach (var ChiTietHD_Xuats in queryChiTietHD_Xuats)
                            {
                                ChiTietHD_Xuats.SoLuong_Xuat =soluongxuat;
                                ChiTietHD_Xuats.DonGia_Xuat =dongiaxuat;
                            }
                            db.SubmitChanges();

            }




        }
        public void xoa1chitethoadonall(string mahd)
        {


            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                                var queryChiTietHD_Xuats =
                    from ChiTietHD_Xuats in db.ChiTietHD_Xuats
                    where
                      ChiTietHD_Xuats.MAHD_Xuat == mahd
                    select ChiTietHD_Xuats;
                                foreach (var del in queryChiTietHD_Xuats)
                                {
                                    db.ChiTietHD_Xuats.DeleteOnSubmit(del);
                                }
                                db.SubmitChanges();
                            }

        }

        public List<ChiTietHD_Xuat> kiemtracohoadonxuat(string mahd)
        {

            var ds = (from s in db.ChiTietHD_Xuats where s.MAHD_Xuat == mahd select s).ToList();
            return ds.ToList();
        }
    




        
        public List<ChiTietHD_Xuat> kiemtradulieuchitethoadonxuat(string mahdxuat)
        {
            return db.ChiTietHD_Xuats.Where(t => t.MAHD_Xuat == mahdxuat).ToList();
        }

    }
}