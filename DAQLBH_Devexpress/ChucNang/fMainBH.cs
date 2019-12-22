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
        public fMainBH()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            fBaseMH_BH bh = new fBaseMH_BH();
            bh.MdiParent = this;
            bh.Show();
        }

        private void btnPhieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ThemBH();
        }

        private void ThemBH()
        {
            Form frm = KiemTraTonTai(typeof(fBaseMH_BH), "Phiếu xuất hàng");
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fBaseMH_BH bh = new fBaseMH_BH();
                bh.MdiParent = this;
                bh.Show();
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
                fBaseBanKe bh = new fBaseBanKe(ThemBH, SuaBH);
                bh.MdiParent = this;
                bh.Show();
            }
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