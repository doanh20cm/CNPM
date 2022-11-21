using Quan_li_nhan_su.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void GetData()
        {
            Enabled = false;
            WindowState = FormWindowState.Maximized;
            Activate();
            progressBar1.Visible = true;
            label14.Visible = true;
            label14.BringToFront();
            dgvLuong.Visible = false;
            //txtHoTen.Text = txtNoiSinh.Text = txtDiaChi.Text = txtSDT.Text =
            //    cbGioiTinh.Text = txtDanToc.Text = txtTonGiao.Text = txtHocVan.Text = rtGhiChu.Text = "";
            //dtpNgaySinh.Value = DateTime.Now;
            //pbAnhHoSo.Image = Resources.noimage;
            var bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (s1, e1) =>
            {
                var table = KetNoi.GetData("select * from Luong");
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
                    dgvLuong.DataSource = e2.Result as DataTable;
                    for (var i = 0; i < dgvLuong.Columns.Count; i++)
                        dgvLuong.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //dgvHoSoNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                    //dgvHoSoNhanVien.Columns[1].HeaderText = "Họ và tên";
                    //dgvHoSoNhanVien.Columns[2].HeaderText = "Ngày sinh";
                    //dgvHoSoNhanVien.Columns[3].HeaderText = "Nơi sinh";
                    //dgvHoSoNhanVien.Columns[4].HeaderText = "Địa chỉ";
                    //dgvHoSoNhanVien.Columns[5].HeaderText = "Số điện thoại";
                    //dgvHoSoNhanVien.Columns[6].HeaderText = "Giới tính";
                    //dgvHoSoNhanVien.Columns[7].HeaderText = "Dân tộc";
                    //dgvHoSoNhanVien.Columns[8].HeaderText = "Tôn giáo";
                    //dgvHoSoNhanVien.Columns[9].HeaderText = "Học vấn";
                    //dgvHoSoNhanVien.Columns[10].HeaderText = "Ghi chú";
                    //cbGioiTinh.Text = "Nam";
                    //dgvHoSoNhanVien.Columns[0].Visible = false;
                    //dgvHoSoNhanVien.Columns[11].Visible = false;
                    dgvLuong.Refresh();
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
    }
}
