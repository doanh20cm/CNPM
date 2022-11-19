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
                    dgvTaiKhoan.DataSource = e2.Result as DataTable;

                    for (var i = 0; i < dgvTaiKhoan.Columns.Count; i++)
                        dgvTaiKhoan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                txtTenTK.Text = dgvTaiKhoan.Rows[_index].Cells[0].Value.ToString();
                cbChucVu.Text = dgvTaiKhoan.Rows[_index].Cells[2].Value.ToString();
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
                MessageBox.Show("Tên tài khoản không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkDoiMK.Checked && txtTenTK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtMatKhau.Focus();
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

            // check vaild email using regex
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
                        CommandText = "insert into NguoiDung values(@TenBoPhan, @NgayThanhLap, @SDTBoPhan, @GhiChu)"
                    })
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", txtTenTK.Text);
                        command.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        command.Parameters.AddWithValue("@ChucVu", cbChucVu.Text);
                        command.Parameters.AddWithValue("@MaNV", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@Email", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@OTP", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@LastOTPRequestTime", rtGhiChu.Text);
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
    }
}
