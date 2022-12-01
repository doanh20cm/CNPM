using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Quan_li_nhan_su
{
    public partial class DangNhap : Form
    {
        private static List<string> _savedUsers = new List<string>();
        private static int otp;
        private static int wrong_otp_count = 0;

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
        public DangNhap()
        {
            InitializeComponent();
        }
        public static string GetMd5(string pass)
        {
            using (var hash = MD5.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass)).Select(x => x.ToString("x2")));
            }
        }
        private static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        private static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return binForm.Deserialize(memStream);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var taikhoan = comboBox1.Text.Trim();
            var matkhau = txtPassword.Text.Trim();
            if (taikhoan.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }
            if (matkhau.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (!Regex.IsMatch(taikhoan, @"^[A-Za-z][A-Za-z0-9_]{7,49}$"))
            {
                MessageBox.Show("Tài khoản không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }
            Enabled = false;
            progressBar1.Visible = true;
            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (s1, e1) =>
            {
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText =
                                   "select ChucVu, TaiKhoan from NguoiDung where TaiKhoan = @TaiKhoan and MatKhau = @MatKhau"
                    })
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                        command.Parameters.AddWithValue("@MatKhau", GetMd5(matkhau));
                        using (var reader = command.ExecuteReader())
                        {
                            var quyen = new DataTable();
                            quyen.Load(reader);
                            e1.Result = quyen;
                        }
                    }
                }
            };
            bw.RunWorkerCompleted += (s2, e2) =>
            {
                Enabled = true;
                progressBar1.Visible = false;
                if (e2.Error != null)
                {
                    MessageBox.Show("Không thể kết nối đến máy chủ, hãy liên hệ IT công ty", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var quyen = e2.Result as DataTable;
                    if (quyen?.Rows.Count != 1)
                    {
                        MessageBox.Show("Tài khoản không tồn tại hoặc sai mật khẩu", "Lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    GiaoDienChinh.Chucvu = quyen.Rows[0][0].ToString();
                    GiaoDienChinh.Username = quyen.Rows[0][1].ToString();
                    Visible = false;
                    MessageBox.Show($"Chào {quyen.Rows[0][1]}, đăng nhập thành công với quyền {quyen.Rows[0][0]}!",
                        "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_savedUsers.Contains(taikhoan)) return;
                    var wantToSave = MessageBox.Show("Bạn có muốn lưu tài khoản này không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (wantToSave == DialogResult.Yes)
                        try
                        {
                            _savedUsers.Add(taikhoan);
                            var save = ObjectToByteArray(_savedUsers);
                            File.WriteAllBytes("save.bin", save);
                            comboBox1.DataSource = new BindingSource(_savedUsers, null);
                            comboBox1.DisplayMember = "Key";
                            MessageBox.Show("Lưu tài khoản thành công!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Có lỗi khi lưu tài khoản", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    Close();
                }
            };
            bw.RunWorkerAsync();
        }
        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            GC.Collect();
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            if (!File.Exists("save.bin")) return;
            try
            {
                var saved = ByteArrayToObject(File.ReadAllBytes("save.bin"));
                _savedUsers = saved as List<string>;
                comboBox1.DataSource = new BindingSource(_savedUsers, null);
                comboBox1.DisplayMember = "Key";
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi tải tài khoản đã lưu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoveSaved_Click(object sender, EventArgs e)
        {
            if (!_savedUsers.Contains(comboBox1.Text))
            {
                MessageBox.Show("Tài khoản này không trong danh sách đã lưu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var wantToRemove = MessageBox.Show("Bạn có muốn bỏ lưu tài khoản này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (wantToRemove != DialogResult.Yes) return;
            try
            {
                _savedUsers.Remove(comboBox1.Text);
                var save = ObjectToByteArray(_savedUsers);
                File.WriteAllBytes("save.bin", save);
                comboBox1.DataSource = new BindingSource(_savedUsers, null);
                comboBox1.DisplayMember = "Key";
                comboBox1.Text = "";
                MessageBox.Show("Tài khoản này đã được xoá khỏi danh sách đã lưu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_savedUsers.Count == 0)
            {
                MessageBox.Show("Không có tài khoản nào được lưu", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var wantToRemove = MessageBox.Show("Bạn có muốn xoá tất cả tài khoản đã lưu không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (wantToRemove != DialogResult.Yes) return;
            try
            {
                _savedUsers.Clear();
                var save = ObjectToByteArray(_savedUsers);
                File.WriteAllBytes("save.bin", save);
                comboBox1.DataSource = new BindingSource(_savedUsers, null);
                comboBox1.DisplayMember = "Key";
                comboBox1.Text = "";
                MessageBox.Show("Tất cả tài khoản đã được xoá khỏi danh sách đã lưu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            button2.BackgroundImage = txtPassword.UseSystemPasswordChar ? Properties.Resources.hide : Properties.Resources.show;
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            btnBack.Visible = true;
            btnForgot.Visible = false;
            ShowHide(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnForgot.Visible = true;
            btnBack.Visible = false;
            ShowHide(true);
        }

        private void ShowHide(bool b)
        {
            label1.Visible = label2.Visible = comboBox1.Visible = btnRemoveSaved.Visible = button1.Visible = txtPassword.Visible = button2.Visible = btnLogin.Visible = b;
            txtOTP.Visible = txtEmail.Visible = btnCheckOTP.Visible = btnRequestOTP.Visible = label3.Visible = label4.Visible = btnDoiMatKhau.Visible = txtMatKhauMoi.Visible = label5.Visible = !b;
        }

        private void ResetState()
        {
            txtOTP.Enabled = btnCheckOTP.Enabled = false;
            txtEmail.Enabled = btnRequestOTP.Enabled = true;
            txtMatKhauMoi.Enabled = btnDoiMatKhau.Enabled = false;
            txtEmail.Text = txtOTP.Text = txtMatKhauMoi.Text = "";
            wrong_otp_count = 0;
        }

        private void btnRequestOTP_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ email", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            Enabled = false;
            progressBar1.Visible = true;
            var bw = new BackgroundWorker();
            bw.DoWork += (s1, e1) =>
            {
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select count(*) from NguoiDung where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        if ((int)command.ExecuteScalar() != 1)
                        {
                            MessageBox.Show("Email không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "SELECT TaiKhoan FROM NguoiDung WHERE DATEDIFF(MINUTE, LastOTPRequestTime, GETDATE()) > 15 and Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        if (command.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Bạn phải chờ 15 phút để yêu cầu lại mã OTP", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                            return;
                        }
                    }
                }
                otp = new Random().Next(000000, 999999);
                using (var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("doanhidm1@gmail.com", "fuekddbixngkafsw"),
                    EnableSsl = true,
                }) using (var mm = new MailMessage()
                {
                    From = new MailAddress("doanhidm1@gmail.com"),
                    Subject = "Yêu cầu đặt lại mật khẩu",
                    Body = $"OTP đặt lại mật khẩu là: {otp}",
                    To = { new MailAddress(txtEmail.Text) }
                })
                {
                    smtpClient.Send(mm);
                }
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "update NguoiDung set LastOTPRequestTime = GETDATE() where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        if (command.ExecuteNonQuery() != 1)
                        {
                            MessageBox.Show("Có lỗi khi hoàn tất yêu cầu OTP", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetState();
                            throw new Exception();
                            return;
                        }
                    }
                }
            };
            bw.RunWorkerCompleted += (s2, e2) =>
            {
                Enabled = true;
                progressBar1.Visible = false;
                if (e2.Error != null)
                {
                    MessageBox.Show("Đã có lỗi xảy ra trong quá trình yêu cầu OTP", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtOTP.Enabled = btnCheckOTP.Enabled = true;
                    txtEmail.Enabled = btnRequestOTP.Enabled = false;
                }
            };
            bw.RunWorkerAsync();
        }

        private void btnCheckOTP_Click(object sender, EventArgs e)
        {
            Enabled = false;
            progressBar1.Visible = true;
            var bw = new BackgroundWorker();
            bw.DoWork += (s1, e1) =>
            {
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select count(*) from NguoiDung where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        if ((int)command.ExecuteScalar() != 1)
                        {
                            MessageBox.Show("Email không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select DATEDIFF(MINUTE, LastOTPRequestTime, GETDATE()) from NguoiDung where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        if ((int)command.ExecuteScalar() > 15)
                        {
                            MessageBox.Show("OTP đã hết hạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                            return;
                        }
                    }
                }
            };
            bw.RunWorkerCompleted += (s2, e2) =>
            {
                Enabled = true;
                progressBar1.Visible = false;
                if (e2.Error != null)
                {
                    ResetState();
                    MessageBox.Show("Đã có lỗi xảy ra trong quá trình kiểm tra OTP", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtOTP.Text != otp.ToString())
                    {
                        MessageBox.Show("OTP không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        wrong_otp_count++;
                        if (wrong_otp_count > 5)
                        {
                            MessageBox.Show("Bạn đã nhập sai OTP quá 5 lần", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetState();
                            return;
                        }
                        return;
                    }
                    txtMatKhauMoi.Enabled = btnDoiMatKhau.Enabled = true;
                    txtOTP.Enabled = btnCheckOTP.Enabled = false;
                }
            };
            bw.RunWorkerAsync();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới", "Cảnh báo", MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }
            if (!Regex.IsMatch(txtMatKhauMoi.Text, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Enabled = false;
            progressBar1.Visible = true;
            var bw = new BackgroundWorker();
            bw.DoWork += (s1, e1) =>
            {
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select count(*) from NguoiDung where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        if ((int)command.ExecuteScalar() != 1)
                        {
                            MessageBox.Show("Email không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select DATEDIFF(MINUTE, LastOTPRequestTime, GETDATE()) from NguoiDung where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        if ((int)command.ExecuteScalar() > 15)
                        {
                            MessageBox.Show("OTP đã hết hạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "update NguoiDung set MatKhau = @MatKhau where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@MatKhau", GetMd5(txtMatKhauMoi.Text));
                        if (command.ExecuteNonQuery() != 1)
                        {
                            MessageBox.Show("Không thể hoàn tất việc đổi mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception();
                        }
                    }
                }
            };
            bw.RunWorkerCompleted += (s2, e2) =>
            {
                Enabled = true;
                progressBar1.Visible = false;
                ResetState();
                if (e2.Error != null)
                {
                    ResetState();
                    MessageBox.Show("Đã có lỗi xảy ra trong quá trình đổi mật khẩu", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            bw.RunWorkerAsync();
        }
    }
}