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

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fNhanVien : fBaseStatic
    {
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