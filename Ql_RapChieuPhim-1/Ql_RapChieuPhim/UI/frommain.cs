using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frommain : Form
    {
        public frommain()
        {
            InitializeComponent();
        }
        Form1 frmphim = new Form1();
        frmlichchieu frmlc = new frmlichchieu();
        frmMuaVe frmmv = new frmMuaVe();
        formHoaDon frmhoadon = new formHoaDon();
        formrap frmrap = new formrap();
        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmphim.MdiParent = this;
            pictureBox1.Hide();
            frmphim.Show();
            frmphim.StartPosition = FormStartPosition.Manual;
            frmlc.Location = new Point(0, 0);
            frmlc.Hide();
            frmmv.Hide();
            frmhoadon.Hide();
            btnDatVe.Hide();
            frmrap.Hide();
        }

        private void lịchChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlc.MdiParent = this;
            pictureBox1.Hide();
            frmlc.Show();
            frmlc.StartPosition = FormStartPosition.Manual;
            frmlc.Location = new Point(0, 0);
            frmphim.Hide();
            frmmv.Hide();
            frmhoadon.Hide();
            btnDatVe.Hide();
            frmrap.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnktg_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void rạpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrap.MdiParent = this;
            pictureBox1.Hide();
            frmrap.Show();
            frmrap.StartPosition = FormStartPosition.Manual;
            frmrap.Location = new Point(0, 0);
            frmphim.Hide();
            frmmv.Hide();
            frmlc.Hide();
            frmhoadon.Hide();
            btnDatVe.Hide();
            

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmhoadon.MdiParent = this;
            pictureBox1.Hide();
            frmhoadon.Show();
            frmhoadon.StartPosition = FormStartPosition.Manual;
            frmhoadon.Location = new Point(0, 0);
            frmphim.Hide();
            frmmv.Hide();
            frmlc.Hide();
            frmrap.Hide();
            btnDatVe.Hide();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtDonGIa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbbRap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbSuat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnIHD_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSGT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmmv.Show();
        }
    }
}
