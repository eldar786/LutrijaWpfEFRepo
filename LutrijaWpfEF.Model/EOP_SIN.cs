//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LutrijaWpfEF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EOP_SIN
    {
        public int ID { get; set; }
        public int OP_BROJ { get; set; }
        public string OPSTINA { get; set; }
        public int REGION { get; set; }
        public int TERMINAL { get; set; }
        public int IGRA { get; set; }
        public int RED_KOLO { get; set; }
        public int KOLO_PRET { get; set; }
        public decimal UPL { get; set; }
        public int UPL_MJE { get; set; }
        public int SEDMICA { get; set; }
        public int DAN_SED { get; set; }
        public System.DateTime DATUM { get; set; }
        public int SRECKA { get; set; }
    
        public virtual OPCINE OPCINE { get; set; }
    }
}