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

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fMainBH : DevExpress.XtraEditors.XtraForm
    {
        public delegate void BanKebtnThem();
        public delegate void BanKebtnSua(List<CBanHang> t);
        bool sale;
        public fMainBH(bool isSale = true)
        {
            InitializeComponent();
            sale = isSale;
            Init();
        }

        private void Init()
        {
            if (sale == true)
            {
                Text = "Bán Hàng";
                this.IconOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.bosaleitem_32x32;
                btnPhieu.Caption = "Phiếu xuất hàng";
                fBaseMH_BH bh = new fBaseMH_BH();
                bh.MdiParent = this;
                bh.Show();
            }
            else
            {
                Text = "Mua Hàng";
                this.IconOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.boorderitem_32x32;
                btnPhieu.Caption = "Phiếu nhập hàng";
                fBaseMH_BH mh = new fBaseMH_BH(false);
                mh.MdiParent = this;
                mh.Show();
            }
        }

        private void btnPhieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Them();
        }

        private void Them()
        {
            Form frm;
            if (sale == true)
            {
                frm = KiemTraTonTai(typeof(fBaseMH_BH), "Phiếu xuất hàng");
            }
            else
            {
                frm = KiemTraTonTai(typeof(fBaseMH_BH), "Phiếu nhập hàng");
            }

            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                if (sale == true)
                {
                    fBaseMH_BH bh = new fBaseMH_BH();
                    bh.MdiParent = this;
                    bh.Show();
                }
                else
                {
                    fBaseMH_BH mh = new fBaseMH_BH(false);
                    mh.MdiParent = this;
                    mh.Show();
                }
            }
        }

        void SuaBH(List<CBanHang> cbh)
        {
            Form frm = KiemTraTonTai(typeof(fBaseMH_BH), "Phiếu xuất hàng");
            if (frm != null)
            {
                frm.Close();
            }
            fBaseMH_BH bh = new fBaseMH_BH(true, false, cbh);
            bh.MdiParent = this;
            bh.Show();
        }

        private Form KiemTraTonTai(Type type, string text)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == type && f.Text == text)
                {
                    return f;
                }
            }
            return null;
        }

        private Form KiemTraTonTai(Type type)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == type)
                {
                    return f;
                }
            }
            return null;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fBaseBanKe));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                if (sale == true)
                {
                    fBaseBanKe bh = new fBaseBanKe(true, Them, SuaBH);
                    bh.MdiParent = this;

                    Action.Module = "Bản Kê";
                    Action.ActionName = "Xem";
                    Action.LuuThongTin();

                    bh.Show();
                }
                else
                {
                    fBaseBanKe mh = new fBaseBanKe(false, Them, SuaMH);
                    mh.MdiParent = this;

                    Action.Module = "Bản Kê";
                    Action.ActionName = "Xem";
                    Action.LuuThongTin();

                    mh.Show();
                }
            }
        }

        private void SuaMH(List<CBanHang> t)
        {
            Form frm = KiemTraTonTai(typeof(fBaseMH_BH), "Phiếu nhập hàng");
            if (frm != null)
            {
                frm.Close();
            }
            fBaseMH_BH mh = new fBaseMH_BH(false, false, t);
            mh.MdiParent = this;
            mh.Show();
        }

        private void btnHangHoa_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            fThemHangHoa hh = new fThemHangHoa();
            hh.ShowDialog();
        }

        private void btnKhachhang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            fThemKhachHang kh = new fThemKhachHang();
            kh.ShowDialog();
        }

        private void btnKhoHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            fThemKho kho = new fThemKho();
            kho.ShowDialog();
        }
    }
}