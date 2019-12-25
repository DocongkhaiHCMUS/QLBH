﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBH_BUS;
using DevExpress.XtraGrid.Views.Grid;

namespace DAQLBH_Devexpress.ChucNang
{
    public partial class fPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        bool PThu; 
        public fPhieuThu(bool thu = true)
        {
            InitializeComponent();
            PThu = thu;
            Init();
        }

        private void Init()
        {
            if (PThu == true)
            {
                gcMain.DataSource = BUS_CongNo.LoadPhieuThu();

                gvMain.Columns[0].FieldName = "MaPT";
                gvMain.Columns[1].FieldName = "MaBH";
                gvMain.Columns[2].FieldName = "NgayLap";
                gvMain.Columns[3].FieldName = "MaKH";
                gvMain.Columns[4].FieldName = "TenKH";
                gvMain.Columns[5].FieldName = "SoTienTra";
                gvMain.Columns[6].FieldName = "GhiChu";
            }
            else
            {
                gcMain.DataSource = BUS_CongNo.LoadPhieuChi();

                gvMain.Columns[0].FieldName = "MaPC";
                gvMain.Columns[1].FieldName = "MaBH";
                gvMain.Columns[2].FieldName = "NgayLap";
                gvMain.Columns[3].FieldName = "MaNCC";
                gvMain.Columns[4].FieldName = "TenNCC";
                gvMain.Columns[5].FieldName = "SoTienTra";
                gvMain.Columns[6].FieldName = "GhiChu";

                gvMain.Columns[2].Caption = "Mã NCC";
                gvMain.Columns[3].Caption = "Nhà Cung Cấp";
            }

            gvMain.IndicatorWidth = 50;
            gvMain.CustomDrawRowIndicator += gvMain_CustomDrawRowIndicator;

            gcMain.UseEmbeddedNavigator = true;
            gcMain.EmbeddedNavigator.Buttons.Append.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gcMain.EmbeddedNavigator.Buttons.Remove.Visible = false;
        }

        private void gvMain_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}