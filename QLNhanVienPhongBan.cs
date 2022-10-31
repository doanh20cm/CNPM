using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
    public partial class QLNhanVienPhongBan : Form
    {
        public QLNhanVienPhongBan()
        {
            InitializeComponent();
        }

        readonly KetNoi _kn = new KetNoi();
        int index = -1;
        const string sqlconnectstring = "Server=localhost\\SQLEXPRESS,1433;Database=test2;UID=sa;PWD=12345";


        private void QLNhanVienPhongBan_Load(object sender, EventArgs e)
        {
            dgvNhanVienPhongBan.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvNhanVienPhongBan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            GetData();
        }

        private void GetData()
        {
            dgvNhanVienPhongBan.DataSource = _kn.GetData("select NhanVienPhongBan.MaNV, HoTen, NhanVienPhongBan.MaPhongBan, TenPhongBan, LoaiHD, NgayKy, NgayHetHan, ThoiGian, NhanVienPhongBan.GhiChu from NhanVienPhongBan, HoSoNhanVien, PhongBan where NhanVienPhongBan.MaNV = HoSoNhanVien.MaNV and PhongBan.MaPhongBan = NhanVienPhongBan.MaPhongBan");
            for (int i = 0; i < dgvNhanVienPhongBan.Columns.Count; i++)
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

            cbHoTenNV.DataSource = _kn.GetData("select MaNV, HoTen from HoSoNhanVien");
            cbHoTenNV.DisplayMember = "HoTen";
            cbHoTenNV.ValueMember = "MaNV";

            cbTenPhongBan.DataSource = _kn.GetData("select MaPhongBan, TenPhongBan from PhongBan");
            cbTenPhongBan.DisplayMember = "TenPhongBan";
            cbTenPhongBan.ValueMember = "MaPhongBan";

            dgvNhanVienPhongBan.Columns[0].Visible = false;
            dgvNhanVienPhongBan.Columns[2].Visible = false;     
            cbHoTenNV.Enabled = true;

            cbHoTenNV.Text = cbTenPhongBan.Text = txtLoaiHopDong.Text = txtThoiGian.Text = rtGhiChu.Text = "";
            dtpNgayKy.Value = dtpNgayHetHan.Value = DateTime.Now;
            cbHoTenNV.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLoaiHopDong.Text.Trim()?.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập loại hợp đồng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiHopDong.Focus();
                return;
            }
            if (txtThoiGian.Text.Trim()?.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập thời gian", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThoiGian.Focus();
                return;
            }
            try
            {
                using (var connection = new SqlConnection(sqlconnectstring))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "insert into NhanVienPhongBan values(@MaNV, @MaPhongBan, @LoaiHD, @NgayKy, @NgayHetHan, @ThoiGian, @GhiChu)"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbHoTenNV.SelectedValue);
                        command.Parameters.AddWithValue("@MaPhongBan", cbTenPhongBan.SelectedValue);
                        command.Parameters.AddWithValue("@LoaiHD", txtLoaiHopDong.Text);
                        command.Parameters.AddWithValue("@NgayKy", dtpNgayKy.Value.Date);
                        command.Parameters.AddWithValue("@NgayHetHan", dtpNgayHetHan.Value.Date);
                        command.Parameters.AddWithValue("@ThoiGian", txtThoiGian.Text);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        var rows_affected = command.ExecuteNonQuery();
                        MessageBox.Show(rows_affected == 1 ? "Thêm thành công" : "Thêm thất bại", rows_affected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, rows_affected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                var IsDuplicated = ex.Message.Contains("Cannot insert duplicate key in object");
                MessageBox.Show(IsDuplicated ? "Nhân viên đó đã ở trong phòng ban" : "Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetData();
        }

        private void dgvNhanVienPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index > -1 && dgvNhanVienPhongBan.SelectedCells.Count != 0)
            {
                button1.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                cbHoTenNV.Text = dgvNhanVienPhongBan.Rows[index].Cells[1].Value.ToString();
                cbTenPhongBan.Text = dgvNhanVienPhongBan.Rows[index].Cells[3].Value.ToString();
                txtLoaiHopDong.Text = dgvNhanVienPhongBan.Rows[index].Cells[4].Value.ToString();
                dtpNgayKy.Value = (DateTime)dgvNhanVienPhongBan.Rows[index].Cells[5].Value;
                dtpNgayHetHan.Value = (DateTime)dgvNhanVienPhongBan.Rows[index].Cells[6].Value;
                txtThoiGian.Text = dgvNhanVienPhongBan.Rows[index].Cells[7].Value.ToString();
                rtGhiChu.Text = dgvNhanVienPhongBan.Rows[index].Cells[8].Value.ToString();
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
            if (index < 0 || dgvNhanVienPhongBan.SelectedCells.Count == 0)
            {
                MessageBox.Show("Chưa chọn dòng nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtLoaiHopDong.Text.Trim()?.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập loại hợp đồng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiHopDong.Focus();
                return;
            }
            if (txtThoiGian.Text.Trim()?.Length == 0)
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
                using (var connection = new SqlConnection(sqlconnectstring))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "update NhanVienPhongBan set MaPhongBan = @MaPhongBan, LoaiHD = @LoaiHD, NgayKy = @NgayKy, NgayHetHan = @NgayHetHan, ThoiGian = @ThoiGian, GhiChu = @GhiChu where MaNV = @MaNV"
                    })
                    {
                        command.Parameters.AddWithValue("@MaPhongBan", cbTenPhongBan.SelectedValue);
                        command.Parameters.AddWithValue("@LoaiHD", txtLoaiHopDong.Text);
                        command.Parameters.AddWithValue("@NgayKy", dtpNgayKy.Value.Date);
                        command.Parameters.AddWithValue("@NgayHetHan", dtpNgayHetHan.Value.Date);
                        command.Parameters.AddWithValue("@ThoiGian", txtThoiGian.Text);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@MaNV", cbHoTenNV.SelectedValue);
                        var rows_affected = command.ExecuteNonQuery();
                        MessageBox.Show(rows_affected == 1 ? "Sửa thành công" : "Sửa thất bại", rows_affected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, rows_affected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
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
            if (index < 0 || dgvNhanVienPhongBan.SelectedCells.Count == 0)
            {
                MessageBox.Show("Chưa chọn dòng nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var luachon = MessageBox.Show("Bạn chắc chắn muốn xoá ?", "Xác nhận xoá", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (luachon != DialogResult.Yes) return;
            try
            {
                using (var connection = new SqlConnection(sqlconnectstring))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "delete from NhanVienPhongBan where MaNV = @MaNV"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbHoTenNV.SelectedValue);
                        var rows_affected = command.ExecuteNonQuery();
                        MessageBox.Show(rows_affected == 1 ? "Xoá thành công" : "Xoá thất bại", rows_affected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, rows_affected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
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
    }
}
