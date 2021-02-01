using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutrijaWpfEF.Model
{
   public class GrKomCollection : ObservableCollection<GrKom>
    {
        

        public static GrKomCollection GetAllGrKom()
        {

            GrKomCollection grKomList = new GrKomCollection();
            GrKom grKom = null;

            string queryString = "SELECT IME, PREZIME, MATICNI_BROJ,ZIRO_RACUN, STARA_SIFRA FROM ORACLE_DB..IBS.GR_KOMITENTI";
            using (SqlConnection connection = new SqlConnection(
               "Server = db-srv-01; Database=Lutrija;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=Lutrija1;"))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //foreach (var item in reader)
                    //{
                    //    GrKomitenti.Items.Add(item);
                    //}
                    while (reader.Read())
                    {
                        grKom = GrKom.GetKomFromResultSet(reader);
                        grKomList.Add(grKom);
                    }
                }
            }
            return grKomList;
        }
    }
}
