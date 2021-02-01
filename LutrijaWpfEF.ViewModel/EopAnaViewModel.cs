using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace LutrijaWpfEF.ViewModel
{
    public class EopAnaViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnpropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


        #region Polja

        private EopAna currentEopAna;
        private EopAnaCollection eopAnaList;
        private ListCollectionView eopAnaListView;

        private string filteringText;
        private string operativniBrojText;

        #endregion

        #region Properties


        public EopAna CurrentEopAna
        {
            get { return currentEopAna; }
            set
            {
                if (currentEopAna == value)
                {
                    return;
                }
                currentEopAna = value;
                OnpropertyChanged(new PropertyChangedEventArgs("CurrentEopAna"));
            }
        }

        public EopAnaCollection EopAnaList
        {
            get { return eopAnaList; }
            set
            {
                if (eopAnaList == value)
                {
                    return;
                }
                eopAnaList = value;
                OnpropertyChanged(new PropertyChangedEventArgs("EopAnaList"));
            }
        }

        public ListCollectionView EopAnaListView
        {
            get { return eopAnaListView; }
            set
            {
                if (eopAnaListView == value)
                {
                    return;
                }
                eopAnaListView = value;
                OnpropertyChanged(new PropertyChangedEventArgs("EopAnaListView"));
            }
        }



        //Kad se unese neka vrijednost u TextBox za filter vrijednost biva prosljedjena u FilteringText
        public String FilteringText
        {
            get { return filteringText; }
            set
            {
                filteringText = value;
                OnpropertyChanged(new PropertyChangedEventArgs("FilteringText"));
            }
        }


        public String OperativniBrojText
        {
            get { return operativniBrojText; }
            set
            {
                operativniBrojText = value;
                OnpropertyChanged(new PropertyChangedEventArgs("OperativniBrojText"));
            }
        }

        #endregion

        #region Constructor

        public EopAnaViewModel()
        {

            this.PropertyChanged += EopAnaViewModel_PropertyChanged;

            EopAnaList = EopAnaCollection.GetAllEopAna();

            // ova klasa posjeduje svojstvo filter kojim je moguce definisati handler metodu koja obavlja filtriranje
            EopAnaListView = new ListCollectionView(EopAnaList);
            //postavljanje handler metode
            EopAnaListView.Filter = EopAnaFilter;

            CurrentEopAna = new EopAna();

        }

        private void EopAnaViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FilteringText"))
            {
                EopAnaListView.Refresh();

            }
        }

        private bool EopAnaFilter(object obj)
        {
            if (FilteringText == null) return true;
            if (FilteringText.Equals("")) return true;


            EopAna eopAna = obj as EopAna;
            return (eopAna.DATUM_UPLATE.StartsWith(FilteringText));
        }
        #endregion

        //iNovine

    }
}
