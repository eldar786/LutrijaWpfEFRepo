using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutrijaWpfEF.Model
{

    public class GlavniRepository:ObservableObject
    {
        private List<ISPLATA> _isplateOsnovneIgre;    
        private List<EOP_SIN> _uplateOsnovneIgre;     
        private List<KLADIONICA> _listiciKladionica;     
        private List<POLOG_PAZAR> _pazar;
        private List<IGRE> _igre;
      


        public GlavniRepository()
        {
            var OrgViewModelContext = new LutrijaEntities1();
            UplateOsnovneIgre = OrgViewModelContext.EOP_SIN.ToList();
            _isplateOsnovneIgre = OrgViewModelContext.ISPLATA.ToList();
            _listiciKladionica = OrgViewModelContext.KLADIONICA.ToList();
            _igre = OrgViewModelContext.IGRE.ToList();
            _pazar = OrgViewModelContext.POLOG_PAZAR.ToList();
        }

        public List<EOP_SIN> UplateOsnovneIgre { get => _uplateOsnovneIgre; set { _uplateOsnovneIgre = value; OnPropertyChanged("UplateOsnovneIgre"); } }
        public List<ISPLATA> IsplateOsnovneIgre { get => _isplateOsnovneIgre; set { _isplateOsnovneIgre = value; OnPropertyChanged("IsplateOsnovneIgre"); } }

        public List<KLADIONICA> ListiciKladionica { get => _listiciKladionica; set { _listiciKladionica = value; OnPropertyChanged("ListiciKladionica"); } }
        public List<IGRE> Igre { get => _igre; set { _igre = value; OnPropertyChanged("Igre"); } }

        public List<POLOG_PAZAR> Pazar { get => _pazar; set { _pazar = value; OnPropertyChanged("Pazar"); } }

    }
}
