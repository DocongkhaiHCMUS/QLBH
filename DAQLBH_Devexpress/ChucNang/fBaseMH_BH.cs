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
using System.Threading;
using DevExpress.XtraEditors.Controls;
using QLBH_BUS;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using QLBH_DTO;

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fBaseMH_BH : DevExpress.XtraEditors.XtraForm
    {
        DataSet dsGcMain = new DataSet();//DataSet dùng cho GridControlMain
        DXErrorProvider error = new DXErrorProvider();
        DataTable table;
        CKho editTonKho = new CKho();
        bool isSale, add;

        /// <summary>
        /// Hàm khởi tạo form Thêm, sửa thông tin mua bán hàng
        /// </summary>
        /// <param name="sale">tham số dùng để xác định là form Mua hàng hay bán hàng</param>
        /// <param name="add">tham số dùng để xác định là hoạt động thêm hay sửa</param>
        public fBaseMH_BH(bool sale = true, bool isAdd = true)
        {
            InitializeComponent();

            isSale = sale;
            add = isAdd;

            Init();
        }

        private void Init()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN");

            //Khởi tạo nhân viên bán hàng
            leNhanVienBH.Properties.TextEditStyle = TextEditStyles.Standard;
            leNhanVienBH.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leNhanVienBH, BUS_NhanVien.LayNhanVienDonGian(), "EMPLOYEE_Name", "EMPLOYEE_ID");
            leNhanVienBH.Properties.Columns[0].FieldName = "EMPLOYEE_Name";
            leNhanVienBH.Properties.Columns[1].FieldName = "EMPLOYEE_ID";
            //leNhanVienBH.EditValue = ((DataTable)leNhanVienBH.Properties.DataSource).Rows[0]["EMPLOYEE_ID"];

            //Khởi tạo kho xuất
            leKhoXuat.Properties.TextEditStyle = TextEditStyles.Standard;
            leKhoXuat.Properties.BestFitMode = BestFitMode.BestFit;
            SetDataSource(leKhoXuat, BUS_KhoXuat.LayKhoDonGian(), "STOCK_Name", "STOCK_ID");
            leKhoXuat.Properties.Columns[0].FieldName = "STOCK_Name";
            leKhoXuat.Properties.Columns[1].FieldName = "STOCK_ID";
            //leKhoXuat.EditValue = ((DataTable)leKhoXuat.Properties.DataSource).Rows[0]["STOCK_ID"];

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
            leMaHang.Columns.Add(new LookUpColumnInfo("Unit", "Đơn vị tính"));
            leMaHang.PopupFormMinSize = new System.Drawing.Size(600, 350);

            //Khởi tạo Tên hàng
            leTenHang.NullText = "(Chọn)";
            SetDataSource(leTenHang, BUS_HangHoa.LayHangHoaLookupEdit(), "Product_Name", "Product_ID");
            leTenHang.Columns.Add(new LookUpColumnInfo("Product_ID", "Mã hàng"));
            leTenHang.Columns.Add(new LookUpColumnInfo("Product_Name", "Tên hàng"));
            leTenHang.Columns.Add(new LookUpColumnInfo("Quantity", "Tồn kho"));
            leTenHang.Columns.Add(new LookUpColumnInfo("Stock_Name", "Kho hàng"));
            leTenHang.Columns.Add(new LookUpColumnInfo("Unit", "Đơn vị tính"));
            leTenHang.PopupFormMinSize = new System.Drawing.Size(600, 350);

            calceSoLuong.NullText = "0";
            calceDonGia.NullText = "0";
            calceChietKhauTiLe.NullText = "0";
            calceChietKhau.NullText = "0";
            calceThanhToan.NullText = "0";

            List<object> listDKTT = new List<object>
            {
                new { ID = 0,name = "Công nợ" },
                new { ID = 1,name = "Thanh toán ngay" }
            };
            gleDKTT.Properties.DataSource = listDKTT;
            gleDKTT.Properties.ValueMember = "ID";
            gleDKTT.Properties.DisplayMember = "name";
            LookUpColumnInfo col_t = new LookUpColumnInfo("name", "");
            gleDKTT.Properties.Columns.Add(col_t);
            gleDKTT.EditValue = 0;

            List<object> listHTTT = new List<object>
            {
                new { ID = 0,name = "Tiền mặt" },
                new { ID = 1,name = "Chuyển khoản" }
            };
            gleHTTT.Properties.DataSource = listHTTT;
            gleHTTT.Properties.ValueMember = "ID";
            gleHTTT.Properties.DisplayMember = "name";
            col_t = new LookUpColumnInfo("name", "");
            gleHTTT.Properties.Columns.Add(col_t);
            gleHTTT.EditValue = 0;

            //Xử lý

            if (isSale == true)
            {
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

                Text = "Phiếu xuất hàng";
            }
            else
            {
                lcITen.Text = "Tên NCC";
                lcIMa.Text = "Mã NCC";
                lcINgayGiao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //Khởi tạo NCC
                leKH.Properties.NullText = "Chọn tên Nhà cung cấp ...";
                leKH.Properties.TextEditStyle = TextEditStyles.Standard;
                leKH.Properties.BestFitMode = BestFitMode.BestFit;
                SetDataSource(leKH, BUS_NhaCungCap.LayNhaCC(), "CustomerName", "Customer_ID");
                leKH.Properties.Columns[0].FieldName = "CustomerName";
                leKH.Properties.Columns[1].FieldName = "Customer_ID";

                //Khởi tạo Mã NCC
                leMaKH.Properties.NullText = "Chọn mã Nhà cung cấp ...";
                leMaKH.Properties.TextEditStyle = TextEditStyles.Standard;
                leMaKH.Properties.BestFitMode = BestFitMode.BestFit;
                SetDataSource(leMaKH, BUS_NhaCungCap.LayNhaCC(), "Customer_ID", "Customer_ID");
                leMaKH.Properties.Columns[1].FieldName = "CustomerName";
                leMaKH.Properties.Columns[0].FieldName = "Customer_ID";

                //Gán sự kiện cho NCC và Mã NCC
                leKH.EditValueChanged += GeKH_EditValueChanged;
                leMaKH.EditValueChanged += GeMaKH_EditValueChanged;

                Text = "Phiếu nhập hàng";
            }

            table = BUS_KhoXuat.GetTonKhoLookup();

            if (add == true)
                phatSinhMa();
            else
                LoadDuLieu();
        }

        private void LoadDuLieu()
        {
            throw new NotImplementedException();
        }

        private void phatSinhMa()
        {
            if (isSale == true)
            {
                var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("RefNo").Contains("BHADMIN")
                        select new
                        {
                            maPhieu = tb.Field<string>("RefNo")
                        };

                DataTable dttb = new DataTable();
                dttb.Columns.Add("RefNo", typeof(string));

                foreach (var item in query)
                {
                    dttb.Rows.Add(item.maPhieu);
                }
                string max, currentMa;
                int num;
                try
                {

                    max = dttb.Compute("Max(RefNo)", "").ToString();
                    num = int.Parse(max.Substring(7)) + 1;
                    currentMa = "BHADMIN" + num.ToString("000000");
                    txtMa.Text = currentMa;
                }
                catch
                {
                    currentMa = "BHADMIN000001";
                    txtMa.Text = currentMa;
                }
            }
            else
            {
                var query = from tb in table.AsEnumerable()
                            where tb.Field<string>("RefNo").Contains("MHADMIN")
                            select new
                            {
                                maPhieu = tb.Field<string>("RefNo")
                            };

                DataTable dttb = new DataTable();
                dttb.Columns.Add("RefNo", typeof(string));

                foreach (var item in query)
                {
                    dttb.Rows.Add(item.maPhieu);
                }
                string max, currentMa;
                int num;
                try
                {

                    max = dttb.Compute("Max(RefNo)", "").ToString();
                    num = int.Parse(max.Substring(7)) + 1;
                    currentMa = "MHADMIN" + num.ToString("000000");
                    txtMa.Text = currentMa;
                }
                catch
                {
                    currentMa = "MHADMIN000001";
                    txtMa.Text = currentMa;
                }
            }
        }

        /// <summary>
        /// Khởi tạo DataSource cho GridControlMain
        /// </summary>
        void CreateDataSource()
        {
            DataTable dataTable = new DataTable("ParentTable");

            addColumns(dataTable, typeof(string), "colMa");
            addColumns(dataTable, typeof(string), "colTen");
            addColumns(dataTable, typeof(string), "colDonVi");
            addColumns(dataTable, typeof(int), "colSoLuong");
            addColumns(dataTable, typeof(double), "colDonGia");
            addColumns(dataTable, typeof(double), "colThanhTien");
            addColumns(dataTable, typeof(float), "colChietKhauTiLe");
            addColumns(dataTable, typeof(double), "colChietKhau");
            addColumns(dataTable, typeof(double), "colThanhToan");

            dsGcMain.Tables.Add(dataTable);

        }

        void SetDataSource(object control, DataTable data, string displayMember, string valueMember)
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

        void addColumns(DataTable dataTable, Type type, string colname)
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
        /// Bắt sự kiện khi 'Tên khách hàng' thay đổi thì 'Mã khách hàng' sẽ thay đổi tương ứng với tên
        /// </summary>
        /// <param name="sender">control LookupEdit</param>
        /// <param name="e"></param>
        void GeMaKH_EditValueChanged(object sender, System.EventArgs e)
        {
            leKH.EditValue = leMaKH.EditValue.ToString();
        }
        /// <summary>
        /// Bắt sự kiện khi 'Mã khách hàng' thay đổi thì 'Tên khách hàng' sẽ thay đổi tương ứng với mã
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GeKH_EditValueChanged(object sender, System.EventArgs e)
        {
            leMaKH.EditValue = leKH.EditValue.ToString();
        }

        void GvMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            if (e.Column.FieldName == "colMa")
            {
                DataRowView value = leMaHang.GetDataSourceRowByKeyValue(gv.GetFocusedRowCellValue(gv.Columns["colMa"])) as DataRowView;
                gv.SetFocusedRowCellValue("colTen", gv.GetFocusedRowCellValue("colMa"));
                gv.SetFocusedRowCellValue("colDonVi", value["Unit"]);
                return;
            }
            else if (e.Column.FieldName == "colTen")
            {
                if (gv.GetFocusedRowCellValue(gv.Columns["colTen"]) != gv.GetFocusedRowCellValue("colMa"))
                {
                    gv.SetFocusedRowCellValue("colMa", gv.GetRowCellValue(e.RowHandle, gv.Columns["colTen"]));
                    DataRowView value = leTenHang.GetDataSourceRowByKeyValue(gv.GetFocusedRowCellValue(gv.Columns["colTen"])) as DataRowView;
                    gv.SetFocusedRowCellValue("colDonVi", value["Unit"]);
                }
                return;
            }
        }
    }
}