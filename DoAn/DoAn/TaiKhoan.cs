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
    
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            this.BoTieuChis = new HashSet<BoTieuChi>();
            this.TieuChis = new HashSet<TieuChi>();
        }
    
        public int ID { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenHienThi { get; set; }
        public Nullable<int> LoaiTK { get; set; }
    
        public virtual ICollection<BoTieuChi> BoTieuChis { get; set; }
        public virtual ICollection<TieuChi> TieuChis { get; set; }
    }
}
