using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Quan_li_nhan_su
{
	public partial class GiaoDienChinh : Form
	{
		public static string Chucvu = "";

		public GiaoDienChinh()
		{
			InitializeComponent();
		}

		private void SetQuyen()
		{
			switch (Chucvu)
			{
				case "Giám đốc":
					menuDangNhap.Enabled = false;
					menuDoiMatKhau.Enabled = true;
					menuDangXuat.Enabled = true;
					mstQuanLy.Enabled = true;
					menuQLBoPhan.Enabled = true;
					menuQLPhongBan.Enabled = true;
					menuQLNhanVienPhongBan.Enabled = true;
					menuQLHoSo.Enabled = true;
					menuQLLuong.Enabled = true;
					menuQLTaiKhoan.Enabled = true;
					menuBCLuong.Enabled = true;
					menuBCNhanVien.Enabled = true;
					mstThongKe.Enabled = true;
					break;
				case "Quản trị bộ phận":
					menuDangNhap.Enabled = false;
					menuDoiMatKhau.Enabled = true;
					menuDangXuat.Enabled = true;
					menuQLPhongBan.Enabled = true;
					mstQuanLy.Enabled = true;
					break;
				case "Quản trị phòng ban":
					menuDangNhap.Enabled = false;
					menuDoiMatKhau.Enabled = true;
					menuDangXuat.Enabled = true;
					menuQLNhanVienPhongBan.Enabled = true;
					mstQuanLy.Enabled = true;
					break;
				case "Kế toán":
					menuDangNhap.Enabled = false;
					menuDoiMatKhau.Enabled = true;
					menuDangXuat.Enabled = true;
					mstQuanLy.Enabled = true;
					menuQLLuong.Enabled = true;
					break;
				case "Quản trị nhân lực":
					menuDangNhap.Enabled = false;
					menuDoiMatKhau.Enabled = true;
					menuDangXuat.Enabled = true;
					mstQuanLy.Enabled = true;
					menuQLHoSo.Enabled = true;
					break;
				default:
					menuDangNhap.Enabled = true;
					menuDangXuat.Enabled = false;
					menuDoiMatKhau.Enabled = false;
					mstQuanLy.Enabled = false;
					mstThongKe.Enabled = false;
					menuQLBoPhan.Enabled = false;
					menuQLPhongBan.Enabled = false;
					menuQLHoSo.Enabled = false;
					menuQLLuong.Enabled = false;
					menuQLTaiKhoan.Enabled = false;
					menuBCLuong.Enabled = false;
					menuBCNhanVien.Enabled = false;
					break;
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			var luachon = MessageBox.Show(@"Bạn chắc chắn muốn thoát ?", @"Xác nhận thoát", MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (luachon == DialogResult.No) e.Cancel = true;
		}

		private void mstThongKe_Click(object sender, EventArgs e)
		{
		}

		private void menuDangNhap_Click(object sender, EventArgs e)
		{
			new DangNhap().ShowDialog();
			if (Chucvu != "") SetQuyen();
		}

		private void menuDangXuat_Click(object sender, EventArgs e)
		{
			var luachon = MessageBox.Show(@"Bạn chắc chắn muốn đăng xuất ?", @"Xác nhận đăng xuất",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (luachon != DialogResult.Yes) return;
			Chucvu = "";
			SetQuyen();
			MessageBox.Show(@"Đăng xuất thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void mstTaiKhoan_Click(object sender, EventArgs e)
		{

		}

		private void menuDoiMatKhau_Click(object sender, EventArgs e)
		{
			var oldPass = "";
			InputBox("Đổi mật khẩu", "Nhập mật khẩu cũ:", ref oldPass);
			MessageBox.Show(oldPass);
			
		}
		
		public static DialogResult InputBox(string title, string promptText, ref string value)
		{
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();
			Button buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			
			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancel";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor |= AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.ControlBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;
			var dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}
	}
}