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
    public class View_PhieuKhamBenh_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<PHIEUKHAM> DS_PhieuKham { get; set; }
        public ObservableCollection<BENH> DS_Benh { get; set; }


        private PHIEUKHAM _selectedItem;
        public PHIEUKHAM SelectedItem
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
                

        /*   This is using for getting the view of DS_PhieuKham   */
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
                


        /// <summary>
        /// Ctor for main view called from MainWindow
        /// </summary>
        public View_PhieuKhamBenh_ViewModel()
        {
            DS_PhieuKham = new ObservableCollection<PHIEUKHAM>();
            DS_Benh = new ObservableCollection<BENH>();
            ReadDiseases();
            ReadList(DateTime.Today);
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_PhieuKham);
        }

        /// <summary>
        /// Ctor for sub view called from TraCuu.SelectedItem
        /// </summary>
        /// <param name="ma_BenhNhan"></param>
        public View_PhieuKhamBenh_ViewModel(string ma_BenhNhan)
        {
            DS_PhieuKham = new ObservableCollection<PHIEUKHAM>();
            DS_Benh = new ObservableCollection<BENH>();
            ReadDiseases();
            ReadList(ma_BenhNhan);
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_PhieuKham);
        }
        


        /// <summary>
        /// Getting diseases from DB
        /// </summary>
        private void ReadDiseases()
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                (from b in dc.BENHs
                 select b).ToList().ForEach(x =>
                 {
                     DS_Benh.Add(x);
                 });
            }
        }

        /// <summary>
        /// Getting data from DB, criteria: date.today
        /// </summary>
        /// <returns></returns>
        private void ReadList(DateTime datePicked)
        {
            DS_PhieuKham.Clear();
            // Getting data from DB (if exists)
            using (var dc = new QLPM_ModelDataContext())
            {
                (from pk in dc.PHIEUKHAMBENHs
                 where pk.NgayKham == datePicked
                 select pk).ToList().ForEach(x => DS_PhieuKham.Add((PHIEUKHAM)x));
            }
        }

        /// <summary>
        /// Getting data from DB, criteria: maBenhNhan
        /// </summary>
        /// <param name="maBenhNhan"></param>
        private void ReadList(string maBenhNhan)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                (from pk in dc.PHIEUKHAMBENHs
                 where pk.Ma_BenhNhan == maBenhNhan
                 select pk).ToList().ForEach(x => DS_PhieuKham.Add((PHIEUKHAM)x));
            }
        }



        private void AddPill(CT_DONTHUOC thuoc)
        {
            //await Task.Run(() => Helper.AddPill((CT_PHIEUKHAMBENH)thuoc));
            SelectedItem.DONTHUOC.Add(thuoc);
            SelectedItem.ViewSource.Refresh();
        }

        private void RemovePill(CT_DONTHUOC thuoc)
        {
            //await Task.Run(() => Helper.RemovePill((CT_PHIEUKHAMBENH)thuoc));
            SelectedItem.DONTHUOC.Remove(thuoc);
            SelectedItem.ViewSource.Refresh();
        }


        private RelayCommand _cm_GetList;
        public RelayCommand CM_GetList => _cm_GetList ?? (_cm_GetList = new RelayCommand(parameter =>
                                                      {
                                                          ReadList(DateTime.Today);
                                                      }));


        private RelayCommand _cm_SaveClicked;
        public RelayCommand CM_SaveClicked => _cm_SaveClicked ?? (_cm_SaveClicked = new RelayCommand(async parameter =>
                                                            {
                                                                // Save | Update data to PHIEUKHAMBENH table
                                                                await Task.Run(() =>
                                                                {
                                                                    using (var dc = new QLPM_ModelDataContext())
                                                                    {
                                                                        var query = dc.PHIEUKHAMBENHs.Single(pk => pk.Ma_PhieuKham == SelectedItem.Ma_PhieuKham);
                                                                        query.Ma_Benh = SelectedItem.Ma_Benh;
                                                                        query.TrieuChung = SelectedItem.TrieuChung;

                                                                        dc.SubmitChanges();
                                                                    }
                                                                });

                                                                // Remove all old data and re-insert the new ones in CT_PHIEUKHAMBENH
                                                                await Task.Run(() =>
                                                                {
                                                                    using (var dc = new QLPM_ModelDataContext())
                                                                    {
                                                                        dc.CT_PHIEUKHAMBENHs.DeleteAllOnSubmit((from ct in dc.CT_PHIEUKHAMBENHs
                                                                                                                where ct.Ma_PhieuKham == SelectedItem.Ma_PhieuKham
                                                                                                                select ct).ToList());

                                                                        foreach (var item in SelectedItem.DONTHUOC)
                                                                        {
                                                                            dc.CT_PHIEUKHAMBENHs.InsertOnSubmit((CT_PHIEUKHAMBENH)item);
                                                                        }
                                                                        dc.SubmitChanges();
                                                                    }
                                                                });

                                                                Helper.AddHoaDon(SelectedItem);

                                                                SelectedItem.IsSaved = false;
                                                            }));


        private RelayCommand _cm_PrintClicked;
        public RelayCommand CM_PrintClicked => _cm_PrintClicked ?? (_cm_PrintClicked = new RelayCommand(parameter =>
                                                             {

                                                             }));


        private RelayCommand _cm_MorePillClicked;
        public RelayCommand CM_MorePillClicked => _cm_MorePillClicked ?? (_cm_MorePillClicked = new RelayCommand(async parameter =>
                                                                {
                                                                    var addPillWindow = new View_ThemSuaThuoc();
                                                                    var addedPill = new CT_DONTHUOC();

                                                                    if(addPillWindow.ShowDialog() == true)
                                                                    {
                                                                        addedPill = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).Thuoc;
                                                                        using (var dc = new QLPM_ModelDataContext())
                                                                        {
                                                                            addedPill.Ma_PhieuKham = SelectedItem.Ma_PhieuKham;
                                                                            addedPill.Ma_Thuoc     = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.Ma_Thuoc;
                                                                            addedPill.TenThuoc     = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.TenThuoc;
                                                                            addedPill.TenCachDung  = dc.CACHDUNGs.Single(x => x.Ma_CachDung == addedPill.Ma_CachDung).TenCachDung;
                                                                            addedPill.DonGia       = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.DonGia;
                                                                            addedPill.Ma_DonVi     = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.Ma_DonVi;
                                                                            addedPill.TenDonVi     = dc.THUOCs.Single(x => x.Ma_Thuoc == addedPill.Ma_Thuoc).DONVI.TenDonVi;
                                                                        }
                                                                    }

                                                                    if(addedPill.Ma_Thuoc!= null)
                                                                    {
                                                                        if (SelectedItem.DONTHUOC.Any(x => x.Ma_Thuoc == addedPill.Ma_Thuoc))
                                                                        {
                                                                            var dialog = new MessageDialog()
                                                                            {
                                                                                DataContext = new MessageDialog_ViewModel("Danh sách đã tồn tại thuốc này!")
                                                                            };
                                                                            await DialogHost.Show(dialog, "RootDialog");
                                                                            return;
                                                                        }
                                                                        AddPill(addedPill);
                                                                    }
                                                                }));


        private RelayCommand _cm_EditPill;
        public RelayCommand CM_EditPill => _cm_EditPill ?? (_cm_EditPill = new RelayCommand(async parameter =>
                                                         {
                                                             var pill = (CT_DONTHUOC)parameter;
                                                             var newPill = new CT_DONTHUOC();
                                                             var addPillWindow = new View_ThemSuaThuoc();
                                                             using (var dc = new QLPM_ModelDataContext())
                                                             {
                                                                 ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).Thuoc = pill;
                                                                 ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc = dc.THUOCs.Single(x => x.Ma_Thuoc == pill.Ma_Thuoc);

                                                                 if (addPillWindow.ShowDialog() == true)
                                                                 {
                                                                     newPill = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).Thuoc;

                                                                     newPill.Ma_PhieuKham = SelectedItem.Ma_PhieuKham;
                                                                     newPill.Ma_Thuoc = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.Ma_Thuoc;
                                                                     newPill.TenThuoc = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.TenThuoc;
                                                                     newPill.TenCachDung = dc.CACHDUNGs.Single(x => x.Ma_CachDung == newPill.Ma_CachDung).TenCachDung;
                                                                     newPill.DonGia = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.DonGia;
                                                                     newPill.Ma_DonVi = ((View_ThemSuaThuoc_ViewModel)addPillWindow.DataContext).PickedThuoc.Ma_DonVi;
                                                                     newPill.TenDonVi = dc.THUOCs.Single(x => x.Ma_Thuoc == newPill.Ma_Thuoc).DONVI.TenDonVi;
                                                                 }
                                                             }
                                                             if (newPill.Ma_Thuoc != null)
                                                             {
                                                                 if(newPill.Ma_Thuoc != pill.Ma_Thuoc)
                                                                 {
                                                                     if (SelectedItem.DONTHUOC.Any(x => x.Ma_Thuoc == newPill.Ma_Thuoc))
                                                                     {
                                                                         var dialog = new MessageDialog()
                                                                         {
                                                                             DataContext = new MessageDialog_ViewModel("Danh sách đã tồn tại thuốc này!")
                                                                         };
                                                                         await DialogHost.Show(dialog, "RootDialog");
                                                                         return;
                                                                     }
                                                                 }
                                                                 
                                                                 RemovePill(pill);
                                                                 AddPill(newPill);
                                                             }
                                                         }));


        private RelayCommand _cm_DeletePillClicked;
        public RelayCommand CM_DeletePillClicked => _cm_DeletePillClicked ?? (_cm_DeletePillClicked = new RelayCommand(parameter =>
                                                                  {
                                                                      if (parameter != null)
                                                                      {
                                                                          var ctpk = (CT_DONTHUOC)parameter;
                                                                          RemovePill(ctpk);
                                                                      }
                                                                  }));

    }
}
