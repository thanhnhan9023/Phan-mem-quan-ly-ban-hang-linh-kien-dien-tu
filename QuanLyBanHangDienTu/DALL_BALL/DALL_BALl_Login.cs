using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DALL_BALL;
namespace DALL_BALL
{
    public class DALL_BALL_Login
    {
        QLBanHangDataContext data = new QLBanHangDataContext();

        public List<NguoiDung> login(string username, string passwrod)
        {
            var ds = from NguoiDungs in data.NguoiDungs
                     where
                       NguoiDungs.UserName == username &&
                       NguoiDungs.PassWord == passwrod
                     select NguoiDungs;
            return ds.ToList();
        }
        public string SHA256(string password)
        {
            try
            {
                SHA256Managed crypt = new SHA256Managed();
                string hash = string.Empty;
                byte[] crypyo = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
                foreach (byte item in crypyo)
                {
                    hash += item.ToString("x2");
                }
                return hash;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public string laymacvtuusser(string username)


        {

            string ds = (from NguoiDungs in data.NguoiDungs
                         where
                           NguoiDungs.UserName == username
                         select NguoiDungs.NhanVien.MaCV).FirstOrDefault();

            return ds.ToString();



        }

        public string laymanvtuusername(string username)
        {
            string ds = (from NguoiDungs in data.NguoiDungs
                         where
                           NguoiDungs.UserName == username
                         select NguoiDungs.MaNV).FirstOrDefault();
            return ds;
        }
    }
    
}
