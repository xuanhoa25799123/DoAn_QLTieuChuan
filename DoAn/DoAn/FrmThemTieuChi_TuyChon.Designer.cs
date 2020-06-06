namespace DoAn
{
	partial class FrmThemTieuChi_TuyChon
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThemTieuChi_TuyChon));
			DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
			DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.btnOK = new DevExpress.XtraEditors.SimpleButton();
			this.grcTieuChi = new DevExpress.XtraGrid.GridControl();
			this.gvTieuChi = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lueKieuHienThi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.txtNhomTieuChi = new DevExpress.XtraEditors.TextEdit();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grcTieuChi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTieuChi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lueKieuHienThi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNhomTieuChi.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.btnOK);
			this.layoutControl1.Controls.Add(this.grcTieuChi);
			this.layoutControl1.Controls.Add(this.txtNhomTieuChi);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(818, 383);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// btnOK
			// 
			this.btnOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.ImageOptions.Image")));
			this.btnOK.Location = new System.Drawing.Point(650, 338);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(156, 22);
			this.btnOK.StyleController = this.layoutControl1;
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "Chọn";
			// 
			// grcTieuChi
			// 
			this.grcTieuChi.Location = new System.Drawing.Point(12, 48);
			this.grcTieuChi.MainView = this.gvTieuChi;
			this.grcTieuChi.Name = "grcTieuChi";
			this.grcTieuChi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueKieuHienThi});
			this.grcTieuChi.Size = new System.Drawing.Size(794, 286);
			this.grcTieuChi.TabIndex = 5;
			this.grcTieuChi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTieuChi});
			// 
			// gvTieuChi
			// 
			this.gvTieuChi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
			this.gvTieuChi.GridControl = this.grcTieuChi;
			this.gvTieuChi.Name = "gvTieuChi";
			this.gvTieuChi.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "gridColumn1";
			this.gridColumn1.FieldName = "MaTieuChi";
			this.gridColumn1.Name = "gridColumn1";
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Nội dung tiêu chí:";
			this.gridColumn3.FieldName = "NoiDung";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			this.gridColumn3.Width = 350;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Kiểu hiển thị tùy chọn";
			this.gridColumn4.ColumnEdit = this.lueKieuHienThi;
			this.gridColumn4.FieldName = "KieuHienThiTuyChon";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			this.gridColumn4.Width = 98;
			// 
			// lueKieuHienThi
			// 
			this.lueKieuHienThi.AutoHeight = false;
			this.lueKieuHienThi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lueKieuHienThi.Name = "lueKieuHienThi";
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Mô tả tiêu chí";
			this.gridColumn5.FieldName = "MoTaTieuChi";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 2;
			this.gridColumn5.Width = 328;
			// 
			// txtNhomTieuChi
			// 
			this.txtNhomTieuChi.Location = new System.Drawing.Point(83, 12);
			this.txtNhomTieuChi.Name = "txtNhomTieuChi";
			this.txtNhomTieuChi.Size = new System.Drawing.Size(723, 20);
			this.txtNhomTieuChi.StyleController = this.layoutControl1;
			this.txtNhomTieuChi.TabIndex = 4;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
			this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
			this.Root.Name = "Root";
			columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
			columnDefinition1.Width = 80D;
			columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
			columnDefinition2.Width = 20D;
			this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
			rowDefinition1.Height = 10D;
			rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
			rowDefinition2.Height = 80D;
			rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
			rowDefinition3.Height = 10D;
			rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
			this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3});
			this.Root.Size = new System.Drawing.Size(818, 383);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.txtNhomTieuChi;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 2;
			this.layoutControlItem1.Size = new System.Drawing.Size(798, 36);
			this.layoutControlItem1.Text = "Nhóm tiêu chí:";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.grcTieuChi;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 36);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 2;
			this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
			this.layoutControlItem2.Size = new System.Drawing.Size(798, 290);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.btnOK;
			this.layoutControlItem3.Location = new System.Drawing.Point(638, 326);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 1;
			this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
			this.layoutControlItem3.Size = new System.Drawing.Size(160, 37);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// FrmThemTieuChi_TuyChon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 383);
			this.Controls.Add(this.layoutControl1);
			this.Name = "FrmThemTieuChi_TuyChon";
			this.Text = "Thêm tiêu chí";
			this.Load += new System.EventHandler(this.FrmThemTieuChi_TuyChon_Load);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grcTieuChi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTieuChi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lueKieuHienThi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNhomTieuChi.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraEditors.SimpleButton btnOK;
		private DevExpress.XtraGrid.GridControl grcTieuChi;
		private DevExpress.XtraGrid.Views.Grid.GridView gvTieuChi;
		private DevExpress.XtraEditors.TextEdit txtNhomTieuChi;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueKieuHienThi;
	}
}