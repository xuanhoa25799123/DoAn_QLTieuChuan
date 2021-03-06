using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoAn
{
    public partial class FormDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
		QLTCTC db = new QLTCTC();
        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "Tên đăng nhập")
            {
                txtTaiKhoan.Text = null;
                txtTaiKhoan.ForeColor = Color.Black;
            }
            if (txtTaiKhoan.Text == "")
                txtTaiKhoan.ForeColor = Color.Black;

        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                txtTaiKhoan.Text = "Tên đăng nhập";
                txtTaiKhoan.ForeColor = Color.Gray;
            }
          
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.PasswordChar = ' ';
                txtMatKhau.Text = "Mật khẩu";
                txtMatKhau.ForeColor = Color.Gray;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu")
            {
                txtMatKhau.Text = null;
                txtMatKhau.PasswordChar = '*';
                txtMatKhau.ForeColor = Color.Black;
            }

            txtMatKhau.ForeColor = Color.Black;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
			var result = db.TaiKhoans.SingleOrDefault(b => b.TenTaiKhoan == txtTaiKhoan.Text && b.MatKhau == txtMatKhau.Text);
			if (result != null)
			{
				MainForm f = new MainForm(result as TaiKhoan);
				f.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
			}      
        }

		private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}



    }
}
