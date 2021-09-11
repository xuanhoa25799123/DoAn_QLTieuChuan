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
using DevExpress.XtraGrid.Views.Grid;

namespace DoAn
{
    public partial class UCTrangChu : DevExpress.XtraEditors.XtraUserControl
    {
        public UCTrangChu()
        {
            InitializeComponent();
	
			
        }
        private static UCTrangChu _instance;

        public static UCTrangChu Instance
        {
            get {
            if(_instance == null)
            {
                _instance = new UCTrangChu();
            }
            return _instance;
            }

           
        }

		string TinNhanLoi;
		int IDBo;
		DataTable DiemTieuChiTheoNhom;
		QLTCTC db;
		int IsActive;
		List<BoTieuChi_TenNhom> dsNhomBo;
		List<TCBo> list;
		List<TChonBo> listTC;
		int DiemTong;
		List<int> DSMaNhan;
		public List<int> DSMa
		{
			set { DSMaNhan = value; }
		}

		public void LoadDuLieu()
		{
			
			List<int> HocKy = new List<int>();
			for (int i = 1; i <= 3; i++)
				HocKy.Add(i);
			lueHocKy.Properties.DataSource = HocKy;
			lueHocKy.EditValue = 1;
			List<string> NamHoc = new List<string>();
			for (int i = 0; i <= DateTime.Today.Year + 2 - 2018; i++)
			{
				string nh = Convert.ToString(2018 + i) + "-" + Convert.ToString(2018 + i + 1);
				NamHoc.Add(nh);
			}
			lueNamHoc.Properties.DataSource = NamHoc;
			lueNamHoc.EditValue = NamHoc[0];
		}
		public void LoadLenView()
		{
			db = new QLTCTC();
			DiemTieuChiTheoNhom = new DataTable();
			DiemTieuChiTheoNhom.Columns.Add("MaNhom", typeof(Int32));
			DiemTieuChiTheoNhom.Columns.Add("DiemTong", typeof(Int32));
			DiemTong = 0;
			dsNhomBo = new List<BoTieuChi_TenNhom>();
			list = new List<TCBo>();
			listTC = new List<TChonBo>();
			int HocKy = Convert.ToInt32(lueHocKy.Text);
			IDBo = (int)db.BoTieuChis.Where(c=>c.NamHoc == lueNamHoc.Text && c.HocKy == HocKy).Select(c=>c.IDBoTieuChi).FirstOrDefault();
			DSTieuChiBanDau(IDBo);
			DSTuyChonBanDau(IDBo);
			var DanhSachNhom = db.ChiTietBoTieuChis.Where(c => c.BoTieuChi.NamHoc == lueNamHoc.Text && c.BoTieuChi.HocKy == HocKy).Select(c => c.TieuChi.NhomTieuChi).Distinct().ToList();
			foreach(NhomTieuChi nhom in DanhSachNhom)
			{
				int DiemNhom = 0;
				BoTieuChi_TenNhom NhomBo = new BoTieuChi_TenNhom();
				var DSTieuChi = db.TieuChis.Where(c => c.MaNhom == nhom.MaNhom).ToList();
				foreach(TieuChi tc in DSTieuChi)
				{
					var DiemTieuChi = (int)db.ChiTietBoTieuChis.Where(c => c.MaTieuChi == tc.MaTieuChi && c.IDBoTieuChi == IDBo).Select(c => c.DiemTieuChi).FirstOrDefault();
					DiemNhom += DiemTieuChi;
				}
				NhomBo.IDBoTieuChi = IDBo;
				NhomBo.MaNhom = nhom.MaNhom;
				NhomBo.DiemNhom = DiemNhom;
				NhomBo.TenNhom = nhom.TenNhom;
				dsNhomBo.Add(NhomBo);
			}
			grcBoTieuChi.DataSource = dsNhomBo;
			var IDNguoiTao = db.BoTieuChis.Where(c => c.HocKy == HocKy).Where(c => c.NamHoc == lueNamHoc.Text).Select(c => c.IDNguoiTao).FirstOrDefault();
			var TenNguoiTao = db.TaiKhoans.Where(c => c.ID == IDNguoiTao).Select(c => c.TenHienThi).FirstOrDefault();
			txtNguoiTao.Text = TenNguoiTao;
			var NgayTao = db.BoTieuChis.Where(c => c.HocKy == HocKy).Where(c => c.NamHoc == lueNamHoc.Text).Select(c => c.NgayTao).FirstOrDefault();
			if (txtNguoiTao.Text != "")
				txtNgayTao.Text = NgayTao.ToShortDateString();
			else
				txtNgayTao.Text = "";
			IsActive = Convert.ToInt32(db.BoTieuChis.Where(c => c.IDBoTieuChi == IDBo).Select(c => c.isActive).FirstOrDefault());
			if(IsActive == 1)
			{
				lblTrangThai.Text = "Bộ tiêu chí đang được sử dụng, không thể sửa";
				lblTrangThai.ForeColor = Color.Red;
				btnThemNhom.Enabled = false;
				btnLuuBo.Enabled = false;
			}
			else
			{
				lblTrangThai.Text = "Bộ tiêu chí chưa được sử dụng, có thể sửa";
				lblTrangThai.ForeColor = Color.Green;
				btnThemNhom.Enabled = true;
				btnLuuBo.Enabled = true;
			}
		}

		private void lueHocKy_EditValueChanged(object sender, EventArgs e)
		{
			LoadLenView();
		}

		private void lueNamHoc_EditValueChanged(object sender, EventArgs e)
		{
			LoadLenView();
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo,MessageBoxIcon.Question) !=
				  DialogResult.Yes)
				return;
			if (IsActive == 1)
			{
				MessageBox.Show("Bộ tiêu chí đang được sử dụng. Không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				int rowHandle = gvNhomTieuChi.FocusedRowHandle;
				int MaNhom = Convert.ToInt32(gvNhomTieuChi.GetRowCellValue( rowHandle, "MaNhom"));
				BoTieuChi_TenNhom NhomBo = dsNhomBo.Where(c => c.MaNhom == MaNhom).FirstOrDefault();
				dsNhomBo.Remove(NhomBo);
				var dsTieuChi = db.TieuChis.Where(c => c.MaNhom == MaNhom).ToList();
				foreach(TieuChi tc in dsTieuChi)
				{
					var ChiTietXoa = db.ChiTietBoTieuChis.Where(c => c.MaTieuChi == tc.MaTieuChi && c.IDBoTieuChi == IDBo).FirstOrDefault();
					if(ChiTietXoa != null)
						db.ChiTietBoTieuChis.Remove(ChiTietXoa);
				}
				grcBoTieuChi.DataSource = dsNhomBo;
				grcBoTieuChi.RefreshDataSource();
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			GridRow row = gvNhomTieuChi.GetRow(gvNhomTieuChi.FocusedRowHandle) as GridRow;
	
		}

		private void grcBoTieuChi_Click(object sender, EventArgs e)
		{

		}

		private void DSTieuChiBanDau(int IDBoTieuChi)
		{
			var ChiTiet = db.ChiTietBoTieuChis.Where(c => c.IDBoTieuChi == IDBoTieuChi).ToList();
			foreach(ChiTietBoTieuChi ct in ChiTiet)
			{
				TCBo TC = new TCBo();
				TC.MaTieuChi = (int)ct.MaTieuChi;
				TC.MaNhom = ct.TieuChi.MaNhom;
				TC.NoiDung = ct.TieuChi.NoiDung;
				TC.MoTaTieuChi = ct.TieuChi.MoTaTieuChi;
				TC.Diem = ct.DiemTieuChi;
				TC.IDChiTietBo = ct.IDChiTietBo;
				list.Add(TC);
			}
		}

		public void ThemDSTieuChi(int MaTieuChi)
		{
			var TChi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChi).FirstOrDefault();
			TCBo TC = new TCBo();
			TC.MaTieuChi = (int)TChi.MaTieuChi;
			TC.MaNhom = TChi.MaNhom;
			TC.NoiDung = TChi.NoiDung;
			TC.MoTaTieuChi = TChi.MoTaTieuChi;
			if (TC != null && !list.Any(c => c.MaTieuChi == MaTieuChi))
				list.Add(TC);
		}

		private void DSTuyChonBanDau(int IDBoTieuChi)
		{
			var TuyChonBo = db.DiemTuyChons.Where(c => c.ChiTietBoTieuChi.IDBoTieuChi == IDBoTieuChi).ToList();
			foreach (DiemTuyChon dtc in TuyChonBo)
			{
				TChonBo tcb = new TChonBo();
				tcb.MaTieuChi = dtc.ChiTietBoTieuChi.MaTieuChi;
				tcb.MaTuyChon = (int)dtc.MaTuyChon;
				tcb.NoiDungTuyChon = dtc.TuyChonTieuChi.NoiDungTuyChon;
				tcb.Diem = dtc.DiemTuyChon1;
				tcb.IDTuyChon = dtc.IDTuyChon;
				listTC.Add(tcb);
			}
		}

		public void ThemDSTuyChon(int MaTuyChon)
		{
			var TChon = db.TuyChonTieuChis.Where(c => c.MaTuyChon == MaTuyChon).FirstOrDefault();
			TChonBo TC = new TChonBo();
			TC.MaTieuChi = (int)TChon.MaTieuChi;
			TC.MaTuyChon = TChon.MaTuyChon;
			TC.NoiDungTuyChon = TChon.NoiDungTuyChon;
			if (TC != null && !listTC.Any(c => c.MaTuyChon == MaTuyChon))
				listTC.Add(TC);
		}
		
		public void ThemDSNhom(int MaNhom)
		{
			var NhomTC = db.NhomTieuChis.Where(c => c.MaNhom == MaNhom).FirstOrDefault();
			BoTieuChi_TenNhom Nhom = new BoTieuChi_TenNhom();
			Nhom.IDBoTieuChi = IDBo;
			Nhom.MaNhom = NhomTC.MaNhom;
			Nhom.TenNhom = NhomTC.TenNhom;
			if (Nhom != null && !dsNhomBo.Any(c => c.MaNhom == MaNhom))
				dsNhomBo.Add(Nhom);
		}

		private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
		{
			GridView view = sender as GridView;
			var MaNhom = (int)view.GetRowCellValue(e.RowHandle, "MaNhom");
			e.ChildList = list.Where(c=>c.MaNhom == MaNhom).ToList();
		}

		private void gridView1_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
		{
			e.RelationCount = 1;
		}

		private void gridView1_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
		{
			e.RelationName = "Level1";
		}

		private void gridView1_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
		{

			GridView view = sender as GridView;
			//var MaNhom = (int)view.GetRowCellValue(e.RowHandle, "MaNhom");
			//e.IsEmpty = !list.Any(c => c.MaNhom == MaNhom);

		}


		private void gvChiTiet_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
		{
			GridView view = sender as GridView;
			var MaTieuChi = (int)view.GetRowCellValue(e.RowHandle, "MaTieuChi");
			e.ChildList = listTC.Where(c => c.MaTieuChi == MaTieuChi).ToList();
		}

		private void gvChiTiet_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
		{
			e.RelationCount = 1;
		}

		private void gvChiTiet_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
		{
			e.RelationName = "Level2";
		}

		private void gvChiTiet_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
		{
			GridView view = sender as GridView;
			var MaTieuChi = (int)view.GetRowCellValue(e.RowHandle, "MaTieuChi");
			e.IsEmpty = !listTC.Any(c => c.MaTieuChi == MaTieuChi);
		}

		private void UCTrangChu_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
			LoadLenView();
			btnXoa.Click += btnXoa_Click;
			btnXoaTieuChi.Click += btnXoaTieuChi_Click;
			btnXoaTuyChon.Click += btnXoaTuyChon_Click;
			btnThemTieuChi.Click +=btnThemTieuChi_Click;
			btnThemTuyChon.Click += btnThemTuyChon_Click;
		}

		private void gvNhomTieuChi_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			
			if (view.FocusedColumn.FieldName == "")
				e.Cancel = false;
		}

		private void gvChiTiet_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "" || (view.FocusedColumn.FieldName == "Diem" && IsActive == 0))
				e.Cancel = false;
		}

		private void gvTuyChon_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "" || (view.FocusedColumn.FieldName == "Diem" && IsActive == 0))
				e.Cancel = false;
		}

		private int FindRowHandleByRowObject(DevExpress.XtraGrid.Views.Grid.GridView view, int MaNhom, string col)
		{
			for (int i = 0; i < view.DataRowCount; i++)
				if (MaNhom.Equals(view.GetRowCellValue(i, view.Columns[col])))
					return i;
			return DevExpress.XtraGrid.GridControl.InvalidRowHandle;
		}



		private void KiemTraNhom(int MaNhom)
		{
			foreach (DataRow row in DiemTieuChiTheoNhom.Rows)
			{
				if ((int)row["MaNhom"] == MaNhom)
					return;
			}
			DiemTieuChiTheoNhom.Rows.Add(MaNhom, 0);
		}

		private void CapNhatDiemTieuChi(int MaNhom, int rowHandle)
		{
			KiemTraNhom(MaNhom);
			int Diem = 0;
			GridView TieuChi = gvNhomTieuChi.GetDetailView(rowHandle, gvNhomTieuChi.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
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
			gvNhomTieuChi.SetRowCellValue(rowHandle, "DiemNhom", dr["DiemTong"]);
		}

		private void CapNhatDiem()
		{
			DiemTong = 0;
			for (int i = 0; i < gvNhomTieuChi.DataRowCount; i++)
			{
				object diem = gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.GetRowHandle(i), "DiemNhom");
				if (diem.GetType() != typeof(DBNull))
				{
					DiemTong += Convert.ToInt32(diem);
				}
				else
					DiemTong += 0;
			}
		}

		private void btnXoaTuyChon_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
				return;
			if (IsActive == 1)
			{
				MessageBox.Show("Bộ tiêu chí đang được sử dụng. Không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				int MaNhom = Convert.ToInt32(gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.FocusedRowHandle, gvNhomTieuChi.Columns["MaNhom"]));
				int rowHandle = FindRowHandleByRowObject(gvNhomTieuChi, MaNhom, "MaNhom");
				GridView gvTieuChi = gvNhomTieuChi.GetDetailView(rowHandle, gvNhomTieuChi.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
				int MaTieuChi = Convert.ToInt32(gvTieuChi.GetRowCellValue(gvTieuChi.FocusedRowHandle, gvTieuChi.Columns["MaTieuChi"]));
				int rowHandleTieuChi = FindRowHandleByRowObject(gvTieuChi, MaTieuChi, "MaTieuChi");
				GridView gvTuyChon = gvTieuChi.GetDetailView(rowHandleTieuChi, gvTieuChi.GetVisibleDetailRelationIndex(rowHandleTieuChi)) as GridView;
				int MaTuyChon = Convert.ToInt32(gvTuyChon.GetRowCellValue(gvTuyChon.FocusedRowHandle, "MaTuyChon"));
				int IDTuyChon = Convert.ToInt32(gvTuyChon.GetRowCellValue(gvTuyChon.FocusedRowHandle, "IDTuyChon"));
				TChonBo TChon = listTC.Where(c => c.MaTuyChon == MaTuyChon).FirstOrDefault();
				listTC.Remove(TChon);
				var tcBo = db.DiemTuyChons.Where(c => c.IDTuyChon == IDTuyChon).FirstOrDefault();
				db.DiemTuyChons.Remove(tcBo);
				gvTuyChon.DeleteRow(gvTuyChon.FocusedRowHandle);
			}
		}

		private void btnXoaTieuChi_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
				return;
			if (IsActive == 1)
			{
				MessageBox.Show("Bộ tiêu chí đang được sử dụng. Không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				int MaNhom = Convert.ToInt32(gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.FocusedRowHandle, gvNhomTieuChi.Columns["MaNhom"]));
				int rowHandle = FindRowHandleByRowObject(gvNhomTieuChi, MaNhom, "MaNhom");
				GridView gvTieuChi = gvNhomTieuChi.GetDetailView(rowHandle, gvNhomTieuChi.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
				int MaTieuChi = Convert.ToInt32(gvTieuChi.GetRowCellValue(gvTieuChi.FocusedRowHandle, gvTieuChi.Columns["MaTieuChi"]));
				int Diem = Convert.ToInt32(gvTieuChi.GetRowCellValue(gvTieuChi.FocusedRowHandle, gvTieuChi.Columns["Diem"]));
				gvTieuChi.DeleteRow(gvTieuChi.FocusedRowHandle);
				TieuChi TieuChi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChi).FirstOrDefault();
				TCBo TC = list.Where(c => c.MaTieuChi == MaTieuChi).FirstOrDefault();
				list.Remove(TC);
				var ctBo = db.ChiTietBoTieuChis.Where(c => c.IDBoTieuChi == IDBo && c.MaTieuChi == MaTieuChi).FirstOrDefault();
				db.ChiTietBoTieuChis.Remove(ctBo);
				CapNhatDiemTieuChi(MaNhom, rowHandle);
				CapNhatDiem();
			}
		}

		private void gvChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView view = sender as GridView;
			int MaNhom = (int)view.GetRowCellValue(e.RowHandle, "MaNhom");
			CapNhatDiemTieuChi(MaNhom, view.SourceRowHandle);
			CapNhatDiem();
		}

		private void btnThemTuyChon_Click(object sender, EventArgs e)
		{
			int MaNhom = Convert.ToInt32(gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.FocusedRowHandle, gvNhomTieuChi.Columns["MaNhom"]));
			int rowHandle = FindRowHandleByRowObject(gvNhomTieuChi, MaNhom, "MaNhom");
			GridView TieuChi = gvNhomTieuChi.GetDetailView(rowHandle, gvNhomTieuChi.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
			int MaTieuChi = Convert.ToInt32(TieuChi.GetRowCellValue(TieuChi.FocusedRowHandle, TieuChi.Columns["MaTieuChi"]));
			int rowHandleTC = FindRowHandleByRowObject(TieuChi, MaTieuChi, "MaTieuChi");
			int KieuHienThi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChi).Select(c => c.KieuHienThiTuyChon).FirstOrDefault();
			if (KieuHienThi != 2)
			{
				FrmTuyChon frm = new FrmTuyChon() { UCTrangChu = this, CNang = 1, rowHandleTC = rowHandleTC};
				frm.MaTieuChi = MaTieuChi;
				frm.Show();
			}
			else
				MessageBox.Show("Tiêu chí không có tùy chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnThemTieuChi_Click(object sender, EventArgs e)
		{
			int MaNhom = Convert.ToInt32(gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.FocusedRowHandle, gvNhomTieuChi.Columns["MaNhom"]));
			int rowHandle = FindRowHandleByRowObject(gvNhomTieuChi, MaNhom, "MaNhom");
			FrmThemTieuChi_TuyChon frm = new FrmThemTieuChi_TuyChon() { UCTrangChu = this, rowHandle = rowHandle };
			frm.MaNhom = MaNhom;
			frm.Show();
		}

		public void LoadGridView()
		{
			grcBoTieuChi.DataSource = dsNhomBo;
			grcBoTieuChi.RefreshDataSource();
		}

		private void btnThemNhom_Click(object sender, EventArgs e)
		{
			FrmChonNhom frm = new FrmChonNhom() { UCTrangChu = this };
			frm.Show();
		}

		private void btnLuuBo_Click(object sender, EventArgs e)
		{
			bool Loi = KiemTraDiemTatCa();
			int IDChiTietBo = -1;
			try
			{
				//Nếu có lỗi xuất thông báo
				if (IDBo == 0)
				{
					int HocKy = Convert.ToInt32(lueHocKy.Text);
					BoTieuChi bo = new BoTieuChi();
					bo.NamHoc = lueNamHoc.Text;
					bo.HocKy = HocKy;
					bo.NgayTao = DateTime.Now;
					bo.IDNguoiTao = MainForm.tk.ID;
					bo.isActive = 0;
					db.BoTieuChis.Add(bo);
					db.SaveChanges();
					IDBo = (int)db.BoTieuChis.Where(c => c.NamHoc == lueNamHoc.Text && c.HocKy == HocKy).Select(c => c.IDBoTieuChi).FirstOrDefault();
				}
				if (Loi)
				{
					MessageBox.Show("Không thể lưu bộ tiêu chí:\n" + TinNhanLoi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					TinNhanLoi = null;
				}
				else
				{
					//Duyệt từng nhóm tiêu chí
					for (int i = 0; i < gvNhomTieuChi.RowCount; i++)
					{
						gvNhomTieuChi.ExpandMasterRow(i);
						//Lấy gridview chứa tiêu chí thuộc nhóm tieu chí
						GridView TieuChi = gvNhomTieuChi.GetDetailView(i, gvNhomTieuChi.GetVisibleDetailRelationIndex(i)) as GridView;
						if (TieuChi != null)
						{
							for (int j = 0; j < TieuChi.RowCount; j++)
							{
								TieuChi.ExpandMasterRow(j);
								//Lưu chi tiết bộ tiêu chí
								IDChiTietBo = (int)TieuChi.GetRowCellValue(TieuChi.GetRowHandle(j), "IDChiTietBo");
								int MaTieuChi = (int)TieuChi.GetRowCellValue(TieuChi.GetRowHandle(j), "MaTieuChi");
								var DiemTieuChi = (int)TieuChi.GetRowCellValue(TieuChi.GetRowHandle(j), "Diem");
								int KieuHienThi = db.TieuChis.Where(c => c.MaTieuChi == MaTieuChi).Select(c => c.KieuHienThiTuyChon).FirstOrDefault();
								if (IDChiTietBo == 0)
								{
									ChiTietBoTieuChi ChiTietBo = new ChiTietBoTieuChi();
									ChiTietBo.IDBoTieuChi = IDBo;
									ChiTietBo.MaTieuChi = MaTieuChi;
									ChiTietBo.DiemTieuChi = DiemTieuChi;
									db.ChiTietBoTieuChis.Add(ChiTietBo);
								}
								else
								{
									var ChiTietBoTC = db.ChiTietBoTieuChis.Where(c => c.MaTieuChi == MaTieuChi && c.IDBoTieuChi == IDBo).FirstOrDefault();
									ChiTietBoTC.DiemTieuChi = DiemTieuChi;
								}
								db.SaveChanges();
								IDChiTietBo = Convert.ToInt32(db.ChiTietBoTieuChis.Where(c => c.IDBoTieuChi == IDBo)
									.Where(c => c.MaTieuChi == MaTieuChi).Select(c => c.IDChiTietBo).FirstOrDefault());
								//Lấy gridview chứa tùy chọn thuộc tiêu chí
								GridView TuyChonTC = TieuChi.GetDetailView(j, TieuChi.GetVisibleDetailRelationIndex(j)) as GridView;
								if (TuyChonTC != null)
								{
									//Duyệt từng tùy chọn
									for (int k = 0; k < TuyChonTC.RowCount; k++)
									{
										//Lưu điểm tùy chọn
										int IDTuyChon = (int)TuyChonTC.GetRowCellValue(TuyChonTC.GetRowHandle(k), "IDTuyChon");
										int MaTuyChon = (int)TuyChonTC.GetRowCellValue(TuyChonTC.GetRowHandle(k), "MaTuyChon");
										var DiemTuyChon = (int)TuyChonTC.GetRowCellValue(TuyChonTC.GetRowHandle(k), "Diem");
										if (IDTuyChon == 0)
										{
											DiemTuyChon TuyChon = new DiemTuyChon();
											TuyChon.IDChiTietBo = IDChiTietBo;
											TuyChon.MaTuyChon = MaTuyChon;
											TuyChon.DiemTuyChon1 = DiemTuyChon;
											db.DiemTuyChons.Add(TuyChon);
										}
										else
										{
											var TuyChonBo = db.DiemTuyChons.Where(c => c.IDTuyChon == IDTuyChon).FirstOrDefault();
											TuyChonBo.DiemTuyChon1 = DiemTuyChon;
										}
										db.SaveChanges();
									}
								}
							}
						}
					}
					MessageBox.Show("Sửa bộ tiêu chí thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadLenView();
				}
			}
			catch { MessageBox.Show("Sửa bộ tiêu chí không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); TinNhanLoi = null; }

		}

		public void Collapse_ExpandTieuChi(int rowHandle)
		{
			gvNhomTieuChi.CollapseMasterRow(rowHandle);
			gvNhomTieuChi.ExpandMasterRow(rowHandle);
		}

		public void Collapse_ExpandTuyChon(int rowHandleTC)
		{
			int MaNhom = Convert.ToInt32(gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.FocusedRowHandle, gvNhomTieuChi.Columns["MaNhom"]));
			int rowHandle = FindRowHandleByRowObject(gvNhomTieuChi, MaNhom, "MaNhom");
			GridView TieuChi = gvNhomTieuChi.GetDetailView(rowHandle, gvNhomTieuChi.GetVisibleDetailRelationIndex(rowHandle)) as GridView;
			TieuChi.CollapseMasterRow(rowHandleTC);
			TieuChi.ExpandMasterRow(rowHandleTC);
		}

		private bool KiemTraDiemTatCa()
		{
			bool Loi = false;
			bool LoiTuyChon = false;
			//Nếu chưa thêm nhóm tiêu chí, báo lỗi
			if (gvNhomTieuChi.RowCount == 0)
			{
				Loi = true;
				TinNhanLoi = "Chưa có nhóm tiêu chí nào trong bộ";
			}
			else
			{
				//Duyệt từng nhóm tiêu chí cần thêm vào bộ
				for (int i = 0; i < gvNhomTieuChi.RowCount; i++)
				{
					//Lấy gridview chứa các tiêu chí thuộc nhóm 
					GridView TieuChi = gvNhomTieuChi.GetDetailView(i, gvNhomTieuChi.GetVisibleDetailRelationIndex(i)) as GridView;
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
    }
}
