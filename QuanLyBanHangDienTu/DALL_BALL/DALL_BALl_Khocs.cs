using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
   public class DALL_BALl_Khocs
    {
        QLBanHangDataContext data = new QLBanHangDataContext();
        public IQueryable loadulieukho()
        {
            var ds = from k in data.Khos select new { k.IDKho, k.HangHoa.TenHH, k.SoLuong };
            return ds;
        }
        public void xoa1kho(string makho)
        {
            Kho kh = new Kho();
            kh = data.Khos.Where(t => t.IDKho == makho).FirstOrDefault();
            data.Khos.DeleteOnSubmit(kh);
            data.SubmitChanges();
        }
        public IQueryable loadkhotheoloai(string maloai)
        {
            var ds = from Khos in data.Khos
                     where
                       Khos.HangHoa.LoaiHang.MaLoai == maloai
                     select new
                     {
                         Khos.IDKho,
                         Khos.HangHoa.TenHH,
                         Khos.SoLuong
                     };
            return ds;
        }

        public List<int> laysoluonghanghoahientai(string mahh, string mahdnhap)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {

                var ds = from ChiTietHD_Nhaps in data.ChiTietHD_Nhaps.Where(t => t.MAHH == mahh && t.MAHD_Nhap == mahdnhap)
                         select ChiTietHD_Nhaps.SoLuong_Nhap.Value;
                return ds.ToList();
            }
        }

        public void updatekho(string mahh,string mahdnhap)
        {
            List<int> lst = new List<int>();
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
               
                lst = laysoluonghanghoahientai(mahh, mahdnhap);
                var queryKhos =
        from Khos in data.Khos
        where
          Khos.MAHH == mahh
        select Khos;
                foreach (var Khos in queryKhos)
                {
                    Khos.SoLuong = Khos.SoLuong + lst[0];
                }
                data.SubmitChanges();
            }

        }










    }





    
}
