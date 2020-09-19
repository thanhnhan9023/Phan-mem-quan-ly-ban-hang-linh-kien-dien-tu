using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class DALL_BALL_KhachHang
    {
        TuDongTang tt = new TuDongTang();
        QLBanHangDataContext db = new QLBanHangDataContext();
        public IQueryable getdskhachhang()
        {
            var ds = from KhachHangs in db.KhachHangs
                     select new
                     {
                         KhachHangs.MaKH,
                         KhachHangs.TenKH,
                         KhachHangs.Ngaysinh,
                         KhachHangs.DiaChi,
                         KhachHangs.SDT,
                         KhachHangs.GioiTinh,
                         KhachHangs.LoaiKhachHang.Tenloaikh   
                     };

            return ds;


        }
        public List<KhachHang> loadallkh()
        {
            return db.KhachHangs.ToList();
        }




        public void them1khachhang(string makh, string tenkh, string diachi, string SDT, string gioitinh, string maloaikh,DateTime ngaysinh)
        {
            KhachHang iKhachHangs = new KhachHang
            {
                MaKH = makh,
                TenKH = tenkh,
                DiaChi = diachi,
                SDT = SDT,
                GioiTinh = gioitinh,
                Maloaikh = maloaikh,
                Ngaysinh = ngaysinh
                  
            };
            db.KhachHangs.InsertOnSubmit(iKhachHangs);
            db.SubmitChanges();

        }

        public void sua1khachhang(string makh, string tenkh, string diachi, string SDT, string gioitinh, string maloaikh,DateTime ngaysinh)
        {
            var queryKhachHangs =
    from KhachHangs in db.KhachHangs
    where
      KhachHangs.MaKH == makh
    select KhachHangs;
            foreach (var KhachHangs in queryKhachHangs)
            {
                KhachHangs.TenKH = tenkh;
                KhachHangs.DiaChi = diachi;
                KhachHangs.SDT = SDT;
                KhachHangs.GioiTinh = gioitinh;
                KhachHangs.Maloaikh = maloaikh;
                KhachHangs.Ngaysinh = ngaysinh;


            }
            db.SubmitChanges();

        }

        public void xoa1khachhang(string makh)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                KhachHang kh = new KhachHang();
                kh = db.KhachHangs.Where(t => t.MaKH == makh).FirstOrDefault();
                if (kh != null)
                {

                    db.KhachHangs.DeleteOnSubmit(kh);
                    db.SubmitChanges();
                }
            }


        }

        public List<String> getmadh(string makh)
        {
            var ds = from s in db.DonHangs.Where(t => t.MaKH == makh) select s.MaDH;

            return ds.ToList();

        }
        public void xoa1userkhachhang(string makh)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                UserKhachHang user = new UserKhachHang();
                user = db.UserKhachHangs.Where(t => t.MaKH == makh).FirstOrDefault();
                if (user != null)
                {
                    db.UserKhachHangs.DeleteOnSubmit(user);
                    db.SubmitChanges();
                }
            }

        }

        public string getmakhachhang(string y)
        {
            string x = db.KhachHangs.Max(t => t.MaKH);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "KH00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "KH0" + (ma + 1).ToString();
            }
            else
                return "";

        }
        public class Tontienkhachang
        {
            public string tongtien { get; set; }
            public string tienno { get; set; }
         


        }
        public List<Tontienkhachang> laydulieutongtien(string makh)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var ds = from KhachHangs in
              (from HoaDon_Xuats in db.HoaDon_Xuats
               where
                HoaDon_Xuats.MAKH == makh
               select new
               {
                   HoaDon_Xuats.TongTien,
                   Dummy = "x"
               })
                         group KhachHangs by new { KhachHangs.Dummy } into g
                         select new Tontienkhachang
                         {
                             tongtien = g.Sum(p => p.TongTien).ToString()
                         };
                return ds.ToList();
            }
        }
        public string laytienkhachhangthanhtoan(string makh)
        {
            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var ds = from HoaDon_Xuats in
              (from HoaDon_Xuats in db.HoaDon_Xuats
               where
                HoaDon_Xuats.MAKH == makh &&
                HoaDon_Xuats.TinhTrangXuat == "Đã  Thanh Toán"
               select new
               {
                   HoaDon_Xuats.TongTien,
                   Dummy = "x"
               })
                         group HoaDon_Xuats by new { HoaDon_Xuats.Dummy } into g
                         select new Tontienkhachang
                         {
                             tongtien = g.Sum(p => p.TongTien).ToString()
                         };

                List<Tontienkhachang> lst = ds.ToList();
                if (lst.Count > 0)
                {
                    return lst[0].tongtien.ToString();
                }
                else
                    return "0";
            }
        }


        public string laytienkhachhangno(string makh)
        {

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var ds = from HoaDon_Xuats in
              (from HoaDon_Xuats in db.HoaDon_Xuats
               where
                HoaDon_Xuats.MAKH == makh &&
                HoaDon_Xuats.TinhTrangXuat == "Đang giao dịch"
               select new
               {
                   HoaDon_Xuats.TongTien,
                   Dummy = "x"
               })
                         group HoaDon_Xuats by new { HoaDon_Xuats.Dummy } into g
                         select new Tontienkhachang
                         {
                             tienno = g.Sum(p => p.TongTien).ToString()
                         };

                List<Tontienkhachang> lst = ds.ToList();
                if (lst.Count > 0)
                {
                    return lst[0].tienno.ToString();
                }
                else
                    return "0";
            }
        }

        public List<string> laycongnokhachhang()
        {

            using (QLBanHangDataContext db = new QLBanHangDataContext())
            {
                var ds = from HoaDon_Xuats in db.HoaDon_Xuats.Where(t => t.TinhTrangXuat == "Đang giao dịch") select HoaDon_Xuats.MAKH;

                return ds.ToList();
            }
                  
        }
        

    }
                    

    
       
            
           
            
       
    
}
