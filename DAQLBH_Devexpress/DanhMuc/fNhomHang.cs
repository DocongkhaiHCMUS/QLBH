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
using QLBH_BUS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using QLBH_DTO;
using DAQLBH_Devexpress.DanhMuc;

namespace DAQLBH_Devexpress
{
    public partial class fNhomHang : fBaseStatic
    {
        public delegate void sendMessage();
        public fNhomHang()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadData();

            gvMain.Columns[0].FieldName = "ProductGroup_ID";
            gvMain.Columns[1].FieldName = "ProductGroup_Name";
            gvMain.Columns[2].FieldName = "Description";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.IndicatorWidth = 35;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;

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
            gcMain.DataSource = BUS_HangHoa.LayNhomHang();
        }

        private void BtnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                 == DialogResult.No)
                return;
            int rowIndex = gvMain.FocusedRowHandle;
            string colID = "ProductGroup_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_HangHoa.KiemTraNH(value) == true)
            {
                BUS_HangHoa.XoaNH(value);
                LoadData();
            }
            else
                return;
        }

        private void BtnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            CNhomHang nh = new CNhomHang
            {
                MaNH = gvMain.GetRowCellValue(rowIndex, "ProductGroup_ID").ToString(),
                TenNH = gvMain.GetRowCellValue(rowIndex, "ProductGroup_Name").ToString(),
                GhiChu = gvMain.GetRowCellValue(rowIndex, "Description").ToString(),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemSimple sua = new fThemSimple(false, nh, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemSimple themKhuVuc = new fThemSimple(true, null, LoadData,(float)1);
            themKhuVuc.ShowDialog();
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}