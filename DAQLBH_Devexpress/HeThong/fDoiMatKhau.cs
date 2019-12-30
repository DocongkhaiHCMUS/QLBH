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
using QLBH_BUS;

namespace DAQLBH_Devexpress.HeThong
{
    public partial class fDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public fDoiMatKhau()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            txtMatKhauCu.Properties.UseSystemPasswordChar = true;
            txtMatKhauMoi.Properties.UseSystemPasswordChar = true;
            txtXacNhanMatKhauMoi.Properties.UseSystemPasswordChar = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMatKhauCu.Text != fDangNhap.Password)
            {
                XtraMessageBox.Show("Mật Khẩu cũ không đúng !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtMatKhauMoi.Text != txtXacNhanMatKhauMoi.Text)
            {
                XtraMessageBox.Show("Xác nhận mật khẩu không khớp ! !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BUS_TaiKhoan.DoiMatKhau(fDangNhap.userID, txtMatKhauMoi.Text);

            Action.Module = "Đổi Mật Khẩu";
            Action.ActionName = "Thực Hiện";
            Action.LuuThongTin();

            Close();
        }
    }
}