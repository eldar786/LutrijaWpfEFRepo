using LutrijaWpfEF.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutrijaWpfEF.UI.Helpers
{
        public class RepositoryHolder
        {
           // private IEnumerable<OPCINE> _opcine;
            private IEnumerable<komitenti_ime_matbr_zracun> _komitenti;
            private IEnumerable<KANTONI> _kantoni;
            private IEnumerable<OPCINE> _opcine;
            private IEnumerable<EOP_ANA> _eop_Ana;
            private IEnumerable<GR_ORGANIZACIJE_VIEW> _mjesta;
            

            public RepositoryHolder(IEnumerable<komitenti_ime_matbr_zracun> komitenti, IEnumerable<EOP_ANA> eop_Ana, IEnumerable<KANTONI> kantoni, IEnumerable<OPCINE> opcine, IEnumerable<GR_ORGANIZACIJE_VIEW> mjesta)
            {
                this._komitenti = komitenti;
                this._eop_Ana = eop_Ana;
                this._kantoni = kantoni;
                this._opcine = opcine;
                this._mjesta = mjesta;
                
            }

            public IEnumerable<komitenti_ime_matbr_zracun> Komitenti
            {
                get { return _komitenti; }
                set { _komitenti = value; }
            }

            public IEnumerable<EOP_ANA> Eop_Ana
            {
                get { return _eop_Ana; }
                set { _eop_Ana = value; }
            }

            public IEnumerable<KANTONI> Kantoni
            {
                get { return _kantoni; }
                set { _kantoni = value; }
            }

            public IEnumerable<OPCINE> Opcine
            {
                get { return _opcine; }
                set { _opcine = value; }
            }

            public IEnumerable<GR_ORGANIZACIJE_VIEW> Mjesta
            {
                get { return _mjesta; }
                set { _mjesta = value; }
            }

          
        }
    }


