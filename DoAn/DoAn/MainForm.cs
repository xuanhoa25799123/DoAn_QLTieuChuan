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

		public static TaiKhoan tk;
		public MainForm(TaiKhoan tk)
		{
			MainForm.tk = tk;
			InitializeComponent();
		}

		public void LoadTatCa()
		{
			UCQLTieuChi.Instance.LoadDuLieu();
			UCNhomTieuChi.Instance.LoadDuLieu();
			UCTrangChu.Instance.LoadDuLieu();
			UCTaoBoTieuChi.Instance.LoadDuLieu();
		}

		public void ThemDS(List<int> DSMa)
		{
			UCTaoBoTieuChi.Instance.DSMa = DSMa;
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
			container.Controls.Clear();
			this.Hide();
			FormDangNhap frm = new FormDangNhap();
			frm.Show();
			LoadTatCa();
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
			if (!container.Controls.Contains(UCQLTieuChi.Instance))
			{
				container.Controls.Add(UCQLTieuChi.Instance);
				UCQLTieuChi.Instance.Dock = DockStyle.Fill;
				UCQLTieuChi.Instance.BringToFront();
			}
			UCQLTieuChi.Instance.BringToFront();
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
			if (tk.LoaiTK != 0)
				btnQLTaiKhoan.Enabled = false;
			else
				btnQLTaiKhoan.Enabled = true;
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
			if (!container.Controls.Contains(UCQLTieuChi.Instance))
			{
				container.Controls.Add(UCQLTieuChi.Instance);
				UCQLTieuChi.Instance.Dock = DockStyle.Fill;
				UCQLTieuChi.Instance.BringToFront();
			}
			UCQLTieuChi.Instance.BringToFront();
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

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
			
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			container.Controls.Clear();
		}
    }
}