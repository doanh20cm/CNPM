using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        public static string GetMd5(string pass)
        {
            using (var hash = MD5.Create())
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass)).Select(x => x.ToString("x2")));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var taikhoan = txtUsername.Text.Trim();
            var matkhau = txtPassword.Text.Trim();
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

            var quyen = kn.GetData($"select Quyen, Username from tbuser where Username = '{taikhoan}' and Pass = '{GetMd5(matkhau)}'");

            if (quyen.Rows.Count != 1)
            {
                MessageBox.Show(@"Tài khoản không tồn tại hoặc sai mật khẩu", @"Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            GiaoDienChinh.Chucvu = quyen.Rows[0][0].ToString().Trim();
            GiaoDienChinh.Username = quyen.Rows[0][1].ToString().Trim();

            Close();
            MessageBox.Show($@"Chào {quyen.Rows[0][1]}, bạn đã đăng nhập thành công với quyền {quyen.Rows[0][0]}!", @"Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}