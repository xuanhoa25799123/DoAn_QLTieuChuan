using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace DoAn
{
	public partial class UCQLTieuChi : DevExpress.XtraEditors.XtraUserControl
	{
		QLTCTC db = new QLTCTC();
		private static UCQLTieuChi _instance;
		public static UCQLTieuChi Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UCQLTieuChi();
				}
				return _instance;
			}

		}
		public UCQLTieuChi()
		{
			InitializeComponent();
		}

		public void LoadDuLieu()
		{
			var TieuChi = db.TieuChis;
			grcTieuChi.DataSource = TieuChi.ToList();
			var TaiKhoan = db.TaiKhoans.Select(c => new { c.ID, c.TenHienThi });
			lueNguoiTao.DataSource = TaiKhoan.ToList();
			lueNguoiTao.DisplayMember = "TenHienThi";
			lueNguoiTao.ValueMember = "ID";
			lueNguoiTao.Columns.Add(new LookUpColumnInfo(lueNguoiTao.DisplayMember));
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
			var NhomTieuChi = db.NhomTieuChis;
				//.Select(c => new { c.MaNhom, c.TenNhom });
			List<NhomTieuChi> list = new List<NhomTieuChi>();
			NhomTieuChi tc = new NhomTieuChi();
			list = NhomTieuChi.ToList();
			tc.MaNhom = 0;
			tc.TenNhom = "Tất cả";
			list.Add(tc);
			lueNhomTieuChi.Properties.DataSource = list;
			lueNhomTieuChi.Properties.DisplayMember = "TenNhom";
			lueNhomTieuChi.Properties.ValueMember = "MaNhom";
			lueNhomTieuChi.EditValue = 0;
			lueNhomTieuChi.Properties.PopulateColumns();
			lueNhomTieuChi.Properties.Columns["MaNhom"].Visible = false;
			lueNhomTieuChi.Properties.Columns["TieuChis"].Visible = false;
		}

		private void btnTuyChon_Click(object sender, EventArgs e)
		{
			int MaTieuChi = Convert.ToInt32(gvTieuChi.GetRowCellValue(gvTieuChi.FocusedRowHandle, gvTieuChi.Columns["MaTieuChi"]));
			FrmTuyChon frm = new FrmTuyChon();
			frm.MaTieuChi = MaTieuChi;
			frm.Show();
		}

		private void btnThemTC_Click(object sender, EventArgs e)
		{
			ThemTieuChi frm = new ThemTieuChi() { usercontrol = this };
			frm.Show();
		}

		private void XtraUserControl1_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
		}

		private void lueNhomTieuChi_EditValueChanged(object sender, EventArgs e)
		{
			int MaNhomTieuChi = Convert.ToInt32(lueNhomTieuChi.Properties.GetKeyValueByDisplayText(lueNhomTieuChi.Text));
			if (MaNhomTieuChi != 0)
			{
				var TieuChiTheoNhom = db.TieuChis.Where(c => c.MaNhom == MaNhomTieuChi);
				grcTieuChi.DataSource = TieuChiTheoNhom.ToList();
			}
			else
			{
				var TieuChi = db.TieuChis;
				grcTieuChi.DataSource = TieuChi.ToList();
			}
		}

		private bool isUsed(GridView view, int row)
		{
			GridColumn col = view.Columns["MaTieuChi"];
			int MaTieuChi = Convert.ToInt32(view.GetRowCellValue(row, col));
			var ChiTietBoTieuChi = db.ChiTietBoTieuChis.Where(c => c.MaTieuChi == MaTieuChi);
			var TuyChon = db.TuyChonTieuChis.Where(c => c.MaTieuChi == MaTieuChi);
			List<ChiTietBoTieuChi> list = ChiTietBoTieuChi.ToList();
			List<TuyChonTieuChi> listTC = TuyChon.ToList();
			return (list.Count != 0 || listTC.Count != 0);

		}

		private void gvTieuChi_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName != "" && view.FocusedColumn.FieldName != "NgayTao" && !isUsed(view, view.FocusedRowHandle))
				e.Cancel = false;
		}

		private void gvTieuChi_RowCellClick(object sender, RowCellClickEventArgs e)
		{
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "")
			{
				if (isUsed(view, view.FocusedRowHandle))
				{
					MessageBox.Show("Không thể xóa tiêu chí" + "\nNhóm tiêu chí đã được sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
						return;
					int MaTieuChi = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "MaTieuChi"));
					var result = db.TieuChis.FirstOrDefault(c => c.MaTieuChi == MaTieuChi);
					db.TieuChis.Remove(result);
					db.SaveChanges();
					view.DeleteRow(view.FocusedRowHandle);
					MessageBox.Show("Xóa tiêu chí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				GridColumn col = view.Columns["KieuHienThiTuyChon"];
				int KieuHT = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, col));
				if (KieuHT == 2)
					btnTuyChon.Enabled = false;
				else
					btnTuyChon.Enabled = true;
			}
		}

		private void gvTieuChi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView view = sender as GridView;
			int MaTieuChi = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "MaTieuChi"));
			var result = db.TieuChis.FirstOrDefault(c => c.MaTieuChi == MaTieuChi);
			int MaNhom = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "MaNhom"));
			string NoiDung = view.GetRowCellValue(view.FocusedRowHandle, "NoiDung").ToString();
			int KieuHienThi = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "KieuHienThiTuyChon"));
			string MoTa = view.GetRowCellValue(view.FocusedRowHandle, "MoTaTieuChi").ToString();
			result.MaNhom = MaNhom;
			result.NoiDung = NoiDung;
			result.KieuHienThiTuyChon = KieuHienThi;
			result.MoTaTieuChi = MoTa;
			db.SaveChanges();
		}
	}
}
