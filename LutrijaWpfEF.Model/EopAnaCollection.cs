using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutrijaWpfEF.Model
{
    public class EopAnaCollection : ObservableCollection<EopAna>
    {


        // nece biti vise ovah tip kolekcije vec koristiomo kolekciju koju smo mi napravili EopAnaCollection umjesto List<EopAna>
        //public static List<EopAna> GetAllEopAna() -- ranije
        public static EopAnaCollection GetAllEopAna()
        {
            EopAnaCollection eopAnaList = new EopAnaCollection();
            EopAna eopAna = null;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.EOP_ANA", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //eopAna = new EopAna((string)reader["OPERATIVNI_BROJ"], (string)reader["SEDMICA"], (string)reader["PRODAJNO_MJESTO"], (string)reader["VRIJEME_UPLATE"],
                        //                    (string)reader["DATUM_UPLATE"], (string)reader["KOLO"]);

                        eopAna = EopAna.GetEopAnaFromResultSet(reader);
                        eopAnaList.Add(eopAna);
                    }
                }
            }
            return eopAnaList;

        }
    }
}

