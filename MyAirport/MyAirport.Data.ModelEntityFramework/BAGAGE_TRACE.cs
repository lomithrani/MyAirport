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
    
    public partial class BAGAGE_TRACE
    {
        public int ID_TRACE { get; set; }
        public int ID_OCCURENCE { get; set; }
        public System.DateTime HOROADATE { get; set; }
        public int ID_LOCALISATION { get; set; }
        public int TYPE { get; set; }
        public Nullable<int> STATUT { get; set; }
        public string INFO { get; set; }
    
        public virtual BAGAGE_OCCURENCE BAGAGE_OCCURENCE { get; set; }
    }
}
