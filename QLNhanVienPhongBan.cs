﻿using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Quan_li_nhan_su
{
    public partial class QLNhanVienPhongBan : Form
    {
        private int _index = -1;
        public QLNhanVienPhongBan()
        {
            InitializeComponent();
        }
        private void QLNhanVienPhongBan_Load(object sender, EventArgs e)
        {
            dgvNhanVienPhongBan.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvNhanVienPhongBan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvNhanVienPhongBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanVienPhongBan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            dgvNhanVienPhongBan.Visible = false;
            cbHoTenNV.Text = cbTenPhongBan.Text = txtLoaiHopDong.Text = txtThoiGian.Text = rtGhiChu.Text = "";
            dtpNgayKy.Value = dtpNgayHetHan.Value = DateTime.Now;
            cbHoTenNV.Enabled = true;
            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (s1, e1) =>
            {
                var table = KetNoi.GetData(
                    "select NhanVienPhongBan.MaNV, HoTen, NhanVienPhongBan.MaPhongBan, TenPhongBan, LoaiHD, NgayKy, NgayHetHan, ThoiGian, NhanVienPhongBan.GhiChu from NhanVienPhongBan, HoSoNhanVien, PhongBan where NhanVienPhongBan.MaNV = HoSoNhanVien.MaNV and PhongBan.MaPhongBan = NhanVienPhongBan.MaPhongBan");
                var tbTenNv = KetNoi.GetData("select MaNV, HoTen from HoSoNhanVien");
                var tbTenPhongBan = KetNoi.GetData("select MaPhongBan, TenPhongBan from PhongBan");
                e1.Result = new[] { table, tbTenNv, tbTenPhongBan };
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
                    var tbArr = (DataTable[])e2.Result;
                    dgvNhanVienPhongBan.DataSource = tbArr[0];
                    for (var i = 0; i < dgvNhanVienPhongBan.Columns.Count; i++)
                        dgvNhanVienPhongBan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvNhanVienPhongBan.Columns[0].HeaderText = "Mã nhân viên";
                    dgvNhanVienPhongBan.Columns[1].HeaderText = "Tên nhân viên";
                    dgvNhanVienPhongBan.Columns[2].HeaderText = "Mã phòng ban";
                    dgvNhanVienPhongBan.Columns[3].HeaderText = "Tên phòng ban";
                    dgvNhanVienPhongBan.Columns[4].HeaderText = "Loại hợp đồng";
                    dgvNhanVienPhongBan.Columns[5].HeaderText = "Ngày ký";
                    dgvNhanVienPhongBan.Columns[6].HeaderText = "Ngày hết hạn";
                    dgvNhanVienPhongBan.Columns[7].HeaderText = "Thời gian";
                    dgvNhanVienPhongBan.Columns[8].HeaderText = "Ghi chú";
                    dgvNhanVienPhongBan.Refresh();
                    cbHoTenNV.DataSource = tbArr[1];
                    cbHoTenNV.DisplayMember = "HoTen";
                    cbHoTenNV.ValueMember = "MaNV";
                    cbTenPhongBan.DataSource = tbArr[2];
                    cbTenPhongBan.DisplayMember = "TenPhongBan";
                    cbTenPhongBan.ValueMember = "MaPhongBan";
                    cbTimTenPhongBan.DataSource = tbArr[2];
                    cbTimTenPhongBan.DisplayMember = "TenPhongBan";
                    cbTimTenPhongBan.ValueMember = "MaPhongBan";
                    dgvNhanVienPhongBan.Columns[0].Visible = false;
                    dgvNhanVienPhongBan.Columns[2].Visible = false;
                    cbHoTenNV.Enabled = true;
                }
                dgvNhanVienPhongBan.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLoaiHopDong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập loại hợp đồng", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLoaiHopDong.Focus();
                return;
            }
            if (txtThoiGian.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập thời gian", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThoiGian.Focus();
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
                        CommandText =
                                   "insert into NhanVienPhongBan values(@MaNV, @MaPhongBan, @LoaiHD, @NgayKy, @NgayHetHan, @ThoiGian, @GhiChu)"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbHoTenNV.SelectedValue);
                        command.Parameters.AddWithValue("@MaPhongBan", cbTenPhongBan.SelectedValue);
                        command.Parameters.AddWithValue("@LoaiHD", txtLoaiHopDong.Text);
                        command.Parameters.AddWithValue("@NgayKy", dtpNgayKy.Value.Date);
                        command.Parameters.AddWithValue("@NgayHetHan", dtpNgayHetHan.Value.Date);
                        command.Parameters.AddWithValue("@ThoiGian", txtThoiGian.Text);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        var rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected == 1 ? "Thêm thành công" : "Thêm thất bại",
                            rowsAffected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                            rowsAffected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                var isDuplicated = ex.Message.Contains("Cannot insert duplicate key in object");
                MessageBox.Show(isDuplicated ? "Nhân viên đó đã ở trong phòng ban" : "Thêm thất bại", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetData();
        }
        private void dgvNhanVienPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            _index = e.RowIndex;
            if (dgvNhanVienPhongBan.SelectedCells.Count != 0)
            {
                button1.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                cbHoTenNV.Text = dgvNhanVienPhongBan.Rows[_index].Cells[1].Value.ToString();
                cbTenPhongBan.Text = dgvNhanVienPhongBan.Rows[_index].Cells[3].Value.ToString();
                txtLoaiHopDong.Text = dgvNhanVienPhongBan.Rows[_index].Cells[4].Value.ToString();
                dtpNgayKy.Value = (DateTime)dgvNhanVienPhongBan.Rows[_index].Cells[5].Value;
                dtpNgayHetHan.Value = (DateTime)dgvNhanVienPhongBan.Rows[_index].Cells[6].Value;
                txtThoiGian.Text = dgvNhanVienPhongBan.Rows[_index].Cells[7].Value.ToString();
                rtGhiChu.Text = dgvNhanVienPhongBan.Rows[_index].Cells[8].Value.ToString();
                cbHoTenNV.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                cbHoTenNV.Text = cbTenPhongBan.Text = txtLoaiHopDong.Text = txtThoiGian.Text = rtGhiChu.Text = "";
                dtpNgayKy.Value = dtpNgayHetHan.Value = DateTime.Now;
                cbHoTenNV.Enabled = true;
                dgvNhanVienPhongBan.ClearSelection();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtLoaiHopDong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập loại hợp đồng", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLoaiHopDong.Focus();
                return;
            }
            if (txtThoiGian.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập thời gian", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThoiGian.Focus();
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
                                   "update NhanVienPhongBan set MaPhongBan = @MaPhongBan, LoaiHD = @LoaiHD, NgayKy = @NgayKy, NgayHetHan = @NgayHetHan, ThoiGian = @ThoiGian, GhiChu = @GhiChu where MaNV = @MaNV"
                    })
                    {
                        command.Parameters.AddWithValue("@MaPhongBan", cbTenPhongBan.SelectedValue);
                        command.Parameters.AddWithValue("@LoaiHD", txtLoaiHopDong.Text);
                        command.Parameters.AddWithValue("@NgayKy", dtpNgayKy.Value.Date);
                        command.Parameters.AddWithValue("@NgayHetHan", dtpNgayHetHan.Value.Date);
                        command.Parameters.AddWithValue("@ThoiGian", txtThoiGian.Text);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@MaNV", cbHoTenNV.SelectedValue);
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
                        CommandText = "delete from NhanVienPhongBan where MaNV = @MaNV"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbHoTenNV.SelectedValue);
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
        private void dgvNhanVienPhongBan_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void dgvNhanVienPhongBan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (var i = 0; i < dgvNhanVienPhongBan.Rows.Count; i++)
                dgvNhanVienPhongBan.Rows[i].HeaderCell.Value = (i + 1).ToString();
            dgvNhanVienPhongBan.TopLeftHeaderCell.Value = $"Tống: {dgvNhanVienPhongBan.RowCount}";
            dgvNhanVienPhongBan.Rows[dgvNhanVienPhongBan.Rows.Count - 1].HeaderCell.Value =
                dgvNhanVienPhongBan.Rows.Count.ToString();
            dgvNhanVienPhongBan.ClearSelection();
            button1.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!chkTenHopDong.Checked && !chkTheoTenPhongBan.Checked)
            {
                MessageBox.Show("Bạn chưa chọn cách nào để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (chkTenHopDong.Checked && txtTimTenHopDong.Text?.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập loại hợp đồng để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvNhanVienPhongBan.Visible = false;
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
                                   "select NhanVienPhongBan.MaNV, HoTen, NhanVienPhongBan.MaPhongBan, TenPhongBan, LoaiHD, NgayKy, NgayHetHan, ThoiGian, NhanVienPhongBan.GhiChu from NhanVienPhongBan, HoSoNhanVien, PhongBan where NhanVienPhongBan.MaNV = HoSoNhanVien.MaNV and PhongBan.MaPhongBan = NhanVienPhongBan.MaPhongBan " +
                                   (chkTenHopDong.Checked && chkTheoTenPhongBan.Checked
                                       ? "and NhanVienPhongBan.MaPhongBan = @MaPhongBan and LoaiHD like @LoaiHD"
                                       : chkTheoTenPhongBan.Checked
                                           ? "and NhanVienPhongBan.MaPhongBan = @MaPhongBan"
                                           : chkTenHopDong.Checked
                                               ? "and LoaiHD like @LoaiHD"
                                               : "")
                    })
                    {
                        command.Parameters.AddWithValue("@MaPhongBan", cbTimTenPhongBan.SelectedValue);
                        command.Parameters.AddWithValue("@LoaiHD", $"%{txtTimTenHopDong.Text}%");
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
                    dgvNhanVienPhongBan.DataSource = e2.Result as DataTable;
                dgvNhanVienPhongBan.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private void QLNhanVienPhongBan_Shown(object sender, EventArgs e)
        {
            GetData();
        }
    }
}