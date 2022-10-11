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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mstTaiKhoan, this.mstQuanLy, this.mstThongKe });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mstTaiKhoan
            // 
            this.mstTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuDangNhap, this.menuDoiMatKhau, this.menuDangXuat });
            this.mstTaiKhoan.Name = "mstTaiKhoan";
            this.mstTaiKhoan.Size = new System.Drawing.Size(69, 20);
            this.mstTaiKhoan.Text = "Tài khoản";
            this.mstTaiKhoan.Click += new System.EventHandler(this.mstTaiKhoan_Click);
            // 
            // menuDangNhap
            // 
            this.menuDangNhap.Name = "menuDangNhap";
            this.menuDangNhap.Size = new System.Drawing.Size(152, 22);
            this.menuDangNhap.Text = "Đăng nhập";
            this.menuDangNhap.Click += new System.EventHandler(this.menuDangNhap_Click);
            // 
            // menuDoiMatKhau
            // 
            this.menuDoiMatKhau.Enabled = false;
            this.menuDoiMatKhau.Name = "menuDoiMatKhau";
            this.menuDoiMatKhau.Size = new System.Drawing.Size(152, 22);
            this.menuDoiMatKhau.Text = "Đổi mật khẩu";
            this.menuDoiMatKhau.Click += new System.EventHandler(this.menuDoiMatKhau_Click);
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Enabled = false;
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(152, 22);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // mstQuanLy
            // 
            this.mstQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuQLBoPhan, this.menuQLPhongBan, this.menuQLNhanVienPhongBan, this.menuQLHoSo, this.menuQLLuong, this.menuQLTaiKhoan });
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
            // 
            // menuQLHoSo
            // 
            this.menuQLHoSo.Enabled = false;
            this.menuQLHoSo.Name = "menuQLHoSo";
            this.menuQLHoSo.Size = new System.Drawing.Size(189, 22);
            this.menuQLHoSo.Text = "Hồ sơ nhân viên";
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
            this.mstThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuBCLuong, this.menuBCNhanVien });
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
            // GiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GiaoDienChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GiaoDienChinh";
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
    }
}