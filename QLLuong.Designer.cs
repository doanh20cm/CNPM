namespace Quan_li_nhan_su
{
    partial class QLLuong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label14 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numTruoc = new System.Windows.Forms.NumericUpDown();
            this.numSau = new System.Windows.Forms.NumericUpDown();
            this.chkTimSau = new System.Windows.Forms.CheckBox();
            this.chkTimTruoc = new System.Windows.Forms.CheckBox();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.chkTimTen = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtGhiChu = new System.Windows.Forms.RichTextBox();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numSoGioLamThem = new System.Windows.Forms.NumericUpDown();
            this.numSoNgayCong = new System.Windows.Forms.NumericUpDown();
            this.txtPhat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtThuong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhuCap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLuongCoSo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTenNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnExportWord = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTruoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSau)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoGioLamThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgayCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(470, 315);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 21);
            this.label14.TabIndex = 24;
            this.label14.Text = "Vui lòng chờ...";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(424, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 50);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Visible = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(951, 236);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 22;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(549, 236);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 21;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(395, 236);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 20;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(237, 236);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 19;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(84, 236);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.numTruoc);
            this.groupBox2.Controls.Add(this.numSau);
            this.groupBox2.Controls.Add(this.chkTimSau);
            this.groupBox2.Controls.Add(this.chkTimTruoc);
            this.groupBox2.Controls.Add(this.txtTimTen);
            this.groupBox2.Controls.Add(this.chkTimTen);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(712, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 187);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(236, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "triệu đồng";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(236, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "triệu đồng";
            // 
            // numTruoc
            // 
            this.numTruoc.Location = new System.Drawing.Point(161, 130);
            this.numTruoc.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numTruoc.Name = "numTruoc";
            this.numTruoc.Size = new System.Drawing.Size(66, 20);
            this.numTruoc.TabIndex = 12;
            // 
            // numSau
            // 
            this.numSau.Location = new System.Drawing.Point(161, 80);
            this.numSau.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numSau.Name = "numSau";
            this.numSau.Size = new System.Drawing.Size(66, 20);
            this.numSau.TabIndex = 11;
            // 
            // chkTimSau
            // 
            this.chkTimSau.AutoSize = true;
            this.chkTimSau.Location = new System.Drawing.Point(26, 83);
            this.chkTimSau.Name = "chkTimSau";
            this.chkTimSau.Size = new System.Drawing.Size(106, 17);
            this.chkTimSau.TabIndex = 10;
            this.chkTimSau.Text = "Có lương TK trên";
            this.chkTimSau.UseVisualStyleBackColor = true;
            // 
            // chkTimTruoc
            // 
            this.chkTimTruoc.AutoSize = true;
            this.chkTimTruoc.Location = new System.Drawing.Point(26, 133);
            this.chkTimTruoc.Name = "chkTimTruoc";
            this.chkTimTruoc.Size = new System.Drawing.Size(108, 17);
            this.chkTimTruoc.TabIndex = 9;
            this.chkTimTruoc.Text = "Có lương TK dưới";
            this.chkTimTruoc.UseVisualStyleBackColor = true;
            // 
            // txtTimTen
            // 
            this.txtTimTen.Location = new System.Drawing.Point(161, 32);
            this.txtTimTen.MaxLength = 50;
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(125, 20);
            this.txtTimTen.TabIndex = 8;
            // 
            // chkTimTen
            // 
            this.chkTimTen.AutoSize = true;
            this.chkTimTen.Location = new System.Drawing.Point(26, 34);
            this.chkTimTen.Name = "chkTimTen";
            this.chkTimTen.Size = new System.Drawing.Size(113, 17);
            this.chkTimTen.TabIndex = 7;
            this.chkTimTen.Text = "Của nhân viên tên";
            this.chkTimTen.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm kiếm lương";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thông tin lương";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtGhiChu);
            this.groupBox1.Controls.Add(this.txtHeSoLuong);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numNam);
            this.groupBox1.Controls.Add(this.numThang);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numSoGioLamThem);
            this.groupBox1.Controls.Add(this.numSoNgayCong);
            this.groupBox1.Controls.Add(this.txtPhat);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtThuong);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPhuCap);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLuongCoSo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbTenNV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(28, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 187);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // rtGhiChu
            // 
            this.rtGhiChu.Location = new System.Drawing.Point(521, 130);
            this.rtGhiChu.Name = "rtGhiChu";
            this.rtGhiChu.Size = new System.Drawing.Size(98, 40);
            this.rtGhiChu.TabIndex = 33;
            this.rtGhiChu.Text = "";
            // 
            // txtHeSoLuong
            // 
            this.txtHeSoLuong.Location = new System.Drawing.Point(121, 108);
            this.txtHeSoLuong.Name = "txtHeSoLuong";
            this.txtHeSoLuong.Size = new System.Drawing.Size(120, 20);
            this.txtHeSoLuong.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Hệ số lương";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(571, 71);
            this.numNam.Maximum = new decimal(new int[] {
            9998,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(48, 20);
            this.numNam.TabIndex = 32;
            this.numNam.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(578, 31);
            this.numThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(41, 20);
            this.numThang.TabIndex = 31;
            this.numThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(518, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Ghi chú";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(518, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Năm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(518, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Tháng";
            // 
            // numSoGioLamThem
            // 
            this.numSoGioLamThem.Location = new System.Drawing.Point(367, 31);
            this.numSoGioLamThem.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSoGioLamThem.Name = "numSoGioLamThem";
            this.numSoGioLamThem.Size = new System.Drawing.Size(120, 20);
            this.numSoGioLamThem.TabIndex = 25;
            // 
            // numSoNgayCong
            // 
            this.numSoNgayCong.Location = new System.Drawing.Point(121, 143);
            this.numSoNgayCong.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numSoNgayCong.Name = "numSoNgayCong";
            this.numSoNgayCong.Size = new System.Drawing.Size(120, 20);
            this.numSoNgayCong.TabIndex = 24;
            // 
            // txtPhat
            // 
            this.txtPhat.Location = new System.Drawing.Point(367, 143);
            this.txtPhat.Name = "txtPhat";
            this.txtPhat.Size = new System.Drawing.Size(120, 20);
            this.txtPhat.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Phạt (đ)";
            // 
            // txtThuong
            // 
            this.txtThuong.Location = new System.Drawing.Point(367, 107);
            this.txtThuong.Name = "txtThuong";
            this.txtThuong.Size = new System.Drawing.Size(120, 20);
            this.txtThuong.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Thưởng (đ)";
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Location = new System.Drawing.Point(367, 70);
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Size = new System.Drawing.Size(120, 20);
            this.txtPhuCap.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Phụ cấp (đ)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Số giờ làm thêm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số ngày công";
            // 
            // txtLuongCoSo
            // 
            this.txtLuongCoSo.Location = new System.Drawing.Point(121, 70);
            this.txtLuongCoSo.Name = "txtLuongCoSo";
            this.txtLuongCoSo.Size = new System.Drawing.Size(120, 20);
            this.txtLuongCoSo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Lương cơ sở (đ)";
            // 
            // cbTenNV
            // 
            this.cbTenNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTenNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTenNV.FormattingEnabled = true;
            this.cbTenNV.Location = new System.Drawing.Point(121, 30);
            this.cbTenNV.MaxLength = 50;
            this.cbTenNV.Name = "cbTenNV";
            this.cbTenNV.Size = new System.Drawing.Size(120, 21);
            this.cbTenNV.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nhân viên";
            // 
            // dgvLuong
            // 
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.AllowUserToResizeColumns = false;
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLuong.ColumnHeadersHeight = 36;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLuong.Location = new System.Drawing.Point(28, 285);
            this.dgvLuong.MultiSelect = false;
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuong.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLuong.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvLuong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.Size = new System.Drawing.Size(998, 341);
            this.dgvLuong.TabIndex = 15;
            this.dgvLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellClick);
            this.dgvLuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellContentClick);
            this.dgvLuong.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvLuong_DataBindingComplete);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(701, 236);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 25;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnExportWord
            // 
            this.btnExportWord.Location = new System.Drawing.Point(822, 236);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(75, 23);
            this.btnExportWord.TabIndex = 26;
            this.btnExportWord.Text = "Xuất Word";
            this.btnExportWord.UseVisualStyleBackColor = true;
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // QLLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quan_li_nhan_su.Properties.Resources.space_blue_sky_pastel_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1074, 687);
            this.ControlBox = false;
            this.Controls.Add(this.btnExportWord);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvLuong);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QLLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý lương";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.QLLuong_Activated);
            this.Load += new System.EventHandler(this.QLLuong_Load);
            this.Shown += new System.EventHandler(this.QLLuong_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTruoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSau)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoGioLamThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgayCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.ComboBox cbTenNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHeSoLuong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numSoGioLamThem;
        private System.Windows.Forms.NumericUpDown numSoNgayCong;
        private System.Windows.Forms.TextBox txtPhat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtThuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhuCap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLuongCoSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.RichTextBox rtGhiChu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numTruoc;
        private System.Windows.Forms.NumericUpDown numSau;
        private System.Windows.Forms.CheckBox chkTimSau;
        private System.Windows.Forms.CheckBox chkTimTruoc;
        private System.Windows.Forms.TextBox txtTimTen;
        private System.Windows.Forms.CheckBox chkTimTen;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnExportWord;
    }
}