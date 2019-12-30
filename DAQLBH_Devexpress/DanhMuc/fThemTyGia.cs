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
using QLBH_DTO;
using QLBH_BUS;

namespace DAQLBH_Devexpress.DanhMuc
{
    public partial class fThemTyGia : fBaseThem
    {
        fTiGia.sendMessage sendTG;
        DXErrorProvider error = new DXErrorProvider();
        CTyGia editTyGia = new CTyGia();
        bool add;
        public fThemTyGia(bool isAdd = true, CTyGia tien = null, fTiGia.sendMessage send = null)
        {
            InitializeComponent();

            if (isAdd == false && tien == null)
            {
                XtraMessageBox.Show("ERROR : Dữ liệu không được cung cấp để thực hiện hành động !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            if (isAdd == true)
            {
                Text = "Thêm tiền tệ";
            }
            else
            {
                editTyGia = tien;
                Text = "Sửa thông tin tiền tệ";
            }
            add = isAdd;
            sendTG = send;

            Init();
        }

        private void Init()
        {
            if (add == false)
                LoadDuLieuTienTe();
            btnLuu.Click += BtnLuu_Click;
        }

        private void LoadDuLieuTienTe()
        {
            txtMa.Text = editTyGia.MaTienTe;
            txtMa.Enabled = false;
            txtTen.Text = editTyGia.TenTienTe;
            calcTyGia.Value = decimal.Parse(editTyGia.TyGia.ToString());
            ceConQL.Checked = editTyGia.ConQL;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                error.SetError(txtTen, "Vui lòng điền thông tin !");
            }
            else
            {
                error.SetError(txtTen, string.Empty);
            }

            if (txtMa.Text == "")
            {
                error.SetError(txtMa, "Vui lòng điền thông tin !");
            }
            else if (add == true && BUS_TienTe.KiemTraTienTe(txtMa.Text))
            {
                error.SetError(txtMa, "Mã đã tồn tại, vui lòng chọn mã khác !");
            }
            else
            {
                error.SetError(txtMa, string.Empty);
            }

            if (error.GetError(txtMa) == "" && error.GetError(txtTen) == "")
            {
                if (add == true)
                    xlThem();
                else
                    xlSua();
            }
        }

        private void xlSua()
        {
            editTyGia.MaTienTe = txtMa.Text;
            editTyGia.TenTienTe = txtTen.Text;
            editTyGia.TyGia = float.Parse(calcTyGia.Value.ToString());
            editTyGia.ConQL = ceConQL.Checked;
            BUS_TienTe.SuaTienTe(editTyGia);
            sendTG();

            Action.Module = "Tỷ Giá";
            Action.ActionName = "Sửa";
            Action.Reference = txtMa.Text;
            Action.LuuThongTin();

            Close();
        }

        private void xlThem()
        {
            CTyGia tg = new CTyGia(txtMa.Text, txtTen.Text, float.Parse(calcTyGia.Value.ToString()), ceConQL.Checked);
            BUS_TienTe.ThemTienTe(tg);
            sendTG();

            Action.Module = "Tỷ Giá";
            Action.ActionName = "Thêm";
            Action.Reference = txtMa.Text;
            Action.LuuThongTin();

            this.Close();
        }
    }
}