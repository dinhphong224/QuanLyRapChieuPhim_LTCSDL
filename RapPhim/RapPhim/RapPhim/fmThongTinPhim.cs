using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapPhim
{

    public partial class fmThongTinPhim : DevComponents.DotNetBar.Metro.MetroForm
    {
        private string trailer;

        public fmThongTinPhim()
        {
            InitializeComponent();
        }

        public fmThongTinPhim(Phim p)
        {
            InitializeComponent();
            lbTen.Text += p.TenPhim;
            lbTheLoai.Text += p.TheLoai;
            lbDaoDien.Text += p.DaoDien;
            lbDienVien.Text += p.DienVien;
            lbNamSX.Text += p.NamSX;
            lbThoiLuong.Text += p.ThoiLuong;
            lbQuocGia.Text += p.QuocGia;
            trailer = p.Trailer;
            rbNoiDung.Text = p.NoiDung;
            pbHinh.Image = RapPhim.doiSize(pbHinh.Size, p.Hinh);
        }

        private void fmThongTinPhim_Load(object sender, EventArgs e)
        {

        }

        private void btTrailer_Click(object sender, EventArgs e)
        {
            try
            {
                sfTrailer.Visible = true;
                btTrailer.Visible = false;
                btSize.Visible = true;
                btClose.Visible = true;
                sfTrailer.Movie = trailer;
            }
            catch (Exception)
            {
                MessageBox.Show("Link trailer hỏng.Vui lòng cập nhật.");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            sfTrailer.Visible = false;
            sfTrailer.Movie = "hellboy";
            btTrailer.Visible = true;
            btSize.Visible = false;
            btClose.Visible = false;
            this.Size = new Size(728, 400);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width/2 - 364, Screen.PrimaryScreen.WorkingArea.Height/2 - 200);
        }

        private void btSize_Click(object sender, EventArgs e)
        {
            if (this.Height == 400)
            {
                this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.Location = new Point(0, 0);
                btSize.Tooltip = "Thu nhỏ";
            }
            else
            {
                this.Size = new Size(728, 400);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - 364, Screen.PrimaryScreen.WorkingArea.Height / 2 - 200);
                btSize.Tooltip = "Phóng to";
            }
        }
    }
}
