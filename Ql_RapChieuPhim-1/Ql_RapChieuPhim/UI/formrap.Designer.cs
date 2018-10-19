namespace UI
{
    partial class formrap
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
            this.l = new System.Windows.Forms.Label();
            this.txtMaRap = new System.Windows.Forms.TextBox();
            this.txtTenRap = new System.Windows.Forms.TextBox();
            this.e = new System.Windows.Forms.Label();
            this.txtThongTinRap = new System.Windows.Forms.TextBox();
            this.a = new System.Windows.Forms.Label();
            this.txtSLG = new System.Windows.Forms.TextBox();
            this.v = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(36, 30);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(45, 13);
            this.l.TabIndex = 0;
            this.l.Text = "Mã Rạp";
            // 
            // txtMaRap
            // 
            this.txtMaRap.Location = new System.Drawing.Point(112, 27);
            this.txtMaRap.Name = "txtMaRap";
            this.txtMaRap.Size = new System.Drawing.Size(103, 20);
            this.txtMaRap.TabIndex = 1;
            this.txtMaRap.TextChanged += new System.EventHandler(this.txtMaRap_TextChanged);
            // 
            // txtTenRap
            // 
            this.txtTenRap.Location = new System.Drawing.Point(112, 72);
            this.txtTenRap.Name = "txtTenRap";
            this.txtTenRap.Size = new System.Drawing.Size(103, 20);
            this.txtTenRap.TabIndex = 3;
            // 
            // e
            // 
            this.e.AutoSize = true;
            this.e.Location = new System.Drawing.Point(36, 72);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(49, 13);
            this.e.TabIndex = 2;
            this.e.Text = "Tên Rạp";
            // 
            // txtThongTinRap
            // 
            this.txtThongTinRap.Location = new System.Drawing.Point(112, 115);
            this.txtThongTinRap.Name = "txtThongTinRap";
            this.txtThongTinRap.Size = new System.Drawing.Size(103, 20);
            this.txtThongTinRap.TabIndex = 5;
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Location = new System.Drawing.Point(36, 122);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(70, 13);
            this.a.TabIndex = 4;
            this.a.Text = "Thông tin rạp";
            // 
            // txtSLG
            // 
            this.txtSLG.Location = new System.Drawing.Point(112, 164);
            this.txtSLG.Name = "txtSLG";
            this.txtSLG.Size = new System.Drawing.Size(103, 20);
            this.txtSLG.TabIndex = 7;
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.Location = new System.Drawing.Point(36, 164);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(70, 13);
            this.v.TabIndex = 6;
            this.v.Text = "Số lượng ghế";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(277, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(405, 283);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(27, 205);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(65, 27);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(112, 205);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(65, 27);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(206, 205);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(65, 27);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // formrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 302);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSLG);
            this.Controls.Add(this.v);
            this.Controls.Add(this.txtThongTinRap);
            this.Controls.Add(this.a);
            this.Controls.Add(this.txtTenRap);
            this.Controls.Add(this.e);
            this.Controls.Add(this.txtMaRap);
            this.Controls.Add(this.l);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formrap";
            this.Text = "formrap";
            this.Load += new System.EventHandler(this.formrap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l;
        private System.Windows.Forms.TextBox txtMaRap;
        private System.Windows.Forms.TextBox txtTenRap;
        private System.Windows.Forms.Label e;
        private System.Windows.Forms.TextBox txtThongTinRap;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.TextBox txtSLG;
        private System.Windows.Forms.Label v;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
    }
}