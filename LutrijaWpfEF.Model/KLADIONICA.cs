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
    
    public partial class KLADIONICA
    {
        public string BR_OBJ { get; set; }
        public string GRUPA { get; set; }
        public string OP_BR_PROD { get; set; }
        public string BROJ_LISTICA { get; set; }
        public Nullable<decimal> UPLATA { get; set; }
        public Nullable<decimal> NAK_ZA_PRIR { get; set; }
        public Nullable<decimal> ISPLATA { get; set; }
        public Nullable<decimal> PLAC_POREZ { get; set; }
        public Nullable<int> BROJ_SA_POREZOM_SIS { get; set; }
        public Nullable<decimal> UKUPNI_IZNOS_POREZA_SIS { get; set; }
        public Nullable<int> BROJ_SA_POREZOM_NOR { get; set; }
        public Nullable<decimal> UKUPNI_IZNOS_NOR { get; set; }
        public Nullable<int> BROJ_SA_POREZOM_SPEC { get; set; }
        public Nullable<decimal> UKUPNI_IZNOS_SPEC { get; set; }
        public Nullable<int> BROJ_STORNO_TIKETA { get; set; }
        public Nullable<decimal> RAZLIKA { get; set; }
        public int ID { get; set; }
        public int KLAD_IGRA { get; set; }
    
        public virtual KLADIONICA_IGRE KLADIONICA_IGRE { get; set; }
    }
}
