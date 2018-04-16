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
    public class View_BaoCaoDoanhThu_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<DOANHTHUNGAY> DS_DoanhThu { get; set; }
        public ObservableCollection<int> ListMonth { get; set; }
        public ObservableCollection<int> ListYear { get; set; }
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
        public int PickedMonth
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
        public int PickedYear
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



        public View_BaoCaoDoanhThu_ViewModel()
        {
            DS_DoanhThu = new ObservableCollection<DOANHTHUNGAY>();
            ListMonth = new ObservableCollection<int>();
            ListYear = new ObservableCollection<int>();
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_DoanhThu);
            LoadLists();
        }


        /// <summary>
        /// Load lists
        /// </summary>
        private void LoadLists()
        {
            if (CanGetReport)
            {
                ListMonth.Clear();
                ListYear.Clear();
                using (var dc = new QLPM_ModelDataContext())
                {
                    (from m in dc.HOADONs
                     group m by m.PHIEUKHAMBENH.NgayKham.Month into g
                     select g.Key).ToList().ForEach(x => ListMonth.Add(x));

                    (from m in dc.HOADONs
                     group m by m.PHIEUKHAMBENH.NgayKham.Year into g
                     select g.Key).ToList().ForEach(x => ListYear.Add(x));
                }
            }
        }

        /// <summary>
        /// Load report data from DB
        /// </summary>
        /// <param name="pickedMonth"></param>
        /// <param name="pickedYear"></param>
        private bool LoadReport(int pickedMonth, int pickedYear)
        {
            DS_DoanhThu.Clear();

            using (var dc = new QLPM_ModelDataContext())
            {
                if(CanGetReport && PickedMonth > 0 && PickedYear > 0)
                {
                    var total = (from hd in dc.HOADONs
                                 where hd.PHIEUKHAMBENH.NgayKham.Month == pickedMonth &&
                                       hd.PHIEUKHAMBENH.NgayKham.Year == pickedYear
                                 select hd).Sum(x => x.TienKham + x.TienThuoc);

                    (from hd in dc.HOADONs
                     where hd.PHIEUKHAMBENH.NgayKham.Month == pickedMonth &&
                           hd.PHIEUKHAMBENH.NgayKham.Year == pickedYear
                     group hd by hd.PHIEUKHAMBENH.NgayKham into g
                     select new DOANHTHUNGAY
                     {
                         Ngay = g.Key,
                         SoBenhNhan = g.Count(),
                         DoanhThu = g.Sum(i => i.TienKham + i.TienThuoc)
                     }).ToList().ForEach(x => {
                         x.TiLe = Math.Round((double)(x.DoanhThu / total) * 100, 1);
                         DS_DoanhThu.Add(x);
                     });
                }                
            }
            return DS_DoanhThu.Count != 0 ? true : false;
        }




        private RelayCommand _cm_ShowReportClicked;
        public RelayCommand CM_ShowReportClicked => _cm_ShowReportClicked ?? (_cm_ShowReportClicked = new RelayCommand(parameter =>
                                                                        {
                                                                            LoadReport(PickedMonth, PickedYear);
                                                                        }));


        private RelayCommand _cm_PrintReport;
        public RelayCommand CM_PrintReportClicked => _cm_PrintReport ?? (_cm_PrintReport = new RelayCommand(parameter =>
                                                                    {

                                                                    }));

    }

    public class DOANHTHUNGAY : PropertyChangedBase
    {
        private DateTime _ngay;
        private int _soBenhNhan;
        private decimal _doanhThu;
        private double _tiLe;


        public DateTime Ngay
        {
            get { return _ngay; }
            set
            {
                if (value != _ngay)
                {
                    SetProperty(value, ref _ngay);
                    OnPropertyChanged("Ngay");
                }
            }
        }
        public int SoBenhNhan
        {
            get { return _soBenhNhan; }
            set
            {
                if (value != _soBenhNhan)
                {
                    SetProperty(value, ref _soBenhNhan);
                    OnPropertyChanged("SoBenhNhan");
                }
            }
        }
        public decimal DoanhThu
        {
            get { return _doanhThu; }
            set
            {
                if (value != _doanhThu)
                {
                    SetProperty(value, ref _doanhThu);
                    OnPropertyChanged("DoanhThu");
                }
            }
        }
        public double TiLe
        {
            get { return _tiLe; }
            set
            {
                if (value != _tiLe)
                {
                    SetProperty(value, ref _tiLe);
                    OnPropertyChanged("TiLe");
                }
            }
        }


        public DOANHTHUNGAY()
        {
            //
        }
    }
}
