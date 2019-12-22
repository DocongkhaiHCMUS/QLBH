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
        List<CBanHang> editBH = new List<CBanHang>();
        bool isSale, add;

        /// <summary>
        /// Hàm khởi tạo form Thêm, sửa thông tin mua bán hàng
        /// </summary>
        /// <param name="sale">tham số dùng để xác định là form Mua hàng hay bán hàng</param>
        /// <param name="add">tham số dùng để xác định là hoạt động thêm hay sửa</param>
        public fBaseMH_BH(bool sale = true, bool isAdd = true, List<CBanHang> bh = null)
        {
            InitializeComponent();

            if (isAdd == false && bh == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == false)
            {
                editBH = bh;
            }
            isSale = sale;
            add = isAdd;

            Init();
            
        }

        private void Init()
        {
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
            calceSoLuong.MaxLength = 10;
            calceDonGia.NullText = "0";
            calceDonGia.MaxLength = 10;
            calceChietKhauTiLe.NullText = "0";
            calceChietKhauTiLe.MaxLength = 10;
            calceChietKhau.NullText = "0";
            calceChietKhau.MaxLength = 10;
            calceThanhToan.NullText = "0";
            calceThanhToan.MaxLength = 10;

            List<object> listDKTT = new List<object>
            {
                new { name = "Công nợ" },
                new { name = "Thanh toán ngay" }
            };
            gleDKTT.Properties.DataSource = listDKTT;
            gleDKTT.Properties.ValueMember = "name";
            gleDKTT.Properties.DisplayMember = "name";
            LookUpColumnInfo col_t = new LookUpColumnInfo("name", "");
            gleDKTT.Properties.Columns.Add(col_t);
            gleDKTT.EditValue = "Công nợ";

            List<object> listHTTT = new List<object>
            {
                new { ID = 0,name = "Tiền mặt" },
                new { ID = 1,name = "Chuyển khoản" }
            };
            gleHTTT.Properties.DataSource = listHTTT;
            gleHTTT.Properties.ValueMember = "name";
            gleHTTT.Properties.DisplayMember = "name";
            col_t = new LookUpColumnInfo("name", "");
            gleHTTT.Properties.Columns.Add(col_t);
            gleHTTT.EditValue = "Tiền mặt";

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
            txtMa.Text              = editBH[0].MaBH;
            deNgay.EditValue        = editBH[0].NgayLap;
            leKhoXuat.EditValue     = editBH[0].KhoXuat;
            gleDKTT.EditValue       = editBH[0].DieuKhoanThanhToan;
            gleHTTT.EditValue       = editBH[0].HinhThucTT;
            txtGC.Text              = editBH[0].GhiChu;
            txtSDT.Text             = editBH[0].DienThoai;
            txtHoaDonVAT.Text       = editBH[0].SoHoaDonVat;
            txtSoPhieu.Text         = editBH[0].SoPhieuNhapTay;
            deHanTT.EditValue       = editBH[0].HanTT;
            deNgayGiao.EditValue    = editBH[0].NgayGiao;
            leMaKH.EditValue        = editBH[0].MaKH;
            leNhanVienBH.EditValue  = editBH[0].NhanVienBH;

            for (int i = 0; i < editBH.Count; i++)
            {
                DataRow dr = dsGcMain.Tables[0].NewRow();
                dr[0] = editBH[i].MaHH;
                dr[1] = editBH[i].MaHH;
                dr[2] = editBH[i].DonVi;
                dr[3] = editBH[i].SoLuong;
                dr[4] = editBH[i].DonGia;
                dr[5] = editBH[i].ThanhTien;
                dr[6] = editBH[i].ChietKhauTiLe;
                dr[7] = editBH[i].ChietKhau;
                dr[8] = editBH[i].ThanhToan;
                dsGcMain.Tables[0].Rows.Add(dr);
            }
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
            addColumns(dataTable, typeof(float), "colSoLuong");
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

        private void gvMain_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv.FocusedColumn.FieldName == "colThanhTien" ||
                gv.FocusedColumn.FieldName == "colChietKhauTiLe" ||
                gv.FocusedColumn.FieldName == "colChietKhau" ||
                gv.FocusedColumn.FieldName == "colThanhToan")
            {
                double t = 0;
                if (!double.TryParse(e.Value.ToString(), out t))
                {
                    e.Valid = false;
                    e.ErrorText = "Vui lòng chỉ nhập số !";
                }
                else if (t < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Giá trị không hợp lệ !";
                }
                else
                {
                    e.Valid = true;
                    e.ErrorText = "";
                }
            }
        }
        void GvMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            if (e.Column.FieldName == "colMa")
            {
                DataRowView value = leMaHang.GetDataSourceRowByKeyValue(gv.GetRowCellValue(e.RowHandle,gv.Columns["colMa"])) as DataRowView;
                gv.SetFocusedRowCellValue("colTen", gv.GetFocusedRowCellValue("colMa"));
                gv.SetFocusedRowCellValue("colDonVi", value["Unit"]);
                return;
            }
            else if (e.Column.FieldName == "colTen")
            {
                if (gv.GetFocusedRowCellValue(gv.Columns["colTen"]) != gv.GetFocusedRowCellValue("colMa"))
                {
                    gv.SetFocusedRowCellValue("colMa", gv.GetRowCellValue(e.RowHandle, gv.Columns["colTen"]));
                    DataRowView value = leTenHang.GetDataSourceRowByKeyValue(gv.GetRowCellValue(e.RowHandle,gv.Columns["colTen"])) as DataRowView;
                    gv.SetFocusedRowCellValue("colDonVi", value["Unit"]);
                }
                return;
            }
            if (e.Column.FieldName == "colSoLuong")
            {
                if (e.Value.ToString() == "")
                    return;
                float colSoLuong = e.Value.ToString() == "" ? int.MaxValue :float.Parse(e.Value.ToString());
                float colDonGia = GetColValue(gv, "colDonGia");
                float colChietKhau = GetColValue(gv, "colChietKhau");
                if (colDonGia != int.MaxValue)
                    gv.SetFocusedRowCellValue("colThanhTien", colDonGia * colSoLuong);
                if (colChietKhau != int.MaxValue)
                    gv.SetFocusedRowCellValue("colChietKhau", colChietKhau * colSoLuong);
                gv.SetFocusedRowCellValue("colThanhToan", colDonGia * colSoLuong - colChietKhau * colSoLuong);
            }
            if (e.Column.FieldName == "colDonGia")
            {
                if (e.Value.ToString() == "")
                    return;
                float colDonGia = e.Value.ToString() == "" ? int.MaxValue : float.Parse(e.Value.ToString());
                float colSoLuong = GetColValue(gv, "colSoLuong");
                float colChietKhau = GetColValue(gv, "colChietKhau") == int.MaxValue ? 0: GetColValue(gv, "colChietKhau");
                if (colDonGia != int.MaxValue && colSoLuong != int.MaxValue)
                {
                    gv.SetFocusedRowCellValue("colThanhTien", colDonGia * colSoLuong);
                    gv.SetFocusedRowCellValue("colThanhToan", colDonGia * colSoLuong - colChietKhau);
                }
                return;
            }
            if (e.Column.FieldName == "colChietKhauTiLe")
            {
                if (e.Value.ToString() == "")
                    return;
                float colChietKhauTiLe = float.Parse(e.Value.ToString());
                float colDonGia = GetColValue(gv, "colDonGia");
                float colSoLuong = GetColValue(gv, "colSoLuong");
                if (colDonGia != int.MaxValue && colSoLuong != int.MaxValue )
                {
                    gv.SetFocusedRowCellValue("colChietKhau", colDonGia * colSoLuong * colChietKhauTiLe / 100);
                    gv.SetFocusedRowCellValue("colThanhToan", colDonGia * colSoLuong * (100 - colChietKhauTiLe) / 100);
                }
                return;
            }
            else if (e.Column.FieldName == "colChietKhau")
            {
                if (e.Value.ToString() == "")
                    return;
                float colChietKhau = float.Parse(e.Value.ToString());
                float colDonGia = GetColValue(gv, "colDonGia");
                float colSoLuong = GetColValue(gv, "colSoLuong");
                if (colDonGia != int.MaxValue && colSoLuong != int.MaxValue)
                {
                    if (GetColValue(gv, "colChietKhauTiLe") / 100 != colChietKhau / (colDonGia * colSoLuong))
                        gv.SetFocusedRowCellValue("colChietKhauTiLe", colChietKhau / (colDonGia * colSoLuong));
                    gv.SetFocusedRowCellValue("colThanhToan", colDonGia * colSoLuong - colChietKhau);
                }
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView grv = gvcMain.Views[0] as GridView;
            while (grv.RowCount > 1)
            {
                grv.DeleteRow(0);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime        _NgayLap            = DateTime.Parse(deNgay.EditValue.ToString());                                                                         
            string          _KhoXuat            = leKhoXuat.EditValue.ToString();
            string          _MaKH               = leMaKH.EditValue.ToString();
            string          _TenKH              =            leKH.Text.ToString();
            string          _NhanVienBH         = leNhanVienBH.EditValue.ToString();
            string          _DiaChi             = txtDC.Text;
            string          _GhiChu             = txtGC.Text;
            string          _DienThoai          = txtSDT.Text;
            string          _SoHoaDonVat        = txtHoaDonVAT.Text;
            string          _SoPhieuNhapTay     = txtSoPhieu.Text;
            string          _DieuKhoanThanhToan = gleDKTT.Text;
            string          _HinhThucTT         = gleHTTT.Text;
            DateTime        _HanTT              = DateTime.Parse(deHanTT.Text);
            DateTime        _NgayGiao           = DateTime.Parse(deNgayGiao.Text);
            xl(
                _NgayLap             ,
                _KhoXuat             ,
                _MaKH                ,
                _TenKH               ,
                _NhanVienBH          ,
                _DiaChi              ,
                _GhiChu              ,
                _DienThoai           ,
                _SoHoaDonVat         ,
                _SoPhieuNhapTay      ,
                _DieuKhoanThanhToan  ,
                _HinhThucTT          ,
                _HanTT               ,
                _NgayGiao
                );
            btnThem_ItemClick(sender, e);
        }

        void xl(
                DateTime    _NgayLap            ,
                string      _KhoXuat            ,
                string      _MaKH               ,
                string      _TenKH              ,
                string      _NhanVienBH         ,
                string      _DiaChi             ,
                string      _GhiChu             ,
                string      _DienThoai          ,
                string      _SoHoaDonVat        ,
                string      _SoPhieuNhapTay     ,
                string      _DieuKhoanThanhToan ,
                string      _HinhThucTT         ,
                DateTime    _HanTT              ,
                DateTime    _NgayGiao
            )
        {
            List<CBanHang> listBH = new List<CBanHang>();
            string _DonVi             ;
            float _DonGia             ;
            float _SoLuong            ;
            float _ThanhTien          ;
            float _ChietKhauTiLe      ;
            float _ChietKhau          ;
            float _ThanhToan          ;
            string _MaHH              ;
            string _TenHH             ;

            for (int i = 0; i < dsGcMain.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dsGcMain.Tables[0].Rows[i];
                _DonVi = dr["colDonVi"].ToString();
                _DonGia = dr["colDonGia"].ToString() == "" ? 0 : float.Parse(dr["colDonGia"].ToString());
                _SoLuong = dr["colSoLuong"].ToString() == "" ? 0 : float.Parse(dr["colSoLuong"].ToString());
                _ThanhTien = dr["colThanhTien"].ToString() == "" ? 0 : float.Parse(dr["colThanhTien"].ToString());
                _ChietKhauTiLe = dr["colChietKhauTiLe"].ToString() == "" ? 0 : float.Parse(dr["colChietKhauTiLe"].ToString());
                _ChietKhau = dr["colChietKhau"].ToString() == "" ? 0 : float.Parse(dr["colChietKhau"].ToString());
                _ThanhToan = dr["colThanhToan"].ToString() == "" ? 0 : float.Parse(dr["colThanhToan"].ToString());
                _MaHH = dr["colMa"].ToString();
                _TenHH = gvMain.GetRowCellDisplayText(i, "colTen").ToString();


                CBanHang bh = new CBanHang
                    (
                        txtMa.Text,
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
                        _SoLuong,
                        _DonGia,
                        _ThanhTien,
                        _ChietKhauTiLe,
                        _ChietKhau,
                        _ThanhToan
                    );
                listBH.Add(bh);
            }
            if (add == true)
                BUS_KhoXuat.ThemBH(listBH);
            else
                BUS_KhoXuat.SuaBH(listBH);
        }

        private static float GetColValue(GridView gv,string colName)
        {
            return gv.GetFocusedRowCellValue(gv.Columns[colName]).ToString() == "" ? int.MaxValue : float.Parse(gv.GetFocusedRowCellValue(gv.Columns[colName]).ToString());
        }
    }
}