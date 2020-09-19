using DALL_BALL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class DALL_BALL_HangHoa
    {
        QLBanHangDataContext db = new QLBanHangDataContext();
        TuDongTang tt = new TuDongTang();
        public IQueryable loadhanghoa()
        {

            var ds = from HangHoas in db.HangHoas
                     select new
                     {
                         HangHoas.MaHH,
                         HangHoas.TenHH,
                         HangHoas.MoTa,
                         HangHoas.Giabanle,
                         HangHoas.Giabansi,
                         HangHoas.Gianhap,
                         HangHoas.LoaiHang.TenLoai,
                         HangHoas.Duongdan,
                         HangHoas.DonViTinh,

                     };

            return ds;



        }
        public List<HangHoa> loadhh2()
        {

            return db.HangHoas.ToList();
        }
        public void them1loaihanghoa(string mahh, string maloai, string duongdan, string tenhh, string donvitinh, string mota, float giabanle, float giabansi, float gianhap )
        {
            HangHoa iHangHoas = new HangHoa
            {
                MaHH = mahh,
                MaLoai = maloai,
                Duongdan = duongdan,
                TenHH = tenhh,
                DonViTinh = donvitinh,
                MoTa = mota,
                Giabanle = giabanle,
                Giabansi = giabansi,
                Gianhap = gianhap,

            };
            db.HangHoas.InsertOnSubmit(iHangHoas);
            db.SubmitChanges();

        }
        public void xoa1hanghoa(string mahh)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                HangHoa hanghoa = new HangHoa();

                hanghoa = data.HangHoas.Where(t => t.MaHH == mahh).FirstOrDefault();
                if (hanghoa != null)
                {
                    data.HangHoas.DeleteOnSubmit(hanghoa);
                    data.SubmitChanges();
                }
            }
                
        }
        public List<String> laymahdondat(string mahh)
        {
            var ds = from k in db.Chitietdondathangs.Where(t => t.MAHH == mahh) select k.MaDH;
            return ds.ToList();
        }
        public void xoa1hanghoatrongkho(string mahh)
        {
            Kho kh = new Kho();
            kh = db.Khos.Where(t => t.MAHH == mahh).FirstOrDefault();
            if (kh != null)
            {
                db.Khos.DeleteOnSubmit(kh);
                db.SubmitChanges();
            }


        }
        public List<string> laymahdnhap(string mahh)
        {
            
            var ds = from k in db.ChiTietHD_Nhaps.Where(t => t.MAHH==mahh) select k.MAHD_Nhap;
            return ds.ToList();

        }

        public List<string> laymahdxuat(string mahh)
        {
            var ds = from k in db.ChiTietHD_Xuats.Where(t => t.MAHH == mahh) select k.MAHD_Xuat;
            return ds.ToList();
        }
        public void xoahanghoatrongchitiethdnhap(string mahh,string mahdnhap)
        {
          
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                
                ChiTietHD_Nhap chitiethdnhap = new ChiTietHD_Nhap();
                chitiethdnhap = data.ChiTietHD_Nhaps.Where(t => t.MAHH == mahh && t.MAHD_Nhap==mahdnhap).FirstOrDefault();
                if (chitiethdnhap != null)
                {
                    data.ChiTietHD_Nhaps.DeleteOnSubmit(chitiethdnhap);
                    data.SubmitChanges();
                }
            }
            

        }


        public void xoahanghoatrongchitietđonat(string mahh, string mahdnhap)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {

                Chitietdondathang chitiethdnhap = new Chitietdondathang();
                chitiethdnhap = data.Chitietdondathangs.Where(t => t.MAHH == mahh && t.MaDH == mahdnhap).FirstOrDefault();
                if (chitiethdnhap != null)
                {
                    data.Chitietdondathangs.DeleteOnSubmit(chitiethdnhap);
                    data.SubmitChanges();
                }
            }


        }
        public void xoahanghoatrongchitiethdxuat(string mahh,string madhdxuat)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                ChiTietHD_Xuat chitiethdnhap = new ChiTietHD_Xuat();
                chitiethdnhap = data.ChiTietHD_Xuats.Where(t => t.MAHH == mahh && t.MAHD_Xuat == madhdxuat).FirstOrDefault();
                if (chitiethdnhap != null)
                {
                    data.ChiTietHD_Xuats.DeleteOnSubmit(chitiethdnhap);
                    data.SubmitChanges();
                }
            }
        }

        public IQueryable loadhanghoaandlh()
        {
            var ds = from HangHoas in db.HangHoas
                     join c in db.Khos on HangHoas.MaHH equals c.MAHH

                     select new
                     {
                         HangHoas.MaHH,
                         HangHoas.TenHH,
                         HangHoas.DonViTinh,
                         HangHoas.Duongdan,
                         HangHoas.MoTa,
                         HangHoas.Giabanle,
                         HangHoas.Giabansi,
                         HangHoas.Gianhap,
                         HangHoas.MaLoai,
                         c.SoLuong,        
                         HangHoas.LoaiHang.TenLoai,




                     };
            return ds;
        }

        public void sua1hh(string mahh, string maloai, string duongdan, string tenhh, string donvitinh, string mota, float giabanle, float giabansi, float gianhap)
        {
            var queryHangHoas =
       from HangHoas in db.HangHoas
       where
         HangHoas.MaHH == mahh
       select HangHoas;
            foreach (var HangHoas in queryHangHoas)
            {
                HangHoas.MaHH = mahh;
                HangHoas.TenHH = tenhh;
                HangHoas.DonViTinh = donvitinh;
                HangHoas.Duongdan = duongdan;
                HangHoas.MoTa = mota;
                HangHoas.Giabansi = giabansi;
                HangHoas.Giabanle = giabanle;
                HangHoas.Gianhap = gianhap;
                HangHoas.MaLoai =maloai;
            }
            db.SubmitChanges();


        }
        public string getmahhtutang()
        {
            string x = db.HangHoas.Max(t => t.MaHH);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "HH00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "HH0" + (ma + 1).ToString();
            }
            else
                return "";

        }

        public List<Kho> loadsoluongtonkho(string mahh)
        {

            return db.Khos.Where(t => t.MAHH == mahh).ToList();


        }

        public string loadgianhap(string mahh)
        {
            List<HangHoa> hh = new List<HangHoa>();


            hh = db.HangHoas.Where(t => t.MaHH == mahh).ToList();
            return hh[0].Gianhap.ToString();
        }

        public string loadgiaban(string mahh)
        {
            List<HangHoa> hh = new List<HangHoa>();

            hh = db.HangHoas.Where(t => t.MaHH == mahh).ToList();
            return hh[0].Giabanle.ToString();



        }

        public IQueryable loadkho()
        {
            var ds = from Khos in db.Khos
                     select new
                     {
                         Khos.HangHoa.MaHH,
                         Khos.HangHoa.TenHH,
                         Khos.HangHoa.DonViTinh,
                         Khos.HangHoa.Duongdan,
                         Khos.HangHoa.Giabanle,
                         Khos.HangHoa.Giabansi,
                         Khos.HangHoa.Gianhap,
                         Khos.SoLuong,



                     };
            return ds;
        }

        public List<HangHoaDT0> listloadhtheokho()
        {
            
                var ds = from Khos in db.Khos
                         select new HangHoaDT0 
                         {
                           mahh= Khos.HangHoa.MaHH,
                             tenhh=Khos.HangHoa.TenHH,
                             donvitinh=Khos.HangHoa.DonViTinh,
                             duongdan=Khos.HangHoa.Duongdan,
                             giabanle=Khos.HangHoa.Giabanle,
                             giabansi=(double)Khos.HangHoa.Giabansi,
                             gianhap=(double)Khos.HangHoa.Gianhap,
                             soluong=Khos.SoLuong,

                             
                         };

            return ds.ToList();
        }
    }
    }
