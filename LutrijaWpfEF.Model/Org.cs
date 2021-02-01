using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutrijaWpfEF.Model
{
   public class Org : ObservableObject
    {
        private int _opBroj;
        private string _mjesto;
        private string _imePrezime;
        private DateTime _datOd;
        private DateTime _datDo;
        private decimal? _zaduzenja;
        private decimal? _isplataOsnovneIgre;
        private decimal? _isplataKladionica;
        private decimal? _uplataOsnovneIgre;
        private decimal? _uplataKladionica;
        private decimal? _uplataSrecke;
        private decimal? _porez;
        private decimal? _polog;
        private decimal? _webIsplata;
        private decimal? _promo;
        private decimal? _gratis;
        private int _igra;
        private decimal? _isplataIgra;
        private string _nazivIgre;
        //private decimal? _uplataLoto;
        //private decimal? _uplataLotoJoker;
        //private decimal? _uplataRedovniBingo;
        //private decimal? _uplataVanredniBingo;
        //private decimal? _uplataRedovniBingoPlus;
        //private decimal? _uplataVanredniBingoPlus;
        //private decimal? _uplataRedovniBingoJoker;
        //private decimal? _uplataVanredniBingoJoker;
        //private decimal? _uplataKladionicaSve;
        //private decimal? _uplataGreyhoundRaces;
        //private decimal? _uplataLuckySix;
        //private decimal? _uplataLotoKladenje;
        //private decimal? _uplataLiveKladenje;
        //private decimal? _uplataSportskoKladenje;
        //private decimal? _uplataAutomati;
        //private decimal? _uplataBilijar;
        //private decimal? _uplataRulet;
        //private decimal? _uplataSreckeSve;
        //private decimal? _uplataDuplaSansa1;
        //private decimal? _uplataNjamiNjami2;
        //private decimal? _uplataKes1;
        //private decimal? _uplataKes2;
        //private decimal? _uplataEkspres1;
        //private decimal? _uplataMojaDjetelina;
        //private decimal? _uplataZooVrt;
        //private decimal? _uplataCarobnaSrecka;
        //private decimal? _uplataBiser;
        //private decimal? _uplataVelikaLova;
        //private decimal? _uplataPiratskoBlago;
        //private decimal? _uplataDuplaSansa2;
        //private decimal? _uplataPronadi7;
        //private decimal? _uplataSrebreniBonus;
        //private decimal? _uplataSuperM;
        //private decimal? _uplataBiseri;
        //private decimal? _uplataSretniPar;
        //private decimal? _uplataBonusKes;
        //private decimal? _uplataKoloSrece;
        //private decimal? _uplataZlatnaRibica;
        //private decimal? _uplataJackpot;
        //private decimal? _uplataMegaLova;
        //private decimal? _uplataBrzih200;
        //private decimal? _uplata2u1;
        //private decimal? _uplataCasino;
        //private decimal? _uplataSmjesko;

        //private decimal? _isplataOsnovneIgre;
        //private decimal? _isplataRedovniBingo;
        //private decimal? _isplataRedovniBingoPlus;
        //private decimal? _isplataRedovniBingoJoker;
        //private decimal? _isplataVanredniBingo;
        //private decimal? _isplataVanredniBingoPlus;
        //private decimal? _isplataVanredniBingoJoker;
        //private decimal? _isplataLoto;
        //private decimal? _isplataLotoJoker;
        //private decimal? _isplataKladionicaSve;
        //private decimal? _isplataGreyhoundRaces;
        //private decimal? _isplataLuckySix;
        //private decimal? _isplataLotoKladenje;
        //private decimal? _isplataLiveKladenje;
        //private decimal? _isplataSportskoKladenje;
        //private decimal? _isplataAutomati;
        //private decimal? _isplataBilijar;
        //private decimal? _isplataRulet;
        //private decimal? _isplataSreckeSve;
        //private decimal? _isplataDuplaSansa1;
        //private decimal? _isplataNjamiNjami2;
        //private decimal? _isplataKes1;
        //private decimal? _isplataKes2;
        //private decimal? _isplataEkspres1;
        //private decimal? _isplataMojaDjetelina;
        //private decimal? _isplataZooVrt;
        //private decimal? _isplataCarobnaSrecka;
        //private decimal? _isplataBiser;
        //private decimal? _isplataVelikaLova;
        //private decimal? _isplataPiratskoBlago;
        //private decimal? _isplataDuplaSansa2;
        //private decimal? _isplataPronadi7;
        //private decimal? _isplataSrebreniBonus;
        //private decimal? _isplataSuperM;
        //private decimal? _isplataBiseri;
        //private decimal? _isplataSretniPar;
        //private decimal? _isplataBonusKes;
        //private decimal? _isplataKoloSrece;
        //private decimal? _isplataZlatnaRibica;
        //private decimal? _isplataJackpot;
        //private decimal? _isplataMegaLova;
        //private decimal? _isplataBrzih200;
        //private decimal? _isplata2u1;
        //private decimal? _isplataCasino;
        //private decimal? _isplataSmjesko;
        //private decimal? _porezOsnovneIgre;
        //private decimal? _porezRedovniBingo;
        //private decimal? _porezRedovniBingoPlus;
        //private decimal? _porezRedovniBingoJoker;
        //private decimal? _porezVanredniBingo;
        //private decimal? _porezVanredniBingoPlus;
        //private decimal? _porezVanredniBingoJoker;
        //private decimal? _porezLoto;
        //private decimal? _porezLotoJoker;
        //private decimal? _porezKladionicaSve;
        //private decimal? _porezGreyhoundRaces;
        //private decimal? _porezLuckySix;
        //private decimal? _porezLotoKladenje;
        //private decimal? _porezLiveKladenje;
        //private decimal? _porezSportskoKladenje;
        //private decimal? _porezAutomati;
        //private decimal? _porezBilijar;
        //private decimal? _porezRulet;
        //private decimal? _porezSreckeSve;
        //private decimal? _porezDuplaSansa1;
        //private decimal? _porezNjamiNjami2;
        //private decimal? _porezKes1;
        //private decimal? _porezKes2;
        //private decimal? _porezEkspres1;
        //private decimal? _porezMojaDjetelina;
        //private decimal? _porezZooVrt;
        //private decimal? _porezCarobnaSrecka;
        //private decimal? _porezBiser;
        //private decimal? _porezVelikaLova;
        //private decimal? _porezPiratskoBlago;
        //private decimal? _porezDuplaSansa2;
        //private decimal? _porezPronadi7;
        //private decimal? _porezSrebreniBonus;
        //private decimal? _porezSuperM;
        //private decimal? _porezBiseri;
        //private decimal? _porezSretniPar;
        //private decimal? _porezBonusKes;
        //private decimal? _porezKoloSrece;
        //private decimal? _porezZlatnaRibica;
        //private decimal? _porezJackpot;
        //private decimal? _porezMegaLova;
        //private decimal? _porezBrzih200;
        //private decimal? _porez2u1;
        //private decimal? _porezCasino;
        //private decimal? _porezSmjesko;

        public int OpBroj { get => _opBroj;  set  { _opBroj = value; OnPropertyChanged("OpBroj"); } }
        public string Mjesto { get => _mjesto;  set { _mjesto = value; OnPropertyChanged("Mjesto"); } }
        public string ImePrezime { get => _imePrezime; set { _imePrezime = value; OnPropertyChanged("ImePrezime"); } }
        public DateTime DatOd { get => _datOd; set { _datOd = value; OnPropertyChanged("DatOd"); } }
        public DateTime DatDo { get => _datDo; set { _datDo = value; OnPropertyChanged("DatDo"); } }
        public decimal? Zaduzenja { get => _zaduzenja; set { _zaduzenja = value; OnPropertyChanged("Zaduzenja"); } }
        public decimal? Polog { get => _polog; set { _polog = value; OnPropertyChanged("Polog"); } }
        public decimal? WebIsplata { get => _webIsplata; set { _webIsplata = value; OnPropertyChanged("WebIsplata"); } }
        public decimal? Promo { get => _promo; set { _promo = value; OnPropertyChanged("Promo"); } }
        public decimal? Gratis { get => _gratis; set { _gratis = value; OnPropertyChanged("Gratis"); } }
        public decimal? IsplataOsnovneIgre { get => _isplataOsnovneIgre; set { _isplataOsnovneIgre = value; OnPropertyChanged("IsplataOsnovneIgre"); } }
        public decimal? IsplataKladionica { get => _isplataKladionica; set { _isplataKladionica = value; OnPropertyChanged("IsplataKladionica"); } }
        public decimal? UplataOsnovneIgre { get => _uplataOsnovneIgre; set { _uplataOsnovneIgre = value; OnPropertyChanged("UplataOsnovneIgre"); } }
        public decimal? UplataSrecke { get => _uplataSrecke; set { _uplataSrecke = value; OnPropertyChanged("UplataSrecke"); } }
        public decimal? UplataKladionica { get => _uplataKladionica; set { _uplataKladionica = value; OnPropertyChanged("UplataKladionica"); } }
        public decimal? Porez { get => _porez; set { _porez = value; OnPropertyChanged("Porez"); } }

        public int Igra { get => _igra; set { _igra = value; OnPropertyChanged("Igra"); } }
        public decimal? IsplataIgra { get => _isplataIgra; set { _isplataIgra = value; OnPropertyChanged("IsplataIgra"); } }

        public string NazivIgre { get => _nazivIgre; set { _nazivIgre = value; OnPropertyChanged("NazivIgre"); } }


        //public decimal? Isplate { get => _isplate; set { _isplate = value; OnPropertyChanged("Isplate"); } }
        //public decimal? UplataOsnovneIgre { get => _uplataOsnovneIgre; set { _uplataOsnovneIgre = value; OnPropertyChanged("UplataOsnovneIgre"); } }
        //public decimal? UplataLoto { get => _uplataLoto; set { _uplataLoto = value; OnPropertyChanged("UplataLoto"); } }
        //public decimal? UplataLotoJoker { get => _uplataLotoJoker; set { _uplataLotoJoker = value; OnPropertyChanged("UplataLotoJoker"); } }
        //public decimal? UplataRedovniBingo { get => _uplataRedovniBingo; set { _uplataRedovniBingo = value; OnPropertyChanged("UplataRedovniBingo"); } }
        //public decimal? UplataVanredniBingo { get => _uplataVanredniBingo; set { _uplataVanredniBingo = value; OnPropertyChanged("UplataVanredniBingo"); } }
        //public decimal? UplataRedovniBingoPlus { get => _uplataRedovniBingoPlus; set { _uplataRedovniBingoPlus = value; OnPropertyChanged("UplataRedovniBingoPlus"); } }
        //public decimal? UplataVanredniBingoPlus { get => _uplataVanredniBingoPlus; set { _uplataVanredniBingoPlus = value; OnPropertyChanged("UplataVanredniBingoPlus"); } }
        //public decimal? UplataRedovniBingoJoker { get => _uplataRedovniBingoJoker; set { _uplataRedovniBingoJoker = value; OnPropertyChanged("UplataRedovniBingoJoker"); } }
        //public decimal? UplataVanredniBingoJoker { get => _uplataVanredniBingoJoker; set { _uplataVanredniBingoJoker = value; OnPropertyChanged("UplataVanredniBingoJoker"); } }
        //public decimal? UplataKladionicaSve { get => _uplataKladionicaSve; set { _uplataKladionicaSve = value; OnPropertyChanged("UplataKladionicaSve"); } }
        //public decimal? UplataGreyhoundRaces { get => _uplataGreyhoundRaces; set { _uplataGreyhoundRaces = value; OnPropertyChanged("UplataGreyhoundRaces"); } }
        //public decimal? UplataLuckySix { get => _uplataLuckySix; set { _uplataLuckySix = value; OnPropertyChanged("UplataLuckySix"); } }
        //public decimal? UplataLotoKladenje { get => _uplataLotoKladenje; set { _uplataLotoKladenje = value; OnPropertyChanged("UplataLotoKladenje"); } }
        //public decimal? UplataLiveKladenje { get => _uplataLiveKladenje; set { _uplataLiveKladenje = value; OnPropertyChanged("UplataLiveKladenje"); } }
        //public decimal? UplataSportskoKladenje { get => _uplataSportskoKladenje; set { _uplataSportskoKladenje = value; OnPropertyChanged("UplataSportskoKladenje"); } }
        //public decimal? UplataAutomati { get => _uplataAutomati; set { _uplataAutomati = value; OnPropertyChanged("UplataAutomati"); } }
        //public decimal? UplataBilijar { get => _uplataBilijar; set { _uplataBilijar = value; OnPropertyChanged("UplataBilijar"); } }
        //public decimal? UplataRulet { get => _uplataRulet; set { _uplataRulet = value; OnPropertyChanged("UplataRulet"); } }
        //public decimal? UplataSreckeSve { get => _uplataSreckeSve; set { _uplataSreckeSve = value; OnPropertyChanged("UplataSreckeSve"); } }
        //public decimal? UplataDuplaSansa1 { get => _uplataDuplaSansa1; set { _uplataDuplaSansa1 = value; OnPropertyChanged("UplataDuplaSansa1"); } }
        //public decimal? UplataNjamiNjami2 { get => _uplataNjamiNjami2; set { _uplataNjamiNjami2 = value; OnPropertyChanged("UplataNjamiNjami2"); } }
        //public decimal? UplataKes1 { get => _uplataKes1; set { _uplataKes1 = value; OnPropertyChanged("UplataKes1"); } }
        //public decimal? UplataKes2 { get => _uplataKes2; set { _uplataKes2 = value; OnPropertyChanged("UplataKes2"); } }
        //public decimal? UplataEkspres1 { get => _uplataEkspres1; set { _uplataEkspres1 = value; OnPropertyChanged("UplataEkspres1"); } }
        //public decimal? UplataMojaDjetelina { get => _uplataMojaDjetelina; set { _uplataMojaDjetelina = value; OnPropertyChanged("UplataMojaDjetelina"); } }
        //public decimal? UplataZooVrt { get => _uplataZooVrt; set { _uplataZooVrt = value; OnPropertyChanged("UplataZooVrt"); } }
        //public decimal? UplataCarobnaSrecka { get => _uplataCarobnaSrecka; set { _uplataCarobnaSrecka = value; OnPropertyChanged("UplataCarobnaSrecka"); } }
        //public decimal? UplataBiser { get => _uplataBiser; set { _uplataBiser = value; OnPropertyChanged("UplataBiser"); } }
        //public decimal? UplataVelikaLova { get => _uplataVelikaLova; set { _uplataVelikaLova = value; OnPropertyChanged("UplataVelikaLova"); } }
        //public decimal? UplataPiratskoBlago { get => _uplataPiratskoBlago; set { _uplataPiratskoBlago = value; OnPropertyChanged("UplataPiratskoBlago"); } }
        //public decimal? UplataDuplaSansa2 { get => _uplataDuplaSansa2; set { _uplataDuplaSansa2 = value; OnPropertyChanged("UplataDuplaSansa2"); } }
        //public decimal? UplataPronadi7 { get => _uplataPronadi7; set { _uplataPronadi7 = value; OnPropertyChanged("UplataPronadi7"); } }
        //public decimal? UplataSrebreniBonus { get => _uplataSrebreniBonus; set { _uplataSrebreniBonus = value; OnPropertyChanged("UplataSrebreniBonus"); } }
        //public decimal? UplataSuperM { get => _uplataSuperM; set { _uplataSuperM = value; OnPropertyChanged("UplataSuperM"); } }
        //public decimal? UplataBiseri { get => _uplataBiseri; set { _uplataBiseri = value; OnPropertyChanged("UplataBiseri"); } }
        //public decimal? UplataSretniPar { get => _uplataSretniPar; set { _uplataSretniPar = value; OnPropertyChanged("UplataSretniPar"); } }
        //public decimal? UplataBonusKes { get => _uplataBonusKes; set { _uplataBonusKes = value; OnPropertyChanged("UplataBonusKes"); } }
        //public decimal? UplataKoloSrece { get => _uplataKoloSrece; set { _uplataKoloSrece = value; OnPropertyChanged("UplataKoloSrece"); } }
        //public decimal? UplataZlatnaRibica { get => _uplataZlatnaRibica; set { _uplataZlatnaRibica = value; OnPropertyChanged("UplataZlatnaRibica"); } }
        //public decimal? UplataJackpot { get => _uplataJackpot; set { _uplataJackpot = value; OnPropertyChanged("UplataJackpot"); } }
        //public decimal? UplataMegaLova { get => _uplataMegaLova; set { _uplataMegaLova = value; OnPropertyChanged("UplataMegaLova"); } }
        //public decimal? UplataBrzih200 { get => _uplataBrzih200; set { _uplataBrzih200 = value; OnPropertyChanged("UplataBrzih200"); } }
        //public decimal? Uplata2u1 { get => _uplata2u1; set { _uplata2u1 = value; OnPropertyChanged("Uplata2u1"); } }
        //public decimal? UplataCasino { get => _uplataCasino; set { _uplataCasino = value; OnPropertyChanged("UplataCasino"); } }
        //public decimal? UplataSmjesko { get => _uplataSmjesko; set { _uplataSmjesko = value; OnPropertyChanged("UplataSmjesko"); } }

        //public decimal? IsplataOsnovneIgre { get => _isplataOsnovneIgre; set { _isplataOsnovneIgre = value; OnPropertyChanged("IsplataOsnovneIgre"); } }
        //public decimal? IsplataRedovniBingo { get => _isplataRedovniBingo; set { _isplataRedovniBingo = value; OnPropertyChanged("IsplataRedovniBingo"); } }
        //public decimal? IsplataRedovniBingoPlus { get => _isplataRedovniBingoPlus; set { _isplataRedovniBingoPlus = value; OnPropertyChanged("IsplataRedovniBingoPlus"); } }
        //public decimal? IsplataRedovniBingoJoker { get => _isplataRedovniBingoJoker; set { _isplataRedovniBingoJoker = value; OnPropertyChanged("IsplataRedovniBingoJoker"); } }
        //public decimal? IsplataVanredniBingo { get => _isplataVanredniBingo; set { _isplataVanredniBingo = value; OnPropertyChanged("IsplataVanredniBingo"); } }
        //public decimal? IsplataVanredniBingoPlus { get => _isplataVanredniBingoPlus; set { _isplataVanredniBingoPlus = value; OnPropertyChanged("IsplataVanredniBingoPlus"); } }
        //public decimal? IsplataVanredniBingoJoker { get => _isplataVanredniBingoJoker; set { _isplataVanredniBingoJoker = value; OnPropertyChanged("IsplataVanredniBingoJoker"); } }
        //public decimal? IsplataLoto { get => _isplataLoto; set { _isplataLoto = value; OnPropertyChanged("IsplataLoto"); } }
        //public decimal? IsplataLotoJoker { get => _isplataLotoJoker; set { _isplataLotoJoker = value; OnPropertyChanged("IsplataLotoJoker"); } }
        //public decimal? IsplataKladionicaSve { get => _isplataKladionicaSve; set { _isplataKladionicaSve = value; OnPropertyChanged("IsplataKladionicaSve"); } }
        //public decimal? IsplataGreyhoundRaces { get => _isplataGreyhoundRaces; set { _isplataGreyhoundRaces = value; OnPropertyChanged("IsplataGreyhoundRaces"); } }
        //public decimal? IsplataLuckySix { get => _isplataLuckySix; set { _isplataLuckySix = value; OnPropertyChanged("IsplataLuckySix"); } }
        //public decimal? IsplataLotoKladenje { get => _isplataLotoKladenje; set { _isplataLotoKladenje = value; OnPropertyChanged("IsplataLotoKladenje"); } }
        //public decimal? IsplataLiveKladenje { get => _isplataLiveKladenje; set { _isplataLiveKladenje = value; OnPropertyChanged("IsplataLiveKladenje"); } }
        //public decimal? IsplataSportskoKladenje { get => _isplataSportskoKladenje; set { _isplataSportskoKladenje = value; OnPropertyChanged("IsplataSportskoKladenje"); } }
        //public decimal? IsplataAutomati { get => _isplataAutomati; set { _isplataAutomati = value; OnPropertyChanged("IsplataAutomati"); } }
        //public decimal? IsplataBilijar { get => _isplataBilijar; set { _isplataBilijar = value; OnPropertyChanged("IsplataBilijar"); } }
        //public decimal? IsplataRulet { get => _isplataRulet; set { _isplataRulet = value; OnPropertyChanged("IsplataRulet"); } }
        //public decimal? IsplataSreckeSve { get => _isplataSreckeSve; set { _isplataSreckeSve = value; OnPropertyChanged("IsplataSreckeSve"); } }
        //public decimal? IsplataDuplaSansa1 { get => _isplataDuplaSansa1; set { _isplataDuplaSansa1 = value; OnPropertyChanged("IsplataDuplaSansa1"); } }
        //public decimal? IsplataNjamiNjami2 { get => _isplataNjamiNjami2; set { _isplataNjamiNjami2 = value; OnPropertyChanged("IsplataNjamiNjami2"); } }
        //public decimal? IsplataKes1 { get => _isplataKes1; set { _isplataKes1 = value; OnPropertyChanged("IsplataKes1"); } }
        //public decimal? IsplataKes2 { get => _isplataKes2; set { _isplataKes2 = value; OnPropertyChanged("IsplataKes2"); } }
        //public decimal? IsplataEkspres1 { get => _isplataEkspres1; set { _isplataEkspres1 = value; OnPropertyChanged("IsplataEkspres1"); } }
        //public decimal? IsplataMojaDjetelina { get => _isplataMojaDjetelina; set { _isplataMojaDjetelina = value; OnPropertyChanged("IsplataMojaDjetelina"); } }
        //public decimal? IsplataZooVrt { get => _isplataZooVrt; set { _isplataZooVrt = value; OnPropertyChanged("IsplataZooVrt"); } }
        //public decimal? IsplataCarobnaSrecka { get => _isplataCarobnaSrecka; set { _isplataCarobnaSrecka = value; OnPropertyChanged("IsplataCarobnaSrecka"); } }
        //public decimal? IsplataBiser { get => _isplataBiser; set { _isplataBiser = value; OnPropertyChanged("IsplataBiser"); } }
        //public decimal? IsplataVelikaLova { get => _isplataVelikaLova; set { _isplataVelikaLova = value; OnPropertyChanged("IsplataVelikaLova"); } }
        //public decimal? IsplataPiratskoBlago { get => _isplataPiratskoBlago; set { _isplataPiratskoBlago = value; OnPropertyChanged("IsplataPiratskoBlago"); } }
        //public decimal? IsplataDuplaSansa2 { get => _isplataDuplaSansa2; set { _isplataDuplaSansa2 = value; OnPropertyChanged("IsplataDuplaSansa2"); } }
        //public decimal? IsplataPronadi7 { get => _isplataPronadi7; set { _isplataPronadi7 = value; OnPropertyChanged("IsplataPronadi7"); } }
        //public decimal? IsplataSrebreniBonus { get => _isplataSrebreniBonus; set { _isplataSrebreniBonus = value; OnPropertyChanged("IsplataSrebreniBonus"); } }
        //public decimal? IsplataSuperM { get => _isplataSuperM; set { _isplataSuperM = value; OnPropertyChanged("IsplataSuperM"); } }
        //public decimal? IsplataBiseri { get => _isplataBiseri; set { _isplataBiseri = value; OnPropertyChanged("IsplataBiseri"); } }
        //public decimal? IsplataSretniPar { get => _isplataSretniPar; set { _isplataSretniPar = value; OnPropertyChanged("IsplataSretniPar"); } }
        //public decimal? IsplataBonusKes { get => _isplataBonusKes; set { _isplataBonusKes = value; OnPropertyChanged("IsplataBonusKes"); } }
        //public decimal? IsplataKoloSrece { get => _isplataKoloSrece; set { _isplataKoloSrece = value; OnPropertyChanged("IsplataKoloSrece"); } }
        //public decimal? IsplataZlatnaRibica { get => _isplataZlatnaRibica; set { _isplataZlatnaRibica = value; OnPropertyChanged("IsplataZlatnaRibica"); } }
        //public decimal? IsplataJackpot { get => _isplataJackpot; set { _isplataJackpot = value; OnPropertyChanged("IsplataJackpot"); } }
        //public decimal? IsplataMegaLova { get => _isplataMegaLova; set { _isplataMegaLova = value; OnPropertyChanged("IsplataMegaLova"); } }
        //public decimal? IsplataBrzih200 { get => _isplataBrzih200; set { _isplataBrzih200 = value; OnPropertyChanged("IsplataBrzih200"); } }
        //public decimal? Isplata2u1 { get => _isplata2u1; set { _isplata2u1 = value; OnPropertyChanged("Isplata2u1"); } }
        //public decimal? IsplataCasino { get => _isplataCasino; set { _isplataCasino = value; OnPropertyChanged("IsplataCasino"); } }
        //public decimal? IsplataSmjesko { get => _isplataSmjesko; set { _isplataSmjesko = value; OnPropertyChanged("IsplataSmjesko"); } }
    }
}
