using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Quan_li_nhan_su
{
    public partial class QLTaiKhoan : Form
    {
        private int _index = -1;
        public QLTaiKhoan()
        {
            InitializeComponent();
        }
        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTaiKhoan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvTaiKhoan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void GetData()
        {
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvTaiKhoan.Visible = false;
            txtTenTK.Text = rtGhiChu.Text = txtMatKhau.Text = txtEmail.Text = "";
            txtTenTK.Enabled = true;
            chkDoiMK.Checked = true;
            chkDoiMK.Visible = false;
            cbChucVu.Enabled = true;
            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (s1, e1) =>
            {
                var table = KetNoi.GetData("select * from xemtk");
                var table2 = KetNoi.GetData("select MaNV, HoTen from HoSoNhanVien");
                e1.Result = new DataTable[] { table, table2 };
            };
            bw.RunWorkerCompleted += (s2, e2) =>
            {
                progressBar1.Visible = false;
                label14.Visible = false;
                if (e2.Error != null)
                {
                    MessageBox.Show("Có lỗi khi tải dữ liệu", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    var table_arr = e2.Result as DataTable[];
                    dgvTaiKhoan.DataSource = table_arr[0];
                    for (var i = 0; i < dgvTaiKhoan.Columns.Count; i++)
                        dgvTaiKhoan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    cbTenNV.DataSource = table_arr[1];
                    cbTenNV.DisplayMember = "HoTen";
                    cbTenNV.ValueMember = "MaNV";
                    cbTimTheoTenNV.DataSource = table_arr[1];
                    cbTimTheoTenNV.DisplayMember = "HoTen";
                    cbTimTheoTenNV.ValueMember = "MaNV";
                    dgvTaiKhoan.Columns[1].Visible = false;
                    dgvTaiKhoan.Refresh();
                }
                dgvTaiKhoan.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }
        private void dgvTaiKhoan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (var i = 0; i < dgvTaiKhoan.Rows.Count; i++)
                dgvTaiKhoan.Rows[i].HeaderCell.Value = (i + 1).ToString();
            dgvTaiKhoan.TopLeftHeaderCell.Value = $"Tổng: {dgvTaiKhoan.Rows.Count}";
            dgvTaiKhoan.ClearSelection();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cbTenNV.Enabled = true;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private void QLTaiKhoan_Shown(object sender, EventArgs e)
        {
            GetData();
        }
        private void chkDoiMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.Enabled
                = chkDoiMK.Checked;
        }
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            _index = e.RowIndex;
            if (dgvTaiKhoan.SelectedCells.Count != 0)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTenTK.Enabled = false;
                chkDoiMK.Checked = false;
                chkDoiMK.Visible = true;
                cbTenNV.Enabled = false;
                txtTenTK.Text = dgvTaiKhoan.Rows[_index].Cells[0].Value.ToString();
                cbChucVu.Text = dgvTaiKhoan.Rows[_index].Cells[2].Value.ToString();
                cbTenNV.Text = dgvTaiKhoan.Rows[_index].Cells[3].Value.ToString();
                txtEmail.Text = dgvTaiKhoan.Rows[_index].Cells[4].Value.ToString();
                rtGhiChu.Text = dgvTaiKhoan.Rows[_index].Cells[5].Value.ToString();
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                txtTenTK.Text = rtGhiChu.Text = txtMatKhau.Text = txtEmail.Text = "";
                txtTenTK.Enabled = true;
                chkDoiMK.Checked = true;
                chkDoiMK.Visible = false;
                cbTenNV.Enabled = true;
                cbTenNV.Text = "";
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenTK.Focus();
                return;
            }
            if (!Regex.IsMatch(txtTenTK.Text, @"^[A-Za-z][A-Za-z0-9_]{7,49}$"))
            {
                MessageBox.Show("Tên tài khoản phải bắt đầu bằng chữ cái latin, từ 8 - 50 kí tự, có thể bao gồm chữ cái latin, dấu gạch nối, gạch dưới và số tự nhiên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Cảnh báo", MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            if (!Regex.IsMatch(txtMatKhau.Text, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbTenNV.SelectedItem == null || cbTenNV.GetItemText(cbTenNV.SelectedItem) != cbTenNV.Text)
            {
                MessageBox.Show("Bạn phải chọn hoặc chọn 1 nhân viên sau khi nhập từ danh sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbChucVu.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn chức vụ", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cbChucVu.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ email", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenTK.Focus();
                return;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select count(*) from NguoiDung where TaiKhoan = @TaiKhoan"
                    })
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", txtTenTK.Text);
                        var dupplicator = (int)command.ExecuteScalar();
                        if (dupplicator > 0)
                        {
                            MessageBox.Show("Tên tài khoản này đã được sử dụng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select count(*) from NguoiDung where MaNV = @MaNV"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbTenNV.SelectedValue);
                        var dupplicator = (int)command.ExecuteScalar();
                        if (dupplicator > 0)
                        {
                            MessageBox.Show("Nhân viên này đã có tài khoản rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select count(*) from NguoiDung where Email = @Email"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        var dupplicator = (int)command.ExecuteScalar();
                        if (dupplicator > 0)
                        {
                            MessageBox.Show("Email này đã được sử dụng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "insert into NguoiDung values(@TaiKhoan, @MatKhau, @ChucVu, @MaNV, @Email, @LastOTPRequestTime, @GhiChu)"
                    })
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", txtTenTK.Text);
                        command.Parameters.AddWithValue("@MatKhau", DangNhap.GetMd5(txtMatKhau.Text));
                        command.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);
                        command.Parameters.AddWithValue("@MaNV", cbTenNV.SelectedValue);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@LastOTPRequestTime", DBNull.Value);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        var rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected == 1 ? "Thêm thành công" : "Thêm thất bại",
                            rowsAffected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                            rowsAffected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetData();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenTK.Focus();
                return;
            }
            if (!Regex.IsMatch(txtTenTK.Text, @"^[A-Za-z][A-Za-z0-9_]{7,49}$"))
            {
                MessageBox.Show("Tên tài khoản phải bắt đầu bằng chữ cái latin, từ 8 - 50 kí tự, có thể bao gồm chữ cái latin, dấu gạch nối, gạch dưới và số tự nhiên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (chkDoiMK.Checked)
            {
                if (txtMatKhau.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu", "Cảnh báo", MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtMatKhau.Text, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$"))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (cbChucVu.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn chức vụ", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cbChucVu.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ email", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenTK.Focus();
                return;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var luachon = MessageBox.Show("Bạn chắc chắn muốn sửa ?", "Xác nhận sửa", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (luachon != DialogResult.Yes) return;
            try
            {
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select count(*) from NguoiDung where Email = @Email and TaiKhoan != @TaiKhoan"
                    })
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@TaiKhoan", txtTenTK.Text);
                        var dupplicator = (int)command.ExecuteScalar();
                        if (dupplicator > 0)
                        {
                            MessageBox.Show("Email này đã được sử dụng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = chkDoiMK.Checked ? "update NguoiDung set MatKhau = @MatKhau, ChucVu = @ChucVu, Email = @Email, GhiChu = @GhiChu where TaiKhoan = @TaiKhoan" : "update NguoiDung set ChucVu = @ChucVu, Email = @Email, GhiChu = @GhiChu where TaiKhoan = @TaiKhoan"
                    })
                    {
                        command.Parameters.AddWithValue("@MatKhau", DangNhap.GetMd5(txtMatKhau.Text));
                        command.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@TaiKhoan", txtTenTK.Text);
                        var rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected == 1 ? "Sửa thành công" : "Sửa thất bại",
                            rowsAffected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                            rowsAffected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetData();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var luachon = MessageBox.Show("Bạn chắc chắn muốn xoá ?", "Xác nhận xoá", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (luachon != DialogResult.Yes) return;
            try
            {
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "delete from NguoiDung where TaiKhoan = @TaiKhoan"
                    })
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", dgvTaiKhoan.Rows[_index].Cells[0].Value);
                        var rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected == 1 ? "Xoá thành công" : "Xoá thất bại",
                            rowsAffected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                            rowsAffected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xoá thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;
            button1.BackgroundImage = txtMatKhau.UseSystemPasswordChar ? Properties.Resources.hide : Properties.Resources.show;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!chkTenNV.Checked && !chkChucVu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn cách nào để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (chkTenNV.Checked && (cbTimTheoTenNV.SelectedItem == null || cbTimTheoTenNV.GetItemText(cbTimTheoTenNV.SelectedItem) != cbTimTheoTenNV.Text))
            {
                MessageBox.Show("Bạn phải chọn hoặc chọn 1 nhân viên sau khi nhập từ danh sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (chkChucVu.Checked && cbTimTheoChucVu.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn chức vụ để tìm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvTaiKhoan.Visible = false;
            var x = cbTimTheoTenNV.SelectedValue;
            var y = cbTimTheoChucVu.Text;
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
                                   "select * from xemtk " +
                                   (chkTenNV.Checked && chkChucVu.Checked
                                       ? "where MaNV = @MaNV and [Chức vụ] = @ChucVu"
                                       : chkTenNV.Checked
                                           ? "where MaNV = @MaNV"
                                           : chkChucVu.Checked
                                               ? "where [Chức vụ] = @ChucVu"
                                               : "")
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", x);
                        command.Parameters.AddWithValue("@ChucVu", y);
                        using (var reader = command.ExecuteReader())
                        {
                            using (var dt = new DataTable())
                            {
                                dt.Load(reader);
                                e1.Result = dt;
                            }
                        }
                    }
                }
            };
            bw.RunWorkerCompleted += (s2, e2) =>
            {
                progressBar1.Visible = false;
                label14.Visible = false;
                if (e2.Error != null)
                    MessageBox.Show("Có lỗi khi tải dữ liệu", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    dgvTaiKhoan.DataSource = e2.Result as DataTable;
                dgvTaiKhoan.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }

        private void QLTaiKhoan_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}
