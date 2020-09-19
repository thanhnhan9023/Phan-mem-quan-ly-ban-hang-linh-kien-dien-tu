using DALL_BALL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class DALL_BALL_NhaCungCap
    {
        QLBanHangDataContext db = new QLBanHangDataContext();
        TuDongTang tt = new TuDongTang();
        public IQueryable loaddataNCC()
        {
            var dsncc = from ds in db.NhaCungCaps select new
            {
                ds.MaNC,
                ds.TenNCC,
                ds.DIACHI,
                ds.SDT,
            };

            return dsncc;
        }
        public List<NhaCungCap> loadnhacclist()
        {


            return db.NhaCungCaps.ToList();
        }

        public string getmaNhaCC()
        {

            
                string x = db.NhaCungCaps.Max(t => t.MaNC);
                int ma = int.Parse(x.Substring(x.Length - 3, 3));

                if (ma >= 0 && ma < 9)
                {
                    return "NC00" + (ma + 1).ToString();
                }
                else if (ma >= 9)
                {
                    return "NC0" + (ma + 1).ToString();
                }
                else
                    return "";

            

        }
        public void themNhaCC(string maNCC, string tenNCC, string diaChi, string Sdt, string trangthai)
        {
            NhaCungCap nc = new NhaCungCap
            { 
                MaNC = maNCC,
                TenNCC = tenNCC,
                DIACHI = diaChi,
                SDT = Sdt,
                Trangthai = trangthai
            };
            db.NhaCungCaps.InsertOnSubmit(nc);
            db.SubmitChanges();

        }
        public bool sua1NCC(string maNCC, string tenNCC, string diaChi, string Sdt, string trangthai)
        {

            NhaCungCap nc = new NhaCungCap();
            nc = db.NhaCungCaps.Where(m => m.MaNC == maNCC).FirstOrDefault();
            if (nc != null)
            {

                nc.TenNCC = tenNCC;
                nc.DIACHI = diaChi;
                nc.SDT = Sdt;
                nc.Trangthai = trangthai;
                db.SubmitChanges();
                return true;
            }
            else
                return false;

        }
        public bool xoa1NCC(string maNCC)
        {

            NhaCungCap nc = new NhaCungCap();
            nc = db.NhaCungCaps.Where(m => m.MaNC == maNCC).FirstOrDefault();
            if (nc != null)
            {
                db.NhaCungCaps.DeleteOnSubmit(nc);
                db.SubmitChanges();
                return true;
            }
            else
                return false;

        }
        public IQueryable timkiemnhacuncap(string tim)
        {
            var kq = db.NhaCungCaps.Where(c => c.TenNCC.Contains(tim) || c.MaNC.Contains(tim));
            return kq;
        }

        public List<String> mahdnhaptheonhacc(string mannc)
        {

            var ds= (from vnd in db.HoaDon_Nhaps
                        where vnd.MaNC == mannc
                        select vnd.MAHD_Nhap).ToList();
            return ds.ToList();
        }

        public void updatenhacckhithanthoan(string mancc)
        {
            NhaCungCap ncc = new NhaCungCap();

            ncc = db.NhaCungCaps.Where(t=>t.MaNC==mancc).FirstOrDefault();
            if(ncc!=null)
            {
               ncc.Trangthai="Đã Thanh Toán";
                db.SubmitChanges();
            }

           
        }
     


        public string laytienthanhtoanncc(string mancc)
        {
                            var ds = from HoaDon_Nhaps in
                  (from HoaDon_Nhaps in db.HoaDon_Nhaps
                   where
                     HoaDon_Nhaps.MaNC == mancc &&
                     HoaDon_Nhaps.TinhTrangNhap == "Đã Thanh Toán"
                   select new
                   {
                       HoaDon_Nhaps.TongTien,
                       Dummy = "x"
                   })
                                     group HoaDon_Nhaps by new { HoaDon_Nhaps.Dummy } into g
                                     select new TienNhaCungCapDTO
                                     {
                                         tongtien = g.Sum(p => p.TongTien).ToString()
                                     };

            List<TienNhaCungCapDTO> lst = ds.ToList();
            if (lst.Count > 0)
            {
                return lst[0].tongtien.ToString();
            }
            else
                return "0";

        }
        public string laytiennonhacungcap(string mancc)
        {
            var ds = from HoaDon_Nhaps in
                      (from HoaDon_Nhaps in db.HoaDon_Nhaps
                       where
                        HoaDon_Nhaps.MaNC == mancc &&
                        HoaDon_Nhaps.TinhTrangNhap == "Đang giao dịch"
                       select new
                       {
                           HoaDon_Nhaps.TongTien,
                           Dummy = "x"
                       })
                     group HoaDon_Nhaps by new { HoaDon_Nhaps.Dummy } into g
                     select new TienNhaCungCapDTO
                     {
                         tienno = g.Sum(p => p.TongTien).ToString()
                                       };

            List<TienNhaCungCapDTO> lst = ds.ToList();
            if (lst.Count > 0)
            {
                return lst[0].tienno.ToString();
            }
            else
                return "0";



        }


    }
}
