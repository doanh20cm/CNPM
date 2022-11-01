using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
    public partial class QLNhanVienPhongBan : Form
    {
        private const string Sqlconnectstring = "Server=localhost\\SQLEXPRESS,1433;Database=test2;UID=sa;PWD=12345";

        private int _index = -1;

        public QLNhanVienPhongBan()
        {
            InitializeComponent();
        }


        private void QLNhanVienPhongBan_Load(object sender, EventArgs e)
        {
            dgvNhanVienPhongBan.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvNhanVienPhongBan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            GetData();
        }

        private void GetData()
        {
            dgvNhanVienPhongBan.DataSource = KetNoi.GetData(
                "select NhanVienPhongBan.MaNV, HoTen, NhanVienPhongBan.MaPhongBan, TenPhongBan, LoaiHD, NgayKy, NgayHetHan, ThoiGian, NhanVienPhongBan.GhiChu from NhanVienPhongBan, HoSoNhanVien, PhongBan where NhanVienPhongBan.MaNV = HoSoNhanVien.MaNV and PhongBan.MaPhongBan = NhanVienPhongBan.MaPhongBan");
            for (var i = 0; i < dgvNhanVienPhongBan.Columns.Count; i++)
                dgvNhanVienPhongBan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvNhanVienPhongBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanVienPhongBan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

            cbHoTenNV.DataSource = KetNoi.GetData("select MaNV, HoTen from HoSoNhanVien");
            cbHoTenNV.DisplayMember = "HoTen";
            cbHoTenNV.ValueMember = "MaNV";

            cbTenPhongBan.DataSource = KetNoi.GetData("select MaPhongBan, TenPhongBan from PhongBan");
            cbTenPhongBan.DisplayMember = "TenPhongBan";
            cbTenPhongBan.ValueMember = "MaPhongBan";

            cbTimTenPhongBan.DataSource = cbTenPhongBan.DataSource;
            cbTimTenPhongBan.DisplayMember = "TenPhongBan";
            cbTimTenPhongBan.ValueMember = "MaPhongBan";

            dgvNhanVienPhongBan.Columns[0].Visible = false;
            dgvNhanVienPhongBan.Columns[2].Visible = false;
            cbHoTenNV.Enabled = true;

            cbHoTenNV.Text = cbTenPhongBan.Text = txtLoaiHopDong.Text = txtThoiGian.Text = rtGhiChu.Text = "";
            dtpNgayKy.Value = dtpNgayHetHan.Value = DateTime.Now;
            cbHoTenNV.Enabled = true;
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
                using (var connection = new SqlConnection(Sqlconnectstring))
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
            _index = e.RowIndex;
            if (_index > -1 && dgvNhanVienPhongBan.SelectedCells.Count != 0)
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
            if (_index < 0 || dgvNhanVienPhongBan.SelectedCells.Count == 0)
            {
                MessageBox.Show("Chưa chọn dòng nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                using (var connection = new SqlConnection(Sqlconnectstring))
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
            if (_index < 0 || dgvNhanVienPhongBan.SelectedCells.Count == 0)
            {
                MessageBox.Show("Chưa chọn dòng nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var luachon = MessageBox.Show("Bạn chắc chắn muốn xoá ?", "Xác nhận xoá", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (luachon != DialogResult.Yes) return;
            try
            {
                using (var connection = new SqlConnection(Sqlconnectstring))
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
                GetData();
            }
            catch (Exception)
            {
                MessageBox.Show("Xoá thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVienPhongBan_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dgvNhanVienPhongBan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
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

            try
            {
                using (var connection = new SqlConnection(Sqlconnectstring))
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
                                dgvNhanVienPhongBan.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tìm kiếm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GetData();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}