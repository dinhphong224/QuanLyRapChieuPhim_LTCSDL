using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapPhim
{
    class LichChieu
    {
        String maLC, tenPhim, ngayChieu, caChieu, phongChieu;

        public String MaLC { get { return maLC; } }
        public String TenPhim { get { return tenPhim; } }
        public String NgayChieu { get { return ngayChieu; } }
        public String CaChieu { get { return caChieu; } }
        public String PhongChieu { get { return phongChieu; } }

        public LichChieu() { maLC = ""; tenPhim = ""; ngayChieu = ""; caChieu = ""; phongChieu = "";  }
        
        public LichChieu( String maLC, String tenPhim, String ngayChieu, String caChieu, String phongChieu )
        {
            this.maLC = maLC;
            this.tenPhim = tenPhim;
            this.ngayChieu = ngayChieu;
            this.caChieu = caChieu;
            this.phongChieu = phongChieu;
        }
    }

    class LoaiVe
    {
        String maLoai, tenLoai, hangGhe, ngayBan, doiTuong, gia;
        public String MaLoai { get { return maLoai; } }
        public String TenLoai { get { return tenLoai; } }
        public String HangGhe { get { return hangGhe; } }
        public String NgayBan { get { return ngayBan; } }
        public String DoiTuong { get { return doiTuong; } }
        public String Gia { get { return gia; } }

        public LoaiVe()
        {
            maLoai = ""; tenLoai = ""; hangGhe = ""; ngayBan = ""; doiTuong = ""; gia = "";
        }

        public LoaiVe(String maLoai, String tenLoai, String hangGhe, String ngayBan, String doiTuong, String gia)
        {
            this.maLoai = maLoai; this.tenLoai = tenLoai; this.hangGhe = hangGhe;
            this.doiTuong = doiTuong; this.gia = gia;this.ngayBan = ngayBan;
        }
    }

    class NhanVien
    {
        String maNV, hoTen, ngaySinh, soCMND, soDT, chucVu, queQuan, thuongTru;
        bool gioiTinh;
        System.Drawing.Image hinhThe;
        public String MaNV { get { return maNV; } }
        public String HoTen { get { return hoTen; } }
        public String NgaySinh { get { return ngaySinh; } }
        public String SoCMND { get { return soCMND; } }
        public String SoDT { get { return soDT; } }
        public String ChucVu { get { return chucVu; } }
        public String QueQuan { get { return queQuan; } }
        public String ThuongTru { get { return thuongTru; } }
        public bool GioiTinh { get { return gioiTinh; } }
        public System.Drawing.Image HinhThe { get { return hinhThe; } }

        public NhanVien()
        {
            maNV = "";
            hoTen = "";
            ngaySinh = "";
            gioiTinh = false;
            hinhThe = null;
            soCMND = "";
            soDT = "";
            chucVu = "";
            queQuan = "";
            thuongTru = "";
        }

        public NhanVien(String maNV, String hoTen, String ngaySinh, 
            bool gioiTinh, System.Drawing.Image hinhThe, String soCMND,
            String soDT, String chucVu, String queQuan, String thuongTru)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.hinhThe = hinhThe;
            this.soCMND = soCMND;
            this.soDT = soDT;
            this.chucVu = chucVu;
            this.queQuan = queQuan;
            this.thuongTru = thuongTru;
        }
    }

    public class Phim
    {
        String maPhim, tenPhim, daoDien, theLoai, dienVien, noiDung, traiLer, quocGia, thoiLuong;
        int namSX;
        System.Drawing.Image hinh;
        public String MaPhim { get { return maPhim; } }
        public String TenPhim { get { return tenPhim; } }
        public String DaoDien { get { return daoDien; } }
        public String TheLoai { get { return theLoai; } }
        public String DienVien { get { return dienVien; } }
        public String NoiDung { get { return noiDung; } }
        public String Trailer { get { return traiLer; } }
        public String QuocGia { get { return quocGia; } }
        public String ThoiLuong { get { return thoiLuong; } }
        public int NamSX { get { return namSX; } }
        public System.Drawing.Image Hinh { get { return hinh; } }

        public Phim()
        {
            maPhim = "";
            tenPhim = "";
            daoDien = "";
            theLoai = "";
            dienVien = "";
            noiDung = "";
            traiLer = "";
            quocGia = "";
            thoiLuong = "";
            namSX = 0;
            hinh = null;
        }

        public Phim(String maPhim, String tenPhim, String daoDien, String dienVien, String theLoai
            , String noiDung, String traiLer, String quocGia, String thoiLuong, int namSX, System.Drawing.Image hinh)
        {
            this.maPhim = maPhim;
            this.tenPhim = tenPhim;
            this.daoDien = daoDien;
            this.theLoai = theLoai;
            this.dienVien = dienVien;
            this.noiDung = noiDung;
            this.traiLer = traiLer;
            this.quocGia = quocGia;
            this.thoiLuong = thoiLuong;
            this.namSX = namSX;
            this.hinh = hinh;
        }
    }

    class PhongChieu
    {
        String maPC, mayChieu, amThanh, dienTich, tinhTrang, thietBiKhac;
        int soCho, soDay;
        public String MaPC { get { return maPC; } }
        public String MayChieu { get { return mayChieu; } }
        public String AmThanh { get { return amThanh; } }
        public String DienTich { get { return dienTich; } }
        public String TinhTrang { get { return tinhTrang; } }
        public String ThietBiKhac { get { return thietBiKhac; } }
        public int SoCho { get { return soCho; } }
        public int SoDay { get { return soDay; } }

        public PhongChieu()
        {
            maPC = "";
            mayChieu = "";
            amThanh = "";
            dienTich = "";
            tinhTrang = "";
            thietBiKhac = "";
            soCho = 0;
            soDay = 0;
        }

        public PhongChieu(String maPC, int soCho, int soDay, String mayChieu, 
            String amThanh, String dienTich, String tinhTrang, String thietBiKhac)
        {
            maPC = "";
            mayChieu = "";
            amThanh = "";
            dienTich = "";
            tinhTrang = "";
            thietBiKhac = "";
            soCho = 0;
            soDay = 0;
        }
    }

    class VeBan
    {
        String maVe, nguoiMua, soDT, maLichChieu, loaiVe, vAT, nguoiBan; int soLuong;
        public String MaVe { get { return maVe; } }
        public String NguoiMua { get { return nguoiMua; } }
        public String SoDT { get { return soDT; } }
        public String MaLichChieu { get { return maLichChieu; } }
        public String LoaiVe { get { return loaiVe; } }
        public String VAT { get { return vAT; } }
        public String NguoiBan { get { return nguoiBan; } }
        public int SoLuong { get { return soLuong; } }

        public VeBan()
        {
            maVe = "";
            nguoiMua = "";
            soDT = "";
            maLichChieu = "";
            loaiVe = "";
            vAT = "";
            nguoiBan = "";
            soLuong = 0;
        }

        public VeBan(String maVe, String nguoiMua, String soDT, int soLuong, String maLichChieu, String loaiVe
            , String vAT, String nguoiBan)
        {
            this.maVe = maVe;
            this.nguoiMua = nguoiMua;
            this.soDT = "";
            this.maLichChieu = maLichChieu;
            this.loaiVe = loaiVe;
            this.vAT = vAT;
            this.nguoiBan = nguoiBan;
            this.soLuong = soLuong;
        }
    }

    class DuLieu
    {
        public String loai, ma, ten;
    }
}
