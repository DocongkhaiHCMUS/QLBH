using System;
using System.Data;
using QLBH_BUS;
using QLBH_DTO;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemSimple : fBaseThem
    {
        int flag = 0;
        fKhuVuc.sendMessage sendKV;
        fDonViTinh.sendMessage sendDV;
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

            flag = 0;

            InitKV();
        }

        public fThemSimple(bool isAdd = true, CDonViTinh dv = null, fDonViTinh.sendMessage send = null,int action = 1)
        {
            InitializeComponent();

            if (isAdd == false && dv == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_DonViTinh.GetDVT();
                Text = "Thêm đơn vị tính";
            }
            else
            {
                editDV = dv;
                Text = "Sửa thông tin đơn vị tính";
            }
            add = isAdd;
            sendDV = send;

            flag = 1;

            InitDV();
        }

        public fThemSimple(bool isAdd = true, CNhomHang nh = null, fNhomHang.sendMessage send = null, float action = 1)
        {
            InitializeComponent();

            if (isAdd == false && nh == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_HangHoa.LayNhomHang();
                Text = "Thêm nhóm hàng";
            }
            else
            {
                editNH = nh;
                Text = "Sửa thông tin nhóm hàng";
            }
            add = isAdd;
            sendNH = send;

            flag = 2;

            InitNH();
        }

        public fThemSimple(bool isAdd = true, CBoPhan bp = null, fBoPhan.sendMessage send = null, double action = 1)
        {
            InitializeComponent();

            if (isAdd == false && bp == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_NhanVien.LayBoPhan();
                Text = "Thêm bộ phận";
            }
            else
            {
                editBP = bp;
                Text = "Sửa thông tin bộ phận";
            }
            add = isAdd;
            sendBP = send;

            flag = 3;

            InitBP();
        }

        private void InitBP()
        {
            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuBP();
        }

        private void LoadDuLieuBP()
        {
            txtMa.Text = editBP.MaBP;
            txtMa.Enabled = false;
            txtTen.Text = editBP.TenBP;
            txtGhiChu.Text = editBP.GhiChu;
            ceConQL.Checked = editBP.ConQL;
        }

        private void InitNH()
        {
            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuNH();
        }

        private void LoadDuLieuNH()
        {
            txtMa.Text = editNH.MaNH;
            txtMa.Enabled = false;
            txtTen.Text = editNH.TenNH;
            txtGhiChu.Text = editNH.GhiChu;
            ceConQL.Checked = editNH.ConQL;
        }

        private void InitDV()
        {
            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuDV();
        }

        private void LoadDuLieuDV()
        {
            txtMa.Text = editDV.MaDV;
            txtMa.Enabled = false;
            txtTen.Text = editDV.TenDV;
            txtGhiChu.Text = editDV.GhiChu;
            ceConQL.Checked = editDV.ConQL;
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
            switch (flag)
            {
                case 0:
                    MaKV(); break;
                case 1:
                    MaDV(); break;
                case 2:
                    MaNH();break;
                case 3:
                    MaBP();break;
            };
        }

        private void MaBP()
        {
            var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("Department_ID").Contains("BP")
                        select new
                        {
                            maNH = tb.Field<string>("Department_ID")
                        };

            DataTable dttb = new DataTable();
            dttb.Columns.Add("ProductGroup_ID", typeof(string));

            foreach (var item in query)
            {
                dttb.Rows.Add(item.maNH);
            }

            string max, currentMa;
            int num;
            try
            {

                max = table.Compute("Max(@Department_ID)", "").ToString();
                num = int.Parse(max.Substring(2)) + 1;
                currentMa = "BP" + num.ToString("000000");
                txtMa.Text = currentMa;
            }
            catch
            {
                currentMa = "BP000001";
                txtMa.Text = currentMa;
            }
        }

        private void MaNH()
        {
            var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("ProductGroup_ID").Contains("NH")
                        select new 
                        {
                            maNH = tb.Field<string>("ProductGroup_ID")
                        };

            DataTable dttb = new DataTable();
            dttb.Columns.Add("ProductGroup_ID", typeof(string));

            foreach (var item in query)
            {
                dttb.Rows.Add(item.maNH);
            }

            string max, currentMa;
            int num;
            try
            {
                max = dttb.Compute("Max(ProductGroup_ID)", "").ToString();
                num = int.Parse(max.Substring(2)) + 1;
                currentMa = "NH" + num.ToString("000000");
                txtMa.Text = currentMa;
            }
            catch
            {
                currentMa = "NH000001";
                txtMa.Text = currentMa;
            }
        }

        private void MaDV()
        {
            string max = table.Compute("Max(Unit_ID)", "").ToString();
            int num = int.Parse(max.Substring(2)) + 1;
            string currentMa = "DV" + num.ToString("00");
            txtMa.Text = currentMa;
        }

        private void MaKV()
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
                switch (flag)
                {
                    case 0:
                        SuaKV(); break;
                    case 1:
                        SuaDV();break;
                    case 2:
                        SuaNH();break;
                    case 3:
                        SuaBP();break;
                };
            }
        }

        private void SuaBP()
        {
            editBP.TenBP = txtTen.Text;
            editBP.GhiChu = txtGhiChu.Text;
            editBP.ConQL = ceConQL.Checked;
            BUS_NhanVien.SuaBP(editBP);
            sendBP();
            Close();
        }

        private void SuaNH()
        {
            editNH.TenNH = txtTen.Text;
            editNH.GhiChu = txtGhiChu.Text;
            editNH.ConQL = ceConQL.Checked;
            BUS_HangHoa.SuaNH(editNH);
            sendNH();
            Close();
        }

        private void SuaDV()
        {
            editDV.TenDV = txtTen.Text;
            editDV.GhiChu = txtGhiChu.Text;
            editDV.ConQL = ceConQL.Checked;
            BUS_DonViTinh.SuaDV(editDV);
            sendDV();
            this.Close();
        }

        private void SuaKV()
        {
            editKV.TenKV = txtTen.Text;
            editKV.GhiChu = txtGhiChu.Text;
            editKV.ConQL = ceConQL.Checked;
            BUS_KhuVuc.SuaKV(editKV);
            sendKV();
            this.Close();
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
                switch (flag)
                {
                    case 0:
                        ThemKV(); break;
                    case 1:
                        ThemDV(); break;
                    case 2:
                        ThemNH();break;
                    case 3:
                        ThemBP();break;
                };
            }
        }

        private void ThemBP()
        {
            CBoPhan bp = new CBoPhan(txtMa.Text, txtTen.Text, txtGhiChu.Text, ceConQL.Checked);
            BUS_NhanVien.ThemBP(bp);
            sendBP();
            this.Close();
        }

        private void ThemNH()
        {
            CNhomHang nh = new CNhomHang(txtMa.Text, txtTen.Text, txtGhiChu.Text, ceConQL.Checked);
            BUS_HangHoa.ThemNH(nh);
            sendNH();
            this.Close();
        }

        private void ThemDV()
        {
            CDonViTinh dv = new CDonViTinh(txtMa.Text, txtTen.Text, txtGhiChu.Text, ceConQL.Checked);
            BUS_DonViTinh.ThemDV(dv);
            sendDV();
            this.Close();
        }

        private void ThemKV()
        {
            CKhuVuc kv = new CKhuVuc(txtMa.Text, txtTen.Text, txtGhiChu.Text, ceConQL.Checked);
            BUS_KhuVuc.ThemKV(kv);
            sendKV();
            this.Close();
        }

    }
}