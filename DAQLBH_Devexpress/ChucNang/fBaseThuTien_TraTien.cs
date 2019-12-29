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

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fBaseThuTien_TraTien : DevExpress.XtraEditors.XtraForm
    {
        bool thu = true;
        public fBaseThuTien_TraTien(bool PThu=true)
        {
            InitializeComponent();
            thu = PThu;
            Init();
        }

        private void Init()
        {
            if (thu == true)
            {
                Text = "Thu Tiền";
                this.IconOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.Finance_sponsor_investment_loan_money_512;
                btnPhieuThu.Caption = "Phiếu Danh Sách Phiếu Thu";
                fPhieuThu pt = new fPhieuThu();
                pt.MdiParent = this;
                pt.Show();
            }
            else
            {
                Text = "Trả Tiền";
                this.IconOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.Finance_cash_cash_payment_512;
                btnPhieuThu.Caption = "Phiếu Danh Sách Phiếu Chi";
                fPhieuThu pc = new fPhieuThu(false);
                pc.MdiParent = this;
                pc.Show();
            }
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

        private void btnPhieuThu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fPhieuThu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                if (thu == true)
                {
                    fPhieuThu pt = new fPhieuThu();
                    pt.MdiParent = this;
                    pt.Show();
                }
                else
                {
                    fPhieuThu pc = new fPhieuThu(false);
                    pc.MdiParent = this;
                    pc.Show();
                }
            }
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fDSCongNo));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                if (thu == true)
                {
                    fDSCongNo cnt = new fDSCongNo();
                    cnt.MdiParent = this;
                    cnt.Show();
                }
                else
                {
                    fDSCongNo cnc = new fDSCongNo(false);
                    cnc.MdiParent = this;
                    cnc.Show();
                }
            }
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fCongNoTraNgay));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                if (thu == true)
                {
                    fCongNoTraNgay cnt = new fCongNoTraNgay();
                    cnt.MdiParent = this;
                    cnt.Show();
                }
                else
                {
                    fCongNoTraNgay cnc = new fCongNoTraNgay(false);
                    cnc.MdiParent = this;
                    cnc.Show();
                }
            }
        }
    }
}