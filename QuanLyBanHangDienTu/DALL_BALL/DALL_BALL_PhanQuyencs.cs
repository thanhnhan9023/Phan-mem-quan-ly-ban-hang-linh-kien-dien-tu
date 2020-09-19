using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class DALL_BALL_PhanQuyencs
    {
        QLBanHangDataContext data = new QLBanHangDataContext();

        public string nhomnguoidung(string username)
        {
            List<Phanquyennguoidung> ds = (from k in data.Phanquyennguoidungs.Where(t => t.UserName == username) select k).ToList();
            if (ds.Count > 0)
            {
                return ds[0].Manhomnguoidung;
            }
            else
            {
                return "";
            }
        

        }

        public bool kiemtraquyenmanhinh(string manhomngd,string maquyen)
        {
            var ds = from k in data.Phanquyennhoms.Where(t => t.Manhomnguoidung == manhomngd && t.Maquyen==maquyen) select k;

            List<Phanquyennhom> lst = new List<Phanquyennhom>();
            lst = ds.ToList();

            if (lst.Count > 0)
            {
                return lst[0].Quyenhan.Value;
            }
            else
                return false;
            
        }
        
        // load dach sách quyền
        public IQueryable loadquyen()
        {
            var ds = from k in data.Quyens
                     select new
                     {
                         k.Maquyen,
                         k.Chucnangquyen,
                         k.Mota
                     };
            return ds;
        }
        // load nhom nguoidung

        public IQueryable loadnhomnguoidung()
        {
            var ds = from k in data.Nhomnguoidung2s
                     select new
                     {
                         k.Manhomnguoidung,
                         k.Tennhomnguoidung,
                         k.Mota,
                     };
            return ds;
        }

        public IQueryable loadallquyendaco(string mand)

        {
           
                var ds = from k in data.Phanquyennhoms.Where(t => t.Manhomnguoidung == mand)
                         select new
                         {
                             k.Maquyen,
                             k.Quyen.Chucnangquyen,
                             k.Quyen.Mota,

                         };



                return ds;
            
        }
        public IQueryable loadallquyenchuaco(string mand)
        {
           
                var ds = from Quyens in data.Quyens
                         where
                           !
                             (from Phanquyennhoms in data.Phanquyennhoms
                              where
                    Phanquyennhoms.Manhomnguoidung == mand
                              select new
                              {
                                  Phanquyennhoms.Maquyen
                              }).Contains(new { Maquyen = Quyens.Maquyen })
                         select new
                         {
                             Maquyen = Quyens.Maquyen,
                             Chucnangquyen = Quyens.Chucnangquyen,
                             Mota = Quyens.Mota
                         };

                return ds;
            
                 
        }


        public void them1quyenchonhomnd(string  Mand,string maquyen,bool quyen )
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Phanquyennhom pq = new Phanquyennhom();
                pq.Manhomnguoidung = Mand;
                pq.Maquyen = maquyen;
                pq.Quyenhan = quyen;

                data.Phanquyennhoms.InsertOnSubmit(pq);
                data.SubmitChanges();
            }
        }
        public void xoa1quyenchonhomnd(string  mand,string maquyen)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Phanquyennhom pq = new Phanquyennhom();
                pq = data.Phanquyennhoms.Where(t => t.Maquyen == maquyen).FirstOrDefault();
                if (pq != null)
                {
                    data.Phanquyennhoms.DeleteOnSubmit(pq);
                    data.SubmitChanges();
                }
            }
        }
    }

}

