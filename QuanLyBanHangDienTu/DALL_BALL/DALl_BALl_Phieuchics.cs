using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
 public   class DALl_BALl_Phieuchics
    {
        QLBanHangDataContext data = new QLBanHangDataContext();
      
        public IQueryable loadphieuchi()
        {
           
                var ds = from k in data.PhieuChis
                         select new
                         {

                             k.MaPhieuChi,
                             k.DoiTuong,
                             k.TrangThai,
                             k.MaNV,
                             k.NhanVien.TenNV,
                             k.Sotienchi,
                             k.NgayGhiNhan,
                             k.GhiChu,
                         };
                return ds;
           
           
        }
        public List<PhieuChi> loadphieuchilist()
        {
            return data.PhieuChis.ToList();

        }

        public void them1phieuchi(string mapc,string manv,string doituong,DateTime ngaylap,string trangthai,long sotienchi,string ghichu)
        {
          
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                PhieuChi pc = new PhieuChi();
                pc.MaPhieuChi = mapc;
                pc.MaNV = manv;
                pc.NgayGhiNhan = ngaylap;
                pc.TrangThai = trangthai;
                pc.Sotienchi = sotienchi;
                pc.DoiTuong = doituong;
                pc.GhiChu = ghichu;
                data.PhieuChis.InsertOnSubmit(pc);
                data.SubmitChanges();
            }

        }
        public void sua1phieuchi(string mapc, string manv, string doituong, DateTime ngaylap, string trangthai, long sotienchi, string ghichu)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                PhieuChi pc = new PhieuChi();
                pc = data.PhieuChis.Where(t => t.MaPhieuChi == mapc).FirstOrDefault();
                if (pc != null)
                {
                    pc.MaNV = manv;
                    pc.NgayGhiNhan = ngaylap;
                    pc.TrangThai = trangthai;
                    pc.Sotienchi = sotienchi;
                    pc.DoiTuong = doituong;
                    pc.GhiChu = ghichu;

                    data.SubmitChanges();
                }
            }
        }
        public void xoa1phieuchi(string mapt)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                
                PhieuChi pt = data.PhieuChis.Where(m => m.MaPhieuChi == mapt).FirstOrDefault();
                if (pt != null)
                {
                    data.PhieuChis.DeleteOnSubmit(pt);
                    data.SubmitChanges();
                }
            }
        }

        public string getmaphieuthu()
        {
            string x = data.PhieuChis.Max(t => t.MaPhieuChi);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "PC00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "PC0" + (ma + 1).ToString();
            }
            else
                return "";

        }

    }


}
