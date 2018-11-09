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
    public partial class fmDoiMK : DevComponents.DotNetBar.Metro.MetroForm
    {
        public String matKhau = "";
        public fmDoiMK()
        {
            InitializeComponent();
        }

        private void tbMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                tbNhapLai.Focus();
            if (e.KeyCode == Keys.Up)
                btOk.Focus();
        }

        private void tbNhapLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                btOk.Focus();
            if (e.KeyCode == Keys.Up)
                tbMatKhau.Focus();
        }

        private void tbMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (tbMatKhau.Text.Trim() == "")
            {
                erMatKhau.Icon = Properties.Resources.x;
                erMatKhau.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erMatKhau.SetError(tbMatKhau, "Mật khẩu không được để trống!");
            }
            else
            {
                erMatKhau.Icon = Properties.Resources.v;
                erMatKhau.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erMatKhau.SetError(tbMatKhau, "ok");
            }
        }

        private void tbNhapLai_TextChanged(object sender, EventArgs e)
        {
            if (tbNhapLai.Text.Trim() == "")
            {
                erNhaplai.Icon = Properties.Resources.x;
                erNhaplai.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erNhaplai.SetError(tbNhapLai, "Không được để trống!");
            }
            else
            {
                erNhaplai.Icon = Properties.Resources.v;
                erNhaplai.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                erNhaplai.SetError(tbNhapLai, "ok");
            }

            if (tbMatKhau.Text != tbNhapLai.Text)
            {
                erNhaplai.Icon = Properties.Resources.x;
                erNhaplai.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                erNhaplai.SetError(tbNhapLai, "Mật khẩu nhập không trùng nhau!");
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if(tbMatKhau.Text == tbNhapLai.Text)
            {
                matKhau = tbMatKhau.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu chưa chính xác!");
                tbMatKhau.Focus();
            }
        }

        private void fmDoiMK_Load(object sender, EventArgs e)
        {
            tbMatKhau.Focus();
        }
    }
}
