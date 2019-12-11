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
using DevExpress.XtraEditors.DXErrorProvider;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fBaseThem : DevExpress.XtraEditors.XtraForm
    {
        public fBaseThem()
        {
            InitializeComponent();
        }
        protected void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            
        }
    }
}