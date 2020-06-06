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
	public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
	{
		QuanLyTieuChuanTieuChiEntities db = new QuanLyTieuChuanTieuChiEntities();
		private static XtraUserControl1 _instance;
		public static XtraUserControl1 Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new XtraUserControl1();
				}
				return _instance;
			}

		}
		public XtraUserControl1()
		{
			InitializeComponent();
		}

		private void LoadDuLieu()
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
			var NhomTieuChi = db.NhomTieuChis.Select(c => new { c.MaNhom, c.TenNhom });
			lueNhomTieuChi.Properties.DataSource = NhomTieuChi.ToList();
			lueNhomTieuChi.Properties.DisplayMember = "TenNhom";
			lueNhomTieuChi.Properties.ValueMember = "MaNhom";
			lueNhomTieuChi.Properties.Columns.Add(new LookUpColumnInfo(lueNhomTieuChi.Properties.DisplayMember));
		}

		private void btnTuyChon_Click(object sender, EventArgs e)
		{
			FrmTuyChon frm = new FrmTuyChon();
			frm.Show();
		}

		private void btnThemTC_Click(object sender, EventArgs e)
		{
			ThemTieuChi frm = new ThemTieuChi();
			frm.Show();
		}

		private void XtraUserControl1_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
		}

		private void lueNhomTieuChi_EditValueChanged(object sender, EventArgs e)
		{
			int MaNhomTieuChi = Convert.ToInt32(lueNhomTieuChi.Properties.GetKeyValueByDisplayText(lueNhomTieuChi.Text));
			var TieuChiTheoNhom = db.TieuChis.Where(c => c.MaNhom == MaNhomTieuChi);
			grcTieuChi.DataSource = TieuChiTheoNhom.ToList();
		}

		private bool isUsed(GridView view, int row)
		{
			GridColumn col = view.Columns["MaTieuChi"];
			int MaTieuChi = Convert.ToInt32(view.GetRowCellValue(row, col));
			var ChiTietBoTieuChi = db.ChiTietBoTieuChis.Where(c => c.MaTieuChi == MaTieuChi);
			List<ChiTietBoTieuChi> list = ChiTietBoTieuChi.ToList();
			return list.Count != 0;

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
	}
}
