using DevExpress.XtraGrid.Views.Grid;
using QLBH_BUS;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fBoPhan : fBaseStatic
    {
        public delegate void sendMessage();
        public fBoPhan()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_NhanVien.GetBoPhan();

            gvMain.Columns[0].FieldName = "Department_ID";
            gvMain.Columns[1].FieldName = "Department_Name";
            gvMain.Columns[2].FieldName = "Description";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.IndicatorWidth = 30;
            gvMain.CustomDrawRowIndicator += gvMain_CustomDrawRowIndicator;


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
