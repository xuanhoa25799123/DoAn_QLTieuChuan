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
    public partial class UCThongTinTK : DevExpress.XtraEditors.XtraUserControl
    {
        private static UCThongTinTK _instance;

        public static UCThongTinTK Instance
        {
            get {
                if(_instance == null)
                {
                    _instance = new UCThongTinTK();
                }
                return _instance;
            }
            
        }
        public UCThongTinTK()
        {
            InitializeComponent();
        }
    }
}
