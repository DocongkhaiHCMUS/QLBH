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
    public partial class fVaiTroQuyenHan : fBaseStatic
    {
        fLuaChon lc= new fLuaChon();
        public fVaiTroQuyenHan()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gcUser.DataSource = BUS_PhanQuyen.LoadUser();

            gvUser.Columns[0].FieldName = "UserID";
            gvUser.Columns[1].FieldName = "UserName";
            gvUser.Columns[2].FieldName = "Group_ID";
            gvUser.Columns[3].FieldName = "Description";
            gvUser.Columns[4].FieldName = "Active";

            gcPermision.DataSource = BUS_PhanQuyen.LoadPermision();
            gvPermision.Columns[0].FieldName = "ID";
            gvPermision.Columns[1].FieldName = "Name";
            gvPermision.Columns[2].FieldName = "Description";
            gvPermision.Columns[3].FieldName = "ACTIVE";

            gvRule.Columns[0].FieldName = "PER_ID";
            gvRule.Columns[1].FieldName = "Object_ID";
            gvRule.Columns[2].FieldName = "AllowView";
            gvRule.Columns[3].FieldName = "AllowEdit";
            gvRule.Columns[4].FieldName = "AllowAdd";
            gvRule.Columns[5].FieldName = "AllowDelete";
            gvRule.Columns[6].FieldName = "Active";

            gvUser.FocusedRowChanged += GvUser_FocusedRowChanged;
            btnLamMoi.ItemClick += BtnLamMoi_ItemClick;
            btnXoa.ItemClick += BtnXoa_ItemClick;
            btnSua.ItemClick += BtnSua_ItemClick;
        }

        private void BtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lc = new fLuaChon(false);
            if (lc.ShowDialog() == DialogResult.OK)//Vai trò
            {
                
            }
            else if (lc.ShowDialog() == DialogResult.Yes)//Người dùng
            {
                
            }
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(lc.ShowDialog() == DialogResult.OK)//Vai trò
            {
                string ma = gvPermision.GetFocusedRowCellValue("ID").ToString();
                BUS_PhanQuyen.XoaVaiTro(ma);
                return;
            }
            else if (lc.ShowDialog() == DialogResult.Yes)//Người dùng
            {
                string ma = gvUser.GetFocusedRowCellValue("UserID").ToString();
                BUS_PhanQuyen.XoaUser(ma);
                return;
            }
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcUser.DataSource = BUS_PhanQuyen.LoadUser();
            string ma = gvUser.GetFocusedRowCellValue("Group_ID").ToString();
            gcRule.DataSource = BUS_PhanQuyen.LoadPhanQuyen(ma);
        }

        private void GvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvUser.FocusedRowHandle >= 0 && gvUser.FocusedRowHandle <= gvUser.RowCount)
            {
                string ma = gvUser.GetFocusedRowCellValue("Group_ID").ToString();
                gcRule.DataSource = BUS_PhanQuyen.LoadPhanQuyen(ma);
            }
        }
    }
}