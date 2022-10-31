namespace Quan_li_nhan_su
{
    partial class QLNhanVienPhongBan
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
            this.dgvNhanVienPhongBan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtGhiChu = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtThoiGian = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKy = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoaiHopDong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTenPhongBan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHoTenNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienPhongBan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNhanVienPhongBan
            // 
            this.dgvNhanVienPhongBan.AllowUserToAddRows = false;
            this.dgvNhanVienPhongBan.AllowUserToDeleteRows = false;
            this.dgvNhanVienPhongBan.AllowUserToResizeColumns = false;
            this.dgvNhanVienPhongBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVienPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVienPhongBan.Location = new System.Drawing.Point(32, 285);
            this.dgvNhanVienPhongBan.MultiSelect = false;
            this.dgvNhanVienPhongBan.Name = "dgvNhanVienPhongBan";
            this.dgvNhanVienPhongBan.ReadOnly = true;
            this.dgvNhanVienPhongBan.RowHeadersVisible = false;
            this.dgvNhanVienPhongBan.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanVienPhongBan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvNhanVienPhongBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVienPhongBan.Size = new System.Drawing.Size(998, 341);
            this.dgvNhanVienPhongBan.TabIndex = 0;
            this.dgvNhanVienPhongBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVienPhongBan_CellClick);
            this.dgvNhanVienPhongBan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvNhanVienPhongBan_DataBindingComplete);
            this.dgvNhanVienPhongBan.SelectionChanged += new System.EventHandler(this.dgvNhanVienPhongBan_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtGhiChu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtThoiGian);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpNgayHetHan);
            this.groupBox1.Controls.Add(this.dtpNgayKy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLoaiHopDong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTenPhongBan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbHoTenNV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên phòng ban";
            // 
            // rtGhiChu
            // 
            this.rtGhiChu.Location = new System.Drawing.Point(620, 75);
            this.rtGhiChu.Name = "rtGhiChu";
            this.rtGhiChu.Size = new System.Drawing.Size(82, 87);
            this.rtGhiChu.TabIndex = 13;
            this.rtGhiChu.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(636, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ghi chú";
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.Location = new System.Drawing.Point(443, 142);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Size = new System.Drawing.Size(149, 20);
            this.txtThoiGian.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Thời gian";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ngày hết hạn";
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(443, 89);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(149, 20);
            this.dtpNgayHetHan.TabIndex = 8;
            // 
            // dtpNgayKy
            // 
            this.dtpNgayKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKy.Location = new System.Drawing.Point(443, 45);
            this.dtpNgayKy.Name = "dtpNgayKy";
            this.dtpNgayKy.Size = new System.Drawing.Size(149, 20);
            this.dtpNgayKy.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày ký";
            // 
            // txtLoaiHopDong
            // 
            this.txtLoaiHopDong.Location = new System.Drawing.Point(140, 142);
            this.txtLoaiHopDong.Name = "txtLoaiHopDong";
            this.txtLoaiHopDong.Size = new System.Drawing.Size(161, 20);
            this.txtLoaiHopDong.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại hợp đồng";
            // 
            // cbTenPhongBan
            // 
            this.cbTenPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenPhongBan.FormattingEnabled = true;
            this.cbTenPhongBan.Location = new System.Drawing.Point(140, 92);
            this.cbTenPhongBan.Name = "cbTenPhongBan";
            this.cbTenPhongBan.Size = new System.Drawing.Size(161, 21);
            this.cbTenPhongBan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên phòng ban";
            // 
            // cbHoTenNV
            // 
            this.cbHoTenNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoTenNV.FormattingEnabled = true;
            this.cbHoTenNV.Location = new System.Drawing.Point(140, 45);
            this.cbHoTenNV.Name = "cbHoTenNV";
            this.cbHoTenNV.Size = new System.Drawing.Size(161, 21);
            this.cbHoTenNV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên nhân viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(783, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 187);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm nhân viên phòng ban";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(288, 237);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(490, 237);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(681, 237);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(887, 237);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // QLNhanVienPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quan_li_nhan_su.Properties.Resources.space_blue_sky_pastel_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1074, 691);
            this.ControlBox = false;
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvNhanVienPhongBan);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "QLNhanVienPhongBan";
            this.Text = "Quản lý nhân viên phòng ban";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QLNhanVienPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVienPhongBan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhanVienPhongBan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RichTextBox rtGhiChu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtThoiGian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.DateTimePicker dtpNgayKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoaiHopDong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTenPhongBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHoTenNV;
        private System.Windows.Forms.Label label1;
    }
}