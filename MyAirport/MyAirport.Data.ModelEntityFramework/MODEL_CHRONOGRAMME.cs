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
    
    public partial class MODEL_CHRONOGRAMME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODEL_CHRONOGRAMME()
        {
            this.CRI_SELECTION = new HashSet<CRI_SELECTION>();
            this.EMPORTs = new HashSet<EMPORT>();
        }
    
        public int ID_CHRONOGRAMME { get; set; }
        public string LIBELLE { get; set; }
        public string HDEPREF { get; set; }
        public short DANT { get; set; }
        public short DOUVTRI { get; set; }
        public short DFTRI { get; set; }
        public short DFDM { get; set; }
        public short DRATES { get; set; }
        public bool OBSOLETE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRI_SELECTION> CRI_SELECTION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPORT> EMPORTs { get; set; }
    }
}
