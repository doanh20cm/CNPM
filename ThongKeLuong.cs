﻿using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Quan_li_nhan_su
{
    public partial class ThongKeLuong : Form
    {
        public ThongKeLuong() { InitializeComponent(); }
        private void ThongKeLuong_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            try
            {
                string ChartImagePath = Path.Combine(Path.GetTempPath(), $"{DateTime.Now.ToString().Replace("/", "-").Replace(":", "-")}.png");
                chartThongKe.SaveImage(ChartImagePath, ChartImageFormat.Png);
                using (var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "rundll32.exe",
                        Arguments = "\"C:\\Program Files (x86)\\Windows Photo Viewer\\PhotoViewer.dll\", ImageView_Fullscreen " + ChartImagePath,
                        UseShellExecute = false
                    }
                }) process.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Không xem được ảnh biểu đồ");
            }
        }
        private void GetData()
        {
            Enabled = false; WindowState = FormWindowState.Maximized; Activate(); progressBar1.Visible = true; label14.Visible = true; label14.BringToFront(); chartThongKe.Visible = false;
            string query = "";
            string title = "";
            var bw = new BackgroundWorker { WorkerSupportsCancellation = true }; bw.DoWork += (s1, e1) =>
            {
                if (rbCongTy.Checked)
                {
                    if (rbAllNam.Checked)
                    {
                        query = "select Nam as x, sum(TongKetThang) as y from Luong group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG CÔNG TY QUA CÁC NĂM";
                    }
                    else if (rb1Nam.Checked)
                    {
                        query = $"select Thang as x, sum(TongKetThang) as y from Luong where Nam = {numNam.Value} group by Thang";
                        title = "BIỂU ĐỒ LƯƠNG CÔNG TY QUA CÁC THÁNG NĂM " + numNam.Value;
                    }
                    else
                    {
                        query = $"select Nam as x, sum(TongKetThang) as y from Luong where Thang = {numThang.Value} group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG CÔNG TY THÁNG " + numThang.Value + " QUA CÁC NĂM";
                    }
                }
                else if (rbBoPhan.Checked)
                {
                    if (rbAllNam.Checked)
                    {
                        query = $"select Nam as x, sum(TongKetThang) as y from Luong where MaNV in (select MaNV from NhanVienPhongBan where MaPhongBan in (select MaPhongBan from PhongBan where MaBoPhan = {cbBoPhan.SelectedValue})) group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG BỘ PHẬN " + cbBoPhan.Text + " QUA CÁC NĂM";
                    }
                    else if (rb1Nam.Checked)
                    {
                        query = $"select Thang as x, sum(TongKetThang) as y from Luong where MaNV in (select MaNV from NhanVienPhongBan where MaPhongBan in (select MaPhongBan from PhongBan where MaBoPhan = {cbBoPhan.SelectedValue})) and Nam = {numNam.Value} group by Thang";
                        title = "BIỂU ĐỒ LƯƠNG BỘ PHẬN " + cbBoPhan.Text + " QUA CÁC THÁNG NĂM " + numNam.Value;
                    }
                    else
                    {
                        query = $"select Nam as x, sum(TongKetThang) as y from Luong where MaNV in (select MaNV from NhanVienPhongBan where MaPhongBan in (select MaPhongBan from PhongBan where MaBoPhan = {cbBoPhan.SelectedValue})) and Thang = {numThang.Value} group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG BỘ PHẬN " + cbBoPhan.Text + " THÁNG " + numThang.Value + " QUA CÁC NĂM";
                    }
                }
                else if (rbPhongBan.Checked)
                {
                    if (rbAllNam.Checked)
                    {
                        query = $"select Nam as x, sum(TongKetThang) as y from Luong where MaNV in (select MaNV from NhanVienPhongBan where MaPhongBan = {cbPhongBan.SelectedValue}) group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG PHÒNG BAN " + cbPhongBan.Text + " QUA CÁC NĂM";
                    }
                    else if (rb1Nam.Checked)
                    {
                        query = $"select Thang as x, sum(TongKetThang) as y from Luong where MaNV in (select MaNV from NhanVienPhongBan where MaPhongBan = {cbPhongBan.SelectedValue}) and Nam = {numNam.Value} group by Thang";
                        title = "BIỂU ĐỒ LƯƠNG PHÒNG BAN " + cbPhongBan.Text + " QUA CÁC THÁNG NĂM " + numNam.Value;
                    }
                    else
                    {
                        query = $"select Nam as x, sum(TongKetThang) as y from Luong where MaNV in (select MaNV from NhanVienPhongBan where MaPhongBan = {cbPhongBan.SelectedValue}) and Thang = {numThang.Value} group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG PHÒNG BAN " + cbPhongBan.Text + " THÁNG " + numThang.Value + " QUA CÁC NĂM";
                    }
                }
                else
                {
                    if (rbAllNam.Checked)
                    {
                        query = $"select Nam as x, sum(TongKetThang) as y from Luong where MaNV = {cbNhanVien.SelectedValue} group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG NHÂN VIÊN " + cbNhanVien.Text + " QUA CÁC NĂM";
                    }
                    else if (rb1Nam.Checked)
                    {
                        query = $"select Thang as x, sum(TongKetThang) as y from Luong where MaNV = {cbNhanVien.SelectedValue} and Nam = {numNam.Value} group by Thang";
                        title = "BIỂU ĐỒ LƯƠNG NHÂN VIÊN " + cbNhanVien.Text + " QUA CÁC THÁNG NĂM " + numNam.Value;
                    }
                    else
                    {
                        query = $"select Nam as x, sum(TongKetThang) as y from Luong where MaNV = {cbNhanVien.SelectedValue} and Thang = {numThang.Value} group by Nam";
                        title = "BIỂU ĐỒ LƯƠNG NHÂN VIÊN " + cbNhanVien.Text + " THÁNG " + numThang.Value + " QUA CÁC NĂM";
                    }
                }
                var table = KetNoi.GetData(query);
                var table2 = KetNoi.GetData("select MaBoPhan, TenBoPhan from BoPhan");
                var table3 = KetNoi.GetData("select MaPhongBan, TenPhongBan from PhongBan");
                var table4 = KetNoi.GetData("select MaNV, HoTen from HoSoNhanVien");
                e1.Result = new DataTable[] { table, table2, table3, table4 };
            }; bw.RunWorkerCompleted += (s2, e2) =>
            {
                progressBar1.Visible = false; label14.Visible = false; if (e2.Error != null) { MessageBox.Show("Có lỗi khi tải dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    var table_arr = e2.Result as DataTable[];
                    cbBoPhan.DataSource = table_arr[1];
                    cbBoPhan.DisplayMember = "TenBoPhan";
                    cbBoPhan.ValueMember = "MaBoPhan";
                    cbPhongBan.DataSource = table_arr[2];
                    cbPhongBan.DisplayMember = "TenPhongBan";
                    cbPhongBan.ValueMember = "MaPhongBan";
                    cbNhanVien.DataSource = table_arr[3];
                    cbNhanVien.DisplayMember = "HoTen";
                    cbNhanVien.ValueMember = "MaNV";
                    chartThongKe.DataSource = table_arr[0];
                    chartThongKe.Series[0].XValueMember = "x";
                    chartThongKe.Series[0].YValueMembers = "y";
                    chartThongKe.Titles.Add(title);
                    chartThongKe.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
                    chartThongKe.Titles[0].ForeColor = Color.Violet;
                    chartThongKe.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Red;
                    chartThongKe.Series[0].IsValueShownAsLabel = true;
                    chartThongKe.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chartThongKe.ChartAreas[0].AxisX.Title = rb1Nam.Checked ? "Tháng" : "Năm";
                    chartThongKe.ChartAreas[0].AxisY.Title = "Lương (triệu đồng)";
                    chartThongKe.Series[0].IsVisibleInLegend = false;
                }
                chartThongKe.Visible = true; Enabled = true;
            }; bw.RunWorkerAsync();
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            chartThongKe.Series[0].Points.Clear();
            chartThongKe.Titles.Clear();
            GetData();
        }
        private void rb1Nam_CheckedChanged(object sender, EventArgs e)
        {
            lbThang.Visible = numThang.Visible = false;
            lbNam.Visible = numNam.Visible = true;
        }
        private void rbAllNam_CheckedChanged(object sender, EventArgs e)
        {
            lbNam.Visible = lbThang.Visible = numNam.Visible = numThang.Visible = false;
        }
        private void rb1Thang_CheckedChanged(object sender, EventArgs e)
        {
            lbNam.Visible = numNam.Visible = false;
            lbThang.Visible = numThang.Visible = true;
        }
        private void rbCongTy_CheckedChanged(object sender, EventArgs e)
        {
            lbBoPhan.Visible = cbBoPhan.Visible = lbPhongBan.Visible = cbPhongBan.Visible = lbNhanVien.Visible = cbNhanVien.Visible = false;
        }
        private void rbBoPhan_CheckedChanged(object sender, EventArgs e)
        {
            lbBoPhan.Visible = cbBoPhan.Visible = true;
            lbPhongBan.Visible = cbPhongBan.Visible = lbNhanVien.Visible = cbNhanVien.Visible = false;
        }
        private void rbPhongBan_CheckedChanged(object sender, EventArgs e)
        {
            lbPhongBan.Visible = cbPhongBan.Visible = true;
            lbBoPhan.Visible = cbBoPhan.Visible = lbNhanVien.Visible = cbNhanVien.Visible = false;
        }
        private void rbNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            lbNhanVien.Visible = cbNhanVien.Visible = true;
            lbBoPhan.Visible = cbBoPhan.Visible = lbPhongBan.Visible = cbPhongBan.Visible = false;
        }
        private void ThongKeLuong_Shown(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnLuuAnh_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (Path.GetExtension(saveFileDialog1.FileName))
                    {
                        case ".png":
                            chartThongKe.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
                            break;
                        case ".jpeg":
                            chartThongKe.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Jpeg);
                            break;
                        default:
                            MessageBox.Show("Phần mở rộng của file bạn đặt không được hỗ trợ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    using (var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = saveFileDialog1.FileName,
                            UseShellExecute = true
                        }
                    }) process.Start();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không lưu được ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuWord_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuExcel_Click(object sender, EventArgs e)
        {
            
        }
    }
}