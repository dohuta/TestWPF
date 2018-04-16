using PM_QLPM.Core;
using PM_QLPM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PM_QLPM.ViewModel
{
    public class View_AccountManagement_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<NHANVIEN> DS_NV { get; set; }


        private ICollectionView viewSource;
        public ICollectionView ViewSource
        {
            get { return viewSource; }
            set
            {
                if (value != viewSource)
                {
                    SetProperty(value, ref viewSource);
                    OnPropertyChanged("ViewSource");
                }
            }
        }


        private NHANVIEN _selectedItem;
        public NHANVIEN SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    SetProperty(value, ref _selectedItem);
                    OnPropertyChanged("SelectedItem");
                }
            }
        }



        public View_AccountManagement_ViewModel()
        {
            DS_NV = new ObservableCollection<NHANVIEN>();
            GetData();
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_NV);
        }


        /// <summary>
        /// Getting data from DB
        /// </summary>
        private void GetData()
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.NHANVIENs.Select(x => x).ToList().ForEach(x => DS_NV.Add(x));
            }
        }

        /// <summary>
        /// Saving a new NV to DB
        /// </summary>
        /// <param name="nv"></param>
        public void SaveNewNV(NHANVIEN nv)
        {
            using(var dc = new QLPM_ModelDataContext())
            {
                dc.NHANVIENs.InsertOnSubmit(nv);
                dc.SubmitChanges();
            }
        }
        



        private RelayCommand _cm_RemoveClicked;
        public RelayCommand CM_RemoveClicked => _cm_RemoveClicked ?? (_cm_RemoveClicked = new RelayCommand(parameter =>
                                                              {
                                                                  using (var dc = new QLPM_ModelDataContext())
                                                                  {
                                                                      dc.NHANVIENs.DeleteOnSubmit(dc.NHANVIENs.Single(x => x.Ma_NV == SelectedItem.Ma_NV));
                                                                      dc.SubmitChanges();

                                                                      DS_NV.Remove(SelectedItem);
                                                                      ViewSource.Refresh();
                                                                  }
                                                              }));

    }
}
