//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLSATİS
    {
        public int İD { get; set; }
        public Nullable<int> ÜRÜN { get; set; }
        public Nullable<int> PERSONEL { get; set; }
        public Nullable<int> MUSTERİ { get; set; }
        public Nullable<decimal> FİYAT { get; set; }
        public Nullable<System.DateTime> TARİH { get; set; }
    
        public virtual TBLMUSTERİ TBLMUSTERİ { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL { get; set; }
        public virtual TBLURUNLER TBLURUNLER { get; set; }
    }
}
