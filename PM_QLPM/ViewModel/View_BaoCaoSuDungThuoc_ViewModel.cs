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
    public class View_BaoCaoSuDungThuoc_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<SUDUNGTHUOC> DS_DungThuoc { get; set; }
        public ObservableCollection<int> ListMonth1 { get; set; }
        public ObservableCollection<int> ListYear1 { get; set; }
        public bool CanGetReport
        {
            get
            {
                using (var dc = new QLPM_ModelDataContext())
                {
                    if (dc.HOADONs.Count() != 0)
                        return true;
                    else
                        return false;
                }
            }
        }


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


        private int _pickedMonth;
        public int PickedMonth1
        {
            get { return _pickedMonth; }
            set
            {
                if (value != _pickedMonth)
                {
                    SetProperty(value, ref _pickedMonth);
                    OnPropertyChanged("PickedMonth");
                }
            }
        }


        private int _pickedYear;
        public int PickedYear1
        {
            get { return _pickedYear; }
            set
            {
                if (value != _pickedYear)
                {
                    SetProperty(value, ref _pickedYear);
                    OnPropertyChanged("PickedYear");
                }
            }
        }



        public View_BaoCaoSuDungThuoc_ViewModel()
        {
            DS_DungThuoc = new ObservableCollection<SUDUNGTHUOC>();
            ListMonth1 = new ObservableCollection<int>();
            ListYear1 = new ObservableCollection<int>();
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_DungThuoc);
            LoadLists();
        }



        /// <summary>
        /// Load lists
        /// </summary>
        private void LoadLists()
        {
            if (CanGetReport)
            {
                ListMonth1.Clear();
                ListYear1.Clear();
                using (var dc = new QLPM_ModelDataContext())
                {
                    (from m in dc.CT_PHIEUKHAMBENHs
                     group m by m.PHIEUKHAMBENH.NgayKham.Month into g
                     select g.Key).ToList().ForEach(x => ListMonth1.Add(x));

                    (from m in dc.CT_PHIEUKHAMBENHs
                     group m by m.PHIEUKHAMBENH.NgayKham.Year into g
                     select g.Key).ToList().ForEach(x => ListYear1.Add(x));
                }
            }
        }

        /// <summary>
        /// Load report data from DB
        /// </summary>
        /// <param name="pickedMonth"></param>
        /// <param name="pickedYear"></param>
        /// <returns></returns>
        private bool LoadReport(int pickedMonth, int pickedYear)
        {
            DS_DungThuoc.Clear();

            using (var dc = new QLPM_ModelDataContext())
            {
                if (CanGetReport && PickedMonth1 > 0 && PickedYear1 > 0)
                {
                    (from pk in dc.CT_PHIEUKHAMBENHs
                     where pk.PHIEUKHAMBENH.NgayKham.Month == pickedMonth &&
                           pk.PHIEUKHAMBENH.NgayKham.Year == pickedYear
                     group pk by new { pk.THUOC.TenThuoc, pk.Ma_Thuoc } into g
                     select new SUDUNGTHUOC
                     {
                         Ma_Thuoc = g.Key.Ma_Thuoc,
                         TenThuoc = g.Key.TenThuoc,
                         SoLanDung = g.Count()
                     }).ToList().ForEach(x =>
                     {
                         x.SoLuong = dc.CT_PHIEUKHAMBENHs.Where(y => y.Ma_Thuoc == x.Ma_Thuoc).Sum(z => z.SoLuong);
                         x.TenDonVi = dc.THUOCs.Single(y => x.Ma_Thuoc == y.Ma_Thuoc).DONVI.TenDonVi;
                         DS_DungThuoc.Add(x);
                     });
                }
            }
            return DS_DungThuoc.Count != 0 ? true : false;
        }




        private RelayCommand _cm_ShowReportClicked;
        public RelayCommand CM_ShowReportClicked => _cm_ShowReportClicked ?? (_cm_ShowReportClicked = new RelayCommand(parameter =>
                                                                        {
                                                                            LoadReport(PickedMonth1, PickedYear1);
                                                                        }));


        private RelayCommand _cm_PrintReport;
        public RelayCommand CM_PrintReportClicked => _cm_PrintReport ?? (_cm_PrintReport = new RelayCommand(parameter =>
                                                                    {

                                                                    }));
    }

    public class SUDUNGTHUOC : PropertyChangedBase
    {
        private string _ma_Thuoc;
        private string _tenThuoc;
        private string _tenDonVi;
        private int _soLuong;
        private int _soLanDung;


        public string Ma_Thuoc
        {
            get { return _ma_Thuoc; }
            set
            {
                if (value != _ma_Thuoc)
                {
                    SetProperty(value, ref _ma_Thuoc);
                    OnPropertyChanged("Ma_Thuoc");
                }
            }
        }
        public string TenThuoc
        {
            get { return _tenThuoc; }
            set
            {
                if (value != _tenThuoc)
                {
                    SetProperty(value, ref _tenThuoc);
                    OnPropertyChanged("TenThuoc");
                }
            }

        }
        public string TenDonVi
        {
            get { return _tenDonVi; }
            set
            {
                if (value != _tenDonVi)
                {
                    SetProperty(value, ref _tenDonVi);
                    OnPropertyChanged("TenDonVi");
                }
            }
        }
        public int SoLuong
        {
            get { return _soLuong; }
            set
            {
                if (value != _soLuong)
                {
                    SetProperty(value, ref _soLuong);
                    OnPropertyChanged("SoLuong");
                }
            }
        }
        public int SoLanDung
        {
            get { return _soLanDung; }
            set
            {
                if (value != _soLanDung)
                {
                    SetProperty(value, ref _soLanDung);
                    OnPropertyChanged("SoLanDung");
                }
            }
        }


        public SUDUNGTHUOC()
        {
            //
        }
    }
}
