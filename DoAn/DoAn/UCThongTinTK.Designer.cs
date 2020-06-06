namespace DoAn
{
    partial class UCThongTinTK
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label4 = new System.Windows.Forms.Label();
			this.lbDoiTen = new System.Windows.Forms.Label();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(110, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(245, 29);
			this.label4.TabIndex = 19;
			this.label4.Text = "Thông tin tài khoản";
			// 
			// lbDoiTen
			// 
			this.lbDoiTen.AutoSize = true;
			this.lbDoiTen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbDoiTen.ForeColor = System.Drawing.Color.SlateBlue;
			this.lbDoiTen.Location = new System.Drawing.Point(369, 194);
			this.lbDoiTen.Name = "lbDoiTen";
			this.lbDoiTen.Size = new System.Drawing.Size(94, 13);
			this.lbDoiTen.TabIndex = 18;
			this.lbDoiTen.Text = "Thay đổi thông tin";
			// 
			// textEdit1
			// 
			this.textEdit1.Location = new System.Drawing.Point(139, 190);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.textEdit1.Size = new System.Drawing.Size(200, 22);
			this.textEdit1.TabIndex = 17;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 194);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Tên hiển thị";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 149);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Tên đăng nhập";
			// 
			// txtTenDangNhap
			// 
			this.txtTenDangNhap.Location = new System.Drawing.Point(139, 146);
			this.txtTenDangNhap.Name = "txtTenDangNhap";
			this.txtTenDangNhap.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.txtTenDangNhap.Size = new System.Drawing.Size(200, 22);
			this.txtTenDangNhap.TabIndex = 14;
			// 
			// UCThongTinTK
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lbDoiTen);
			this.Controls.Add(this.textEdit1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtTenDangNhap);
			this.Name = "UCThongTinTK";
			this.Size = new System.Drawing.Size(506, 275);
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDoiTen;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTenDangNhap;
    }
}
