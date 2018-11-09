namespace RapPhim
{
    partial class fmDoiMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmDoiMK));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.tbNhapLai = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btOk = new DevComponents.DotNetBar.ButtonX();
            this.erMatKhau = new System.Windows.Forms.ErrorProvider(this.components);
            this.erNhaplai = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erMatKhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erNhaplai)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.Transparent;
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // tbNhapLai
            // 
            this.tbNhapLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            // 
            // 
            // 
            this.tbNhapLai.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbNhapLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbNhapLai.ForeColor = System.Drawing.Color.White;
            this.tbNhapLai.Location = new System.Drawing.Point(140, 53);
            this.tbNhapLai.Name = "tbNhapLai";
            this.tbNhapLai.PasswordChar = '*';
            this.tbNhapLai.Size = new System.Drawing.Size(232, 18);
            this.tbNhapLai.TabIndex = 11;
            this.tbNhapLai.WatermarkText = "Nhập lại mật khẩu";
            this.tbNhapLai.TextChanged += new System.EventHandler(this.tbNhapLai_TextChanged);
            this.tbNhapLai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNhapLai_KeyDown);
            this.tbNhapLai.Leave += new System.EventHandler(this.tbNhapLai_TextChanged);
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            // 
            // 
            // 
            this.tbMatKhau.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbMatKhau.ForeColor = System.Drawing.Color.White;
            this.tbMatKhau.Location = new System.Drawing.Point(140, 15);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(232, 18);
            this.tbMatKhau.TabIndex = 0;
            this.tbMatKhau.WatermarkText = "Nhập mật khẩu mới";
            this.tbMatKhau.TextChanged += new System.EventHandler(this.tbMatKhau_TextChanged);
            this.tbMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMatKhau_KeyDown);
            this.tbMatKhau.Leave += new System.EventHandler(this.tbMatKhau_TextChanged);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX5.ForeColor = System.Drawing.Color.White;
            this.labelX5.Location = new System.Drawing.Point(23, 50);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Nhập lại";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX4.ForeColor = System.Drawing.Color.White;
            this.labelX4.Location = new System.Drawing.Point(23, 12);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(111, 23);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "Mật khẩu mới";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.tbMatKhau);
            this.panel1.Controls.Add(this.tbNhapLai);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 131);
            this.panel1.TabIndex = 13;
            // 
            // btOk
            // 
            this.btOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btOk.Location = new System.Drawing.Point(269, 90);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(103, 29);
            this.btOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btOk.TabIndex = 13;
            this.btOk.Text = "Đồng ý";
            this.btOk.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // erMatKhau
            // 
            this.erMatKhau.ContainerControl = this;
            // 
            // erNhaplai
            // 
            this.erNhaplai.ContainerControl = this;
            // 
            // fmDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 131);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmDoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.fmDoiMK_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erMatKhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erNhaplai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbNhapLai;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMatKhau;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btOk;
        private System.Windows.Forms.ErrorProvider erMatKhau;
        private System.Windows.Forms.ErrorProvider erNhaplai;
    }
}