using LutrijaWpfEF.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for GlavniView.xaml
    /// </summary>
    public partial class GlavniView : UserControl
    {
        public GlavniView()
        {
            InitializeComponent();
            this.DataContext = new ApplicationViewModel();
        }

        public EopAnaViewModel EopAnaViewModel
        {
            get
            {
                return DataContext as EopAnaViewModel;
            }
        }

        //private void btnImport_Click(object sender, RoutedEventArgs e)
        //{
        //    odabraniContent.Content = new ImportView();

        //}



        //private void btnPregled_Click(object sender, RoutedEventArgs e)
        //{
        //    odabraniContent.Content = new EopAnaViewUC();
        //}

        private void btnProvjeriOrg_Click(object sender, RoutedEventArgs e)
        {
            odabraniContent.Content = new OrgView();
        }


        //private void btnGrOrganizacije_Click(object sender, RoutedEventArgs e)
        //{
        //    odabraniContent.Content = new GrOrganizacijeUC();
        //}


        // POSLJEDNJE !!!!!

        //private void btnGrKomitenti_Click(object sender, RoutedEventArgs e)
        //{
        //    odabraniContent.Content = new GrKomitentiUC();
        //}

        //private void org_Click(object sender, RoutedEventArgs e)
        //{
        //    odabraniContent.Content = new OrgView();
        //}

        //private void napraviOrg_Click(object sender, RoutedEventArgs e)
        //{
        //    odabraniContent.Content = new OdaberiOpBrojView();
        //}

        //Izbacen dio, dodata komanda na kontrolu
        //private void btnOrg_Click(object sender, RoutedEventArgs e)
        //{
        //    odabraniContent.Content = new OrgView();
        //}
    }
}
