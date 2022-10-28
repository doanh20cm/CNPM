using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
	public partial class QLHoSoNhanVien : Form
	{
		readonly KetNoi _kn = new KetNoi();
		int index = -1;
        const string sqlconnectstring = "Server=localhost\\SQLEXPRESS,1433;Database=test2;UID=sa;PWD=12345";

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
			dgvHoSoNhanVien.Columns[0].Visible = false;
			dgvHoSoNhanVien.Refresh();
		}

		private void QLHoSoNhanVien_Load(object sender, EventArgs e)
		{
			GetData();
		}

		private void dgvHoSoNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			index = e.RowIndex;
			if (index > -1 && dgvHoSoNhanVien.SelectedCells.Count != 0)
			{
				txtHoTen.Text = dgvHoSoNhanVien.Rows[index].Cells[1].Value.ToString();
				dtpNgaySinh.Value = (DateTime)dgvHoSoNhanVien.Rows[index].Cells[2].Value;
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
			if (txtHoTen.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtHoTen.Focus();
				return;
			}
			if (txtNoiSinh.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập nơi sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtNoiSinh.Focus();
				return;
			}
			if (txtDiaChi.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtDiaChi.Focus();
				return;
			}
			if (!int.TryParse(txtSDT.Text, out int sdt) || txtSDT.Text.Length != 10)
			{
				MessageBox.Show("Số điện thoại phải có 10 số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtSDT.Focus();
				return;
			}
			if (txtDanToc.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập dân tộc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtDanToc.Focus();
				return;
			}
			if (txtTonGiao.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập tôn giáo", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtTonGiao.Focus();
				return;
			}
			if (txtHocVan.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập học vấn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtHocVan.Focus();
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
                        CommandText = "insert into HoSoNhanVien values(@HoTen, @NgaySinh, @NoiSinh, @DiaChi, @SDT, @GioiTinh, @DanToc, @TonGiao, @HocVan, @GhiChu)"
					})
					{
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
			if (index < 0 || dgvHoSoNhanVien.SelectedCells.Count == 0)
			{
				MessageBox.Show("Chưa chọn dòng nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (txtHoTen.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtHoTen.Focus();
				return;
			}
			if (txtNoiSinh.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập nơi sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtNoiSinh.Focus();
				return;
			}
			if (txtDiaChi.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtDiaChi.Focus();
				return;
			}
			if (!int.TryParse(txtSDT.Text, out int sdt) || txtSDT.Text.Length != 10)
			{
				MessageBox.Show("Số điện thoại phải có 10 số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtSDT.Focus();
				return;
			}
			if (txtDanToc.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập dân tộc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtDanToc.Focus();
				return;
			}
			if (txtTonGiao.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập tôn giáo", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtTonGiao.Focus();
				return;
			}
			if (txtHocVan.Text.Trim()?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập học vấn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtHocVan.Focus();
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
                        CommandText = "update HoSoNhanVien set Hoten = @HoTen, NgaySinh = @NgaySinh, NoiSinh = @NoiSinh, DiaChi = @DiaChi, SDT = @SDT, GioiTinh = @GioiTinh, DanToc = @DanToc, TonGiao = @TonGiao, HocVan = @HocVan, GhiChu = @GhiChu where MaNV = @MaNV"

					})
					{
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
                        command.Parameters.AddWithValue("@MaNV", dgvHoSoNhanVien.Rows[index].Cells[0].Value);
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
			if (index < 0 || dgvHoSoNhanVien.SelectedCells.Count == 0)
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
						CommandText = "delete from HoSoNhanVien where MaNV = @MaNV"
					})
					{
						command.Parameters.AddWithValue("@MaNV", dgvHoSoNhanVien.Rows[index].Cells[0].Value);
						var rows_affected = command.ExecuteNonQuery();
						MessageBox.Show(rows_affected == 1 ? "Xoá thành công" : "Xoá thất bại", rows_affected == 1 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, rows_affected == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);

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

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!chkTimTheoTen.Checked && !chkTimTheoHocVan.Checked)
			{
				MessageBox.Show("Bạn chưa chọn gì để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (chkTimTheoTen.Checked && txtTimTheoTen.Text?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập tên để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (chkTimTheoHocVan.Checked && txtTimTheoHocVan.Text?.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập học vấn để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
						CommandText = "select * from HoSoNhanVien" + (chkTimTheoTen.Checked && chkTimTheoHocVan.Checked ? " where HoTen like @HoTen and HocVan like @HocVan" : chkTimTheoTen.Checked ? " where HoTen like @HoTen" : chkTimTheoHocVan.Checked ? " where HocVan like @HocVan" : "")
					})
					{
                        command.Parameters.AddWithValue("@HoTen", $"%{txtTimTheoTen.Text}%");
                        command.Parameters.AddWithValue("@HocVan", $"%{txtTimTheoHocVan.Text}%");
						using (var reader = command.ExecuteReader())
						{
							using (var dt = new DataTable())
							{
                                dt.Load(reader);
                                dgvHoSoNhanVien.DataSource = dt;
                            }
                        }
                    }
                }
            } catch (Exception)
			{
                MessageBox.Show("Tìm kiếm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			GetData();
            }
        }
	}
}