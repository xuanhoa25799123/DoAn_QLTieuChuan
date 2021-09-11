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
using System.Data.Entity.Validation;

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

		DataTable DiemTieuChiTheoNhom;
		QLTCTC db = new QLTCTC();
		private void UCTaoBoTieuChi_Load(object sender, EventArgs e)
		{
			btnThemTieuChi.Click += btnThemTieuChi_Click;
			btnThemTuyChon.Click += btnThemTuyChon_Click;
			btnXoaTieuChi.Click +=btnXoaTieuChi_Click;
			btnXoaTuyChon.Click +=btnXoaTuyChon_Click;
			List<int> HocKy = new List<int>();
			for (int i = 1; i <= 3; i++)
				HocKy.Add(i);
			lueHocKy.Properties.DataSource = HocKy;
			lueHocKy.EditValue = 1;
			List<string> NamHoc = new List<string>();
			for(int i=0;i<=2;i++)
			{
				string nh = Convert.ToString(DateTime.Today.Year + i) + "-" + Convert.ToString(DateTime.Today.Year + i + 1);
				NamHoc.Add(nh);
			}
			lueNamHoc.Properties.DataSource = NamHoc;
			lueNamHoc.EditValue = NamHoc[0];
			LoadDuLieu();
		}

		private void KiemTraBoTieuChi()
		{
			int HocKy = Convert.ToInt32(lueHocKy.Text);
			var isUsed = db.BoTieuChis.Where(c => c.NamHoc == lueNamHoc.Text && c.HocKy == HocKy).FirstOrDefault();
			if(isUsed != null)
			{
				lblCanhBao.Text = "Đã có bộ tiêu chí \ntrong học kỳ của năm học";
				lblCanhBao.ForeColor = Color.Red;
			}
			else
			{
				lblCanhBao.Text = "";
			}
		}

		public void LoadDuLieu()
		{
			int HocKy = Convert.ToInt32(lueHocKy.Text);
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
			DiemTieuChiTheoNhom = new DataTable();
			DiemTieuChiTheoNhom.Columns.Add("MaNhom", typeof(Int32));
			DiemTieuChiTheoNhom.Columns.Add("DiemTong", typeof(Int32));
			KiemTraBoTieuChi();
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
		List<TCBo> list = new List<TCBo>();

		private void gvNhomTieuChiBo_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
		{
			GridView view = sender as GridView;
			
			int MaNhom = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, view.Columns["MaNhom"]));
			e.ChildList = list.Where(c=> c.MaNhom == MaNhom).ToList();
		}

		public void ThemDSTieuChi()
		{
			TieuChi TieuChi;
			if (DSMaNhan != null)
			{
				for (int i = 0; i < DSMaNhan.Count; i++)
				{
					TCBo TC = new TCBo();
					int MaTieuChi = DSMaNhan[i];
					TieuChi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChi).FirstOrDefault();
					TC.MaNhom = TieuChi.MaNhom;
					TC.MaTieuChi = TieuChi.MaTieuChi;
					TC.NoiDung = TieuChi.NoiDung;
					TC.MoTaTieuChi = TieuChi.MoTaTieuChi;
					if (TC != null && !list.Contains(TC))
						list.Add(TC);
				}
			}
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

		private void btnXoaTuyChon_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
				return;
			int MaNhom = Convert.ToInt32(gvNhomTieuChiBo.GetRowCellValue(gvNhomTieuChiBo.FocusedRowHandle, gvNhomTieuChiBo.Columns["MaNhom"]));
			int rowHandle = FindRowHandleByRowObject(gvNhomTieuChiBo, MaNhom, "MaNhom");
			GridView gvTieuChi = gvNhomTieuChiBo.GetDetailView(rowHandle, gvNhomTieuChiBo.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
			int MaTieuChi = Convert.ToInt32(gvTieuChi.GetRowCellValue(gvTieuChi.FocusedRowHandle, gvTieuChi.Columns["MaTieuChi"]));
			int rowHandleTieuChi = FindRowHandleByRowObject(gvTieuChi, MaTieuChi, "MaTieuChi");
			GridView gvTuyChon = gvTieuChi.GetDetailView(rowHandleTieuChi, gvTieuChi.GetVisibleDetailRelationIndex(rowHandleTieuChi)) as GridView;
			int MaTuyChon = Convert.ToInt32(gvTuyChon.GetRowCellValue(gvTuyChon.FocusedRowHandle, "MaTuyChon"));
			TChonBo TChon = listTC.Where(c => c.MaTuyChon == MaTuyChon).FirstOrDefault();
			listTC.Remove(TChon);
			gvTuyChon.DeleteRow(gvTuyChon.FocusedRowHandle);
		}

		private void btnXoaTieuChi_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
				return;
			int MaNhom = Convert.ToInt32(gvNhomTieuChiBo.GetRowCellValue(gvNhomTieuChiBo.FocusedRowHandle, gvNhomTieuChiBo.Columns["MaNhom"]));
			int rowHandle = FindRowHandleByRowObject(gvNhomTieuChiBo, MaNhom, "MaNhom");
			GridView gvTieuChi = gvNhomTieuChiBo.GetDetailView(rowHandle, gvNhomTieuChiBo.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
			int MaTieuChi = Convert.ToInt32(gvTieuChi.GetRowCellValue(gvTieuChi.FocusedRowHandle, gvTieuChi.Columns["MaTieuChi"]));
			int Diem = Convert.ToInt32(gvTieuChi.GetRowCellValue(gvTieuChi.FocusedRowHandle, gvTieuChi.Columns["Diem"]));
			gvTieuChi.DeleteRow(gvTieuChi.FocusedRowHandle);
			TieuChi TieuChi = db.TieuChis.Where(c=>c.MaTieuChi == MaTieuChi).FirstOrDefault();
			TCBo TC = list.Where(c => c.MaTieuChi == MaTieuChi).FirstOrDefault();
			list.Remove(TC);
			CapNhatDiemTieuChi(MaNhom, rowHandle);
			CapNhatDiem();
			KiemTraDiem();
		}

		private void btnThemTieuChi_Click(object sender, EventArgs e)
		{
			int MaNhom = Convert.ToInt32(gvNhomTieuChiBo.GetRowCellValue(gvNhomTieuChiBo.FocusedRowHandle, gvNhomTieuChiBo.Columns["MaNhom"]));
			int rowHandle = FindRowHandleByRowObject(gvNhomTieuChiBo, MaNhom, "MaNhom");
			FrmThemTieuChi_TuyChon frm = new FrmThemTieuChi_TuyChon() { UCTaoBoTieuChi = this, rowHandle= rowHandle };
			frm.MaNhom = MaNhom;
			frm.Show();
		}

		private void btnThemTuyChon_Click(object sender, EventArgs e)
		{
			int MaNhom = Convert.ToInt32(gvNhomTieuChiBo.GetRowCellValue(gvNhomTieuChiBo.FocusedRowHandle, gvNhomTieuChiBo.Columns["MaNhom"]));
			int rowHandle = FindRowHandleByRowObject(gvNhomTieuChiBo,MaNhom,"MaNhom");
			GridView TieuChi = gvNhomTieuChiBo.GetDetailView(rowHandle, gvNhomTieuChiBo.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
			int MaTieuChi = Convert.ToInt32(TieuChi.GetRowCellValue(TieuChi.FocusedRowHandle, TieuChi.Columns["MaTieuChi"]));
			int KieuHienThi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChi).Select(c => c.KieuHienThiTuyChon).FirstOrDefault();
			if (KieuHienThi != 2)
			{
				FrmTuyChon frm = new FrmTuyChon();
				frm.MaTieuChi = MaTieuChi;
				frm.Show();
			}
			else
				MessageBox.Show("Tiêu chí không có tùy chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private int FindRowHandleByRowObject(DevExpress.XtraGrid.Views.Grid.GridView view, int MaNhom, string col)
		{
			for (int i = 0; i < view.DataRowCount; i++)
				if (MaNhom.Equals(view.GetRowCellValue(i,view.Columns[col])))
					return i;
			return DevExpress.XtraGrid.GridControl.InvalidRowHandle;
		} 

		List<int> DSMaNhan;
		public List<int> DSMa
		{
			set { DSMaNhan = value; }
		}

		private void gvTieuChiBo_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
		{
			GridView view = sender as GridView;
			var x = view.GetRowCellValue(e.RowHandle, "MaTieuChi");
			int y = Convert.ToInt32(x);
			e.IsEmpty = !db.TuyChonTieuChis.Any(c => c.MaTieuChi == y);
		}

		List<TChonBo> listTC = new List<TChonBo>();

		public void ThemDSTuyChon(int MaTieuChi)
		{
			var DSTuyChon = db.TuyChonTieuChis.Where(c => c.MaTieuChi == MaTieuChi).ToList();
			foreach (TuyChonTieuChi tc in DSTuyChon)
			{
				TChonBo tcb = new TChonBo();
				tcb.MaTieuChi = tc.MaTieuChi;
				tcb.MaTuyChon = tc.MaTuyChon;
				tcb.NoiDungTuyChon = tc.NoiDungTuyChon;
				listTC.Add(tcb);
			}
		}

		private void gvTieuChiBo_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
		{
			GridView view = sender as GridView;
			var x = (int)view.GetRowCellValue(e.RowHandle, "MaTieuChi");
			
			e.ChildList = listTC.Where(c => c.MaTieuChi == x).ToList(); ;
		}

		private void gvTieuChiBo_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
		{
			e.RelationCount = 1;
		}

		private void gvTieuChiBo_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
		{
			e.RelationName = "Level2";
		}

		string TinNhanLoi;

		//Kiểm tra điểm nếu có lỗi trả về true
		private bool KiemTraDiemTatCa()
		{
			bool Loi = false;
			bool LoiTuyChon = false;
			//Nếu chưa thêm nhóm tiêu chí, báo lỗi
			if (gvNhomTieuChiBo.RowCount == 0)
			{
				Loi = true;
				TinNhanLoi = "Chưa có nhóm tiêu chí nào trong bộ";
			}
			else
			{
				//Duyệt từng nhóm tiêu chí cần thêm vào bộ
				for (int i = 0; i < gvNhomTieuChiBo.RowCount; i++)
				{
					//Lấy gridview chứa các tiêu chí thuộc nhóm 
					GridView TieuChi = gvNhomTieuChiBo.GetDetailView(i, gvNhomTieuChiBo.GetVisibleDetailRelationIndex(i)) as GridView;
					if (TieuChi != null)
					{
						//Duyệt từng tiêu chí
						for (int j = 0; j < TieuChi.RowCount; j++)
						{
							//Lấy điểm tiêu chí
							int DiemTieuChi = (int)TieuChi.GetRowCellValue(TieuChi.GetRowHandle(j), "Diem");
							//Lấy gridview chứa các tùy chọn thuộc tiêu chí	
							GridView TuyChonTC = TieuChi.GetDetailView(j, TieuChi.GetVisibleDetailRelationIndex(j)) as GridView;
							if (TuyChonTC != null)
							{
								//Duyệt từng tùy chọn
								for (int k = 0; k < TuyChonTC.RowCount; k++)
								{
									int DiemTuyChon = (int)TuyChonTC.GetRowCellValue(TuyChonTC.GetRowHandle(k), "Diem");
									//Nếu điểm tùy chọn lớn hơn điểm tiêu chí, thông báo lỗi
									if (DiemTuyChon > DiemTieuChi)
									{
										Loi = true;
										LoiTuyChon = true;
										TinNhanLoi = "- Điểm tùy chọn phải nhỏ hơn điểm tiêu chí!";
										break;
									}
									if (LoiTuyChon == true)
										break;
								}
							}
						}
					}
					//Kiểm tra điểm tổng có bằng 100 không, nếu khác thông báo lỗi
					if (DiemTong != 100)
					{
						Loi = true;
						if (TinNhanLoi == null)
						{
							TinNhanLoi = "- Tổng điểm các nhóm tiêu chí không bằng 100!";
						}
						else
							TinNhanLoi += "\n -Tổng điểm các nhóm tiêu chí không bằng 100!";
						break;
					}
				}
			}
			return Loi;
		}


		private void btnLuu_Click(object sender, EventArgs e)
		{
			bool Loi = KiemTraDiemTatCa();
			int IDBoTieuChi = -1;
			int IDChiTietBo = -1;
			try
			{
				//Nếu có lỗi xuất thông báo
				if (Loi)
				{
					MessageBox.Show(TinNhanLoi,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
					TinNhanLoi = null;
				}
				else
				{
					//Lưu bộ tiêu chí
					BoTieuChi bo = new BoTieuChi();
					bo.NamHoc = lueNamHoc.Text;
					bo.HocKy = Convert.ToInt32(lueHocKy.Text);
					bo.NgayTao = DateTime.Now;
					bo.IDNguoiTao = MainForm.tk.ID;
					bo.isActive = 0;
					db.BoTieuChis.Add(bo);
					db.SaveChanges();
					//Duyệt từng nhóm tiêu chí
					for (int i = 0; i < gvNhomTieuChiBo.RowCount; i++)
					{
						gvNhomTieuChiBo.ExpandMasterRow(i);
						IDBoTieuChi = Convert.ToInt32(db.BoTieuChis.Where(c => c.NamHoc == bo.NamHoc)
							.Where(c => c.HocKy == bo.HocKy).Select(c => c.IDBoTieuChi).FirstOrDefault());
						//Lấy gridview chứa tiêu chí thuộc nhóm tieu chí
						GridView TieuChi = gvNhomTieuChiBo.GetDetailView(i, gvNhomTieuChiBo.GetVisibleDetailRelationIndex(i)) as GridView;
						if(TieuChi !=null)
						{
							for (int j = 0; j < TieuChi.RowCount; j++)
							{
								TieuChi.ExpandMasterRow(j);
								//Lưu chi tiết bộ tiêu chí
								int MaTieuChi = (int)TieuChi.GetRowCellValue(TieuChi.GetRowHandle(j), "MaTieuChi");
								var DiemTieuChi = (int)TieuChi.GetRowCellValue(TieuChi.GetRowHandle(j), "Diem");
								int KieuHienThi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChi).Select(c => c.KieuHienThiTuyChon).FirstOrDefault();
								ChiTietBoTieuChi ChiTietBo = new ChiTietBoTieuChi();
								if (KieuHienThi == 2)
									ChiTietBo.DiemMin = 0;
								ChiTietBo.IDBoTieuChi = IDBoTieuChi;
								ChiTietBo.MaTieuChi = MaTieuChi;
								ChiTietBo.DiemTieuChi = DiemTieuChi;
								db.ChiTietBoTieuChis.Add(ChiTietBo);
								db.SaveChanges();
								IDChiTietBo = Convert.ToInt32(db.ChiTietBoTieuChis.Where(c => c.IDBoTieuChi == IDBoTieuChi)
									.Where(c => c.MaTieuChi == MaTieuChi).Select(c => c.IDChiTietBo).FirstOrDefault());
								//Lấy gridview chứa tùy chọn thuộc tiêu chí
								GridView TuyChonTC = TieuChi.GetDetailView(j, TieuChi.GetVisibleDetailRelationIndex(j)) as GridView;
								if (TuyChonTC != null)
								{
									//Duyệt từng tùy chọn
									for (int k = 0; k < TuyChonTC.RowCount; k++)
									{
										//Lưu điểm tùy chọn
										int MaTuyChon = (int)TuyChonTC.GetRowCellValue(TuyChonTC.GetRowHandle(k), "MaTuyChon");
										var DiemTuyChon = (int)TuyChonTC.GetRowCellValue(TuyChonTC.GetRowHandle(k), "Diem");
										DiemTuyChon TuyChon = new DiemTuyChon();
										TuyChon.IDChiTietBo = IDChiTietBo;
										TuyChon.MaTuyChon = MaTuyChon;
										TuyChon.DiemTuyChon1 = DiemTuyChon;
										db.DiemTuyChons.Add(TuyChon);
										db.SaveChanges();
									}
								}
							}
						}
					}
					MessageBox.Show("Thêm thành công","Thành công",MessageBoxButtons.OK,MessageBoxIcon.Information);
					LoadDuLieu();
				}
			}
			catch { MessageBox.Show("Thêm không thành công","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error); TinNhanLoi = null; }

		}

		private void KiemTraNhom(int MaNhom)
		{
			foreach (DataRow row in DiemTieuChiTheoNhom.Rows)
			{
				if ((int)row["MaNhom"] == MaNhom)
					return;
			}
			DiemTieuChiTheoNhom.Rows.Add(MaNhom,0);
		}

		private void CapNhatDiemTieuChi(int MaNhom, int rowHandle)
		{
			KiemTraNhom(MaNhom);
			int Diem = 0;
			GridView TieuChi = gvNhomTieuChiBo.GetDetailView(rowHandle, gvNhomTieuChiBo.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
			for (int i = 0; i < TieuChi.RowCount; i++)
			{
				object diem = TieuChi.GetRowCellValue(TieuChi.GetRowHandle(i), "Diem");
				if (diem.GetType() != typeof(DBNull))
				{
					Diem += Convert.ToInt32(diem);
				}
				else
					Diem += 0;
			}
			DataRow dr = DiemTieuChiTheoNhom.Select("MaNhom=" + MaNhom).FirstOrDefault();
			dr["DiemTong"] = Diem;
			gvNhomTieuChiBo.SetRowCellValue(rowHandle, "DiemNhom", dr["DiemTong"]);
		}
		private void gvTuyChonBo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{

		}

		//Mỗi lần nhập điểm cập nhật vào DataTable
		private void gvTieuChiBo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView view = sender as GridView;
			int MaNhom = (int)view.GetRowCellValue(e.RowHandle, "MaNhom");
			CapNhatDiemTieuChi(MaNhom, view.SourceRowHandle);
			CapNhatDiem();
			KiemTraDiem();
		}

		private void gvNhomTieuChiBo_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "")
				e.Cancel = false;
		}

		private void gvTieuChiBo_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "" || view.FocusedColumn.FieldName == "Diem")
				e.Cancel = false;
		}

		private void gvTuyChonBo_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "" || view.FocusedColumn.FieldName == "Diem")
				e.Cancel = false;
		}

		public void Collapse_Expand(int rowHandle)
		{
			gvNhomTieuChiBo.CollapseMasterRow(rowHandle);
			gvNhomTieuChiBo.ExpandMasterRow(rowHandle);
		}

		private void lueHocKy_EditValueChanged(object sender, EventArgs e)
		{
			KiemTraBoTieuChi();
		}

		private void lueNamHoc_EditValueChanged(object sender, EventArgs e)
		{
			KiemTraBoTieuChi();
		}
	}

}

