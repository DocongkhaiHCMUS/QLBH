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
using QLBH_DTO;

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fBaseBanKe : fBaseStatic
    {
        fMainBH.BanKebtnThem _sendBH;
        fMainBH.BanKebtnSua _sua;
        bool sale;
        public fBaseBanKe(bool isSale = true,fMainBH.BanKebtnThem send=null,fMainBH.BanKebtnSua sua=null)
        {
            InitializeComponent();
            sale = isSale;
            _sendBH = send;
            _sua = sua;
            Init();
        }

        private void Init()
        {
            if (sale == true)
            {
                KhoiTaoChungTuBH();
                QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnBanHang");
            }
            else
            {
                KhoiTaoChungTuMH();
                QuyenNguoiDung.LayQuyenNguoiDungTheoChucNang("btnMuaHang");
            }

            if (QuyenNguoiDung.Them == false)
                btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (QuyenNguoiDung.Sua == false)
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (QuyenNguoiDung.Xoa == false)
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
            btnThem.ItemClick += BtnThem_ItemClick;
            btnXoa.ItemClick += BtnXoa_ItemClick;
            btnSua.ItemClick += BtnSua_ItemClick;
        }

        private void KhoiTaoChungTuMH()
        {
            gvcMain.DataSource = BUS_KhoXuat.LayChungTuMH();

            gvMain.Columns[0].FieldName = "Inward_ID"       ;
            gvMain.Columns[1].FieldName = "RefDate"         ;
            gvMain.Columns[2].FieldName = "CustomerName"    ;
            gvMain.Columns[3].FieldName = "Product_ID"      ;
            gvMain.Columns[4].FieldName = "ProductName"     ;
            gvMain.Columns[5].FieldName = "Stock_ID"        ;
            gvMain.Columns[6].FieldName = "Unit"            ;
            gvMain.Columns[7].FieldName = "Quantity"        ;
            gvMain.Columns[8].FieldName = "UnitPrice"       ;
            gvMain.Columns[9].FieldName = "Amount";

            gvMain.Columns[2].Caption = "Nhà Cung Cấp";
            gvMain.Columns[10].Visible = false;
            gvMain.Columns[11].Visible = false;
            gvMain.Columns[12].Visible = false;
        }

        private void KhoiTaoChungTuBH()
        {
            gvcMain.DataSource = BUS_KhoXuat.LayChungTuBH();

            gvMain.Columns[0].FieldName = "Outward_ID";
            gvMain.Columns[1].FieldName = "RefDate";
            gvMain.Columns[2].FieldName = "Description";
            gvMain.Columns[3].FieldName = "Product_ID";
            gvMain.Columns[4].FieldName = "ProductName";
            gvMain.Columns[5].FieldName = "Stock_ID";
            gvMain.Columns[6].FieldName = "Unit";
            gvMain.Columns[7].FieldName = "Quantity";
            gvMain.Columns[8].FieldName = "UnitPrice";
            gvMain.Columns[9].FieldName = "Charge";
            gvMain.Columns[10].FieldName = "DiscountRate";
            gvMain.Columns[11].FieldName = "Discount";
            gvMain.Columns[12].FieldName = "Amount";
        }

        private void BtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SuaChungTuBH();
        }

        private void SuaChungTuBH()
        {
            List<CBanHang> lBH = new List<CBanHang>();
            int rowIndex = gvMain.FocusedRowHandle;
            DataTable fBH;
            if (sale == true)
                fBH = BUS_KhoXuat.TimBH(gvMain.GetRowCellValue(rowIndex, "Outward_ID").ToString());
            else
                fBH = BUS_KhoXuat.TimMH(gvMain.GetRowCellValue(rowIndex, "Inward_ID").ToString());
            foreach (DataRow item in fBH.Rows)
            {
                if (sale == true)
                {
                    string _MaBH = item.Field<string>("MaBH");
                    DateTime _NgayLap = item.Field<DateTime>("NgayLap");
                    string _MaKH = item.Field<string>("MaKH");
                    string _TenKH = item.Field<string>("TenKH");
                    string _NhanVienBH = item.Field<string>("NhanVienBH");
                    string _KhoXuat = item.Field<string>("KhoXuat");
                    string _DiaChi = item.Field<string>("DiaChi");
                    string _GhiChu = item.Field<string>("GhiChu");
                    string _DienThoai = item.Field<string>("DienThoai");
                    string _SoHoaDonVat = item.Field<string>("SoHoaDonVat");
                    string _SoPhieuNhapTay = item.Field<string>("SoPhieuNhapTay");
                    string _DieuKhoanThanhToan = item.Field<string>("DieuKhoanThanhToan");
                    string _HinhThucTT = item.Field<string>("HinhThucTT");
                    DateTime _HanTT = item.Field<DateTime>("HanTT");
                    DateTime _NgayGiao = item.Field<DateTime>("NgayGiao");
                    string _MaHH = item.Field<string>("MaHH");
                    string _TenHH = item.Field<string>("TenHH");
                    string _DonVi = item.Field<string>("DonVi");
                    decimal _SoLuong = item.Field<decimal>("SoLuong");
                    decimal _DonGia = item.Field<decimal>("DonGia");
                    decimal _ThanhTien = item.Field<decimal>("ThanhTien");
                    decimal _ChietKhauTiLe = item.Field<decimal>("ChietKhauTiLe");
                    decimal _ChietKhau = item.Field<decimal>("ChietKhau");
                    decimal _ThanhToan = item.Field<decimal>("ThanhToan");


                    CBanHang bh = new CBanHang
                        (
                            _MaBH,
                            _NgayLap,
                            _MaKH,
                            _TenKH,
                            _NhanVienBH,
                            _KhoXuat,
                            _DiaChi,
                            _GhiChu,
                            _DienThoai,
                            _SoHoaDonVat,
                            _SoPhieuNhapTay,
                            _DieuKhoanThanhToan,
                            _HinhThucTT,
                            _HanTT,
                            _NgayGiao,
                            _MaHH,
                            _TenHH,
                            _DonVi,
                            float.Parse(_SoLuong.ToString()),
                            float.Parse(_DonGia.ToString()),
                            float.Parse(_ThanhTien.ToString()),
                            float.Parse(_ChietKhauTiLe.ToString()),
                            float.Parse(_ChietKhau.ToString()),
                            float.Parse(_ThanhToan.ToString())
                        );

                    lBH.Add(bh);
                }
                else
                {
                    string _MaBH = item.Field<string>("MaBH");
                    DateTime _NgayLap = item.Field<DateTime>("NgayLap");
                    string _MaKH = item.Field<string>("MaKH");
                    string _TenKH = item.Field<string>("TenKH");
                    string _NhanVienBH = item.Field<string>("NhanVienBH");
                    string _KhoXuat = item.Field<string>("KhoXuat");
                    string _DiaChi = item.Field<string>("DiaChi");
                    string _GhiChu = item.Field<string>("GhiChu");
                    string _DienThoai = item.Field<string>("DienThoai");
                    string _SoHoaDonVat = item.Field<string>("SoHoaDonVat");
                    string _SoPhieuNhapTay = item.Field<string>("SoPhieuNhapTay");
                    string _DieuKhoanThanhToan = item.Field<string>("DieuKhoanThanhToan");
                    string _HinhThucTT = item.Field<string>("HinhThucTT");
                    DateTime _HanTT = item.Field<DateTime>("HanTT");
                    DateTime _NgayGiao = DateTime.Now;
                    string _MaHH = item.Field<string>("MaHH");
                    string _TenHH = item.Field<string>("TenHH");
                    string _DonVi = item.Field<string>("DonVi");
                    decimal _SoLuong = item.Field<decimal>("SoLuong");
                    decimal _DonGia = item.Field<decimal>("DonGia");
                    decimal _ThanhTien = item.Field<decimal>("ThanhToan");
                    decimal _ChietKhauTiLe = 0;
                    decimal _ChietKhau = 0;
                    decimal _ThanhToan = 0;


                    CBanHang bh = new CBanHang
                        (
                            _MaBH,
                            _NgayLap,
                            _MaKH,
                            _TenKH,
                            _NhanVienBH,
                            _KhoXuat,
                            _DiaChi,
                            _GhiChu,
                            _DienThoai,
                            _SoHoaDonVat,
                            _SoPhieuNhapTay,
                            _DieuKhoanThanhToan,
                            _HinhThucTT,
                            _HanTT,
                            _NgayGiao,
                            _MaHH,
                            _TenHH,
                            _DonVi,
                            float.Parse(_SoLuong.ToString()),
                            float.Parse(_DonGia.ToString()),
                            float.Parse(_ThanhTien.ToString()),
                            float.Parse(_ChietKhauTiLe.ToString()),
                            float.Parse(_ChietKhau.ToString()),
                            float.Parse(_ThanhToan.ToString())
                        );

                    lBH.Add(bh);
                }
            }
            _sua?.Invoke(lBH);


        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa không ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) 
                == DialogResult.Yes)
            {
                if (sale == true)
                {
                    string ma = gvMain.GetFocusedRowCellValue("Outward_ID").ToString();
                    BUS_KhoXuat.XoaBH(ma);

                    Action.Module = "Bán Hàng";
                    Action.ActionName = "Xóa";
                    Action.Reference = ma;

                    Action.LuuThongTin();
                }
                else
                {
                    string ma = gvMain.GetFocusedRowCellValue("Inward_ID").ToString();
                    BUS_KhoXuat.XoaMH(ma);

                    Action.Module = "Mua Hàng";
                    Action.ActionName = "Xóa";
                    Action.Reference = ma;

                    Action.LuuThongTin();
                }

                Refresh();
            }

        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _sendBH?.Invoke();
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            if (sale == true)
                gvcMain.DataSource = BUS_KhoXuat.LayChungTuBH();
            else
                gvcMain.DataSource = BUS_KhoXuat.LayChungTuMH();
        }
    }
}