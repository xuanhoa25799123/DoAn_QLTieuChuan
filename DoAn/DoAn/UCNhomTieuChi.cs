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
		QuanLyTieuChuanTieuChiEntities db = new QuanLyTieuChuanTieuChiEntities();
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

		
		private void LoadDuLieu()
		{
			var NhomTieuChi = db.NhomTieuChis;
			grcNhomTieuChi.DataSource = NhomTieuChi.ToList();
		}

		private bool isUsed(GridView view, int row)
		{
			GridColumn col = view.Columns["MaNhom"];
			int MaNhom = Convert.ToInt32(view.GetRowCellValue(row, col));
			var BoTieuChi = db.BoTieuChis.Where(c => c.MaNhom == MaNhom);
			List<BoTieuChi> list = BoTieuChi.ToList();
			return list.Count != 0;
			
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
			if (view.FocusedColumn.FieldName != "")
			{
				//string NhomTieuChi = view.GetRowCellValue(view.FocusedRowHandle, "TenNhom").ToString();
				//txtNhomTC.Text = NhomTieuChi;
				//if (!isUsed(view, view.FocusedRowHandle))
				//	btnCapNhat.Enabled = true;
				//else
				//	btnCapNhat.Enabled = false;
			}
			else
			{
				if (isUsed(view, view.FocusedRowHandle))
				{
					MessageBox.Show("Không thể xóa nhóm tiêu chí!" + "\nNhóm tiêu chí đã được sử dụng.", "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
				else
				{
					view.DeleteRow(view.FocusedRowHandle);
					MessageBox.Show("Xóa nhóm tiêu chí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

   
    }
}
