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
using DevExpress.XtraGrid.Columns;

namespace DoAn
{
    public partial class UCNhomTieuChi : DevExpress.XtraEditors.XtraUserControl
    {
        private static UCNhomTieuChi _instance;
		QLTCTC db = new QLTCTC();
		List<NhomTieuChi> NTCValidate = new List<NhomTieuChi>();
        public static UCNhomTieuChi Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UCNhomTieuChi();
                }
                return _instance;
            }

        }
        public UCNhomTieuChi()
        {
            InitializeComponent();
        }

		private void UCNhomTieuChi_Load(object sender, EventArgs e)
		{
			LoadDuLieu();
		}

		
		public void LoadDuLieu()
		{
			//Truy vấn tất cả nhóm tiêu chí từ cơ sở dữ liệu
			var NhomTieuChi = db.NhomTieuChis;
			//Đưa vào gridcontrol đề hiển thị
			grcNhomTieuChi.DataSource = NhomTieuChi.ToList();
		}

		private bool isUsed(GridView view, int row)
		{
			GridColumn col = view.Columns["MaNhom"];
			int MaNhom = Convert.ToInt32(view.GetRowCellValue(row, col));
			
			var TieuChi = db.TieuChis.Where(c => c.MaNhom == MaNhom);
			
			List<TieuChi> listTc = TieuChi.ToList();
			return (listTc.Count!=0);
			
		}

		private void gvNhomTieuChi_ShowingEditor(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "TenNhom" && !isUsed(view, view.FocusedRowHandle))
				e.Cancel = false;
		}

		private void gvNhomTieuChi_RowCellClick(object sender, RowCellClickEventArgs e)
		{
			GridView view = sender as GridView;
			if (view.FocusedColumn.FieldName == "")
			{
				if (isUsed(view, view.FocusedRowHandle))
				{
					MessageBox.Show("Không thể xóa nhóm tiêu chí!" + "\nNhóm tiêu chí đã được sử dụng.", "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
				else
				{
					if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
						return;
					int MaNhom = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "MaNhom"));
					var result = db.NhomTieuChis.FirstOrDefault(c => c.MaNhom == MaNhom);
					db.NhomTieuChis.Remove(result);
					db.SaveChanges();
					view.DeleteRow(view.FocusedRowHandle);
					MessageBox.Show("Xóa nhóm tiêu chí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtNhomTC.Text == "")
					MessageBox.Show("Chưa nhập đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
				{
					NhomTieuChi ntc = new NhomTieuChi();
					ntc.TenNhom = txtNhomTC.Text;
					db.NhomTieuChis.Add(ntc);
					db.SaveChanges();
					MessageBox.Show("Thêm nhóm tiêu chí thành công");
					txtNhomTC.Text = "";
					LoadDuLieu();
				}
			}
			catch
			{
				MessageBox.Show("Có lỗi khi thêm nhóm tiêu chí");
			}
		}



		private void gvNhomTieuChi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			int MaNhom = Convert.ToInt32(gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.FocusedRowHandle, "MaNhom"));
			string TenNhom = gvNhomTieuChi.GetRowCellValue(gvNhomTieuChi.FocusedRowHandle, "TenNhom").ToString();
			var result = db.NhomTieuChis.FirstOrDefault(c => c.MaNhom == MaNhom);
			result.TenNhom = TenNhom;
			db.SaveChanges();
		}

   
    }
}
