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
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            GiaoDienChinh.Luongcoso = txtLuongcoso.Text;
            MessageBox.Show("Cập nhật mặc định thành công!","Thông báo");
        }
    }
}
