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

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fBaseKho_NV_HH : DevExpress.XtraEditors.XtraForm
    {
        public fBaseKho_NV_HH()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}