using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using System.IO;
using System.Text.RegularExpressions;

namespace RapPhim
{
    partial class RapPhim
    {
        SqlConnection conn;
        SqlDataAdapter dtAdapter;
        DataTable dtTable;
        SqlCommand cmd;
        //arr
        List<Phim> arPhim;
        List<String> arGheDaChon = new List<String>();
        List<String> arGhe = new List<String>();
        List<DevExpress.XtraCharts.SeriesPoint> arThongKe = new List<DevExpress.XtraCharts.SeriesPoint>();
        double tongDoanhThu = 0;

        private void connectDatabase()
        {
            conn = new SqlConnection("Data Source=DESKTOP-MLF7OA4;Initial Catalog=QLRapPhim;Integrated Security=True");
            conn.Close();
        }

        private void dangNhap()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("select MatKhau from DangNhap where MaNV = '" + tbTenDN.Text.Trim() + "'", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            if (dtTable.Rows.Count < 1)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại!");
                tbTenDN.Focus();
            }
            else
            {
                if (dtTable.Rows[0][0].ToString().Trim() != md5(tbMatKhau.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu đăng nhập không đúng!\n Vui lòng thử lại.");
                    tbMatKhau.Clear();
                    tbMatKhau.Focus();
                }
                else
                {
                    cmd = new SqlCommand("select MaNV, HoTen, ChucVu, AnhThe from NhanVien where MaNV = '" + tbTenDN.Text.Trim() + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        Image imHinh = null;
                        try
                        {
                            byte[] btHinh = (byte[])(dr[3]);
                            MemoryStream msHinh = new MemoryStream(btHinh);
                            imHinh = Image.FromStream(msHinh);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lỗi!");
                        }
                        if (imHinh != null)
                            pbNguoiDung.Image = doiSize(pbNguoiDung.Size, imHinh);
                        lbten.Text = dr[1].ToString().Trim();
                        lbMaNV.Text = dr[0].ToString().Trim();
                        lbChucVu.Text = dr[2].ToString().Trim();
                    }

                    tmDangNhap.Start();
                    MessageBox.Show("Đăng nhập thành công.");
                }
            }
            conn.Close();
            //Kiểm tra chức vụ của nhân viên
            if (lbChucVu.Text == "admin")
            {
                //Thêm tất cả bảng dữ liệu
                this.xcData.TabPages.Add(this.xpQuanLyNhanVien);
                loadTableNV();
                cbTimNV.SelectedIndex = 0;
                cbChucVuNV.SelectedIndex = 0;
                dtNgaySinhNV.MaxDate = DateTime.Now;
                this.xcData.TabPages.Add(this.xpThongKe);
                dtTKNgay.MaxDate = DateTime.Now;
                dtTKNgayBD.MaxDate = DateTime.Now;
                dtTKNgayKT.MaxDate = DateTime.Now;
                this.xcData.TabPages.Add(this.xpQuanLyLoaiVe);
                loadTableLV();
                this.xcData.TabPages.Add(this.xpBanVe);
                this.xcData.TabPages.Add(this.xpQuanLyPhim);
                this.xcData.TabPages.Add(this.xpQuanLyLichChieu);
                loadTablePhim();
                loadTableLC();
                cbTimPhim.SelectedIndex = 0;
                dtCNNgayChieu.MinDate = DateTime.Now;
                for (int i = 0; i < 24; i++)
                    cbGio.Items.Add(new DevComponents.Editors.ComboItem(i.ToString()));
                for (int i = 0; i < 59; i++)
                    cbPhut.Items.Add(new DevComponents.Editors.ComboItem(i.ToString()));
                this.xcData.TabPages.Add(this.xpQuanLyPhongChieu);
                loadTablePC();
                xcData.SelectedTabPage = xpBanVe;
                pbBanner.Image = doiSize(pbBanner.Size, Properties.Resources._1);
                xcData.SelectedTabPage = xpDanhSachPhim;
            }
            //Nhân viên thuộc ban quản lý
            else if (lbChucVu.Text == "Ban quản lý")
            {
                //Thêm thẻ thống kê
                this.xcData.TabPages.Add(this.xpThongKe);
                //Thêm thẻ nhân viên
                this.xcData.TabPages.Add(this.xpQuanLyNhanVien);
                loadTableNV();
                cbTimNV.SelectedIndex = 0;
                cbChucVuNV.SelectedIndex = 0;
                dtNgaySinhNV.MaxDate = DateTime.Now;
                dtTKNgay.MaxDate = DateTime.Now;
                dtTKNgayBD.MaxDate = DateTime.Now;
                dtTKNgayKT.MaxDate = DateTime.Now;
                xcData.SelectedTabPage = xpThongKe;
            }
            //Nhân viên thuộc bộ phận quản lý phim
            else if (lbChucVu.Text == "Quản lý phim")
            {
                //Thêm thẻ quản lý phim
                this.xcData.TabPages.Add(this.xpQuanLyPhim);
                //Thêm bảng quản lý lịch chiếu
                this.xcData.TabPages.Add(this.xpQuanLyLichChieu);
                loadTablePhim();
                loadTableLC();
                cbTimPhim.SelectedIndex = 0;
                dtCNNgayChieu.MinDate = DateTime.Now;
                for (int i = 0; i < 24; i++)
                    cbGio.Items.Add(new DevComponents.Editors.ComboItem(i.ToString()));
                for (int i = 0; i < 59; i++)
                    cbPhut.Items.Add(new DevComponents.Editors.ComboItem(i.ToString()));
                xcData.SelectedTabPage = xpQuanLyPhim;
            }
            //Nhân viên thuộc bộ phận quản lý vé
            else if (lbChucVu.Text == "Quản lý vé")
            {
                //Thêm thẻ quản lý loại vé
                this.xcData.TabPages.Add(this.xpQuanLyLoaiVe);
                //Thêm bảng bán vé
                this.xcData.TabPages.Add(this.xpBanVe);
                loadTableLV();
                xcData.SelectedTabPage = xpBanVe;
                pbBanner.Image = doiSize(pbBanner.Size, Properties.Resources._1);
            }
            //Nhân viên thuộc bộ phận quản lý phòng chiếu
            else if (lbChucVu.Text == "Quản lý phòng chiếu")
            {
                //Thêm bảng quản lý phòng chiếu
                this.xcData.TabPages.Add(this.xpQuanLyPhongChieu);
                xcData.SelectedTabPage = xpQuanLyPhongChieu;
                loadTablePC();
            }
        }

        private bool setErr(ErrorProvider err, TextBox tb, String strErr)
        {    //Kiểm tra textbox trống
            if (tb.Text.Trim() == "")
            {   //Báo lỗi
                err.Icon = Properties.Resources.x;
                err.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                err.SetError(tb, strErr);
                return true;
            }
            else
            {
                err.Icon = Properties.Resources.v;
                err.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                err.SetError(tb, "ok");
                return false;
            }
        }

        static public Image doiSize(Size s, Image im)
        {
            if (s.Width / s.Height > im.Width / im.Height)
            {
                s.Height = (int)(im.Height * (s.Width / (float)im.Width));
            }
            else
            {
                s.Width = (int)(im.Width * (s.Height / (float)im.Height));
            }
            Bitmap bm = new Bitmap(s.Width, s.Height);
            Graphics gp = Graphics.FromImage((Image)bm);
            gp.DrawImage(im, 0, 0, s.Width, s.Height);
            gp.Dispose();
            return bm;
        }

        private string boDau(string str)
        {//Bỏ dấu tiếng việt
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = str.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private void trim()
        {
            for (int i = 0; i < dtTable.Rows.Count; i++)
                for (int j = 0; j < dtTable.Columns.Count; j++)
                    dtTable.Rows[i][j] = dtTable.Rows[i][j].ToString().Trim();
        }

        private byte[] ghiHinh(String path)
        {
            byte[] hinh = null;
            FileStream fsHinh = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader brHinh = new BinaryReader(fsHinh);
            hinh = brHinh.ReadBytes((int)fsHinh.Length);
            fsHinh.Close();
            return hinh;
        }

        private string md5(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        private DevComponents.DotNetBar.Metro.MetroTileItem tileChon(String ma, String ten)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem itChon = new DevComponents.DotNetBar.Metro.MetroTileItem();
            // 
            // itChon
            //
            itChon.Name = ma;
            itChon.SymbolColor = System.Drawing.Color.Empty;
            itChon.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            itChon.TileSize = new System.Drawing.Size(1200, 50);
            itChon.CheckBehavior = DevComponents.DotNetBar.Metro.eMetroTileCheckBehavior.LeftMouseButtonClick;
            if (loai == "Phim")
                itChon.Image = Properties.Resources.ChonPhim;
            else
                itChon.Image = Properties.Resources.ChonPhong;
            // 
            // 
            // 
            itChon.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itChon.TitleText = "           " + ten;
            itChon.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            itChon.TitleTextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            itChon.Click += new System.EventHandler(this.itChon_Click);
            return itChon;
        }

        private DevComponents.DotNetBar.Metro.MetroTileItem tileBanVe(String ma, String ten)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem itChon = new DevComponents.DotNetBar.Metro.MetroTileItem();
            // 
            // itChon
            //
            itChon.Name = ma;
            itChon.SymbolColor = System.Drawing.Color.Empty;
            itChon.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            itChon.CheckBehavior = DevComponents.DotNetBar.Metro.eMetroTileCheckBehavior.LeftMouseButtonClick;
            // 
            // 
            // 
            itChon.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itChon.TitleText = "           " + ten;
            itChon.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            itChon.TitleTextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            itChon.Click += new System.EventHandler(this.itBanVe_Click);
            return itChon;
        }

        private void itBanVe_Click(object sender, EventArgs e)
        {
            if ((sender as DevComponents.DotNetBar.Metro.MetroTileItem).Checked == true)
            {
                if ((sender as DevComponents.DotNetBar.Metro.MetroTileItem).TileSize.Height == 50)
                {
                    foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonPhim.Items)
                        it.Checked = false;
                    (sender as DevComponents.DotNetBar.Metro.MetroTileItem).Checked = true;
                    ipBVChonLich.Items.Clear();
                    ipBVChonPhong.Items.Clear();
                    ipBVChonPhong.Items.Add(tilePhong);
                    ipBVChonLich.Items.Add(tileLich);
                    String[] dmy = dtBVNgayChieu.Value.ToString().Split('/', ' ');
                    String ngay = dmy[0] + "/" + dmy[1] + "/" + dmy[2];
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    dtAdapter = new SqlDataAdapter("select distinct MaPC from LichChieu where MaPhim ='" +
                        (sender as DevComponents.DotNetBar.Metro.MetroTileItem).Name + "' and NgayChieu ='"
                        + ngay + "'", conn);
                    dtTable = new DataTable();
                    dtAdapter.Fill(dtTable);
                    trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        DevComponents.DotNetBar.Metro.MetroTileItem tile = tileBanVe(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][0].ToString());
                        tile.TileSize = new Size(ipBVChonPhong.Width - 2, 51);
                        tile.Image = Properties.Resources.ChonPhong;
                        ipBVChonPhong.Items.Add(tile);
                    }
                    conn.Close();
                    ipBVChonPhong.Enabled = false;
                    ipBVChonPhong.Enabled = true;
                    ipBVChonLich.Enabled = false;
                    ipBVChonLich.Enabled = true;
                }
                else if ((sender as DevComponents.DotNetBar.Metro.MetroTileItem).TileSize.Height == 51)
                {
                    foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonPhong.Items)
                        it.Checked = false;
                    (sender as DevComponents.DotNetBar.Metro.MetroTileItem).Checked = true;
                    ipBVChonLich.Items.Clear();
                    ipBVChonLich.Items.Add(tileLich);
                    String[] dmy = dtBVNgayChieu.Value.ToString().Split('/', ' ');
                    String ngay = dmy[0] + "/" + dmy[1] + "/" + dmy[2];
                    String maPhim = "";
                    foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonPhim.Items)
                        if (it.Checked == true)
                            maPhim = it.Name;
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    dtAdapter = new SqlDataAdapter("Select distinct MaLichChieu, GioChieu  from LichChieu where NgayChieu = '"
                        + ngay + "' and MaPC ='" + (sender as DevComponents.DotNetBar.Metro.MetroTileItem).Name
                        + "' and MaPhim ='" + maPhim + "'", conn);
                    dtTable = new DataTable();
                    dtAdapter.Fill(dtTable);
                    trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        DevComponents.DotNetBar.Metro.MetroTileItem tile = tileBanVe(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString());
                        tile.TileSize = new Size(ipBVChonPhong.Width - 2, 52);
                        tile.Image = doiSize(new Size(50, 50), Properties.Resources.ChonLich);
                        ipBVChonLich.Items.Add(tile);
                    }
                    conn.Close();
                    ipBVChonLich.Enabled = false;
                    ipBVChonLich.Enabled = true;
                }
                else
                {
                    foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonLich.Items)
                        it.Checked = false;
                    (sender as DevComponents.DotNetBar.Metro.MetroTileItem).Checked = true;
                    String maPhong = "";
                    foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonPhong.Items)
                        if (it.Checked == true)
                            maPhong = it.Name;
                    String maLich = "";
                    foreach (DevComponents.DotNetBar.Metro.MetroTileItem it in ipBVChonLich.Items)
                        if (it.Checked == true)
                            maLich = it.Name;
                    loadGhe(maLich);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = new SqlCommand("Select distinct SoCho, SoDay  from PhongChieu where MaPC = '"
                        + maPhong + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    nfBanVe.TransitionType = DevExpress.Utils.Animation.Transitions.Push;
                    nfBanVe.SelectedPage = npSoDo;
                    int soGhe = int.Parse(dr[0].ToString().Trim());
                    int soDay = int.Parse(dr[1].ToString().Trim());
                    ipSoDo.Items.Clear();
                    icGheDaChon.SubItems.Clear();
                    int i;
                    for (i = 0; i < soDay; i++)
                    {
                        ipSoDo.Items.Add(hangGhe(soGhe / soDay, 65 + i));
                    }
                    ipSoDo.Items.Add(hangGhe(soGhe - (soDay) * (soGhe / soDay), 65 + i + 1));
                    conn.Close();
                    ipSoDo.Enabled = false;
                    ipSoDo.Enabled = true;
                    arGheDaChon.Clear();
                    loadGheChon(arGheDaChon);
                    dr.Close();
                }
            }
            else
            {
                if ((sender as DevComponents.DotNetBar.Metro.MetroTileItem).TileSize.Height == 50)
                {
                    ipBVChonLich.Items.Clear();
                    ipBVChonPhong.Items.Clear();
                    ipBVChonLich.Enabled = false;
                    ipBVChonLich.Enabled = true;
                    ipBVChonPhong.Enabled = false;
                    ipBVChonPhong.Enabled = true;
                }
                else if ((sender as DevComponents.DotNetBar.Metro.MetroTileItem).TileSize.Height == 51)
                {
                    ipBVChonLich.Items.Clear();
                    ipBVChonLich.Enabled = false;
                    ipBVChonLich.Enabled = true;
                }

            }
        }

        private DevComponents.DotNetBar.Metro.MetroTileItem tileKetQua(String phim, String ngay, String phong, String gio)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem itKetQua = new DevComponents.DotNetBar.Metro.MetroTileItem();
            // 
            // itKetQua
            // 
            itKetQua.Checked = true;
            itKetQua.Name = phim;
            itKetQua.SymbolColor = System.Drawing.Color.Empty;
            itKetQua.Text = "Tên Phim    : \r" + phim +
                "\r\nNgày Chiếu  : " + ngay +
                "\r\nPhòng Chiếu : " + phong +
                "\r\nGiờ Chiếu   : " + gio;
            itKetQua.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            itKetQua.Image = Properties.Resources.ChonLich;
            itKetQua.Click += new System.EventHandler(this.itKetQua_Click);
            // 
            // 
            // 
            itKetQua.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            return itKetQua;
        }

        private DevComponents.DotNetBar.ItemContainer hangGhe(int soGhe, int ch)
        {
            DevComponents.DotNetBar.ItemContainer igGhe = new DevComponents.DotNetBar.ItemContainer();
            // 
            igGhe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            igGhe.Name = "igGhe";
            // 
            // 
            // 
            for (int i = 0; i < soGhe; i++)
            {
                DevComponents.DotNetBar.ButtonItem bt = ghe((char)ch + " " + (i + 1).ToString());
                bt.Click += new System.EventHandler(this.ghe_Click);
                foreach (String str in arGhe)
                    if (str == bt.NotificationMarkText)
                    {
                        bt.Enabled = false;
                        bt.NotificationMarkColor = Color.Red;
                    }
                igGhe.SubItems.Add(bt);
            }
            return igGhe;
        }

        private void loadGhe(String maLich)
        {
            try {
                arGhe.Clear();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("select Ghe from VeBan where MaLichChieu =" + maLich, conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    String[] danhSachGhe = dtTable.Rows[i][0].ToString().Trim().Split('/');
                    foreach (String str in danhSachGhe)
                        arGhe.Add(str);
                }
                conn.Close();
            }
            catch { }
        }

        private DevComponents.DotNetBar.ButtonItem ghe(String text)
        {

            DevComponents.DotNetBar.ButtonItem ghe = new DevComponents.DotNetBar.ButtonItem();
            // 
            // btGhe
            // 
            ghe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            ghe.FixedSize = new System.Drawing.Size(70, 50);
            ghe.FontBold = true;
            ghe.Image = global::RapPhim.Properties.Resources.ghe;
            ghe.ImageFixedSize = new System.Drawing.Size(45, 45);
            ghe.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            ghe.Name = "ghe";
            ghe.NotificationMarkColor = System.Drawing.Color.Teal;
            ghe.NotificationMarkOffset = new System.Drawing.Point(0, 0);
            ghe.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomLeft;
            ghe.NotificationMarkSize = 30;
            ghe.NotificationMarkText = text;
            ghe.Checked = false;
            return ghe;
        }

        private void ghe_Click(object sender, EventArgs e)
        {
            if ((sender as DevComponents.DotNetBar.ButtonItem).Name == "ghe")
            {
                if (arGheDaChon.Count < 6)
                {
                    (sender as DevComponents.DotNetBar.ButtonItem).Name = "chon";
                    (sender as DevComponents.DotNetBar.ButtonItem).NotificationMarkColor = Color.DarkBlue;
                    arGheDaChon.Add((sender as DevComponents.DotNetBar.ButtonItem).NotificationMarkText);
                }
                else
                    MessageBox.Show("Chỉ có thể chọn tối đa 6 ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                (sender as DevComponents.DotNetBar.ButtonItem).Name = "ghe";
                (sender as DevComponents.DotNetBar.ButtonItem).NotificationMarkColor = Color.Teal;
                for (int i = 0; i <= arGheDaChon.Count; i++)
                {
                    try {
                        if (arGheDaChon[i] == (sender as DevComponents.DotNetBar.ButtonItem).NotificationMarkText)
                            arGheDaChon.RemoveAt(i);
                    }
                    catch { }
                }
            }
            loadGheChon(arGheDaChon);
        }

        private void loadGheChon(List<String> gheDaChon)
        {
            icGheDaChon.SubItems.Clear();
            foreach (String strghe in arGheDaChon)
                icGheDaChon.SubItems.Add(this.ghe(strghe));
            icGheDaChon.Enabled = false;
            icGheDaChon.Enabled = true;
        }

        //
        //Quản lý phim
        private void loadPhim()
        {
            arPhim = new List<Phim>();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("select MaPhim,TenPhim,DaoDien,TheLoai,DienVien,NoiDung,Trailer,NamSX,QuocGia,ThoiLuong from Phim", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                //lay hinh
                Image imHinh = null;
                try
                {
                    cmd = new SqlCommand("select Hinh from Phim where MaPhim ='" + dtTable.Rows[i][0].ToString().Trim() + "'", conn);
                    SqlDataReader drHinh = cmd.ExecuteReader();
                    drHinh.Read();
                    if (drHinh.HasRows)
                    {
                        byte[] btHinh = (byte[])(drHinh[0]);
                        MemoryStream msHinh = new MemoryStream(btHinh);
                        imHinh = Image.FromStream(msHinh);
                        drHinh.Close();
                    }
                }
                catch (Exception)
                {
                    imHinh = Properties.Resources.Phim;
                }
                Phim p = new Phim(dtTable.Rows[i][0].ToString().Trim(), dtTable.Rows[i][1].ToString().Trim(), dtTable.Rows[i][2].ToString().Trim(),
                    dtTable.Rows[i][4].ToString().Trim(), dtTable.Rows[i][3].ToString().Trim(), dtTable.Rows[i][5].ToString().Trim(),
                    dtTable.Rows[i][6].ToString().Trim(), dtTable.Rows[i][8].ToString().Trim(), dtTable.Rows[i][9].ToString().Trim(),
                    int.Parse(dtTable.Rows[i][7].ToString().Trim()), imHinh);
                arPhim.Add(p);
            }
            conn.Close();
            tgPhim.Items.Clear();
            foreach (Phim p in arPhim)
            {
                ITileItem tile = tilePhim(p);
                tile.Enabled = false;
                this.tgPhim.Items.Add(tile);
                tile.Enabled = true;
            }
        }

        private void loadTablePhim()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select MaPhim, TenPhim, DaoDien, DienVien, TheLoai, NamSX, QuocGia, ThoiLuong from Phim", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            dvPhim.DataSource = dtTable;
            conn.Close();
        }

        private void setEnabledPhim(bool b)
        {
            tbMaPhim.ReadOnly = b;
            tbTenPhim.ReadOnly = b;
            tbDaoDien.ReadOnly = b;
            tbDienVien.ReadOnly = b;
            tbTheLoai.ReadOnly = b;
            tbThoiLuong.ReadOnly = b;
            tbQuocGia.ReadOnly = b;
            tbNamSX.ReadOnly = b;
            tbTrailer.ReadOnly = b;
            tbNoiDung.ReadOnly = b;
        }

        private void clearPhim()
        {
            tbMaPhim.Text = "";
            tbTenPhim.Text = "";
            tbDaoDien.Text = "";
            tbDienVien.Text = "";
            tbTheLoai.Text = "";
            tbThoiLuong.Text = "";
            tbQuocGia.Text = "";
            tbNamSX.Text = "";
            tbTrailer.Text = "";
            tbNoiDung.Text = "";
            pbHinh.Image = null;
            erMaPhim.Clear();
            erTenPhim.Clear();
            erTheLoai.Clear();
            erThoiLuong.Clear();
            erTrailer.Clear();
            erDaoDien.Clear();
            erDienVien.Clear();
            erNamSX.Clear();
            erQuocGia.Clear();
            erNoiDung.Clear();
            erHinhPhim.Clear();
        }

        private void loadThongTinPhim()
        {
            try
            {
                if (dvPhim.CurrentCell.RowIndex >= 0)
                {
                    btSuaPhim.Enabled = true;
                    btXoaPhim.Enabled = true;
                    foreach (Phim p in arPhim)
                        if (p.MaPhim == dvPhim.Rows[dvPhim.CurrentCell.RowIndex].Cells[0].Value.ToString())
                        {
                            tbMaPhim.Text = p.MaPhim;
                            tbTenPhim.Text = p.TenPhim;
                            tbDaoDien.Text = p.DaoDien;
                            tbDienVien.Text = p.DienVien;
                            tbTheLoai.Text = p.TheLoai;
                            tbThoiLuong.Text = p.ThoiLuong;
                            tbQuocGia.Text = p.QuocGia;
                            tbNamSX.Text = p.NamSX.ToString();
                            tbTrailer.Text = p.Trailer;
                            tbNoiDung.Text = p.NoiDung;
                            pbHinh.Image = doiSize(pbHinh.Size, p.Hinh);
                        }
                }
            }
            catch (Exception)
            {
                btSuaPhim.Enabled = false;
                btXoaPhim.Enabled = false;
            }
        }

        private bool kiemTraPhim()
        {
            bool b = true;
            if (setErr(erMaPhim, tbMaPhim, "Mã phim không được để trống!"))
                b = false;
            if (setErr(erTenPhim, tbTenPhim, "Tên phim không được để trống!"))
                b = false;
            if (setErr(erDaoDien, tbDaoDien, "Tên đạo diễn không được để trống!"))
                b = false;
            if (setErr(erDienVien, tbDienVien, "Diễn viên không được để trống!"))
                b = false;
            if (setErr(erTheLoai, tbTheLoai, "Thể loại không được để trống!"))
                b = false;
            if (setErr(erThoiLuong, tbThoiLuong, "Thời lượng không được để trống!"))
                b = false;
            if (setErr(erQuocGia, tbQuocGia, "Quốc gia không được để trống!"))
                b = false;
            if (setErr(erNamSX, tbNamSX, "Năm sản xuất không được để trống!"))
                b = false;
            if (setErr(erTrailer, tbTrailer, "Trailer không được để trống!"))
                b = false;
            if (setErr(erNoiDung, tbNoiDung, "Nội dung không được để trống!"))
                b = false;
            if (!tbMaPhim.ReadOnly)
            {
                if (layHinh)
                {
                    erHinhPhim.Icon = Properties.Resources.v;
                    erHinhPhim.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erHinhPhim.SetError(pbHinh, "ok");
                }
                else
                {
                    erHinhPhim.Icon = Properties.Resources.x;
                    erHinhPhim.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erHinhPhim.SetError(pbHinh, "Chưa chọn hình!");
                    b = false;
                }
                foreach (Phim p in arPhim)
                    if (tbMaPhim.Text == p.MaPhim)
                    {
                        erMaPhim.Icon = Properties.Resources.x;
                        erMaPhim.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                        erMaPhim.SetError(tbMaPhim, "Mã phim đã tồn tại!");
                        b = false;
                    }
            }
            return b;
        }

        private void timPhim()
        {
            if (tbTim.Text.Trim() != "" && cbTim.SelectedIndex >= 0)
            {
                tgPhim.Items.Clear();
                foreach (Phim p in arPhim)
                {
                    switch (cbTim.SelectedIndex)
                    {
                        case 0:
                            if (boDau(p.TenPhim.Trim().ToLower()).Contains(boDau(tbTim.Text.Trim().ToLower())))
                            {
                                ITileItem tile = tilePhim(p);
                                tile.Enabled = false;
                                this.tgPhim.Items.Add(tile);
                                tile.Enabled = true;
                            }
                            break;
                        case 1:
                            if (p.DaoDien.Trim().ToLower().Contains(tbTim.Text.Trim().ToLower()))
                            {
                                ITileItem tile = tilePhim(p);
                                tile.Enabled = false;
                                this.tgPhim.Items.Add(tile);
                                tile.Enabled = true;
                            }
                            break;
                        case 2:
                            if (p.DienVien.Trim().ToLower().Contains(tbTim.Text.Trim().ToLower()))
                            {
                                ITileItem tile = tilePhim(p);
                                tile.Enabled = false;
                                this.tgPhim.Items.Add(tile);
                                tile.Enabled = true;
                            }
                            break;
                    }
                }
            }
            else
            {
                loadPhim();
            }
        }

        private void timPhimTable()
        {
            if (tbTimPhim.Text.Trim() != "" && cbTimPhim.SelectedIndex >= 0)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("Select MaPhim, TenPhim, DaoDien, DienVien, TheLoai, NamSX, QuocGia, ThoiLuong from Phim", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                trim();
                switch (cbTimPhim.SelectedIndex)
                {
                    case 0:
                        for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
                            if (!(boDau(dtTable.Rows[i][1].ToString().Trim().ToLower()).Contains(boDau(tbTimPhim.Text.Trim().ToLower()))))
                                dtTable.Rows.RemoveAt(i);
                        break;
                    case 1:
                        for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
                            if (!(boDau(dtTable.Rows[i][2].ToString().Trim().ToLower()).Contains(boDau(tbTimPhim.Text.Trim().ToLower()))))
                                dtTable.Rows.RemoveAt(i);
                        break;
                    case 2:
                        for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
                            if (!(boDau(dtTable.Rows[i][3].ToString().Trim().ToLower()).Contains(boDau(tbTimPhim.Text.Trim().ToLower()))))
                                dtTable.Rows.RemoveAt(i);
                        break;
                }
                dvPhim.DataSource = dtTable;
            }
            else
            {
                loadTablePhim();
            }
        }

        private ITileItem tilePhim(Phim p)
        {
            Random rd = new Random();
            TileItem tiPhim = new TileItem();
            TileItemElement tileItemElement1 = new TileItemElement();
            TileItemElement tileItemElement2 = new TileItemElement();
            TileItemElement tileItemElement3 = new TileItemElement();
            TileItemFrame tileItemFrame1 = new TileItemFrame();
            TileItemFrame tileItemFrame2 = new TileItemFrame();
            tiPhim.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tiPhim.CurrentFrameIndex = 1;
            tileItemElement1.Text = "Thể loai : " + p.TheLoai + "<br>Đạo diễn: " + p.DaoDien +
                "<br>Diễn viên: " + p.DienVien + "<br>Thời lượng: " + p.ThoiLuong + "<br>Năm SX: " + 2015 + "<br>Quốc gia: " + p.QuocGia;
            tiPhim.Elements.Add(tileItemElement1);
            tileItemFrame1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            tileItemFrame1.Appearance.ForeColor = System.Drawing.Color.White;
            tileItemFrame1.Appearance.Options.UseFont = true;
            tileItemFrame1.Appearance.Options.UseForeColor = true;
            tileItemFrame1.BackgroundImage = doiSize(new Size(250, 120), p.Hinh);
            tileItemElement2.Text = p.TenPhim;
            tileItemFrame1.Elements.Add(tileItemElement2);
            tileItemFrame2.Appearance.BackColor = Color.FromArgb(85, 85, 91);//System.Drawing.Color.FromArgb(rd.Next(0,255), rd.Next(0, 255), rd.Next(0, 255));
            tileItemFrame2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            tileItemFrame2.Appearance.ForeColor = System.Drawing.Color.White;
            tileItemFrame2.Appearance.Options.UseBackColor = true;
            tileItemFrame2.Appearance.Options.UseFont = true;
            tileItemFrame2.Appearance.Options.UseForeColor = true;
            tileItemElement3.Text = "Thể loai : " + p.TheLoai + "<br>Đạo diễn: " + p.DaoDien +
                "<br>Diễn viên: " + p.DienVien + "<br>Thời lượng: " + p.ThoiLuong + "<br>Năm SX: " + 2018 + "<br>Quốc gia: " + p.QuocGia;
            tileItemFrame2.Elements.Add(tileItemElement3);
            tiPhim.Frames.Add(tileItemFrame1);
            tiPhim.Frames.Add(tileItemFrame2);
            tiPhim.Id = 0;
            tiPhim.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            tiPhim.Name = p.MaPhim;
            ToolTipTitleItem ttTile = new ToolTipTitleItem();
            SuperToolTip stTile = new SuperToolTip();
            ttTile.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            //ttTile.Image = doiSize(new Size(322, 200), p.Hinh);
            ttTile.Text = p.TenPhim;
            stTile.Items.Add(ttTile);
            tiPhim.SuperTip = stTile;
            tiPhim.ItemClick += new TileItemClickEventHandler(this.tileItem_ItemClick);
            //
            int t = rd.Next(400, 800);
            tileItemFrame1.Interval = t * 10;
            tileItemFrame2.Interval = t * 10;
            return tiPhim;
        }

        private void tileItem_ItemClick(object sender, TileItemEventArgs e)
        {
            foreach (Phim p in arPhim)
                if (p.MaPhim == e.Item.Name)
                {
                    fmThongTinPhim fmPhim = new fmThongTinPhim(p);
                    fmPhim.ShowDialog(this);
                }
        }

        private void itKetQua_Click(object sender, EventArgs e)
        {
            foreach(Phim p in arPhim)
            {
                if(p.TenPhim == (sender as DevComponents.DotNetBar.Metro.MetroTileItem).Name)
                {
                    new fmThongTinPhim(p).ShowDialog(this);
                    break;
                }
            }
        }

        //
        //Quan ly nhan vien
        private void loadTableNV()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select MaNV, HoTen, NgaySinh, GioiTinh, SoCMND, SoDT, ChucVu, QueQuan, ThuongTru from NhanVien", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            dvNhanVien.DataSource = dtTable;
            conn.Close();
        }

        private void loadThongTinNV()
        {
            try
            {
                if (dvNhanVien.CurrentCell.RowIndex >= 0)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = new SqlCommand("select * from NhanVien where MaNV ='" +
                        dvNhanVien.Rows[dvNhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        Image imHinh = null;
                        try
                        {
                            byte[] btHinh = (byte[])(dr[6]);
                            MemoryStream msHinh = new MemoryStream(btHinh);
                            imHinh = Image.FromStream(msHinh);
                        }
                        catch (Exception) { }
                        pbAnhTheNV.Image = doiSize(pbAnhTheNV.Size, imHinh);
                        tbMaNV.Text = dr[0].ToString().Trim();
                        tbHoTenNV.Text = dr[1].ToString().Trim();
                        String[] dmy = dr[2].ToString().Trim().Split('/', ' ');
                        DateTime dt = new DateTime(int.Parse(dmy[2]), int.Parse(dmy[1]), int.Parse(dmy[0]));
                        dtNgaySinhNV.Value = dt;
                        if (dr[3].ToString() == "True")
                            rbNam.Checked = true;
                        else
                            rbNu.Checked = true;
                        tbSoCMND.Text = dr[4].ToString().Trim();
                        tbSoDT.Text = dr[5].ToString().Trim();
                        for (int i = 0; i < 5; i++)
                            if (cbChucVuNV.Items[i].ToString() == dr[7].ToString().Trim())
                            {
                                cbChucVuNV.SelectedIndex = i;
                                break;
                            }
                        tbQueQuanNV.Text = dr[8].ToString().Trim();
                        tbThuongTruNV.Text = dr[9].ToString().Trim();
                        dr.Close();
                    }
                    btSuaNV.Enabled = true;
                    btXoaNV.Enabled = true;
                    conn.Close();
                }
            }
            catch (Exception)
            {
                btSuaNV.Enabled = false;
                btXoaNV.Enabled = false;
            }
        }

        private void timNhanVien()
        {
            if (tbTimNV.Text.Trim() != "" && cbTimNV.SelectedIndex >= 0)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("Select MaNV, HoTen, NgaySinh, GioiTinh, SoCMND, SoDT, ChucVu, QueQuan, ThuongTru from NhanVien", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                trim();
                switch (cbTimPhim.SelectedIndex)
                {
                    case 0:
                        for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
                            if (!(boDau(dtTable.Rows[i][1].ToString().Trim().ToLower()).Contains(boDau(tbTimNV.Text.Trim().ToLower()))))
                                dtTable.Rows.RemoveAt(i);
                        break;
                    case 1:
                        for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
                            if (!(boDau(dtTable.Rows[i][0].ToString().Trim().ToLower()).Contains(boDau(tbTimNV.Text.Trim().ToLower()))))
                                dtTable.Rows.RemoveAt(i);
                        break;
                }
                dvNhanVien.DataSource = dtTable;
            }
            else
                loadTableNV();
        }

        private void clearNhanVien()
        {
            tbMaNV.Text = "";
            tbHoTenNV.Text = "";
            dtNgaySinhNV.Value = DateTime.Now;
            rbNam.Checked = false;
            rbNu.Checked = false;
            tbSoCMND.Text = "";
            tbSoDT.Text = "";
            cbChucVuNV.SelectedIndex = -1;
            tbQueQuanNV.Text = "";
            tbThuongTruNV.Text = "";
            pbAnhTheNV.Image = null;
            erMaNV.Clear();
            erHoTenNV.Clear();
            erNgaySinhNV.Clear();
            erGioiTinhNV.Clear();
            erSoCMNDNV.Clear();
            erSoDTNV.Clear();
            erAnhTheNV.Clear();
            erQueQuanNV.Clear();
            erThuongTruNV.Clear();
            erChucVuNV.Clear();
        }

        private void setEnabledNV(bool b)
        {
            tbMaNV.ReadOnly = b;
            tbHoTenNV.ReadOnly = b;
            dtNgaySinhNV.Enabled = !b;
            gpGioiTinh.Enabled = !b;
            tbSoCMND.ReadOnly = b;
            tbSoDT.ReadOnly = b;
            cbChucVuNV.Enabled = !b;
            tbQueQuanNV.ReadOnly = b;
            tbThuongTruNV.ReadOnly = b;
        }

        private bool kiemTraNV()
        {
            bool b = true;
            if (setErr(erMaNV, tbMaNV, "Mã nhân viên không được để trống!"))
                b = false;
            if (setErr(erHoTenNV, tbHoTenNV, "Họ Tên không được để trống!"))
                b = false;
            if (setErr(erSoCMNDNV, tbSoCMND, "Số chứng minh không được để trống!"))
                b = false;
            if (setErr(erSoDTNV, tbSoDT, "Số điện thoại không được để trống!"))
                b = false;
            if (setErr(erQueQuanNV, tbQueQuanNV, "Quê quán không được để trống!"))
                b = false;
            if (setErr(erThuongTruNV, tbThuongTruNV, "Địa chỉ thường trú không được để trống!"))
                b = false;
            if (!rbNam.Checked && !rbNu.Checked)
            {
                b = false;
                erGioiTinhNV.Icon = Properties.Resources.x;
                erGioiTinhNV.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erGioiTinhNV.SetError(gpGioiTinh, "Chưa chọn giới tính!");
            }
            else
            {
                erGioiTinhNV.Icon = Properties.Resources.v;
                erGioiTinhNV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erGioiTinhNV.SetError(gpGioiTinh, "ok");
            }
            if (dtNgaySinhNV.IsEmpty)
            {
                b = false;
                erNgaySinhNV.Icon = Properties.Resources.x;
                erNgaySinhNV.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erNgaySinhNV.SetError(dtNgaySinhNV, "Chưa chọn ngày sinh!");
            }
            else
            {
                erNgaySinhNV.Icon = Properties.Resources.v;
                erNgaySinhNV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erNgaySinhNV.SetError(dtNgaySinhNV, "ok");
            }
            if (cbChucVuNV.SelectedIndex < 0)
            {
                b = false;
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
            if (!tbMaNV.ReadOnly)
            {
                if (layHinh)
                {
                    erAnhTheNV.Icon = Properties.Resources.v;
                    erAnhTheNV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                    erAnhTheNV.SetError(pbAnhTheNV, "ok");
                }
                else
                {
                    erAnhTheNV.Icon = Properties.Resources.x;
                    erAnhTheNV.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    erAnhTheNV.SetError(pbAnhTheNV, "Chưa chọn hình!");
                    b = false;
                }
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("select HoTen from NhanVien where MaNV ='" + tbMaNV.Text + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                if (dtTable.Rows.Count > 0)
                    b = false;
                conn.Close();
            }
            return b;
        }

        //LichChieu

        private void loadTableLC()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select MaLichChieu, TenPhim, MaPC, NgayChieu, GioChieu from LichChieu, Phim where LichChieu.MaPhim = Phim.MaPhim", conn);
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

        private void clearLichChieu()
        {
            cbTenPhimLC.SelectedIndex = -1;
            cbPhongChieuLC.SelectedIndex = -1;
            dtCNNgayChieu.Value = DateTime.Now;
            cbGio.SelectedIndex = -1;
            cbPhut.SelectedIndex = -1;
            erTenPhimLC.Clear();
            erPhongChieuLC.Clear();
            erNgayChieuLC.Clear();
            erGioChieuLC.Clear();
        }

        private void setEnabledLC(bool b)
        {
            cbTenPhimLC.Enabled = b;
            cbPhongChieuLC.Enabled = b;
            dtCNNgayChieu.Enabled = b;
            cbGio.Enabled = b;
            cbPhut.Enabled = b;
        }

        private void loadThongTinLC()
        {
            try
            {
                if (dvLichChieu.CurrentCell.RowIndex >= 0)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = new SqlCommand("Select TenPhim, MaPC, NgayChieu, GioChieu from LichChieu inner join Phim on (LichChieu.MaPhim = Phim.MaPhim) where MaLichChieu =" +
                        dvLichChieu.Rows[dvLichChieu.CurrentCell.RowIndex].Cells[0].Value.ToString(), conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        for (int i = 0; i < cbTenPhimLC.Items.Count; i++)
                            if (cbTenPhimLC.Items[i].ToString() == dr[0].ToString().Trim())
                            {
                                cbTenPhimLC.SelectedIndex = i;
                                break;
                            }
                        for (int i = 0; i < cbPhongChieuLC.Items.Count; i++)
                            if (cbPhongChieuLC.Items[i].ToString() == dr[1].ToString().Trim())
                            {
                                cbPhongChieuLC.SelectedIndex = i;
                                break;
                            }
                        dtCNNgayChieu.Value = Convert.ToDateTime(dr[2].ToString().Trim().Split(' ')[0]);
                        String[] gioChieu = dr[3].ToString().Trim().Split(':');
                        try
                        {
                            cbGio.SelectedIndex = int.Parse(gioChieu[0]);
                            cbPhut.SelectedIndex = int.Parse(gioChieu[1]);
                        }
                        catch (Exception)
                        {

                        }

                    }
                    dr.Close();
                    conn.Close();
                    btSuaLC.Enabled = true;
                    btXoaLC.Enabled = true;
                }
            }
            catch (Exception)
            {
                btSuaLC.Enabled = false;
                btXoaLC.Enabled = false;
            }
        }

        private bool kiemTraLC()
        {
            bool b = true;
            if (cbTenPhimLC.SelectedIndex < 0)
            {
                b = false;
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
            if (cbPhongChieuLC.SelectedIndex < 0)
            {
                b = false;
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
            if (cbGio.SelectedIndex < 0)
            {
                b = false;
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
                b = false;
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
            if (dtCNNgayChieu.IsEmpty)
            {
                b = false;
                erNgayChieuLC.Icon = Properties.Resources.x;
                erNgayChieuLC.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erNgayChieuLC.SetError(dtCNNgayChieu, "Chưa chọn ngày chiếu!");
            }
            else
            {
                erNgayChieuLC.Icon = Properties.Resources.v;
                erNgayChieuLC.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erNgayChieuLC.SetError(dtCNNgayChieu, "ok");
            }

            return b;
        }

        //LoaiVe
        //

        private void loadTableLV()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select * from LoaiVe", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            dvLoaiVe.DataSource = dtTable;
            conn.Close();
        }

        private void clearLoaiVe()
        {
            tbMaLoaiLV.Text = "";
            tbTenLoaiLV.Text = "";
            tbHangGheLV.Text = "";
            tbDoiTuongLV.Text = "";
            tbGiaBanLV.Text = "";
            ckCN.Checked = false;
            ckT2.Checked = false;
            ckT3.Checked = false;
            ckT4.Checked = false;
            ckT5.Checked = false;
            ckT6.Checked = false;
            ckT7.Checked = false;
            erMaLoaiLV.Clear();
            erTenLoaiLV.Clear();
            erHangGheLV.Clear();
            erDoiTuongLV.Clear();
            erGiaBanLV.Clear();
            erNgayBanLV.Clear();
        }

        private void setEnabledLV(bool b)
        {
            tbTenLoaiLV.ReadOnly = !b;
            tbMaLoaiLV.ReadOnly = !b;
            tbHangGheLV.ReadOnly = !b;
            tbDoiTuongLV.ReadOnly = !b;
            tbGiaBanLV.ReadOnly = !b;
            grNgayBan.Enabled = b;
        }

        private void loadThongTinLV()
        {
            try
            {
                if (dvLoaiVe.CurrentCell.RowIndex >= 0)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = new SqlCommand("Select * from LoaiVe where MaLoai ='" +
                        dvLoaiVe.Rows[dvLoaiVe.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        tbMaLoaiLV.Text = dr[0].ToString().Trim();
                        tbTenLoaiLV.Text = dr[1].ToString().Trim();
                        tbHangGheLV.Text = dr[2].ToString().Trim();
                        tbDoiTuongLV.Text = dr[4].ToString().Trim();
                        tbGiaBanLV.Text = dr[5].ToString().Trim();

                        String[] ngayBan = dr[3].ToString().Trim().Split('/');
                        bool t2 = false, t3 = false, t4 = false, t5 = false, t6 = false, t7 = false, cn = false;
                        foreach (String thu in ngayBan)
                        {
                            if (thu == "Thứ Hai")
                                t2 = true;
                            if (thu == "Thứ Ba")
                                t3 = true;
                            if (thu == "Thứ Tư")
                                t4 = true;
                            if (thu == "Thứ Năm")
                                t5 = true;
                            if (thu == "Thứ Sáu")
                                t6 = true;
                            if (thu == "Thứ Bảy")
                                t7 = true;
                            if (thu == "Chủ Nhật")
                                cn = true;
                        }
                        ckT2.Checked = t2;
                        ckT3.Checked = t3;
                        ckT4.Checked = t4;
                        ckT5.Checked = t5;
                        ckT6.Checked = t6;
                        ckT7.Checked = t7;
                        ckCN.Checked = cn;

                    }
                    dr.Close();
                    conn.Close();
                    btSuaLV.Enabled = true;
                    btXoaLV.Enabled = true;
                }
            }
            catch (Exception)
            {
                btSuaLV.Enabled = false;
                btXoaLV.Enabled = false;
            }
        }

        private bool kiemTraLV()
        {
            bool b = true;
            if (setErr(erMaLoaiLV, tbMaLoaiLV, "Mã loại vé không được để trống!"))
                b = false;
            if (setErr(erTenLoaiLV, tbTenLoaiLV, "Tên loại vé không được để trống!"))
                b = false;
            if (setErr(erHangGheLV, tbHangGheLV, "Hàng ghế không được để trống!"))
                b = false;
            if (setErr(erDoiTuongLV, tbDoiTuongLV, "Đối tượng không được để trống!"))
                b = false;
            if (setErr(erGiaBanLV, tbGiaBanLV, "Giá bán không được để trống!"))
                b = false;
            if (!ckCN.Checked && !ckT2.Checked && !ckT3.Checked && !ckT4.Checked && !ckT5.Checked && !ckT6.Checked && !ckT7.Checked)
            {
                b = false;
                erNgayBanLV.Icon = Properties.Resources.x;
                erNgayBanLV.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erNgayBanLV.SetError(grNgayBan, "Chưa chọn phim!");
            }
            else
            {
                erNgayBanLV.Icon = Properties.Resources.v;
                erNgayBanLV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erNgayBanLV.SetError(grNgayBan, "ok");
            }
            if (!tbMaLoaiLV.ReadOnly)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("select TenLoai from LoaiVe where MaLoai ='" + tbMaLoaiLV.Text.Trim() + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                if (dtTable.Rows.Count > 0)
                    b = false;
                conn.Close();
            }
            return b;
        }

        //PhongChieu
        //

        private void loadTablePC()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select * from PhongChieu", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            trim();
            dvPhongChieu.DataSource = dtTable;
            conn.Close();
        }

        private void clearPhongChieu()
        {
            tbPhongChieu.Text = "";
            tbSoCho.Text = "";
            tbSoDay.Text = "";
            tbMayChieu.Text = "";
            tbAmThanh.Text = "";
            tbDienTich.Text = "";
            tbTinhTrang.Text = "";
            tbThietBị.Text = "";
            erPCPhong.Clear();
            erPCSoCho.Clear();
            erPCSoDay.Clear();
            erPCMayChieu.Clear();
            erPCAmThanh.Clear();
            erPCDienTich.Clear();
            erPCTinhTrang.Clear();
            erPCThietBi.Clear();
        }

        private void setEnabledPC(bool b)
        {
            tbPhongChieu.ReadOnly = !b;
            tbSoCho.ReadOnly = !b;
            tbSoDay.ReadOnly = !b;
            tbDienTich.ReadOnly = !b;
            tbMayChieu.ReadOnly = !b;
            tbAmThanh.ReadOnly = !b;
            tbTinhTrang.ReadOnly = !b;
            tbThietBị.ReadOnly = !b;
        }

        private void loadThongTinPC()
        {
            try
            {
                if (dvPhongChieu.CurrentCell.RowIndex >= 0)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd = new SqlCommand("Select * from PhongChieu where MaPC ='" +
                        dvPhongChieu.Rows[dvPhongChieu.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        tbPhongChieu.Text = dr[0].ToString().Trim();
                        tbSoCho.Text = dr[1].ToString().Trim();
                        tbSoDay.Text = dr[2].ToString().Trim();
                        tbMayChieu.Text = dr[3].ToString().Trim();
                        tbAmThanh.Text = dr[4].ToString().Trim();
                        tbDienTich.Text = dr[5].ToString().Trim();
                        tbTinhTrang.Text = dr[6].ToString().Trim();
                        tbThietBị.Text = dr[7].ToString().Trim();

                    }
                    dr.Close();
                    conn.Close();
                    btSuaPC.Enabled = true;
                    btXoaPC.Enabled = true;
                }
            }
            catch (Exception)
            {
                btSuaPC.Enabled = false;
                btXoaPC.Enabled = false;
            }
        }

        private bool kiemTraPC()
        {
            bool b = true;
            if (setErr(erPCPhong, tbPhongChieu, "Mã phòng chiếu không được để trống!"))
                b = false;
            if (setErr(erPCSoCho, tbSoCho, "Số chỗ không được để trống!"))
                b = false;
            if (setErr(erPCSoDay, tbSoDay, "Số dãy không được để trống!"))
                b = false;
            if (setErr(erPCMayChieu, tbMayChieu, "Máy chiếu không được để trống!"))
                b = false;
            if (setErr(erPCAmThanh, tbAmThanh, "Âm thanh không được để trống!"))
                b = false;
            if (setErr(erPCDienTich, tbDienTich, "Diện tích không được để trống!"))
                b = false;
            if (!tbPhongChieu.ReadOnly)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("select DienTich from PhongChieu where MaPC ='" + tbPhongChieu.Text.Trim() + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                if (dtTable.Rows.Count > 0)
                    b = false;
                conn.Close();
            }
            return b;
        }

        private void timPhong()
        {
            if (tbTimPhongChieu.Text.Trim() != "")
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("Select * from PhongChieu", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                trim();
                for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
                    if (!(boDau(dtTable.Rows[i][0].ToString().Trim().ToLower()).Contains(boDau(tbTimPhongChieu.Text.Trim().ToLower()))))
                        dtTable.Rows.RemoveAt(i);
                dvPhongChieu.DataSource = dtTable;
            }
            else
                loadTablePC();
        }

        //
        //ve

        private bool kiemTraKH()
        {
            bool b = true;
            if (setErr(erHoTenKH, tbHoTenKH, "Tên khách hàng không được để trống!"))
                b = false;
            if (setErr(erSoDTKH, tbSoDTKH, "Số điện thoại khách hàng không được để trống!"))
                b = false;
            if (cbLoaiVeKH.SelectedIndex < 0)
            {
                b = false;
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
            return b;
        }

        ///

        ///
        //Biểu đồ
        private void loadThongKeNgay(String ngay)
        {
            srTKNgay.Points.Clear();
            if (cbTKPhim.SelectedIndex >= 0)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtAdapter = new SqlDataAdapter("Select Gia*SoLuong, VAT from LoaiVe, VeBan, LichChieu where LoaiVe = MaLoai and VeBan.MaLichChieu = LichChieu.MaLichChieu and NgayChieu = '" + ngay + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                double tongTien = 0;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    long gia = long.Parse(dtTable.Rows[i][0].ToString());
                    long vat = long.Parse(dtTable.Rows[i][1].ToString());
                    double tien = gia + gia * (vat / (float)100);
                    tongTien += tien;
                }
                dtAdapter = new SqlDataAdapter("Select Gia*SoLuong, VAT from LoaiVe, VeBan, LichChieu where LoaiVe = MaLoai and VeBan.MaLichChieu = LichChieu.MaLichChieu and NgayChieu = '"
                    + ngay + "' and MaPhim = '" + cbTKPhim.SelectedValue.ToString().Trim() + "'", conn);
                dtTable = new DataTable();
                dtAdapter.Fill(dtTable);
                double tongTienPhim = 0;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    long gia = long.Parse(dtTable.Rows[i][0].ToString());
                    long vat = long.Parse(dtTable.Rows[i][1].ToString());
                    double tien = gia + gia * (vat / (float)100);
                    tongTienPhim += tien;
                }
                DevExpress.XtraCharts.SeriesPoint ssPhim = new DevExpress.XtraCharts.SeriesPoint(cbTKPhim.Text, new double[] { tongTienPhim });
                DevExpress.XtraCharts.SeriesPoint ss = new DevExpress.XtraCharts.SeriesPoint("Khác", new double[] { tongTien - tongTienPhim });
                ss.ColorSerializable = "#1F497D";
                ssPhim.ColorSerializable = "#95B3D7";
                srTKNgay.Points.Add(ss);
                srTKNgay.Points.Add(ssPhim);
                conn.Close();
            }
        }

        private void loadThongKe(String ngay)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            dtAdapter = new SqlDataAdapter("Select Gia*SoLuong, VAT from LoaiVe, VeBan, LichChieu where LoaiVe = MaLoai and VeBan.MaLichChieu = LichChieu.MaLichChieu and NgayChieu = '" + ngay + "'", conn);
            dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            double tongTien = 0;
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                long gia = long.Parse(dtTable.Rows[i][0].ToString());
                long vat = long.Parse(dtTable.Rows[i][1].ToString());
                double tien = gia + gia * (vat / (float)100);
                tongTien += tien;
            }
            tongDoanhThu += tongTien;
            String[] dmy = ngay.Split('-');
            ngay = dmy[2] + "-" + dmy[1] + "-" + dmy[0];
            DevExpress.XtraCharts.SeriesPoint ss = new DevExpress.XtraCharts.SeriesPoint(ngay, new double[] { tongTien });
            ss.ColorSerializable = "#4F81BD";
            srThongKe.Points.Add(ss);
        }

        //private DevExpress.XtraCharts.Series srThongKe()
        //{
        //    ///0
        //    /// 
        //    DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
        //    DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
        //    DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView1 = new DevExpress.XtraCharts.SplineAreaSeriesView();
        //    ///1
        //    /// 
        //    ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).BeginInit();
        //    ///2
        //    /// 
        //    ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit(); pointSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //    pointSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
        //    pointSeriesLabel1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        //    pointSeriesLabel1.LineLength = 14;
        //    pointSeriesLabel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(108)))), ((int)(((byte)(9)))));
        //    pointSeriesLabel1.TextPattern = "{V:c1}";
        //    series1.Label = pointSeriesLabel1;
        //    series1.Label = pointSeriesLabel1;
        //    series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
        //    series1.Name = "Series 1";
        //    //series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
        //    //seriesPoint1,
        //    //seriesPoint2,
        //    //seriesPoint3,
        //    //seriesPoint4,
        //    //seriesPoint5,
        //    //seriesPoint6,
        //    //seriesPoint7,
        //    //seriesPoint8,
        //    //seriesPoint9});
        //    splineAreaSeriesView1.Transparency = ((byte)(0));
        //    series1.View = splineAreaSeriesView1;

        //    ///3
        //    /// 
        //    ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
        //    return series1;
        //}

        //private DevExpress.XtraCharts.Series srTKNgay()
        //{
        //    ///0
        //    /// 
        //    DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
        //    DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
        //    DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
        //    ///1
        //    /// 
        //    ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();


        //    ///2
        //    /// 

        //    series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
        //    pieSeriesLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
        //    pieSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
        //    pieSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
        //    pieSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
        //    pieSeriesLabel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        //    pieSeriesLabel1.TextPattern = "{A} : {V}";
        //    series2.Label = pieSeriesLabel1;
        //    series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
        //    series2.Name = "ssTKNgay";
        //    //series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
        //    //seriesPoint10,
        //    //seriesPoint11});
        //    series2.View = pieSeriesView1;


        //    ///3
        //    /// 
        //    ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();


        //    return series2;
        //}
        

            //
        }
}
