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
    public partial class frmMuaVe : Form
    {
        public frmMuaVe()
        {
            InitializeComponent();
        }
        congketnoi ketnoi = new congketnoi();
        TextBox txtMHD = new TextBox();
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ketnoirap()
        {
            ketnoi.cnn.Close();
            cbbRap.DataSource = ketnoi.truyvan("exec ProcRap N'" + cbbPhim.Text + "', '" + cbbDD.Text + "', '"+cbbSuat.Text+"'");
            cbbRap.ValueMember = "TENRAP";
            cbbRap.DisplayMember = "TENRAP";
             ketnoi.cnn.Close();
        }
        public int laysl()
        {
          
            ketnoi.cnn.Open();
            string sql = "EXEC SLghe N'" + cbbRap.Text+"'";
            SqlCommand com = new SqlCommand(sql, ketnoi.cnn);
            return (int)com.ExecuteScalar();
        }
        public string laygia()
        {
            ketnoi.cnn.Open();
            string sql = "exec dongia N'" +cbbPhim.Text+"', N'"+ cbbDD.Text +"'";
            SqlCommand com = new SqlCommand(sql, ketnoi.cnn);
            return (string)com.ExecuteScalar();
        }


        private void ketnoiphim()
        {
            
            ketnoi.cnn.Close();
            cbbPhim.DataSource= ketnoi.truyvan("select TENPHIM from PHIM LEFT JOIN LICHCHIEU ON PHIM.MAPHIM = LICHCHIEU.MAPHIM group by TENPHIM");
            cbbPhim.ValueMember = "TENPHIM";
            cbbPhim.DisplayMember = "TENPHIM";
            
           
        }
        private void cmbMGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoisuat();

            ketnoi.cnn.Close();
           
            txtDonGIa.Text = laygia();
            ketnoi.cnn.Close();



        }
        private void ketnoisuat()
        {
            ketnoi.cnn.Close();
            cbbSuat.DataSource = ketnoi.truyvan("exec suat N'" + cbbPhim.Text + "', '"+cbbDD.Text+"'");
            cbbSuat.ValueMember = "GIOCHIEU";
            cbbSuat.DisplayMember = "GIOCHIEU";

        }
        private void txtMKH_TextChanged(object sender, EventArgs e)
        {
           
    
        }
        private void frmMuaVe_Load(object sender, EventArgs e)
        {
      
            txtMKH.Text = ketnoi.layid("makh").ToString();
            ketnoi.cnn.Close();
            ketnoiphim();          
        }
        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGIa.Text == null)
                txtDonGIa.Text = "0";
            txtThanhTien.Text = (Convert.ToInt32(txtSL.Text) * Convert.ToInt32(txtDonGIa.Text)).ToString();
        }
        private void cbbSuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoirap();
        }

        private void cbbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoisuat();
            ketnoi.cnn.Close();
            txtDonGIa.Text = laygia();
            ketnoi.cnn.Close();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                txtMKH.Text = ketnoi.layid("makh").ToString();
                ketnoi.cnn.Close();
                HOADON hd = new HOADON();
                hd.SLGHEMUA = Convert.ToInt32(txtSL.Text);
                hd.THANHTIEN = txtThanhTien.Text;
                txtMHD.Text = ketnoi.layid("MaHoaDon");
                hd.MAHD = txtMHD.Text;
                ketnoi.cnn.Close();
                hd.MAKH = txtMKH.Text;
                hd.MAPHIM = ketnoi.layid("chonmp " + "'" + cbbPhim.Text + "'");
                ketnoi.cnn.Close();
                txtMHD.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                hd.NGAYLAPHD = Convert.ToDateTime(txtMHD.Text);
                hd.SUATCHIEU = cbbSuat.Text;
                ketnoi.connect.HOADONs.Add(hd);
                ketnoi.connect.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
                
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
        private void cbbRap_SelectedIndexChanged(object sender, EventArgs e)
        {
         

        }
        private void cbbRap_TextChanged(object sender, EventArgs e)
        {
       
        }
        private void cbbRap_TextUpdate(object sender, EventArgs e)
        {

        }
        private void cbbRap_DisplayMemberChanged(object sender, EventArgs e)
        {

        }
        private void cbbPhim_DisplayMemberChanged(object sender, EventArgs e)
        {
            ketnoi.cnn.Close();
            txtDonGIa.Text = laygia();
            ketnoi.cnn.Close();
        }
        private void cbbDD_DisplayMemberChanged(object sender, EventArgs e)
        {
            ketnoi.cnn.Close();
            txtDonGIa.Text = laygia();
            ketnoi.cnn.Close();
        }
        private void btnIHD_Click(object sender, EventArgs e)
        {
           

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSGT_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbRap_Click(object sender, EventArgs e)
        {

        }

        private void cbbRap_MouseCaptureChanged(object sender, EventArgs e)
        {
    
        }

        private void cbbRap_SelectedValueChanged(object sender, EventArgs e)
        {
        
        }

        private void btnktg_Click(object sender, EventArgs e)
        {
            ketnoi.cnn.Close();
            txtSGT.Text = laysl().ToString();
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtDonGIa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
