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
    
    public partial class TieuChuan
    {
        public TieuChuan()
        {
            this.TieuChis = new HashSet<TieuChi>();
        }
    
        public int MaTieuChuan { get; set; }
        public string TenTieuChuan { get; set; }
        public int DiemThuc { get; set; }
    
        public virtual ICollection<TieuChi> TieuChis { get; set; }
    }
}
