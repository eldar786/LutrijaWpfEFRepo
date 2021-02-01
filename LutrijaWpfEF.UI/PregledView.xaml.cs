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
    /// Interaction logic for ImportView.xaml
    /// </summary>
    public partial class PregledView : UserControl
    {
        public PregledView()
        {
            InitializeComponent();
        }

        private void Button_Click_EOP_ANA(object sender, RoutedEventArgs e)
        {
           // prikaziContent.Content = new EopAnaView();
        }

        private void Button_Click_GR_ORG_VIEW(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_KOMITENTI_IME_MATBR_ZRACUN_VIEW(object sender, RoutedEventArgs e)
        {

        }

        private void lstKiosci_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
