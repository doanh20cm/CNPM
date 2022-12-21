namespace Quan_li_nhan_su
{
    partial class ThongKeLuong
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLuuWord = new System.Windows.Forms.Button();
            this.btnLuuAnh = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbNhanVien = new System.Windows.Forms.ComboBox();
            this.lbNhanVien = new System.Windows.Forms.Label();
            this.cbPhongBan = new System.Windows.Forms.ComboBox();
            this.lbPhongBan = new System.Windows.Forms.Label();
            this.cbBoPhan = new System.Windows.Forms.ComboBox();
            this.lbBoPhan = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lbThang = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lbNam = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rb1Thang = new System.Windows.Forms.RadioButton();
            this.rb1Nam = new System.Windows.Forms.RadioButton();
            this.rbAllNam = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbCongTy = new System.Windows.Forms.RadioButton();
            this.rbBoPhan = new System.Windows.Forms.RadioButton();
            this.rbPhongBan = new System.Windows.Forms.RadioButton();
            this.rbNhanVien = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnLuuExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartThongKe
            // 
            chartArea1.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Location = new System.Drawing.Point(43, 277);
            this.chartThongKe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartThongKe.Name = "chartThongKe";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartThongKe.Series.Add(series1);
            this.chartThongKe.Size = new System.Drawing.Size(1331, 494);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "chart1";
            this.chartThongKe.Visible = false;
            this.chartThongKe.Click += new System.EventHandler(this.chart1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLuuExcel);
            this.groupBox1.Controls.Add(this.btnLuuWord);
            this.groupBox1.Controls.Add(this.btnLuuAnh);
            this.groupBox1.Controls.Add(this.btnBaoCao);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(43, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1331, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnLuuWord
            // 
            this.btnLuuWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuWord.Location = new System.Drawing.Point(1177, 124);
            this.btnLuuWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuuWord.Name = "btnLuuWord";
            this.btnLuuWord.Size = new System.Drawing.Size(133, 28);
            this.btnLuuWord.TabIndex = 10;
            this.btnLuuWord.Text = "Lưu file word";
            this.btnLuuWord.UseVisualStyleBackColor = true;
            this.btnLuuWord.Click += new System.EventHandler(this.btnLuuWord_Click);
            // 
            // btnLuuAnh
            // 
            this.btnLuuAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuAnh.Location = new System.Drawing.Point(1177, 76);
            this.btnLuuAnh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuuAnh.Name = "btnLuuAnh";
            this.btnLuuAnh.Size = new System.Drawing.Size(133, 28);
            this.btnLuuAnh.TabIndex = 9;
            this.btnLuuAnh.Text = "Lưu file ảnh";
            this.btnLuuAnh.UseVisualStyleBackColor = true;
            this.btnLuuAnh.Click += new System.EventHandler(this.btnLuuAnh_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.Location = new System.Drawing.Point(1177, 23);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(133, 28);
            this.btnBaoCao.TabIndex = 8;
            this.btnBaoCao.Text = "Xem báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.cbNhanVien);
            this.groupBox4.Controls.Add(this.lbNhanVien);
            this.groupBox4.Controls.Add(this.cbPhongBan);
            this.groupBox4.Controls.Add(this.lbPhongBan);
            this.groupBox4.Controls.Add(this.cbBoPhan);
            this.groupBox4.Controls.Add(this.lbBoPhan);
            this.groupBox4.Controls.Add(this.numThang);
            this.groupBox4.Controls.Add(this.lbThang);
            this.groupBox4.Controls.Add(this.numNam);
            this.groupBox4.Controls.Add(this.lbNam);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(845, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(324, 218);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhanVien.FormattingEnabled = true;
            this.cbNhanVien.Location = new System.Drawing.Point(117, 73);
            this.cbNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbNhanVien.Name = "cbNhanVien";
            this.cbNhanVien.Size = new System.Drawing.Size(185, 28);
            this.cbNhanVien.TabIndex = 13;
            this.cbNhanVien.Visible = false;
            // 
            // lbNhanVien
            // 
            this.lbNhanVien.AutoSize = true;
            this.lbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhanVien.Location = new System.Drawing.Point(13, 76);
            this.lbNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNhanVien.Name = "lbNhanVien";
            this.lbNhanVien.Size = new System.Drawing.Size(83, 20);
            this.lbNhanVien.TabIndex = 12;
            this.lbNhanVien.Text = "Nhân viên";
            this.lbNhanVien.Visible = false;
            // 
            // cbPhongBan
            // 
            this.cbPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPhongBan.FormattingEnabled = true;
            this.cbPhongBan.Location = new System.Drawing.Point(117, 73);
            this.cbPhongBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPhongBan.Name = "cbPhongBan";
            this.cbPhongBan.Size = new System.Drawing.Size(185, 28);
            this.cbPhongBan.TabIndex = 11;
            this.cbPhongBan.Visible = false;
            // 
            // lbPhongBan
            // 
            this.lbPhongBan.AutoSize = true;
            this.lbPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhongBan.Location = new System.Drawing.Point(13, 76);
            this.lbPhongBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPhongBan.Name = "lbPhongBan";
            this.lbPhongBan.Size = new System.Drawing.Size(88, 20);
            this.lbPhongBan.TabIndex = 10;
            this.lbPhongBan.Text = "Phòng ban";
            this.lbPhongBan.Visible = false;
            // 
            // cbBoPhan
            // 
            this.cbBoPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoPhan.FormattingEnabled = true;
            this.cbBoPhan.Location = new System.Drawing.Point(97, 73);
            this.cbBoPhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBoPhan.Name = "cbBoPhan";
            this.cbBoPhan.Size = new System.Drawing.Size(205, 28);
            this.cbBoPhan.TabIndex = 9;
            this.cbBoPhan.Visible = false;
            // 
            // lbBoPhan
            // 
            this.lbBoPhan.AutoSize = true;
            this.lbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBoPhan.Location = new System.Drawing.Point(13, 76);
            this.lbBoPhan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBoPhan.Name = "lbBoPhan";
            this.lbBoPhan.Size = new System.Drawing.Size(71, 20);
            this.lbBoPhan.TabIndex = 8;
            this.lbBoPhan.Text = "Bộ phận";
            this.lbBoPhan.Visible = false;
            // 
            // numThang
            // 
            this.numThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numThang.Location = new System.Drawing.Point(189, 148);
            this.numThang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numThang.Size = new System.Drawing.Size(53, 26);
            this.numThang.TabIndex = 7;
            this.numThang.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThang.Visible = false;
            // 
            // lbThang
            // 
            this.lbThang.AutoSize = true;
            this.lbThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThang.Location = new System.Drawing.Point(103, 149);
            this.lbThang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThang.Name = "lbThang";
            this.lbThang.Size = new System.Drawing.Size(55, 20);
            this.lbThang.TabIndex = 6;
            this.lbThang.Text = "Tháng";
            this.lbThang.Visible = false;
            // 
            // numNam
            // 
            this.numNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNam.Location = new System.Drawing.Point(169, 148);
            this.numNam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numNam.Size = new System.Drawing.Size(73, 26);
            this.numNam.TabIndex = 5;
            this.numNam.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.numNam.Visible = false;
            // 
            // lbNam
            // 
            this.lbNam.AutoSize = true;
            this.lbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNam.Location = new System.Drawing.Point(103, 149);
            this.lbNam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(44, 20);
            this.lbNam.TabIndex = 4;
            this.lbNam.Text = "Năm";
            this.lbNam.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(112, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hoàn thiện";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rb1Thang);
            this.groupBox3.Controls.Add(this.rb1Nam);
            this.groupBox3.Controls.Add(this.rbAllNam);
            this.groupBox3.Location = new System.Drawing.Point(432, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(493, 218);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(37, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 100);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chọn\r\n cách\r\nthống\r\n   kê";
            // 
            // rb1Thang
            // 
            this.rb1Thang.AutoSize = true;
            this.rb1Thang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1Thang.Location = new System.Drawing.Point(127, 145);
            this.rb1Thang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb1Thang.Name = "rb1Thang";
            this.rb1Thang.Size = new System.Drawing.Size(269, 24);
            this.rb1Thang.TabIndex = 1;
            this.rb1Thang.Text = "Qua tất cả các năm của 1 tháng";
            this.rb1Thang.UseVisualStyleBackColor = true;
            this.rb1Thang.CheckedChanged += new System.EventHandler(this.rb1Thang_CheckedChanged);
            // 
            // rb1Nam
            // 
            this.rb1Nam.AutoSize = true;
            this.rb1Nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1Nam.Location = new System.Drawing.Point(127, 90);
            this.rb1Nam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb1Nam.Name = "rb1Nam";
            this.rb1Nam.Size = new System.Drawing.Size(269, 24);
            this.rb1Nam.TabIndex = 0;
            this.rb1Nam.Text = "Qua tất cả các tháng của 1 năm";
            this.rb1Nam.UseVisualStyleBackColor = true;
            this.rb1Nam.CheckedChanged += new System.EventHandler(this.rb1Nam_CheckedChanged);
            // 
            // rbAllNam
            // 
            this.rbAllNam.AutoSize = true;
            this.rbAllNam.Checked = true;
            this.rbAllNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAllNam.Location = new System.Drawing.Point(127, 34);
            this.rbAllNam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbAllNam.Name = "rbAllNam";
            this.rbAllNam.Size = new System.Drawing.Size(177, 24);
            this.rbAllNam.TabIndex = 2;
            this.rbAllNam.TabStop = true;
            this.rbAllNam.Text = "Qua tất cả các năm";
            this.rbAllNam.UseVisualStyleBackColor = true;
            this.rbAllNam.CheckedChanged += new System.EventHandler(this.rbAllNam_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(647, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // rbCongTy
            // 
            this.rbCongTy.AutoSize = true;
            this.rbCongTy.Checked = true;
            this.rbCongTy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCongTy.Location = new System.Drawing.Point(215, 37);
            this.rbCongTy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCongTy.Name = "rbCongTy";
            this.rbCongTy.Size = new System.Drawing.Size(110, 24);
            this.rbCongTy.TabIndex = 0;
            this.rbCongTy.TabStop = true;
            this.rbCongTy.Text = "Cả công ty";
            this.rbCongTy.UseVisualStyleBackColor = true;
            this.rbCongTy.CheckedChanged += new System.EventHandler(this.rbCongTy_CheckedChanged);
            // 
            // rbBoPhan
            // 
            this.rbBoPhan.AutoSize = true;
            this.rbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBoPhan.Location = new System.Drawing.Point(215, 74);
            this.rbBoPhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbBoPhan.Name = "rbBoPhan";
            this.rbBoPhan.Size = new System.Drawing.Size(162, 24);
            this.rbBoPhan.TabIndex = 1;
            this.rbBoPhan.Text = "1 bộ phận công ty";
            this.rbBoPhan.UseVisualStyleBackColor = true;
            this.rbBoPhan.CheckedChanged += new System.EventHandler(this.rbBoPhan_CheckedChanged);
            // 
            // rbPhongBan
            // 
            this.rbPhongBan.AutoSize = true;
            this.rbPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPhongBan.Location = new System.Drawing.Point(215, 111);
            this.rbPhongBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbPhongBan.Name = "rbPhongBan";
            this.rbPhongBan.Size = new System.Drawing.Size(180, 24);
            this.rbPhongBan.TabIndex = 2;
            this.rbPhongBan.Text = "1 phòng ban công ty";
            this.rbPhongBan.UseVisualStyleBackColor = true;
            this.rbPhongBan.CheckedChanged += new System.EventHandler(this.rbPhongBan_CheckedChanged);
            // 
            // rbNhanVien
            // 
            this.rbNhanVien.AutoSize = true;
            this.rbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNhanVien.Location = new System.Drawing.Point(215, 148);
            this.rbNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbNhanVien.Name = "rbNhanVien";
            this.rbNhanVien.Size = new System.Drawing.Size(174, 24);
            this.rbNhanVien.TabIndex = 3;
            this.rbNhanVien.Text = "1 nhân viên công ty";
            this.rbNhanVien.UseVisualStyleBackColor = true;
            this.rbNhanVien.CheckedChanged += new System.EventHandler(this.rbNhanVien_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rbBoPhan);
            this.groupBox2.Controls.Add(this.rbCongTy);
            this.groupBox2.Controls.Add(this.rbNhanVien);
            this.groupBox2.Controls.Add(this.rbPhongBan);
            this.groupBox2.Location = new System.Drawing.Point(43, 27);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(433, 218);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(25, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn đối tượng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(627, 388);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 28);
            this.label14.TabIndex = 26;
            this.label14.Text = "Vui lòng chờ...";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(565, 369);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(267, 62);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // btnLuuExcel
            // 
            this.btnLuuExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuExcel.Location = new System.Drawing.Point(1177, 176);
            this.btnLuuExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuExcel.Name = "btnLuuExcel";
            this.btnLuuExcel.Size = new System.Drawing.Size(133, 28);
            this.btnLuuExcel.TabIndex = 11;
            this.btnLuuExcel.Text = "Lưu file excel";
            this.btnLuuExcel.UseVisualStyleBackColor = true;
            this.btnLuuExcel.Click += new System.EventHandler(this.btnLuuExcel_Click);
            // 
            // ThongKeLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quan_li_nhan_su.Properties.Resources.space_blue_sky_pastel_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1432, 850);
            this.ControlBox = false;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartThongKe);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThongKeLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê lương nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.ThongKeLuong_Activated);
            this.Load += new System.EventHandler(this.ThongKeLuong_Load);
            this.Shown += new System.EventHandler(this.ThongKeLuong_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb1Thang;
        private System.Windows.Forms.RadioButton rb1Nam;
        private System.Windows.Forms.RadioButton rbAllNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbCongTy;
        private System.Windows.Forms.RadioButton rbBoPhan;
        private System.Windows.Forms.RadioButton rbPhongBan;
        private System.Windows.Forms.RadioButton rbNhanVien;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lbNam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLuuWord;
        private System.Windows.Forms.Button btnLuuAnh;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lbThang;
        private System.Windows.Forms.ComboBox cbPhongBan;
        private System.Windows.Forms.Label lbPhongBan;
        private System.Windows.Forms.ComboBox cbBoPhan;
        private System.Windows.Forms.Label lbBoPhan;
        private System.Windows.Forms.ComboBox cbNhanVien;
        private System.Windows.Forms.Label lbNhanVien;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnLuuExcel;
    }
}