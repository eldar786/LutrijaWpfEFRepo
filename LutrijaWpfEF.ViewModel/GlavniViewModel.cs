using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LutrijaWpfEF.ViewModel
{
    public class GlavniViewModel : ObservableObject, IPageViewModel
    {
        public ICommand WizardCommand { get; set; }

        public string Name
        {
            get
            {
                return "Glavni";
            }
        }
              

    }
}
