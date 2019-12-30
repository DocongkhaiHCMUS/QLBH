using DAQLBH_Devexpress.ChucNang;
using DAQLBH_Devexpress.DanhMuc;
using DAQLBH_Devexpress.HeThong;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Windows.Forms;

namespace DAQLBH_Devexpress
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fMain()
        {
            InitializeComponent();

            Load += FMain_Load;
            btnKhuVuc.ItemClick += BtnKhuVuc_ItemClick;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            FormClosing += FMain_FormClosing;
            btnKetThuc.ItemClick += BtnKetThuc_ItemClick; 
        }

        private void BtnKetThuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Action.Module = "Hệ Thống";
            Action.ActionName = "Kết Thúc";
            Action.LuuThongTin();

            this.Close();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn thoát ứng dụng ?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void BtnKhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fKhuVuc));
            if(frm!= null)
            {
                frm.Activate();
            }
            else 
            {
                fKhuVuc kv = new fKhuVuc();
                kv.MdiParent = this;

                Action.Module = "Khu Vực";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                kv.Show();
            }
        }

        private Form KiemTraTonTai(Type type)
        {
            foreach(var f in this.MdiChildren)
            {
                if(f.GetType() == type)
                {
                    return f;
                }
            }
            return null;
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

        private void FMain_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            barXinChao.Caption = "Xin chào : " + fDangNhap.userName;
            txtDate.Border = BorderStyles.Style3D;
            txtTime.Border = BorderStyles.Style3D;
            txtDate.Caption = DateTime.Today.ToString("dd/MM/yyyy");
            txtTime.Caption = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Caption = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fKhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fKhachHang kh = new fKhachHang();
                kh.MdiParent = this;

                Action.Module = "Khách Hàng";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                kh.Show();
            }
        }

        private void btnNhaPhanPhoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fNhaCC));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fNhaCC ncc = new fNhaCC();
                ncc.MdiParent = this;

                Action.Module = "Nhà Phân Phối";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                ncc.Show();
            }
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fKhoHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fKhoHang kho = new fKhoHang();
                kho.MdiParent = this;

                Action.Module = "Kho Hàng";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                kho.Show();
            }
        }

        private void btnDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fDonViTinh));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fDonViTinh dvt = new fDonViTinh();
                dvt.MdiParent = this;

                Action.Module = "Đơn Vị Tính";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                dvt.Show();
            }
        }

        private void btnNhomHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fNhomHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fNhomHang nhomHang = new fNhomHang();
                nhomHang.MdiParent = this;

                Action.Module = "Nhóm Hàng";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                nhomHang.Show();
            }
        }

        private void btnHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fHangHoa));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fHangHoa hangHoa = new fHangHoa();
                hangHoa.MdiParent = this;

                Action.Module = "Hàng Hóa";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                hangHoa.Show();
            }
        }

        private void btnTyGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fTiGia));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fTiGia tiGia = new fTiGia();
                tiGia.MdiParent = this;

                Action.Module = "Tỷ Giá";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                tiGia.Show();
            }
        }

        private void btnBoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fBoPhan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fBoPhan boPhan = new fBoPhan();
                boPhan.MdiParent = this;

                Action.Module = "Bộ Phận";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                boPhan.Show();
            }
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fNhanVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fNhanVien nhanVien = new fNhanVien();
                nhanVien.MdiParent = this;

                Action.Module = "Nhân Viên";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                nhanVien.Show();
            }
        }

        private void btnBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fMainBH),"Bán hàng");
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                fMainBH bh = new fMainBH();

                Action.Module = "Bán Hàng";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                bh.ShowDialog();
            }
        }

        private void btnMuaHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fMainBH), "Mua hàng");
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                
                fMainBH mh = new fMainBH(false);

                Action.Module = "Mua Hàng";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                mh.ShowDialog();
            }
        }

        private void btnTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fTonKho));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {

                fTonKho mh = new fTonKho();
                mh.MdiParent = this;

                Action.Module = "Tồn Kho";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                mh.Show();
            }
        }

        private void btnThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fThongTin tt = new fThongTin();

            Action.Module = "Thông Tin";
            Action.ActionName = "Xem";
            Action.LuuThongTin();

            tt.Show();
        }

        private void btnThuTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fBaseThuTien_TraTien thutien = new fBaseThuTien_TraTien();

            Action.Module = "Thu Tiền";
            Action.ActionName = "Xem";
            Action.LuuThongTin();

            thutien.ShowDialog();
        }

        private void btnTraTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fBaseThuTien_TraTien traTien = new fBaseThuTien_TraTien(false);

            Action.Module = "Trả Tiền";
            Action.ActionName = "Xem";
            Action.LuuThongTin();

            traTien.ShowDialog();
        }

        private void btnNhatKyHeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(fNhatKyHeThong));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {

                fNhatKyHeThong nk = new fNhatKyHeThong();
                nk.MdiParent = this;

                Action.Module = "Nhật Ký Hệ Thống";
                Action.ActionName = "Xem";
                Action.LuuThongTin();

                nk.Show();
            }
        }
    }
}
