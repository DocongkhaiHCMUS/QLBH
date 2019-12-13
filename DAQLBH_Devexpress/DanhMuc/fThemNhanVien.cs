using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using QLBH_BUS;
using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemNhanVien : fBaseKho_NV_HH
    {
        fNhanVien.sendMessage sendNV;
        DXErrorProvider error = new DXErrorProvider();
        DataTable table;
        CNhanVien editNV = new CNhanVien();
        bool add;
        public fThemNhanVien(bool isAdd = true, CNhanVien nv = null, fNhanVien.sendMessage send = null)
        {
            InitializeComponent();

            if (isAdd == false && nv == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_NhanVien.LayNhanVien();
                Text = "Thêm nhân viên";
            }
            else
            {
                editNV = nv;
                Text = "Sửa thông tin nhân viên";
            }
            add = isAdd;
            sendNV = send;

            Init();
        }

        private void Init()
        {
            LoadDataBP();
            gleBoPhan.Properties.DisplayMember = "Department_Name";
            gleBoPhan.Properties.ValueMember = "Department_ID";
            gleBoPhan.Properties.Buttons[1].Click += btnThemBP_ThemNhanVien_Click;

            gleQuanLy.Properties.DataSource = BUS_NhanVien.LayNhanVienDonGian();
            gleQuanLy.Properties.DisplayMember = "EMPLOYEE_Name";
            gleQuanLy.Properties.ValueMember = "EMPLOYEE_ID";

            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuNV();
        }

        private void LoadDuLieuNV()
        {
            txtMa.Enabled = false;
            txtMa.Text                      = editNV.MaNV         ;
            txtTen.Text                     = editNV.TenNV        ;
            radioGioiTinh.EditValue         = editNV.GioiTinh     ;
            txtDiaChi.Text                  = editNV.DiaChi       ;
            txtDienThoai.Text               = editNV.DienThoai    ;
            txtDiDong.Text                  = editNV.DiDong       ;
            deNgaySinh.EditValue            = editNV.NgaySinh     ;
            gleBoPhan.EditValue             = editNV.BoPhan       ;
            gleQuanLy.EditValue             = editNV.QuanLy       ;
            txtChucVu.Text                  = editNV.ChucVu       ;
            txtEmail.Text                   = editNV.Email        ;
            checkConQL.Checked              = editNV.ConQL        ;
        }

        private void phatSinhMa()
        {
            string max, currentMa;
            int num;
            try
            {

                max = table.Compute("Max(Employee_ID)", "").ToString();
                num = int.Parse(max.Substring(2)) + 1;
                currentMa = "NV" + num.ToString("000000");
                txtMa.Text = currentMa;
            }
            catch
            {
                currentMa = "NV000001";
                txtMa.Text = currentMa;
            }
        }

        private void LoadDataBP()
        {
            gleBoPhan.Properties.DataSource = BUS_NhanVien.LayBoPhan();
        }

        private void btnThemBP_ThemNhanVien_Click(object sender, EventArgs e)
        {
            fThemSimple bp = new fThemSimple(true, null, null, (double)1);
            bp.ShowDialog();
            LoadDataBP();
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
            editNV.MaNV = txtMa.Text;
            editNV.TenNV = txtTen.Text;
            editNV.GioiTinh = bool.Parse(radioGioiTinh.EditValue.ToString());
            editNV.DiaChi = txtDiaChi.Text;
            editNV.DienThoai = txtDienThoai.Text;
            editNV.DiDong = txtDiDong.Text;
            editNV.NgaySinh = (deNgaySinh.Text == "" ? DateTime.Now : DateTime.Parse(deNgaySinh.Text));
            editNV.BoPhan = (gleBoPhan.Text == "" ? "" : gleBoPhan.EditValue.ToString());
            editNV.QuanLy = (gleQuanLy.Text == "" ? "" : gleQuanLy.EditValue.ToString());
            editNV.ChucVu = txtChucVu.Text;
            editNV.Email = txtEmail.Text;
            editNV.ConQL = checkConQL.Checked;
            BUS_NhanVien.SuaNV(editNV);
            sendNV();
            Close();
        }

        private void xlThem()
        {
            CNhanVien nv = new CNhanVien
                (txtMa.Text,
                txtTen.Text,
                bool.Parse(radioGioiTinh.EditValue.ToString()),
                txtDiaChi.Text,
                txtDienThoai.Text,
                txtDiDong.Text,
                (deNgaySinh.Text == "" ? DateTime.Now : DateTime.Parse(deNgaySinh.Text)),
                (gleBoPhan.Text == "" ? "" : gleBoPhan.EditValue.ToString()),
                (gleQuanLy.Text == "" ? "" : gleQuanLy.EditValue.ToString()),
                txtChucVu.Text,
                txtEmail.Text,
                checkConQL.Checked);

            BUS_NhanVien.ThemNV(nv);
            sendNV();
            this.Close();
        }
    }
}
