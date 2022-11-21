using Quan_li_nhan_su.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
    public partial class QLHoSoNhanVien : Form
    {
        public static PictureBox AnhChup = new PictureBox();
        private int _index = -1;

        public QLHoSoNhanVien()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvHoSoNhanVien.Visible = false;
            txtHoTen.Text = txtNoiSinh.Text = txtDiaChi.Text = txtSDT.Text =
                cbGioiTinh.Text = txtDanToc.Text = txtTonGiao.Text = txtHocVan.Text = rtGhiChu.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            pbAnhHoSo.Image = Resources.noimage;
            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (s1, e1) =>
            {
                var table = KetNoi.GetData("select * from HoSoNhanVien");
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
                    dgvHoSoNhanVien.DataSource = e2.Result as DataTable;
                    for (var i = 0; i < dgvHoSoNhanVien.Columns.Count; i++)
                        dgvHoSoNhanVien.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                    dgvHoSoNhanVien.Columns[11].Visible = false;
                    dgvHoSoNhanVien.Refresh();
                }

                dgvHoSoNhanVien.Visible = true;
                Enabled = true;
            };
            bw.RunWorkerAsync();
        }

        private void QLHoSoNhanVien_Load(object sender, EventArgs e)
        {
            dgvHoSoNhanVien.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHoSoNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvHoSoNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoSoNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //GetData();
        }

        private Image BytesToImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private byte[] ImagetoBytes(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void dgvHoSoNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            _index = e.RowIndex;
            if (dgvHoSoNhanVien.SelectedCells.Count != 0)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtHoTen.Text = dgvHoSoNhanVien.Rows[_index].Cells[1].Value.ToString();
                dtpNgaySinh.Value = (DateTime)dgvHoSoNhanVien.Rows[_index].Cells[2].Value;
                txtNoiSinh.Text = dgvHoSoNhanVien.Rows[_index].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvHoSoNhanVien.Rows[_index].Cells[4].Value.ToString();
                txtSDT.Text = dgvHoSoNhanVien.Rows[_index].Cells[5].Value.ToString();
                cbGioiTinh.Text = dgvHoSoNhanVien.Rows[_index].Cells[6].Value.ToString();
                txtDanToc.Text = dgvHoSoNhanVien.Rows[_index].Cells[7].Value.ToString();
                txtTonGiao.Text = dgvHoSoNhanVien.Rows[_index].Cells[8].Value.ToString();
                txtHocVan.Text = dgvHoSoNhanVien.Rows[_index].Cells[9].Value.ToString();
                rtGhiChu.Text = dgvHoSoNhanVien.Rows[_index].Cells[10].Value.ToString();
                pbAnhHoSo.Image = BytesToImage((byte[])dgvHoSoNhanVien.Rows[_index].Cells[11].Value);
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                txtHoTen.Text = txtNoiSinh.Text = txtDiaChi.Text = txtSDT.Text = cbGioiTinh.Text =
                    txtDanToc.Text = txtTonGiao.Text = txtHocVan.Text = rtGhiChu.Text = "";
                dtpNgaySinh.Value = DateTime.Now;
                pbAnhHoSo.Image = Resources.noimage;
                dgvHoSoNhanVien.ClearSelection();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (txtNoiSinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập nơi sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiSinh.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (!int.TryParse(txtSDT.Text, out _) || txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (txtDanToc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập dân tộc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDanToc.Focus();
                return;
            }

            if (txtTonGiao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tôn giáo", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTonGiao.Focus();
                return;
            }

            if (txtHocVan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập học vấn", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHocVan.Focus();
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
                                   "insert into HoSoNhanVien values(@HoTen, @NgaySinh, @NoiSinh, @DiaChi, @SDT, @GioiTinh, @DanToc, @TonGiao, @HocVan, @GhiChu, @AnhHoSo)"
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
                        command.Parameters.AddWithValue("@AnhHoSo", ImagetoBytes(pbAnhHoSo.Image));
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
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (txtNoiSinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập nơi sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiSinh.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (!int.TryParse(txtSDT.Text, out _) || txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (txtDanToc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập dân tộc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDanToc.Focus();
                return;
            }

            if (txtTonGiao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tôn giáo", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTonGiao.Focus();
                return;
            }

            if (txtHocVan.Text.Trim().Length == 0)
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
                using (var connection = new SqlConnection(GiaoDienChinh.ConnStr))
                {
                    connection.Open();
                    using (var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText =
                                   "update HoSoNhanVien set Hoten = @HoTen, NgaySinh = @NgaySinh, NoiSinh = @NoiSinh, DiaChi = @DiaChi, SDT = @SDT, GioiTinh = @GioiTinh, DanToc = @DanToc, TonGiao = @TonGiao, HocVan = @HocVan, GhiChu = @GhiChu, AnhHoSo = @AnhHoSo where MaNV = @MaNV"
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
                        command.Parameters.AddWithValue("@AnhHoSo", ImagetoBytes(pbAnhHoSo.Image));
                        command.Parameters.AddWithValue("@MaNV", dgvHoSoNhanVien.Rows[_index].Cells[0].Value);
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
                        CommandText = "delete from HoSoNhanVien where MaNV = @MaNV"
                    })
                    {
                        command.Parameters.AddWithValue("@MaNV", dgvHoSoNhanVien.Rows[_index].Cells[0].Value);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!chkTimTheoTen.Checked && !chkTimTheoHocVan.Checked)
            {
                MessageBox.Show("Bạn chưa chọn cách nào để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (chkTimTheoTen.Checked && txtTimTheoTen.Text?.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (chkTimTheoHocVan.Checked && txtTimTheoHocVan.Text?.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập học vấn để tìm kiếm", "Cảnh báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvHoSoNhanVien.Visible = false;

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
                        CommandText = "select * from HoSoNhanVien" +
                                             (chkTimTheoTen.Checked && chkTimTheoHocVan.Checked
                                                 ? " where HoTen like @HoTen and HocVan like @HocVan"
                                                 : chkTimTheoTen.Checked
                                                     ? " where HoTen like @HoTen"
                                                     : chkTimTheoHocVan.Checked
                                                         ? " where HocVan like @HocVan"
                                                         : "")
                    })
                    {
                        command.Parameters.AddWithValue("@HoTen", $"%{txtTimTheoTen.Text}%");
                        command.Parameters.AddWithValue("@HocVan", $"%{txtTimTheoHocVan.Text}%");
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
                    dgvHoSoNhanVien.DataSource = e2.Result as DataTable;

                dgvHoSoNhanVien.Visible = true;
                Enabled = true;
            };

            bw.RunWorkerAsync();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Filter = "Ảnh(*.PNG;*.JPG;*.JPEG;*.BMP)|*.PNG;*.JPG;*.JPEG,*.BMP",
                Multiselect = false,
                Title = "Chọn ảnh hồ sơ nhân viên"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length > 8 * 1024 * 1024)
                    {
                        MessageBox.Show("Kích cỡ ảnh quá lớn, hãy dùng ảnh nhỏ hơn 8MB", "Cảnh báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        pbAnhHoSo.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể dùng ảnh này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pbAnhHoSo.Image = Resources.noimage;
        }

        private void pbAnhHoSo_Click(object sender, EventArgs e)
        {
            pbAnhHoSo.Image.Save(Path.Combine(Path.GetTempPath(), "temp.png"));
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "rundll32.exe",
                    Arguments = "\"C:\\Program Files (x86)\\Windows Photo Viewer\\PhotoViewer.dll\", ImageView_Fullscreen " +
                                Path.Combine(Path.GetTempPath(), "temp.png"),
                    UseShellExecute = false
                }
            }) process.Start();
        }

        private void dgvHoSoNhanVien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (var i = 0; i < dgvHoSoNhanVien.Rows.Count; i++)
                dgvHoSoNhanVien.Rows[i].HeaderCell.Value = (i + 1).ToString();
            dgvHoSoNhanVien.TopLeftHeaderCell.Value = $"Tổng: {dgvHoSoNhanVien.Rows.Count}";
            dgvHoSoNhanVien.ClearSelection();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var c = new Camera();
            c.ShowDialog();
            c.Dispose();
            GC.Collect();
            if (AnhChup.Image == null) return;
            pbAnhHoSo.Image = AnhChup.Image;
            AnhChup.Image = null;
        }

        private void QLHoSoNhanVien_Shown(object sender, EventArgs e)
        {
            GetData();
        }

        private void QLHoSoNhanVien_Enter(object sender, EventArgs e)
        {
  

        }
    }
}