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
using QLBH_DTO;

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
            btnThem.ItemClick += BtnThem_ItemClick;
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lc = new fLuaChon(3);
            DialogResult rs = lc.ShowDialog();
            if (rs == DialogResult.OK)//Vai trò
            {
                fSuaVaiTro vt = new fSuaVaiTro(true);
                vt.ShowDialog();
                return;
            }
            else if (rs == DialogResult.Yes)//Người dùng
            {
                fSuaNguoiDung nd = new fSuaNguoiDung(true);
                nd.ShowDialog();
                return;
            }
        }

        private void BtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lc = new fLuaChon(2);
            DialogResult rs = lc.ShowDialog();
            if (rs == DialogResult.OK)//Vai trò
            {

                string      _ID              =   gvPermision.GetFocusedRowCellValue("ID").ToString();
                string      _Name            =  gvPermision.GetFocusedRowCellValue("Name").ToString();
                string      _Description     =  gvPermision.GetFocusedRowCellValue("Description").ToString();
                bool        _ACTIVE          =  bool.Parse(gvPermision.GetFocusedRowCellValue("ACTIVE").ToString());
                CQuyen q = new CQuyen
                    (
                        _ID           ,
                        _Name         ,
                        _Description  ,
                        _ACTIVE
                    );

                fSuaVaiTro vt = new fSuaVaiTro(false,q);
                vt.ShowDialog();
                return;
            }
            else if (rs == DialogResult.Yes)//Người dùng
            {
                string  _UserID         = gvUser.GetFocusedRowCellValue("UserID").ToString();
                string  _UserName       = gvUser.GetFocusedRowCellValue("UserName").ToString();
                string  _Password       = gvUser.GetFocusedRowCellValue("Password").ToString();
                string  _GroupID        = gvUser.GetFocusedRowCellValue("GroupID").ToString();
                string  _Description    = gvUser.GetFocusedRowCellValue("Description").ToString();
                string  _PartID         = gvUser.GetFocusedRowCellValue("PartID").ToString();
                bool    _Active         = bool.Parse(gvUser.GetFocusedRowCellValue("Active").ToString());

                CUser us = new CUser
                    (
                        _UserID      ,
                        _UserName    ,
                        _Password    ,
                        _GroupID     ,
                        _Description ,
                        _PartID      ,
                        _Active
                    );
                fSuaNguoiDung nd = new fSuaNguoiDung(false, us);
                nd.ShowDialog();
                return;
            }
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rs = lc.ShowDialog();
            if (rs == DialogResult.OK)//Vai trò
            {
                string ma = gvPermision.GetFocusedRowCellValue("ID").ToString();
                BUS_PhanQuyen.XoaVaiTro(ma);
                return;
            }
            else if (rs == DialogResult.Yes)//Người dùng
            {
                string ma = gvUser.GetFocusedRowCellValue("UserID").ToString();
                BUS_PhanQuyen.XoaUser(ma);
                return;
            }
        }

        private void BtnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcUser.DataSource = BUS_PhanQuyen.LoadUser();
            gcPermision.DataSource = BUS_PhanQuyen.LoadPermision();
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