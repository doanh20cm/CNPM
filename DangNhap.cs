using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace Quan_li_nhan_su
{
	public partial class DangNhap : Form
	{
		public DangNhap()
		{
			InitializeComponent();
		}

		private string GetMd5(string pass)
		{
			using (var hash = MD5.Create())
				return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass)).Select(x => x.ToString("x2")));
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			var taikhoan = txtUsername.Text;
			var matkhau = GetMd5(txtPassword.Text);
			if (taikhoan == "")
			{
				MessageBox.Show(@"Bạn chưa nhập tài khoản!", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (matkhau == "")
			{
				MessageBox.Show(@"Bạn chưa nhập mật khẩu!", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				var conn = new SqlConnection(@"Server=localhost\\SQLEXPRESS,1433;Database=QLNS;UID=sa;PWD=12345");
				conn.Open();
				var select = $"select Quyen from tbuser where Username = '{taikhoan}' and Pass = '{matkhau}'";
				var cmd = new SqlCommand(select, conn);
				var quyen = cmd.ExecuteScalar();
				conn.Close();
				if (quyen is null)
				{
					MessageBox.Show(@"Tài khoản không tồn tại hoặc sai mật khẩu", @"Lỗi", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
				else
				{
					GiaoDienChinh.Chucvu = quyen.ToString().Trim();
					Close();
					MessageBox.Show($@"Đăng nhập thành công với quyền {quyen}", @"Thông báo", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
			}
			catch
			{
				MessageBox.Show(@"Không thể kết nối đến máy chủ", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}