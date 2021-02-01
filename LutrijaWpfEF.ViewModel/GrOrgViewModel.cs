using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace LutrijaWpfEF.ViewModel
{
    public class GrOrgViewModel : ObservableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnpropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


        #region Polja
        private GrOrg currentGrOrg;
        private GrOrgCollection grOrgList;
        private ListCollectionView grOrgListView;

        private string filteringText;

        #endregion

        #region Properties


        public GrOrg CurrentGrOrg
        {
            get { return currentGrOrg; }
            set
            {
                if (currentGrOrg == value)
                {
                    return;
                }
                currentGrOrg = value;
                OnpropertyChanged(new PropertyChangedEventArgs("CurrentEopAna"));
            }
        }

        public GrOrgCollection GrOrgList
        {
            get { return grOrgList; }
            set
            {
                if (grOrgList == value)
                {
                    return;
                }
                grOrgList = value;
                OnpropertyChanged(new PropertyChangedEventArgs("GrOrgList"));
            }
        }

        

        public ListCollectionView GrOrgListView
        {
            get { return grOrgListView; }
            set
            {
                if (grOrgListView == value)
                {
                    return;
                }
                grOrgListView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("GrOrgListView"));
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public String FilteringText
        {
            get { return filteringText; }
            set
            {
                filteringText = value;
                OnpropertyChanged(new PropertyChangedEventArgs("FilteringText"));
            }
        }


        #endregion

        #region Constructor

        public GrOrgViewModel()
        {
            this.PropertyChanged += GrOrgViewModel_PropertyChanged;

            GrOrgList = GrOrgCollection.GetAllGrOrg();

            GrOrgListView = new ListCollectionView(GrOrgList);

            GrOrgListView.Filter = GrOrgFilter;
        }

        private bool GrOrgFilter(object obj)
        {
            if (FilteringText == null) return true;
            if (FilteringText.Equals("")) return true;

            GrOrg grOrg = obj as GrOrg;
            return (grOrg.NAZIV.StartsWith(FilteringText));

        }
        #endregion

        private void GrOrgViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FilteringText"))
            {
                GrOrgListView.Refresh();
            }
        }
    }
}
