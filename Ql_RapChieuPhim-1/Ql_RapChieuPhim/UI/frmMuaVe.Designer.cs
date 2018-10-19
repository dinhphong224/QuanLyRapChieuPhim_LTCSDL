namespace UI
{
    partial class frmMuaVe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuaVe));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSGT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnIHD = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbPhim = new System.Windows.Forms.ComboBox();
            this.cbbSuat = new System.Windows.Forms.ComboBox();
            this.cbbDD = new System.Windows.Forms.ComboBox();
            this.cbbRap = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDonGIa = new System.Windows.Forms.TextBox();
            this.btnktg = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(62, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phim";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(43, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số lượng";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(118, 131);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(106, 20);
            this.txtSL.TabIndex = 7;
            this.txtSL.TextChanged += new System.EventHandler(this.txtSL_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(361, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Định dạng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(10, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã khách hàng";
            // 
            // txtMKH
            // 
            this.txtMKH.Enabled = false;
            this.txtMKH.Location = new System.Drawing.Point(118, 40);
            this.txtMKH.Name = "txtMKH";
            this.txtMKH.Size = new System.Drawing.Size(106, 20);
            this.txtMKH.TabIndex = 11;
            this.txtMKH.TextChanged += new System.EventHandler(this.txtMKH_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(475, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Số ghế trống";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSGT
            // 
            this.txtSGT.Location = new System.Drawing.Point(461, 72);
            this.txtSGT.Name = "txtSGT";
            this.txtSGT.Size = new System.Drawing.Size(106, 20);
            this.txtSGT.TabIndex = 13;
            this.txtSGT.TextChanged += new System.EventHandler(this.txtSGT_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(375, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rạp";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(56, 206);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(106, 28);
            this.btnLuu.TabIndex = 16;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnIHD
            // 
            this.btnIHD.Location = new System.Drawing.Point(499, 206);
            this.btnIHD.Name = "btnIHD";
            this.btnIHD.Size = new System.Drawing.Size(106, 28);
            this.btnIHD.TabIndex = 17;
            this.btnIHD.Text = "In hóa đơn";
            this.btnIHD.UseVisualStyleBackColor = true;
            this.btnIHD.Click += new System.EventHandler(this.btnIHD_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(256, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Thành tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(320, 206);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(106, 20);
            this.txtThanhTien.TabIndex = 19;
            this.txtThanhTien.TextChanged += new System.EventHandler(this.txtThanhTien_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(62, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Suất";
            // 
            // cbbPhim
            // 
            this.cbbPhim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbbPhim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbPhim.FormattingEnabled = true;
            this.cbbPhim.Location = new System.Drawing.Point(118, 74);
            this.cbbPhim.Name = "cbbPhim";
            this.cbbPhim.Size = new System.Drawing.Size(153, 21);
            this.cbbPhim.TabIndex = 22;
            this.cbbPhim.SelectedIndexChanged += new System.EventHandler(this.cbbPhim_SelectedIndexChanged);
            this.cbbPhim.DisplayMemberChanged += new System.EventHandler(this.cbbPhim_DisplayMemberChanged);
            // 
            // cbbSuat
            // 
            this.cbbSuat.FormattingEnabled = true;
            this.cbbSuat.Location = new System.Drawing.Point(118, 101);
            this.cbbSuat.Name = "cbbSuat";
            this.cbbSuat.Size = new System.Drawing.Size(106, 21);
            this.cbbSuat.TabIndex = 23;
            this.cbbSuat.SelectedIndexChanged += new System.EventHandler(this.cbbSuat_SelectedIndexChanged);
            // 
            // cbbDD
            // 
            this.cbbDD.FormattingEnabled = true;
            this.cbbDD.Items.AddRange(new object[] {
            "2D",
            "3D"});
            this.cbbDD.Location = new System.Drawing.Point(336, 112);
            this.cbbDD.Name = "cbbDD";
            this.cbbDD.Size = new System.Drawing.Size(106, 21);
            this.cbbDD.TabIndex = 24;
            this.cbbDD.SelectedIndexChanged += new System.EventHandler(this.cmbMGG_SelectedIndexChanged);
            this.cbbDD.DisplayMemberChanged += new System.EventHandler(this.cbbDD_DisplayMemberChanged);
            // 
            // cbbRap
            // 
            this.cbbRap.FormattingEnabled = true;
            this.cbbRap.Location = new System.Drawing.Point(336, 72);
            this.cbbRap.Name = "cbbRap";
            this.cbbRap.Size = new System.Drawing.Size(106, 21);
            this.cbbRap.TabIndex = 25;
            this.cbbRap.SelectedIndexChanged += new System.EventHandler(this.cbbRap_SelectedIndexChanged);
            this.cbbRap.TextUpdate += new System.EventHandler(this.cbbRap_TextUpdate);
            this.cbbRap.DisplayMemberChanged += new System.EventHandler(this.cbbRap_DisplayMemberChanged);
            this.cbbRap.SelectedValueChanged += new System.EventHandler(this.cbbRap_SelectedValueChanged);
            this.cbbRap.TextChanged += new System.EventHandler(this.cbbRap_TextChanged);
            this.cbbRap.Click += new System.EventHandler(this.cbbRap_Click);
            this.cbbRap.MouseCaptureChanged += new System.EventHandler(this.cbbRap_MouseCaptureChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(43, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Đơn giá";
            // 
            // txtDonGIa
            // 
            this.txtDonGIa.Location = new System.Drawing.Point(118, 157);
            this.txtDonGIa.Name = "txtDonGIa";
            this.txtDonGIa.Size = new System.Drawing.Size(106, 20);
            this.txtDonGIa.TabIndex = 27;
            this.txtDonGIa.TextChanged += new System.EventHandler(this.txtDonGIa_TextChanged);
            // 
            // btnktg
            // 
            this.btnktg.Location = new System.Drawing.Point(573, 67);
            this.btnktg.Name = "btnktg";
            this.btnktg.Size = new System.Drawing.Size(82, 28);
            this.btnktg.TabIndex = 28;
            this.btnktg.Text = "Kiểm tra ghế";
            this.btnktg.UseVisualStyleBackColor = true;
            this.btnktg.Click += new System.EventHandler(this.btnktg_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(659, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmMuaVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 261);
            this.Controls.Add(this.btnktg);
            this.Controls.Add(this.txtDonGIa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbbRap);
            this.Controls.Add(this.cbbDD);
            this.Controls.Add(this.cbbSuat);
            this.Controls.Add(this.cbbPhim);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnIHD);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSGT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmMuaVe";
            this.Text = "frmMuaVe";
            this.Load += new System.EventHandler(this.frmMuaVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSGT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnIHD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbPhim;
        private System.Windows.Forms.ComboBox cbbSuat;
        private System.Windows.Forms.ComboBox cbbDD;
        private System.Windows.Forms.ComboBox cbbRap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDonGIa;
        private System.Windows.Forms.Button btnktg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}