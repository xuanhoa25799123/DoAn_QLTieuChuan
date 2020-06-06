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
		public FrmThemTieuChi_TuyChon()
		{
			InitializeComponent();
		}
		int MaNhomNhan;
		QuanLyTieuChuanTieuChiEntities db = new QuanLyTieuChuanTieuChiEntities();
		public int MaNhom
		{
			get { return MaNhomNhan; }
			set { MaNhomNhan = value; }
		}

		private void FrmThemTieuChi_TuyChon_Load(object sender, EventArgs e)
		{
			var DSTieuChi = db.TieuChis.Where(c => c.MaNhom == MaNhomNhan);
			grcTieuChi.DataSource = DSTieuChi.ToList();
			var NhomTieuChi = db.NhomTieuChis.Where(c => c.MaNhom == MaNhomNhan).Select(c=>c.TenNhom).FirstOrDefault();
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


	}
}