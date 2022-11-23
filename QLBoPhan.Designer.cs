using System.ComponentModel;
using System.Windows.Forms;
namespace Quan_li_nhan_su
{
    partial class QLBoPhan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
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
            this.dgvBoPhan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenBoPhan = new System.Windows.Forms.TextBox();
            this.rtGhiChu = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayThanhLap = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpTimSau = new System.Windows.Forms.DateTimePicker();
            this.dtpTimTruoc = new System.Windows.Forms.DateTimePicker();
            this.chkTimSau = new System.Windows.Forms.CheckBox();
            this.chkTimTruoc = new System.Windows.Forms.CheckBox();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.chkTimTen = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoPhan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBoPhan
            // 
            this.dgvBoPhan.AllowUserToAddRows = false;
            this.dgvBoPhan.AllowUserToDeleteRows = false;
            this.dgvBoPhan.AllowUserToResizeColumns = false;
            this.dgvBoPhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBoPhan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBoPhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoPhan.Location = new System.Drawing.Point(32, 285);
            this.dgvBoPhan.MultiSelect = false;
            this.dgvBoPhan.Name = "dgvBoPhan";
            this.dgvBoPhan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBoPhan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBoPhan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvBoPhan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBoPhan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoPhan.Size = new System.Drawing.Size(998, 341);
            this.dgvBoPhan.TabIndex = 0;
            this.dgvBoPhan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBoPhan_CellClick);
            this.dgvBoPhan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvBoPhan_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTenBoPhan);
            this.groupBox1.Controls.Add(this.rtGhiChu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpNgayThanhLap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thông tin bộ phận";
            // 
            // txtTenBoPhan
            // 
            this.txtTenBoPhan.Location = new System.Drawing.Point(145, 40);
            this.txtTenBoPhan.MaxLength = 50;
            this.txtTenBoPhan.Name = "txtTenBoPhan";
            this.txtTenBoPhan.Size = new System.Drawing.Size(130, 20);
            this.txtTenBoPhan.TabIndex = 8;
            // 
            // rtGhiChu
            // 
            this.rtGhiChu.Location = new System.Drawing.Point(474, 107);
            this.rtGhiChu.MaxLength = 50;
            this.rtGhiChu.Name = "rtGhiChu";
            this.rtGhiChu.Size = new System.Drawing.Size(130, 51);
            this.rtGhiChu.TabIndex = 7;
            this.rtGhiChu.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ghi chú";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(474, 40);
            this.txtSDT.MaxLength = 10;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(130, 20);
            this.txtSDT.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày thành lập";
            // 
            // dtpNgayThanhLap
            // 
            this.dtpNgayThanhLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThanhLap.Location = new System.Drawing.Point(145, 100);
            this.dtpNgayThanhLap.Name = "dtpNgayThanhLap";
            this.dtpNgayThanhLap.Size = new System.Drawing.Size(130, 20);
            this.dtpNgayThanhLap.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên bộ phận";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTimSau);
            this.groupBox2.Controls.Add(this.dtpTimTruoc);
            this.groupBox2.Controls.Add(this.chkTimSau);
            this.groupBox2.Controls.Add(this.chkTimTruoc);
            this.groupBox2.Controls.Add(this.txtTimTen);
            this.groupBox2.Controls.Add(this.chkTimTen);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(716, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 187);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dtpTimSau
            // 
            this.dtpTimSau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimSau.Location = new System.Drawing.Point(162, 85);
            this.dtpTimSau.Name = "dtpTimSau";
            this.dtpTimSau.Size = new System.Drawing.Size(130, 20);
            this.dtpTimSau.TabIndex = 6;
            // 
            // dtpTimTruoc
            // 
            this.dtpTimTruoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimTruoc.Location = new System.Drawing.Point(162, 138);
            this.dtpTimTruoc.Name = "dtpTimTruoc";
            this.dtpTimTruoc.Size = new System.Drawing.Size(130, 20);
            this.dtpTimTruoc.TabIndex = 5;
            // 
            // chkTimSau
            // 
            this.chkTimSau.AutoSize = true;
            this.chkTimSau.Location = new System.Drawing.Point(27, 88);
            this.chkTimSau.Name = "chkTimSau";
            this.chkTimSau.Size = new System.Drawing.Size(120, 17);
            this.chkTimSau.TabIndex = 4;
            this.chkTimSau.Text = "Thành lập sau ngày";
            this.chkTimSau.UseVisualStyleBackColor = true;
            // 
            // chkTimTruoc
            // 
            this.chkTimTruoc.AutoSize = true;
            this.chkTimTruoc.Location = new System.Drawing.Point(27, 138);
            this.chkTimTruoc.Name = "chkTimTruoc";
            this.chkTimTruoc.Size = new System.Drawing.Size(127, 17);
            this.chkTimTruoc.TabIndex = 3;
            this.chkTimTruoc.Text = "Thành lập trước ngày";
            this.chkTimTruoc.UseVisualStyleBackColor = true;
            // 
            // txtTimTen
            // 
            this.txtTimTen.Location = new System.Drawing.Point(162, 37);
            this.txtTimTen.MaxLength = 50;
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(130, 20);
            this.txtTimTen.TabIndex = 2;
            // 
            // chkTimTen
            // 
            this.chkTimTen.AutoSize = true;
            this.chkTimTen.Location = new System.Drawing.Point(27, 39);
            this.chkTimTen.Name = "chkTimTen";
            this.chkTimTen.Size = new System.Drawing.Size(99, 17);
            this.chkTimTen.TabIndex = 1;
            this.chkTimTen.Text = "Có tên bộ phận";
            this.chkTimTen.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm kiếm bộ phận";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(868, 236);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(675, 236);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 11;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(480, 236);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(290, 236);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(103, 236);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(474, 315);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 21);
            this.label14.TabIndex = 14;
            this.label14.Text = "Vui lòng chờ...";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(428, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 50);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // QLBoPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quan_li_nhan_su.Properties.Resources.space_blue_sky_pastel_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1074, 691);
            this.ControlBox = false;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvBoPhan);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "QLBoPhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý bộ phận";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.QLBoPhan_Activated);
            this.Load += new System.EventHandler(this.QLBoPhan_Load);
            this.Shown += new System.EventHandler(this.QLBoPhan_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoPhan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DataGridView dgvBoPhan;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnTimKiem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Label label2;
        private DateTimePicker dtpNgayThanhLap;
        private Label label1;
        private RichTextBox rtGhiChu;
        private Label label4;
        private TextBox txtSDT;
        private Label label3;
        private TextBox txtTenBoPhan;
        private Label label5;
        private Label label6;
        private TextBox txtTimTen;
        private CheckBox chkTimTen;
        private DateTimePicker dtpTimSau;
        private DateTimePicker dtpTimTruoc;
        private CheckBox chkTimSau;
        private CheckBox chkTimTruoc;
        private Label label14;
        private ProgressBar progressBar1;
    }
}