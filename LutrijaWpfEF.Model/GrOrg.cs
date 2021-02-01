using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutrijaWpfEF.Model
{
   public class GrOrg
    {

        [StringLength(220)]
        public string SIFRA { get; set; }

        [StringLength(220)]
        public string NAZIV { get; set; }

        [StringLength(220)]
        public string ADRESA { get; set; }

        [StringLength(220)]
        public string TELEFON { get; set; }

        [StringLength(220)]
        public string OPIS { get; set; }

        public override string ToString() => SIFRA + " " + NAZIV; 
        

        public GrOrg(string sIFRA, string nAZIV, string aDRESA, string tELEFON, string oPIS)
        {
            SIFRA = sIFRA;
            NAZIV = nAZIV;
            ADRESA = aDRESA;
            TELEFON = tELEFON;
            OPIS = oPIS;
        }

        public GrOrg()
        {

        }

        public static GrOrg GetGrOrgFromResultSet(SqlDataReader reader)
        {
            //Ukoliko tabela iz baze posjeduje NULL vrijednosti
            string adresa = Convert.IsDBNull(reader["ADRESA"]) ? null : (string)reader["ADRESA"];
            string telefon = Convert.IsDBNull(reader["TELEFON"]) ? null : (string)reader["TELEFON"];
            string opis = Convert.IsDBNull(reader["OPIS"]) ? null : (string)reader["OPIS"];



            GrOrg grOrg = new GrOrg((string)reader["SIFRA"],(string)reader["NAZIV"],adresa,telefon,opis);

            return grOrg;
        }
    }


}
