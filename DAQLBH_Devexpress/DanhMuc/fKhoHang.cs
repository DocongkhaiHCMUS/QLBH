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
using DevExpress.XtraBars;
using QLBH_DTO;
using DAQLBH_Devexpress.DanhMuc;

namespace DAQLBH_Devexpress
{
    public partial class fKhoHang : fBaseStatic
    {
        public delegate void sendMessage();
        public fKhoHang()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadData();

            gvMain.Columns[0].FieldName = "Stock_ID";
            gvMain.Columns[1].FieldName = "Stock_Name";
            gvMain.Columns[2].FieldName = "Contact";
            gvMain.Columns[3].FieldName = "Address";
            gvMain.Columns[4].FieldName = "Telephone";
            gvMain.Columns[5].FieldName = "Manager";
            gvMain.Columns[6].FieldName = "Description";
            gvMain.Columns[7].FieldName = "Active";

            gvMain.IndicatorWidth = 45;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;

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
            string colID = "Stock_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_KhoXuat.KiemTraKho(value) == true)
            {
                BUS_KhoXuat.XoaKho(value);

                Action.Module = "Kho Hàng";
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
            CKho kho = new CKho
            {
                MaKho = gvMain.GetRowCellValue(rowIndex, "Stock_ID").ToString(),
                TenKho = gvMain.GetRowCellValue(rowIndex, "Stock_Name").ToString(),
                LienHe = gvMain.GetRowCellValue(rowIndex, "Contact").ToString(),
                DiaChi = gvMain.GetRowCellValue(rowIndex, "Address").ToString(),
                Email = "",
                DienThoai = gvMain.GetRowCellValue(rowIndex, "Telephone").ToString(),
                Fax = "",
                DiDong = "",
                NguoiQuanLy = gvMain.GetRowCellValue(rowIndex, "Manager").ToString(),
                DienGiai = gvMain.GetRowCellValue(rowIndex, "Description").ToString(),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemKho sua = new fThemKho(false, kho, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemKho kho = new fThemKho(true, null, LoadData);
            kho.ShowDialog();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_KhoXuat.LayKho();
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
    }
}