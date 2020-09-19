using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
 public   class DALl_BALL_Cv
    {
        QLBanHangDataContext data = new QLBanHangDataContext();

       public List<ChucVu> loadcv()
        {
            return data.ChucVus.ToList();
        }
        public string getmachucvu()
        {

            string x = data.ChucVus.Max(t => t.MaCv);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "CV00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "CV0" + (ma + 1).ToString();
            }
            else
                return "";



        }
        public void xoa1cv(string macv)
        {
            ChucVu cv = new ChucVu();
            cv = data.ChucVus.Where(t => t.MaCv == macv).FirstOrDefault();

            if(cv!=null)
                {
                data.ChucVus.DeleteOnSubmit(cv);
                data.SubmitChanges();

                }
        }
        public void them1cv(string macv,string tencv)
        {
            ChucVu cv = new ChucVu();
            cv.MaCv = macv;
            cv.TenCv = tencv;
            data.ChucVus.InsertOnSubmit(cv);
            data.SubmitChanges();
        }
        public void sua1cv(string macv,string tencv)
        {

            ChucVu cv = new ChucVu();
            cv = data.ChucVus.Where(t=>t.MaCv==macv).FirstOrDefault();
            if (cv != null)
            {
                cv.TenCv = tencv;
                data.SubmitChanges();
            }
        }
    }


    
}
