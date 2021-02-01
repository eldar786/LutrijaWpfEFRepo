using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;


namespace LutrijaWpfEF.ViewModel
{


    public class PregledPoIgrama : ObservableObject
    {
        private List<OPCINE> _opcine;
        private ApplicationViewModel _avm;
        private komitenti_ime_matbr_zracun _odabraniKomitent;
        private OdaberiKomitentaViewModel _oKVM;

        private List<ISPLATA> _isplateOsnovneIgre;
        private List<ISPLATA> _poreziZaOrgOsnovneIgre;
        private List<EOP_SIN> _uplateOsnovneIgre;
        private List<KLADIONICA> _uplateZaOrgKladionica;
        private List<KLADIONICA> _listiciKladionica;
        private List<KLADIONICA> _isplateZaOrgKladionica;
        private List<KLADIONICA> _poreziZaOrgKladionica;
        private List<ISPLATA> _isplateZaOrg;
        private List<POLOG_PAZAR> _pazarZaOrg;
        private List<POLOG_PAZAR> _pazar;
        private List<IGRE> _igre;
        private List<EOP_SIN> _uplateZaOrgOsnovneIgre;
        private List<EOP_SIN> _uplateZaOrgSrecke;
        private List<EOP_SIN> _uplateZaOrgWebIsplata;
        private decimal? _isplataOsnovneIgreSrecke;
        private decimal? _uplataOsnovneIgre;
        private decimal? _uplataSreckeSve;
        private decimal? _ukupnaUplata;
        private decimal? _ukupnaIsplata;
        private decimal? _porezOsnovneIgre;
        private decimal? _porez;
        private decimal? _porezKladionica;
        private decimal? _isplataKladionica;
        private decimal? _uplataKladionica;
        private decimal? _saldo;
        private decimal? _pologPazara;
        private decimal? _webIsplata;
        private DateTime _od = DateTime.Now;
        private DateTime _do = DateTime.Now;
        private Org _org;

        public ICommand KomitentiCommand { get; set; }
        public ICommand KreirajOrgCommand { get; set; }


        public PregledPoIgrama (ApplicationViewModel avm)
        {
            var OrgViewModelContext = new LutrijaEntities1();

            _avm = avm;
          //  _odabraniKomitent = 
            _odabraniKomitent.IME = "Odaberi Komitenta";
            _uplateOsnovneIgre = OrgViewModelContext.EOP_SIN.ToList();
            _isplateOsnovneIgre = OrgViewModelContext.ISPLATA.ToList();
            _listiciKladionica = OrgViewModelContext.KLADIONICA.ToList();
            _igre = OrgViewModelContext.IGRE.ToList();
            _pazar = OrgViewModelContext.POLOG_PAZAR.ToList();

            //imamo ovdjegresku

           
            this.KreirajOrgCommand = new RelayCommand(PodijeliPoIgri);



        }

        private void Komitenti()
        {

            if (_avm.OdabraniVM == this)
            {

                _avm.OdabraniVM = new OdaberiKomitentaViewModel(_avm);

            }
        }

        private void PodijeliPoIgri()
        {
            _isplateZaOrg = new List<ISPLATA>();
            _uplateZaOrgOsnovneIgre = new List<EOP_SIN>();
            _uplateZaOrgSrecke = new List<EOP_SIN>();
            _uplateZaOrgKladionica = new List<KLADIONICA>();
            _isplateZaOrgKladionica = new List<KLADIONICA>();
            _poreziZaOrgKladionica = new List<KLADIONICA>();
            _poreziZaOrgOsnovneIgre = new List<ISPLATA>();
            _pazarZaOrg = new List<POLOG_PAZAR>();
            _uplateZaOrgWebIsplata = new List<EOP_SIN>();
            _org = new Org();


            // Isplata Osnovne Igre
            foreach (ISPLATA i in _isplateOsnovneIgre.Where(ios => ios.LIS_ISPL == OdabraniKomitent.STARA_SIFRA && ios.LIS_VRISPL >= Od && ios.LIS_VRISPL <= Do).GroupBy(ios => ios.LIS_IGRA))
            {
                _isplateZaOrg.Add(i);
            }

            _org.IsplataOsnovneIgre = (from i in _isplateZaOrg
                                       select i.LIS_IZNOS).Sum();
           
            //Uplata Osnovne Igre (Kolo pretplate se racuna na datum uplate ne za uplaceno kolo)
            foreach (EOP_SIN es in _uplateOsnovneIgre.Where(ios => ios.OP_BROJ.ToString().PadLeft(5, '0') == OdabraniKomitent.STARA_SIFRA && ios.DATUM >= Od && ios.DATUM <= Do && ios.SRECKA == 0 && ios.IGRA != 30))
            {
                _uplateZaOrgOsnovneIgre.Add(es);
            }

            _org.UplataOsnovneIgre = (from i in _uplateZaOrgOsnovneIgre
                                      select i.UPL).Sum();
            UplataOsnovneIgre = _org.UplataOsnovneIgre;

            foreach (EOP_SIN es in _uplateOsnovneIgre.Where(ios => ios.OP_BROJ.ToString().PadLeft(5, '0') == OdabraniKomitent.STARA_SIFRA && ios.DATUM >= Od && ios.DATUM <= Do && ios.SRECKA == 0 && ios.IGRA == 30))
            {
                _uplateZaOrgWebIsplata.Add(es);
            }

            _org.WebIsplata = (from i in _uplateZaOrgWebIsplata
                               select i.UPL).Sum();

            WebIsplata = _org.WebIsplata;

            //Uplata Srecke
            foreach (EOP_SIN esi in _uplateOsnovneIgre.Where(ios => ios.OP_BROJ.ToString().PadLeft(5, '0') == OdabraniKomitent.STARA_SIFRA && ios.DATUM >= Od && ios.DATUM <= Do && ios.SRECKA != 0))
            {
                _uplateZaOrgSrecke.Add(esi);
            }

            _org.UplataSrecke = (from i in _uplateZaOrgSrecke
                                 select i.UPL).Sum();
            UplataSreckeSve = _org.UplataSrecke;

            //SRECKE NEMAJU POREZ MORA SE RUCNO IZRACUNATI IZ FILEA ZA SVAKU SRECKU DOBITKA PREKO 100 KM 10%



            //Porez Osnovne Igre i Srecke
            foreach (ISPLATA i in _isplateOsnovneIgre.Where(ios => ios.LIS_ISPL == OdabraniKomitent.STARA_SIFRA && ios.LIS_VRISPL >= Od && ios.LIS_VRISPL <= Do && ios.LIS_POREZ != 0))
            {
                _poreziZaOrgOsnovneIgre.Add(i);
            }

            PorezOsnovneIgre = (from i in _poreziZaOrgOsnovneIgre
                                select i.LIS_POREZ).Sum();


        }
        public komitenti_ime_matbr_zracun OdabraniKomitent { get => _odabraniKomitent; set { _odabraniKomitent = value; OnPropertyChanged("OdabraniKomitent"); } }

        public Org Org { get => _org; set { _org = value; OnPropertyChanged("Org"); } }
        public DateTime Od { get => _od; set { _od = value; OnPropertyChanged("Od"); } }
        public DateTime Do { get => _do; set { _do = value; OnPropertyChanged("Do"); } }

        public decimal? IsplataOsnovneIgreSrecke { get => _isplataOsnovneIgreSrecke; set { _isplataOsnovneIgreSrecke = value; OnPropertyChanged("IsplataOsnovneIgreSrecke"); } }
        public decimal? UplataOsnovneIgre { get => _uplataOsnovneIgre; set { _uplataOsnovneIgre = value; OnPropertyChanged("UplataOsnovneIgre"); } }
        public decimal? UplataSreckeSve { get => _uplataSreckeSve; set { _uplataSreckeSve = value; OnPropertyChanged("UplataSreckeSve"); } }
        public decimal? UkupnaUplata { get => _ukupnaUplata; set { _ukupnaUplata = value; OnPropertyChanged("UkupnaUplata"); } }
        public decimal? UkupnaIsplata { get => _ukupnaIsplata; set { _ukupnaIsplata = value; OnPropertyChanged("UkupnaIsplata"); } }
        public decimal? Saldo { get => _saldo; set { _saldo = value; OnPropertyChanged("Saldo"); } }
        public decimal? PorezOsnovneIgre { get => _porezOsnovneIgre; set { _porezOsnovneIgre = value; OnPropertyChanged("PorezOsnovneIgre"); } }
        public decimal? PorezKladionica { get => _porezKladionica; set { _porezKladionica = value; OnPropertyChanged("PorezKladionica"); } }
        public decimal? UplataKladionica { get => _uplataKladionica; set { _uplataKladionica = value; OnPropertyChanged("UplataKladionica"); } }
        public decimal? IsplataKladionica { get => _isplataKladionica; set { _isplataKladionica = value; OnPropertyChanged("IsplataKladionica"); } }

        public decimal? Porez { get => _porez; set { _porez = value; OnPropertyChanged("Porez"); } }

        public decimal? PologPazara { get => _pologPazara; set { _pologPazara = value; OnPropertyChanged("PologPazara"); } }
        public decimal? WebIsplata { get => _webIsplata; set { _webIsplata = value; OnPropertyChanged("WebIsplata"); } }


    }

}
