using System.ComponentModel;
using System.Windows.Forms;
namespace Quan_li_nhan_su
{
    partial class DangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRemoveSaved = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnForgot = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCheckOTP = new System.Windows.Forms.Button();
            this.btnRequestOTP = new System.Windows.Forms.Button();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(142, 88);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(151, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(124, 161);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(97, 33);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(124, 161);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(97, 33);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // btnRemoveSaved
            // 
            this.btnRemoveSaved.Location = new System.Drawing.Point(139, 51);
            this.btnRemoveSaved.Name = "btnRemoveSaved";
            this.btnRemoveSaved.Size = new System.Drawing.Size(58, 23);
            this.btnRemoveSaved.TabIndex = 4;
            this.btnRemoveSaved.Text = "Bỏ lưu";
            this.btnRemoveSaved.UseVisualStyleBackColor = true;
            this.btnRemoveSaved.Click += new System.EventHandler(this.btnRemoveSaved_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(142, 21);
            this.comboBox1.MaxLength = 50;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Bỏ lưu tất cả";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Quan_li_nhan_su.Properties.Resources.hide;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(270, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 24;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnForgot
            // 
            this.btnForgot.Location = new System.Drawing.Point(195, 120);
            this.btnForgot.Name = "btnForgot";
            this.btnForgot.Size = new System.Drawing.Size(98, 23);
            this.btnForgot.TabIndex = 25;
            this.btnForgot.Text = "Quên mật khẩu ?";
            this.btnForgot.UseVisualStyleBackColor = true;
            this.btnForgot.Click += new System.EventHandler(this.btnForgot_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(50, 185);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(58, 23);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Trở về";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtOTP
            // 
            this.txtOTP.Enabled = false;
            this.txtOTP.Location = new System.Drawing.Point(142, 90);
            this.txtOTP.MaxLength = 6;
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(151, 20);
            this.txtOTP.TabIndex = 30;
            this.txtOTP.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(142, 22);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(151, 20);
            this.txtEmail.TabIndex = 29;
            this.txtEmail.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "OTP";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Email";
            this.label4.Visible = false;
            // 
            // btnCheckOTP
            // 
            this.btnCheckOTP.Enabled = false;
            this.btnCheckOTP.Location = new System.Drawing.Point(218, 120);
            this.btnCheckOTP.Name = "btnCheckOTP";
            this.btnCheckOTP.Size = new System.Drawing.Size(75, 23);
            this.btnCheckOTP.TabIndex = 32;
            this.btnCheckOTP.Text = "Kiểm tra";
            this.btnCheckOTP.UseVisualStyleBackColor = true;
            this.btnCheckOTP.Visible = false;
            this.btnCheckOTP.Click += new System.EventHandler(this.btnCheckOTP_Click);
            // 
            // btnRequestOTP
            // 
            this.btnRequestOTP.Location = new System.Drawing.Point(218, 51);
            this.btnRequestOTP.Name = "btnRequestOTP";
            this.btnRequestOTP.Size = new System.Drawing.Size(75, 23);
            this.btnRequestOTP.TabIndex = 31;
            this.btnRequestOTP.Text = "Gửi OTP";
            this.btnRequestOTP.UseVisualStyleBackColor = true;
            this.btnRequestOTP.Visible = false;
            this.btnRequestOTP.Click += new System.EventHandler(this.btnRequestOTP_Click);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Enabled = false;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(142, 158);
            this.txtMatKhauMoi.MaxLength = 50;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(151, 20);
            this.txtMatKhauMoi.TabIndex = 34;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            this.txtMatKhauMoi.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Mật khẩu mới";
            this.label5.Visible = false;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Enabled = false;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(218, 185);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(75, 23);
            this.btnDoiMatKhau.TabIndex = 35;
            this.btnDoiMatKhau.Text = "Đổi";
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Visible = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // DangNhap
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quan_li_nhan_su.Properties.Resources._360_F_122719641_V0yw2cAOrfxsON3HeWi2Sf4iVxhv27QO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(341, 225);
            this.Controls.Add(this.btnDoiMatKhau);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCheckOTP);
            this.Controls.Add(this.btnRequestOTP);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnForgot);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnRemoveSaved);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "                                            Đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DangNhap_FormClosed);
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Button btnLogin;
        private ProgressBar progressBar1;
        private Button btnRemoveSaved;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button btnForgot;
        private Button btnBack;
        private TextBox txtOTP;
        private TextBox txtEmail;
        private Label label3;
        private Label label4;
        private Button btnCheckOTP;
        private Button btnRequestOTP;
        private TextBox txtMatKhauMoi;
        private Label label5;
        private Button btnDoiMatKhau;
    }
}
