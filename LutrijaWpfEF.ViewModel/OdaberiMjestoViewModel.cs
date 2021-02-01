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
        public class OdaberiMjestoViewModel : ObservableObject
        {

            private ObservableCollection<GR_ORGANIZACIJE_VIEW> _svaMjesta;
            private ObservableCollection<GR_ORGANIZACIJE_VIEW> _mjestaZaOrg;
            private GR_ORGANIZACIJE_VIEW _odabranoMjesto;
            private List<GR_ORGANIZACIJE_VIEW> _mjestaPretraga;
            private string _pretraga;
            private bool _omoguciDodavanje;
            private ApplicationViewModel _avm;
            public ICommand DodajCommand { get; set; }

        public ICommand DodajSveCommand { get; set; }
        public ICommand UkloniCommand { get; set; }
        public ICommand UkloniSveCommand { get; set; }
        public ICommand PrethodniCommand { get; set; }
        public ICommand SljedeciCommand { get; set; }





            public OdaberiMjestoViewModel(ApplicationViewModel avm)
            {
                var OrgViewModelContext = new LutrijaEntities1();
                
                _mjestaZaOrg = new ObservableCollection<GR_ORGANIZACIJE_VIEW>();
                SvaMjesta = new ObservableCollection<GR_ORGANIZACIJE_VIEW>();
            _mjestaPretraga = OrgViewModelContext.GR_ORGANIZACIJE_VIEW.ToList();
            _avm = avm;


                foreach (GR_ORGANIZACIJE_VIEW mj in _mjestaPretraga)
                {
                    SvaMjesta.Add(mj);

                }

                this.DodajCommand = new RelayCommand(Dodaj);
            this.DodajSveCommand = new RelayCommand(DodajSve);
            this.UkloniCommand = new RelayCommand(Ukloni);
            this.UkloniSveCommand = new RelayCommand(UkloniSve);
            this.PrethodniCommand = new RelayCommand(Prethodni);
            this.SljedeciCommand = new RelayCommand(Sljedeci);
            }

        private void Sortiraj()
        {
            ICollectionView mjestaView = CollectionViewSource.GetDefaultView(_svaMjesta);
            mjestaView.SortDescriptions.Clear();
            mjestaView.SortDescriptions.Add(new SortDescription("NAZIV", ListSortDirection.Ascending));
        }
        public void TraziMjesto(string _pretraga)
            {
                if (!string.IsNullOrEmpty(_pretraga) && _pretraga.Length > 0)
                {
                    SvaMjesta = new ObservableCollection<GR_ORGANIZACIJE_VIEW>(from i in _svaMjesta
                                                                                        where i.SIFRA.IndexOf(_pretraga) >= 0 || i.NAZIV.IndexOf(_pretraga) >= 0
                                                                                        select i);

                }
                else
                {
                    SvaMjesta.Clear();
                    if (_mjestaPretraga != null)
                    {
                    _mjestaPretraga.RemoveAll(MjestaZaOrg.Contains);

                        foreach (GR_ORGANIZACIJE_VIEW mjesto in _mjestaPretraga)
                        {
                            SvaMjesta.Add(mjesto);
                        }
                    }
                }

            }
            private void Dodaj()
            {

                if (OdabranoMjesto != null)
                {
                    MjestaZaOrg.Add(OdabranoMjesto);
                    SvaMjesta.Remove(OdabranoMjesto);
                    OmoguciDodavanje = true;

                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Morate odabrati bar jednu lokaciju", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        public void DodajSve()
        {
            var pomocna = SvaMjesta.ToList();

          
                foreach (GR_ORGANIZACIJE_VIEW mje in pomocna)
                {
                   
                    MjestaZaOrg.Add(mje);
                    SvaMjesta.Remove(mje);
                }

                OmoguciDodavanje = true;
        }

        public void Ukloni()
        {
           
            if (OdabranoMjesto != null)
            {
                SvaMjesta.Add(OdabranoMjesto);
                MjestaZaOrg.Remove(OdabranoMjesto);

                if (MjestaZaOrg.Count == 0)
                {
                    OmoguciDodavanje = false;
                }
            }
        }

        public void UkloniSve()
        {
            var pomocna = MjestaZaOrg.ToList();

            foreach (GR_ORGANIZACIJE_VIEW mje in pomocna)
            {
                SvaMjesta.Add(mje);
                MjestaZaOrg.Remove(mje);
            }
            if (MjestaZaOrg.Count == 0)
            {
                OmoguciDodavanje = false;
            }

            Sortiraj();
        }



        private void Sljedeci()
            {

                if (_avm.OdabraniVM == this)
                {
                   // _avm.OdabraniVM = new OdaberiIgreViewModel();
                }
            }

        private void Prethodni()
        {

            if (_avm.OdabraniVM == this)
            {
                _avm.OdabraniVM = _avm.OdabraniVMOpBroj;
            }
        }


        public ObservableCollection<GR_ORGANIZACIJE_VIEW> SvaMjesta { get => _svaMjesta; set { _svaMjesta = value; OnPropertyChanged("SvaMjesta"); } }
            public ObservableCollection<GR_ORGANIZACIJE_VIEW> MjestaZaOrg { get => _mjestaZaOrg; set { _mjestaZaOrg = value; OnPropertyChanged("MjestaZaOrg"); } }
            public GR_ORGANIZACIJE_VIEW OdabranoMjesto { get => _odabranoMjesto; set { _odabranoMjesto = value; OnPropertyChanged("OdabranoMjesto"); } }
            public string Pretraga { get => _pretraga; set { _pretraga = value; TraziMjesto(_pretraga); } }
            public bool OmoguciDodavanje { get => _omoguciDodavanje; set { _omoguciDodavanje = value; OnPropertyChanged("OmoguciDodavanje"); } }

        }
    }





