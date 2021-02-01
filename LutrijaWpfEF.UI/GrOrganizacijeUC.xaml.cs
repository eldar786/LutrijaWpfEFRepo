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
    /// Interaction logic for GrOrganizacijeUC.xaml
    /// </summary>
    public partial class GrOrganizacijeUC : UserControl
    {
        public GrOrganizacijeUC()
        {
            InitializeComponent();
        }

        private void TextBoxSifra_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxSifra_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        //private void PopulateGrOrg()
        //{
        //    //SELECT SIFRA, NAZIV, ADRESA, TELEFON, OPIS FROM ORACLE_DB..IBS.GR_ORGANIZACIJE
        //    string queryString = "SELECT SIFRA, NAZIV, ADRESA, TELEFON, OPIS FROM ORACLE_DB..IBS.GR_ORGANIZACIJE";
        //    using (SqlConnection connection = new SqlConnection(
        //        "Server=db-srv-01;Database=Lutrija;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=sa;Password=Lutrija1;"))
        //    {
        //        SqlCommand command = new SqlCommand(
        //            queryString, connection);
        //        connection.Open();

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {

        //            foreach (var item in reader)
        //            {
        //                GrOrgList.Items.Add(item);
        //            }
        //        }
        //    }
        //}

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    PopulateGrOrg();
        //}
    }
}
