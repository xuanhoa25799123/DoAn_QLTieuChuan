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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace DoAn
{
	public partial class FrmTuyChon : DevExpress.XtraEditors.XtraForm
	{
		public FrmTuyChon()
		{
			InitializeComponent();
		}

		public int rowHandleTC;
		public UCTrangChu UCTrangChu;
		public int CNang; // 1-Sua
		int MaTieuChiNhan;
		QLTCTC db = new QLTCTC();
		public int MaTieuChi
		{
			get { return MaTieuChiNhan; }
			set { MaTieuChiNhan = value; }
		}

		private void FrmTuyChon_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
			txtTieuChi.ReadOnly = true;
			if (CNang != 1)
				btnChon.Enabled= false;
		}

		private void LoadDuLieu()
		{
			var DSTuyChon = db.TuyChonTieuChis.Where(c => c.MaTieuChi == MaTieuChiNhan);
			grcTuyChon.DataSource = DSTuyChon.ToList();
			var TieuChi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChiNhan).Select(c => c.NoiDung).FirstOrDefault();
			txtTieuChi.Text = TieuChi;
		}
		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtTuyChon.Text == "")
					MessageBox.Show("Chưa nhập đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
				{
					TuyChonTieuChi tctc = new TuyChonTieuChi();
					tctc.MaTieuChi = MaTieuChiNhan;
					tctc.NoiDungTuyChon = txtTuyChon.Text;
					db.TuyChonTieuChis.Add(tctc);
					db.SaveChanges();
					MessageBox.Show("Thêm tùy chọn tiêu chí thành công");
					txtTuyChon.Text = "";
					LoadDuLieu();
				}
			}
			catch
			{
				MessageBox.Show("Có lỗi khi thêm tùy chọn tiêu chí");
			}
		}

		private void gvTuyChon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView view = sender as GridView;
			int MaTuyChon = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "MaTuyChon"));
			string NoiDungTuyChon = view.GetRowCellValue(view.FocusedRowHandle, "NoiDungTuyChon").ToString();
			var result = db.TuyChonTieuChis.FirstOrDefault(c => c.MaTuyChon == MaTuyChon);
			result.NoiDungTuyChon = NoiDungTuyChon;
			db.SaveChanges();
		}

		private bool isUsed(GridView view, int row)
		{
			GridColumn col = view.Columns["MaTuyChon"];
			int MaTuyChon = Convert.ToInt32(view.GetRowCellValue(row, col));
			var DiemTuyChon = db.DiemTuyChons.Where(c => c.MaTuyChon == MaTuyChon);
			List<DiemTuyChon> list = DiemTuyChon.ToList();
			return (list.Count != 0);

		}

		private void gvTuyChon_RowCellClick(object sender, RowCellClickEventArgs e)
		{
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "")
			{
				if (isUsed(view, view.FocusedRowHandle))
				{
					MessageBox.Show("Không thể xóa tùy chọn tiêu chí!" + "\nTùy chọn tiêu chí đã được sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
						return;
					int MaTuyChon = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "MaTuyChon"));
					var result = db.TuyChonTieuChis.FirstOrDefault(c => c.MaTuyChon == MaTuyChon);
					db.TuyChonTieuChis.Remove(result);
					db.SaveChanges();
					view.DeleteRow(view.FocusedRowHandle);
					MessageBox.Show("Xóa tùy chọn tiêu chí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void gvTuyChon_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName != "" && !isUsed(view, view.FocusedRowHandle))
				e.Cancel = false;
		}

		private void btnChon_Click(object sender, EventArgs e)
		{
			int MaTuyChon;
			int[] dsTuyChon = gvTuyChon.GetSelectedRows();
			foreach (int TuyChon in dsTuyChon)
			{
				MaTuyChon = Convert.ToInt32(gvTuyChon.GetRowCellValue(TuyChon, gvTuyChon.Columns[0]));
					UCTrangChu.ThemDSTuyChon(MaTuyChon);
			}
			UCTrangChu.Collapse_ExpandTuyChon(rowHandleTC);
			this.Close();
		}
	}
}