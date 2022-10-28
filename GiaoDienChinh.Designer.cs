namespace Quan_li_nhan_su
{
    partial class GiaoDienChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaoDienChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mstTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mstQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQLBoPhan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQLPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQLNhanVienPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQLHoSo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQLLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQLTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mstThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBCLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBCNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstTaiKhoan,
            this.mstQuanLy,
            this.mstThongKe});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mstTaiKhoan
            // 
            this.mstTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangNhap,
            this.menuDoiMatKhau,
            this.menuDangXuat});
            this.mstTaiKhoan.Name = "mstTaiKhoan";
            this.mstTaiKhoan.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mstTaiKhoan.Size = new System.Drawing.Size(69, 20);
            this.mstTaiKhoan.Text = "Tài khoản";
            // 
            // menuDangNhap
            // 
            this.menuDangNhap.Name = "menuDangNhap";
            this.menuDangNhap.Size = new System.Drawing.Size(145, 22);
            this.menuDangNhap.Text = "Đăng nhập";
            this.menuDangNhap.Click += new System.EventHandler(this.menuDangNhap_Click);
            // 
            // menuDoiMatKhau
            // 
            this.menuDoiMatKhau.Enabled = false;
            this.menuDoiMatKhau.Name = "menuDoiMatKhau";
            this.menuDoiMatKhau.Size = new System.Drawing.Size(145, 22);
            this.menuDoiMatKhau.Text = "Đổi mật khẩu";
            this.menuDoiMatKhau.Click += new System.EventHandler(this.menuDoiMatKhau_Click);
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Enabled = false;
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(145, 22);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // mstQuanLy
            // 
            this.mstQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQLBoPhan,
            this.menuQLPhongBan,
            this.menuQLNhanVienPhongBan,
            this.menuQLHoSo,
            this.menuQLLuong,
            this.menuQLTaiKhoan});
            this.mstQuanLy.Enabled = false;
            this.mstQuanLy.Name = "mstQuanLy";
            this.mstQuanLy.Size = new System.Drawing.Size(60, 20);
            this.mstQuanLy.Text = "Quản lý";
            // 
            // menuQLBoPhan
            // 
            this.menuQLBoPhan.Enabled = false;
            this.menuQLBoPhan.Name = "menuQLBoPhan";
            this.menuQLBoPhan.Size = new System.Drawing.Size(189, 22);
            this.menuQLBoPhan.Text = "Bộ phận";
            // 
            // menuQLPhongBan
            // 
            this.menuQLPhongBan.Enabled = false;
            this.menuQLPhongBan.Name = "menuQLPhongBan";
            this.menuQLPhongBan.Size = new System.Drawing.Size(189, 22);
            this.menuQLPhongBan.Text = "Phòng ban";
            // 
            // menuQLNhanVienPhongBan
            // 
            this.menuQLNhanVienPhongBan.Enabled = false;
            this.menuQLNhanVienPhongBan.Name = "menuQLNhanVienPhongBan";
            this.menuQLNhanVienPhongBan.Size = new System.Drawing.Size(189, 22);
            this.menuQLNhanVienPhongBan.Text = "Nhân viên phòng ban";
            this.menuQLNhanVienPhongBan.Click += new System.EventHandler(this.menuQLNhanVienPhongBan_Click);
            // 
            // menuQLHoSo
            // 
            this.menuQLHoSo.Enabled = false;
            this.menuQLHoSo.Name = "menuQLHoSo";
            this.menuQLHoSo.Size = new System.Drawing.Size(189, 22);
            this.menuQLHoSo.Text = "Hồ sơ nhân viên";
            this.menuQLHoSo.Click += new System.EventHandler(this.menuQLHoSo_Click);
            // 
            // menuQLLuong
            // 
            this.menuQLLuong.Enabled = false;
            this.menuQLLuong.Name = "menuQLLuong";
            this.menuQLLuong.Size = new System.Drawing.Size(189, 22);
            this.menuQLLuong.Text = "Lương nhân viên";
            // 
            // menuQLTaiKhoan
            // 
            this.menuQLTaiKhoan.Enabled = false;
            this.menuQLTaiKhoan.Name = "menuQLTaiKhoan";
            this.menuQLTaiKhoan.Size = new System.Drawing.Size(189, 22);
            this.menuQLTaiKhoan.Text = "Tài khoản nhân viên";
            // 
            // mstThongKe
            // 
            this.mstThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBCLuong,
            this.menuBCNhanVien});
            this.mstThongKe.Enabled = false;
            this.mstThongKe.Name = "mstThongKe";
            this.mstThongKe.Size = new System.Drawing.Size(68, 20);
            this.mstThongKe.Text = "Thống kê";
            this.mstThongKe.Click += new System.EventHandler(this.mstThongKe_Click);
            // 
            // menuBCLuong
            // 
            this.menuBCLuong.Enabled = false;
            this.menuBCLuong.Name = "menuBCLuong";
            this.menuBCLuong.Size = new System.Drawing.Size(171, 22);
            this.menuBCLuong.Text = "Báo cáo lương";
            // 
            // menuBCNhanVien
            // 
            this.menuBCNhanVien.Enabled = false;
            this.menuBCNhanVien.Name = "menuBCNhanVien";
            this.menuBCNhanVien.Size = new System.Drawing.Size(171, 22);
            this.menuBCNhanVien.Text = "Báo cáo nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(426, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(385, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 50);
            this.label2.TabIndex = 3;
            // 
            // GiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quan_li_nhan_su.Properties.Resources.daniela_cuevas_t7YycgAoVSw_unsplash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "GiaoDienChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý nhân sự AnPhatComputer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mstTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem menuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mstQuanLy;
        private System.Windows.Forms.ToolStripMenuItem menuQLBoPhan;
        private System.Windows.Forms.ToolStripMenuItem menuQLPhongBan;
        private System.Windows.Forms.ToolStripMenuItem menuQLNhanVienPhongBan;
        private System.Windows.Forms.ToolStripMenuItem menuQLLuong;
        private System.Windows.Forms.ToolStripMenuItem menuQLTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mstThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuBCLuong;
        private System.Windows.Forms.ToolStripMenuItem menuBCNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuQLHoSo;
        private System.Windows.Forms.ToolStripMenuItem menuDangNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}