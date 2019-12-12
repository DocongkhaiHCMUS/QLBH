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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraBars;
using DAQLBH_Devexpress.DanhMuc;
using QLBH_DTO;

namespace DAQLBH_Devexpress
{
    public partial class fKhachHang : fBaseStatic
    {
        public delegate void SendMessage();
        public fKhachHang()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadData();

            gvMain.Columns[0].FieldName = "Customer_ID";
            gvMain.Columns[1].FieldName = "CustomerName";
            gvMain.Columns[2].FieldName = "Customer_Group_ID";
            gvMain.Columns[3].FieldName = "Contact";
            gvMain.Columns[4].FieldName = "CustomerAddress";
            gvMain.Columns[5].FieldName = "Tel";
            gvMain.Columns[6].FieldName = "Mobile";
            gvMain.Columns[7].FieldName = "Fax";
            gvMain.Columns[8].FieldName = "Email";
            gvMain.Columns[9].FieldName = "Website";
            gvMain.Columns[10].FieldName = "Tax";
            gvMain.Columns[11].FieldName = "BankAccount";
            gvMain.Columns[12].FieldName = "BankName";
            gvMain.Columns[13].FieldName = "Active";

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
        }

        private void BtnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                return;
            int rowIndex = gvMain.FocusedRowHandle;
            string colID = "Customer_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_KhachHang.KiemTraKH(value) == true)
            {
                BUS_KhachHang.XoaKH(value);
                LoadData();
            }
            else
                return;
        }

        private void BtnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            CKhachHang kh = new CKhachHang
            {
                MaKH = gvMain.GetRowCellValue(rowIndex, "Customer_ID").ToString(),
                TenKH = gvMain.GetRowCellValue(rowIndex, "CustomerName").ToString(),
                KhuVuc = gvMain.GetRowCellValue(rowIndex, "Customer_Group_ID").ToString(),
                LienHe = gvMain.GetRowCellValue(rowIndex, "Contact").ToString(),
                DiaChi = gvMain.GetRowCellValue(rowIndex, "CustomerAddress").ToString(),
                DienThoai = gvMain.GetRowCellValue(rowIndex, "Tel").ToString(),
                DiDong = gvMain.GetRowCellValue(rowIndex, "Mobile").ToString(),
                Fax = gvMain.GetRowCellValue(rowIndex, "Fax").ToString(),
                Email = gvMain.GetRowCellValue(rowIndex, "Email").ToString(),
                Website = gvMain.GetRowCellValue(rowIndex, "Website").ToString(),
                MaSoThue = gvMain.GetRowCellValue(rowIndex, "Tax").ToString(),
                TaiKhoan = gvMain.GetRowCellValue(rowIndex, "BankAccount").ToString(),
                NganHang = gvMain.GetRowCellValue(rowIndex, "BankName").ToString(),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemKhachHang sua = new fThemKhachHang(false, kh, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemKhachHang kh = new fThemKhachHang(true, null, LoadData);
            kh.ShowDialog();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_KhachHang.LayKhachHang();
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}