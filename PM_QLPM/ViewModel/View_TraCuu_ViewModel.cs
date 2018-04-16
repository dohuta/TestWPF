using PM_QLPM.Core;
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
    public class View_TraCuu_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<RECORD> LookUpList { get; set; }


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


        private RECORD _selectedItem;
        public RECORD SelectedItem
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


        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value != _searchText)
                {
                    SetProperty(value, ref _searchText);
                    OnPropertyChanged("SearchText");
                }
            }
        }



        /// <summary>
        /// Constructor
        /// </summary>
        public View_TraCuu_ViewModel()
        {
            GetList();
        }



        /// <summary>
        /// Getting all the records from DB
        /// </summary>
        private void GetList()
        {
            LookUpList = new ObservableCollection<RECORD>();

            using (var dc = new QLPM_ModelDataContext())
            {
                (from pk in dc.PHIEUKHAMBENHs
                 join bn in dc.HOSOBENHNHANs on pk.Ma_BenhNhan equals bn.Ma_BenhNhan
                 join be in dc.BENHs on pk.Ma_Benh equals be.Ma_Benh
                 select new RECORD
                 {
                     Ma_BenhNhan = bn.Ma_BenhNhan,
                     HoTen = bn.Hoten,
                     NgayKham = pk.NgayKham,
                     TenBenh = be.TenBenh,
                     TrieuChung = pk.TrieuChung
                 }).ToList().ForEach(x => LookUpList.Add(x));

                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(LookUpList);
            }
        }

        /// <summary>
        /// Searching by multi-criteria
        /// </summary>
        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                GetList();
                return;
            }

            var criterias = SearchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < criterias.Length; i++)
            {
                criterias[i] = criterias[i].ToUpper();
            }

            ViewSource.Filter = item => string.IsNullOrWhiteSpace(SearchText) || item.ToString().ToUpper().ContainsAll(criterias);
            ViewSource.Refresh();
        }



        #region Unused methods
        private void GetResultByID(string maBenhNhan)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var query = (from pk in dc.PHIEUKHAMBENHs
                             join bn in dc.HOSOBENHNHANs on pk.Ma_BenhNhan equals bn.Ma_BenhNhan
                             join be in dc.BENHs on pk.Ma_Benh equals be.Ma_Benh
                             where pk.Ma_BenhNhan == maBenhNhan
                             select new
                             {
                                 pk.Ma_PhieuKham,
                                 bn.Ma_BenhNhan,
                                 bn.Hoten,
                                 pk.NgayKham,
                                 be.TenBenh,
                                 pk.TrieuChung
                             }).ToList();
                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(query);
            }
        }
        private void GetResultByName(string hoten)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var query = (from bn in dc.HOSOBENHNHANs
                             join pk in dc.PHIEUKHAMBENHs on bn.Ma_BenhNhan equals pk.Ma_BenhNhan
                             join be in dc.BENHs on pk.Ma_Benh equals be.Ma_Benh
                             where bn.Hoten == hoten
                             select new
                             {
                                 pk.Ma_PhieuKham,
                                 bn.Ma_BenhNhan,
                                 bn.Hoten,
                                 pk.NgayKham,
                                 be.TenBenh,
                                 pk.TrieuChung
                             }).ToList();
                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(query);
            }
        }
        private void GetResultByDate(DateTime ngayKham)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var query = (from pk in dc.PHIEUKHAMBENHs
                             join bn in dc.HOSOBENHNHANs on pk.Ma_BenhNhan equals bn.Ma_BenhNhan
                             join be in dc.BENHs on pk.Ma_Benh equals be.Ma_Benh
                             where pk.NgayKham == ngayKham
                             select new
                             {
                                 pk.Ma_PhieuKham,
                                 bn.Ma_BenhNhan,
                                 bn.Hoten,
                                 pk.NgayKham,
                                 be.TenBenh,
                                 pk.TrieuChung
                             }).ToList();
                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(query);
            }
        }
        private void GetResultByDisease(string tenBenh)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var query = (from pk in dc.PHIEUKHAMBENHs
                             join bn in dc.HOSOBENHNHANs on pk.Ma_BenhNhan equals bn.Ma_BenhNhan
                             join be in dc.BENHs on pk.Ma_Benh equals be.Ma_Benh
                             where be.TenBenh == tenBenh
                             select new
                             {
                                 pk.Ma_PhieuKham,
                                 bn.Ma_BenhNhan,
                                 bn.Hoten,
                                 pk.NgayKham,
                                 be.TenBenh,
                                 pk.TrieuChung
                             }).ToList();
                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(query);
            }
        }
        private void GetResultBySymtom(string trieuChung)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var query = (from pk in dc.PHIEUKHAMBENHs
                             join bn in dc.HOSOBENHNHANs on pk.Ma_BenhNhan equals bn.Ma_BenhNhan
                             join be in dc.BENHs on pk.Ma_Benh equals be.Ma_Benh
                             where pk.TrieuChung == trieuChung
                             select new
                             {
                                 pk.Ma_PhieuKham,
                                 bn.Ma_BenhNhan,
                                 bn.Hoten,
                                 pk.NgayKham,
                                 be.TenBenh,
                                 pk.TrieuChung
                             }).ToList();
                ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(query);
            }
        }

        #endregion



        private RelayCommand _cm_Search;
        public RelayCommand CM_Search => _cm_Search ?? (_cm_Search = new RelayCommand(parameter =>
                                                       {
                                                           Search();
                                                       }));


        private RelayCommand _cm_ItemClicked;
        public RelayCommand CM_ItemClicked => _cm_ItemClicked ?? (_cm_ItemClicked = new RelayCommand(parameter =>
                                                            {
                                                                if(SelectedItem != null)
                                                                {
                                                                    var detailWindow = new ChiTietTraCuuWindow()
                                                                                       { DataContext = new ChiTietTraCuuWindow_ViewModel(SelectedItem.Ma_BenhNhan) };
                                                                    detailWindow.ShowDialog();
                                                                }
                                                            }));

    }


    public partial class RECORD : PropertyChangedBase
    {
        private string   _ma_Benhnhan;
        private string   _hoTen;
        private DateTime _ngayKham;
        private string   _tenBenh;
        private string   _trieuChung;
        
        public string Ma_BenhNhan
        {
            get { return _ma_Benhnhan; }
            set
            {
                if (value != _ma_Benhnhan)
                {
                    SetProperty(value, ref _ma_Benhnhan);
                    OnPropertyChanged("Ma_BenhNhan");
                }
            }
        }
        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (value != _hoTen)
                {
                    SetProperty(value, ref _hoTen);
                    OnPropertyChanged("HoTen");
                }
            }
        }
        public DateTime NgayKham
        {
            get { return _ngayKham; }
            set
            {
                if (value != _ngayKham)
                {
                    SetProperty(value, ref _ngayKham);
                    OnPropertyChanged("NgayKham");
                }
            }
        }
        public string TenBenh
        {
            get { return _tenBenh; }
            set
            {
                if (value != _tenBenh)
                {
                    SetProperty(value, ref _tenBenh);
                    OnPropertyChanged("TenBenh");
                }
            }
        }
        public string TrieuChung
        {
            get { return _trieuChung; }
            set
            {
                if (value != _trieuChung)
                {
                    SetProperty(value, ref _trieuChung);
                    OnPropertyChanged("TrieuChung");
                }
            }
        }


        public RECORD()
        {
            //
        }


        public override string ToString()
        {
            return Ma_BenhNhan + " " + HoTen + " " + NgayKham.ToString() + " " + TenBenh + " " + TrieuChung;
        }
    }


    public static class StringExtension
    {
        public static bool ContainsAll(this string source, params string[] values)
        {
            return values.Any(x => source.Contains(x));
        }
    }
}
