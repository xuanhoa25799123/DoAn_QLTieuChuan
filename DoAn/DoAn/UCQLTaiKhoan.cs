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
	public partial class UCQLTaiKhoan : DevExpress.XtraEditors.XtraUserControl
	{
		private static UCQLTaiKhoan _instance;
		QuanLyTieuChuanTieuChiEntities db = new QuanLyTieuChuanTieuChiEntities();
		public static UCQLTaiKhoan Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UCQLTaiKhoan();
				}
				return _instance;
			}

		}
		public UCQLTaiKhoan()
		{
			InitializeComponent();
		}
		private void LoadDuLieu()
		{
			var TaiKhoan = db.TaiKhoans;
			grcTaiKhoan.DataSource = TaiKhoan.ToList();
			DataTable LoaiTK = new DataTable();
			LoaiTK.Columns.Add("MaLoai", typeof(int));
			LoaiTK.Columns.Add("TenLoai", typeof(string));
			LoaiTK.Rows.Add(0, "Admin");
			LoaiTK.Rows.Add(1, "Nhân viên");
			lueLoaiTK.DataSource = LoaiTK;
			lueLoaiTK.DisplayMember = "TenLoai";
			lueLoaiTK.ValueMember = "MaLoai";
			lueLoaiTK.Columns.Add(new LookUpColumnInfo(lueLoaiTK.DisplayMember));
		}

		private void UCQLTaiKhoan_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
		}

		private bool isUsed(GridView view, int row)
		{
			GridColumn col = view.Columns["ID"];
			int ID = Convert.ToInt32(view.GetRowCellValue(row, col));
			var BoTieuChi = db.BoTieuChis.Where(c => c.IDNguoiTao == ID);
			List<BoTieuChi> list = BoTieuChi.ToList();
			return list.Count != 0;

		}

		private void gvTaiKhoan_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName != "" && !isUsed(view, view.FocusedRowHandle))
				e.Cancel = false;
		}

		private void gvTaiKhoan_RowCellClick(object sender, RowCellClickEventArgs e)
		{
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "")
			{
				if (isUsed(view, view.FocusedRowHandle))
				{
					MessageBox.Show("Không thể xóa tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					view.DeleteRow(view.FocusedRowHandle);
					MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
