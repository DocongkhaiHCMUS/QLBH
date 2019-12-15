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
using DevExpress.XtraEditors.DXErrorProvider;
using QLBH_DTO;
using QLBH_BUS;
using DevExpress.XtraEditors.Controls;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemNCC : fBaseKH_NCC
    {
        fNhaCC.sendMessage sendNCC;
        DXErrorProvider error = new DXErrorProvider();
        DataTable table;
        CNhaCC editNCC = new CNhaCC();
        bool add;

        public fThemNCC(bool isAdd = true, CNhaCC ncc = null, fNhaCC.sendMessage send = null)
        {
            InitializeComponent();

            if (isAdd == false && ncc == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_NhaCungCap.LayNhaCC();
                Text = "Thêm nhà cung cấp";
            }
            else
            {
                editNCC = ncc;
                Text = "Sửa thông tin nhà cung cấp";
            }
            add = isAdd;
            sendNCC = send;

            Init();
        }

        private void Init()
        {
            LoadDataKV();
            leKhuVuc.Properties.DisplayMember = "CUSTOMER_GROUP_Name";
            leKhuVuc.Properties.ValueMember = "CUSTOMER_GROUP_ID";
            LookUpColumnInfo col = new LookUpColumnInfo("CUSTOMER_GROUP_ID", "Mã");
            LookUpColumnInfo col1 = new LookUpColumnInfo("CUSTOMER_GROUP_Name", "Tên");
            leKhuVuc.Properties.Columns.Add(col);
            leKhuVuc.Properties.Columns.Add(col1);
            leKhuVuc.Properties.Buttons[1].Click += btnKhuVuc_ThemKhachHang_Click;

            txtNickYahoo.Visible = false;
            calcNoHienTai.Enabled = false;
            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuNCC();
        }

        private void LoadDuLieuNCC()
        {
            txtMa.Text = editNCC.MaNCC;
            txtMa.Enabled = true;
            txtTen.Text = editNCC.TenNCC;
            txtDiaChi.Text = editNCC.DiaChi;
            leKhuVuc.EditValue = editNCC.KhuVuc;
            txtMaSoThue.Text = editNCC.MaSoThue;
            txtDienThoai.Text = editNCC.DienThoai;
            txtEmail.Text = editNCC.Email;
            txtTaiKhoan.Text = editNCC.TaiKhoan;
            calcGioiHanNo.Value = decimal.Parse(editNCC.GioiHanNo.ToString());
            calcChietKhau.Value = decimal.Parse(editNCC.ChietKhau.ToString());
            txtNguoiLienHe.Text = editNCC.LienHe;
            txtFax.Text = editNCC.Fax;
            txtMobile.Text = editNCC.DiDong;
            txtWebsite.Text = editNCC.Website;
            txtNganHang.Text = editNCC.NganHang;
            txtNickSkype.Text = editNCC.ChucVu;
            checkConQL.Checked = editNCC.ConQL;
        }

        private void phatSinhMa()
        {
            var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("Customer_ID").Contains("NCC")
                        select new
                        {
                            maNCC = tb.Field<string>("Customer_ID")
                        };

            DataTable dttb = new DataTable();
            dttb.Columns.Add("Customer_ID", typeof(string));

            foreach (var item in query)
            {
                dttb.Rows.Add(item.maNCC);
            }

            string max, currentMa;
            int num;
            try
            {

                max = dttb.Compute("Max(Customer_ID)", "").ToString();
                num = int.Parse(max.Substring(3)) + 1;
                currentMa = "NCC" + num.ToString("000000");
                txtMa.Text = currentMa;
            }
            catch
            {
                currentMa = "NCC000001";
                txtMa.Text = currentMa;
            }
        }

        private void LoadDataKV()
        {
            leKhuVuc.Properties.DataSource = BUS_KhuVuc.KhuVuc();
        }

        private void btnKhuVuc_ThemKhachHang_Click(object sender, EventArgs e)
        {
            fThemSimple kv = new fThemSimple(true, null, null);
            kv.ShowDialog();
            LoadDataKV();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                error.SetError(txtTen, "Vui lòng điền thông tin !");
            }
            else
            {
                error.SetError(txtTen, string.Empty);
            }

            if (txtMa.Text == "")
            {
                error.SetError(txtMa, "Vui lòng điền thông tin !");
            }
            else if (add == true && BUS_KhachHang.KiemTraKH(txtMa.Text))
            {
                error.SetError(txtMa, "Mã đã tồn tại, vui lòng chọn mã khác !");
            }
            else
            {
                error.SetError(txtMa, string.Empty);
            }

            if (leKhuVuc.Text == "")
            {
                error.SetError(leKhuVuc, "Vui lòng chọn khu vực !");
            }
            else
            {
                error.SetError(txtMa, string.Empty);
            }
            if (error.GetError(txtMa) == "" && error.GetError(txtTen) == "")
            {
                if (add == true)
                    xlThem();
                else
                    xlSua();
            }
        }

        private void xlThem()
        {
            CNhaCC ncc = new CNhaCC(txtMa.Text, txtTen.Text, leKhuVuc.EditValue.ToString(), txtDiaChi.Text, txtMaSoThue.Text,
                                           txtDienThoai.Text, txtFax.Text, txtEmail.Text, txtMobile.Text, txtWebsite.Text, txtNguoiLienHe.Text,
                                           txtNickSkype.Text, txtTaiKhoan.Text, txtNganHang.Text,
                                           (calcGioiHanNo.Text == "" ? 0 : float.Parse(calcGioiHanNo.Value.ToString())),
                                           (calcChietKhau.Text == "" ? 0 : float.Parse(calcChietKhau.Value.ToString())),
                                           checkConQL.Checked);
            BUS_NhaCungCap.ThemNCC(ncc);
            sendNCC?.Invoke();
            this.Close();
        }

        private void xlSua()
        {
            editNCC.MaNCC = txtMa.Text;
            editNCC.TenNCC = txtTen.Text;
            editNCC.DiaChi = txtDiaChi.Text;
            editNCC.KhuVuc = leKhuVuc.EditValue.ToString();
            editNCC.MaSoThue = txtMaSoThue.Text;
            editNCC.DienThoai = txtDienThoai.Text;
            editNCC.Email = txtEmail.Text;
            editNCC.TaiKhoan = txtTaiKhoan.Text;
            editNCC.GioiHanNo = (calcGioiHanNo.Text == "" ? 0 : float.Parse(calcGioiHanNo.Text));
            editNCC.ChietKhau = (calcChietKhau.Text == "" ? 0 : float.Parse(calcChietKhau.Text));
            editNCC.LienHe = txtNguoiLienHe.Text;
            editNCC.Fax = txtFax.Text;
            editNCC.DiDong = txtMobile.Text;
            editNCC.Website = txtWebsite.Text;
            editNCC.NganHang = txtNganHang.Text;
            editNCC.ChucVu = txtNickSkype.Text;
            editNCC.ConQL = checkConQL.Checked;
            BUS_NhaCungCap.SuaNCC(editNCC);
            sendNCC();
            this.Close();
        }
    }
}