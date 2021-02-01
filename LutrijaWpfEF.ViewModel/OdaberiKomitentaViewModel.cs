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
    public class OdaberiKomitentaViewModel : ObservableObject
    {
        private ObservableCollection<komitenti_ime_matbr_zracun> _sviKomitenti;
       
        private komitenti_ime_matbr_zracun _odabraniKomitent;
        private List<komitenti_ime_matbr_zracun> _komitentiPretraga;
        private string _pretraga;
        private bool _omoguciDodavanje;
        private ApplicationViewModel _avm;
        

        public ICommand OdaberiCommand { get; set; }
       





        public OdaberiKomitentaViewModel(ApplicationViewModel avm)
        {
            var OrgViewModelContext = new LutrijaEntities1();

           
            SviKomitenti = new ObservableCollection<komitenti_ime_matbr_zracun>();
            _komitentiPretraga = OrgViewModelContext.komitenti_ime_matbr_zracun.ToList();
            _avm = avm;

            foreach (komitenti_ime_matbr_zracun k in _komitentiPretraga)
            {
                SviKomitenti.Add(k);

            }

            Sortiraj();

            this.OdaberiCommand = new RelayCommand(Odaberi);
            
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
                                                                                    where i.IME.IndexOf(_pretraga) >= 0 ||  i.MATICNI_BROJ.IndexOf(_pretraga) >= 0
                                                                                    select i);
            }
            else
            {
                SviKomitenti.Clear();

                if (_komitentiPretraga != null)
                {

                    foreach (komitenti_ime_matbr_zracun komitent in _komitentiPretraga)
                    {
                        SviKomitenti.Add(komitent);
                    }
                }
            }
            Sortiraj();
        }


        private void Odaberi()
        {

            if (OdabraniKomitent != null)
            {
                OdabraniKomitent = _odabraniKomitent;


                OmoguciDodavanje = true;

                
                OrgViewModel org = new OrgViewModel(_avm);
                org.OdabraniKomitent = _odabraniKomitent;

                _avm.OdabraniVM = org;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Morate odabrati bar jednog komitenta", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public ObservableCollection<komitenti_ime_matbr_zracun> SviKomitenti { get => _sviKomitenti; set { _sviKomitenti = value; OnPropertyChanged("SviKomitenti"); } }
       
        public komitenti_ime_matbr_zracun OdabraniKomitent { get => _odabraniKomitent; set { _odabraniKomitent = value; OnPropertyChanged("OdabraniKomitent"); } }
        public string Pretraga { get => _pretraga; set { _pretraga = value; TraziKomitenta(_pretraga); } }
        public bool OmoguciDodavanje { get => _omoguciDodavanje; set { _omoguciDodavanje = value; OnPropertyChanged("OmoguciDodavanje"); } }

    }
}
  