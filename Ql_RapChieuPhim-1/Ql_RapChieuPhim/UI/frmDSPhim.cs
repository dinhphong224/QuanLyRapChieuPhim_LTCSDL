using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connector;
using Model;
using System.Data.SqlClient;
namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        congketnoi ketnoi = new congketnoi();
        PHIM p = new PHIM();


        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoicsdl();

        }
        private void ketnoicsdl()
        {
            ketnoi.cnn.Close();
            dataGridView1.DataSource = ketnoi.laydulieu("PHIM");
            txtMaPhim.Text = ketnoi.layid("maphim").ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhim.Text = ketnoi.layid("maphim").ToString();
            p.MAPHIM = txtMaPhim.Text;
            p.MATL = txtMTL.Text;
            p.NAMSX = Convert.ToInt32(txtNamSX.Text);
            p.NgayKhoiChieu = Convert.ToDateTime(txtDate.Text);
            p.QuocGia = txtQuocGia.Text;
            p.TENPHIM = txtTenPhim.Text;
            p.Daodien = txtDaoDien.Text;
            ketnoi.connect.PHIMs.Add(p);
            ketnoi.connect.SaveChanges();
            ketnoicsdl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            var mp = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            PHIM ph = ketnoi.connect.PHIMs.Single(p => p.MAPHIM.Equals(mp));
            ketnoi.connect.PHIMs.Remove(ph);
            ketnoi.connect.SaveChanges();
            ketnoicsdl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mp = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            PHIM ph = ketnoi.connect.PHIMs.Single(p => p.MAPHIM.Equals(mp));
           // p.MAPHIM = txtMaPhim.Text;
            ph.MATL = txtMTL.Text;
            ph.NAMSX = Convert.ToInt32(txtNamSX.Text);
            ph.NgayKhoiChieu = Convert.ToDateTime(txtDate.Text);
            ph.QuocGia = txtQuocGia.Text;
            ph.TENPHIM = txtTenPhim.Text;
            ph.Daodien = txtDaoDien.Text;
            ketnoi.connect.SaveChanges();
            ketnoicsdl();
        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var mp = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            PHIM ph = ketnoi.connect.PHIMs.Single(p => p.MAPHIM.Equals(mp));
            txtMaPhim.Text = ph.MAPHIM.ToString();
            txtMTL.Text = ph.MATL.ToString();
            txtNamSX.Text = ph.NAMSX.ToString();
            txtDate.Text = ph.NgayKhoiChieu.ToString();
            txtQuocGia.Text = ph.QuocGia;
            txtTenPhim.Text = ph.TENPHIM.ToString();
            txtDaoDien.Text = ph.Daodien;

        }
    }
}
