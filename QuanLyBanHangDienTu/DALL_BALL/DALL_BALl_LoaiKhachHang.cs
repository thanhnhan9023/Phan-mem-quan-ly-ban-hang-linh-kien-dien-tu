using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
  public  class DALL_BALl_LoaiKhachHang
    {

        QLBanHangDataContext db = new QLBanHangDataContext();
        TuDongTang tt = new TuDongTang();
        public IQueryable<LoaiKhachHang> getloaikh()
        {

            return db.LoaiKhachHangs.Select(t => t);
        }

        public void them1loaikhachhang(string maloaikh, string tenloaikh)
        {
            LoaiKhachHang iLoaiKhachHangs = new LoaiKhachHang();

            iLoaiKhachHangs.Maloaikh = maloaikh;
            iLoaiKhachHangs.Tenloaikh = tenloaikh;
            iLoaiKhachHangs.soluongkh = 0;

            db.LoaiKhachHangs.InsertOnSubmit(iLoaiKhachHangs);
            db.SubmitChanges();



        }

        public void sua1loaikhachhang(string maloaikh, string tenloaikh)
        {
            var queryLoaiKhachHangs =
            from LoaiKhachHangs in db.LoaiKhachHangs
            where
              LoaiKhachHangs.Maloaikh == maloaikh
            select LoaiKhachHangs;
            foreach (var LoaiKhachHangs in queryLoaiKhachHangs)
            {
                LoaiKhachHangs.Tenloaikh = tenloaikh;
            }
            db.SubmitChanges();

        }

        public void xoa1loaikhachang(string loaikh)
        {
            var queryLoaiKhachHangs =
    from LoaiKhachHangs in db.LoaiKhachHangs
    where
      LoaiKhachHangs.Maloaikh == loaikh
    select LoaiKhachHangs;
            foreach (var del in queryLoaiKhachHangs)
            {
                db.LoaiKhachHangs.DeleteOnSubmit(del);
            }
            db.SubmitChanges();
        }

        public string laymatudongtangkhachhang()
        {

            string x = db.LoaiKhachHangs.Max(t => t.Maloaikh);
            return tt.laymatudongtang(x, "LK00");
        }


    }
}
