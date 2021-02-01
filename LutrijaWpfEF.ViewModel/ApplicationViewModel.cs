using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LutrijaWpfEF.ViewModel
{
    public class ApplicationViewModel : ObservableObject
    {
        public ICommand GlavniCommand { get; set; }

        public ICommand OpBrojCommand { get; set; }

        public ICommand OrgCommand { get; set; }

        public ICommand ImportCommand { get; set; }

        public ICommand EopAnaCommand { get; set; }

        public ICommand GrOrgCommand { get; set; }

        public ICommand GrKomCommand { get; set; }




        private object _odabraniVM;
        private object _odabraniVMOpBroj;
        private object _odabraniVMOrgView;
        private object _odabraniVMImport;
        private GlavniRepository _gr;


        public object OdabraniVM
        {

            get { return _odabraniVM; }

            set
            {
                _odabraniVM = value;
                OnPropertyChanged("OdabraniVM");
            }

        }

        public object OdabraniVMOpBroj
        {

            get { return _odabraniVMOpBroj; }

            set { _odabraniVMOpBroj = value; OnPropertyChanged("OdabraniVMOpBroj"); }

        }

        public object OdabraniVMOrgView
        {

            get { return _odabraniVMOrgView; }

            set { _odabraniVMOrgView = value; OnPropertyChanged("OdabraniVMOrgView"); }

        }

        public object OdabraniVMImport
        {

            get { return _odabraniVMImport; }

            set { _odabraniVMImport = value; OnPropertyChanged("OdabraniVMImport"); }

        }

        public ApplicationViewModel()
        {

            _gr = new GlavniRepository();

            GlavniCommand = new RelayCommand(OtvoriGlavni);

            OpBrojCommand = new RelayCommand(OtvoriOpBroj);

            OrgCommand = new RelayCommand(OtvoriOrg);

            ImportCommand = new RelayCommand(OtvoriImport);

            EopAnaCommand = new RelayCommand(OtvoriEopAna);

            GrOrgCommand = new RelayCommand(OtvoriGrOrg);

            GrKomCommand = new RelayCommand(OtvoriGrKom);
        }



        public GlavniRepository Gr
        {
            get { return _gr; }
            set { _gr = value; OnPropertyChanged("Gr"); }
        }
        private void OtvoriGlavni()

        {

            OdabraniVM = new GlavniViewModel();

        }

        private void OtvoriOpBroj()

        {
            OdabraniVM = new OdaberiOpBrojViewModel(this);
        }

        private void OtvoriOrg()

        {
            OdabraniVM = new OrgViewModel(this);
        }

        private void OtvoriImport()
        {
            OdabraniVM = new ImportViewModel(this); 
        }

        private void OtvoriEopAna()
        {
            OdabraniVM = new EopAnaViewModel();
        }

        private void OtvoriGrOrg()
        {
            OdabraniVM = new GrOrgViewModel();
        }

        private void OtvoriGrKom()
        {
            OdabraniVM = new GrKomViewModel();
        }
    }
}



