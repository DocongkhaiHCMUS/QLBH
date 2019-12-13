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

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fNhanVien : fBaseStatic
    {
        public delegate void sendMessage();
        public fNhanVien()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadData();

            gvMain.Columns[0].FieldName = "Employee_ID";
            gvMain.Columns[1].FieldName = "Employee_Name";
            gvMain.Columns[2].FieldName = "Address";
            gvMain.Columns[3].FieldName = "O_Tel";
            gvMain.Columns[4].FieldName = "Mobile";
            gvMain.Columns[5].FieldName = "Email";
            gvMain.Columns[6].FieldName = "Active";

            gvMain.IndicatorWidth = 50;
            gvMain.CustomDrawRowIndicator += gvMain_CustomDrawRowIndicator;

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
            string colID = "Employee_ID";
            string value = gvMain.GetRowCellValue(rowIndex, colID).ToString();
            if (BUS_NhanVien.KiemTraNV(value) == true)
            {
                BUS_NhanVien.XoaNV(value);
                LoadData();
            }
            else
                return;
        }

        private void BtnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowIndex = gvMain.FocusedRowHandle;
            CNhanVien nv = new CNhanVien
            {
                MaNV      = gvMain.GetRowCellValue(rowIndex, "Employee_ID").ToString(),
                TenNV     = gvMain.GetRowCellValue(rowIndex, "Employee_Name").ToString(),
                GioiTinh  = true,
                DiaChi    = gvMain.GetRowCellValue(rowIndex, "Address").ToString(),
                DienThoai = gvMain.GetRowCellValue(rowIndex, "O_Tel").ToString(),
                DiDong    = gvMain.GetRowCellValue(rowIndex, "Mobile").ToString(),
                NgaySinh  = DateTime.Now,
                BoPhan    = "",
                QuanLy    = "",
                ChucVu    = "",
                Email     = gvMain.GetRowCellValue(rowIndex, "Email").ToString(),
                ConQL     = bool.Parse(gvMain.GetRowCellValue(rowIndex, "Active").ToString())
            };      
            fThemNhanVien sua = new fThemNhanVien(false, nv, LoadData);
            sua.ShowDialog();
        }

        private void BtnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThemNhanVien nv = new fThemNhanVien(true, null, LoadData);
            nv.ShowDialog();
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gcMain.DataSource = BUS_NhanVien.LayNhanVien();
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