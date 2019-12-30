using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DAQLBH_Devexpress.HeThong
{
    public partial class fLuaChon : DevExpress.XtraEditors.XtraForm
    {
        public fLuaChon(int isDel = 1)
        {
            InitializeComponent();
            if (isDel == 1)
            {
                labelControl1.Text = "Bạn Muốn Xóa ?";
            }
            else if(isDel == 2)
            {
                labelControl1.Text = "Bạn Muốn Sửa ?";
            }
            else
            {
                labelControl1.Text = "Bạn Muốn Thêm ?";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuyenHan_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVaiTro_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuyen_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}