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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace DoAn
{
	public partial class UCTaoBoTieuChi : DevExpress.XtraEditors.XtraUserControl
	{
		public UCTaoBoTieuChi()
		{
			InitializeComponent();
		}

		private static UCTaoBoTieuChi _instance;

		public static UCTaoBoTieuChi Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UCTaoBoTieuChi();
				}
				return _instance;
			}
		}

		public static DataTable ToDataTable<T>(List<T> items)
		{
			DataTable dataTable = new DataTable(typeof(T).Name);

			//Get all the properties
			PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in Props)
			{
				//Setting column names as Property names
				dataTable.Columns.Add(prop.Name);
			}
			foreach (T item in items)
			{
				var values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					//inserting property values to datatable rows
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}
			//put a breakpoint here and check datatable
			return dataTable;
		}

		QuanLyTieuChuanTieuChiEntities db = new QuanLyTieuChuanTieuChiEntities();

		private void UCTaoBoTieuChi_Load(object sender, EventArgs e)
		{
			btnThemTieuChi.Click += btnThemTieuChi_Click;
			List<int> HocKy = new List<int>();
			for (int i = 1; i <= 3; i++)
				HocKy.Add(i);
			lueHocKy.Properties.DataSource = HocKy;
			lueHocKy.EditValue = 1;
			var NhomTC = db.NhomTieuChis.Select(c => new { c.MaNhom, c.TenNhom });
			var NhomTieuChi = db.NhomTieuChis;
			List<NhomTieuChi> list = NhomTieuChi.ToList();
			DataTable dt = ToDataTable(list);
			grcNhomTieuChi.DataSource = dt;
			lblDiem.Text = "Điểm: 0/100";
			DataTable data = new DataTable();
			data.Columns.Add("MaNhom", typeof(int));
			data.Columns.Add("TenNhom");
			data.Columns.Add("DiemNhom", typeof(int));
			grcBoTieuChi.DataSource = data;
			lblCanhBao.Text = "";
		}

		int DiemTong = 0;
		GridHitInfo downhitInfo = null;

		private void CapNhatDiem()
		{
			DiemTong = 0;
			for (int i = 0; i < gvNhomTieuChiBo.DataRowCount; i++)
			{
				object diem = gvNhomTieuChiBo.GetRowCellValue(gvNhomTieuChiBo.GetRowHandle(i), "DiemNhom");
				if (diem.GetType() != typeof(DBNull))
				{
					DiemTong += Convert.ToInt32(diem);
				}
				else
					DiemTong += 0;
			}
			lblDiem.Text = "Điểm: " + DiemTong.ToString() + "/100";
		}
		private void KiemTraDiem()
		{
			if (DiemTong > 100)
			{
				lblCanhBao.Text = "Điểm quá giới hạn";
				lblCanhBao.ForeColor = Color.Red;
			}
			else
				lblCanhBao.Text = "";
		}

		private void gvNhomTieuChiBo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			CapNhatDiem();
			KiemTraDiem();
		}

		private void grcNhomTieuChi_DragDrop(object sender, DragEventArgs e)
		{
			GridControl grid = sender as GridControl;
			DataTable table = grid.DataSource as DataTable;
			DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
			if (row != null && table != null && row.Table != table)
			{
				table.ImportRow(row);
				row.Delete();
			}
			CapNhatDiem();
		}

		private void grcNhomTieuChi_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(DataRow)))
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void grcBoTieuChi_DragDrop(object sender, DragEventArgs e)
		{
			GridControl grid = sender as GridControl;
			DataTable table = grid.DataSource as DataTable;
			DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
			if (row != null && table != null && row.Table != table)
			{
				table.ImportRow(row);
				row.Delete();
			}
		}

		private void grcBoTieuChi_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(DataRow)))
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void gvNhomTieuChi_MouseDown(object sender, MouseEventArgs e)
		{
			GridView view = sender as GridView;
			downhitInfo = null;
			GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
			if (Control.ModifierKeys != Keys.None) return;
			if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
			{
				downhitInfo = hitInfo;
			}
		}

		private void gvNhomTieuChi_MouseMove(object sender, MouseEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.Button == MouseButtons.Left && downhitInfo != null)
			{
				Size dragSize = SystemInformation.DragSize;
				Rectangle dragRect = new Rectangle(new Point(downhitInfo.HitPoint.X - dragSize.Width / 2, downhitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
				if (!dragRect.Contains(new Point(e.X, e.Y)))
				{
					DataRow row = view.GetDataRow(downhitInfo.RowHandle);
					view.GridControl.DoDragDrop(row, DragDropEffects.Move);
					downhitInfo = null;
					DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
				}
			}
		}

		private void gvNhomTieuChiBo_MouseMove(object sender, MouseEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.Button == MouseButtons.Left && downhitInfo != null)
			{
				Size dragSize = SystemInformation.DragSize;
				Rectangle dragRect = new Rectangle(new Point(downhitInfo.HitPoint.X - dragSize.Width / 2, downhitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
				if (!dragRect.Contains(new Point(e.X, e.Y)))
				{
					DataRow row = view.GetDataRow(downhitInfo.RowHandle);
					view.GridControl.DoDragDrop(row, DragDropEffects.Move);
					downhitInfo = null;
					DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
				}
			}
		}

		private void gvNhomTieuChiBo_MouseDown(object sender, MouseEventArgs e)
		{
			GridView view = sender as GridView;
			downhitInfo = null;
			GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
			if (Control.ModifierKeys != Keys.None) return;
			if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
			{
				downhitInfo = hitInfo;
			}
		}

		private void gvNhomTieuChiBo_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
		{
			GridView view = sender as GridView;
			//TieuChi TieuChi;
			List<TieuChi> list = new List<TieuChi>();
			int MaNhom = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, view.Columns["MaNhom"]));
			var TieuChi = db.TieuChis.Where(c => c.MaNhom == MaNhom);
			//if (DSMaNhan != null)
			//{
			//	for (int i = 0; i < DSMaNhan.Count; i++)
			//	{
			//		int MaTieuChi = DSMaNhan[i];
			//		TieuChi = db.TieuChis.Where(c => c.MaNhom == MaNhom).Where(c => c.MaTieuChi == MaTieuChi).FirstOrDefault();
			//		if (TieuChi != null)
			//			list.Add(TieuChi);
			//	}
			//}
			list = TieuChi.ToList();
			e.ChildList = list;
		}
		private void gvNhomTieuChiBo_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
		{
			e.IsEmpty = false;
		}

		private void gvNhomTieuChiBo_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
		{
			e.RelationCount = 1;
		}

		private void gvNhomTieuChiBo_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
		{
			GridView view = sender as GridView;
			e.RelationName = "Level1";
		}

		private void btnThemTieuChi_Click(object sender, EventArgs e)
		{
			
			int MaNhom = Convert.ToInt32(gvNhomTieuChiBo.GetRowCellValue(gvNhomTieuChiBo.FocusedRowHandle, gvNhomTieuChiBo.Columns["MaNhom"]));
			FrmThemTieuChi_TuyChon frm = new FrmThemTieuChi_TuyChon();
			frm.MaNhom = MaNhom;
			frm.Show();
		}
	}
}
