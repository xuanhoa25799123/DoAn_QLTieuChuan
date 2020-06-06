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
    public partial class UCTieuChi : DevExpress.XtraEditors.XtraUserControl
    {
        private static UCTieuChi _instance;
        public static UCTieuChi Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UCTieuChi();
                }
                return _instance;
            }

        }
        public UCTieuChi()
        {
            InitializeComponent();
        }

        private void UCTieuChi_Load(object sender, EventArgs e)
        {

        }
    }
}
