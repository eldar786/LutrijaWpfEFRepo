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
using LutrijaWpfEF.ViewModel;

namespace LutrijaWpfEF.UI
{
    /// <summary>
    /// Interaction logic for OdaberiMjestoView.xaml
    /// </summary>
    public partial class OdaberiMjestoView : UserControl
    {
        private int _errors = 0;
        public OdaberiMjestoView()
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
        }
    }

