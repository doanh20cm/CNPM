using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
    public partial class QLBoPhan : Form
    {
        private int _index = -1;

        public QLBoPhan()
        {
            InitializeComponent();
        }

        private void QLBoPhan_Load(object sender, EventArgs e)
        {
            dgvBoPhan.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvBoPhan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvBoPhan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //GetData();
        }

        private void GetData()
        {
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvBoPhan.Visible = false;

            txtSDT.Text = rtGhiChu.Text = txtTenBoPhan.Text = "";
            dtpNgayThanhLap.Value = DateTime.Now;

            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            bw.DoWork += (s1, e1) =>
            {
                var table = KetNoi.GetData("select * from xemBoPhan");
                e1.Result = table;
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
                    dgvBoPhan.DataSource = e2.Result as DataTable;

                    for (var i = 0; i < dgvBoPhan.Columns.Count; i++)
                        dgvBoPhan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dgvBoPhan.Columns[0].HeaderText = "Mã bộ phận";
                    dgvBoPhan.Columns[1].HeaderText = "Tên bộ phận";
                    dgvBoPhan.Columns[2].HeaderText = "Ngày thành lập";
                    dgvBoPhan.Columns[3].HeaderText = "Số điện thoại";
                    dgvBoPhan.Columns[4].HeaderText = "Ghi chú";
                    dgvBoPhan.Columns[0].Visible = false;
                    dgvBoPhan.Refresh();
                }

                dgvBoPhan.Visible = true;
                Enabled = true;
            };

            bw.RunWorkerAsync();
        }

        private void dgvBoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            _index = e.RowIndex;
            if (dgvBoPhan.SelectedCells.Count != 0)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTenBoPhan.Text = dgvBoPhan.Rows[_index].Cells[1].Value.ToString();
                dtpNgayThanhLap.Value = (DateTime)dgvBoPhan.Rows[_index].Cells[2].Value;
                txtSDT.Text = dgvBoPhan.Rows[_index].Cells[3].Value.ToString();
                rtGhiChu.Text = dgvBoPhan.Rows[_index].Cells[4].Value.ToString();
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                txtSDT.Text = rtGhiChu.Text = txtTenBoPhan.Text = "";
                dtpNgayThanhLap.Value = DateTime.Now;
            }
        }

        private void dgvBoPhan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (var i = 0; i < dgvBoPhan.Rows.Count; i++)
                dgvBoPhan.Rows[i].HeaderCell.Value = (i + 1).ToString();
            dgvBoPhan.TopLeftHeaderCell.Value = $"Tổng: {dgvBoPhan.Rows.Count}";
            dgvBoPhan.ClearSelection();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenBoPhan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên bộ phận", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenBoPhan.Focus();
                return;
            }

            if (!int.TryParse(txtSDT.Text, out _) || txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
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
                        CommandText = "insert into BoPhan values(@TenBoPhan, @NgayThanhLap, @SDTBoPhan, @GhiChu)"
                    })
                    {
                        command.Parameters.AddWithValue("@TenBoPhan", txtTenBoPhan.Text);
                        command.Parameters.AddWithValue("@NgayThanhLap", dtpNgayThanhLap.Value.Date);
                        command.Parameters.AddWithValue("@SDTBoPhan", txtSDT.Text);
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
            if (txtTenBoPhan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên bộ phận", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenBoPhan.Focus();
                return;
            }

            if (!int.TryParse(txtSDT.Text, out _) || txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
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
                        CommandText =
                                   "update BoPhan set TenBoPhan = @TenBoPhan, NgayThanhLap = @NgayThanhLap, SDTBoPhan = @SDTBoPhan, GhiChu = @GhiChu where MaBoPhan = @MaBoPhan"
                    })
                    {
                        command.Parameters.AddWithValue("@TenBoPhan", txtTenBoPhan.Text);
                        command.Parameters.AddWithValue("@NgayThanhLap", dtpNgayThanhLap.Value.Date);
                        command.Parameters.AddWithValue("@SDTBoPhan", txtSDT.Text);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@MaBoPhan", dgvBoPhan.Rows[_index].Cells[0].Value);
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
                        CommandText = "delete from BoPhan where MaBoPhan = @MaBoPhan"
                    })
                    {
                        command.Parameters.AddWithValue("@MaBoPhan", dgvBoPhan.Rows[_index].Cells[0].Value);
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!chkTimTen.Checked && !chkTimTruoc.Checked && !chkTimSau.Checked)
            {
                MessageBox.Show("Bạn chưa chọn cách nào để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (chkTimTen.Checked && txtTimTen.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên bộ phận để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (chkTimTruoc.Checked && chkTimSau.Checked && dtpTimTruoc.Value.Date < dtpTimSau.Value.Date)
            {
                MessageBox.Show("Ngày tìm trước phải lớn hơn ngày tìm sau", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvBoPhan.Visible = false;

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
                                   "select * from xemBoPhan " +
                                   (chkTimTen.Checked && chkTimTruoc.Checked && chkTimSau.Checked
                                       ? "where TenBoPhan like @TenBoPhan and NgayThanhLap <= @NgayTruoc and NgayThanhLap >= @NgaySau"
                                       : chkTimTen.Checked && chkTimTruoc.Checked
                                           ? "where TenBoPhan like @TenBoPhan and NgayThanhLap <= @NgayTruoc"
                                           : chkTimTen.Checked && chkTimSau.Checked
                                               ? "where TenBoPhan like @TenBoPhan and NgayThanhLap >= @NgaySau"
                                               : chkTimTruoc.Checked && chkTimSau.Checked
                                                   ? "where NgayThanhLap <= @NgayTruoc and NgayThanhLap >= @NgaySau"
                                                   : chkTimTen.Checked
                                                       ? "where TenBoPhan like @TenBoPhan"
                                                       : chkTimTruoc.Checked
                                                           ? "where NgayThanhLap <= @NgayTruoc"
                                                           : chkTimSau.Checked
                                                               ? "where NgayThanhLap >= @NgaySau"
                                                               : "")
                    })
                    {
                        command.Parameters.AddWithValue("@TenBoPhan", $"%{txtTimTen.Text}%");
                        command.Parameters.AddWithValue("@NgayTruoc", dtpTimTruoc.Value.Date);
                        command.Parameters.AddWithValue("@NgaySau", dtpTimSau.Value.Date);
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
                    dgvBoPhan.DataSource = e2.Result as DataTable;

                dgvBoPhan.Visible = true;
                Enabled = true;
            };

            bw.RunWorkerAsync();
        }

        private void QLBoPhan_Shown(object sender, EventArgs e)
        {
            GetData();
        }
    }
}