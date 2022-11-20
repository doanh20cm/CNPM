using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
    public partial class Camera : Form
    {
        private readonly FilterInfoCollection _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice _videoSource;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x216)
            { // Trap WM_MOVING
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                Screen scr = Screen.FromRectangle(Rectangle.FromLTRB(rc.left, rc.top, rc.right, rc.bottom));
                if (rc.left < scr.WorkingArea.Left) { rc.left = scr.WorkingArea.Left; rc.right = rc.left + this.Width; }
                if (rc.top < scr.WorkingArea.Top) { rc.top = scr.WorkingArea.Top; rc.bottom = rc.top + this.Height; }
                if (rc.right > scr.WorkingArea.Right) { rc.right = scr.WorkingArea.Right; rc.left = rc.right - this.Width; }
                if (rc.bottom > scr.WorkingArea.Bottom) { rc.bottom = scr.WorkingArea.Bottom; rc.top = rc.bottom - this.Height; }
                Marshal.StructureToPtr(rc, m.LParam, false);
            }
            base.WndProc(ref m);
        }
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public Camera()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(pictureBox1.Image.Clone() is Image clone)) return;
                using (var varBmp = new Bitmap(clone))
                {
                    var cropRect = new Rectangle((varBmp.Width - pictureBox1.Width) / 2,
                        (varBmp.Height - pictureBox1.Height) / 2, pictureBox1.Width, pictureBox1.Height);
                    var target = new Bitmap(cropRect.Width, cropRect.Height);
                    using (var g = Graphics.FromImage(target))
                    {
                        g.DrawImage(varBmp, new Rectangle(0, 0, target.Width, target.Height),
                            cropRect,
                            GraphicsUnit.Pixel);
                    }

                    clone.Dispose();
                    pictureBox2.Image?.Dispose();
                    pictureBox2.Image = target;
                    button3.Enabled = true;
                    button2.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không chụp được ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image.Save(saveFileDialog1.FileName);
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            if (_videoSource != null)
            {
                _videoSource.SignalToStop();
                _videoSource.NewFrame -= videoSource_NewFrame;
                _videoSource = null;
            }

            _videoSource = new VideoCaptureDevice(_videoDevices[comboBox1.SelectedIndex].MonikerString);
            _videoSource.NewFrame += videoSource_NewFrame;
            _videoSource.Start();
            comboBox1.Enabled = true;
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var newFrame = (Bitmap)eventArgs.Frame.Clone();
            Invoke(new MethodInvoker(delegate
            {
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                var filter = new Mirror(false, true);
                filter.ApplyInPlace(newFrame);
                pictureBox1.Image = newFrame;
            }));
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            if (_videoDevices.Count == 0)
            {
                MessageBox.Show("Máy bạn không có camera hoặc chưa cắm", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                return;
            }

            foreach (FilterInfo device in _videoDevices) comboBox1.Items.Add(device.Name);
            comboBox1.SelectedIndex = 0;
            _videoSource = new VideoCaptureDevice(_videoDevices[comboBox1.SelectedIndex].MonikerString);
            _videoSource.NewFrame += videoSource_NewFrame;
            _videoSource.Start();
        }

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_videoSource != null)
            {
                _videoSource.SignalToStop();
                _videoSource.NewFrame -= videoSource_NewFrame;
                _videoSource = null;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
                try
                {
                    pictureBox2.Image.Save(Path.Combine(Path.GetTempPath(), "temp.png"));
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
                catch (Exception)
                {
                    MessageBox.Show("Không xem được ảnh");
                }
            else
                MessageBox.Show("Chụp ít nhất 1 ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLHoSoNhanVien.AnhChup.Image = pictureBox2.Image;
            Close();
        }
    }
}