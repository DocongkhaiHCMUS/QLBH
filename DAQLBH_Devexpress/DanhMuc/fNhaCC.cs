using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBH_BUS;
using DevExpress.XtraBars;
using DAQLBH_Devexpress.DanhMuc;
using QLBH_DTO;

namespace DAQLBH_Devexpress
{
    public partial class fNhaCC : fBaseStatic
    {
        public delegate void sendMessage();
        public fNhaCC()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitColumns();
            LoadData();

            gcMain.UseEmbeddedNavigator = true;
            gcMain.EmbeddedNavigator.Buttons.Append.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gvMain.Columns[2].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gvMain.OptionsBehavior.AutoExpandAllGroups = true;

            gvMain.IndicatorWidth = 45;
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

        private void BtnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                return;
            int rowIndex = gvMain.FocusedRowHandle;
            string colID = "Customer_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_NhaCungCap.KiemTraNCC(value) == true)
            {
                BUS_NhaCungCap.XoaNCC(value);

                Action.Module = "Nhà Cung Cấp";
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
            CNhaCC ncc = new CNhaCC
            {
                MaNCC = gvMain.GetRowCellValue(rowIndex, "Customer_ID").ToString(),
                TenNCC = gvMain.GetRowCellValue(rowIndex, "CustomerName").ToString(),
                KhuVuc = gvMain.GetRowCellValue(rowIndex, "Customer_Group_ID").ToString(),
                LienHe = gvMain.GetRowCellValue(rowIndex, "Contact").ToString(),
                ChucVu = gvMain.GetRowCellValue(rowIndex, "Position").ToString(),
                DiaChi = gvMain.GetRowCellValue(rowIndex, "CustomerAddress").ToString(),
                DienThoai = gvMain.GetRowCellValue(rowIndex, "Tel").ToString(),
                DiDong = gvMain.GetRowCellValue(rowIndex, "Mobile").ToString(),
                Fax = gvMain.GetRowCellValue(rowIndex, "Fax").ToString(),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemNCC sua = new fThemNCC(false, ncc, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemNCC ncc = new fThemNCC(true, null, LoadData);
            ncc.ShowDialog();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_NhaCungCap.LayNhaCC();
        }

        private void GvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        /// <summary>
        /// Binding các columns với FileName của DataSource
        /// </summary>
        private void InitColumns()
        {
            gvMain.Columns[0].FieldName = "Customer_ID";
            gvMain.Columns[1].FieldName = "CustomerName";
            gvMain.Columns[2].FieldName = "Customer_Group_ID";
            gvMain.Columns[3].FieldName = "Contact";
            gvMain.Columns[4].FieldName = "Position";
            gvMain.Columns[5].FieldName = "CustomerAddress";
            gvMain.Columns[6].FieldName = "Tel";
            gvMain.Columns[7].FieldName = "Mobile";
            gvMain.Columns[8].FieldName = "Fax";
            gvMain.Columns[9].FieldName = "Active";
        }
    }
}