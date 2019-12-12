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
            LoadData();

            gvMain.Columns[0].FieldName = "Currency_ID";
            gvMain.Columns[1].FieldName = "CurrencyName";
            gvMain.Columns[2].FieldName = "Exchange";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvMain.Columns[2].DisplayFormat.FormatString = "n0";

            gvMain.IndicatorWidth = 35;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;
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