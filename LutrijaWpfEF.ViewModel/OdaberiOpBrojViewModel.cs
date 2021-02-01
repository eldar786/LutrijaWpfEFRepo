using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace LutrijaWpfEF.ViewModel
{
    public class OdaberiOpBrojViewModel : ObservableObject
    {

        private ObservableCollection<komitenti_ime_matbr_zracun> _sviKomitenti;
        private ObservableCollection<komitenti_ime_matbr_zracun> _komitentiZaOrg;
        private komitenti_ime_matbr_zracun _odabraniKomitent;
        private List<komitenti_ime_matbr_zracun> _komitentiPretraga;
        private string _pretraga;
        private bool _omoguciDodavanje;
        private ApplicationViewModel _avm;
        public ICommand DodajCommand { get; set; }
        public ICommand DodajSveCommand { get; set; }
        public ICommand UkloniCommand { get; set; }
        public ICommand UkloniSveCommand { get; set; }

        public ICommand SljedeciCommand { get; set; }





        public OdaberiOpBrojViewModel(ApplicationViewModel avm)
        {
            var OrgViewModelContext = new LutrijaEntities1();

            _komitentiZaOrg = new ObservableCollection<komitenti_ime_matbr_zracun>();
            SviKomitenti = new ObservableCollection<komitenti_ime_matbr_zracun>();
            _komitentiPretraga = OrgViewModelContext.komitenti_ime_matbr_zracun.ToList();
            _avm = avm;

            foreach (komitenti_ime_matbr_zracun k in _komitentiPretraga)
            {
                SviKomitenti.Add(k);

            }

            Sortiraj();

            this.DodajCommand = new RelayCommand(Dodaj);
            this.DodajSveCommand = new RelayCommand(DodajSve);
            this.UkloniCommand = new RelayCommand(Ukloni);
            this.UkloniSveCommand = new RelayCommand(UkloniSve);
            this.SljedeciCommand = new RelayCommand(Sljedeci);

        }

        private void Sortiraj()
        {
            ICollectionView komitentiView = CollectionViewSource.GetDefaultView(_sviKomitenti);
            komitentiView.SortDescriptions.Clear();
            komitentiView.SortDescriptions.Add(new SortDescription("IME", ListSortDirection.Ascending));
        }
        public void TraziKomitenta(string _pretraga)
        {
            if (!string.IsNullOrEmpty(_pretraga) && _pretraga.Length > 0)
            {
                SviKomitenti = new ObservableCollection<komitenti_ime_matbr_zracun>(from i in _sviKomitenti
                                                                                    where i.IME.IndexOf(_pretraga) >= 0 || i.MATICNI_BROJ.IndexOf(_pretraga) >= 0
                                                                                    select i);

            }
            else
            {
                SviKomitenti.Clear();

                if (_komitentiPretraga != null)
                {
                    _komitentiPretraga.RemoveAll(KomitentiZaOrg.Contains);


                    foreach (komitenti_ime_matbr_zracun komitent in _komitentiPretraga)
                    {
                        SviKomitenti.Add(komitent);
                    }
                }
            }
            Sortiraj();
        }


        private void Dodaj()
        {

            if (OdabraniKomitent != null)
            {
                KomitentiZaOrg.Add(OdabraniKomitent);
                SviKomitenti.Remove(OdabraniKomitent);
                OmoguciDodavanje = true;

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Morate odabrati bar jednog komitenta", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void DodajSve()
        {
            var pomocna = SviKomitenti.ToList();


            foreach (komitenti_ime_matbr_zracun kom in pomocna)
            {

                KomitentiZaOrg.Add(kom);
                SviKomitenti.Remove(kom);
            }

            OmoguciDodavanje = true;
        }

        public void Ukloni()
        {

            if (OdabraniKomitent != null)
            {
                SviKomitenti.Add(OdabraniKomitent);
                KomitentiZaOrg.Remove(OdabraniKomitent);

                if (KomitentiZaOrg.Count == 0)
                {
                    OmoguciDodavanje = false;
                }
            }
        }

        public void UkloniSve()
        {
            var pomocna = KomitentiZaOrg.ToList();

            foreach (komitenti_ime_matbr_zracun kom in pomocna)
            {
                SviKomitenti.Add(kom);
                KomitentiZaOrg.Remove(kom);
            }
            if (KomitentiZaOrg.Count == 0)
            {
                OmoguciDodavanje = false;
            }

            Sortiraj();
        }



        private void Sljedeci()
        {

            if (_avm.OdabraniVM == this)
            {
                _avm.OdabraniVMOpBroj = this;
                _avm.OdabraniVM = new OdaberiMjestoViewModel(_avm);

            }
        }



        public ObservableCollection<komitenti_ime_matbr_zracun> SviKomitenti { get => _sviKomitenti; set { _sviKomitenti = value; OnPropertyChanged("SviKomitenti"); } }
        public ObservableCollection<komitenti_ime_matbr_zracun> KomitentiZaOrg { get => _komitentiZaOrg; set { _komitentiZaOrg = value; OnPropertyChanged("KomitentiZaOrg"); } }
        public komitenti_ime_matbr_zracun OdabraniKomitent { get => _odabraniKomitent; set { _odabraniKomitent = value; OnPropertyChanged("OdabraniKomitent"); } }
        public string Pretraga { get => _pretraga; set { _pretraga = value; TraziKomitenta(_pretraga); } }
        public bool OmoguciDodavanje { get => _omoguciDodavanje; set { _omoguciDodavanje = value; OnPropertyChanged("OmoguciDodavanje"); } }

    }
}



