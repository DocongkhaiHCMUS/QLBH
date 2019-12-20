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
    public partial class fMainBH : DevExpress.XtraEditors.XtraForm
    {
        public fMainBH()
        {
            InitializeComponent();
        }

        private void btnPhieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fBaseMH_BH),"Phiếu nhập hàng");
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
        private Form KiemTraTonTai(Type type,string text)
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

    }
}