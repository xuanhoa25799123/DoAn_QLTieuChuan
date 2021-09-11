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
		QLTCTC db = new QLTCTC();
		List<TaiKhoan> TKValidate = new List<TaiKhoan>();
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
			lueLoaiTaiKhoan.Properties.DataSource = LoaiTK;
			lueLoaiTaiKhoan.Properties.DisplayMember = "TenLoai";
			lueLoaiTaiKhoan.Properties.ValueMember = "MaLoai";
			lueLoaiTaiKhoan.EditValue = 0;
			lueLoaiTaiKhoan.Properties.Columns.Add(new LookUpColumnInfo(lueLoaiTaiKhoan.Properties.DisplayMember));
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
			var TieuChi = db.TieuChis.Where(c => c.IDNguoiTao == ID);
			List<BoTieuChi> list = BoTieuChi.ToList();
			List<TieuChi> listTc = TieuChi.ToList();
			return (list.Count != 0||listTc.Count!=0);

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
					if (MessageBox.Show("Bạn có muốn xóa không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				  DialogResult.Yes)
						return;
					int ID= Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID"));
					var result = db.TaiKhoans.FirstOrDefault(c => c.ID== ID);
					db.TaiKhoans.Remove(result);
					db.SaveChanges();
					view.DeleteRow(view.FocusedRowHandle);
					MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void AddBinding()
		{
			txtTenTaiKhoan.DataBindings.Clear();
			txtTenHienThi.DataBindings.Clear();
			lueLoaiTaiKhoan.DataBindings.Clear();
			txtTenTaiKhoan.DataBindings.Add(new Binding("Text", grcTaiKhoan.DataSource, "TenTaiKhoan", true, DataSourceUpdateMode.Never));
			txtTenHienThi.DataBindings.Add(new Binding("Text", grcTaiKhoan.DataSource, "TenHienThi", true, DataSourceUpdateMode.Never));
			lueLoaiTaiKhoan.DataBindings.Add(new Binding("EditValue", grcTaiKhoan.DataSource, "LoaiTK", true, DataSourceUpdateMode.Never));
		}

		private void btnThemTK_Click(object sender, EventArgs e)
		{
			if (txtTenTaiKhoan.Text == "" || txtTenHienThi.Text == "")
				MessageBox.Show("Chưa nhập đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
			{
				var TK = db.TaiKhoans.Where(c => c.TenTaiKhoan == txtTenTaiKhoan.Text);
				if (TK.ToList().Count != 0)
				{
					MessageBox.Show("Đã có người sử dụng tên tài khoản này");
					return;
				}
				else
				{
					TaiKhoan taikhoan = new TaiKhoan { TenTaiKhoan = txtTenTaiKhoan.Text, TenHienThi = txtTenHienThi.Text, LoaiTK = (int)lueLoaiTaiKhoan.EditValue, MatKhau = "1" };
					db.TaiKhoans.Add(taikhoan);
					db.SaveChanges();
					MessageBox.Show("Thêm tài khoản thành công");
					LoadDuLieu();
					txtTenHienThi.Text = "";
					txtTenTaiKhoan.Text = "";
					lueLoaiTaiKhoan.EditValue = 0;
				}
			}
		}


		private void btnHuy_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Thay đổi sẽ không được lưu", "Huỷ thay đổi", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				TKValidate.Clear();
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			try
			{
				string TenTaiKhoan = gvTaiKhoan.GetRowCellValue(gvTaiKhoan.FocusedRowHandle, "TenTaiKhoan").ToString();
				if (MessageBox.Show("Đặt lại mật khẩu tài khoản " + TenTaiKhoan, "Đặt lại mật khẩu", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					var result = db.TaiKhoans.FirstOrDefault(c => c.TenTaiKhoan == TenTaiKhoan);
					if (result != null)
					{
						result.MatKhau = "1";
						MessageBox.Show("Đặt lại mật khẩu thành công, mật khẩu mặc định là 1");
						db.SaveChanges();
					}
				}
			}
			catch
			{
				MessageBox.Show("Chọn tài khoản để đặt lại mật khẩu");
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			string ten = txtFind.Text;
			var result = db.TaiKhoans.Where(c => c.TenTaiKhoan.ToLower().Contains(ten.ToLower()) || c.TenHienThi.ToLower().Contains(ten.ToLower()));
			grcTaiKhoan.DataSource = null;
			grcTaiKhoan.DataSource = result.ToList();
		}

		private void txtFind_EditValueChanged(object sender, EventArgs e)
		{
			if (txtFind.Text == "")
			{
				LoadDuLieu();
			}
		}

		private void gvTaiKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			int ID = Convert.ToInt32(gvTaiKhoan.GetRowCellValue(gvTaiKhoan.FocusedRowHandle, "ID"));
			var result = db.TaiKhoans.FirstOrDefault(c => c.ID == ID);
			string TenTaiKhoan = gvTaiKhoan.GetRowCellValue(gvTaiKhoan.FocusedRowHandle, "TenTaiKhoan").ToString();
			string TenHienThi = gvTaiKhoan.GetRowCellValue(gvTaiKhoan.FocusedRowHandle, "TenHienThi").ToString();
			int LoaiTK = Convert.ToInt32(gvTaiKhoan.GetRowCellValue(gvTaiKhoan.FocusedRowHandle, "LoaiTK"));
			result.TenTaiKhoan = TenTaiKhoan;
			result.TenHienThi = TenHienThi;
			result.LoaiTK = LoaiTK;
			db.SaveChanges();
		}


	}
}
