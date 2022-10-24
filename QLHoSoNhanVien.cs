using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
	public partial class QLHoSoNhanVien : Form
	{
		KetNoi _kn = new KetNoi();
		private int index = -1;

		public QLHoSoNhanVien()
		{
			InitializeComponent();
		}

		private void GetData()
        {
			dgvHoSoNhanVien.DataSource = _kn.GetData("select * from HoSoNhanVien");
			for (int i = 0; i < dgvHoSoNhanVien.Columns.Count; i++)
				dgvHoSoNhanVien.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			dgvHoSoNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvHoSoNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvHoSoNhanVien.Columns[0].HeaderText = "Mã nhân viên";
			dgvHoSoNhanVien.Columns[1].HeaderText = "Họ và tên";
			dgvHoSoNhanVien.Columns[2].HeaderText = "Ngày sinh";
			dgvHoSoNhanVien.Columns[3].HeaderText = "Nơi sinh";
			dgvHoSoNhanVien.Columns[4].HeaderText = "Địa chỉ";
			dgvHoSoNhanVien.Columns[5].HeaderText = "Số điện thoại";
			dgvHoSoNhanVien.Columns[6].HeaderText = "Giới tính";
			dgvHoSoNhanVien.Columns[7].HeaderText = "Dân tộc";
			dgvHoSoNhanVien.Columns[8].HeaderText = "Tôn giáo";
			dgvHoSoNhanVien.Columns[9].HeaderText = "Học vấn";
			dgvHoSoNhanVien.Columns[10].HeaderText = "Ghi chú";
			cbGioiTinh.Text = "Nam";
			dgvHoSoNhanVien.Refresh();
        }

        private void QLHoSoNhanVien_Load(object sender, System.EventArgs e)
        {
			GetData();
        }

        private void dgvHoSoNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			index = e.RowIndex;
			if (index > -1 && dgvHoSoNhanVien.SelectedCells.Count != 0)
			{
				txtHoTen.Text = dgvHoSoNhanVien.Rows[index].Cells[1].Value.ToString();
				dtpNgaySinh.Value = (DateTime) dgvHoSoNhanVien.Rows[index].Cells[2].Value;
				txtNoiSinh.Text = dgvHoSoNhanVien.Rows[index].Cells[3].Value.ToString();
				txtDiaChi.Text = dgvHoSoNhanVien.Rows[index].Cells[4].Value.ToString();
			txtSDT.Text = dgvHoSoNhanVien.Rows[index].Cells[5].Value.ToString();
				cbGioiTinh.Text = dgvHoSoNhanVien.Rows[index].Cells[6].Value.ToString();
				txtDanToc.Text = dgvHoSoNhanVien.Rows[index].Cells[7].Value.ToString();
				txtTonGiao.Text = dgvHoSoNhanVien.Rows[index].Cells[8].Value.ToString();
				txtHocVan.Text = dgvHoSoNhanVien.Rows[index].Cells[9].Value.ToString();
				rtGhiChu.Text = dgvHoSoNhanVien.Rows[index].Cells[10].Value.ToString();
			}
			else
			{
				txtHoTen.Text = txtNoiSinh.Text = txtDiaChi.Text = txtSDT.Text = cbGioiTinh.Text = txtDanToc.Text = txtTonGiao.Text = txtHocVan.Text = rtGhiChu.Text = "";
				dtpNgaySinh.Value = DateTime.Now;
			}
		}

        private void btnThem_Click(object sender, EventArgs e)
        {
			if(txtHoTen.Text.Trim() == "")
            {
				MessageBox.Show(@"Bạn chưa nhập họ tên", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtHoTen.Focus();
				return;
            }
			if (txtNoiSinh.Text.Trim() == "")
			{
				MessageBox.Show(@"Bạn chưa nhập nơi sinh", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtNoiSinh.Focus();
				return;
			}
			if (txtDiaChi.Text.Trim() == "")
			{
				MessageBox.Show(@"Bạn chưa nhập địa chỉ", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtDiaChi.Focus();
				return;
			}
			if(!int.TryParse(txtSDT.Text, out int sdt) || txtSDT.Text.Length != 10)
            {
				MessageBox.Show(@"Số điện thoại phải có 10 số", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtSDT.Focus();
				return;
			}
			if (txtDanToc.Text.Trim() == "")
			{
				MessageBox.Show(@"Bạn chưa nhập dân tộc", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtDanToc.Focus();
				return;
			}
			if (txtTonGiao.Text.Trim() == "")
			{
				MessageBox.Show(@"Bạn chưa nhập tôn giáo", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtTonGiao.Focus();
                return;
            }
			if (txtHocVan.Text.Trim() == "")
			{
				MessageBox.Show(@"Bạn chưa nhập học vấn", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtHocVan.Focus();
				return;
			}
			try
            {
				var sqlconnectstring = "Server=localhost\\SQLEXPRESS,1433;Database=test2;UID=sa;PWD=12345";
				var connection = new SqlConnection(sqlconnectstring);
				connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection
                };
                string queryString = @"insert into HoSoNhanVien values(@HoTen, @NgaySinh, @NoiSinh, @DiaChi, @SDT, @GioiTinh, @DanToc, @TonGiao, @HocVan, @GhiChu)";
				command.CommandText = queryString;
				command.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
				command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date);
				command.Parameters.AddWithValue("@NoiSinh", txtNoiSinh.Text);
				command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
				command.Parameters.AddWithValue("@SDT", txtSDT.Text);
				command.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
				command.Parameters.AddWithValue("@DanToc", txtDanToc.Text);
				command.Parameters.AddWithValue("@TonGiao", txtTonGiao.Text);
				command.Parameters.AddWithValue("@HocVan", txtHocVan.Text);
				command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
				var rows_affected = command.ExecuteNonQuery();
				MessageBox.Show(rows_affected == 1 ? "Thêm thành công" : "Thêm thất bại", rows_affected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, rows_affected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
				connection.Close();
			} catch (Exception)
            {
				MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			GetData();
		}

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
			GetData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}