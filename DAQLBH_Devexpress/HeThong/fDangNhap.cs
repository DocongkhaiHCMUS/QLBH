using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBH_BUS;
using System.Data.SqlClient;
using DevExpress.XtraEditors.DXErrorProvider;

namespace DAQLBH_Devexpress
{
    public partial class fDangNhap : DevExpress.XtraEditors.XtraForm
    {
        bool isHide = true;
        public fDangNhap()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Load += FDangNhap_Load;
            btnThoat.Click += BtnThoat_Click;
            btnDangNhap.Click += BtnDangNhap_Click;
            txtPassword.ButtonClick += TxtPassword_ButtonClick;
            txtPassword.Properties.UseSystemPasswordChar = true;
            InitValidDation();
        }

        private void InitValidDation()
        {
            ConditionValidationRule rule = new ConditionValidationRule();
            rule.ConditionOperator = ConditionOperator.IsNotBlank;
            rule.ErrorText = "Không được bỏ trống !";

            dxValidationProvider1.SetValidationRule(cbTaiKhoan, rule);
            dxValidationProvider1.SetValidationRule(txtPassword, rule);
        }
        private void LoadUserName()
        {
            DataTable dt = BUS_TaiKhoan.LayTenUser();
            foreach (DataRow row in dt.Rows)
            {
                cbTaiKhoan.Properties.Items.Add(row["UserName"]);
            }
        }
        private void FDangNhap_Load(object sender, EventArgs e)
        {
            LoadUserName();
        }
        private void TxtPassword_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            isHide = (!isHide);
            if (isHide == true)
            {
                txtPassword.Properties.Buttons[0].ImageOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.hide_16x16;
                txtPassword.Properties.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.Properties.Buttons[0].ImageOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.show_16x16;
                txtPassword.Properties.UseSystemPasswordChar = false;
            }
        }
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;
            try
            {
                string NameUser = BUS_TaiKhoan.getInfo(cbTaiKhoan.Text, txtPassword.Text, "UserName");
                if(NameUser != "")
                {
                    fMain Main = new fMain();
                    Main.ShowDialog();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Tài khoản hoặc mật khẩu không đúng \r\nVui lòng đăng nhập lại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbTaiKhoan.Text = null;
                    txtPassword.Text = null;
                    cbTaiKhoan.Focus();
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn thoát ứng dụng ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Dispose();
            else
                return;
        }
    }
}