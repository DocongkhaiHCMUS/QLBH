using System;
using System.Data;
using System.Windows.Forms;
using DAQLBH_Devexpress.DanhMuc;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using QLBH_BUS;
using QLBH_DTO;

namespace DAQLBH_Devexpress
{
    public partial class fKhuVuc : DevExpress.XtraEditors.XtraForm
    {

        public delegate void sendMessage();
        public fKhuVuc()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnKhuVuc");
            if (QuyenNguoiDung.Them == false)
                btnThem.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Sua == false)
                btnSua.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Xoa == false)
                btnXoa.Visibility = BarItemVisibility.Never;

            Load += FKhuVuc_Load;
            btnLamMoi.ItemClick += FKhuVuc_Load;

            gvMain.IndicatorWidth = 35;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void GvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void FKhuVuc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gvcMain.DataSource = BUS_KhuVuc.KhuVuc();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                return;
            int rowIndex = gvMain.FocusedRowHandle;
            string colID = "CUSTOMER_GROUP_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_KhuVuc.KiemTraKV(value) == true)
            {
                BUS_KhuVuc.XoaKV(value);

                Action.Module = "Khu Vực";
                Action.ActionName = "Xóa";
                Action.Reference = value;
                Action.LuuThongTin();

                LoadData();
            }
            else
                return;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            CKhuVuc kv = new CKhuVuc
            {
                MaKV = gvMain.GetRowCellValue(rowIndex, "CUSTOMER_GROUP_ID").ToString(),
                TenKV = gvMain.GetRowCellValue(rowIndex, "CUSTOMER_GROUP_Name").ToString(),
                GhiChu = gvMain.GetRowCellValue(rowIndex, "Description").ToString(),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemSimple sua = new fThemSimple(false, kv, LoadData);
            sua.ShowDialog();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fThemSimple themKhuVuc = new fThemSimple(true,null,LoadData);
            themKhuVuc.ShowDialog();
        }

    }
}