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
using DAQLBH_Devexpress.DanhMuc;
using QLBH_DTO;
using QLBH_BUS;

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fPhieuTraTien : fBaseKho_NV_HH
    {
        bool PThu;
        DataTable table;
        CCongNo addCN;
        public fPhieuTraTien(bool thu = true,CCongNo cn = null) 
        {
            InitializeComponent();
            PThu = thu;
            addCN = cn;
            Init();
        }

        private void Init()
        {
            if(PThu == true)
            {
                table = BUS_CongNo.LoadPhieuThu();
            }
            else
            {
                table = BUS_CongNo.LoadPhieuChi();
            }

            gleNhanVien.Properties.DataSource = BUS_NhanVien.LayNhanVienDonGian();
            gleNhanVien.Properties.ValueMember = "EMPLOYEE_ID";
            gleNhanVien.Properties.DisplayMember = "EMPLOYEE_Name";
            gleNhanVien.EditValue = ((DataTable)gleNhanVien.Properties.DataSource).Rows[0]["EMPLOYEE_ID"];

            txtPhieu.Enabled = false;
            PhatSinhMa();
            LoadDuLieu();
        }

        private void LoadDuLieu()
        {
            txtKH.Text = addCN.TenKH;
            txtCT.Text = addCN.MaBH;
            deNgayLap.EditValue = addCN.NgayLap;
            deNgay.EditValue = DateTime.Now;
            calcSoTien.EditValue = addCN.SoTien;
            calcConNo.EditValue = addCN.SoTienConNo;
            calcTraTien.EditValue = addCN.SoTien;
        }

        private void PhatSinhMa()
        {
            if(PThu==true)
            {
                var query = from tb in table.AsEnumerable()
                            where tb.Field<string>("MaPT").Contains("PT")
                            select new
                            {
                                maPT = tb.Field<string>("MaPT")
                            };

                DataTable dttb = new DataTable();
                dttb.Columns.Add("MaPT", typeof(string));

                foreach (var item in query)
                {
                    dttb.Rows.Add(item.maPT);
                }
                string max, currentMa;
                int num;
                try
                {

                    max = dttb.Compute("Max(MaPT)", "").ToString();
                    num = int.Parse(max.Substring(7)) + 1;
                    currentMa = "PTADMIN" + num.ToString("000000");
                    txtPhieu.Text = currentMa;
                }
                catch
                {
                    currentMa = "PTADMIN000001";
                    txtPhieu.Text = currentMa;
                }
            }
            else
            {
                var query = from tb in table.AsEnumerable()
                            where tb.Field<string>("MaPC").Contains("PC")
                            select new
                            {
                                maPC = tb.Field<string>("MaPC")
                            };

                DataTable dttb = new DataTable();
                dttb.Columns.Add("MaPC", typeof(string));

                foreach (var item in query)
                {
                    dttb.Rows.Add(item.maPC);
                }
                string max, currentMa;
                int num;
                try
                {

                    max = dttb.Compute("Max(MaPC)", "").ToString();
                    num = int.Parse(max.Substring(7)) + 1;
                    currentMa = "PCADMIN" + num.ToString("000000");
                    txtPhieu.Text = currentMa;
                }
                catch
                {
                    currentMa = "PCADMIN000001";
                    txtPhieu.Text = currentMa;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            XLThem();
        }

        private void XLThem()
        {
            string      _MaPT        =   txtPhieu.Text    ;
            DateTime    _NgayLap     =   DateTime.Parse(deNgayLap.EditValue.ToString())    ;
            string      _MaBH        =   txtCT.Text    ;
            string      _MaKH        =   addCN.MaBH    ;
            string      _TenKH       =   txtKH.Text    ;
            decimal     _SoTienTra   =   decimal.Parse(calcTraTien.EditValue.ToString())    ;
            string      _TaoBoi      =   "admin"    ;
            string      _MaNV        =   gleNhanVien.EditValue.ToString()    ;
            string      _GhiChu      =   txtGhiChu.Text    ;

            CCongNo cn = new CCongNo
                (
                    _MaPT          ,
                    _NgayLap       ,
                    _MaBH          ,
                    _MaKH          ,
                    _TenKH         ,
                    _SoTienTra     ,
                    _TaoBoi        ,
                    _MaNV          ,
                    _GhiChu
                );

        }
    }
}