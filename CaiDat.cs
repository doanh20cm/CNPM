using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Quan_li_nhan_su
{
    public partial class CaiDat : Form
    {
        private static readonly byte[] Key = Encoding.ASCII.GetBytes("VTFlZUlncTgrZz09");
        private static readonly byte[] Iv = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");

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

        public CaiDat()
        {
            InitializeComponent();
        }

        private static void EncryptString_Aes(string plainText, byte[] key, byte[] iv)
        {
            byte[] encrypted;
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            File.WriteAllBytes("config.bin", encrypted);
        }

        private void btnApplyConfig_Click(object sender, EventArgs e)
        {
            try
            {
                GiaoDienChinh.ConnStr =
                    $@"Data Source={txtIP.Text}\SQLEXPRESS,{numPort.Value};Initial Catalog={txtDatabase.Text};UID={txtUsername.Text};PWD={txtPassword.Text}";
                EncryptString_Aes(GiaoDienChinh.ConnStr, Key, Iv);
                MessageBox.Show(@"Áp dụng cấu hình thành công!", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể áp dụng cấu hình mới!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            Enabled = false;

            var bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            var workerTimer = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            bw.ProgressChanged += (sender3, e3) =>
            {
                progressBar1.Value = e3.ProgressPercentage;
                label7.Text = e3.ProgressPercentage + "%";
            };
            bw.DoWork += (sender1, e1) =>
            {
                var conn = new SqlConnection(GiaoDienChinh.ConnStr);
                conn.Open();
                e1.Result = conn;
            };
            bw.RunWorkerCompleted += (sender4, e4) =>
            {
                workerTimer.CancelAsync();
                Enabled = true;
                Focus();
                if (e4.Error != null)
                {
                    MessageBox.Show("Không thể kết nối đến máy chủ!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ((SqlConnection)e4.Result).Close();
                }

                label7.Text = "Chờ kiểm tra...";
                progressBar1.Value = 0;
            };
            bw.RunWorkerAsync();
            workerTimer.DoWork += (sender2, e2) =>
            {
                for (var i = 0; i < 15; i++)
                {
                    if (workerTimer.CancellationPending)
                    {
                        e2.Cancel = true;
                        return;
                    }

                    bw.ReportProgress(i * 100 / 15);
                    Thread.Sleep(1000);
                }

                bw.ReportProgress(100);
            };
            workerTimer.RunWorkerAsync();
        }
    }
}