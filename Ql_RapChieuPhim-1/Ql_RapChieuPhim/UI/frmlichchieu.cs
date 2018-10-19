using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Connector;

namespace UI
{
    public partial class frmlichchieu : Form
    {
        public frmlichchieu()
        {
            InitializeComponent();
        }
        congketnoi ketnoi = new congketnoi();
        LICHCHIEU lc = new LICHCHIEU();
        private void ketnoicsdl()
        {
            ketnoi.cnn.Close();
            dataGridView1.DataSource = ketnoi.laydulieu("LICHCHIEU");
        }
        private void frmlichchieu_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            txtMaLC.Text = ketnoi.layid("malichchieu").ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            txtMaLC.Text = ketnoi.layid("malichchieu").ToString() ;
            lc.MALICHCHIEU = txtMaLC.Text;
            lc.MAPHIM = txtMaPhim.Text;
            lc.THOILUONG = Convert.ToInt32(txtThoiLuong.Text);
            lc.GIOCHIEU =  txtGioChieu.Text;
            lc.NGAYCHIEU =Convert.ToDateTime(txtNgayChieu.Text);
            lc.MALICHCHIEU = txtMaLC.Text;
            lc.GIA = txtGia.Text;
            ketnoi.connect.LICHCHIEUx.Add(lc);
            ketnoi.connect.SaveChanges();
            ketnoicsdl(); 
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mlc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            LICHCHIEU lc = ketnoi.connect.LICHCHIEUx.Single(p => p.MALICHCHIEU.Equals(mlc));
            // p.MAPHIM = txtMaPhim.Text;
            lc.MALICHCHIEU = txtMaLC.Text;
            lc.MAPHIM = txtMaPhim.Text;
            lc.THOILUONG = Convert.ToInt32(txtThoiLuong.Text);
            lc.GIOCHIEU = txtGioChieu.Text;
            lc.NGAYCHIEU = Convert.ToDateTime(txtNgayChieu.Text);
            lc.GIA = txtGia.Text;
            lc.LOAICHIEU = txtMaLC.Text;
            ketnoi.connect.SaveChanges();
            ketnoicsdl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var mlc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            LICHCHIEU lc = ketnoi.connect.LICHCHIEUx.Single(p => p.MALICHCHIEU.Equals(mlc));
            ketnoi.connect.LICHCHIEUx.Remove(lc);
            ketnoi.connect.SaveChanges();
            ketnoicsdl();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var mlc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            LICHCHIEU lc = ketnoi.connect.LICHCHIEUx.Single(p => p.MALICHCHIEU.Equals(mlc));
            txtGioChieu.Text = lc.GIOCHIEU.ToString();
            txtLoaiChieu.Text = lc.LOAICHIEU.ToString();
            txtMaLC.Text = lc.LOAICHIEU.ToString();
            txtMaPhim.Text = lc.MAPHIM.ToString();
            txtNgayChieu.Text = lc.NGAYCHIEU.ToString();
            txtThoiLuong.Text = lc.THOILUONG.ToString();
            txtGia.Text = lc.GIA.ToString();
        }
    }
}
