using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class DALL_BALL_DonHang
    {
        QLBanHangDataContext data = new QLBanHangDataContext();
        public IQueryable loaddonhang()
        {

            var ds = from DonHangs in data.DonHangs
                     select new
                     {
                         DonHangs.MaDH,
                         DonHangs.KhachHang.MaKH,
                         DonHangs.KhachHang.TenKH,
                         DonHangs.Ngaydathang,
                         DonHangs.Tongtien,
                         DonHangs.KhachHang.DiaChi,
                         DonHangs.KhachHang.SDT,
                         DonHangs.Tinhtrang
                     };
            return ds;
        }

        public List<Chitietdonhang> loaddschitietdondathang(string madh)
        {

            List<Chitietdonhang> lst = new List<Chitietdonhang>();
            var ds = from Chitietdondathangs in data.Chitietdondathangs
                     where Chitietdondathangs.MaDH == madh
                     select (new Chitietdonhang
                     {
                         TenHH = Chitietdondathangs.HangHoa.TenHH,
                         Soluong =(int)Chitietdondathangs.Soluong,
                         Duongdan=Chitietdondathangs.HangHoa.Duongdan,
                         Giaban=(float)Chitietdondathangs.Giaban
                 
                         
                     });
            lst = ds.ToList();

            return lst;
            
                     
                      
                    

        }
        public void update(string madh,string tinhtrang)
        {
            var queryDonHangs =
    from DonHangs in data.DonHangs
    where
      DonHangs.MaDH == madh
    select DonHangs;
            foreach (var DonHangs in queryDonHangs)
            {
                DonHangs.Tinhtrang=tinhtrang;
            }
            data.SubmitChanges();

        }
        public void deletechitietdh(string madh)
        {
                        var queryChitietdondathangs =
                from Chitietdondathangs in data.Chitietdondathangs
                where
                  Chitietdondathangs.MaDH == madh
                select Chitietdondathangs;
                        foreach (var del in queryChitietdondathangs)
                        {
                            data.Chitietdondathangs.DeleteOnSubmit(del);
                        }
                        data.SubmitChanges();

        }
        public void deletedonhang(string madh)
        {
                        var queryDonHangs =
                from DonHangs in data.DonHangs
                where
                  DonHangs.MaDH ==madh
                select DonHangs;
                        foreach (var del in queryDonHangs)
                        {
                            data.DonHangs.DeleteOnSubmit(del);
                        }
                        data.SubmitChanges();

        }
    }

}
