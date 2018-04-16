using MaterialDesignThemes.Wpf;
using PM_QLPM.Core;
using PM_QLPM.Dialog;
using PM_QLPM.Model;
using PM_QLPM.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PM_QLPM.ViewModel
{
        

    public class View_DSKhamBenh_ViewModel : PropertyChangedBase
    {
        /*   This is using to managing a list of BENHNHAN   */
        public ObservableCollection<BENHNHAN> DS_KhamBenh { get; set; }

        /*   This is using for view   */
        private ICollectionView _viewSource;
        public ICollectionView ViewSource
        {
            get { return _viewSource; }
            set
            {
                if (value != _viewSource)
                {
                    SetProperty(value, ref _viewSource);
                    OnPropertyChanged("ViewSource");
                }
            }
        }

        /*   This is using for searching (a) row(s) in datagrid   */
        private string _searcher;
        public string Searcher
        {
            get { return _searcher; }
            set
            {
                if (SetProperty(value, ref _searcher))
                {
                    ViewSource.Filter = item => string.IsNullOrWhiteSpace(Searcher) || item.ToString().ToUpper().Contains(Searcher.ToUpper());

                    ViewSource.Refresh();
                }
            }
        }

        /*   This is using for getting a list of patients depends on picked date   */
        private DateTime _datePicked;
        public DateTime DatePicked
        {
            get { return _datePicked; }
            set
            {
                if (value != _datePicked)
                {
                    SetProperty(value, ref _datePicked);
                    OnPropertyChanged("DatePicked");

                    ReadList(_datePicked);
                    ViewSource.Refresh();
                }
            }
        }

        /*   This is using to check all object is selected or not   */
        private bool _isAllSelected;
        public bool IsAllSelected
        {
            get { return _isAllSelected; }
            set
            {
                if (value != _isAllSelected)
                {
                    SetProperty(value, ref _isAllSelected);
                    OnPropertyChanged("IsAllSelected");

                    Parallel.ForEach(DS_KhamBenh, x =>
                    {
                        x.IsSelected = _isAllSelected;
                    });

                    ViewSource.Refresh();
                }
            }
        }




        public View_DSKhamBenh_ViewModel()
        {
            DS_KhamBenh = new ObservableCollection<BENHNHAN>();
            DatePicked = DateTime.Today;
            ReadList(DatePicked);
        }

        public View_DSKhamBenh_ViewModel(ObservableCollection<BENHNHAN> ds_KhamBenh, DateTime pickedDate)
        {
            DS_KhamBenh = ds_KhamBenh;
            DatePicked = pickedDate;
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_KhamBenh);
        }



        /// <summary>
        /// Getting data from DB
        /// </summary>
        /// <returns></returns>
        private void ReadList(DateTime datePicked)
        {
            if(DS_KhamBenh.Count == 0)
            {
                // Getting data from DB (if exists)
                using (var dc = new QLPM_ModelDataContext())
                {
                    var query = (from pk in dc.PHIEUKHAMBENHs
                                 where pk.NgayKham == datePicked
                                 select pk.Ma_BenhNhan).ToList();
                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            DS_KhamBenh.Add((BENHNHAN)(from bn in dc.HOSOBENHNHANs
                                                       where bn.Ma_BenhNhan == item
                                                       select bn).FirstOrDefault());
                        }
                    }
                }
                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_KhamBenh);
            }
            else
            {
                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_KhamBenh);
            }
        }

        /// <summary>
        /// Add a new benhnhan object to list, DB and refresh the view
        /// </summary>
        /// <param name="bn"></param>
        public async Task Add(BENHNHAN bn)
        {
            //await Task.Run(() => Helper.AddBenhNhan(bn));
            await Task.Run(() => Helper.AddPhieuKham(bn));
            DS_KhamBenh.Add(bn);
            ViewSource.Refresh();
        }

        /// <summary>
        /// Remove a benhnhan object from list, DB and refresh the view
        /// </summary>
        /// <param name="bn"></param>
        public async Task Remove(BENHNHAN bn)
        {
            //await Task.Run(() => Helper.RemoveBenhNhan(bn));
            await Task.Run(() => Helper.RemovePhieuKham(bn));
            DS_KhamBenh.Remove(bn);
            ViewSource.Refresh();
        }




        private RelayCommand _cm_AddClicked;
        public RelayCommand CM_AddClicked => _cm_AddClicked ?? (_cm_AddClicked = new RelayCommand(async parameter =>
                                                           {
                                                               var addPatientWindow = new View_ThemBenhNhan();
                                                               var addedPatient = new BENHNHAN();
                                                               if(addPatientWindow.ShowDialog() == true)
                                                               {
                                                                   addedPatient = (BENHNHAN)((View_ThemBenhNhan_ViewModel)addPatientWindow.DataContext).SelectedBenhNhan;
                                                               }
                                                               if (addedPatient.Ma_BenhNhan != null)
                                                               {
                                                                   if (DS_KhamBenh.Any(x => x.Ma_BenhNhan == addedPatient.Ma_BenhNhan))
                                                                   {
                                                                       var dialog = new MessageDialog()
                                                                       {
                                                                           DataContext = new MessageDialog_ViewModel("Danh sách đã tồn tại bệnh nhân này")
                                                                       };
                                                                       await DialogHost.Show(dialog, "RootDialog");
                                                                       return;
                                                                   }

                                                                   await Add(addedPatient);
                                                               }
                                                           }));

        private RelayCommand _cm_DeleteClicked;
        public RelayCommand CM_DeleteClicked => _cm_DeleteClicked ?? (_cm_DeleteClicked = new RelayCommand(async parameter =>
                                                              {
                                                                  var needToBeRemoved_Patients = ((IList)parameter).Cast<BENHNHAN>().ToList();

                                                                  if (needToBeRemoved_Patients.Count == 0) return;

                                                                  foreach (var item in needToBeRemoved_Patients)
                                                                  {
                                                                      await Remove(item);
                                                                  }

                                                                  ViewSource.Refresh();
                                                              }));

        private RelayCommand _cm_PrintClicked;
        public RelayCommand CM_PrintClicked => _cm_PrintClicked ?? (_cm_PrintClicked = new RelayCommand(parameter =>
                                                             {

                                                             }));

    }
}
