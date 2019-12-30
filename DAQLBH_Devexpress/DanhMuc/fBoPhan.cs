using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using QLBH_BUS;
using QLBH_DTO;
using System;
using System.Windows.Forms;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fBoPhan : fBaseStatic
    {
        public delegate void sendMessage();
        public fBoPhan()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnBoPhan");
            if (QuyenNguoiDung.Them == false)
                btnThem.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Sua == false)
                btnSua.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Xoa == false)
                btnXoa.Visibility = BarItemVisibility.Never;

            LoadData();

            gvMain.Columns[0].FieldName = "Department_ID";
            gvMain.Columns[1].FieldName = "Department_Name";
            gvMain.Columns[2].FieldName = "Description";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.IndicatorWidth = 30;
            gvMain.CustomDrawRowIndicator += gvMain_CustomDrawRowIndicator;

            btnThem.ItemClick += BtnThem_ItemClick;
            btnSua.ItemClick += BtnSua_ItemClick;
            btnXoa.ItemClick += BtnXoa_ItemClick;
            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
        }

        private void BtnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_NhanVien.LayBoPhan();
        }

        private void BtnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                 == DialogResult.No)
                return;
            int rowIndex = gvMain.FocusedRowHandle;
            string colID = "Department_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_NhanVien.KiemTraBP(value) == true)
            {
                BUS_NhanVien.XoaBP(value);

                Action.Module = "Bộ Phận";
                Action.ActionName = "Xóa";
                Action.Reference = value;
                Action.LuuThongTin();

                LoadData();
            }
            else
                return;
        }

        private void BtnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            CBoPhan bp = new CBoPhan
            {
                MaBP = gvMain.GetRowCellValue(rowIndex, "Department_ID").ToString(),
                TenBP = gvMain.GetRowCellValue(rowIndex, "Department_Name").ToString(),
                GhiChu = gvMain.GetRowCellValue(rowIndex, "Description").ToString(),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemSimple sua = new fThemSimple(false, bp, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemSimple themKhuVuc = new fThemSimple(true, null, LoadData, (double)1);
            themKhuVuc.ShowDialog();
        }

        /// <summary>
        /// Sự kiện hiển thị số thứ tự của hàng trong bảng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
