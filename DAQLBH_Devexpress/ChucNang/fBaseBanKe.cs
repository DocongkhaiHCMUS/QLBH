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

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fBaseBanKe : fBaseStatic
    {
        public fBaseBanKe()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gvcMain.DataSource = BUS_KhoXuat.LayChungTuBH();

            gvMain.Columns[0].FieldName =  "Outward_ID"     ;
            gvMain.Columns[1].FieldName =  "RefDate"        ;
            gvMain.Columns[2].FieldName =  "Description"    ;
            gvMain.Columns[3].FieldName =  "Product_ID"     ;
            gvMain.Columns[4].FieldName =  "ProductName"    ;
            gvMain.Columns[5].FieldName =  "Stock_ID"       ;
            gvMain.Columns[6].FieldName =  "Unit"           ;
            gvMain.Columns[7].FieldName =  "Quantity"       ;
            gvMain.Columns[8].FieldName =  "UnitPrice"      ;
            gvMain.Columns[9].FieldName =  "Charge"         ;
            gvMain.Columns[10].FieldName = "DiscountRate"   ;
            gvMain.Columns[11].FieldName = "Discount"       ;
            gvMain.Columns[12].FieldName = "Amount"         ;

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
            btnThem.ItemClick += BtnThem_ItemClick;
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvcMain.DataSource = BUS_KhoXuat.LayChungTuBH();
        }
    }
}