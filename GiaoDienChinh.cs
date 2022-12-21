using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Quan_li_nhan_su
{
    public partial class GiaoDienChinh : Form
    {
        public static string Chucvu = "";
        public static string Username = "";
        public static string ConnStr = "";
        public static string Luongcoso = "";
        private static readonly byte[] Key = Encoding.ASCII.GetBytes("VTFlZUlncTgrZz09");
        private static readonly byte[] Iv = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");
        private readonly Timer _time = new Timer();
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x216)
            { // Trap WM_MOVING
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                Screen scr = Screen.FromRectangle(Rectangle.FromLTRB(rc.left, rc.top, rc.right, rc.bottom));
                if (rc.left < scr.WorkingArea.Left) { rc.left = scr.WorkingArea.Left; rc.right = rc.left + this.Width; }
                if (rc.top < scr.WorkingArea.Top) { rc.top = scr.WorkingArea.Top; rc.bottom = rc.top + this.Height; }
                if (rc.right > scr.WorkingArea.Right) { rc.right = scr.WorkingArea.Right; rc.left = rc.right - this.Width; }
                if (rc.bottom > scr.WorkingArea.Bottom) { rc.bottom = scr.WorkingArea.Bottom; rc.top = rc.bottom - this.Height; }
                Marshal.StructureToPtr(rc, m.LParam, false);
            }
            base.WndProc(ref m);
        }
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        public GiaoDienChinh()
        {
            InitializeComponent();
            _time.Interval = 1000;
            _time.Tick += time_Tick;
            _time.Start();
            if (!File.Exists("config.bin"))
            {
                MessageBox.Show("Không tìm thấy cấu hình kết nối, vui lòng liên hệ bộ phận IT của công ty", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DecryptString_Aes(Key, Iv);
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tải cấu hình kết nối, vui lòng liên hệ bộ phận IT của công ty!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                GC.Collect();
            }
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }
        private void SetQuyen()
        {
            menuDangNhap.Enabled = false;
            menuDoiMatKhau.Enabled = true;
            menuDangXuat.Enabled = true;
            mstCaiDat.Enabled = false;
            kếtNốiToolStripMenuItem.Enabled = false;
            lươngMặcĐịnhToolStripMenuItem.Enabled = false;
            switch (Chucvu)
            {
                case "Giám đốc":
                    mstQuanLy.Enabled = true;
                    menuQLBoPhan.Enabled = true;
                    menuQLPhongBan.Enabled = true;
                    menuQLNhanVienPhongBan.Enabled = true;
                    menuQLHoSo.Enabled = true;
                    menuQLLuong.Enabled = true;
                    menuQLTaiKhoan.Enabled = true;
                    menuBCLuong.Enabled = true;
                    mstThongKe.Enabled = true;
                    mstCaiDat.Enabled = true;
                    lươngMặcĐịnhToolStripMenuItem.Enabled = true;
                    break;
                case "Phó giám đốc":
                    mstQuanLy.Enabled = true;
                    menuQLBoPhan.Enabled = true;
                    menuQLPhongBan.Enabled = true;
                    menuQLNhanVienPhongBan.Enabled = true;
                    menuQLHoSo.Enabled = true;
                    menuQLLuong.Enabled = true;
                    menuBCLuong.Enabled = true;
                    mstThongKe.Enabled = true;
                    mstCaiDat.Enabled = true;
                    lươngMặcĐịnhToolStripMenuItem.Enabled = true;
                    break;
                case "Quản trị bộ phận":
                    menuQLPhongBan.Enabled = true;
                    mstQuanLy.Enabled = true;
                    break;
                case "Quản trị phòng ban":
                    menuQLNhanVienPhongBan.Enabled = true;
                    mstQuanLy.Enabled = true;
                    break;
                case "Kế toán":
                    mstQuanLy.Enabled = true;
                    menuQLLuong.Enabled = true;
                    mstCaiDat.Enabled = true;
                    lươngMặcĐịnhToolStripMenuItem.Enabled = true;
                    break;
                case "Quản trị nhân lực":
                    mstQuanLy.Enabled = true;
                    menuQLHoSo.Enabled = true;
                    break;
                default:
                    menuDangNhap.Enabled = true;
                    menuDoiMatKhau.Enabled = false;
                    menuDangXuat.Enabled = false;
                    mstCaiDat.Enabled = true;
                    mstQuanLy.Enabled = false;
                    menuQLBoPhan.Enabled = false;
                    menuQLPhongBan.Enabled = false;
                    menuQLNhanVienPhongBan.Enabled = false;
                    menuQLHoSo.Enabled = false;
                    menuQLLuong.Enabled = false;
                    menuQLTaiKhoan.Enabled = false;
                    menuBCLuong.Enabled = false;
                    mstThongKe.Enabled = false;
                    kếtNốiToolStripMenuItem.Enabled = false;
                    lươngMặcĐịnhToolStripMenuItem.Enabled = false;
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
            GC.Collect();
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
            if (!Regex.IsMatch(newPass, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private DialogResult InputBox(string title, string promptText, ref string value)
        {
            var form = new Form();
            // make the from unmoveable
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
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
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            foreach (var f in MdiChildren)
                if (f is QLHoSoNhanVien)
                {
                    f.Activate();
                    return;
                }
            var qlhsnv = new QLHoSoNhanVien
            {
                MdiParent = this
            };
            qlhsnv.Show();
        }
        private void menuQLNhanVienPhongBan_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            foreach (var f in MdiChildren)
                if (f is QLNhanVienPhongBan)
                {

                    f.Activate();

                    return;
                }
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
            label1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            foreach (var f in MdiChildren)
                if (f is QLBoPhan)
                {

                    f.Activate();

                    return;
                }
            var qlbp = new QLBoPhan
            {
                MdiParent = this
            };
            qlbp.Show();
        }
        private void mstCaiDat_Click(object sender, EventArgs e)
        {
            //new CaiDat().ShowDialog();
        }
        private void GiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            var luachon = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Xác nhận thoát", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (luachon == DialogResult.No) e.Cancel = true;
        }
        private void menuQLPhongBan_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            foreach (var f in MdiChildren)
                if (f is QLPhongBan)
                {

                    f.Activate();

                    return;
                }
            var qlpb = new QLPhongBan
            {
                MdiParent = this
            };
            qlpb.Show();
        }
        private void menuQLTaiKhoan_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            foreach (var f in MdiChildren)
                if (f is QLTaiKhoan)
                {

                    f.Activate();

                    return;
                }
            var qltk = new QLTaiKhoan
            {
                MdiParent = this
            };
            qltk.Show();
        }
        private void menuQLLuong_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            foreach (var f in MdiChildren)
                if (f is QLLuong)
                {

                    f.Activate();

                    return;
                }
            var qll = new QLLuong
            {
                MdiParent = this
            };
            qll.Show();
        }
        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            label1.Parent = label2.Parent = label3.Parent = this;
            label1.BackColor = label2.BackColor = label3.BackColor = Color.Transparent;
        }
        private void GiaoDienChinh_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                if (notifyIcon1.Visible) return;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
        }
        private void menuBCLuong_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            foreach (var f in MdiChildren)
                if (f is ThongKeLuong)
                {

                    f.Activate();
                    f.WindowState = FormWindowState.Maximized;
                    f.Visible = true;
                    return;
                }
            var tkl = new ThongKeLuong
            {
                MdiParent = this
            };
            tkl.Show();
        }

        private void kếtNốiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CaiDat().ShowDialog();
        }

        private void lươngMặcĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Default().ShowDialog();
        }
    }
}