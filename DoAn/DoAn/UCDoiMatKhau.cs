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

namespace DoAn
{
    public partial class UCDoiMatKhau : DevExpress.XtraEditors.XtraUserControl
    {
        private static UCDoiMatKhau _instance;

        public static UCDoiMatKhau Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UCDoiMatKhau();
                }
                return _instance;
            }

        }
        public UCDoiMatKhau()
        {
            InitializeComponent();
			UCDoiMatKhauLoad();
        }

		public void UCDoiMatKhauLoad()
		{
			txtTenDangNhap.Text = MainForm.tk.TenTaiKhoan;
			txtTenHienThi.Text = MainForm.tk.TenHienThi;
			if (MainForm.tk.LoaiTK == 0)
			{
				txtLoaiTaiKhoan.Text = "Admin";
			}
			else
			{
				txtLoaiTaiKhoan.Text = "Nhân viên";
			}

		}

		private void btnCapNhatThongTin_Click(object sender, EventArgs e)
		{
			if (txtCurrentPass.Text == "")
			{
				if (MessageBox.Show("Nhập mật khẩu để thay đổi thông tin tài khoản", "Nhập mật khẩu", MessageBoxButtons.OK) == DialogResult.OK)
				{
					txtCurrentPass.Focus();
					return;
				}

			}
			else
			{
				using (QLTCTC db = new QLTCTC())
				{
					var result = db.TaiKhoans.FirstOrDefault(c => c.ID == MainForm.tk.ID && c.MatKhau == txtCurrentPass.Text);
					if (result != null)
					{
						result.TenHienThi = txtTenHienThi.Text;
						db.SaveChanges();
						MainForm.tk.TenHienThi = txtTenHienThi.Text;
						MessageBox.Show("Sửa thông tin thành công");

					}
					else
					{
						MessageBox.Show("Nhập sai mật khẩu");
					}
				}
			}
		
		}

		private void btnCapNhatMK_Click(object sender, EventArgs e)
		{
			if (txtCurrentPass.Text == "")
			{
				if (MessageBox.Show("Nhập mật khẩu để thay đổi mật khẩu", "Nhập mật khẩu", MessageBoxButtons.OK) == DialogResult.OK)
				{
					txtCurrentPass.Focus();
					return;
				}

			}
			else if (txtNewPass.Text != txtReEnter.Text)
			{
				MessageBox.Show("2 mật khẩu không trùng khớp");
				txtNewPass.Text = "";
				txtReEnter.Text = "";
				txtNewPass.Focus();
			}
			else
			{
				using (QLTCTC db = new QLTCTC())
				{
					var result = db.TaiKhoans.FirstOrDefault(c => c.ID == MainForm.tk.ID && c.MatKhau == txtCurrentPass.Text);
					if (result != null)
					{
						result.MatKhau = txtNewPass.Text;
						db.SaveChanges();
						MainForm.tk.MatKhau = txtNewPass.Text;
						MessageBox.Show("Đổi mật khẩu thành công");
						txtCurrentPass.Text = "";
						txtNewPass.Text = "";
						txtReEnter.Text = "";
					}
					else
					{
						MessageBox.Show("Nhập sai mật khẩu");
					}
				}
			}
		}
    }
}
