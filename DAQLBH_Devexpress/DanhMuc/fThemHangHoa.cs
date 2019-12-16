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
using DevExpress.XtraEditors.DXErrorProvider;
using QLBH_DTO;
using QLBH_BUS;
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemHangHoa : fBaseKho_NV_HH
    {
        fHangHoa.sendMessage sendHH;
        DXErrorProvider error = new DXErrorProvider();
        DataTable table;
        CHangHoa editHH = new CHangHoa();
        bool add;
        string nameImage, sourceImg, pathPictureFolder = Application.StartupPath.Replace(@"bin\Debug", @"\Picture\");
        public fThemHangHoa(bool isAdd = true, CHangHoa hh = null, fHangHoa.sendMessage send = null)
        {
            InitializeComponent();

            if (isAdd == false && hh == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_HangHoa.LayHangHoa();
                Text = "Thêm Hàng hóa";
            }
            else
            {
                editHH = hh;
                Text = "Sửa thông tin Hàng hóa";
            }
            add = isAdd;
            sendHH = send;

            Init();
        }

        private void Init()
        {
            List<object> list = new List<object>
            {
                new { ID = 0,Name="Hàng hóa" },
                new { ID = 1,Name="Dịch vụ" }
            };
            cbLoaiHH.Properties.DataSource = list;
            cbLoaiHH.Properties.DisplayMember = "Name";
            cbLoaiHH.Properties.ValueMember = "ID";
            LookUpColumnInfo col_t = new LookUpColumnInfo("Name", "");
            cbLoaiHH.Properties.Columns.Add(col_t);
            cbLoaiHH.EditValue = 0;

            leKhoMacDinh.Properties.DataSource = BUS_KhoXuat.LayKhoDonGian();
            leKhoMacDinh.Properties.DisplayMember = "STOCK_Name";
            leKhoMacDinh.Properties.ValueMember = "STOCK_ID";
            LookUpColumnInfo col = new LookUpColumnInfo("STOCK_ID", "Mã");
            LookUpColumnInfo col1 = new LookUpColumnInfo("STOCK_Name", "Tên");
            leKhoMacDinh.Properties.Columns.Add(col1);
            leKhoMacDinh.Properties.Columns.Add(col);
            leKhoMacDinh.EditValue = ((DataTable)leKhoMacDinh.Properties.DataSource).Rows[0]["STOCK_ID"];
            leKhoMacDinh.Properties.Buttons[1].Click += btnThemKho_ThemHangHoa_Click;

            lePhanLoai.Properties.TextEditStyle = TextEditStyles.Standard;
            lePhanLoai.Properties.DataSource = BUS_HangHoa.LayNhomHang();
            lePhanLoai.Properties.DisplayMember = "ProductGroup_Name";
            lePhanLoai.Properties.ValueMember = "ProductGroup_ID";
            col = new LookUpColumnInfo("ProductGroup_ID", "Mã");
            col1 = new LookUpColumnInfo("ProductGroup_Name", "Tên");
            lePhanLoai.Properties.Columns.Add(col1);
            lePhanLoai.Properties.Columns.Add(col);
            lePhanLoai.EditValue = ((DataTable)lePhanLoai.Properties.DataSource).Rows[0]["ProductGroup_ID"];
            lePhanLoai.Properties.Buttons[1].Click += btnThemNhomhang_ThemHangHoa_Click;

            leDonVi.Properties.TextEditStyle = TextEditStyles.Standard;
            leDonVi.Properties.DataSource = BUS_DonViTinh.GetDVTDonGian();
            leDonVi.Properties.DisplayMember = "UNIT_Name";
            leDonVi.Properties.ValueMember = "UNIT_ID";
            col = new LookUpColumnInfo("UNIT_ID", "Mã");
            col1 = new LookUpColumnInfo("UNIT_Name", "Tên");
            leDonVi.Properties.Columns.Add(col1);
            leDonVi.Properties.Columns.Add(col);
            leDonVi.EditValue = ((DataTable)leDonVi.Properties.DataSource).Rows[0]["UNIT_ID"];
            leDonVi.Properties.Buttons[1].Click += btnThemDV_ThemHangHoa_Click;

            leNCC.Properties.TextEditStyle = TextEditStyles.Standard;
            leNCC.Properties.DataSource = BUS_NhaCungCap.LayNhaCC();
            leNCC.Properties.DisplayMember = "CustomerName";
            leNCC.Properties.ValueMember = "Customer_ID";
            col = new LookUpColumnInfo("Customer_ID", "Mã");
            col1 = new LookUpColumnInfo("CustomerName", "Tên");
            leNCC.Properties.Columns.Add(col1);
            leNCC.Properties.Columns.Add(col);
            leNCC.EditValue = ((DataTable)leNCC.Properties.DataSource).Rows[0]["Customer_ID"];
            leNCC.Properties.Buttons[1].Click += btnThemNCC_ThemHangHoa_Click;

            peHinhAnh.Properties.NullText = "Ảnh";
            peHinhAnh.Click += PeHinhAnh_Click;

            txtMa.TextChanged += TxtMa_TextChanged;
            txtMaVachNSX.TextChanged += TxtMaVachNSX_TextChanged;

            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuHH();
        }

        private void PeHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadFileSteam = new OpenFileDialog();
            try
            {
                if (uploadFileSteam.ShowDialog() == DialogResult.OK)
                {
                    peHinhAnh.Image = Image.FromFile(uploadFileSteam.FileName);
                    sourceImg = uploadFileSteam.FileName;
                    nameImage = uploadFileSteam.SafeFileName;
                }
            }
            catch 
            { 
            }
        }

        private void TxtMaVachNSX_TextChanged(object sender, EventArgs e)
        {
            txtMa.Text = txtMaVachNSX.Text;
        }

        private void TxtMa_TextChanged(object sender, EventArgs e)
        {
            txtMaVachNSX.Text = txtMa.Text;
        }

        private void LoadDuLieuHH()
        {
            txtMa.Enabled = false;
            txtMa.Text                        =       editHH.Product_ID                                                                                   ;
            txtTen.Text                       =       editHH.Product_Name                                                                                 ;
            cbLoaiHH.EditValue                =       editHH.Product_Type_ID                                                                              ;
            lePhanLoai.EditValue              =       editHH.Product_Group_ID                                                                             ;
            leKhoMacDinh.EditValue            =       editHH.Provider_ID                                                                                  ;
            leDonVi.EditValue                 =       editHH.Unit                                                                                         ;
            if(editHH.Photo!="")
            peHinhAnh.Image                   =       Image.FromFile(pathPictureFolder + editHH.Photo)          ;
            calcGiaSi.EditValue               =       editHH.Org_Price                                                                                    ;
            calcGiaMua.EditValue              =       editHH.Sale_Price                                                                                   ;
            calcGiaLe.EditValue               =       editHH.Retail_Price                                                                                 ;
            leNCC.EditValue                   =       editHH.Customer_ID                                                                                  ;
            leNCC.Text                        =       editHH.Customer_Name                                                                                ;
            calcTonKhoToiThieu.EditValue      =       editHH.MinStock                                                                                     ;
            checkConQL.Checked                =       editHH.Active                                                                                       ;
        }

        private void phatSinhMa()
        {
            var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("Product_ID").Contains("HH")
                        select new
                        {
                            maHH = tb.Field<string>("Product_ID")
                        };

            DataTable dttb = new DataTable();
            dttb.Columns.Add("Product_ID", typeof(string));

            foreach (var item in query)
            {
                dttb.Rows.Add(item.maHH);
            }
            string max, currentMa;
            int num;
            try
            {

                max = dttb.Compute("Max(Product_ID)", "").ToString();
                num = int.Parse(max.Substring(2)) + 1;
                currentMa = "HH" + num.ToString("000000");
                txtMa.Text = currentMa;
            }
            catch
            {
                currentMa = "K000001";
                txtMa.Text = currentMa;
            }
        }

        private void btnThemNCC_ThemHangHoa_Click(object sender, EventArgs e)
        {
            fThemNCC ncc = new fThemNCC();
            ncc.ShowDialog();
        }

        private void btnThemDV_ThemHangHoa_Click(object sender, EventArgs e)
        {
            fThemSimple nh = new fThemSimple(true, null, null,(int)1);
            nh.ShowDialog();
        }

        private void btnThemNhomhang_ThemHangHoa_Click(object sender, EventArgs e)
        {
            fThemSimple nh = new fThemSimple(true, null, null,(float)1);
            nh.ShowDialog();
        }

        private void btnThemKho_ThemHangHoa_Click(object sender, EventArgs e)
        {
            fThemKho kho = new fThemKho(true, null, null);
            kho.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                error.SetError(txtTen, "Vui lòng điền thông tin !");
            }
            else
            {
                error.SetError(txtTen, string.Empty);
            }

            if (lePhanLoai.Text == "")
            {
                error.SetError(lePhanLoai, "Vui lòng điền thông tin !");
            }
            else
            {
                error.SetError(lePhanLoai, string.Empty);
            }

            if (leDonVi.Text == "")
            {
                error.SetError(leDonVi, "Vui lòng điền thông tin !");
            }
            else
            {
                error.SetError(leDonVi, string.Empty);
            }

            if (txtMa.Text == "")
            {
                error.SetError(txtMa, "Vui lòng điền thông tin !");
            }
            else if (add == true && BUS_HangHoa.KiemTraHH(txtMa.Text))
            {
                error.SetError(txtMa, "Mã đã tồn tại, vui lòng chọn mã khác !");
            }
            else
            {
                error.SetError(txtMa, string.Empty);
            }

            if (error.GetError(txtMa) == "" && error.GetError(txtTen) == "" &&
                error.GetError(leDonVi) == "" && error.GetError(lePhanLoai) == "")
            {
                if (add == true)
                    xlThem();
                else
                    xlSua();
            }
        }

        private void btnLichSuGiaoDich_Click(object sender, EventArgs e)
        {
            fLichSuGiaoDich ls = new fLichSuGiaoDich();
            ls.ShowDialog();
        }

        private void xlSua()                                                                                                
        {                                                                                                                   ;
            editHH.Product_ID             =        txtMa.Text                                                               ;
            editHH.Product_Name           =        txtTen.Text                                                              ;
            editHH.Product_Type_ID        =        int.Parse(cbLoaiHH.EditValue.ToString())                                 ;
            editHH.Product_Group_ID       =        lePhanLoai.EditValue.ToString()                                          ;
            editHH.Provider_ID            =        leKhoMacDinh.EditValue.ToString()                                        ;
            editHH.Unit                   =        leDonVi.EditValue.ToString()                                             ;
            editHH.Photo                  =        nameImage==null?"":nameImage                                             ;
            editHH.Org_Price              =        calcGiaSi.Text ==""? 0 :float.Parse(calcGiaSi.Text)                      ;
            editHH.Sale_Price             =        calcGiaMua.Text == "" ? 0 : float.Parse(calcGiaMua.Text)                 ;
            editHH.Retail_Price           =        calcGiaLe.Text == "" ? 0 : float.Parse(calcGiaLe.Text)                   ;
            editHH.Customer_ID            =        leNCC.Text==""?"":leNCC.EditValue.ToString()                             ;
            editHH.Customer_Name          =        leNCC.EditValue.ToString() == "" ? "" : leNCC.Text                       ;
            editHH.MinStock               =        calcTonKhoToiThieu.Text == "" ? 0 : int.Parse(calcTonKhoToiThieu.Text)   ;
            editHH.Active                 =        checkConQL.Checked                                                       ;

            BUS_HangHoa.SuaHh(editHH);
            sendHH();
            this.Close();
        }

        private void xlThem()
        {
            try
            {
                File.Copy(sourceImg, pathPictureFolder + nameImage);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            CHangHoa hh = new CHangHoa
                (
                    txtMa.Text                                                                  ,
                    txtTen.Text                                                                 ,
                    int.Parse(cbLoaiHH.EditValue.ToString())                                    ,
                    lePhanLoai.EditValue.ToString()                                             ,
                    leKhoMacDinh.EditValue.ToString()                                           ,
                    leDonVi.EditValue.ToString()                                                ,
                    nameImage                                                                   ,
                    calcGiaSi.Text ==""? 0 :float.Parse(calcGiaSi.Text)                         ,
                    calcGiaMua.Text == "" ? 0 : float.Parse(calcGiaMua.Text)                    ,
                    calcGiaLe.Text == "" ? 0 : float.Parse(calcGiaLe.Text)                      ,
                    leNCC.Text==""?"":leNCC.EditValue.ToString()                                ,
                    leNCC.EditValue.ToString() == "" ? "" : leNCC.Text                          ,
                    calcTonKhoToiThieu.Text == "" ? 0 : int.Parse(calcTonKhoToiThieu.Text)      ,
                    checkConQL.Checked
                );
            BUS_HangHoa.ThemHH(hh);
            sendHH?.Invoke();
            this.Close();
        }
    }
}