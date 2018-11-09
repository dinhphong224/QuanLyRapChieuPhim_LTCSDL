using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Data.SqlClient;

namespace RapPhim
{
    public partial class RapPhim : DevComponents.DotNetBar.Metro.MetroForm
    {
        int a = 3, toaDoX, toaDoY;
        Random rd = new Random();
        String path = "";
        bool layHinh = false;
        bool tangSize = true;
        bool tangSizeGD = true;
        Stack<String> duongDy = new Stack<string>();
        Stack<DuLieu> dulieu = new Stack<DuLieu>();
        String loai = "";
        int chon = 0;
        public RapPhim()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectDatabase();
            loadPhim();
            //  sfBanner.Movie = Application.StartupPath + "\\logo.xyz";
            //  sfLogo.Movie = Application.StartupPath + "\\abc.xyz";
            sfBanner.Movie = Application.StartupPath + "\\logo.jpg";
            sfLogo.Movie = Application.StartupPath + "\\abc.jpg";
            //
            tbMatKhau.PasswordChar = '*';
            cbTim.SelectedIndex = 0;
            tbTenDN.Focus();
            //
            /////
            ////
            //loadTableNV();
            //cbTimNV.SelectedIndex = 0;
            //cbChucVuNV.SelectedIndex = 0;
            //dtNgaySinhNV.MaxDate = DateTime.Now;
            //loadTablePhim();
            //loadTableLC();
            //cbTimPhim.SelectedIndex = 0;
            //dtCNNgayChieu.MinDate = DateTime.Now;
            //for (int i = 0; i < 24; i++)
            //    cbGio.Items.Add(new DevComponents.Editors.ComboItem(i.ToString()));
            //for (int i = 0; i < 59; i++)
            //    cbPhut.Items.Add(new DevComponents.Editors.ComboItem(i.ToString()));
            //loadTableLV();
            //loadTablePC();
            ////
            ///

            //dtTKNgay.MaxDate = DateTime.Now;
            //dtTKNgayBD.MaxDate = DateTime.Now;
            //dtTKNgayKT.MaxDate = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int i = rd.Next(0, 7);
            if (i == 0)
                tcPhim.ItemContentAnimation = TileItemContentAnimationType.Fade;
            if (i == 1)
                tcPhim.ItemContentAnimation = TileItemContentAnimationType.RandomSegmentedFade;
            if (i == 2)
                tcPhim.ItemContentAnimation = TileItemContentAnimationType.ScrollDown;
            if (i == 3)
                tcPhim.ItemContentAnimation = TileItemContentAnimationType.ScrollLeft;
            if (i == 4)
                tcPhim.ItemContentAnimation = TileItemContentAnimationType.ScrollRight;
            if (i == 5)
                tcPhim.ItemContentAnimation = TileItemContentAnimationType.ScrollTop;
            if (i == 6)
                tcPhim.ItemContentAnimation = TileItemContentAnimationType.SegmentedFade;
        }

        private void RapPhim_Resize(object sender, EventArgs e)
        {
            toaDoX = pnDangNhap.Location.X + (pnDangNhap.Size.Width) - pnNguoiDung.Width;
            toaDoY = pnDangNhap.Location.X;
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            dangNhap();
        }

        private void btTimLichPhim_Click(object sender, EventArgs e)
        {

        }

        private void tbTenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) && tbTenDN.Text.Trim() != "")
                tbMatKhau.Focus();
            if (e.KeyCode == Keys.Up && tbTenDN.Text.Trim() != "")
                tbMatKhau.Focus();

        }

        private void tbMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && tbMatKhau.Text.Trim() != "")
                tbTenDN.Focus();
            if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) && tbMatKhau.Text.Trim() != "")
                btDangNhap.Focus();

        }

        private void tbMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dangNhap();
        }

        private void tbTenDN_TextChanged(object sender, EventArgs e)
        {
            setErr(erTenDN, tbTenDN, "Tên đăng nhập trống!");
        }

        private void tbMatKhau_TextChanged(object sender, EventArgs e)
        {
            setErr(erMatKhau, tbMatKhau, "Mật khẩu trống!");
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RapPhim rap = new RapPhim();
            rap.Show();
        }

        private void RapPhim_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn = null;
            Application.Exit();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            timPhim();
        }

        private void dvPhim_SelectionChanged(object sender, EventArgs e)
        {
            loadThongTinPhim();
        }

        private void btThemPhim_Click(object sender, EventArgs e)
        {
            clearPhim();
            setEnabledPhim(false);
            pnCapNhatPhim.Enabled = false;
            btHinhPhim.Visible = true;
            btLuuPhim.Visible = true;
            btHuyPhim.Visible = true;
            dvPhim.Enabled = false;
            tbMaPhim.Focus();

        }

        private void btSuaPhim_Click(object sender, EventArgs e)
        {
            loadThongTinPhim();
            setEnabledPhim(false);
            pnCapNhatPhim.Enabled = false;
            btHinhPhim.Visible = true;
            btLuuPhim.Visible = true;
            btHuyPhim.Visible = true;
            tbMaPhim.ReadOnly = true;
            dvPhim.Enabled = false;
            tbTenPhim.Focus();
        }

        private void btHuyPhim_Click(object sender, EventArgs e)
        {
            setEnabledPhim(true);
            pnCapNhatPhim.Enabled = true;
            btHinhPhim.Visible = false;
            btLuuPhim.Visible = false;
            btHuyPhim.Visible = false;
            layHinh = false;
            dvPhim.Enabled = true;
            clearPhim();
            loadThongTinPhim();
        }

        private void btXoaPhim_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa phim đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String maPhim = dvPhim.Rows[dvPhim.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Concat("Delete from Phim where MaPhim ='" + maPhim + "'");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                loadPhim();
                loadTablePhim();
                conn.Close();
            }
        }

        private void btLuuPhim_Click(object sender, EventArgs e)
        {
            if (!kiemTraPhim())
                MessageBox.Show("Thông tin chưa đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    if (!tbMaPhim.ReadOnly)
                        cmd.CommandText = "insert into Phim (MaPhim, TenPhim, DaoDien,"
                           + " DienVien, TheLoai, NoiDung, ThoiLuong, QuocGia, NamSX, Trailer, Hinh) values ('" +
                           tbMaPhim.Text + "',N'" + tbTenPhim.Text + "',N'" + tbDaoDien.Text + "',N'" + tbDienVien.Text
                           + "',N'" + tbTheLoai.Text + "',N'" + tbNoiDung.Text + "',N'" + tbThoiLuong.Text + "',N'" + tbQuocGia.Text + "',"
                           + tbNamSX.Text + ",'" + tbTrailer.Text.Replace("watch?v=", "v/") + "',@hinh)";
                    else
                    {
                        if (!layHinh)
                            cmd.CommandText = "update Phim set TenPhim =N'" + tbTenPhim.Text + "', DaoDien =N'" + tbDaoDien.Text + "', DienVien =N'" +
                                tbDienVien.Text + "', TheLoai =N'" + tbTheLoai.Text + "', NoiDung =N'" + tbNoiDung.Text + "', ThoiLuong =N'" + tbThoiLuong.Text
                                + "', QuocGia =N'" + tbQuocGia.Text + "', NamSX =" + tbNamSX.Text + ", Trailer ='" + tbTrailer.Text.Replace("watch?v=", "v/") +
                                "' where MaPhim ='" + tbMaPhim.Text + "'";
                        else
                            cmd.CommandText = "update Phim set TenPhim =N'" + tbTenPhim.Text + "', DaoDien =N'" + tbDaoDien.Text + "', DienVien =N'" +
                                tbDienVien.Text + "', TheLoai =N'" + tbTheLoai.Text + "', NoiDung =N'" + tbNoiDung.Text + "', ThoiLuong =N'" + tbThoiLuong.Text
                                + "', QuocGia =N'" + tbQuocGia.Text + "', NamSX =" + tbNamSX.Text + ", Trailer ='" + tbTrailer.Text.Replace("watch?v=", "v/") +
                                "', Hinh =@hinh where MaPhim ='" + tbMaPhim.Text + "'";
                    }
                    if(layHinh)
                        cmd.Parameters.Add(new SqlParameter("@hinh", ghiHinh(path)));
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadPhim();
                    loadTablePhim();
                    setEnabledPhim(true);
                    pnCapNhatPhim.Enabled = true;
                    btHinhPhim.Visible = false;
                    btLuuPhim.Visible = false;
                    btHuyPhim.Visible = false;
                    layHinh = false;
                    dvPhim.Enabled = true;
                    clearPhim();
                    loadThongTinPhim();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu!", "Lỗi");
                }
            }
        }

        private void btHinhPhim_Click(object sender, EventArgs e)
        {
            odPhim = new OpenFileDialog();
            odPhim.Filter = "(*JPG)|*jpg|(*PNG)|*png";
            if(odPhim.ShowDialog() == DialogResult.OK)
            {
                pbHinh.Image = doiSize(pbHinh.Size, Image.FromFile(odPhim.FileName));
                path = odPhim.FileName;
                path = path.Replace("\\", "\\\\");
                layHinh = true;
            }
        }

        private void btTimPhim_Click(object sender, EventArgs e)
        {
            timPhimTable();
        }

        private void tbNamSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbMaPhim_TextChanged(object sender, EventArgs e)
        {
            if (!tbMaPhim.ReadOnly)
            {
                setErr(erMaPhim, tbMaPhim, "Mã phim không được để trống!");
                foreach (Phim p in arPhim)
                    if (tbMaPhim.Text == p.MaPhim)
                    {
                        erMaPhim.Icon = Properties.Resources.x;
                        erMaPhim.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                        erMaPhim.SetError(tbMaPhim, "Mã phim đã tồn tại!");
                    }
            }
        }

        private void tbMaPhim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbTenPhim.Focus();
            if (e.KeyCode == Keys.Up)
                btHinhPhim.Focus();
        }

        private void tbTenPhim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbDaoDien.Focus();
            if (e.KeyCode == Keys.Up)
                tbMaPhim.Focus();
        }

        private void tbDaoDien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbDienVien.Focus();
            if (e.KeyCode == Keys.Up)
                tbTenPhim.Focus();
        }

        private void tbDienVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbTheLoai.Focus();
            if (e.KeyCode == Keys.Up)
                tbDaoDien.Focus();
        }

        private void tbTheLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbThoiLuong.Focus();
            if (e.KeyCode == Keys.Up)
                tbDienVien.Focus();
        }

        private void tbThoiLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbQuocGia.Focus();
            if (e.KeyCode == Keys.Up)
                tbTheLoai.Focus();
        }

        private void tbQuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbNamSX.Focus();
            if (e.KeyCode == Keys.Up)
                tbThoiLuong.Focus();
        }

        private void tbNamSX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbTrailer.Focus();
            if (e.KeyCode == Keys.Up)
                tbQuocGia.Focus();
        }

        private void tbTrailer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbNoiDung.Focus();
            if (e.KeyCode == Keys.Up)
                tbNamSX.Focus();
        }

        private void tbNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                btHinhPhim.Focus();
            if (e.KeyCode == Keys.Up)
                tbTrailer.Focus();
        }

        private void tbTenPhim_TextChanged(object sender, EventArgs e)
        {
            if (!tbTenPhim.ReadOnly)
                setErr(erTenPhim, tbTenPhim, "Tên phim không được để trống!");
        }

        private void tbDaoDien_TextChanged(object sender, EventArgs e)
        {
            if (!tbDaoDien.ReadOnly)
                setErr(erDaoDien, tbDaoDien, "Tên đạo diễn không được để trống!");
        }

        private void tbDienVien_TextChanged(object sender, EventArgs e)
        {
            if (!tbDienVien.ReadOnly)
                setErr(erDienVien, tbDienVien, "Diễn viên không được để trống!");
        }

        private void tbTheLoai_TextChanged(object sender, EventArgs e)
        {
            if (!tbTheLoai.ReadOnly)
                setErr(erTheLoai, tbTheLoai, "Thể loại không được để trống!");
        }

        private void tbThoiLuong_TextChanged(object sender, EventArgs e)
        {
            if (!tbThoiLuong.ReadOnly)
                setErr(erThoiLuong, tbThoiLuong, "Thời lượng không được để trống!");
        }

        private void tbQuocGia_TextChanged(object sender, EventArgs e)
        {
            if (!tbQuocGia.ReadOnly)
                setErr(erQuocGia, tbQuocGia, "Quốc gia không được để trống!");

        }

        private void tbNamSX_TextChanged(object sender, EventArgs e)
        {
            if (!tbNamSX.ReadOnly)
                setErr(erNamSX, tbNamSX, "Năm sản xuất không được để trống!");
        }

        private void tbTrailer_TextChanged(object sender, EventArgs e)
        {
            if (!tbTrailer.ReadOnly)
                setErr(erTrailer, tbTrailer, "Trailer không được để trống!");
        }

        private void tbNoiDung_TextChanged(object sender, EventArgs e)
        {
            if (!tbNoiDung.ReadOnly)
                setErr(erNoiDung, tbNoiDung, "Nội dung không được để trống!");
        }

        private void cbTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTim.SelectedIndex)
            {
                case 0:
                    tbTim.WatermarkText = "Nhập tên phim muốn tìm";
                    break;
                case 1:
                    tbTim.WatermarkText = "Nhập tên đạo diễn";
                    break;
                case 2:
                    tbTim.WatermarkText = "Nhập tên diễn viên";
                    break;
            }
        }

        private void tbTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                timPhim();
        }

        private void cbTimPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTimPhim.SelectedIndex)
            {
                case 0:
                    tbTimPhim.WatermarkText = "Nhập tên phim muốn tìm";
                    break;
                case 1:
                    tbTimPhim.WatermarkText = "Nhập tên đạo diễn";
                    break;
                case 2:
                    tbTimPhim.WatermarkText = "Nhập tên diễn viên";
                    break;
            }
        }

        private void tbTimPhim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                timPhimTable();
        }

        private void tmDoiSize_Tick(object sender, EventArgs e)
        {
            if (tangSize)
            {
                if (pnTim.Width < 508)
                    pnTim.Size = new Size(pnTim.Width + 10, pnTim.Height);
                else
                    tmDoiSize.Stop();
            }
            else
            {
                if (pnTim.Width > 48)
                    pnTim.Size = new Size(pnTim.Width - 10, pnTim.Height);
                else
                    tmDoiSize.Stop();
            }
        }

        private void btAnTim_Click(object sender, EventArgs e)
        {
            tangSize = false;
            tmDoiSize.Start();
        }

        private void lbTimPhim_MouseEnter(object sender, EventArgs e)
        {
            tangSize = true;
            tmDoiSize.Start();
            tangSizeGD = false;
            tmGiaoDien.Start();
        }

        private void tmGiaoDien_Tick(object sender, EventArgs e)
        {
            if (tangSizeGD)
            {
                if (pnGiaoDien.Width < 173)
                    pnGiaoDien.Size = new Size(pnGiaoDien.Width + 5, pnGiaoDien.Height);
                else
                    tmGiaoDien.Stop();
            }
            else
            {
                if(pnGiaoDien.Width > 47)
                    pnGiaoDien.Size = new Size(pnGiaoDien.Width - 5, pnGiaoDien.Height);
                else
                    tmGiaoDien.Stop();
            }
        }

        private void btGiaoDien_MouseEnter(object sender, EventArgs e)
        {

            tangSizeGD = true;
            tmGiaoDien.Start();
        }

        private void tcPhim_MouseEnter(object sender, EventArgs e)
        {
            tangSizeGD = false;
            tmGiaoDien.Start();
        }

        private void btToi_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark;
        }

        private void tbSang_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light;
        }

        //
        //Quản lý nhân viên

        private void dvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            loadThongTinNV();
        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            clearNhanVien();
            setEnabledNV(false);
            pnCapNhatNV.Enabled = false;
            btChonHinhNV.Visible = true;
            btLuuNV.Visible = true;
            btHuyNV.Visible = true;
            dvNhanVien.Enabled = false;
            tbMaNV.Focus();
        }

        private void cbTimNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTimNV.SelectedIndex)
            {
                case 0:
                    tbTimNV.WatermarkText = "Nhập Tên nhân viên muốn tìm";
                    break;
                case 1:
                    tbTimNV.WatermarkText = "Nhập mã nhân viên cần tìm";
                    break;
            }
        }

        private void btTimNV_Click(object sender, EventArgs e)
        {
            timNhanVien();
        }

        private void tbTimNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                timNhanVien();
        }

        private void btSuaNV_Click(object sender, EventArgs e)
        {
            loadThongTinNV();
            setEnabledNV(false);
            pnCapNhatNV.Enabled = false;
            btChonHinhNV.Visible = true;
            btLuuNV.Visible = true;
            btHuyNV.Visible = true;
            tbMaNV.ReadOnly = true;
            dvNhanVien.Enabled = false;
            tbHoTenNV.Focus();
        }

        private void btLuuNV_Click(object sender, EventArgs e)
        {
            if (!kiemTraNV())
                MessageBox.Show("Thông tin chưa đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    String ngaySinh = dtNgaySinhNV.Value.Year + "-" + dtNgaySinhNV.Value.Month + "-" + dtNgaySinhNV.Value.Day;
                    if (!tbMaNV.ReadOnly)
                    {
                        cmd.CommandText = "insert into NhanVien (MaNV, HoTen, NgaySinh, GioiTinh, SoCMND, SoDT,"
                           + " ChucVu, QueQuan, ThuongTru, AnhThe) values ('" +
                           tbMaNV.Text + "',N'" + tbHoTenNV.Text + "','" + ngaySinh + "','" + rbNam.Checked
                           + "','" + tbSoCMND.Text + "','" + tbSoDT.Text + "',N'" + cbChucVuNV.Text + "',N'" + tbQueQuanNV.Text + "',N'"
                           + tbThuongTruNV.Text + "',@hinh)";
                    }
                    else
                    {
                        if (!layHinh)
                            cmd.CommandText = "update NhanVien set HoTen =N'" + tbHoTenNV.Text + "', NgaySinh ='" + ngaySinh + "', GioiTinh ='" +
                                rbNam.Checked + "', SoCMND ='" + tbSoCMND.Text + "', SoDT ='" + tbSoDT.Text + "', ChucVu =N'" + cbChucVuNV.Text
                                + "', QueQuan =N'" + tbQueQuanNV.Text + "', ThuongTru =N'" + tbThuongTruNV.Text + "' where MaNV ='" + tbMaNV.Text + "'";
                        else
                            cmd.CommandText = "update NhanVien set HoTen =N'" + tbHoTenNV.Text + "', NgaySinh ='" + ngaySinh + "', GioiTinh ='" +
                                rbNam.Checked + "', SoCMND ='" + tbSoCMND.Text + "', SoDT ='" + tbSoDT.Text + "', ChucVu =N'" + cbChucVuNV.Text
                                + "', QueQuan =N'" + tbQueQuanNV.Text + "', ThuongTru =N'" + tbThuongTruNV.Text + "', AnhThe =@hinh where MaNV ='" + tbMaNV.Text + "'";
                    }
                    if (layHinh)
                        cmd.Parameters.Add(new SqlParameter("@hinh", ghiHinh(path)));
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    if (!tbMaNV.ReadOnly)
                    {
                        cmd.CommandText = "insert into DangNhap (MaNV, MatKhau) values ('" + tbMaNV.Text.Trim() + "','" + md5(tbMaNV.Text.Trim()) + "')";
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    loadTableNV();
                    setEnabledNV(true);
                    pnCapNhatNV.Enabled = true;
                    btChonHinhNV.Visible = false;
                    btLuuNV.Visible = false;
                    btHuyNV.Visible = false;
                    layHinh = false;
                    dvNhanVien.Enabled = true;
                    clearNhanVien();
                    loadThongTinNV();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu!", "Lỗi");
                }
            }
        }

        private void btHuyNV_Click(object sender, EventArgs e)
        {
            setEnabledNV(true);
            pnCapNhatNV.Enabled = true;
            btChonHinhNV.Visible = false;
            btLuuNV.Visible = false;
            btHuyNV.Visible = false;
            layHinh = false;
            dvNhanVien.Enabled = true;
            clearNhanVien();
            loadThongTinNV();
        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhân viên đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String maNV = dvNhanVien.Rows[dvNhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Concat("Delete from NhanVien where MaNV ='" + maNV + "'");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                loadTableNV();
                conn.Close();
            }
        }

        private void btChonHinhNV_Click(object sender, EventArgs e)
        {
            odPhim = new OpenFileDialog();
            odPhim.Filter = "(*JPG)|*jpg|(*PNG)|*png";
            if (odPhim.ShowDialog() == DialogResult.OK)
            {
                pbAnhTheNV.Image = doiSize(pbAnhTheNV.Size, Image.FromFile(odPhim.FileName));
                path = odPhim.FileName;
                path = path.Replace("\\", "\\\\");
                layHinh = true;
            }
        }

        private void tbMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbHoTenNV.Focus();
            if (e.KeyCode == Keys.Up)
                btChonHinhNV.Focus();
        }

        private void tbHoTenNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                dtNgaySinhNV.Focus();
            if (e.KeyCode == Keys.Up)
                tbMaNV.Focus();
        }

        private void tbSoCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbSoDT.Focus();
            if (e.KeyCode == Keys.Up)
                rbNu.Focus();
        }

        private void tbSoDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                cbChucVuNV.Focus();
            if (e.KeyCode == Keys.Up)
                tbSoCMND.Focus();
        }

        private void tbQueQuanNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbThuongTruNV.Focus();
            if (e.KeyCode == Keys.Up)
                tbSoDT.Focus();
        }

        private void tbThuongTruNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                btChonHinhNV.Focus();
            if (e.KeyCode == Keys.Up)
                tbQueQuanNV.Focus();
        }

        private void tbMaNV_Validated(object sender, EventArgs e)
        {
            if (!tbMaNV.ReadOnly)
                setErr(erMaNV, tbMaNV, "Mã nhân viên không được để trống!");
        }

        private void btDoiMK_Click(object sender, EventArgs e)
        {
            fmDoiMK fmDoiMK = new fmDoiMK();
            fmDoiMK.ShowDialog(this);
            if(fmDoiMK.matKhau != "")
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update DangNhap set MatKhau ='" + md5(fmDoiMK.matKhau) + "' where MaNV ='" + lbMaNV.Text + "'" ;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thay đổi mật khẩu thành công.");
            }
        }

        private void tbHoTenNV_TextChanged(object sender, EventArgs e)
        {
            if (!tbHoTenNV.ReadOnly)
                setErr(erHoTenNV, tbHoTenNV, "Họ Tên không được để trống!");
        }

        private void tbSoCMND_TextChanged(object sender, EventArgs e)
        {
            if (!tbSoCMND.ReadOnly)
                setErr(erSoCMNDNV, tbSoCMND, "Số chứng minh không được để trống!");
        }

        private void tbSoDT_TextChanged(object sender, EventArgs e)
        {
            if (!tbSoDT.ReadOnly)
                setErr(erSoDTNV, tbSoDT, "Số điện thoại không được để trống!");
        }

        private void cbChucVuNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChucVuNV.Enabled)
            {
                if (cbChucVuNV.SelectedIndex < 0)
                {
                    erChucVuNV.Icon = Properties.Resources.x;
                    erChucVuNV.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erChucVuNV.SetError(cbChucVuNV, "Chưa chọn chức vụ!");
                }
                else
                {
                    erChucVuNV.Icon = Properties.Resources.v;
                    erChucVuNV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erChucVuNV.SetError(cbChucVuNV, "ok");
                }
            }
        }

        private void tbQueQuanNV_TextChanged(object sender, EventArgs e)
        {
            if (!tbQueQuanNV.ReadOnly)
                setErr(erQueQuanNV, tbQueQuanNV, "Quê quán không được để trống!");
        }

        private void tbThuongTruNV_TextChanged(object sender, EventArgs e)
        {
            if (!tbThuongTruNV.ReadOnly)
                setErr(erThuongTruNV, tbThuongTruNV, "Địa chỉ thường trú không được để trống!");
        }

        private void rbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (gpGioiTinh.Enabled)
            {
                erGioiTinhNV.Icon = Properties.Resources.v;
                erGioiTinhNV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erGioiTinhNV.SetError(gpGioiTinh, "ok");
            }
        }

        private void rbNu_CheckedChanged(object sender, EventArgs e)
        {
            if (gpGioiTinh.Enabled)
            {
                erGioiTinhNV.Icon = Properties.Resources.v;
                erGioiTinhNV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erGioiTinhNV.SetError(gpGioiTinh, "ok");
            }
        }

        private void dtNgaySinhNV_TextChanged(object sender, EventArgs e)
        {
            if (dtNgaySinhNV.Enabled)
            {
                if (!dtNgaySinhNV.IsEmpty)
                {
                    erNgaySinhNV.Icon = Properties.Resources.v;
                    erNgaySinhNV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erNgaySinhNV.SetError(dtNgaySinhNV, "ok");
                }
                else
                {
                    erNgaySinhNV.Icon = Properties.Resources.x;
                    erNgaySinhNV.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erNgaySinhNV.SetError(dtNgaySinhNV, "Chưa chọn ngày sinh!");
                }
            }
        }

        private void tbSoDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbSoCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbTimNV_TextChanged(object sender, EventArgs e)
        {
        }

        //LicChieu
        //

        private void btThemLC_Click(object sender, EventArgs e)
        {
            //clearLichChieu();
            setEnabledLC(true);
            pnCapNhatLC.Enabled = false;
            btLuuLC.Visible = true;
            btHuyLC.Visible = true;
            dvLichChieu.Enabled = false;
            buttonX2.Name = "Them";
            cbTenPhimLC.Focus();
        }

        private void btSuaLC_Click(object sender, EventArgs e)
        {
            loadThongTinLC();
            setEnabledLC(true);
            pnCapNhatLC.Enabled = false;
            btLuuLC.Visible = true;
            btHuyLC.Visible = true;
            dvLichChieu.Enabled = false;
            buttonX2.Name = "Sua";
            cbTenPhimLC.Focus();
        }

        private void dvLichChieu_SelectionChanged(object sender, EventArgs e)
        {
            loadThongTinLC();
        }

        private void btXoaLC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa lịch chiếu đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String maLC = dvLichChieu.Rows[dvLichChieu.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Concat("Delete from LichChieu where MaLichChieu =" + maLC + "");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                loadTableLC();
                conn.Close();
            }
        }

        private void btLuuLC_Click(object sender, EventArgs e)
        {
            if (!kiemTraLC())
                MessageBox.Show("Thông tin chưa đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    String ngayChieu = dtCNNgayChieu.Value.Year + "-" + dtCNNgayChieu.Value.Month + "-" + dtCNNgayChieu.Value.Day;
                    if (buttonX2.Name == "Them")
                    {
                        cmd.CommandText = "insert into LichChieu (NgayChieu, GioChieu, MaPC, MaPhim) values ('" +
                               ngayChieu + "','" + cbGio.Text + ":" + cbPhut.Text + "','" + cbPhongChieuLC.Text + "','"
                               + (cbTenPhimLC.SelectedItem as DevComponents.Editors.ComboItem).Value.ToString() + "')";
                    }
                    else
                    {
                        cmd.CommandText = "update LichChieu set NgayChieu ='" + ngayChieu + "', GioChieu ='" + cbGio.Text + ":" + cbPhut.Text + "', MaPC ='" +
                            cbPhongChieuLC.Text + "', MaPhim ='" + (cbTenPhimLC.SelectedItem as DevComponents.Editors.ComboItem).Value.ToString() + "' where MaLichChieu =" +
                            dvLichChieu.Rows[dvLichChieu.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadTableLC();
                    setEnabledLC(false);
                    pnCapNhatLC.Enabled = true;
                    btLuuLC.Visible = false;
                    btHuyLC.Visible = false;
                    dvLichChieu.Enabled = true;
                    clearLichChieu();
                    loadThongTinLC();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu!", "Lỗi");
                }
            }
        }

        private void btHuyLC_Click(object sender, EventArgs e)
        {
            setEnabledLC(false);
            pnCapNhatLC.Enabled = true;
            btLuuLC.Visible = false;
            btHuyLC.Visible = false;
            dvLichChieu.Enabled = true;
            clearLichChieu();
            loadThongTinLC();
        }

        private void btTroVe_Click(object sender, EventArgs e)
        {
            nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Cover;
            try
            {
                duongDy.Pop();
                dulieu.Pop();
                if (duongDy.Peek() == "Phim")
                {
                    nfLichChieu.SelectedPage = npChonPhim;
                    loai = "Phim";
                }
                else if (duongDy.Peek() == "Phong")
                {
                    nfLichChieu.SelectedPage = npPhongChieu;
                    loai = "Phong";
                }
                else if (duongDy.Peek() == "Ngay")
                {
                    nfLichChieu.SelectedPage = npNgayChieu;
                    loai = "Ngay";
                }
            }
            catch
            {
                nfLichChieu.SelectedPage = npLuaChon;
            }
            chon--;
        }

        private void btTheoPhim_Click(object sender, EventArgs e)
        {
            chon++;
            loai = "Phim";
            duongDy.Push(loai);
            ipChonPhim.Items.Clear();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select distinct MaPhim, TenPhim from Phim", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            for (int i = 0; i < dtTable.Rows.Count; i++)
                ipChonPhim.Items.Add(tileChon(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString()));
            nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
            nfLichChieu.SelectedPage = npChonPhim;
            conn.Close();
        }

        private void btTheoPhongChieu_Click(object sender, EventArgs e)
        {
            chon++;
            loai = "Phong";
            duongDy.Push(loai);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select distinct MaPC from PhongChieu", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            ipChonPhong.Items.Clear();
            trim();
            for (int i = 0; i < dtTable.Rows.Count; i++)
                ipChonPhong.Items.Add(tileChon(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][0].ToString()));
            nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
            nfLichChieu.SelectedPage = npPhongChieu;
            conn.Close();
        }

        private void btTheoNgay_Click(object sender, EventArgs e)
        {
            chon++;
            loai = "Ngay";
            duongDy.Push(loai);
            nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
            nfLichChieu.SelectedPage = npNgayChieu;
        }

        private void itChon_Click(object sender, EventArgs e)
        {
            DuLieu d = new DuLieu();
            d.loai = loai;
            d.ten = (sender as DevComponents.DotNetBar.Metro.MetroTileItem).TitleText;
            d.ma = (sender as DevComponents.DotNetBar.Metro.MetroTileItem).Name;
            if(chon == 1)
            {
                if (loai == "Phim")
                {
                    loai = "Phong";
                    ipChonPhong.Items.Clear();
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    dtAdapter = new SqlDataAdapter("select distinct MaPC from LichChieu where MaPhim ='" + d.ma + "'", conn);
                    dtTable = new DataTable();
                    dtAdapter.Fill(dtTable);
                    trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                        ipChonPhong.Items.Add(tileChon(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][0].ToString()));
                    nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
                    nfLichChieu.SelectedPage = npPhongChieu;
                    conn.Close();
                }
                else if (loai == "Phong")
                {
                    nfLichChieu.SelectedPage = npNgayChieu;
                    loai = "Ngay";
                }
            } else if(chon == 2)
            {
                if(loai == "Phong")
                {
                    nfLichChieu.SelectedPage = npNgayChieu;
                    loai = "Ngay";
                } else if(loai == "Phim")
                {
                    loai = "Phong";
                    ipChonPhong.Items.Clear();
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    dtAdapter = new SqlDataAdapter("select distinct MaPC from LichChieu where MaPhim ='" + d.ma + "' and NgayChieu ='"
                        + dulieu.Peek().ma + "'", conn);
                    dtTable = new DataTable();
                    dtAdapter.Fill(dtTable);
                    trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                        ipChonPhong.Items.Add(tileChon(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][0].ToString()));
                    nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
                    nfLichChieu.SelectedPage = npPhongChieu;
                    conn.Close();
                }
            } else if( chon == 3)
            {
                if(loai == "Phim")
                {
                    DuLieu ngay = dulieu.Pop();
                    DuLieu phong = dulieu.Pop();
                    ipKetQua.Items.Clear();
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    dtAdapter = new SqlDataAdapter("Select distinct TenPhim, NgayChieu, MaPC, GioChieu  from LichChieu inner join Phim on LichChieu.MaPhim = Phim.MaPhim where NgayChieu = '"
                        + ngay.ma + "' and MaPC ='" + phong.ma + "' and LichChieu.MaPhim ='" + d.ma + "'", conn);
                    dtTable = new DataTable();
                    dtAdapter.Fill(dtTable);
                    trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                        ipKetQua.Items.Add(tileKetQua(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString().Split(' ')[0],
                            dtTable.Rows[i][2].ToString(), dtTable.Rows[i][3].ToString()));
                    nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
                    nfLichChieu.SelectedPage = npKetQua;
                    loai = "KetQua";
                    dulieu.Push(phong);
                    dulieu.Push(ngay);
                    conn.Close();
                } else if(loai == "Phong")
                {
                    DuLieu phim = dulieu.Pop();
                    DuLieu ngay = dulieu.Pop();
                    ipKetQua.Items.Clear();
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    dtAdapter = new SqlDataAdapter("Select distinct TenPhim, NgayChieu, MaPC, GioChieu  from LichChieu inner join Phim on LichChieu.MaPhim = Phim.MaPhim where NgayChieu = '"
                        + ngay.ma + "' and MaPC ='" + d.ma + "' and LichChieu.MaPhim ='" + phim.ma + "'", conn);
                    dtTable = new DataTable();
                    dtAdapter.Fill(dtTable);
                    trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                        ipKetQua.Items.Add(tileKetQua(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString().Split(' ')[0],
                            dtTable.Rows[i][2].ToString(), dtTable.Rows[i][3].ToString()));
                    nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
                    nfLichChieu.SelectedPage = npKetQua;
                    loai = "KetQua";
                    dulieu.Push(ngay);
                    dulieu.Push(phim);
                    conn.Close();
                }
            }
            dulieu.Push(d);
            duongDy.Push(loai);
            chon++;
        }

        private void mcChonNgay_DateChanged(object sender, DateRangeEventArgs e)
        {
            String[] dmy = mcChonNgay.SelectionStart.ToString().Split('/', ' ');
            String ngay = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
            if (chon == 1)
            {
                loai = "Phim";
                ipChonPhim.Items.Clear();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("Select distinct LichChieu.MaPhim, TenPhim from LichChieu inner join Phim on LichChieu.MaPhim = Phim.MaPhim where NgayChieu = '"
                    + ngay + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                trim();
                for (int i = 0; i < dtTable.Rows.Count; i++)
                    ipChonPhim.Items.Add(tileChon(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString()));
                nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Dissolve;
                nfLichChieu.SelectedPage = npChonPhim;
                conn.Close();
            }else if(chon == 2)
            {
                loai = "Phim";
                String phong = dulieu.Peek().ma;
                ipChonPhim.Items.Clear();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("Select distinct LichChieu.MaPhim, TenPhim from LichChieu inner join Phim on LichChieu.MaPhim = Phim.MaPhim where NgayChieu = '"
                    + ngay + "' and MaPC ='" + phong + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                trim();
                for (int i = 0; i < dtTable.Rows.Count; i++)
                    ipChonPhim.Items.Add(tileChon(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString()));
                nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Dissolve;
                nfLichChieu.SelectedPage = npChonPhim;
                conn.Close();

            }
            else if (chon == 3)
            {
                DuLieu phong = dulieu.Pop();
                DuLieu phim = dulieu.Pop();
                ipKetQua.Items.Clear();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("Select distinct TenPhim, NgayChieu, MaPC, GioChieu  from LichChieu inner join Phim on LichChieu.MaPhim = Phim.MaPhim where NgayChieu = '"
                    + ngay + "' and MaPC ='" + phong.ma + "' and LichChieu.MaPhim ='" + phim.ma + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                trim();
                for (int i = 0; i < dtTable.Rows.Count; i++)
                    ipKetQua.Items.Add(tileKetQua(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString().Split(' ')[0], 
                        dtTable.Rows[i][2].ToString(), dtTable.Rows[i][3].ToString()));
                nfLichChieu.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
                nfLichChieu.SelectedPage = npKetQua;
                loai = "KetQua";
                dulieu.Push(phim);
                dulieu.Push(phong);
                conn.Close();
            }
            DuLieu d = new DuLieu();
            d.loai = loai;
            d.ten = ngay;
            d.ma = ngay;
            dulieu.Push(d);
            duongDy.Push(loai);
            chon++;
        }

        private void cbTenPhimLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenPhimLC.Enabled)
            {
                if (cbTenPhimLC.SelectedIndex < 0)
                {
                    erTenPhimLC.Icon = Properties.Resources.x;
                    erTenPhimLC.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erTenPhimLC.SetError(cbTenPhimLC, "Chưa chọn phim!");
                }
                else
                {
                    erTenPhimLC.Icon = Properties.Resources.v;
                    erTenPhimLC.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erTenPhimLC.SetError(cbTenPhimLC, "ok");
                }
            }
        }

        private void cbPhongChieuLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhongChieuLC.Enabled)
            {
                if (cbPhongChieuLC.SelectedIndex < 0)
                {
                    erPhongChieuLC.Icon = Properties.Resources.x;
                    erPhongChieuLC.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erPhongChieuLC.SetError(cbPhongChieuLC, "Chưa chọn phòng chiếu!");
                }
                else
                {
                    erPhongChieuLC.Icon = Properties.Resources.v;
                    erPhongChieuLC.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erPhongChieuLC.SetError(cbPhongChieuLC, "ok");
                }
            }
        }

        private void dtCNNgayChieu_TextChanged(object sender, EventArgs e)
        {
            if (dtCNNgayChieu.Enabled)
            {
                if (dtCNNgayChieu.IsEmpty)
                {
                    erNgayChieuLC.Icon = Properties.Resources.x;
                    erNgayChieuLC.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erNgayChieuLC.SetError(dtCNNgayChieu, "Chưa chọn ngày sinh!");
                }
                else
                {
                    erNgayChieuLC.Icon = Properties.Resources.v;
                    erNgayChieuLC.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erNgayChieuLC.SetError(dtCNNgayChieu, "ok");
                }
            }
        }

        private void cbGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGio.Enabled)
            {
                if (cbGio.SelectedIndex < 0)
                {
                    erGioChieuLC.Icon = Properties.Resources.x;
                    erGioChieuLC.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erGioChieuLC.SetError(cbPhut, "Chưa chọn giờ chiếu!");
                }
                else
                {
                    erGioChieuLC.Icon = Properties.Resources.v;
                    erGioChieuLC.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erGioChieuLC.SetError(cbPhut, "ok");
                }

                if (cbPhut.SelectedIndex < 0)
                {
                    erGioChieuLC.Icon = Properties.Resources.x;
                    erGioChieuLC.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erGioChieuLC.SetError(cbPhut, "Chưa chọn giờ chiếu!");
                }
                else
                {
                    erGioChieuLC.Icon = Properties.Resources.v;
                    erGioChieuLC.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erGioChieuLC.SetError(cbPhut, "ok");
                }
            }
        }

        private void dtNgayChieuLC_ValueChanged(object sender, EventArgs e)
        {
            String[] dmy = dtNgayChieuLC.Value.ToString().Split('/', ' ');
            String ngay = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select MaLichChieu, TenPhim, MaPC, NgayChieu, GioChieu from LichChieu, Phim where LichChieu.MaPhim = Phim.MaPhim and NgayChieu ='" + ngay + "'", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            dvLichChieu.DataSource = dtTable;
            dtAdapter = new SqlDataAdapter("select MaPhim, TenPhim from Phim", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            cbTenPhimLC.Items.Clear();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DevComponents.Editors.ComboItem it = new DevComponents.Editors.ComboItem();
                it.Value = dtTable.Rows[i][0].ToString();
                it.Text = dtTable.Rows[i][1].ToString();
                cbTenPhimLC.Items.Add(it);
            }
            dtAdapter = new SqlDataAdapter("select MaPC from PhongChieu", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            cbPhongChieuLC.Items.Clear();
            for (int i = 0; i < dtTable.Rows.Count; i++)
                cbPhongChieuLC.Items.Add(new DevComponents.Editors.ComboItem(dtTable.Rows[i][0].ToString()));
            conn.Close();
        }

        private void btXemHet_Click(object sender, EventArgs e)
        {
            loadTableLC();
        }

        //LoaiVe
        //

        private void tbGiaBanLV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dvLoaiVe_SelectionChanged(object sender, EventArgs e)
        {
            loadThongTinLV();
        }

        private void btThemLV_Click(object sender, EventArgs e)
        {
            clearLoaiVe();
            setEnabledLV(true);
            pnCapNhatLV.Enabled = false;
            btLuuLV.Visible = true;
            btHuyLV.Visible = true;
            dvLoaiVe.Enabled = false;
            tbMaLoaiLV.Focus();
        }

        private void btSuaLV_Click(object sender, EventArgs e)
        {
            loadThongTinLV();
            setEnabledLV(true);
            pnCapNhatLV.Enabled = false;
            btLuuLV.Visible = true;
            btHuyLV.Visible = true;
            dvLoaiVe.Enabled = false;
            tbMaLoaiLV.ReadOnly = true;
            tbTenLoaiLV.Focus();
        }

        private void btXoaLV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa loại vé đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String maLV = dvLoaiVe.Rows[dvLoaiVe.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Concat("Delete from LoaiVe where MaLoai ='" + maLV + "'");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                loadTableLV();
                conn.Close();
            }
        }

        private void btHuyLV_Click(object sender, EventArgs e)
        {
            setEnabledLV(false);
            pnCapNhatLV.Enabled = true;
            btLuuLV.Visible = false;
            btHuyLV.Visible = false;
            dvLoaiVe.Enabled = true;
            clearLoaiVe();
            loadThongTinLV();
        }

        private void btLuuLV_Click(object sender, EventArgs e)
        {
            if (!kiemTraLV())
                MessageBox.Show("Thông tin chưa đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    String ngayBan = "";
                    if (ckCN.Checked)
                        ngayBan += ckCN.Text + "/";
                    if (ckT2.Checked)
                        ngayBan += ckT2.Text + "/";
                    if (ckT3.Checked)
                        ngayBan += ckT3.Text + "/";
                    if (ckT4.Checked)
                        ngayBan += ckT4.Text + "/";
                    if (ckT5.Checked)
                        ngayBan += ckT5.Text + "/";
                    if (ckT6.Checked)
                        ngayBan += ckT6.Text + "/";
                    if (ckT7.Checked)
                        ngayBan += ckT7.Text + "/";
                    if (!tbMaLoaiLV.ReadOnly)
                    {
                        cmd.CommandText = "insert into LoaiVe (MaLoai, TenLoai, HangGhe, DoiTuong, Gia, NgayBan) values ('" +
                               tbMaLoaiLV.Text.Trim() + "',N'" + tbTenLoaiLV.Text.Trim() + "','" + tbHangGheLV.Text.Trim() + "',N'" 
                               + tbDoiTuongLV.Text.Trim() + "'," + tbGiaBanLV.Text.Trim() + ",N'" + ngayBan + "')";
                    }
                    else
                    {
                        cmd.CommandText = "update LoaiVe set TenLoai =N'" + tbTenLoaiLV.Text.Trim() + "', HangGhe ='" + tbHangGheLV.Text.Trim() + "', DoiTuong =N'" +
                             tbDoiTuongLV.Text.Trim() + "', Gia =" + tbGiaBanLV.Text.Trim() + ",NgayBan =N'" + ngayBan + "' where MaLoai ='" + tbMaLoaiLV.Text.Trim() + "'";
                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadTableLV();
                    setEnabledLV(false);
                    pnCapNhatLV.Enabled = true;
                    btLuuLV.Visible = false;
                    btHuyLV.Visible = false;
                    dvLoaiVe.Enabled = true;
                    clearLoaiVe();
                    loadThongTinLV();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu!", "Lỗi");
                }
            }
        }

        private void tbMaLoaiLV_TextChanged(object sender, EventArgs e)
        {
            if (!tbMaLoaiLV.ReadOnly)
                setErr(erMaLoaiLV, tbMaLoaiLV, "Mã loại vé không được để trống!");
        }

        private void tbTenLoaiLV_TextChanged(object sender, EventArgs e)
        {
            if (!tbTenLoaiLV.ReadOnly)
                setErr(erTenLoaiLV, tbTenLoaiLV, "Tên loại vé không được để trống!");
        }

        private void tbHangGheLV_TextChanged(object sender, EventArgs e)
        {
            if (!tbHangGheLV.ReadOnly)
                setErr(erHangGheLV, tbHangGheLV, "Hàng ghế không được để trống!");
        }

        private void tbDoiTuongLV_TextChanged(object sender, EventArgs e)
        {
            if (!tbDoiTuongLV.ReadOnly)
                setErr(erDoiTuongLV, tbDoiTuongLV, "Đối tượng không được để trống!");
        }

        private void tbGiaBanLV_TextChanged(object sender, EventArgs e)
        {
            if (!tbGiaBanLV.ReadOnly)
                setErr(erGiaBanLV, tbGiaBanLV, "Giá bán không được để trống!");
        }

        private void tbMaLoaiLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbTenLoaiLV.Focus();
            if (e.KeyCode == Keys.Up)
                grNgayBan.Focus();
        }

        private void tbTenLoaiLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbHangGheLV.Focus();
            if (e.KeyCode == Keys.Up)
                tbMaLoaiLV.Focus();
        }

        private void tbHangGheLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbDoiTuongLV.Focus();
            if (e.KeyCode == Keys.Up)
                tbTenLoaiLV.Focus();
        }

        private void tbDoiTuongLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbGiaBanLV.Focus();
            if (e.KeyCode == Keys.Up)
                tbHangGheLV.Focus();
        }

        private void tbGiaBanLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                grNgayBan.Focus();
            if (e.KeyCode == Keys.Up)
                tbDoiTuongLV.Focus();
        }

        //
        //PhongChieu

        private void dvPhongChieu_SelectionChanged(object sender, EventArgs e)
        {
            loadThongTinPC();
        }

        private void tbSoCho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbSoDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbDienTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btThemPC_Click(object sender, EventArgs e)
        {
            clearPhongChieu();
            setEnabledPC(true);
            pnCapNhatPC.Enabled = false;
            btLuuPC.Visible = true;
            btHuyPC.Visible = true;
            dvPhongChieu.Enabled = false;
            tbPhongChieu.Focus();
        }

        private void btSuaPC_Click(object sender, EventArgs e)
        {
            loadThongTinPC();
            setEnabledPC(true);
            pnCapNhatPC.Enabled = false;
            btLuuPC.Visible = true;
            btHuyPC.Visible = true;
            dvPhongChieu.Enabled = false;
            tbPhongChieu.ReadOnly = true;
            tbSoCho.Focus();
        }

        private void btXoaPC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa phòng chiếu đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String maPC = dvPhongChieu.Rows[dvPhongChieu.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = String.Concat("Delete from PhongChieu where MaPC ='" + maPC + "'");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                loadTablePC();
                conn.Close();
            }
        }

        private void btLuuPC_Click(object sender, EventArgs e)
        {
            if (!kiemTraPC())
                MessageBox.Show("Thông tin chưa đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    if (!tbPhongChieu.ReadOnly)
                    {
                        cmd.CommandText = "insert into PhongChieu (MaPC, SoCho, SoDay, MayChieu, AmThanh, DienTich, TinhTrang, ThietBiKhac) values ('" +
                               tbPhongChieu.Text.Trim() + "'," + tbSoCho.Text.Trim() + "," + tbSoDay.Text.Trim() + ",N'"
                               + tbMayChieu.Text.Trim() + "',N'" + tbAmThanh.Text.Trim() + "','" + tbDienTich.Text.Trim() + "', N'" +
                               tbTinhTrang.Text.Trim() + "',N'" + tbThietBị.Text.Trim() + "')";
                    }
                    else
                    {
                        cmd.CommandText = "update PhongChieu set SoCho =" + tbSoCho.Text.Trim() + ", SoDay =" + tbSoDay.Text.Trim() + ", MayChieu =N'" +
                             tbMayChieu.Text.Trim() + "', AmThanh =N'" + tbAmThanh.Text.Trim() + "',DienTich ='" + tbDienTich.Text.Trim() + "', TinhTrang =N'"
                             + tbTinhTrang.Text.Trim() + "', ThietBiKhac =N'" + tbThietBị.Text.Trim() + "' where MaPC ='" + tbPhongChieu.Text.Trim() + "'";
                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    loadTablePC();
                    setEnabledPC(false);
                    pnCapNhatPC.Enabled = true;
                    btLuuPC.Visible = false;
                    btHuyPC.Visible = false;
                    dvPhongChieu.Enabled = true;
                    clearPhongChieu();
                    loadThongTinPC();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể cập nhật dữ liệu!", "Lỗi");
                }
            }
        }

        private void btHuyPC_Click(object sender, EventArgs e)
        {
            setEnabledPC(false);
            pnCapNhatPC.Enabled = true;
            btLuuPC.Visible = false;
            btHuyPC.Visible = false;
            dvPhongChieu.Enabled = true;
            clearPhongChieu();
            loadThongTinPC();
        }

        private void tbPhongChieu_TextChanged(object sender, EventArgs e)
        {
            if (!tbPhongChieu.ReadOnly)
                setErr(erPCPhong, tbPhongChieu, "Mã phòng chiếu không được để trống!");
        }

        private void tbSoCho_TextChanged(object sender, EventArgs e)
        {
            if (!tbSoCho.ReadOnly)
                setErr(erPCSoCho, tbSoCho, "Số chỗ không được để trống!");
        }

        private void tbSoDay_TextChanged(object sender, EventArgs e)
        {
            if (!tbSoDay.ReadOnly)
                setErr(erPCSoDay, tbSoDay, "Số dãy không được để trống!");
        }

        private void tbMayChieu_TextChanged(object sender, EventArgs e)
        {
            if (!tbMayChieu.ReadOnly)
                setErr(erPCMayChieu, tbMayChieu, "Máy chiếu không được để trống!");
        }

        private void tbAmThanh_TextChanged(object sender, EventArgs e)
        {
            if (!tbAmThanh.ReadOnly)
                setErr(erPCAmThanh, tbAmThanh, "Âm thanh không được để trống!");
        }

        private void tbDienTich_TextChanged(object sender, EventArgs e)
        {
            if (!tbDienTich.ReadOnly)
                setErr(erPCDienTich, tbDienTich, "Diện tích không được để trống!");
        }

        private void tbTinhTrang_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbThietBị_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPhongChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbSoCho.Focus();
            if (e.KeyCode == Keys.Up)
                tbThietBị.Focus();
        }

        private void tbSoCho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbSoDay.Focus();
            if (e.KeyCode == Keys.Up)
                tbPhongChieu.Focus();
        }

        private void tbSoDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbMayChieu.Focus();
            if (e.KeyCode == Keys.Up)
                tbSoCho.Focus();
        }

        private void tbMayChieu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbAmThanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbDienTich.Focus();
            if (e.KeyCode == Keys.Up)
                tbMayChieu.Focus();
        }

        private void tbMayChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbAmThanh.Focus();
            if (e.KeyCode == Keys.Up)
                tbSoDay.Focus();
        }

        private void tbDienTich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbTinhTrang.Focus();
            if (e.KeyCode == Keys.Up)
                tbAmThanh.Focus();
        }

        private void tbTinhTrang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbThietBị.Focus();
            if (e.KeyCode == Keys.Up)
                tbDienTich.Focus();
        }

        private void tbTimNV_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                timNhanVien();
            }
        }

        private void tbTimPhongChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                timPhong();
            }
        }

        private void btTimPC_Click(object sender, EventArgs e)
        {
            timPhong();
        }

        private void dtBVNgayChieu_ValueChanged(object sender, EventArgs e)
        {
            ipBVChonLich.Items.Clear();
            ipBVChonPhim.Items.Clear();
            ipBVChonPhong.Items.Clear();
            ipBVChonPhong.Items.Add(tilePhong);
            ipBVChonLich.Items.Add(tileLich);
            ipBVChonPhim.Items.Add(tilePhimBV);
            String[] dmy = dtBVNgayChieu.Value.ToString().Split('/', ' ');
            String ngay = dmy[0] + "/" + dmy[1] + "/" + dmy[2];
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select distinct LichChieu.MaPhim, TenPhim from LichChieu inner join Phim on LichChieu.MaPhim = Phim.MaPhim where NgayChieu = '"
                    + ngay + "'", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DevComponents.DotNetBar.Metro.MetroTileItem tile = tileBanVe(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString());
                tile.TileSize = new Size(750, 50);
                tile.Image = Properties.Resources.ChonPhim;
                ipBVChonPhim.Items.Add(tile);
            }
            ipBVChonPhim.Enabled = false;
            ipBVChonPhim.Enabled = true;
            ipBVChonPhong.Enabled = false;
            ipBVChonPhong.Enabled = true;
            ipBVChonLich.Enabled = false;
            ipBVChonLich.Enabled = true;
            conn.Close();
        }

        private void xcData_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
        }

        private void btBVTroVe_Click(object sender, EventArgs e)
        {
                nfBanVe.SelectedPage = npBVChonLich;
        }

        private void btBanVe_Click(object sender, EventArgs e)
        {
            if (arGheDaChon.Count > 0)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("select MaLoai, Tenloai from LoaiVe", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                trim();
                cbLoaiVeKH.DataSource = dtTable;
                cbLoaiVeKH.ValueMember = "MaLoai";
                cbLoaiVeKH.DisplayMember = "TenLoai";
                nfBanVe.SelectedPage = npThongTinKhach;
                tbHoTenKH.Text = "";
                tbSoDTKH.Text = "";
                cbLoaiVeKH.SelectedIndex = -1;
                lvVe.Items[2].SubItems[2].Text = dtBVNgayChieu.Value.ToString().Split(' ')[0];
                foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonPhim.Items)
                    if (it.Checked == true)
                        lvVe.Items[1].SubItems[2].Text = it.TitleText.Trim();
                foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonLich.Items)
                    if (it.Checked == true)
                        lvVe.Items[3].SubItems[2].Text = it.TitleText.Trim();
                foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonPhong.Items)
                    if (it.Checked == true)
                        lvVe.Items[4].SubItems[2].Text = it.TitleText.Trim();
                lvVe.Items[5].SubItems[2].Text = "";
                foreach (String str in arGheDaChon)
                    lvVe.Items[5].SubItems[2].Text += (str + "/");
                lvVe.Items[6].SubItems[2].Text = arGheDaChon.Count.ToString();
                lvVe.Items[0].SubItems[2].Text = "";
                lvVe.Items[7].SubItems[2].Text = "";
                lvVe.Items[8].SubItems[2].Text = "";

            }
            else
                MessageBox.Show("Bạn chưa chọn vị trí ghế ngồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btTroVeVE_Click(object sender, EventArgs e)
        {
            nfBanVe.SelectedPage = npSoDo;
            if(lvVe.Items[6].SubItems[2].Text == "")
            {
                ipSoDo.Items.Clear();
                ipSoDo.Enabled = false;
                ipSoDo.Enabled = true;
            }
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            nfBanVe.SelectedPage = npBVChonLich;
        }

        private void btXongKH_Click(object sender, EventArgs e)
        {
            if(!kiemTraKH())
                MessageBox.Show("Thông tin chưa đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                lvVe.Items[0].SubItems[2].Text = tbHoTenKH.Text.Trim();
                lvVe.Items[7].SubItems[2].Text = tbVAT.Text.Trim();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd = new SqlCommand("Select Gia from LoaiVe where MaLoai ='" + cbLoaiVeKH.SelectedValue + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int gia = int.Parse(dr[0].ToString().Trim());
                int soLuongVe = arGheDaChon.Count;
                int vat = 0;
                try {
                    vat = int.Parse(tbVAT.Text);
                }
                catch { }
                float tien = (gia * soLuongVe) + (gia * soLuongVe) * (vat / (float)100);
                lvVe.Items[8].SubItems[2].Text = tien.ToString();
                dr.Close();
                conn.Close();
            }
        }

        private void tbVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbHoTenKH_TextChanged(object sender, EventArgs e)
        {
            setErr(erHoTenKH, tbHoTenKH, "Tên khách hàng không được để trống!");
        }

        private void tbSoDTKH_TextChanged(object sender, EventArgs e)
        {
            setErr(erSoDTKH, tbSoDTKH, "Số điện thoại khách hàng không được để trống!");
        }

        private void cbLoaiVeKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiVeKH.SelectedIndex < 0)
            {
                erLoaiVe.Icon = Properties.Resources.x;
                erLoaiVe.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erLoaiVe.SetError(cbLoaiVeKH, "Chưa chọn loại vé!");
            }
            else
            {
                erLoaiVe.Icon = Properties.Resources.v;
                erLoaiVe.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erLoaiVe.SetError(cbLoaiVeKH, "ok");
            }
        }

        private void btInVe_Click(object sender, EventArgs e)
        {
            if (lvVe.Items[0].SubItems[2].Text == "")
                MessageBox.Show("Thông tin chưa đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (pdInVe.ShowDialog() == DialogResult.OK)
                {
                    dcPrint.Print();
                    String maLich = "";
                    foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonLich.Items)
                        if (it.Checked == true)
                            maLich = it.Name.Trim();
                    String ghe = "";
                    foreach (String str in arGheDaChon)
                        ghe += (str + "/");
                    String maVe = maLich + "-" + ghe;
                    String nguoiMua = lvVe.Items[0].SubItems[2].Text;
                    String vat = lvVe.Items[7].SubItems[2].Text;
                    if (vat.Trim() == "")
                        vat = "0";
                    String soLuong = arGheDaChon.Count.ToString();
                    String loaiVe = cbLoaiVeKH.SelectedValue.ToString();
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into VeBan(MaVe, NguoiMua, SoDT, MaLichChieu, LoaiVe, SoLuong, Ghe, NguoiBan, VAT) values ('" +
                        maVe + "',N'" + nguoiMua + "','" + tbSoDTKH.Text + "', '" + maLich + "', '" + loaiVe +
                        "', " + soLuong + ", '" + ghe + "', '" + lbMaNV.Text + "', " + vat + ")";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lvVe.Items[0].SubItems[2].Text = "";
                    lvVe.Items[1].SubItems[2].Text = "";
                    lvVe.Items[2].SubItems[2].Text = "";
                    lvVe.Items[3].SubItems[2].Text = "";
                    lvVe.Items[4].SubItems[2].Text = "";
                    lvVe.Items[5].SubItems[2].Text = "";
                    lvVe.Items[6].SubItems[2].Text = "";
                    lvVe.Items[7].SubItems[2].Text = "";
                    lvVe.Items[8].SubItems[2].Text = "";
                    tbHoTenKH.Text = "";
                    tbSoDTKH.Text = "";
                    cbLoaiVeKH.SelectedIndex = -1;

                    arGheDaChon.Clear();
                    loadGheChon(arGheDaChon);
                    icGheDaChon.Enabled = false;
                    icGheDaChon.Enabled = true;
                    nfBanVe.SelectedPage = npBVChonLich;
                }
            }
        }

        private void dcPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int startX = 10;
            int startY = 35;
            int offset = 10;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            Graphics graphic = e.Graphics;
            graphic.DrawImage(Properties.Resources.ve, 10, 50, 630, 230);
            graphic.DrawString("-------------------------------------------------", font, new SolidBrush(Color.White), startX, startY + offset);
            graphic.DrawString("-------------------------------------------------", font, new SolidBrush(Color.Red), startX, startY + offset + 4);
            offset += (int)fontHeight;
            graphic.DrawString("  Khách Hàng  : " + lvVe.Items[0].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Phim        : " + lvVe.Items[1].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Ngày Chiếu  : " + lvVe.Items[2].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Giờ Chiếu   : " + lvVe.Items[3].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Phòng Chiếu : " + lvVe.Items[4].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Ghế         : " + lvVe.Items[5].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Số Lượng    : " + lvVe.Items[6].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Thuế VAT    : " + lvVe.Items[7].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.White), startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphic.DrawString("  Thành Tiền  : " + lvVe.Items[8].SubItems[2].Text, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.Yellow), startX, startY + offset);
            offset += (int)fontHeight;
            graphic.DrawString("-------------------------------------------------", font, new SolidBrush(Color.Red), startX, startY + offset);
            graphic.DrawString("-------------------------------------------------", font, new SolidBrush(Color.White), startX, startY + offset + 4);

        }

        private void dtTKNgay_ValueChanged(object sender, EventArgs e)
        {
            if (!dtTKNgay.IsEmpty)
                cbTKPhim.Enabled = true;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            String ngay = dtTKNgay.Value.ToString();
            ngay = ngay.Split(' ')[0];
            String[] dmy = ngay.Split('/');
            ngay = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
            dtAdapter = new SqlDataAdapter("select distinct LichChieu.MaPhim, TenPhim from LichChieu, Phim where LichChieu.MaPhim = Phim.MaPhim and NgayChieu='" + ngay + "'", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            cbTKPhim.DataSource = dtTable;
            cbTKPhim.DisplayMember = "TenPhim";
            cbTKPhim.ValueMember = "MaPhim";
            cbTKPhim.Text = "";
            cbTKPhim.SelectedIndex = -1;
            conn.Close();
        }

        private void cbTKPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTKPhim.SelectedIndex >= 0)
            {
                String ngay = dtTKNgay.Value.ToString().Split(' ')[0];
                String[] dmy = ngay.Split('/');
                ngay = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
                loadThongKeNgay(ngay);
            }
        }

        private void dtTKNgayBD_ValueChanged(object sender, EventArgs e)
        {
            if(!dtTKNgayBD.IsEmpty)
            {
                dtTKNgayKT.MinDate = dtTKNgayBD.Value;
                dtTKNgayKT.Enabled = true;
            }
        }

        private void dtTKNgayKT_ValueChanged(object sender, EventArgs e)
        {
            String strBatDau = dtTKNgayBD.Value.ToString().Split(' ')[0];
            String[] dmy = strBatDau.Split('/');
            strBatDau = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
            DateTime dtBatDau = Convert.ToDateTime(strBatDau);
            String strKetThuc = dtTKNgayKT.Value.ToString().Split(' ')[0];
            dmy = strKetThuc.Split('/');
            strKetThuc = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
            DateTime dtKetThuc = Convert.ToDateTime(strKetThuc);
            srThongKe.Points.Clear();
            tongDoanhThu = 0;
            for (DateTime i = dtBatDau; DateTime.Compare(i, dtKetThuc) <= 0; i = i.AddDays(1))
            {
                String dt = i.ToString().Split(' ')[0];
                dmy = dt.Split('/');
                dt = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
                loadThongKe(dt);
            }
            lbDoanhThu.Text = "Tổng doanh thu : " + tongDoanhThu.ToString() + " đ";
            lbDoanhThu.Visible = true;
        }

        private void tbHoTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbSoDTKH.Focus();
            if (e.KeyCode == Keys.Up)
                tbVAT.Focus();
        }

        private void tbSoDTKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                cbLoaiVeKH.Focus();
            if (e.KeyCode == Keys.Up)
                tbHoTenKH.Focus();
        }

        private void tbVAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbHoTenKH.Focus();
            if (e.KeyCode == Keys.Up)
                cbLoaiVeKH.Focus();
        }

        private void tbThietBị_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbPhongChieu.Focus();
            if (e.KeyCode == Keys.Up)
                tbTinhTrang.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pnDN.Visible == true)
            {
                int x = pnDN.Location.X + a;
                int y = pnDN.Location.Y;
                pnDN.Location = new Point(x, y);
                btDangNhap.TextColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
                if (x > this.Width - pnDangNhap.Width/2)
                {
                    int x1 = pnDN.Location.X + pnDangNhap.Width/2;
                    int y1 = pnDN.Location.Y + 3;
                    pnNguoiDung.Location = new Point(x1, y1);
                    pnDN.Visible = false;
                    pnNguoiDung.Visible = true;
                    a = -2;
                }
            }
            if (pnNguoiDung.Visible == true)
            {
                btDangXuat.TextColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
                int x = pnNguoiDung.Location.X + a;
                int y = pnNguoiDung.Location.Y;
                pnNguoiDung.Location = new Point(x, y);
                if (x < toaDoY)
                {
                    a = 1;
                    btDangXuat.TextColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
                }
                if (x > toaDoX && a != -2)
                {
                    a = -1;
                    btDangXuat.TextColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
                }
            }
        }
    }
}
