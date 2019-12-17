using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using QLBH_BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;

namespace DAQLBH_Devexpress
{
    public partial class fBanHang : DevExpress.XtraEditors.XtraForm
    {
        DataSet dsGcMain = new DataSet();//DataSet dùng cho GridControlMain
        public fBanHang()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Khởi tạo các giá trị, thuộc tính của các control 
        /// </summary>
        private void Init()
        {
            
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN");

            //Khởi tạo KH
            leKH.Properties.TextEditStyle = TextEditStyles.Standard;
            leKH.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leKH, BUS_KhachHang.LayKhachHangDonGian(), "CustomerName", "Customer_ID");
            leKH.Properties.Columns[0].FieldName = "CustomerName";
            leKH.Properties.Columns[1].FieldName = "Customer_ID";

            //Khởi tạo Mã KH
            leMaKH.Properties.TextEditStyle = TextEditStyles.Standard;
            leMaKH.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leMaKH, BUS_KhachHang.LayKhachHangDonGian(), "Customer_ID", "Customer_ID");
            leMaKH.Properties.Columns[1].FieldName = "CustomerName";
            leMaKH.Properties.Columns[0].FieldName = "Customer_ID";

            //Gán sự kiện cho KH và Mã KH
            leKH.EditValueChanged += GeKH_EditValueChanged;
            leMaKH.EditValueChanged += GeMaKH_EditValueChanged;

            //Khởi tạo nhân viên bán hàng
            leNhanVienBH.Properties.TextEditStyle = TextEditStyles.Standard;
            leNhanVienBH.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leNhanVienBH, BUS_NhanVien.LayNhanVienDonGian(), "EMPLOYEE_Name", "EMPLOYEE_ID");
            leNhanVienBH.Properties.Columns[0].FieldName = "EMPLOYEE_Name";
            leNhanVienBH.Properties.Columns[1].FieldName = "EMPLOYEE_ID";
            leNhanVienBH.EditValue = ((DataTable)leNhanVienBH.Properties.DataSource).Rows[0]["EMPLOYEE_ID"];

            //Khởi tạo kho xuất
            leKhoXuat.Properties.TextEditStyle = TextEditStyles.Standard;
            leKhoXuat.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leKhoXuat, BUS_KhoXuat.LayKhoDonGian(), "STOCK_Name", "STOCK_ID");
            leKhoXuat.Properties.Columns[0].FieldName = "STOCK_Name";
            leKhoXuat.Properties.Columns[1].FieldName = "STOCK_ID";
            leKhoXuat.EditValue = ((DataTable)leKhoXuat.Properties.DataSource).Rows[0]["STOCK_ID"];

            //Khởi tạo các DateEdit
            deHanTT.EditValue = DateTime.Today.ToShortDateString();
            deNgayGiao.EditValue = DateTime.Today.ToShortDateString();
            deNgay.EditValue = DateTime.Today.ToShortDateString();

            //Khởi tạo GridviewControl
            gvMain.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            CreateDataSource();
            gvcMain.DataSource = dsGcMain.Tables[0];
            gvMain.CellValueChanged += GvMain_CellValueChanged;
            //gvMain.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            //Khởi tạo đơn vị tính
            leDonVi.NullText = "(Chọn)";
            leDonVi.TextEditStyle = TextEditStyles.Standard;
            leMaHang.TextEditStyle = TextEditStyles.Standard;
            leMaHang.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leDonVi, BUS_DonViTinh.GetDVTDonGian(), "UNIT_Name", "UNIT_ID");
            leDonVi.Columns.Add(new LookUpColumnInfo("UNIT_Name", "ĐVT"));

            //Khởi tạo Mã hàng
            leMaHang.NullText = "(Chọn)";
            SetDataSource(leMaHang, BUS_HangHoa.LayHangHoaLookupEdit(), "Product_ID", "Product_ID");
            leMaHang.Columns.Add(new LookUpColumnInfo("Product_ID", "Mã hàng"));
            leMaHang.Columns.Add(new LookUpColumnInfo("Product_Name", "Tên hàng"));
            leMaHang.Columns.Add(new LookUpColumnInfo("Quantity", "Tồn kho"));
            leMaHang.Columns.Add(new LookUpColumnInfo("Stock_Name", "Kho hàng"));
            leMaHang.PopupFormMinSize = new System.Drawing.Size(600,350);

            //Khởi tạo Tên hàng
            leTenHang.NullText = "(Chọn)";
            SetDataSource(leTenHang, BUS_HangHoa.LayHangHoaLookupEdit(),"Product_Name", "Product_ID");
            leTenHang.Columns.Add(new LookUpColumnInfo("Product_ID", "Mã hàng"));
            leTenHang.Columns.Add(new LookUpColumnInfo("Product_Name", "Tên hàng"));
            leTenHang.Columns.Add(new LookUpColumnInfo("Quantity", "Tồn kho"));
            leTenHang.Columns.Add(new LookUpColumnInfo("Stock_Name", "Kho hàng"));
            leTenHang.PopupFormMinSize = new System.Drawing.Size(600, 350);

            //Gán sự kiện cho Mã hàng và Tên hàng
            leMaHang.EditValueChanged += LeMaHang_EditValueChanged;
            leTenHang.EditValueChanged += LeTenHang_EditValueChanged;

            List<string> listDKTT = new List<string>();
            listDKTT.Add("Công Nợ");
            listDKTT.Add("Thanh Toán Ngay");

            gleDKTT.Properties.DataSource = listDKTT;
        }

        private void GvMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            if (e.Column.FieldName == "colMa")
            {
                gv.SetFocusedRowCellValue("colTen", gv.GetFocusedRowCellValue("colMa"));
                return;
            }
            else if (e.Column.FieldName == "colTen")
            {
                if (gv.GetFocusedRowCellValue(gv.Columns["colTen"]) != gv.GetFocusedRowCellValue("colMa"))
                    gv.SetFocusedRowCellValue("colMa", gv.GetRowCellValue(e.RowHandle, gv.Columns["colTen"]));
                return;
            }
        }

        /// <summary>
        /// Bắt sự kiện khi 'Tên hàng' thay đổi thì 'Mã hàng' sẽ thay đổi tương ứng với Tên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeTenHang_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Bắt sự kiện khi 'Mã hàng' thay đổi thì 'Tên hàng' sẽ thay đổi tương ứng với mã
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeMaHang_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Khởi tạo DataSource cho GridControlMain
        /// </summary>
        private void CreateDataSource()
        {
            DataTable dataTable = new DataTable("ParentTable");

            addColumns(dataTable,typeof(string),"colMa");
            addColumns(dataTable, typeof(string), "colTen");
            addColumns(dataTable, typeof(string), "colDonVi");
            addColumns(dataTable, typeof(int), "colLoaiGia");
            addColumns(dataTable, typeof(int), "colSoLuong");
            addColumns(dataTable, typeof(double), "colDonGia");
            addColumns(dataTable, typeof(double), "colThanhTien");
            addColumns(dataTable, typeof(float), "colChietKhauTiLe");
            addColumns(dataTable, typeof(double), "colChietKhau");
            addColumns(dataTable, typeof(double), "colThanhToan");

            dsGcMain.Tables.Add(dataTable);

        }

        /// <summary>
        /// Khởi tạo giá trị của column và thêm vào DataTable
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="type">Kiểu dữ liệu của column</param>
        /// <param name="colname">Tên column</param>
        private static void addColumns(DataTable dataTable,Type type,string colname)
        {
            DataColumn col = new DataColumn();
            col.DataType = type;
            col.ColumnName = colname;
            col.AutoIncrement = false;
            col.ReadOnly = false;
            col.Unique = false;

            dataTable.Columns.Add(col);
        }


        /// <summary>
        /// Gán DataSource, giá trị cho các con trol LookupEdit hoặc RepositoryItemLookUpEdit
        /// </summary>
        /// <param name="control">tên control cần gán</param>
        /// <param name="data">Datatable cần gán</param>
        /// <param name="displayMember">Thuộc tính để hiển thị giá trị</param>
        /// <param name="valueMember">Thuộc tính ánh xạ giá trị và lưu lại</param>
        private void SetDataSource(object control,DataTable data, string displayMember, string valueMember)
        {
            if (control is LookUpEdit)
            {
                LookUpEdit t = control as LookUpEdit;
                t.Properties.DataSource = data;
                t.Properties.DisplayMember = displayMember;
                t.Properties.ValueMember = valueMember;
            }
            if (control is RepositoryItemLookUpEdit)
            {
                RepositoryItemLookUpEdit t = control as RepositoryItemLookUpEdit;
                t.DataSource = data;
                t.DisplayMember = displayMember;
                t.ValueMember = valueMember;
            }
        }

        /// <summary>
        /// Bắt sự kiện khi 'Tên khách hàng' thay đổi thì 'Mã khách hàng' sẽ thay đổi tương ứng với tên
        /// </summary>
        /// <param name="sender">control LookupEdit</param>
        /// <param name="e"></param>
        private void GeMaKH_EditValueChanged(object sender, System.EventArgs e)
        {
            leKH.EditValue = leMaKH.EditValue.ToString();
        }
        /// <summary>
        /// Bắt sự kiện khi 'Mã khách hàng' thay đổi thì 'Tên khách hàng' sẽ thay đổi tương ứng với mã
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeKH_EditValueChanged(object sender, System.EventArgs e)
        {
            leMaKH.EditValue = leKH.EditValue.ToString();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void dpChucNang_Click(object sender, EventArgs e)
        {

        }

        private void btnPhieuBanHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gcXuat.Visible = true;
        }
    }
}