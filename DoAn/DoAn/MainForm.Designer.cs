namespace DoAn
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.btnXem = new DevExpress.XtraBars.BarButtonItem();
			this.btnXemTK = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
			this.btnNhomTieuChi = new DevExpress.XtraBars.BarButtonItem();
			this.btnTieuChi = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.btnQLNhom = new DevExpress.XtraBars.BarButtonItem();
			this.btnQLTieuChi = new DevExpress.XtraBars.BarButtonItem();
			this.btnThemBoTieuChi = new DevExpress.XtraBars.BarButtonItem();
			this.btnQLTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.container = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ExpandCollapseItem.Id = 0;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnXem,
            this.btnXemTK,
            this.barButtonItem1,
            this.btnDangXuat,
            this.btnNhomTieuChi,
            this.btnTieuChi,
            this.barButtonItem2,
            this.btnQLNhom,
            this.btnQLTieuChi,
            this.btnThemBoTieuChi,
            this.btnQLTaiKhoan});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 13;
			this.ribbon.Name = "ribbon";
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
			this.ribbon.Size = new System.Drawing.Size(963, 143);
			this.ribbon.StatusBar = this.ribbonStatusBar;
			// 
			// btnXem
			// 
			this.btnXem.Caption = "Xem bộ tiêu chí";
			this.btnXem.Id = 1;
			this.btnXem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.ImageOptions.Image")));
			this.btnXem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXem.ImageOptions.LargeImage")));
			this.btnXem.Name = "btnXem";
			this.btnXem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXem_ItemClick);
			// 
			// btnXemTK
			// 
			this.btnXemTK.Caption = "Xem thông tin tài khoản";
			this.btnXemTK.Id = 2;
			this.btnXemTK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemTK.ImageOptions.Image")));
			this.btnXemTK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXemTK.ImageOptions.LargeImage")));
			this.btnXemTK.Name = "btnXemTK";
			this.btnXemTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemTK_ItemClick);
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "barButtonItem1";
			this.barButtonItem1.Id = 4;
			this.barButtonItem1.Name = "barButtonItem1";
			// 
			// btnDangXuat
			// 
			this.btnDangXuat.Caption = "Đăng xuất";
			this.btnDangXuat.Id = 5;
			this.btnDangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.Image")));
			this.btnDangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.LargeImage")));
			this.btnDangXuat.Name = "btnDangXuat";
			this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick);
			// 
			// btnNhomTieuChi
			// 
			this.btnNhomTieuChi.Caption = "Nhóm tiêu chí";
			this.btnNhomTieuChi.Id = 6;
			this.btnNhomTieuChi.Name = "btnNhomTieuChi";
			this.btnNhomTieuChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhomTieuChi_ItemClick);
			// 
			// btnTieuChi
			// 
			this.btnTieuChi.Caption = "Tiêu chí";
			this.btnTieuChi.Id = 7;
			this.btnTieuChi.Name = "btnTieuChi";
			this.btnTieuChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTieuChi_ItemClick);
			// 
			// barButtonItem2
			// 
			this.barButtonItem2.Caption = "barButtonItem2";
			this.barButtonItem2.Id = 8;
			this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
			this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
			this.barButtonItem2.Name = "barButtonItem2";
			// 
			// btnQLNhom
			// 
			this.btnQLNhom.Caption = "Quản lý nhóm tiêu chí";
			this.btnQLNhom.Id = 9;
			this.btnQLNhom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLNhom.ImageOptions.Image")));
			this.btnQLNhom.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLNhom.ImageOptions.LargeImage")));
			this.btnQLNhom.Name = "btnQLNhom";
			this.btnQLNhom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLNhom_ItemClick);
			// 
			// btnQLTieuChi
			// 
			this.btnQLTieuChi.Caption = "Quản lý tiêu chí";
			this.btnQLTieuChi.Id = 10;
			this.btnQLTieuChi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLTieuChi.ImageOptions.Image")));
			this.btnQLTieuChi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLTieuChi.ImageOptions.LargeImage")));
			this.btnQLTieuChi.Name = "btnQLTieuChi";
			this.btnQLTieuChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLTieuChi_ItemClick);
			// 
			// btnThemBoTieuChi
			// 
			this.btnThemBoTieuChi.Caption = "Tạo bộ tiêu chí";
			this.btnThemBoTieuChi.Id = 11;
			this.btnThemBoTieuChi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemBoTieuChi.ImageOptions.Image")));
			this.btnThemBoTieuChi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThemBoTieuChi.ImageOptions.LargeImage")));
			this.btnThemBoTieuChi.Name = "btnThemBoTieuChi";
			this.btnThemBoTieuChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemBoTieuChi_ItemClick);
			// 
			// btnQLTaiKhoan
			// 
			this.btnQLTaiKhoan.Caption = "Quản lý tài khoản";
			this.btnQLTaiKhoan.Id = 12;
			this.btnQLTaiKhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLTaiKhoan.ImageOptions.Image")));
			this.btnQLTaiKhoan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLTaiKhoan.ImageOptions.LargeImage")));
			this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
			this.btnQLTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLTaiKhoan_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Bộ tiêu chí";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.btnXem);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			// 
			// ribbonPageGroup3
			// 
			this.ribbonPageGroup3.ItemLinks.Add(this.btnQLNhom);
			this.ribbonPageGroup3.Name = "ribbonPageGroup3";
			this.ribbonPageGroup3.ShowCaptionButton = false;
			// 
			// ribbonPageGroup6
			// 
			this.ribbonPageGroup6.ItemLinks.Add(this.btnQLTieuChi);
			this.ribbonPageGroup6.Name = "ribbonPageGroup6";
			this.ribbonPageGroup6.ShowCaptionButton = false;
			// 
			// ribbonPageGroup7
			// 
			this.ribbonPageGroup7.ItemLinks.Add(this.btnThemBoTieuChi);
			this.ribbonPageGroup7.Name = "ribbonPageGroup7";
			this.ribbonPageGroup7.ShowCaptionButton = false;
			// 
			// ribbonPage2
			// 
			this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
			this.ribbonPage2.Name = "ribbonPage2";
			this.ribbonPage2.Text = "Tài khoản";
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.ItemLinks.Add(this.btnXemTK);
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.ShowCaptionButton = false;
			// 
			// ribbonPageGroup4
			// 
			this.ribbonPageGroup4.ItemLinks.Add(this.btnQLTaiKhoan);
			this.ribbonPageGroup4.Name = "ribbonPageGroup4";
			this.ribbonPageGroup4.ShowCaptionButton = false;
			// 
			// ribbonPageGroup5
			// 
			this.ribbonPageGroup5.ItemLinks.Add(this.btnDangXuat);
			this.ribbonPageGroup5.Name = "ribbonPageGroup5";
			this.ribbonPageGroup5.ShowCaptionButton = false;
			// 
			// ribbonStatusBar
			// 
			this.ribbonStatusBar.Location = new System.Drawing.Point(0, 539);
			this.ribbonStatusBar.Name = "ribbonStatusBar";
			this.ribbonStatusBar.Ribbon = this.ribbon;
			this.ribbonStatusBar.Size = new System.Drawing.Size(963, 31);
			// 
			// container
			// 
			this.container.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.container.Location = new System.Drawing.Point(0, 143);
			this.container.Name = "container";
			this.container.Size = new System.Drawing.Size(963, 396);
			this.container.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(963, 570);
			this.Controls.Add(this.container);
			this.Controls.Add(this.ribbonStatusBar);
			this.Controls.Add(this.ribbon);
			this.Name = "MainForm";
			this.Ribbon = this.ribbon;
			this.StatusBar = this.ribbonStatusBar;
			this.Text = "Quản lý tiêu chí tiêu chuẩn sinh viên";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnXem;
		private DevExpress.XtraBars.BarButtonItem btnXemTK;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.BarButtonItem btnNhomTieuChi;
        private DevExpress.XtraBars.BarButtonItem btnTieuChi;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private System.Windows.Forms.Panel container;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private DevExpress.XtraBars.BarButtonItem btnQLNhom;
		private DevExpress.XtraBars.BarButtonItem btnQLTieuChi;
		private DevExpress.XtraBars.BarButtonItem btnThemBoTieuChi;
		private DevExpress.XtraBars.BarButtonItem btnQLTaiKhoan;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
    }
}