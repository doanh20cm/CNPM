﻿using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
	public partial class GiaoDienChinh : Form
	{
		public static string Chucvu = "";
		public static string Username = "";
		public static string ConnStr = "";
		private static readonly byte[] Key = Encoding.ASCII.GetBytes("VTFlZUlncTgrZz09");
		private static readonly byte[] Iv = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");

		private readonly Timer _time = new Timer();


		public GiaoDienChinh()
		{
			InitializeComponent();
			try
			{
				DecryptString_Aes(Key, Iv);
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Không tìm thấy cấu hình kết nối, vui lòng liên hệ bộ phận  IT của công ty", "Cảnh báo",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception)
			{
				MessageBox.Show("Đã có lỗi xảy ra khi tải cấu hình kết nối, vui lòng liên hệ bộ phận IT của công ty!",
					"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			_time.Interval = 1000;
			_time.Tick += time_Tick;
			_time.Start();
		}

		private static void DecryptString_Aes(byte[] key, byte[] iv)
		{
			var cipherText = File.ReadAllBytes("config.bin");
			string plaintext;
			using (var aesAlg = Aes.Create())
			{
				aesAlg.Key = key;
				aesAlg.IV = iv;
				var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				using (var msDecrypt = new MemoryStream(cipherText))
				{
					using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (var srDecrypt = new StreamReader(csDecrypt))
						{
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}
			}

			ConnStr = plaintext;
		}

		private void DongForm()
		{
			foreach (var form in MdiChildren)
			{
				form.Close();
				form.Dispose();
			}

			GC.Collect();
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

			bool isOldPassCorrect;
			//       if (KetNoi.GetData(
			//	$"")
			//.Rows.Count != 1)
			try
			{
				using (var connection = new SqlConnection(ConnStr))
				{
					connection.Open();
					using (var command = new SqlCommand
					{
						Connection = connection,
						CommandText =
								   "select TaiKhoan from NguoiDung where TaiKhoan = @TaiKhoan and MatKhau = @MatKhau"
					})
					{
						command.Parameters.AddWithValue("@TaiKhoan", Username);
						command.Parameters.AddWithValue("@MatKhau", DangNhap.GetMd5(oldPass));
						using (var reader = command.ExecuteReader())
						{
							isOldPassCorrect = reader.Read() && !reader.Read();
						}
					}
				}
			}
			catch (Exception)
			{
				isOldPassCorrect = false;
			}

			if (!isOldPassCorrect)
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

			bool ableToChangePass;
			try
			{
				using (var connection = new SqlConnection(ConnStr))
				{
					connection.Open();
					using (var command = new SqlCommand
					{
						Connection = connection,
						CommandText =
								   "update NguoiDung set MatKhau = @MatKhau where TaiKhoan = @TaiKhoan"
					})
					{
						command.Parameters.AddWithValue("@TaiKhoan", Username);
						command.Parameters.AddWithValue("@MatKhau", DangNhap.GetMd5(newPass));
						ableToChangePass = command.ExecuteNonQuery() == 1;
					}
				}
			}
			catch (Exception)
			{
				ableToChangePass = false;
			}

			MessageBox.Show(ableToChangePass ? "Đổi mật khẩu thành công!" : "Đổi mật khẩu thất bại!",
				ableToChangePass ? "Thông báo" : "Lỗi",
				MessageBoxButtons.OK, ableToChangePass ? MessageBoxIcon.Information : MessageBoxIcon.Error);
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
				if (f is QLHoSoNhanVien)
				{
					f.WindowState = FormWindowState.Maximized;

					f.Activate();
					return;
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
				if (f is QLNhanVienPhongBan)
				{
					f.WindowState = FormWindowState.Maximized;

					f.Activate();
					return;
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
				if (f is QLBoPhan)
				{
					f.WindowState = FormWindowState.Maximized;

					f.Activate();
					return;
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

		private void mstCaiDat_Click(object sender, EventArgs e)
		{
			new CaiDat().ShowDialog();
		}

		private void GiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
		{
			var luachon = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Xác nhận thoát", MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);
			if (luachon == DialogResult.No) e.Cancel = true;
		}
	}
}