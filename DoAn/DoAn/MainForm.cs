using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace DoAn
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
		private void ResetContainer()
		{
			container.Controls.Remove(UCDoiMatKhau.Instance);
			container.Controls.Remove(UCTieuChi.Instance);
			container.Controls.Remove(UCNhomTieuChi.Instance);
			container.Controls.Remove(UCThongTinTK.Instance);
		}
        private void btnXem_ItemClick(object sender, ItemClickEventArgs e)
        {
			if (!container.Controls.Contains(UCTrangChu.Instance))
			{
				container.Controls.Add(UCTrangChu.Instance);
				UCTrangChu.Instance.Dock = DockStyle.Fill;
				UCTrangChu.Instance.BringToFront();
			}
			UCTrangChu.Instance.BringToFront();
			//ResetContainer();
        }

        private void btnXemTK_ItemClick(object sender, ItemClickEventArgs e)
        {
			UCDoiMatKhau uc = new UCDoiMatKhau();

			if (!container.Controls.Contains(UCDoiMatKhau.Instance))
            {
				container.Controls.Add(UCDoiMatKhau.Instance);
				UCDoiMatKhau.Instance.Dock = DockStyle.Fill;
				UCDoiMatKhau.Instance.BringToFront();
            }
			UCDoiMatKhau.Instance.BringToFront();
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
			this.Hide();
            FormDangNhap f = new FormDangNhap();
            f.Show();
        }

      

        private void btnNhomTieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!container.Controls.Contains(UCNhomTieuChi.Instance))
            {
                container.Controls.Add(UCNhomTieuChi.Instance);
                UCNhomTieuChi.Instance.Dock = DockStyle.Fill;
                UCNhomTieuChi.Instance.BringToFront();
            }
            UCNhomTieuChi.Instance.BringToFront();
        }

        private void btnTieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
			if (!container.Controls.Contains(XtraUserControl1.Instance))
			{
				container.Controls.Add(XtraUserControl1.Instance);
				XtraUserControl1.Instance.Dock = DockStyle.Fill;
				XtraUserControl1.Instance.BringToFront();
			}
			XtraUserControl1.Instance.BringToFront();
			//if (!container.Controls.Contains(UCTieuChi.Instance))
			//{
			//	container.Controls.Add(UCTieuChi.Instance);
			//	UCTieuChi.Instance.Dock = DockStyle.Fill;
			//	UCTieuChi.Instance.BringToFront();
			//}
			//UCTieuChi.Instance.BringToFront();
        }

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (!container.Controls.Contains(UCTrangChu.Instance))
			{
				container.Controls.Add(UCTrangChu.Instance);
				UCTrangChu.Instance.Dock = DockStyle.Fill;
				UCTrangChu.Instance.BringToFront();
			}
			UCTrangChu.Instance.BringToFront();
		}

		private void btnQLNhom_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!container.Controls.Contains(UCNhomTieuChi.Instance))
            {
                container.Controls.Add(UCNhomTieuChi.Instance);
                UCNhomTieuChi.Instance.Dock = DockStyle.Fill;
                UCNhomTieuChi.Instance.BringToFront();
            }
            UCNhomTieuChi.Instance.BringToFront();
		}

		private void btnQLTieuChi_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!container.Controls.Contains(XtraUserControl1.Instance))
			{
				container.Controls.Add(XtraUserControl1.Instance);
				XtraUserControl1.Instance.Dock = DockStyle.Fill;
				XtraUserControl1.Instance.BringToFront();
			}
			XtraUserControl1.Instance.BringToFront();
		}

		private void btnQLTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!container.Controls.Contains(UCQLTaiKhoan.Instance))
			{
				container.Controls.Add(UCQLTaiKhoan.Instance);
				UCQLTaiKhoan.Instance.Dock = DockStyle.Fill;
				UCQLTaiKhoan.Instance.BringToFront();
			}
			UCQLTaiKhoan.Instance.BringToFront();
		}

		private void btnThemBoTieuChi_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!container.Controls.Contains(UCTaoBoTieuChi.Instance))
			{
				container.Controls.Add(UCTaoBoTieuChi.Instance);
				UCTaoBoTieuChi.Instance.Dock = DockStyle.Fill;
				UCTaoBoTieuChi.Instance.BringToFront();
			}
			UCTaoBoTieuChi.Instance.BringToFront();
		}
    }
}