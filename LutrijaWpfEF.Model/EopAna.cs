namespace LutrijaWpfEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class EopAna
    {
        

        [StringLength(220)]
        public string OPERATIVNI_BROJ { get; set; }

        [StringLength(220)]
        public string SEDMICA { get; set; }

        [StringLength(220)]
        public string PRODAJNO_MJESTO { get; set; }

        [StringLength(220)]
        public string VRIJEME_UPLATE { get; set; }

        [StringLength(220)]
        public string DATUM_UPLATE { get; set; }

        [StringLength(220)]
        public string KOLO { get; set; }

        public int ID { get; set; }

        public override string ToString() => OPERATIVNI_BROJ + " " + SEDMICA;


        public EopAna(string oPERATIVNI_BROJ, string sEDMICA, string pRODAJNO_MJESTO, string vRIJEME_UPLATE, string dATUM_UPLATE, string kOLO)
        {
            OPERATIVNI_BROJ = oPERATIVNI_BROJ;
            SEDMICA = sEDMICA;
            PRODAJNO_MJESTO = pRODAJNO_MJESTO;
            VRIJEME_UPLATE = vRIJEME_UPLATE;
            DATUM_UPLATE = dATUM_UPLATE;
            KOLO = kOLO;
        }
        public EopAna()
        {

        }

        public static EopAna GetEopAnaFromResultSet(SqlDataReader reader)
        {
            EopAna eopAna = new EopAna((string)reader["OPERATIVNI_BROJ"], (string)reader["SEDMICA"], (string)reader["PRODAJNO_MJESTO"], (string)reader["VRIJEME_UPLATE"],
                                             (string)reader["DATUM_UPLATE"], (string)reader["KOLO"]);
            
            return eopAna;
        }
    }
}
