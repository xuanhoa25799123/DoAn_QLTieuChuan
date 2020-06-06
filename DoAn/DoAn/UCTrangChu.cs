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
			//LoadData();
			
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
		QuanLyTieuChuanTieuChiEntities db = new QuanLyTieuChuanTieuChiEntities();
	   //public void LoadData()
	   // {
	   //	using(QLTCEntities QLTC = new QLTCEntities())
	   //	{
	   //		gcDanhSach.DataSource = QLTC.TieuChuans.ToList();
	   //	}
	   //  }
	   // private void gridControl1_Click(object sender, EventArgs e)
	   // {

	   // }

	   // private void gvNhomTieuChi_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
	   // {
	   //	 using (QLTCEntities QLTC = new QLTCEntities())
	   //	 {
	   //		 GridView view = sender as GridView;
	   //		 TieuChuan tc = view.GetRow(e.RowHandle) as TieuChuan;
	   //		 if (tc != null)
	   //			 e.IsEmpty = !QLTC.TieuChis.Any(x => x.NhomTieuChi == tc.MaTieuChuan);
	   //	 }
	   // }

	   // private void gvNhomTieuChi_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
	   // {
	   //	 using (QLTCEntities QLTC = new QLTCEntities())
	   //	 {
	   //		 GridView view = sender as GridView;
	   //		 TieuChuan tc = view.GetRow(e.RowHandle) as TieuChuan;
	   //		 if (tc != null)
	   //			 e.ChildList = QLTC.TieuChis.Where(x => x.MaTieuChuan == tc.MaTieuChuan).ToList();
	   //	 }
	   // }

	   // private void gvNhomTieuChi_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
	   // {
	   //	 e.RelationCount = 1;
	   // }

	   // private void gvNhomTieuChi_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
	   // {
	   //	 e.RelationName = "TieuChiDetail";
	   // }

		public void LoadDuLieu()
		{
			List<int> HocKy = new List<int>();
			for (int i = 1; i <= 3; i++)
				HocKy.Add(i);
			lueHocKy.Properties.DataSource = HocKy;
			lueHocKy.EditValue = 1;
			var NamHoc = db.BoTieuChis.Where(c => c.MaNhom == 1).Select(c => c.NamHoc);
			lueNamHoc.Properties.DataSource = NamHoc.ToList();
			lueNamHoc.EditValue = NamHoc.First();
		}
		public void LoadLenView()
		{
			int HocKy = Convert.ToInt32(lueHocKy.Text);
			var NhomTieuChi = db.BoTieuChis.Where(c => c.HocKy == HocKy).Where(c => c.NamHoc == lueNamHoc.Text).Select(c => new { c.IDBoTieuChi, c.MaNhom, c.NhomTieuChi.TenNhom, c.DiemNhom });
			var TieuChi = db.ChiTietBoTieuChis.Where(c => c.IDBoTieuChi == c.BoTieuChi.IDBoTieuChi).Select(c => new { c.IDBoTieuChi, c.MaTieuChi, c.TieuChi.NoiDung, c.TieuChi.MoTaTieuChi, c.DiemTieuChi });
			grcBoTieuChi.DataSource = NhomTieuChi.ToList();
			var IDNguoiTao = db.BoTieuChis.Where(c => c.HocKy == HocKy).Where(c => c.NamHoc == lueNamHoc.Text).Select(c => c.IDNguoiTao).FirstOrDefault();
			var TenNguoiTao = db.TaiKhoans.Where(c => c.ID == IDNguoiTao).Select(c => c.TenHienThi).FirstOrDefault();
			txtNguoiTao.Text = TenNguoiTao;
			var NgayTao = db.BoTieuChis.Where(c => c.HocKy == HocKy).Where(c => c.NamHoc == lueNamHoc.Text).Select(c => c.NgayTao).FirstOrDefault();
			if (txtNguoiTao.Text != "")
				txtNgayTao.Text = NgayTao.ToShortDateString();
			else
				txtNgayTao.Text = "";
			

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
			if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo) !=
				  DialogResult.Yes)
				return;
			gvNhomTieuChi.DeleteRow(gvNhomTieuChi.FocusedRowHandle);
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			GridRow row = gvNhomTieuChi.GetRow(gvNhomTieuChi.FocusedRowHandle) as GridRow;
	
		}

		private void grcBoTieuChi_Click(object sender, EventArgs e)
		{

		}

		private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
		{
			GridView view = sender as GridView;
			var x = view.GetRowCellValue(e.RowHandle, "IDBoTieuChi");
			int y = Convert.ToInt32(x);
			e.ChildList = db.ChiTietBoTieuChis.Where(c => c.IDBoTieuChi == y).Select(c => new { c.IDChiTietBo, c.TieuChi.NoiDung, c.TieuChi.MoTaTieuChi, c.DiemTieuChi }).ToList();
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
			var x = view.GetRowCellValue(e.RowHandle, "IDBoTieuChi");
			int y = Convert.ToInt32(x);
			e.IsEmpty = !db.ChiTietBoTieuChis.Any(c => c.IDBoTieuChi == y);

		}
		private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
			{
				if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
				  DialogResult.Yes)
					return;
				GridView view = sender as GridView;
				view.DeleteRow(view.FocusedRowHandle);
			}
		}

		private void gvChiTiet_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
		{
			GridView view = sender as GridView;
			var x = view.GetRowCellValue(e.RowHandle, "IDChiTietBo");
			int y = Convert.ToInt32(x);
			e.ChildList = db.DiemTuyChons.Where(c => c.IDChiTietBo == y).Select(c => new { c.TuyChonTieuChi.NoiDungTuyChon, c.DiemTuyChon1 }).ToList();
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
			var x = view.GetRowCellValue(e.RowHandle, "IDChiTietBo");
			int y = Convert.ToInt32(x);
			e.IsEmpty = !db.DiemTuyChons.Any(c => c.IDChiTietBo == y);
		}

		private void UCTrangChu_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
			LoadLenView();
			btnXoa.Click += btnXoa_Click;
		}

    }
}
