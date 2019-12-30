namespace DAQLBH_Devexpress.HeThong
{
    partial class fVaiTroQuyenHan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVaiTro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcRule = new DevExpress.XtraGrid.GridControl();
            this.gvRule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaVaiTro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChucNang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKichHoat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcPermision = new DevExpress.XtraGrid.GridControl();
            this.gvPermision = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPermision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPermision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcPermision);
            this.layoutControl1.Controls.Add(this.gcRule);
            this.layoutControl1.Controls.Add(this.gcUser);
            this.layoutControl1.Location = new System.Drawing.Point(0, 44);
            this.layoutControl1.Size = new System.Drawing.Size(974, 421);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Size = new System.Drawing.Size(974, 421);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm Người dùng";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.ImageOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.addfile_32x32;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gcUser
            // 
            this.gcUser.Location = new System.Drawing.Point(12, 12);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.MenuManager = this.barManager1;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(950, 109);
            this.gcUser.TabIndex = 0;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMa,
            this.colTen,
            this.colVaiTro,
            this.colDienGiai,
            this.colConQL});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsView.ShowAutoFilterRow = true;
            this.gvUser.OptionsView.ShowGroupPanel = false;
            // 
            // colMa
            // 
            this.colMa.Caption = "Mã Người dùng";
            this.colMa.Name = "colMa";
            this.colMa.Visible = true;
            this.colMa.VisibleIndex = 0;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên đăng nhập";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 1;
            // 
            // colVaiTro
            // 
            this.colVaiTro.Caption = "Vai Trò";
            this.colVaiTro.Name = "colVaiTro";
            this.colVaiTro.Visible = true;
            this.colVaiTro.VisibleIndex = 2;
            // 
            // colDienGiai
            // 
            this.colDienGiai.Caption = "Diễn Gải";
            this.colDienGiai.Name = "colDienGiai";
            this.colDienGiai.Visible = true;
            this.colDienGiai.VisibleIndex = 3;
            // 
            // colConQL
            // 
            this.colConQL.Caption = "Kích Hoạt";
            this.colConQL.Name = "colConQL";
            this.colConQL.Visible = true;
            this.colConQL.VisibleIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcUser;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(954, 113);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gcRule
            // 
            this.gcRule.Location = new System.Drawing.Point(12, 225);
            this.gcRule.MainView = this.gvRule;
            this.gcRule.MenuManager = this.barManager1;
            this.gcRule.Name = "gcRule";
            this.gcRule.Size = new System.Drawing.Size(950, 184);
            this.gcRule.TabIndex = 3;
            this.gcRule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRule});
            // 
            // gvRule
            // 
            this.gvRule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaVaiTro,
            this.colChucNang,
            this.colXem,
            this.colSua,
            this.colThem,
            this.colXoa,
            this.colKichHoat});
            this.gvRule.GridControl = this.gcRule;
            this.gvRule.Name = "gvRule";
            this.gvRule.OptionsView.ShowAutoFilterRow = true;
            this.gvRule.OptionsView.ShowGroupPanel = false;
            // 
            // colMaVaiTro
            // 
            this.colMaVaiTro.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaVaiTro.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaVaiTro.Caption = "Vai Trò";
            this.colMaVaiTro.Name = "colMaVaiTro";
            this.colMaVaiTro.Visible = true;
            this.colMaVaiTro.VisibleIndex = 0;
            // 
            // colChucNang
            // 
            this.colChucNang.AppearanceHeader.Options.UseTextOptions = true;
            this.colChucNang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChucNang.Caption = "Chức năng";
            this.colChucNang.Name = "colChucNang";
            this.colChucNang.Visible = true;
            this.colChucNang.VisibleIndex = 1;
            // 
            // colXem
            // 
            this.colXem.AppearanceHeader.Options.UseTextOptions = true;
            this.colXem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXem.Caption = "Xem";
            this.colXem.Name = "colXem";
            this.colXem.Visible = true;
            this.colXem.VisibleIndex = 2;
            // 
            // colSua
            // 
            this.colSua.AppearanceHeader.Options.UseTextOptions = true;
            this.colSua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSua.Caption = "Sửa";
            this.colSua.Name = "colSua";
            this.colSua.Visible = true;
            this.colSua.VisibleIndex = 3;
            // 
            // colThem
            // 
            this.colThem.AppearanceHeader.Options.UseTextOptions = true;
            this.colThem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThem.Caption = "Thêm";
            this.colThem.Name = "colThem";
            this.colThem.Visible = true;
            this.colThem.VisibleIndex = 4;
            // 
            // colXoa
            // 
            this.colXoa.AppearanceHeader.Options.UseTextOptions = true;
            this.colXoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXoa.Caption = "Xóa";
            this.colXoa.Name = "colXoa";
            this.colXoa.Visible = true;
            this.colXoa.VisibleIndex = 5;
            // 
            // colKichHoat
            // 
            this.colKichHoat.AppearanceHeader.Options.UseTextOptions = true;
            this.colKichHoat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKichHoat.Caption = "Kích Hoạt";
            this.colKichHoat.Name = "colKichHoat";
            this.colKichHoat.Visible = true;
            this.colKichHoat.VisibleIndex = 6;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcRule;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 213);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(954, 188);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // gcPermision
            // 
            this.gcPermision.Location = new System.Drawing.Point(12, 125);
            this.gcPermision.MainView = this.gvPermision;
            this.gcPermision.MenuManager = this.barManager1;
            this.gcPermision.Name = "gcPermision";
            this.gcPermision.Size = new System.Drawing.Size(950, 96);
            this.gcPermision.TabIndex = 2;
            this.gcPermision.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPermision});
            // 
            // gvPermision
            // 
            this.gvPermision.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaVT,
            this.colTenVT,
            this.colGhiChu,
            this.colKH});
            this.gvPermision.GridControl = this.gcPermision;
            this.gvPermision.Name = "gvPermision";
            this.gvPermision.OptionsView.ShowGroupPanel = false;
            // 
            // colMaVT
            // 
            this.colMaVT.Caption = "Mã ";
            this.colMaVT.Name = "colMaVT";
            this.colMaVT.Visible = true;
            this.colMaVT.VisibleIndex = 0;
            // 
            // colTenVT
            // 
            this.colTenVT.Caption = "Tên Vai Trò";
            this.colTenVT.Name = "colTenVT";
            this.colTenVT.Visible = true;
            this.colTenVT.VisibleIndex = 1;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Diễn Giải";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 2;
            // 
            // colKH
            // 
            this.colKH.Caption = "Kích Hoạt";
            this.colKH.Name = "colKH";
            this.colKH.Visible = true;
            this.colKH.VisibleIndex = 3;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcPermision;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 113);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(954, 100);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // fVaiTroQuyenHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 465);
            this.IconOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.editrangepermission_32x32;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "fVaiTroQuyenHan";
            this.Text = "Vai Trò Quyền Hạn";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPermision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPermision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.GridControl gcRule;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRule;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVaiTro;
        private DevExpress.XtraGrid.Columns.GridColumn colChucNang;
        private DevExpress.XtraGrid.Columns.GridColumn colXem;
        private DevExpress.XtraGrid.Columns.GridColumn colSua;
        private DevExpress.XtraGrid.Columns.GridColumn colThem;
        private DevExpress.XtraGrid.Columns.GridColumn colXoa;
        private DevExpress.XtraGrid.Columns.GridColumn colKichHoat;
        private DevExpress.XtraGrid.Columns.GridColumn colMa;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colVaiTro;
        private DevExpress.XtraGrid.Columns.GridColumn colDienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn colConQL;
        private DevExpress.XtraGrid.GridControl gcPermision;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPermision;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVT;
        private DevExpress.XtraGrid.Columns.GridColumn colTenVT;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colKH;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}