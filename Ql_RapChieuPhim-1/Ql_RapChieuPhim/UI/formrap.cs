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
using System.Data.SqlClient;

namespace UI
{
    public partial class formrap : Form
    {
        public formrap()
        {
            InitializeComponent();
        }
        congketnoi ketnoi = new congketnoi();
        RAP r = new RAP();
        private void ketnoicsdl()
        {
            ketnoi.cnn.Close();
            dataGridView1.DataSource = ketnoi.laydulieu("RAP");
        }
        private void formrap_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
           txtMaRap.Text = ketnoi.layid("marap");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaRap.Text = ketnoi.layid("marap");
            r.MARAP = txtMaRap.Text;
            r.TENRAP = this.txtTenRap.Text;
            r.THONGTINRAP = txtThongTinRap.Text;
            r.SLGHE = Convert.ToInt32(txtSLG.Text);
            ketnoi.connect.RAPs.Add(r);
            ketnoi.connect.SaveChanges();
            ketnoicsdl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mr = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            RAP r = ketnoi.connect.RAPs.Single(p => p.MARAP.Equals(mr));
            // r.MARAP = txtMaRap.Text;
            r.TENRAP = this.txtTenRap.Text;
            r.THONGTINRAP = txtThongTinRap.Text;
            r.SLGHE = Convert.ToInt32(txtSLG.Text);
            ketnoi.connect.SaveChanges();
            ketnoicsdl();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var mr = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            RAP r = ketnoi.connect.RAPs.Single(p => p.MARAP.Equals(mr));
           txtMaRap.Text = r.MARAP.ToString() ;
            txtThongTinRap.Text = r.THONGTINRAP.ToString();
            txtSLG.Text = r.SLGHE.ToString();
            this.txtTenRap.Text = r.TENRAP.ToString();
        }

        private void txtMaRap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
