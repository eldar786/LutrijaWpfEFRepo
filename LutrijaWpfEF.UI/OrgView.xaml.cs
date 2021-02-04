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
    /// Interaction logic for OrgView.xaml
    /// </summary>
    public partial class OrgView : UserControl
    {

        private int _errors = 0;

        public OrgView()
        {
            InitializeComponent();
            
        }

        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _errors == 0;
            e.Handled = true;
        }

        private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;

        }
        public void OtvoriKomitente()
        {
            //KomitentiWindow komitenti = new KomitentiWindow(KomitentiView view);
        }
        private void datOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datDo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void stampa_button(object sender, RoutedEventArgs e)
        {
            //PrintOrg print = new PrintOrg();
            //print.Stampa();
        }
    }
}
