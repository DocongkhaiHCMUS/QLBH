namespace DAQLBH_Devexpress.HeThong
{
    partial class fLuaChon
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
            this.btnVaiTro = new DevExpress.XtraEditors.SimpleButton();
            this.btnNguoiDung = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnQuyen = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnVaiTro
            // 
            this.btnVaiTro.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVaiTro.Location = new System.Drawing.Point(57, 95);
            this.btnVaiTro.Name = "btnVaiTro";
            this.btnVaiTro.Size = new System.Drawing.Size(97, 31);
            this.btnVaiTro.TabIndex = 0;
            this.btnVaiTro.Text = "Vai Trò";
            this.btnVaiTro.Click += new System.EventHandler(this.btnVaiTro_Click);
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnNguoiDung.Location = new System.Drawing.Point(194, 95);
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.Size = new System.Drawing.Size(97, 31);
            this.btnNguoiDung.TabIndex = 1;
            this.btnNguoiDung.Text = "Người Dùng";
            this.btnNguoiDung.Click += new System.EventHandler(this.btnQuyenHan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.ImageOptions.Image = global::DAQLBH_Devexpress.Properties.Resources.cancel_32x32;
            this.btnHuy.Location = new System.Drawing.Point(117, 189);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(106, 40);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(57, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(234, 25);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Bạn muốn xóa ?";
            // 
            // btnQuyen
            // 
            this.btnQuyen.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnQuyen.Location = new System.Drawing.Point(126, 143);
            this.btnQuyen.Name = "btnQuyen";
            this.btnQuyen.Size = new System.Drawing.Size(97, 31);
            this.btnQuyen.TabIndex = 4;
            this.btnQuyen.Text = "Quyền Hạn";
            this.btnQuyen.Click += new System.EventHandler(this.btnQuyen_Click);
            // 
            // fLuaChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 241);
            this.Controls.Add(this.btnQuyen);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnNguoiDung);
            this.Controls.Add(this.btnVaiTro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "fLuaChon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lựa Chọn";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVaiTro;
        private DevExpress.XtraEditors.SimpleButton btnNguoiDung;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnQuyen;
    }
}