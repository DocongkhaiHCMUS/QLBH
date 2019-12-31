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
using DevExpress.XtraEditors.Controls;
using QLBH_BUS;
using QLBH_DTO;

namespace DAQLBH_Devexpress.HeThong
{
    public partial class fSuaNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        string Ma;
        bool add;
        CUser editUser = new CUser();
        public fSuaNguoiDung(bool isAdd = true,CUser us = null)
        {
            InitializeComponent();
            if (isAdd == false && us == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                Text = "Thêm Người Dùng";
            }
            else
            {
                editUser = us;
                Text = "Sửa thông tin người dùng";
            }
            add = isAdd;
            Init();

        }

        void SetDataSource(object control, DataTable data, string displayMember, string valueMember)
        {
            if (control is LookUpEdit)
            {
                LookUpEdit t = control as LookUpEdit;
                t.Properties.DataSource = data;
                t.Properties.DisplayMember = displayMember;
                t.Properties.ValueMember = valueMember;
            }
        }

        private void Init()
        {
            txtPass.Properties.UseSystemPasswordChar = true;
            txtXacNhan.Properties.UseSystemPasswordChar = true;

            //Khởi tạo nhân viên bán hàng
            leNhanVien.Properties.TextEditStyle = TextEditStyles.Standard;
            leNhanVien.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leNhanVien, BUS_NhanVien.LayNhanVienDonGian(), "EMPLOYEE_Name", "EMPLOYEE_ID");
            leNhanVien.Properties.Columns[0].FieldName = "EMPLOYEE_Name";
            leNhanVien.Properties.Columns[1].FieldName = "EMPLOYEE_ID";

            //Khởi tạo vai trò
            leVaiTro.Properties.TextEditStyle = TextEditStyles.Standard;
            leVaiTro.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leVaiTro, BUS_PhanQuyen.LoadPermision(), "Description", "ID");
            leVaiTro.Properties.Columns[0].FieldName = "ID";
            leVaiTro.Properties.Columns[1].FieldName = "Description";


            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuBP();
        }

        private void LoadDuLieuBP()
        {
            leNhanVien.EditValue = editUser.PartID;
            txtUserName.Text = editUser.UserName;
            txtUserName.Enabled = false;
            txtPass.Text = editUser.Password;
            txtXacNhan.Text = editUser.Password;
            leVaiTro.EditValue = editUser.GroupID;
            txtDienGiai.Text = editUser.Description;
            checkConQL.Checked = editUser.Active;
        }

        private void phatSinhMa()
        {
            DataTable table = BUS_PhanQuyen.LoadUser();
            var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("UserID").Contains("US")
                        select new
                        {
                            maND = tb.Field<string>("UserID")
                        };

            DataTable dttb = new DataTable();
            dttb.Columns.Add("UserID", typeof(string));

            foreach (var item in query)
            {
                dttb.Rows.Add(item.maND);
            }

            string max, currentMa;
            int num;
            try
            {

                max = dttb.Compute("Max(UserID)", "").ToString();
                num = int.Parse(max.Substring(2)) + 1;
                currentMa = "US" + num.ToString("000000");
                Ma = currentMa;
            }
            catch
            {
                currentMa = "US000001";
                Ma = currentMa;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="")
            {
                XtraMessageBox.Show("Tên đăng nhập không được để trống", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPass.Text == ""||txtXacNhan.Text=="")
            {
                XtraMessageBox.Show("Mật Khẩu không được để trống", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (leVaiTro.Text=="")
            {
                XtraMessageBox.Show("vai trò không được để trống", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (add == true)
                xlThem();
            else
                xlSua();
        }

        private void xlSua()
        {
            editUser.UserName = txtUserName.Text;
            editUser.Password = txtPass.Text;
            editUser.GroupID = leVaiTro.EditValue.ToString();
            editUser.PartID = leNhanVien.Text == "" ? "" : leNhanVien.EditValue.ToString();
            editUser.Description = txtDienGiai.Text;
            editUser.Active = checkConQL.Checked;
            BUS_PhanQuyen.SuaUser(editUser);

            Action.Module = "Người Dùng";
            Action.ActionName = "Sửa";
            Action.Reference = Ma;
            Action.LuuThongTin();

            Close();
        }

        private void xlThem()
        {
            editUser.UserID = Ma;
            editUser.UserName = txtUserName.Text;
            editUser.Password = txtPass.Text;
            editUser.GroupID = leVaiTro.EditValue.ToString();
            editUser.PartID = leNhanVien.Text == "" ? "" : leNhanVien.EditValue.ToString();
            editUser.Description = txtDienGiai.Text;
            editUser.Active = checkConQL.Checked;
            BUS_PhanQuyen.ThemUser(editUser);

            Action.Module = "Người Dùng";
            Action.ActionName = "Thêm";
            Action.Reference = Ma;
            Action.LuuThongTin();

            Close();
        }
    }
}