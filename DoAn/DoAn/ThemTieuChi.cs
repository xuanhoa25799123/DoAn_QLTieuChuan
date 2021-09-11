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
using DevExpress.XtraEditors.Controls;

namespace DoAn
{
	public partial class ThemTieuChi : DevExpress.XtraEditors.XtraForm
	{
		public UCQLTieuChi usercontrol;
		public FrmThemTieuChi_TuyChon frm;
		public int MaNhom;
		public int Bo;
		public ThemTieuChi()
		{
			InitializeComponent();
		}
		QLTCTC db = new QLTCTC();

		private static ThemTieuChi _instance;
		public static ThemTieuChi Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ThemTieuChi();
				}
				return _instance;
			}
		}

		private void ThemTieuChi_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		public void LoadData()
		{
			DataTable NhomTieuChi = new DataTable();
			NhomTieuChi.Columns.Add("MaNhom", typeof(int));
			NhomTieuChi.Columns.Add("TenNhom", typeof(string));
			var result = db.NhomTieuChis.ToList();
			foreach (NhomTieuChi tc in result)
			{
				NhomTieuChi.Rows.Add(tc.MaNhom, tc.TenNhom);
			}
			lueNhomTieuChi.Properties.DataSource = NhomTieuChi;
			lueNhomTieuChi.Properties.DisplayMember = "TenNhom";
			lueNhomTieuChi.Properties.ValueMember = "MaNhom";
			lueNhomTieuChi.Properties.Columns.Clear();
			lueNhomTieuChi.Properties.Columns.Add(new LookUpColumnInfo(lueNhomTieuChi.Properties.DisplayMember));
			if(Bo == 1)
			{
				lueNhomTieuChi.EditValue = MaNhom;
				lueNhomTieuChi.ReadOnly = true;
			}
			else
				lueNhomTieuChi.ItemIndex = 0;
		}

		private void btnThemTieuChi_Click(object sender, EventArgs e)
		{
			if (txtNoiDungTieuChi.Text == "")
				MessageBox.Show("Chưa nhập đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
			{
				TieuChi tc = new TieuChi();
				tc.IDNguoiTao = MainForm.tk.ID;
				tc.NgayTao = DateTime.Now;
				tc.KieuHienThiTuyChon = (rbInput.Checked == true) ? 0 : (rbSingleChoice.Checked == true) ? 1 : 2;
				tc.MoTaTieuChi = txtMoTaTieuChi.Text;
				tc.NoiDung = txtNoiDungTieuChi.Text;
				tc.MaNhom = (int)lueNhomTieuChi.EditValue;
				//tc.TaiKhoan = MainForm.tk;
				//NhomTieuChi nTC = db.NhomTieuChis.FirstOrDefault(c => c.MaNhom == (int)lueNhomTieuChi.EditValue);
				//tc.NhomTieuChi = nTC;
				db.TieuChis.Add(tc);
				db.SaveChanges();
				if (Bo != 1)
					usercontrol.LoadDuLieu();
				else
					frm.LoadDuLieu();
				MessageBox.Show("Thêm tiêu chí thành công");
				this.Close();
			}
		}
	}
}