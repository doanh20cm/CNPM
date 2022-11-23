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
    public partial class ThongKeLuong : Form
    {
        public ThongKeLuong()
        {
            InitializeComponent();
        }

        private void ThongKeLuong_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}
