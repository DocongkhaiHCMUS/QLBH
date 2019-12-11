namespace DAQLBH_Devexpress
{
    partial class fHangHoa
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
            this.colNhomHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaMua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaSi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaLe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToiThieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinhChat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoMacDinh = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.layoutControl1.Size = new System.Drawing.Size(928, 369);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Size = new System.Drawing.Size(928, 369);
            // 
            // gcMain
            // 
            this.gcMain.Location = new System.Drawing.Point(12, 12);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.MenuManager = this.barManager1;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(904, 345);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMa,
            this.colTen,
            this.colNhomHang,
            this.colDonVi,
            this.colGiaMua,
            this.colGiaSi,
            this.colGiaLe,
            this.colToiThieu,
            this.colTinhChat,
            this.colKhoMacDinh,
            this.colConQL});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.GroupCount = 1;
            this.gvMain.Name = "gvMain";
            this.gvMain.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNhomHang, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMa
            // 
            this.colMa.Caption = "Mã Hàng";
            this.colMa.Name = "colMa";
            this.colMa.Visible = true;
            this.colMa.VisibleIndex = 0;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên Hàng";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 1;
            // 
            // colNhomHang
            // 
            this.colNhomHang.Caption = "Nhóm Hàng";
            this.colNhomHang.Name = "colNhomHang";
            this.colNhomHang.Visible = true;
            this.colNhomHang.VisibleIndex = 10;
            // 
            // colDonVi
            // 
            this.colDonVi.Caption = "Đơn Vị";
            this.colDonVi.Name = "colDonVi";
            this.colDonVi.Visible = true;
            this.colDonVi.VisibleIndex = 2;
            // 
            // colGiaMua
            // 
            this.colGiaMua.Caption = "Giá Mua";
            this.colGiaMua.Name = "colGiaMua";
            this.colGiaMua.Visible = true;
            this.colGiaMua.VisibleIndex = 3;
            // 
            // colGiaSi
            // 
            this.colGiaSi.Caption = "Giá Bán Sỉ";
            this.colGiaSi.Name = "colGiaSi";
            this.colGiaSi.Visible = true;
            this.colGiaSi.VisibleIndex = 4;
            // 
            // colGiaLe
            // 
            this.colGiaLe.Caption = "Giá bán lẻ";
            this.colGiaLe.Name = "colGiaLe";
            this.colGiaLe.Visible = true;
            this.colGiaLe.VisibleIndex = 5;
            // 
            // colToiThieu
            // 
            this.colToiThieu.Caption = "Tối Thiểu";
            this.colToiThieu.Name = "colToiThieu";
            this.colToiThieu.Visible = true;
            this.colToiThieu.VisibleIndex = 6;
            // 
            // colTinhChat
            // 
            this.colTinhChat.Caption = "Tính Chất";
            this.colTinhChat.Name = "colTinhChat";
            this.colTinhChat.Visible = true;
            this.colTinhChat.VisibleIndex = 7;
            // 
            // colKhoMacDinh
            // 
            this.colKhoMacDinh.Caption = "Kho Mặc Định";
            this.colKhoMacDinh.Name = "colKhoMacDinh";
            this.colKhoMacDinh.Visible = true;
            this.colKhoMacDinh.VisibleIndex = 8;
            // 
            // colConQL
            // 
            this.colConQL.Caption = "Còn Quản Lý";
            this.colConQL.Name = "colConQL";
            this.colConQL.Visible = true;
            this.colConQL.VisibleIndex = 9;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcMain;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(908, 349);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // fHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 413);
            this.IconOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.box;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "fHangHoa";
            this.Text = "Hàng Hóa";
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
        private DevExpress.XtraGrid.Columns.GridColumn colNhomHang;
        private DevExpress.XtraGrid.Columns.GridColumn colDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaMua;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaSi;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaLe;
        private DevExpress.XtraGrid.Columns.GridColumn colToiThieu;
        private DevExpress.XtraGrid.Columns.GridColumn colTinhChat;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoMacDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colConQL;
    }
}