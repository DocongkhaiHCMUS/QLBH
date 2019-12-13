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
using QLBH_DAO;
using QLBH_DTO;
using QLBH_BUS;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemKhachHang : fBaseKH_NCC
    {
        fKhachHang.SendMessage sendKH;
        DXErrorProvider error = new DXErrorProvider();
        DataTable table;
        CKhachHang editKhachHang = new CKhachHang();
        bool add;

        public fThemKhachHang(bool isAdd = true, CKhachHang kh = null, fKhachHang.SendMessage send = null)
        {
            InitializeComponent();

            if (isAdd == false && kh == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_KhachHang.LayKhachHang();
                Text = "Thêm khách hàng";
            }
            else
            {
                editKhachHang = kh;
                Text = "Sửa thông tin khách hàng";
            }
            add = isAdd;
            sendKH = send;

            Init();
        }

        private void Init()
        {
            LoadDataKV();
            leKhuVuc.Properties.DisplayMember = "CUSTOMER_GROUP_Name";
            leKhuVuc.Properties.ValueMember = "CUSTOMER_GROUP_ID";
            leKhuVuc.Properties.Columns[0].FieldName = "CUSTOMER_GROUP_ID";
            leKhuVuc.Properties.Columns[1].FieldName = "CUSTOMER_GROUP_Name";
            leKhuVuc.Properties.Buttons[1].Click += btnKhuVuc_ThemKhachHang_Click;

            calcNoHienTai.Enabled = false;

            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuKH();
        }

        private void LoadDataKV()
        {
            leKhuVuc.Properties.DataSource = BUS_KhuVuc.KhuVuc();
        }

        private void btnKhuVuc_ThemKhachHang_Click(object sender, EventArgs e)
        {
            fThemSimple kv = new fThemSimple(true, null, null) ;
            kv.ShowDialog();
            LoadDataKV();
        }

        private void LoadDuLieuKH()
        {
            txtMa.Text = editKhachHang.MaKH;
            txtMa.Enabled = true;
            txtTen.Text = editKhachHang.TenKH;
            txtDiaChi.Text = editKhachHang.DiaChi;
            leKhuVuc.EditValue = editKhachHang.KhuVuc;
            txtMaSoThue.Text = editKhachHang.MaSoThue;
            txtDienThoai.Text = editKhachHang.DienThoai;
            txtEmail.Text = editKhachHang.Email;
            txtTaiKhoan.Text = editKhachHang.TaiKhoan;
            calcGioiHanNo.Value = decimal.Parse(editKhachHang.GioiHanNo.ToString());
            calcChietKhau.Value = decimal.Parse(editKhachHang.ChietKhau.ToString());
            txtNguoiLienHe.Text = editKhachHang.LienHe;
            txtFax.Text = editKhachHang.Fax;
            txtMobile.Text = editKhachHang.DiDong;
            txtWebsite.Text = editKhachHang.Website;
            txtNganHang.Text = editKhachHang.NganHang;
            txtNickYahoo.Text = editKhachHang.NickYM;
            txtNickSkype.Text = editKhachHang.NickSky;
            checkConQL.Checked = editKhachHang.ConQL;
            radioLoaiKH.EditValue = editKhachHang.LoaiKH;
        }

        private void phatSinhMa()
        {
            string max = table.Compute("Max(Customer_ID)", "").ToString();
            int num = int.Parse(max.Substring(2)) + 1;
            string currentMa = "KH" + num.ToString("000000");
            txtMa.Text = currentMa;
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

            if(leKhuVuc.Text == "")
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

        private void xlSua()
        {
            editKhachHang.MaKH = txtMa.Text;
            editKhachHang.TenKH = txtTen.Text;
            editKhachHang.DiaChi = txtDiaChi.Text;
            editKhachHang.KhuVuc = leKhuVuc.EditValue.ToString();
            editKhachHang.MaSoThue = txtMaSoThue.Text;
            editKhachHang.DienThoai = txtDienThoai.Text;
            editKhachHang.Email = txtEmail.Text;
            editKhachHang.TaiKhoan = txtTaiKhoan.Text;
            editKhachHang.GioiHanNo = (calcGioiHanNo.Text == ""? 0 : float.Parse(calcGioiHanNo.Text));
            editKhachHang.ChietKhau = (calcChietKhau.Text == "" ? 0 : float.Parse(calcChietKhau.Text));
            editKhachHang.LienHe = txtNguoiLienHe.Text;
            editKhachHang.Fax = txtFax.Text;
            editKhachHang.DiDong = txtMobile.Text;
            editKhachHang.Website = txtWebsite.Text;
            editKhachHang.NganHang = txtNganHang.Text;
            editKhachHang.NickYM = txtNickYahoo.Text;
            editKhachHang.NickSky = txtNickSkype.Text;
            editKhachHang.ConQL = checkConQL.Checked;
            editKhachHang.LoaiKH = bool.Parse(radioLoaiKH.EditValue.ToString());
            BUS_KhachHang.SuaKH(editKhachHang);
            sendKH();
            this.Close();
        }

        private void xlThem()
        {
            CKhachHang kh = new CKhachHang(txtMa.Text, txtTen.Text,bool.Parse(radioLoaiKH.EditValue.ToString()),leKhuVuc.EditValue.ToString(),txtDiaChi.Text,txtMaSoThue.Text,
                                           txtDienThoai.Text,txtFax.Text,txtEmail.Text,txtMobile.Text,txtWebsite.Text,txtNguoiLienHe.Text,
                                           txtNickYahoo.Text,txtNickSkype.Text,txtTaiKhoan.Text,txtNganHang.Text,
                                           (calcGioiHanNo.Text == ""? 0 : float.Parse(calcGioiHanNo.Value.ToString())),
                                           (calcChietKhau.Text == "" ? 0 : float.Parse(calcChietKhau.Value.ToString())),
                                           checkConQL.Checked);
            BUS_KhachHang.ThemKH(kh);
            sendKH();
            this.Close();
        }
    }
}