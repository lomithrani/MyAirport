//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyAirport.Data.ModelEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class VOL_DEPART
    {
        public int ID_VOL { get; set; }
        public Nullable<int> ID_EMPORT { get; set; }
        public string SHA { get; set; }
        public string CRE { get; set; }
        public string TYP { get; set; }
        public Nullable<short> JUR { get; set; }
        public Nullable<System.DateTime> SCT { get; set; }
        public Nullable<System.DateTime> AVC { get; set; }
        public string IMM { get; set; }
        public Nullable<short> PAX { get; set; }
        public string MAS { get; set; }
        public string DES { get; set; }
    
        public virtual EMPORT EMPORT { get; set; }
        public virtual VOL VOL { get; set; }
    }
}