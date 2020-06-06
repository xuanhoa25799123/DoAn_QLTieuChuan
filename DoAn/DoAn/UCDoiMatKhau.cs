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
        }
    }
}
