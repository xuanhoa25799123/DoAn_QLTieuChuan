namespace DoAn
{
	partial class FrmChonNhom
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChonNhom));
			DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
			DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
			DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
			DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
			DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.btnChonNhom = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
			this.btnThemNhom = new DevExpress.XtraEditors.SimpleButton();
			this.txtTenNhom = new DevExpress.XtraEditors.TextEdit();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.grcNhom = new DevExpress.XtraGrid.GridControl();
			this.gvNhom = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
			this.layoutControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtTenNhom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grcNhom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNhom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.btnChonNhom);
			this.layoutControl1.Controls.Add(this.groupControl1);
			this.layoutControl1.Controls.Add(this.grcNhom);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(548, 325);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// btnChonNhom
			// 
			this.btnChonNhom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChonNhom.ImageOptions.Image")));
			this.btnChonNhom.Location = new System.Drawing.Point(434, 286);
			this.btnChonNhom.Name = "btnChonNhom";
			this.btnChonNhom.Size = new System.Drawing.Size(102, 22);
			this.btnChonNhom.StyleController = this.layoutControl1;
			this.btnChonNhom.TabIndex = 6;
			this.btnChonNhom.Text = "Chọn";
			this.btnChonNhom.Click += new System.EventHandler(this.btnChonNhom_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.layoutControl2);
			this.groupControl1.Location = new System.Drawing.Point(12, 195);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(418, 118);
			this.groupControl1.TabIndex = 5;
			this.groupControl1.Text = "Thêm nhóm tiêu chí:";
			// 
			// layoutControl2
			// 
			this.layoutControl2.Controls.Add(this.btnThemNhom);
			this.layoutControl2.Controls.Add(this.txtTenNhom);
			this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl2.Location = new System.Drawing.Point(2, 20);
			this.layoutControl2.Name = "layoutControl2";
			this.layoutControl2.Root = this.layoutControlGroup1;
			this.layoutControl2.Size = new System.Drawing.Size(414, 96);
			this.layoutControl2.TabIndex = 0;
			this.layoutControl2.Text = "layoutControl2";
			// 
			// btnThemNhom
			// 
			this.btnThemNhom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNhom.ImageOptions.Image")));
			this.btnThemNhom.Location = new System.Drawing.Point(327, 50);
			this.btnThemNhom.Name = "btnThemNhom";
			this.btnThemNhom.Size = new System.Drawing.Size(75, 22);
			this.btnThemNhom.StyleController = this.layoutControl2;
			this.btnThemNhom.TabIndex = 5;
			this.btnThemNhom.Text = "Thêm";
			this.btnThemNhom.Click += new System.EventHandler(this.btnThemNhom_Click);
			// 
			// txtTenNhom
			// 
			this.txtTenNhom.Location = new System.Drawing.Point(83, 12);
			this.txtTenNhom.Name = "txtTenNhom";
			this.txtTenNhom.Size = new System.Drawing.Size(319, 20);
			this.txtTenNhom.StyleController = this.layoutControl2;
			this.txtTenNhom.TabIndex = 4;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
			this.layoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
			columnDefinition1.Width = 80D;
			columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
			columnDefinition2.Width = 20D;
			this.layoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
			rowDefinition1.Height = 50D;
			rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
			rowDefinition2.Height = 50D;
			rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
			this.layoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2});
			this.layoutControlGroup1.Size = new System.Drawing.Size(414, 96);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.txtTenNhom;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
			this.layoutControlItem3.Size = new System.Drawing.Size(394, 38);
			this.layoutControlItem3.Text = "Nhóm tiêu chí:";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnThemNhom;
			this.layoutControlItem4.Location = new System.Drawing.Point(315, 38);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1;
			this.layoutControlItem4.OptionsTableLayoutItem.RowIndex = 1;
			this.layoutControlItem4.Size = new System.Drawing.Size(79, 38);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// grcNhom
			// 
			this.grcNhom.Location = new System.Drawing.Point(12, 12);
			this.grcNhom.MainView = this.gvNhom;
			this.grcNhom.Name = "grcNhom";
			this.grcNhom.Size = new System.Drawing.Size(524, 179);
			this.grcNhom.TabIndex = 4;
			this.grcNhom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhom});
			// 
			// gvNhom
			// 
			this.gvNhom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
			this.gvNhom.GridControl = this.grcNhom;
			this.gvNhom.Name = "gvNhom";
			this.gvNhom.OptionsBehavior.ReadOnly = true;
			this.gvNhom.OptionsSelection.MultiSelect = true;
			this.gvNhom.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "gridColumn1";
			this.gridColumn1.FieldName = "MaNhom";
			this.gridColumn1.Name = "gridColumn1";
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Tên nhóm";
			this.gridColumn2.FieldName = "TenNhom";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 0;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5});
			this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
			this.Root.Name = "Root";
			columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
			columnDefinition3.Width = 80D;
			columnDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
			columnDefinition4.Width = 20D;
			this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition3,
            columnDefinition4});
			rowDefinition3.Height = 60D;
			rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
			rowDefinition4.Height = 30D;
			rowDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
			rowDefinition5.Height = 10D;
			rowDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
			this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition3,
            rowDefinition4,
            rowDefinition5});
			this.Root.Size = new System.Drawing.Size(548, 325);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.grcNhom;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 2;
			this.layoutControlItem1.Size = new System.Drawing.Size(528, 183);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.groupControl1;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 183);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
			this.layoutControlItem2.OptionsTableLayoutItem.RowSpan = 2;
			this.layoutControlItem2.Size = new System.Drawing.Size(422, 122);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnChonNhom;
			this.layoutControlItem5.Location = new System.Drawing.Point(422, 274);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 1;
			this.layoutControlItem5.OptionsTableLayoutItem.RowIndex = 2;
			this.layoutControlItem5.Size = new System.Drawing.Size(106, 31);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// FrmChonNhom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(548, 325);
			this.Controls.Add(this.layoutControl1);
			this.Name = "FrmChonNhom";
			this.Text = "Chọn nhóm tiêu chí";
			this.Load += new System.EventHandler(this.FrmChonNhom_Load);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
			this.layoutControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtTenNhom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grcNhom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNhom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraEditors.SimpleButton btnChonNhom;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraLayout.LayoutControl layoutControl2;
		private DevExpress.XtraEditors.SimpleButton btnThemNhom;
		private DevExpress.XtraEditors.TextEdit txtTenNhom;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraGrid.GridControl grcNhom;
		private DevExpress.XtraGrid.Views.Grid.GridView gvNhom;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
	}
}