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

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fTiGia : fBaseStatic
    {
        public delegate void sendMessage();
        public fTiGia()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnTyGia");
            if (QuyenNguoiDung.Them == false)
                btnThem.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Sua == false)
                btnSua.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Xoa == false)
                btnXoa.Visibility = BarItemVisibility.Never;

            LoadData();

            gvMain.Columns[0].FieldName = "Currency_ID";
            gvMain.Columns[1].FieldName = "CurrencyName";
            gvMain.Columns[2].FieldName = "Exchange";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMain.Columns[2].DisplayFormat.FormatString = "n0";

            gvMain.IndicatorWidth = 35;
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
            string colID = "Currency_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_TienTe.KiemTraTienTe(value) == true)
            {
                BUS_TienTe.XoaTienTe(value);

                Action.Module = "Tiền Tệ";
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
            CTyGia tg = new CTyGia
            {
                MaTienTe = gvMain.GetRowCellValue(rowIndex, "Currency_ID").ToString(),
                TenTienTe = gvMain.GetRowCellValue(rowIndex, "CurrencyName").ToString(),
                TyGia = float.Parse(gvMain.GetRowCellValue(rowIndex, "Exchange").ToString()),
                ConQL = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };
            fThemTyGia sua = new fThemTyGia(false, tg, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemTyGia themKhuVuc = new fThemTyGia(true, null, LoadData);
            themKhuVuc.ShowDialog();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_TienTe.LayTienTe();
        }

        /// <summary>
        /// Sự kiện hiển thị số thứ tự của hàng trong bảng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}