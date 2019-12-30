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
using QLBH_DTO;
using QLBH_BUS;
using DevExpress.XtraGrid.Views.Grid;

namespace DAQLBH_Devexpress.HeThong
{
    public partial class fSuaVaiTro : DevExpress.XtraEditors.XtraForm
    {
        DataTable table;
        CQuyen editq = new CQuyen();
        bool add;
        public fSuaVaiTro(bool isAdd = true,CQuyen q =null)
        {
            InitializeComponent();

            if (isAdd == false && q == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                table = BUS_PhanQuyen.LoadPhanQuyen("admin");
                Text = "Thêm Vai Trò";
            }
            else
            {
                editq = q;
                table = BUS_PhanQuyen.LoadPhanQuyen(q.ID);
                Text = "Sửa thông tin vai trò";
            }
            add = isAdd;
            gcRule.DataSource = table;
            Init();
        }

        private void Init()
        {
            gvRule.Columns[0].FieldName = "Object_ID";
            gvRule.Columns[1].FieldName = "AllowView";
            gvRule.Columns[2].FieldName = "AllowEdit";
            gvRule.Columns[3].FieldName = "AllowAdd";
            gvRule.Columns[4].FieldName = "AllowDelete";
            gvRule.Columns[5].FieldName = "Active";
            if (add == true)
                phatSinhMa();
            else
                LoadDuLieuBP();
        }

        private void LoadDuLieuBP()
        {
            txtMa.Enabled = false;
            txtMa.Text              = editq.ID;
            txtTen.Text             = editq.Name;
            txtDienGiai.Text        = editq.Description;
            checkKichHoat.Checked   = editq.ACTIVE;
        }

        private void phatSinhMa()
        {
            DataTable table = BUS_PhanQuyen.LoadPermision();
            var query = from tb in table.AsEnumerable()
                        where tb.Field<string>("ID").Contains("VT")
                        select new
                        {
                            maVT = tb.Field<string>("ID")
                        };

            DataTable dttb = new DataTable();
            dttb.Columns.Add("ID", typeof(string));

            foreach (var item in query)
            {
                dttb.Rows.Add(item.maVT);
            }

            string max, currentMa;
            int num;
            try
            {

                max = dttb.Compute("Max(ID)", "").ToString();
                num = int.Parse(max.Substring(2)) + 1;
                currentMa = "VT" + num.ToString("000000");
                txtMa.Text = currentMa;
            }
            catch
            {
                currentMa = "VT000001";
                txtMa.Text = currentMa;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                XtraMessageBox.Show("Mã Vai trò không được để trống", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTen.Text == "")
            {
                XtraMessageBox.Show("Tên Vai trò không được để trống", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            editq.ID             =     txtMa.Text                ;
            editq.Name           =     txtTen.Text               ;
            editq.Description    =     txtDienGiai.Text          ;
            editq.ACTIVE         =     checkKichHoat.Checked     ;

            xl();
        }

        private void xl()
        {
            List<CQuyenHan> lqh = new List<CQuyenHan>();
            string _PER_ID        = editq.ID;
            string _Object_ID     ;
            bool   _AllowView     ;
            bool   _AllowAdd      ;
            bool   _AllowDelete   ;
            bool   _AllowEdit     ;
            bool   _Active        ;

            GridView gv = gvRule as GridView;
            for(int i=0;i<gvRule.RowCount;i++)
            {
                _Object_ID    = gv.GetRowCellValue(i, "Object_ID").ToString();
                _AllowView    = bool.Parse(gv.GetRowCellValue(i, "AllowView").ToString());
                _AllowAdd     = bool.Parse(gv.GetRowCellValue(i, "AllowAdd").ToString());
                _AllowDelete  = bool.Parse(gv.GetRowCellValue(i, "AllowDelete").ToString());
                _AllowEdit    = bool.Parse(gv.GetRowCellValue(i, "AllowEdit").ToString());
                _Active       = bool.Parse(gv.GetRowCellValue(i, "Active").ToString());

                CQuyenHan qh = new CQuyenHan
                    (
                        _PER_ID      ,
                        _Object_ID   ,
                        _AllowView   ,
                        _AllowAdd    ,
                        _AllowDelete ,
                        _AllowEdit   ,
                        _Active
                    );

                lqh.Add(qh);
                if(add==true)
                {

                }
                else
                {
                    BUS_PhanQuyen.SuaVaiTro(editq, lqh);
                }
            }
        }
    }
}