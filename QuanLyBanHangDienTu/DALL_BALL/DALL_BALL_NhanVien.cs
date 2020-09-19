using DALL_BALL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class DALL_BALL_NhanVien
    {
        TuDongTang tt = new TuDongTang();

        QLBanHangDataContext data = new QLBanHangDataContext();
        public IQueryable loaddulieuNhanVien()
        {
            var s = from NhanViens in data.NhanViens
                    select new
                    {

                        NhanViens.MANV,
                        NhanViens.TenNV,
                        NhanViens.GioiTinh,
                        NhanViens.NgaySinh,
                        NhanViens.DiaChi,
                        NhanViens.SDT,
                        NhanViens.NgayVaoLam,
                        NhanViens.NgayKetThuc,
                        NhanViens.ChucVu.TenCv,
                     
                        NhanViens.TinhTrang,

                    };

            return s;
        }
        public List<NhanVienDTO> dsnhanvien()
        {
            List<NhanVienDTO> nvdt = new List<NhanVienDTO>();
            var ds = from k in data.NhanViens
                     select new NhanVienDTO
                     {
                         MANV1 = k.MANV,
                         TenNV1 = k.TenNV,
                         NgaySinh1 = k.NgaySinh,
                         GioiTinh1 = k.GioiTinh,
                         DiaChi1 = k.DiaChi,
                         SDT1 = k.SDT,
                         NgayVaoLam1 = k.NgayVaoLam,
                         TenCV1=k.ChucVu.TenCv,
                         TinhTrang1=k.TinhTrang,


                     };
            return ds.ToList();
        }

        public void them1NhanVien(string maNV, string tenNV, string gt, DateTime ngaysinh, string diachi, string sdt, DateTime ngayVL, string MaCV, string tinhTrang)
        {
            NhanVien lh = new NhanVien();
            lh.MANV = maNV;
            lh.TenNV = tenNV;
            lh.GioiTinh = gt;
            lh.NgaySinh = ngaysinh;
            lh.DiaChi = diachi;
            lh.SDT = sdt;
            lh.NgayVaoLam = (System.DateTime)ngayVL;
            lh.NgayKetThuc = null;
            lh.MaCV = MaCV;
       
            lh.TinhTrang = tinhTrang;
            data.NhanViens.InsertOnSubmit(lh);
            data.SubmitChanges();
        }

        public bool sua1NhanVien(string maNV, string tenNV, string gt, DateTime ngaysinh, string diachi, string sdt, DateTime ngayVL, string MaCV, string tinhTrang)
        {

            NhanVien lh = new NhanVien();
            lh = data.NhanViens.Where(m => m.MANV == maNV).FirstOrDefault();
            if (lh != null)
            {

                lh.TenNV = tenNV;
                lh.GioiTinh = gt;
                lh.NgaySinh = ngaysinh;
                lh.DiaChi = diachi;
                lh.SDT = sdt;
                lh.NgayVaoLam = ngayVL;
                lh.MaCV = MaCV;
                lh.TinhTrang = tinhTrang;
                data.SubmitChanges();
                return true;
            }
            else
                return false;

        }



        public  List<String>  mahdxuattheonv(string manv)
        {
            var ds = from s in data.HoaDon_Xuats.Where(t => t.MANV == manv) select s.MAHD_Xuat;

            return ds.ToList();
        }

        public List<String> mahdnhaptheonv(string manv)
        {
            var ds = from s in data.HoaDon_Nhaps.Where(t => t.MANV == manv) select s.MAHD_Nhap;

            return ds.ToList();
        }




        public void xoa1NhanVien(string maNV)
        {
            //QuanTriNguoiDung a = data.QuanTriNguoiDungs.Where(m => m.MANV == maNV).FirstOrDefault();
            //HoaDon_Nhap b = data.HoaDon_Nhaps.Where(m => m.MANV == maNV).FirstOrDefault();
            //HoaDon_Xuat c = data.HoaDon_Xuats.Where(m => m.MANV == maNV).FirstOrDefault();
            NhanVien lh = data.NhanViens.Where(m => m.MANV == maNV).FirstOrDefault();
            //if (a == null && b == null && c == null && lh != null)
            //{
            data.NhanViens.DeleteOnSubmit(lh);
            data.SubmitChanges();
            //    return true;
            //}
            //else
            //    return false;
        }
        public string getmaNhanVien(string y)
        {


            string x = data.NhanViens.Max(t => t.MANV);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "NV00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "NV0" + (ma + 1).ToString();
            }
            else
                return "";
        }
        public IQueryable LoadChucVu()
        {
            var a = from b in data.ChucVus select b;
            return a;
        }

    
    }

}
