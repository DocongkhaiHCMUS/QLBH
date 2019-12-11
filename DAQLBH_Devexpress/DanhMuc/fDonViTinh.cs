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

namespace DAQLBH_Devexpress
{
    public partial class fDonViTinh : fBaseStatic
    {
        public delegate void sendMessage();
        public fDonViTinh()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcMain.DataSource = BUS_DonViTinh.GetDVT();

            gvMain.Columns[0].FieldName = "Unit_ID";
            gvMain.Columns[1].FieldName = "Unit_Name";
            gvMain.Columns[2].FieldName = "Description";
            gvMain.Columns[3].FieldName = "Active";

            gvMain.IndicatorWidth = 45;
            gvMain.CustomDrawRowIndicator += GvMain_CustomDrawRowIndicator;
        }

        private void GvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}