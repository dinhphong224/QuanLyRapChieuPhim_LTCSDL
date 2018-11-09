namespace RapPhim
{
    partial class fmThongTinPhim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmThongTinPhim));
            this.pnForm = new System.Windows.Forms.Panel();
            this.btClose = new DevComponents.DotNetBar.ButtonX();
            this.btSize = new DevComponents.DotNetBar.ButtonX();
            this.btTrailer = new DevComponents.DotNetBar.ButtonX();
            this.sfTrailer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbNoiDung = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDienVien = new System.Windows.Forms.Label();
            this.lbQuocGia = new System.Windows.Forms.Label();
            this.lbNamSX = new System.Windows.Forms.Label();
            this.lbThoiLuong = new System.Windows.Forms.Label();
            this.lbTheLoai = new System.Windows.Forms.Label();
            this.lbDaoDien = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.pbHinh = new System.Windows.Forms.PictureBox();
            this.btXemLC = new DevComponents.DotNetBar.ButtonX();
            this.ilSize = new System.Windows.Forms.ImageList(this.components);
            this.pnForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfTrailer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnForm
            // 
            this.pnForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnForm.BackColor = System.Drawing.Color.Transparent;
            this.pnForm.Controls.Add(this.btClose);
            this.pnForm.Controls.Add(this.btSize);
            this.pnForm.Controls.Add(this.btTrailer);
            this.pnForm.Controls.Add(this.sfTrailer);
            this.pnForm.Controls.Add(this.panel1);
            this.pnForm.Controls.Add(this.lbDienVien);
            this.pnForm.Controls.Add(this.lbQuocGia);
            this.pnForm.Controls.Add(this.lbNamSX);
            this.pnForm.Controls.Add(this.lbThoiLuong);
            this.pnForm.Controls.Add(this.lbTheLoai);
            this.pnForm.Controls.Add(this.lbDaoDien);
            this.pnForm.Controls.Add(this.lbTen);
            this.pnForm.Controls.Add(this.pbHinh);
            this.pnForm.Controls.Add(this.btXemLC);
            this.pnForm.ForeColor = System.Drawing.Color.White;
            this.pnForm.Location = new System.Drawing.Point(0, 0);
            this.pnForm.Name = "pnForm";
            this.pnForm.Size = new System.Drawing.Size(712, 361);
            this.pnForm.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackColor = System.Drawing.Color.Red;
            this.btClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.Location = new System.Drawing.Point(667, 334);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(45, 27);
            this.btClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btClose.TabIndex = 19;
            this.btClose.Tooltip = "Tắt trailer";
            this.btClose.Visible = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSize
            // 
            this.btSize.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btSize.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btSize.Image = ((System.Drawing.Image)(resources.GetObject("btSize.Image")));
            this.btSize.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btSize.Location = new System.Drawing.Point(629, 334);
            this.btSize.Name = "btSize";
            this.btSize.Size = new System.Drawing.Size(38, 27);
            this.btSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btSize.TabIndex = 4;
            this.btSize.Tooltip = "Phóng to";
            this.btSize.Visible = false;
            this.btSize.Click += new System.EventHandler(this.btSize_Click);
            // 
            // btTrailer
            // 
            this.btTrailer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btTrailer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btTrailer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btTrailer.Location = new System.Drawing.Point(118, 204);
            this.btTrailer.Name = "btTrailer";
            this.btTrailer.Size = new System.Drawing.Size(107, 29);
            this.btTrailer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btTrailer.TabIndex = 18;
            this.btTrailer.Text = "Xem Trailer";
            this.btTrailer.TextColor = System.Drawing.Color.Red;
            this.btTrailer.Click += new System.EventHandler(this.btTrailer_Click);
            // 
            // sfTrailer
            // 
            this.sfTrailer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfTrailer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.sfTrailer.Enabled = true;
            this.sfTrailer.ForeColor = System.Drawing.Color.White;
            this.sfTrailer.Location = new System.Drawing.Point(0, 0);
            this.sfTrailer.Name = "sfTrailer";
            this.sfTrailer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sfTrailer.OcxState")));
            this.sfTrailer.Size = new System.Drawing.Size(712, 361);
            this.sfTrailer.TabIndex = 17;
            this.sfTrailer.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.rbNoiDung);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 125);
            this.panel1.TabIndex = 15;
            // 
            // rbNoiDung
            // 
            this.rbNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.rbNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbNoiDung.ForeColor = System.Drawing.Color.White;
            this.rbNoiDung.Location = new System.Drawing.Point(91, 6);
            this.rbNoiDung.Name = "rbNoiDung";
            this.rbNoiDung.ReadOnly = true;
            this.rbNoiDung.Size = new System.Drawing.Size(615, 113);
            this.rbNoiDung.TabIndex = 3;
            this.rbNoiDung.Text = "Nội dung phim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nội Dung : ";
            // 
            // lbDienVien
            // 
            this.lbDienVien.AutoSize = true;
            this.lbDienVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDienVien.ForeColor = System.Drawing.Color.White;
            this.lbDienVien.Location = new System.Drawing.Point(330, 75);
            this.lbDienVien.Name = "lbDienVien";
            this.lbDienVien.Size = new System.Drawing.Size(82, 18);
            this.lbDienVien.TabIndex = 7;
            this.lbDienVien.Text = "Diễn Viên : ";
            // 
            // lbQuocGia
            // 
            this.lbQuocGia.AutoSize = true;
            this.lbQuocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbQuocGia.ForeColor = System.Drawing.Color.White;
            this.lbQuocGia.Location = new System.Drawing.Point(330, 180);
            this.lbQuocGia.Name = "lbQuocGia";
            this.lbQuocGia.Size = new System.Drawing.Size(84, 18);
            this.lbQuocGia.TabIndex = 8;
            this.lbQuocGia.Text = "Quốc Gia : ";
            // 
            // lbNamSX
            // 
            this.lbNamSX.AutoSize = true;
            this.lbNamSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNamSX.ForeColor = System.Drawing.Color.White;
            this.lbNamSX.Location = new System.Drawing.Point(330, 215);
            this.lbNamSX.Name = "lbNamSX";
            this.lbNamSX.Size = new System.Drawing.Size(80, 18);
            this.lbNamSX.TabIndex = 10;
            this.lbNamSX.Text = "Năm SX  : ";
            // 
            // lbThoiLuong
            // 
            this.lbThoiLuong.AutoSize = true;
            this.lbThoiLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbThoiLuong.ForeColor = System.Drawing.Color.White;
            this.lbThoiLuong.Location = new System.Drawing.Point(330, 145);
            this.lbThoiLuong.Name = "lbThoiLuong";
            this.lbThoiLuong.Size = new System.Drawing.Size(94, 18);
            this.lbThoiLuong.TabIndex = 11;
            this.lbThoiLuong.Text = "Thời Lượng : ";
            // 
            // lbTheLoai
            // 
            this.lbTheLoai.AutoSize = true;
            this.lbTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTheLoai.ForeColor = System.Drawing.Color.White;
            this.lbTheLoai.Location = new System.Drawing.Point(330, 110);
            this.lbTheLoai.Name = "lbTheLoai";
            this.lbTheLoai.Size = new System.Drawing.Size(81, 18);
            this.lbTheLoai.TabIndex = 12;
            this.lbTheLoai.Text = "Thể Loại  : ";
            // 
            // lbDaoDien
            // 
            this.lbDaoDien.AutoSize = true;
            this.lbDaoDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDaoDien.ForeColor = System.Drawing.Color.White;
            this.lbDaoDien.Location = new System.Drawing.Point(330, 40);
            this.lbDaoDien.Name = "lbDaoDien";
            this.lbDaoDien.Size = new System.Drawing.Size(82, 18);
            this.lbDaoDien.TabIndex = 13;
            this.lbDaoDien.Text = "Đạo Diễn : ";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTen.ForeColor = System.Drawing.Color.White;
            this.lbTen.Location = new System.Drawing.Point(330, 5);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(124, 24);
            this.lbTen.TabIndex = 6;
            this.lbTen.Text = "Tên Phim :  ";
            // 
            // pbHinh
            // 
            this.pbHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pbHinh.ForeColor = System.Drawing.Color.White;
            this.pbHinh.Location = new System.Drawing.Point(0, 0);
            this.pbHinh.Name = "pbHinh";
            this.pbHinh.Size = new System.Drawing.Size(322, 200);
            this.pbHinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHinh.TabIndex = 5;
            this.pbHinh.TabStop = false;
            // 
            // btXemLC
            // 
            this.btXemLC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btXemLC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btXemLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btXemLC.Location = new System.Drawing.Point(5, 204);
            this.btXemLC.Name = "btXemLC";
            this.btXemLC.Size = new System.Drawing.Size(107, 29);
            this.btXemLC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btXemLC.TabIndex = 16;
            this.btXemLC.Text = "Xem lịch chiếu";
            this.btXemLC.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            // 
            // ilSize
            // 
            this.ilSize.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSize.ImageStream")));
            this.ilSize.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSize.Images.SetKeyName(0, "MaxSize.png");
            this.ilSize.Images.SetKeyName(1, "MinSize.png");
            // 
            // fmThongTinPhim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 361);
            this.Controls.Add(this.pnForm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmThongTinPhim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin phim";
            this.Load += new System.EventHandler(this.fmThongTinPhim_Load);
            this.pnForm.ResumeLayout(false);
            this.pnForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfTrailer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rbNoiDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDienVien;
        private System.Windows.Forms.Label lbQuocGia;
        private System.Windows.Forms.Label lbNamSX;
        private System.Windows.Forms.Label lbThoiLuong;
        private System.Windows.Forms.Label lbTheLoai;
        private System.Windows.Forms.Label lbDaoDien;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.PictureBox pbHinh;
        private DevComponents.DotNetBar.ButtonX btXemLC;
        private AxShockwaveFlashObjects.AxShockwaveFlash sfTrailer;
        private DevComponents.DotNetBar.ButtonX btSize;
        private DevComponents.DotNetBar.ButtonX btTrailer;
        private DevComponents.DotNetBar.ButtonX btClose;
        private System.Windows.Forms.ImageList ilSize;
    }
}