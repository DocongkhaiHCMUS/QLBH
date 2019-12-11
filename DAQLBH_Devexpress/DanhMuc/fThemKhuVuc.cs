using System;
using System.Data;
using QLBH_BUS;
using QLBH_DTO;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemSimple : fBaseThem
    {
        fKhuVuc.sendMessage sendKV;
        fDonViTinh.sendMessage senDV;
        fNhomHang.sendMessage sendNH;
        fBoPhan.sendMessage sendBP;

        DXErrorProvider error = new DXErrorProvider();
        DataTable table;
        CKhuVuc editKV = new CKhuVuc();
        CDonViTinh editDV = new CDonViTinh();
        CNhomHang editNH = new CNhomHang();
        CBoPhan editBP = new CBoPhan();
        bool add;


        public fThemSimple(bool isAdd = true, CKhuVuc kv = null,fKhuVuc.sendMessage send = null)
        {
            InitializeComponent();

            if (isAdd == false && kv == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_KhuVuc.KhuVuc();
                Text = "Thêm khu vực";
            }
            else
            {
                editKV = kv;
                Text = "Sửa thông tin khu vực";
            }
            add = isAdd;
            sendKV = send;

            InitKV();
        }

        public fThemSimple(bool isAdd = true, CDonViTinh dv = null, fDonViTinh.sendMessage send = null,int action = 1)
        { 

        }

        public fThemSimple(bool isAdd = true, CNhomHang nh = null, fNhomHang.sendMessage send = null,float action = 1)
        {

        }

        public fThemSimple(bool isAdd = true, CBoPhan bp = null, fBoPhan.sendMessage send = null,double action = 1)
        {

        }

        private void InitKV()
        {
            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuKV();

        }

        /// <summary>
        /// Hàm lấy dữ liệu đối tượng truyền vào load lên các control trong trường hợp sửa đối tượng
        /// </summary>
        private void LoadDuLieuKV()
        {
            txtMa.Text = editKV.MaKV;
            txtMa.Enabled = false;
            txtTen.Text = editKV.TenKV;
            txtGhiChu.Text = editKV.GhiChu;
            ceConQL.Checked = editKV.ConQL;
        }

        /// <summary>
        /// Hàm dùng để phát sinh mã trong trường hợp thêm đối tượng
        /// </summary>
        private void phatSinhMa()
        {
            string max = table.Compute("Max(CUSTOMER_GROUP_ID)", "").ToString();
            int num = int.Parse(max.Substring(2)) + 1;
            string currentMa = "KV" + num.ToString("000000");
            txtMa.Text = currentMa;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (add == true)
                xlThem();
            else
                xlSua();
        }

        /// <summary>
        /// Hàm xử lý việc sửa thông tin
        /// </summary>
        private void xlSua()
        {
            if (txtTen.Text == "")
            {
                error.SetError(txtTen, "Vui lòng điền thông tin !");
            }
            else
            {
                error.SetError(txtTen, string.Empty);
            }

            if (error.GetError(txtTen) == string.Empty)
            {
                editKV.TenKV = txtTen.Text;
                editKV.GhiChu = txtGhiChu.Text;
                editKV.ConQL = ceConQL.Checked;
                BUS_KhuVuc.SuaKV(editKV);
                sendKV();
                this.Close();
            }
        }

        /// <summary>
        /// Hàm xử lý việc thêm đối tượng
        /// </summary>
        private void xlThem()
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
            else if (BUS_KhuVuc.KiemTraKV(txtMa.Text))
            {
                error.SetError(txtMa, "Mã đã tồn tại, vui lòng chọn giá trị khác !");
            }
            else
            {
                error.SetError(txtMa, string.Empty);
            }

            if (error.GetError(txtMa) == string.Empty && error.GetError(txtTen) == string.Empty)
            {
                CKhuVuc kv = new CKhuVuc(txtMa.Text, txtTen.Text, txtGhiChu.Text, ceConQL.Checked);
                BUS_KhuVuc.ThemKV(kv);
                sendKV();
                this.Close();
            }
        }
    }
}