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
            QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnNhanVien");
            if (QuyenNguoiDung.Them == false)
                btnThem.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Sua == false)
                btnSua.Visibility = BarItemVisibility.Never;
            if (QuyenNguoiDung.Xoa == false)
                btnXoa.Visibility = BarItemVisibility.Never;

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

                Action.Module = "Nhân Viên";
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
            DataRow fNV = BUS_NhanVien.TimNV(gvMain.GetRowCellValue(rowIndex, "Employee_ID").ToString());
            string      _MaNV       = fNV.Field<string>("Employee_ID")          ;
            string      _TenNV      = fNV.Field<string>("Employee_Name")        ;
            bool        _GioiTinh   = fNV.Field<bool>("Sex")                    ;
            string      _DiaChi     = fNV.Field<string>("Address")              ;
            string      _DienThoai  = fNV.Field<string>("O_Tel")                ;
            string      _DiDong     = fNV.Field<string>("Mobile")               ;
            DateTime    _NgaySinh   = fNV.Field<DateTime>("Birthday")           ;
            string      _BoPhan     = fNV.Field<string>("Department_ID")        ;
            string      _QuanLy     = fNV.Field<string>("Manager_ID")           ;
            string      _ChucVu     = fNV.Field<string>("Description")          ;
            string      _Email      = fNV.Field<string>("Email")                ;
            bool        _ConQL      = fNV.Field<bool>("Active")                 ; 
            CNhanVien nv = new CNhanVien
            {
                MaNV      = _MaNV       ,
                TenNV     = _TenNV      ,
                GioiTinh  = _GioiTinh   ,
                DiaChi    = _DiaChi     ,
                DienThoai = _DienThoai  ,
                DiDong    = _DiDong     ,
                NgaySinh  = _NgaySinh   ,
                BoPhan    = _BoPhan     ,
                QuanLy    = _QuanLy     ,
                ChucVu    = _ChucVu     ,
                Email     = _Email      ,
                ConQL     = _ConQL
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