﻿using AForge.Imaging.Filters;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
{
    public partial class ThongKeLuong : Form
    {
        public ThongKeLuong() { InitializeComponent(); }
            {
            {
                progressBar1.Visible = false; label14.Visible = false; if (e2.Error != null) { MessageBox.Show("Có lỗi khi tải dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                }
                chartThongKe.Visible = true; Enabled = true;
            }; bw.RunWorkerAsync();

        private void btnLuuAnh_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch(Path.GetExtension(saveFileDialog1.FileName))
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
    }
}