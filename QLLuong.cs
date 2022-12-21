using Quan_li_nhan_su.Properties;
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
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
namespace Quan_li_nhan_su
{
    public partial class QLLuong : Form
    {
        private int _index = -1;
        public QLLuong()
        {
            InitializeComponent();
        }
        private void QLLuong_Load(object sender, EventArgs e)
        {
            dgvLuong.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLuong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void
            GetData()
        {
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvLuong.Visible = false;
            cbTenNV.Enabled = true;
            txtLuongCoSo.Text = GiaoDienChinh.Luongcoso;
            txtHeSoLuong.Text = cbTenNV.Text = txtPhuCap.Text = txtThuong.Text = txtPhat.Text = rtGhiChu.Text = "";

            numSoNgayCong.Value = numSoGioLamThem.Value = 0;
            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;
            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (s1, e1) =>
            {
                var table = KetNoi.GetData("select * from xemluong");
                var table2 = KetNoi.GetData("select  MaNV, HoTen from HoSoNhanVien");
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
                    dgvLuong.DataSource = table_arr[0];
                    for (var i = 0; i < dgvLuong.Columns.Count; i++)
                        dgvLuong.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvLuong.Columns[0].HeaderText = "Mã lương";
                    dgvLuong.Columns[1].HeaderText = "Nhân viên";
                    dgvLuong.Columns[2].HeaderText = "Lương cơ sở\n(triệu đồng)";
                    dgvLuong.Columns[3].HeaderText = "Hệ số lương";
                    dgvLuong.Columns[4].HeaderText = "Số ngày\ncông";
                    dgvLuong.Columns[5].HeaderText = "Số giờ\nlàm thêm";
                    dgvLuong.Columns[6].HeaderText = "Phụ cấp\n(triệu đồng)";
                    dgvLuong.Columns[7].HeaderText = "Thưởng\n(triệu đồng)";
                    dgvLuong.Columns[8].HeaderText = "Phạt\n(triệu đồng)";
                    dgvLuong.Columns[9].HeaderText = "Tháng";
                    dgvLuong.Columns[10].HeaderText = "Năm";
                    dgvLuong.Columns[11].HeaderText = "Ghi chú"; dgvLuong.Columns[12].HeaderText = "Tổng kết\n(triệu đồng)";
                    dgvLuong.Columns[0].Visible = false;
                    dgvLuong.Refresh();
                    cbTenNV.DataSource = table_arr[1];
                    cbTenNV.DisplayMember = "HoTen";
                    cbTenNV.ValueMember = "MaNV";
                }
                dgvLuong.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }
        private void dgvLuong_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (var i = 0; i < dgvLuong.Rows.Count; i++)
                dgvLuong.Rows[i].HeaderCell.Value = (i + 1).ToString();
            dgvLuong.TopLeftHeaderCell.Value = $"Tổng: {dgvLuong.Rows.Count}";
            dgvLuong.ClearSelection();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void QLLuong_Shown(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgvLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbTenNV.SelectedItem == null || cbTenNV.GetItemText(cbTenNV.SelectedItem) != cbTenNV.Text)
            {
                MessageBox.Show("Bạn phải chọn hoặc chọn 1 nhân viên sau khi nhập từ danh sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtLuongCoSo.Text, out int lcs) || lcs < 1000)
            {
                MessageBox.Show("Lương cơ sở phải là số nguyên > 1000", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!float.TryParse(txtHeSoLuong.Text, out float hsl) || hsl < 1)
            {
                MessageBox.Show("Hệ số lương phải là số thực >= 1", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!int.TryParse(txtPhuCap.Text, out int pc) || pc < 0)
            {
                MessageBox.Show("Lương phụ cấp phải là số  nguyên >= 0", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!int.TryParse(txtThuong.Text, out int t) || t < 0)
            {
                MessageBox.Show("Lương thưởng phải là số  nguyên >= 0", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!int.TryParse(txtPhat.Text, out int p) || p < 0)
            {
                MessageBox.Show("Tiền phạt phải là số nguyên >= 0", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
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
                        CommandText = "select count(*) from Luong where MaNV = @MaNV and Thang = @Thang and Nam = @Nam"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbTenNV.SelectedValue);
                        command.Parameters.AddWithValue("@Thang", numThang.Value);
                        command.Parameters.AddWithValue("@Nam", numNam.Value);
                        var dupplicator = (int)command.ExecuteScalar();
                        if (dupplicator > 0)
                        {
                            MessageBox.Show("Nhân viên đó đã có bản ghi lương vào thời gian này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText =
                                   "insert into Luong values(@MaNV, @LuongCoSo, @HeSoLuong, @SoNgayCong, @SoGioLamThem, @PhuCap, @Thuong, @Phat, @Thang, @Nam, @GhiChu, 0)"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbTenNV.SelectedValue);
                        command.Parameters.AddWithValue("@LuongCoSo", lcs);
                        command.Parameters.AddWithValue("@HeSoLuong", hsl);
                        command.Parameters.AddWithValue("@SoNgayCong", numSoNgayCong.Value);
                        command.Parameters.AddWithValue("@SoGioLamThem", numSoGioLamThem.Value);
                        command.Parameters.AddWithValue("@PhuCap", pc);
                        command.Parameters.AddWithValue("@Thuong", t);
                        command.Parameters.AddWithValue("@Phat", p);
                        command.Parameters.AddWithValue("@Thang", numThang.Value);
                        command.Parameters.AddWithValue("@Nam", numNam.Value);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        var rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected == 2 ? "Thêm thành công" : "Thêm thất bại", rowsAffected == 2 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, rowsAffected == 2 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetData();
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            _index = e.RowIndex;
            if (dgvLuong.SelectedCells.Count != 0)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;

                btnXoa.Enabled = true;
                cbTenNV.Text = dgvLuong.Rows[_index].Cells[1].Value.ToString();
                txtLuongCoSo.Text = (1000000 * float.Parse(dgvLuong.Rows[_index].Cells[2].Value.ToString())).ToString();
                txtHeSoLuong.Text = dgvLuong.Rows[_index].Cells[3].Value.ToString();
                numSoNgayCong.Value = (int)dgvLuong.Rows[_index].Cells[4].Value;
                numSoGioLamThem.Value = (int)dgvLuong.Rows[_index].Cells[5].Value;
                txtPhuCap.Text = (1000000 * float.Parse(dgvLuong.Rows[_index].Cells[6].Value.ToString())).ToString();
                txtThuong.Text = (1000000 * float.Parse(dgvLuong.Rows[_index].Cells[7].Value.ToString())).ToString();
                txtPhat.Text = (1000000 * float.Parse(dgvLuong.Rows[_index].Cells[8].Value.ToString())).ToString();
                numThang.Value = (int)dgvLuong.Rows[_index].Cells[9].Value;
                numNam.Value = (int)dgvLuong.Rows[_index].Cells[10].Value;
                rtGhiChu.Text = dgvLuong.Rows[_index].Cells[11].Value.ToString();
                cbTenNV.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                cbTenNV.Enabled = true;
                txtLuongCoSo.Text = GiaoDienChinh.Luongcoso; txtHeSoLuong.Text = cbTenNV.Text = txtPhuCap.Text = txtThuong.Text = txtPhat.Text = rtGhiChu.Text = "";
                numSoNgayCong.Value = numSoGioLamThem.Value = 0;
                numThang.Value = DateTime.Now.Month;
                numNam.Value = DateTime.Now.Year;
                dgvLuong.ClearSelection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLuongCoSo.Text, out int lcs) || lcs < 1000)
            {
                MessageBox.Show("Lương cơ sở phải là số nguyên > 1000", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!float.TryParse(txtHeSoLuong.Text, out float hsl) || hsl < 1)
            {
                MessageBox.Show("Hệ số lương phải là số thực >= 1", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!int.TryParse(txtPhuCap.Text, out int pc) || pc < 0)
            {
                MessageBox.Show("Lương phụ cấp phải là số  nguyên >= 0", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!int.TryParse(txtThuong.Text, out int t) || t < 0)
            {
                MessageBox.Show("Lương thưởng phải là số  nguyên >= 0", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
                return;
            }
            if (!int.TryParse(txtPhat.Text, out int p) || p < 0)
            {
                MessageBox.Show("Tiền phạt phải là số nguyên >= 0", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLuongCoSo.Focus();
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
                        CommandText = "select count(*) from Luong where MaNV = @MaNV and Thang = @Thang and Nam = @Nam and MaLuong != @MaLuong"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", cbTenNV.SelectedValue);
                        command.Parameters.AddWithValue("@Thang", numThang.Value);
                        command.Parameters.AddWithValue("@Nam", numNam.Value);
                        command.Parameters.AddWithValue("@MaLuong", dgvLuong.Rows[_index].Cells[0].Value);
                        var dupplicator = (int)command.ExecuteScalar();
                        if (dupplicator > 0)
                        {
                            MessageBox.Show("Nhân viên đã có bản ghi lương vào thời gian này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText =
                                   "update Luong set LuongCoSo = @LuongCoSo, HeSoLuong = @HeSoLuong, SoNgayCong = @SoNgayCong, SoGioLamThem = @SoGioLamThem, PhuCap = @PhuCap, Thuong = @Thuong, Phat = @Phat, Thang = @Thang, Nam = @Nam, GhiChu = @GhiChu where MaLuong = @MaLuong"
                    })
                    {
                        command.Parameters.AddWithValue("@LuongCoSo", lcs);
                        command.Parameters.AddWithValue("@HeSoLuong", hsl);
                        command.Parameters.AddWithValue("@SoNgayCong", numSoNgayCong.Value);
                        command.Parameters.AddWithValue("@SoGioLamThem", numSoGioLamThem.Value);
                        command.Parameters.AddWithValue("@PhuCap", pc);
                        command.Parameters.AddWithValue("@Thuong", t);
                        command.Parameters.AddWithValue("@Phat", p);
                        command.Parameters.AddWithValue("@Thang", numThang.Value);
                        command.Parameters.AddWithValue("@Nam", numNam.Value);
                        command.Parameters.AddWithValue("@GhiChu", rtGhiChu.Text);
                        command.Parameters.AddWithValue("@MaLuong", dgvLuong.Rows[_index].Cells[0].Value);
                        var rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected == 2 ? "Sửa thành công" : "Sửa thất bại",
                            rowsAffected == 2 ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                            rowsAffected == 2 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
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
                        CommandText = "delete from Luong where MaLuong = @MaLuong"
                    })
                    {
                        command.Parameters.AddWithValue("@MaLuong", dgvLuong.Rows[_index].Cells[0].Value);
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
            if (!chkTimTen.Checked && !chkTimTruoc.Checked && !chkTimSau.Checked)
            {
                MessageBox.Show("Bạn chưa chọn cách nào để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (chkTimTen.Checked && txtTimTen.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (chkTimTruoc.Checked && chkTimSau.Checked && numTruoc.Value < numSau.Value)
            {
                MessageBox.Show("Giới hạn lương dưới không được thấp hơn giới hạn lương trên", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvLuong.Visible = false;
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
                                   "select * from xemluong " +
                                   (chkTimTen.Checked && chkTimTruoc.Checked && chkTimSau.Checked
                                       ? "where HoTen like @HoTen and TongKetThang <= @NgayTruoc and TongKetThang >= @NgaySau"
                                       : chkTimTen.Checked && chkTimTruoc.Checked
                                           ? "where HoTen like @HoTen and TongKetThang <= @NgayTruoc"
                                           : chkTimTen.Checked && chkTimSau.Checked
                                               ? "where HoTen like @HoTen and TongKetThang >= @NgaySau"
                                               : chkTimTruoc.Checked && chkTimSau.Checked
                                                   ? "where TongKetThang <= @NgayTruoc and TongKetThang >= @NgaySau"
                                                   : chkTimTen.Checked
                                                       ? "where HoTen like @HoTen"
                                                       : chkTimTruoc.Checked
                                                           ? "where TongKetThang <= @NgayTruoc"
                                                           : chkTimSau.Checked
                                                               ? "where TongKetThang >= @NgaySau"
                                                               : "")
                    })
                    {
                        command.Parameters.AddWithValue("@HoTen", $"%{txtTimTen.Text}%");
                        command.Parameters.AddWithValue("@NgayTruoc", numTruoc.Value);
                        command.Parameters.AddWithValue("@NgaySau", numSau.Value);
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
                    dgvLuong.DataSource = e2.Result as DataTable;
                dgvLuong.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }

        private void QLLuong_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------------------

            //// lấy dữ liệu từ bảng
            //GetData();

            //// Tạo một ứng dụng Excel mới
            //ExcelApplication excel = new ExcelApplication();

            //// Tạo sổ làm việc Excel mới
            //Workbook workbook = excel.Workbooks.Add();

            //// Lấy trang tính đầu tiên trong sổ làm việc
            //Worksheet worksheet = workbook.Sheets[1];

            //// Thêm tên cột vào hàng đầu tiên của trang tính
            //for (int i = 0; i < dgvLuong.Columns.Count; i++)
            //{
            //    worksheet.Cells[1, i + 1] = dgvLuong.Columns[i].HeaderText;
            //}

            //// Thêm dữ liệu từ DataTable vào trang tính
            //for (int i = 0; i < dgvLuong.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dgvLuong.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 2, j + 1] = dgvLuong.Rows[i].Cells[j].Value.ToString();
            //    }
            //}

            //// Lưu file vào địa chỉ đường link ngay khi ấn nút xuất
            ////workbook.SaveAs("D:\\Word\\Báo cáo lương quý 1.xlsx");
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //saveFileDialog.FilterIndex = 1;
            //saveFileDialog.RestoreDirectory = true;

            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = saveFileDialog.FileName;
            //    // Save the file to the selected folder here
            //}

            //// Kết thúc
            //workbook.Close();
            //excel.Quit();
            //--------------------------------------------------------------------------------
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 1;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Tạo một lớp Ứng dụng Excel và hiển thị nó
                        ExcelApplication excelApp = new ExcelApplication();
                        excelApp.Visible = true;

                        // Tạo một sổ làm việc mới và thêm một trang tính vào đó
                        Workbook workbook = excelApp.Workbooks.Add();
                        Worksheet worksheet = workbook.ActiveSheet;

                        // Lặp lại qua các hàng và cột của DataGridView và ghi các giá trị ô vào trang tính
                        for (int i = 1; i < dgvLuong.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i] = dgvLuong.Columns[i - 1].HeaderText;
                        }

                        for (int i = 0; i < dgvLuong.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvLuong.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvLuong.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        // Lưu sổ làm việc vào tệp do người dùng chọn và đóng ứng dụng Excel
                        workbook.SaveAs(saveDialog.FileName);
                        excelApp.Quit();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xuất thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

