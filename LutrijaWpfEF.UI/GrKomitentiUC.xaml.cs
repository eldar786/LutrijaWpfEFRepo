using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LutrijaWpfEF.UI
{
    /// <summary>
    /// Interaction logic for GrKomitentiUC.xaml
    /// </summary>
    public partial class GrKomitentiUC : UserControl
    {
        public GrKomitentiUC()
        {
            InitializeComponent();
        }

        //public void PopulateKomitenti()
        //{
        //    string queryString = "SELECT IME, PREZIME, MATICNI_BROJ,ZIRO_RACUN, STARA_SIFRA FROM ORACLE_DB..IBS.GR_KOMITENTI";
        //    using (SqlConnection connection = new SqlConnection(
        //       "Server = db-srv-01; Database=Lutrija;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=Lutrija1;"))
        //    {
        //        SqlCommand command = new SqlCommand(
        //            queryString, connection);
        //        connection.Open();
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            foreach (var item in reader)
        //            {
        //                GrKomitenti.Items.Add(item);
        //            }
        //        }
        //    }
        //}

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    PopulateKomitenti();
        //}
    }
}
