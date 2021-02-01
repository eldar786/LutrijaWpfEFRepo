using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LutrijaWpfEF.ViewModel
{
    public class GrKomViewModel : ObservableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnpropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


        #region Polja

        private GrKomCollection grKomList;
        private ListCollectionView grKomListView;

        private string filteringText;

        #endregion


        #region Properties

        public GrKomCollection GrKomList
        {
            get { return grKomList; }
            set
            {
                if (grKomList == value)
                {
                    return;
                }
                grKomList = value;
                OnpropertyChanged(new PropertyChangedEventArgs("GrKomList"));
            }
        }

        public ListCollectionView GrKomListView
        {
            get { return grKomListView; }
            set
            {
                if (grKomListView == value)
                {
                    return;
                }
                grKomListView = value;
                OnpropertyChanged(new PropertyChangedEventArgs("GrKomListView"));
            }
        }

        #endregion

        #region Constructor

        public GrKomViewModel() 
        {
            GrKomList = GrKomCollection.GetAllGrKom();
            GrKomListView = new ListCollectionView(GrKomList);
        }

        #endregion
    }
}
