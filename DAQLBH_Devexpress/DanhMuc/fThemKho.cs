using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using QLBH_DTO;
using QLBH_BUS;
using DevExpress.XtraEditors.Controls;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemKho : fBaseKho_NV_HH
    {
        fKhoHang.sendMessage sendKho;
        DXErrorProvider error = new DXErrorProvider();
        DataTable table;
        CKho editKho = new CKho();
        bool add;
        public fThemKho(bool isAdd = true, CKho kho = null, fKhoHang.sendMessage send = null)
        {
            InitializeComponent();

            if (isAdd == false && kho == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_KhoXuat.LayKho();
                Text = "Thêm nhà cung cấp";
            }
            else
            {
                editKho = kho;
                Text = "Sửa thông tin nhà cung cấp";
            }
            add = isAdd;
            sendKho = send;

            Init();
        }

        private void Init()
        {
            leNguoiQL.Properties.DataSource = BUS_NhanVien.LayNhanVienDonGian();
            leNguoiQL.Properties.DisplayMember = "EMPLOYEE_Name";
            leNguoiQL.Properties.ValueMember = "EMPLOYEE_ID";
            LookUpColumnInfo col = new LookUpColumnInfo("EMPLOYEE_ID", "Mã");
            LookUpColumnInfo col1 = new LookUpColumnInfo("EMPLOYEE_Name", "Tên");
            leNguoiQL.Properties.Columns.Add(col1);
            leNguoiQL.Properties.Columns.Add(col);

            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuKho();
        }

        private void LoadDuLieuKho()
        {
            txtMa.Enabled = false;
            txtMa.Text = editKho.MaKho;
            txtTen.Text = editKho.TenKho;
            txtLienHe.Text = editKho.LienHe;
            txtDiaChi.Text = editKho.DiaChi;
            txtEmail.Text = editKho.Email;
            txtDienThoai.Text = editKho.DienThoai;
            txtFax.Text = editKho.Fax;
            leNguoiQL.EditValue = editKho.NguoiQuanLy;
            txtDienGiai.Text = editKho.DienGiai;
            checkConQL.Checked = editKho.ConQL;
        }

        private void phatSinhMa()
        {
            var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("Stock_ID").Contains("K")
                        select new
                        {
                            maKho = tb.Field<string>("Stock_ID")
                        };

            DataTable dttb = new DataTable();
            dttb.Columns.Add("Stock_ID", typeof(string));

            foreach (var item in query)
            {
                dttb.Rows.Add(item.maKho);
            }
            string max, currentMa;
            int num;
            try
            {

                max = dttb.Compute("Max(Stock_ID)", "").ToString();
                num = int.Parse(max.Substring(1)) + 1;
                currentMa = "K" + num.ToString("000000");
                txtMa.Text = currentMa;
            }
            catch
            {
                currentMa = "K000001";
                txtMa.Text = currentMa;
            }
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
            editKho.MaKho = txtMa.Text;
            editKho.TenKho = txtTen.Text;
            editKho.LienHe = txtLienHe.Text;
            editKho.DiaChi = txtDiaChi.Text;
            editKho.Email = txtEmail.Text;
            editKho.DienThoai = txtDienThoai.Text;
            editKho.Fax = txtFax.Text;
            editKho.NguoiQuanLy = leNguoiQL.EditValue.ToString();
            editKho.DienGiai = txtDienGiai.Text;
            editKho.ConQL = checkConQL.Checked;

            BUS_KhoXuat.SuaKho(editKho);
            sendKho();
            this.Close();
        }

        private void xlThem()
        {
            CKho kho = new CKho
                (txtMa.Text,
                txtTen.Text,
                txtLienHe.Text,
                txtDiaChi.Text,
                txtEmail.Text,
                txtDienThoai.Text,
                txtFax.Text,
                "",
                leNguoiQL.EditValue.ToString(),
                txtDienGiai.Text,
                checkConQL.Checked);

            BUS_KhoXuat.ThemKho(kho);
            sendKho();
            this.Close();
        } 
    }
}