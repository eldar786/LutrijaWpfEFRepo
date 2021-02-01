using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutrijaWpfEF.Model
{
   public class GrKom
    {
        [StringLength(220)]
        public string IME { get; set; }

        [StringLength(220)]
        public string MATICNI_BROJ { get; set; }

        [StringLength(220)]
        public string ZIRO_RACUN { get; set; }

        [StringLength(220)]
        public string STARA_SIFRA { get; set; }

        public GrKom(string iME, string mATICNI_BROJ, string zIRO_RACUN, string sTARA_SIFRA)
        {
            IME = iME;
            MATICNI_BROJ = mATICNI_BROJ;
            ZIRO_RACUN = zIRO_RACUN;
            STARA_SIFRA = sTARA_SIFRA;
        }

        public GrKom()
        {

        }

        public static GrKom GetKomFromResultSet(SqlDataReader reader)
        {

            string ime = Convert.IsDBNull(reader["IME"]) ? null : (string)reader["IME"];
            string matBroj = Convert.IsDBNull(reader["MATICNI_BROJ"]) ? null : (string)reader["MATICNI_BROJ"];
            string ziroRacun = Convert.IsDBNull(reader["ZIRO_RACUN"]) ? null : (string)reader["ZIRO_RACUN"];
            string staraSifra = Convert.IsDBNull(reader["STARA_SIFRA"]) ? null : (string)reader["STARA_SIFRA"];

            GrKom grKom = new GrKom(ime,matBroj,ziroRacun,staraSifra);

            return grKom;
        }
    }
}
