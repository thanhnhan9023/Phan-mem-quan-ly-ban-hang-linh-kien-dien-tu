using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL_BALL;

namespace DALL_BALL
{
    public class DALL_QuantriNguoiDung
    {

        QLBanHangDataContext data = new QLBanHangDataContext();

        public IQueryable loaddachsachtaikhoan()
        {
            var ds = from NguoiDungs in data.NguoiDungs
                     select new
                     {
                         NguoiDungs.UserName,
                         NguoiDungs.NhanVien.TenNV,
                         NguoiDungs.NhanVien.ChucVu.TenCv,
                         NguoiDungs.NhanVien.TinhTrang,
                         NguoiDungs.Hoatdong,

                     };
            return ds;
        }

        // load user cho bảng người dùng
        public IQueryable loaduserall()
        {

            var ds = from k in data.NguoiDungs
                     select new
                     {
                         k.UserName,
                         k.NhanVien.TenNV,
                         k.PassWord,
                         k.Hoatdong,
                     };
            return ds;
        }

        public void them1nguoidung(string username, string manv, string password,bool hoatdong)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                NguoiDung nd = new NguoiDung();
                nd.UserName = username;
                nd.MaNV = manv;
                nd.PassWord = password;
                nd.Hoatdong = hoatdong;


                data.NguoiDungs.InsertOnSubmit(nd);
                data.SubmitChanges();
            }

        }
        public bool kiemtrakhoachinh(string username)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                NguoiDung nd = new NguoiDung();
                nd = data.NguoiDungs.Where(t => t.UserName == username).FirstOrDefault();
                if (nd != null)
                {
                    return true;
                }
                else
                    return false;
               
            }
        }
        public void sua1nguoidung(string username, string password,bool hoatdong)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                NguoiDung nd = new NguoiDung();
                nd = data.NguoiDungs.Where(t => t.UserName == username).FirstOrDefault();

                if (nd != null)
                {

                    nd.PassWord = password;
                    nd.Hoatdong = hoatdong;

                    data.SubmitChanges();
                }
            }

        }
        public void resetpassword(string username, bool hoatdong)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                NguoiDung nd = new NguoiDung();
                nd = data.NguoiDungs.Where(t => t.UserName == username).FirstOrDefault();

                if (nd != null)
                {

                    nd.PassWord = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92";
                    nd.Hoatdong = hoatdong;

                    data.SubmitChanges();
                }
            }

        }
        public void xoa1nguoidung(string username)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                NguoiDung nd = new NguoiDung();
                nd = data.NguoiDungs.Where(t => t.UserName == username).FirstOrDefault();
                data.NguoiDungs.DeleteOnSubmit(nd);
                data.SubmitChanges();
            }
        }
        public void xoa1nguoidungTheoNV(string manv)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                NguoiDung nd = new NguoiDung();
                
                nd = data.NguoiDungs.Where(t => t.MaNV == manv).FirstOrDefault();
                if (nd != null)
                {
                    data.NguoiDungs.DeleteOnSubmit(nd);
                    data.SubmitChanges();


                }
                else
                    return;
            }
        }
        public  IQueryable loadnhomnguoidung(string mannd)
        {
            var ds = from k in data.Phanquyennguoidungs.Where(t=>t.Manhomnguoidung==mannd)
                     select new
                     {
                         k.NguoiDung.UserName,
                         k.NguoiDung.NhanVien.TenNV,
                         k.Nhomnguoidung2.Tennhomnguoidung,
                         k.Nhomnguoidung2.Mota,
                         k.Nhomnguoidung2.Manhomnguoidung,
                     };
            return ds;
        }
        public IQueryable loadnhoom()
        {
            var ds = from k in data.Nhomnguoidung2s
                     select new
                     {
                         k.Manhomnguoidung,
                         k.Tennhomnguoidung,
                         k.Mota
                     };
            return ds;
        }
       

        public void themuservaonhomnd(string user,string manhom)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Phanquyennguoidung nnd = new Phanquyennguoidung();

                nnd.UserName = user;
                nnd.Manhomnguoidung = manhom;

                data.Phanquyennguoidungs.InsertOnSubmit(nnd);
                data.SubmitChanges();
            }
        }
        public bool kiemtrakhoachinh(string user,string mand)
        {
            Phanquyennguoidung phanquyen = new Phanquyennguoidung();
            phanquyen = data.Phanquyennguoidungs.Where(t => t.UserName == user ).FirstOrDefault();
            if (phanquyen != null)
            {
                return true;
            }
            else
                return false;


            
        }

        public void xoa1nguoidungrahomnd(string user,string manhomnd)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Phanquyennguoidung nnd = new Phanquyennguoidung();

                nnd = data.Phanquyennguoidungs.Where(t => t.UserName==user && t.Manhomnguoidung==manhomnd).FirstOrDefault();

                if(nnd!=null)
                {
                    data.Phanquyennguoidungs.DeleteOnSubmit(nnd);
                    data.SubmitChanges();
                }
               
            }
        }

        public void them1quyen(string maquyen,string chucnangquyen,string mota)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {

                Quyen quyen = new Quyen();

                quyen.Maquyen = maquyen;
                quyen.Chucnangquyen = chucnangquyen;
                quyen.Mota = mota;

                data.Quyens.InsertOnSubmit(quyen);
                data.SubmitChanges();
            }

        }
        public void sua1quyen (string maquyen,string chucnangquyen,string mota)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Quyen quyen = new Quyen();

                quyen = data.Quyens.Where(t => t.Maquyen == maquyen).FirstOrDefault();

                //quyen.Maquyen = maquyen;
                quyen.Chucnangquyen = chucnangquyen;
                quyen.Mota = mota;
                //data.Quyens.InsertOnSubmit(quyen);
                data.SubmitChanges();
            }
        }
        public void xoa1quyen(string maquyen)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Quyen quyen = new Quyen();

                quyen = data.Quyens.Where(t => t.Maquyen == maquyen).FirstOrDefault();
                if (quyen != null)
                {
                    data.Quyens.DeleteOnSubmit(quyen);
                    data.SubmitChanges();
                }
            }
        }


        public string getmaquyentutang() //auto ma quyen tang
        {
            string x = data.Quyens.Max(t => t.Maquyen);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "QH00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "QH0" + (ma + 1).ToString();
            }
            else
                return "";

        }

        public string getmanhomndtutang() //auto manhomndtang
        {
            string x = data.Nhomnguoidung2s.Max(t => t.Manhomnguoidung);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "ND00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "ND0" + (ma + 1).ToString();
            }
            else
                return "";

        }

        public void  them1nhomnd(string manhonnd,string tennhomnguoidung,string mota)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Nhomnguoidung2 ndn = new Nhomnguoidung2();
                ndn.Manhomnguoidung = manhonnd;
                ndn.Tennhomnguoidung = tennhomnguoidung;
                ndn.Mota = mota;

                data.Nhomnguoidung2s.InsertOnSubmit(ndn);
                data.SubmitChanges();
            }
        }
        public void sua1nhomnd(string mand,string tennhomnd,string mota)
        {

            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Nhomnguoidung2 ndn = new Nhomnguoidung2();
                ndn = data.Nhomnguoidung2s.Where(t => t.Manhomnguoidung == mand).FirstOrDefault();
                if (ndn != null)
                {
                    ndn.Tennhomnguoidung = tennhomnd;
                    ndn.Mota = mota;
                    data.SubmitChanges();
                }
            }

        }
        public void xoa1nhomnd(string mand)
        {
            using (QLBanHangDataContext data = new QLBanHangDataContext())
            {
                Nhomnguoidung2 ndn = new Nhomnguoidung2();
                ndn = data.Nhomnguoidung2s.Where(t => t.Manhomnguoidung == mand).FirstOrDefault();
                if (ndn != null)
                {

                    data.Nhomnguoidung2s.DeleteOnSubmit(ndn);
                    data.SubmitChanges();
                }
            }
          
        }
           

    }
}
