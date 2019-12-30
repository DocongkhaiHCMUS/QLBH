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
        bool xoa;
        public fLuaChon(bool isDel = true)
        {
            InitializeComponent();
            if (isDel == true)
            {
                btnQuyen.Visible = false;
                labelControl1.Text = "Bạn Muốn Xóa ?";
            }
            else
            {
                labelControl1.Text = "Bạn Muốn Sửa ?";
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