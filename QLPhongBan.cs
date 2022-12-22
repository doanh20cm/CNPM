using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
namespace Quan_li_nhan_su
{
    public partial class QLPhongBan : Form
    {
        private int _index = -1;
        public QLPhongBan()
        {
            InitializeComponent();
        }
        private void QLPhongBan_Load(object sender, EventArgs e)
        {
            dgvPhongBan.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPhongBan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvPhongBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhongBan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void GetData()
        {
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvPhongBan.Visible = false;
            txtTenPhongBan.Text = txtSDT.Text = txtTruongPhong.Text = rtGhiChu.Text = "";
            dtpNgayThanhLap.Value = DateTime.Now;
            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (s1, e1) =>
            {
                var table = KetNoi.GetData("select * from xempb");
                var table1 = KetNoi.GetData("select MaBoPhan, TenBoPhan from BoPhan");
                e1.Result = new[] { table, table1 };
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
                    dgvPhongBan.DataSource = tbArr[0];
                    for (var i = 0; i < dgvPhongBan.Columns.Count; i++)
                        dgvPhongBan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvPhongBan.Columns[0].HeaderText = "Mã phòng ban";
                    dgvPhongBan.Columns[1].HeaderText = "Tên phòng ban";
                    dgvPhongBan.Columns[2].HeaderText = "Mã bộ phận";
                    dgvPhongBan.Columns[3].HeaderText = "Tên bộ phận";
                    dgvPhongBan.Columns[4].HeaderText = "Ngày thành lập";
                    dgvPhongBan.Columns[5].HeaderText = "Trưởng phòng";
                    dgvPhongBan.Columns[6].HeaderText = "SDT";
                    dgvPhongBan.Columns[7].HeaderText = "Ghi chú";
                    cbTenBoPhan.DataSource = tbArr[1];
                    cbTenBoPhan.DisplayMember = "TenBoPhan";
                    cbTenBoPhan.ValueMember = "MaBoPhan";
                    cbTimTheoTenBoPhan.DataSource = tbArr[1];
                    cbTimTheoTenBoPhan.DisplayMember = "TenBoPhan";
                    cbTimTheoTenBoPhan.ValueMember = "MaBoPhan";
                    dgvPhongBan.Columns[0].Visible = false;
                    dgvPhongBan.Columns[2].Visible = false;
                    dgvPhongBan.Refresh();
                }
                dgvPhongBan.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }
        private void dgvPhongBan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (var i = 0; i < dgvPhongBan.Rows.Count; i++)
                dgvPhongBan.Rows[i].HeaderCell.Value = (i + 1).ToString();
            dgvPhongBan.TopLeftHeaderCell.Value = $"Tổng: {dgvPhongBan.Rows.Count}";
            dgvPhongBan.ClearSelection();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void QLPhongBan_Shown(object sender, EventArgs e)
        {
            GetData();
        }
        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            _index = e.RowIndex;
            if (dgvPhongBan.SelectedCells.Count != 0)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTenPhongBan.Text = dgvPhongBan.Rows[_index].Cells[1].Value.ToString();
                cbTenBoPhan.Text = dgvPhongBan.Rows[_index].Cells[3].Value.ToString();
                dtpNgayThanhLap.Value = (DateTime)dgvPhongBan.Rows[_index].Cells[4].Value;
                txtTruongPhong.Text = dgvPhongBan.Rows[_index].Cells[5].Value.ToString();
                txtSDT.Text = dgvPhongBan.Rows[_index].Cells[6].Value.ToString();
                rtGhiChu.Text = dgvPhongBan.Rows[_index].Cells[7].Value.ToString();
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                txtTenPhongBan.Text = cbTenBoPhan.Text = txtTruongPhong.Text = txtSDT.Text = rtGhiChu.Text = "";
                dtpNgayThanhLap.Value = DateTime.Now;
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenPhongBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên phòng ban", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenPhongBan.Focus();
                return;
            }
            if (cbTenBoPhan.SelectedItem == null || cbTenBoPhan.GetItemText(cbTenBoPhan.SelectedItem) != cbTenBoPhan.Text)
            {
                MessageBox.Show("Bạn phải chọn hoặc chọn 1 bộ phận sau khi nhập từ danh sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTruongPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên trưởng phòng", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTruongPhong.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số", "Cảnh báo", MessageBoxButtons.OK,
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
                        CommandText =
                                   "insert into PhongBan values(@TenPhongBan, @MaBoPhan, @NgayThanhLap, @TruongPhongBan, @SDTPhong, @GhiChu)"
                    })
                    {
                        command.Parameters.AddWithValue("@TenPhongBan", txtTenPhongBan.Text);
                        command.Parameters.AddWithValue("@MaBoPhan", cbTenBoPhan.SelectedValue);
                        command.Parameters.AddWithValue("@NgayThanhLap", dtpNgayThanhLap.Value.Date);
                        command.Parameters.AddWithValue("@TruongPhongBan", txtTruongPhong.Text);
                        command.Parameters.AddWithValue("@SDTPhong", txtSDT.Text);
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
            if (txtTenPhongBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên phòng ban", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTenPhongBan.Focus();
                return;
            }
            if (cbTenBoPhan.SelectedItem == null || cbTenBoPhan.GetItemText(cbTenBoPhan.SelectedItem) != cbTenBoPhan.Text)
            {
                MessageBox.Show("Bạn phải chọn hoặc chọn 1 bộ phận sau khi nhập từ danh sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTruongPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên trưởng phòng", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTruongPhong.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số", "Cảnh báo", MessageBoxButtons.OK,
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
                                   "update PhongBan set TenPhongBan = @TenPhongBan, MaBoPhan = @MaBoPhan, NgayThanhLap = @NgayThanhLap, TruongPhongBan = @TruongPhongBan, SDTPhong = @SDTPhong, GhiChu = @GhiChu where MaPhongBan = @MaPhongBan"
                    })
                    {
                        command.Parameters.AddWithValue("@TenPhongBan", txtTenPhongBan.Text);
                        command.Parameters.AddWithValue("@MaBoPhan", cbTenBoPhan.SelectedValue);
                        command.Parameters.AddWithValue("@NgayThanhLap", dtpNgayThanhLap.Value.Date);
                        command.Parameters.AddWithValue("@TruongPhongBan", txtTruongPhong.Text);
                        command.Parameters.AddWithValue("@SDTPhong", txtSDT.Text);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@MaPhongBan", dgvPhongBan.Rows[_index].Cells[0].Value);
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
                        CommandText = "delete from PhongBan where MaPhongBan = @MaPhongBan"
                    })
                    {
                        command.Parameters.AddWithValue("@MaPhongBan", dgvPhongBan.Rows[_index].Cells[0].Value);
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!chkTenBoPhan.Checked && !chkTenPhongBan.Checked)
            {
                MessageBox.Show("Bạn chưa chọn cách nào để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (chkTenPhongBan.Checked && txtTimTheoTenPhongBan.Text?.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên phòng ban để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (chkTenBoPhan.Checked && (cbTimTheoTenBoPhan.SelectedItem == null || cbTimTheoTenBoPhan.GetItemText(cbTimTheoTenBoPhan.SelectedItem) != cbTimTheoTenBoPhan.Text))
            {
                MessageBox.Show("Bạn phải chọn hoặc chọn 1 nhân viên sau khi nhập từ danh sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvPhongBan.Visible = false;
            var x = cbTimTheoTenBoPhan.SelectedValue;
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
                                   "select * from xempb " +
                                   (chkTenPhongBan.Checked && chkTenBoPhan.Checked
                                       ? "where TenPhongBan like @TenPhongBan and MaBoPhan = @MaBoPhan"
                                       : chkTenPhongBan.Checked
                                           ? "where TenPhongBan like @TenPhongBan"
                                           : chkTenBoPhan.Checked
                                               ? "where MaBoPhan = @MaBoPhan"
                                               : "")
                    })
                    {
                        command.Parameters.AddWithValue("@TenPhongBan", $"%{txtTimTheoTenPhongBan.Text}%");
                        command.Parameters.AddWithValue("@MaBoPhan", x);
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
                    dgvPhongBan.DataSource = e2.Result as DataTable;
                dgvPhongBan.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }

        private void QLPhongBan_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một SaveFileDialog mới
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Đặt bộ lọc cho phần mở rộng tệp
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                    // Đặt phần mở rộng tệp mặc định
                    saveFileDialog.DefaultExt = "xlsx";

                    // Hiển thị SaveFileDialog và kiểm tra xem người dùng có nhấp vào nút Lưu không
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Tạo workbook mới
                        var workbook = new XLWorkbook();

                        // Thêm một trang tính vào workbook
                        var worksheet = workbook.Worksheets.Add("Sheet1");

                        // Lấy phạm vi ô chứa dữ liệu cần xuất

                        var range = worksheet.Range(1, 1, dgvPhongBan.RowCount + 1, dgvPhongBan.ColumnCount);

                        // Đặt giá trị của hàng đầu tiên thành tên cột
                        for (int i = 0; i < dgvPhongBan.ColumnCount; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvPhongBan.Columns[i].HeaderText;
                        }
                        // Đặt giá trị của phạm vi thành dữ liệu từ DataGridView
                        for (int i = 0; i < dgvPhongBan.RowCount; i++)
                        {
                            for (int j = 0; j < dgvPhongBan.ColumnCount; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dgvPhongBan.Rows[i].Cells[j].Value;
                            }
                        }

                        // Lưu sổ file vào tệp do người dùng chỉ định
                        workbook.SaveAs(saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xuất dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
