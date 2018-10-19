namespace UI
{
    partial class frmlichchieu
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
            this.txtLoaiChieu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgayChieu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGioChieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThoiLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaPhim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaLC = new System.Windows.Forms.TextBox();
            this.lbmaphim = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoaiChieu
            // 
            this.txtLoaiChieu.Location = new System.Drawing.Point(101, 214);
            this.txtLoaiChieu.Name = "txtLoaiChieu";
            this.txtLoaiChieu.Size = new System.Drawing.Size(81, 20);
            this.txtLoaiChieu.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Loại chiếu";
            // 
            // txtNgayChieu
            // 
            this.txtNgayChieu.Location = new System.Drawing.Point(101, 176);
            this.txtNgayChieu.Name = "txtNgayChieu";
            this.txtNgayChieu.Size = new System.Drawing.Size(81, 20);
            this.txtNgayChieu.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ngày chiếu";
            // 
            // txtGioChieu
            // 
            this.txtGioChieu.Location = new System.Drawing.Point(101, 143);
            this.txtGioChieu.Name = "txtGioChieu";
            this.txtGioChieu.Size = new System.Drawing.Size(81, 20);
            this.txtGioChieu.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Giờ chiếu";
            // 
            // txtThoiLuong
            // 
            this.txtThoiLuong.Location = new System.Drawing.Point(101, 106);
            this.txtThoiLuong.Name = "txtThoiLuong";
            this.txtThoiLuong.Size = new System.Drawing.Size(81, 20);
            this.txtThoiLuong.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Thời lượng";
            // 
            // txtMaPhim
            // 
            this.txtMaPhim.Location = new System.Drawing.Point(101, 71);
            this.txtMaPhim.Name = "txtMaPhim";
            this.txtMaPhim.Size = new System.Drawing.Size(81, 20);
            this.txtMaPhim.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã phim";
            // 
            // txtMaLC
            // 
            this.txtMaLC.Location = new System.Drawing.Point(101, 34);
            this.txtMaLC.Name = "txtMaLC";
            this.txtMaLC.Size = new System.Drawing.Size(81, 20);
            this.txtMaLC.TabIndex = 14;
            // 
            // lbmaphim
            // 
            this.lbmaphim.AutoSize = true;
            this.lbmaphim.Location = new System.Drawing.Point(11, 34);
            this.lbmaphim.Name = "lbmaphim";
            this.lbmaphim.Size = new System.Drawing.Size(70, 13);
            this.lbmaphim.TabIndex = 13;
            this.lbmaphim.Text = "Mã lịch chiếu";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(529, 245);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 25);
            this.btnXoa.TabIndex = 28;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(404, 246);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 25);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(278, 246);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 25);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(214, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(704, 200);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(101, 246);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(81, 20);
            this.txtGia.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Giá";
            // 
            // frmlichchieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 287);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtLoaiChieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNgayChieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGioChieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtThoiLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaPhim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaLC);
            this.Controls.Add(this.lbmaphim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmlichchieu";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmlichchieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoaiChieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNgayChieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGioChieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThoiLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaPhim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaLC;
        private System.Windows.Forms.Label lbmaphim;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label6;
    }
}