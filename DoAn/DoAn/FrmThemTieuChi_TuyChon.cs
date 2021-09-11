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
using DevExpress.XtraEditors.Controls;

namespace DoAn
{
	public partial class FrmThemTieuChi_TuyChon : DevExpress.XtraEditors.XtraForm
	{
		public UCTaoBoTieuChi UCTaoBoTieuChi = null;
		public UCTrangChu UCTrangChu = null;
		public int rowHandle;
		public FrmThemTieuChi_TuyChon()
		{
			InitializeComponent();
		}
		int MaNhomNhan;
		QLTCTC db = new QLTCTC();
		public int MaNhom
		{
			get { return MaNhomNhan; }
			set { MaNhomNhan = value; }
		}

		private void FrmThemTieuChi_TuyChon_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
		}

		public void LoadDuLieu()
		{
			var DSTieuChi = db.TieuChis.Where(c => c.MaNhom == MaNhomNhan);
			grcTieuChi.DataSource = DSTieuChi.ToList();
			var NhomTieuChi = db.NhomTieuChis.Where(c => c.MaNhom == MaNhomNhan).Select(c => c.TenNhom).FirstOrDefault();
			txtNhomTieuChi.Text = NhomTieuChi;
			txtNhomTieuChi.ReadOnly = true;
			DataTable KieuHienThi = new DataTable();
			KieuHienThi.Columns.Add("MaKieu", typeof(int));
			KieuHienThi.Columns.Add("TenKieu", typeof(string));
			KieuHienThi.Rows.Add(0, "Single choice");
			KieuHienThi.Rows.Add(1, "Multiple choice");
			KieuHienThi.Rows.Add(2, "Input");
			lueKieuHienThi.DataSource = KieuHienThi;
			lueKieuHienThi.DisplayMember = "TenKieu";
			lueKieuHienThi.ValueMember = "MaKieu";
			lueKieuHienThi.Columns.Add(new LookUpColumnInfo(lueKieuHienThi.DisplayMember));
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			List<int> dsTC = new List<int>();
			int MaTieuChi;
			int[] dsTieuChi = gvTieuChi.GetSelectedRows();
			foreach (int TieuChi in dsTieuChi)
			{
				MaTieuChi = Convert.ToInt32(gvTieuChi.GetRowCellValue(TieuChi, gvTieuChi.Columns[0]));
				dsTC.Add(MaTieuChi);
				if(UCTaoBoTieuChi != null)
					UCTaoBoTieuChi.ThemDSTuyChon(MaTieuChi);
				if(UCTrangChu != null)
				{
					UCTrangChu.ThemDSTieuChi(MaTieuChi);
				}
			}
			if (UCTaoBoTieuChi != null)
			{
				MainForm Frm = Application.OpenForms[1] as MainForm;
				Frm.ThemDS(dsTC);
				UCTaoBoTieuChi.ThemDSTieuChi();
				UCTaoBoTieuChi.Collapse_Expand(rowHandle);
			}
			if (UCTrangChu != null)
			{
				UCTrangChu.Collapse_ExpandTieuChi(rowHandle);
			}
			this.Close();
		}

		private void btnThemTieuChi_Click(object sender, EventArgs e)
		{
			ThemTieuChi frm = new ThemTieuChi() { frm = this, Bo=1, MaNhom = MaNhomNhan };
			frm.Show();
		}


	}
}