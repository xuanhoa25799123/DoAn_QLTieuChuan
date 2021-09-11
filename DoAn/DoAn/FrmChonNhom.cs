using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DoAn
{
	public partial class FrmChonNhom : DevExpress.XtraEditors.XtraForm
	{
		public FrmChonNhom()
		{
			InitializeComponent();
		}
		QLTCTC db = new QLTCTC();
		public UCTrangChu UCTrangChu;

		public void LoadDuLieu()
		{
			var NhomTieuChi = db.NhomTieuChis;
			grcNhom.DataSource = NhomTieuChi.ToList();
		}

		private void FrmChonNhom_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
		}

		private void btnThemNhom_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtTenNhom.Text == "")
					MessageBox.Show("Chưa nhập đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
				{
					NhomTieuChi ntc = new NhomTieuChi();
					ntc.TenNhom = txtTenNhom.Text;
					db.NhomTieuChis.Add(ntc);
					db.SaveChanges();
					MessageBox.Show("Thêm nhóm tiêu chí thành công");
					txtTenNhom.Text = "";
					LoadDuLieu();
				}
			}
			catch
			{
				MessageBox.Show("Có lỗi khi thêm nhóm tiêu chí");
			}
		}

		private void btnChonNhom_Click(object sender, EventArgs e)
		{
			int MaNhom;
			int[] dsNhomTC = gvNhom.GetSelectedRows();
			foreach (int NhomTieuChi in dsNhomTC)
			{
				MaNhom = Convert.ToInt32(gvNhom.GetRowCellValue(NhomTieuChi, gvNhom.Columns[0]));
				if (UCTrangChu != null)
				{
					UCTrangChu.ThemDSNhom(MaNhom);
					UCTrangChu.LoadGridView();
				}
			}
			this.Close();
		}
	}
}