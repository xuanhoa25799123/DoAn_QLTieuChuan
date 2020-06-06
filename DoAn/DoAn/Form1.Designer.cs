namespace DoAn
{
    partial class FormDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnDangNhap = new DevExpress.XtraEditors.SimpleButton();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.txtTaiKhoan = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.btnDangNhap.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.btnDangNhap.Appearance.Options.UseBackColor = true;
			this.btnDangNhap.Location = new System.Drawing.Point(44, 320);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(190, 23);
			this.btnDangNhap.TabIndex = 22;
			this.btnDangNhap.Text = "Đăng nhập";
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.ForeColor = System.Drawing.SystemColors.GrayText;
			this.txtMatKhau.Location = new System.Drawing.Point(44, 283);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new System.Drawing.Size(190, 21);
			this.txtMatKhau.TabIndex = 21;
			this.txtMatKhau.Text = "Mật khẩu";
			this.txtMatKhau.Enter += new System.EventHandler(this.txtMatKhau_Enter);
			this.txtMatKhau.Leave += new System.EventHandler(this.txtMatKhau_Leave);
			// 
			// txtTaiKhoan
			// 
			this.txtTaiKhoan.ForeColor = System.Drawing.SystemColors.GrayText;
			this.txtTaiKhoan.Location = new System.Drawing.Point(44, 239);
			this.txtTaiKhoan.Multiline = true;
			this.txtTaiKhoan.Name = "txtTaiKhoan";
			this.txtTaiKhoan.Size = new System.Drawing.Size(190, 20);
			this.txtTaiKhoan.TabIndex = 20;
			this.txtTaiKhoan.Text = "Tên đăng nhập";
			this.txtTaiKhoan.Enter += new System.EventHandler(this.txtTaiKhoan_Enter);
			this.txtTaiKhoan.Leave += new System.EventHandler(this.txtTaiKhoan_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(70, 174);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 17);
			this.label2.TabIndex = 19;
			this.label2.Text = "Cổng thông tin sinh viên";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label3.Location = new System.Drawing.Point(79, 138);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 15);
			this.label3.TabIndex = 18;
			this.label3.Text = "DALAT UNIVERSITY";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(40, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(206, 22);
			this.label1.TabIndex = 17;
			this.label1.Text = "Trường Đại Học Đà Lạt";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.BackgroundImage = global::DoAn.Properties.Resources.tải_xuống;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.panel1.Location = new System.Drawing.Point(82, 17);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(125, 69);
			this.panel1.TabIndex = 16;
			// 
			// FormDangNhap
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 361);
			this.Controls.Add(this.btnDangNhap);
			this.Controls.Add(this.txtMatKhau);
			this.Controls.Add(this.txtTaiKhoan);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Name = "FormDangNhap";
			this.Text = "Đăng nhập";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;

    }
}

