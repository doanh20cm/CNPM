using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
	public partial class GiaoDienChinh : Form
	{
		public static string Chucvu = "";
		public static string Username = "";
		private readonly Timer _time = new Timer();

		public GiaoDienChinh()
		{
			InitializeComponent();
			_time.Interval = 1000;
			_time.Tick += time_Tick;
			_time.Start();
		}

		private void DongForm()
		{
			foreach (var t in MdiChildren) t.Close();
			label1.Visible = true;
			label2.Visible = true;
			label3.Visible = true;
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
			var luachon = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Xác nhận thoát", MessageBoxButtons.YesNo,
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
			var luachon = MessageBox.Show("Bạn chắc chắn muốn đăng xuất ?", "Xác nhận đăng xuất",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (luachon != DialogResult.Yes) return;
			Chucvu = "";
			Username = "";
			DongForm();
			SetQuyen();
			MessageBox.Show("Đăng xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void menuDoiMatKhau_Click(object sender, EventArgs e)
		{
			var oldPass = "";
			if (InputBox("Đổi mật khẩu", "Nhập mật khẩu cũ:", ref oldPass) != DialogResult.OK) return;
			if (oldPass?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập mật khẩu cũ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (KetNoi.GetData(
						$"select TaiKhoan from NguoiDung where TaiKhoan = '{Username}' and  MatKhau = '{DangNhap.GetMd5(oldPass)}'")
					.Rows.Count != 1)
			{
				MessageBox.Show("Mật khẩu cũ không đúng", "Lỗi", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			var newPass = "";
			if (InputBox("Đổi mật khẩu", "Nhập mật khẩu mới:", ref newPass) != DialogResult.OK) return;
			if (newPass?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			var kq = KetNoi.Execute(
				$"update NguoiDung set MatKhau = '{DangNhap.GetMd5(newPass)}' where TaiKhoan = '{Username}'");
			MessageBox.Show(kq ? "Đổi mật khẩu thành công!" : "Đổi mật khẩu thất bại!", kq ? "Thông báo" : "Lỗi",
				MessageBoxButtons.OK, kq ? MessageBoxIcon.Information : MessageBoxIcon.Error);
		}

		private static DialogResult InputBox(string title, string promptText, ref string value)
		{
			var form = new Form();
			var label = new Label();
			var textBox = new TextBox();
			var buttonOk = new Button();
			var buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			form.AcceptButton = buttonOk;
			textBox.UseSystemPasswordChar = true;


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
			var dialogResult = form.ShowDialog();
			if (dialogResult == DialogResult.OK) value = textBox.Text;
			return dialogResult;
		}


		private void menuQLHoSo_Click(object sender, EventArgs e)
		{
			foreach (var f in MdiChildren)
			{
				if (f is QLHoSoNhanVien)
				{
					f.Activate();
					f.WindowState = FormWindowState.Maximized;
					return;
				}
			}
			label1.Visible = false;
			label2.Visible = false;
			label3.Visible = false;
			var qlhsnv = new QLHoSoNhanVien
			{
				MdiParent = this
			};
			qlhsnv.Show();
		}

		private void menuQLNhanVienPhongBan_Click(object sender, EventArgs e)
		{
			foreach (var f in MdiChildren)
			{
				if (f is QLNhanVienPhongBan)
				{
					f.Activate();
					return;
				}
			}

			label1.Visible = false;
			label2.Visible = false;
			label3.Visible = false;
			var qlnvpb = new QLNhanVienPhongBan
			{
				MdiParent = this
			};
			qlnvpb.Show();
		}

		private void time_Tick(object sender, EventArgs e)
		{
			var thuCuaTuan = "";
			switch (DateTime.Now.DayOfWeek)
			{
				case DayOfWeek.Monday:
					thuCuaTuan = "Thứ hai";
					break;
				case DayOfWeek.Tuesday:
					thuCuaTuan = "Thứ ba";
					break;
				case DayOfWeek.Wednesday:
					thuCuaTuan = "Thứ tư";
					break;
				case DayOfWeek.Thursday:
					thuCuaTuan = "Thứ năm";
					break;
				case DayOfWeek.Friday:
					thuCuaTuan = "Thứ sáu";
					break;
				case DayOfWeek.Saturday:
					thuCuaTuan = "Thứ bảy";
					break;
				case DayOfWeek.Sunday:
					thuCuaTuan = "Chủ nhật";
					break;
			}
			label3.Text = $"{thuCuaTuan}, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
			var hh = DateTime.Now.Hour;
			var mm = DateTime.Now.Minute;
			var ss = DateTime.Now.Second;
			var time = "";
			if (hh < 10)
				time += "0" + hh;
			else
				time += hh;
			time += ":";
			if (mm < 10)
				time += "0" + mm;
			else
				time += mm;
			time += ":";

			if (ss < 10)
				time += "0" + ss;
			else
				time += ss;
			label1.Text = time;
			switch (hh)
			{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					label2.Text = "Chào buổi sáng";
					break;
				case 11:
				case 12:
					label2.Text = "Chào buổi trưa";
					break;
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
					label2.Text = "Chào buổi chiều";
					break;
				case 19:
				case 20:
				case 21:
					label2.Text = "Chào buổi tối";
					break;
				default:
					label2.Text = "Chào buổi đêm";
					break;
			}
		}

		private void menuQLBoPhan_Click(object sender, EventArgs e)
		{
			foreach (var f in MdiChildren)
			{
				if (f is QLBoPhan)
				{
					f.Activate();
					return;
				}
			}

			label1.Visible = false;
			label1.Visible = false;
			label3.Visible = false;
			label2.Visible = false;
			var qlbp = new QLBoPhan
			{
				MdiParent = this
			};
			qlbp.Show();
		}
	}
}