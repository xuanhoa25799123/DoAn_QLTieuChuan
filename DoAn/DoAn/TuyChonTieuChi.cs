//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn
{
    using System;
    using System.Collections.Generic;
    
    public partial class TuyChonTieuChi
    {
        public TuyChonTieuChi()
        {
            this.DiemTuyChons = new HashSet<DiemTuyChon>();
        }
    
        public int MaTuyChon { get; set; }
        public Nullable<int> MaTieuChi { get; set; }
        public string NoiDungTuyChon { get; set; }
    
        public virtual ICollection<DiemTuyChon> DiemTuyChons { get; set; }
        public virtual TieuChi TieuChi { get; set; }
    }
}
