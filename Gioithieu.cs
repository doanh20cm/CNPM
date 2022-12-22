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
    public partial class Gioithieu : Form
    {
        static int i = 0;
        Bitmap[] mang = new Bitmap[] { Properties.Resources.anh1, Properties.Resources.anh2, Properties.Resources.anh3, Properties.Resources.anh4 };

        public Gioithieu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image.Dispose();
            pictureBox2.Image = new Bitmap(mang[i % 4]);
            i++;
        }

    }
}
