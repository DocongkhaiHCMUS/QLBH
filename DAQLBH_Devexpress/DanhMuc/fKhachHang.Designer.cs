namespace DAQLBH_Devexpress
{
    partial class fKhachHang
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
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhuVuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLienHe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWebsite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSoThue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNganHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcMain);
            this.layoutControl1.Location = new System.Drawing.Point(0, 44);
            this.layoutControl1.Size = new System.Drawing.Size(965, 422);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Size = new System.Drawing.Size(965, 422);
            // 
            // gcMain
            // 
            this.gcMain.Location = new System.Drawing.Point(12, 12);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.MenuManager = this.barManager1;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(941, 398);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMa,
            this.colTen,
            this.colKhuVuc,
            this.colLienHe,
            this.colDiaChi,
            this.colDienThoai,
            this.colDiDong,
            this.colFax,
            this.colEmail,
            this.colWebsite,
            this.colMaSoThue,
            this.colSoTK,
            this.colTenNganHang,
            this.colConQL});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.GroupCount = 1;
            this.gvMain.GroupRowHeight = 20;
            this.gvMain.Name = "gvMain";
            this.gvMain.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKhuVuc, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMa
            // 
            this.colMa.Caption = "Mã KH";
            this.colMa.Name = "colMa";
            this.colMa.Visible = true;
            this.colMa.VisibleIndex = 0;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên KH";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 1;
            // 
            // colKhuVuc
            // 
            this.colKhuVuc.Caption = "Khu Vực";
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colKhuVuc.Visible = true;
            this.colKhuVuc.VisibleIndex = 13;
            // 
            // colLienHe
            // 
            this.colLienHe.Caption = "Người Liên Hệ";
            this.colLienHe.Name = "colLienHe";
            this.colLienHe.Visible = true;
            this.colLienHe.VisibleIndex = 2;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa Chỉ";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 3;
            // 
            // colDienThoai
            // 
            this.colDienThoai.Caption = "Điện Thoại";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 4;
            // 
            // colDiDong
            // 
            this.colDiDong.Caption = "Di Động";
            this.colDiDong.Name = "colDiDong";
            this.colDiDong.Visible = true;
            this.colDiDong.VisibleIndex = 5;
            // 
            // colFax
            // 
            this.colFax.Caption = "FAX";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 6;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 7;
            // 
            // colWebsite
            // 
            this.colWebsite.Caption = "Website";
            this.colWebsite.Name = "colWebsite";
            this.colWebsite.Visible = true;
            this.colWebsite.VisibleIndex = 8;
            // 
            // colMaSoThue
            // 
            this.colMaSoThue.Caption = "Mã Số Thuế";
            this.colMaSoThue.Name = "colMaSoThue";
            this.colMaSoThue.Visible = true;
            this.colMaSoThue.VisibleIndex = 9;
            // 
            // colSoTK
            // 
            this.colSoTK.Caption = "Số Tài Khoản";
            this.colSoTK.Name = "colSoTK";
            this.colSoTK.Visible = true;
            this.colSoTK.VisibleIndex = 10;
            // 
            // colTenNganHang
            // 
            this.colTenNganHang.Caption = "Tên Ngân Hàng";
            this.colTenNganHang.Name = "colTenNganHang";
            this.colTenNganHang.Visible = true;
            this.colTenNganHang.VisibleIndex = 11;
            // 
            // colConQL
            // 
            this.colConQL.Caption = "Còn Quản Lý";
            this.colConQL.Name = "colConQL";
            this.colConQL.Visible = true;
            this.colConQL.VisibleIndex = 12;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcMain;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(945, 402);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // fKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 466);
            this.IconOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.users;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "fKhachHang";
            this.Text = "Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colMa;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colLienHe;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colDiDong;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colWebsite;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSoThue;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTK;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNganHang;
        private DevExpress.XtraGrid.Columns.GridColumn colConQL;
        private DevExpress.XtraGrid.Columns.GridColumn colKhuVuc;
    }
}