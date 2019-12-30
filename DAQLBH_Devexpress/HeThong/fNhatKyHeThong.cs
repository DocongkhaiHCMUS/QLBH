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

namespace DAQLBH_Devexpress.HeThong
{
    public partial class fNhatKyHeThong : fBaseStatic
    {
        public fNhatKyHeThong()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            gcMain.DataSource = BUS_NhatKy.LoadNhatKy();

            gvMain.Columns[0].FieldName = "UserID";
            gvMain.Columns[1].FieldName = "MChine";
            gvMain.Columns[2].FieldName = "Created";
            gvMain.Columns[3].FieldName = "Module";
            gvMain.Columns[4].FieldName = "Action_Name";

            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
            btnXoa.ItemClick += BtnXoa_ItemClick;
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                return;
            try
            {
                int rowHandle = gvMain.FocusedRowHandle;
                int ID = int.Parse(((DataTable)gcMain.DataSource).Rows[rowHandle]["SYS_ID"].ToString());
                BUS_NhatKy.XoaNhatKy(ID);
                gcMain.DataSource = BUS_NhatKy.LoadNhatKy();

                Action.Module = "Nhật Ký Hệ Thống";
                Action.ActionName = "Xóa";
                Action.Reference = "ID";
                Action.LuuThongTin();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcMain.DataSource = BUS_NhatKy.LoadNhatKy();
        }
    }
}