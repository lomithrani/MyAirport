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
    
    public partial class VOL_ARRIVE
    {
        public int ID_VOL { get; set; }
        public string AER_ORIGINE { get; set; }
        public bool CTRL_SUR_OK { get; set; }
    
        public virtual VOL VOL { get; set; }
    }
}
