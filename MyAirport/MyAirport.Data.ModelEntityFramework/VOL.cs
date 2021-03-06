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
    
    public partial class VOL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VOL()
        {
            this.BAGAGEs = new HashSet<BAGAGE>();
            this.VOL_ITINERAIRE = new HashSet<VOL_ITINERAIRE>();
        }
    
        public int ID_VOL { get; set; }
        public int ID_CIE { get; set; }
        public Nullable<int> ID_CEC { get; set; }
        public string LIG { get; set; }
        public short JEX { get; set; }
        public short QRF { get; set; }
        public Nullable<System.DateTime> DHC { get; set; }
        public string SPK { get; set; }
        public string STA { get; set; }
        public string DOA { get; set; }
        public string PKG { get; set; }
        public string TDH { get; set; }
        public string NAT { get; set; }
        public Nullable<System.DateTime> REP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAGAGE> BAGAGEs { get; set; }
        public virtual COMPAGNIE COMPAGNIE { get; set; }
        public virtual COMPAGNIE COMPAGNIE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOL_ITINERAIRE> VOL_ITINERAIRE { get; set; }
        public virtual VOL_ARRIVE VOL_ARRIVE { get; set; }
        public virtual VOL_DEPART VOL_DEPART { get; set; }
    }
}
