using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Connector;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UI
{
    public partial class formHoaDon : Form
    {
        public formHoaDon()
        {
            InitializeComponent();
        }
        congketnoi ketnoi =new congketnoi();
        private void formHoaDon_Load(object sender, EventArgs e)
        {

        }
        private void ketnoicsdl()
        {
            ketnoi.cnn.Close();
            dataGridView1.DataSource = ketnoi.laydulieu("HOADON");
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
    }
}
