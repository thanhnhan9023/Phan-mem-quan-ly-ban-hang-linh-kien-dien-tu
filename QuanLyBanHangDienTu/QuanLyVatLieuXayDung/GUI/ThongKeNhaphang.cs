using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALL_BALL;
namespace QuanLyVatLieuXayDung.GUI
{
    public partial class ThongKeNhapHang : UserControl
    {
        HoaDonNhapDALL_BALL hdn = new HoaDonNhapDALL_BALL();


        DALL_BALL_NhaCungCap a = new DALL_BALL_NhaCungCap();

        DALL_BALL_Thongke tk = new DALL_BALL_Thongke();
        public ThongKeNhapHang()
        {
            InitializeComponent();
            btnXem.Enabled = false;

        }

        private void ThongKeNhapHang_Load(object sender, EventArgs e)
        {

            load();
        }

        private void btnNgay_Click(object sender, EventArgs e)
        {
            dsHoadon.DataSource = tk.XemThongkeNgay(dateTimePicker1.Value);
            btnXem.Enabled = true;
        }
        public void load()
        {
            dsHoadon.DataSource = tk.loadthongke();
        }
        private void btnNam_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            dsHoadon.DataSource = tk.XemThongkeThang(dateTimePicker1.Value.Month.ToString(), dateTimePicker1.Value.Year.ToString());
        }
    }
}

