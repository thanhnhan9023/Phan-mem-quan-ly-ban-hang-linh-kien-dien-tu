using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
   public class DALL_BALL_Phieuthu
    {
        QLBanHangDataContext data = new QLBanHangDataContext();
        public IQueryable loadphieuthu()
        {
            var ds = from k in data.PhieuThus
                     select new
                     {

                         k.MaPhieuThu,
                         k.DoiTuong,
                         k.TrangThai,
                         k.MaNV,
                         k.NhanVien.TenNV,
                         k.Sotienchi,
                         k.Ngayghinhan,
                         k.GhiChu,
                        
                     };
            return ds;
        }
        public List<PhieuThu> loadphieuthulist()
        {
            return data.PhieuThus.ToList();
            
        }
       public void themphieuthikhithanhtoan(string maphieuthu,string doituong,string trangthai,string manv,long sotienthu,DateTime ngayghinhan)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                PhieuThu pt = new PhieuThu();
                pt.MaPhieuThu = maphieuthu;
                pt.DoiTuong = doituong;
                pt.TrangThai = trangthai;
                pt.MaNV = manv;
                pt.Sotienchi = sotienthu;
                pt.Ngayghinhan = ngayghinhan;
                data.PhieuThus.InsertOnSubmit(pt);
                data.SubmitChanges();
            }


          
        }
        public void them1phieuthu(string mapt, string doituong, string trangthai, string manv, long sotienchi, DateTime ngayghinhan,string ghichu)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                PhieuThu pt = new PhieuThu();
                pt.MaPhieuThu = mapt;
                pt.DoiTuong = doituong;
                pt.TrangThai = trangthai;
                pt.MaNV = manv;
                pt.Sotienchi = sotienchi;
                pt.Ngayghinhan = ngayghinhan;
                pt.GhiChu = ghichu;
                data.PhieuThus.InsertOnSubmit(pt);
                data.SubmitChanges();
            }

        }

        public void sua1phieuthu(string mapt, string doituong, string trangthai, string manv, long sotienchi, DateTime ngayghinhan, string ghichu)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                PhieuThu PhieuThus = new PhieuThu();
                PhieuThus = data.PhieuThus.Where(t => t.MaPhieuThu == mapt).FirstOrDefault();

                if(PhieuThus!=null)
                {
                    PhieuThus.DoiTuong = doituong;
                    PhieuThus.TrangThai = trangthai;
                    PhieuThus.MaNV = manv;
                    PhieuThus.Sotienchi = sotienchi;
                    PhieuThus.Ngayghinhan = ngayghinhan;
                    PhieuThus.GhiChu = ghichu;
                    data.SubmitChanges();
                }

            }

        }

        public void xoa1phieuthu(string mapt)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                PhieuThu pt = data.PhieuThus.Where(m => m.MaPhieuThu == mapt).FirstOrDefault();
                if (pt != null)
                {
                    data.PhieuThus.DeleteOnSubmit(pt);
                    data.SubmitChanges();
                }
            }
        }

        public string getmaphieuthu()
        {
            string x = data.PhieuThus.Max(t => t.MaPhieuThu);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "PT00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "PT0" + (ma + 1).ToString();
            }
            else
                return "";

        }

    }
}
