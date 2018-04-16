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
    public class View_HoaDon_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<CTHOADON> DS_HoaDon { get; set; }


        private CTHOADON _selectedIten;
        public CTHOADON SelectedItem
        {
            get { return _selectedIten; }
            set
            {
                if (value != _selectedIten)
                {
                    SetProperty(value, ref _selectedIten);
                    OnPropertyChanged("SelectedItem");
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

        

        public View_HoaDon_ViewModel()
        {
            DS_HoaDon = new ObservableCollection<CTHOADON>();
            GetBills();
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_HoaDon);
        }



        private void GetBills()
        {
            DS_HoaDon.Clear();

            using (var dc = new QLPM_ModelDataContext())
            {
                (from hd in dc.HOADONs
                 where hd.PHIEUKHAMBENH.NgayKham == DateTime.Today
                 select hd).ToList().ForEach(x => DS_HoaDon.Add((CTHOADON)x));
            }
        }


        private RelayCommand _cm_GetBills;
        public RelayCommand CM_GetBills => _cm_GetBills ?? (_cm_GetBills = new RelayCommand(parameter =>
                                                      {
                                                          GetBills();
                                                      }));


        private RelayCommand _cm_SaveClicked;
        public RelayCommand CM_SaveClicked => _cm_SaveClicked ?? (_cm_SaveClicked = new RelayCommand(parameter =>
                                                            {
                                                                using (var dc = new QLPM_ModelDataContext())
                                                                {
                                                                    dc.HOADONs.Single(hd => hd.Ma_HoaDon == SelectedItem.Ma_HoaDon).GhiChu = SelectedItem.GhiChu;
                                                                    dc.SubmitChanges();
                                                                }
                                                                SelectedItem.IsSaved = false;
                                                            }));

    }


    public class CTHOADON : PropertyChangedBase
    {
        private string _ma_HoaDon;
        private string _ma_PhieuKham;
        private string _ma_BenhNhan;
        private string _hoTen;
        private decimal _tienKham;
        private decimal _tienThuoc;
        private string _ghiChu;
        private DateTime _ngayKham;

        public string  Ma_HoaDon   
        {
            get { return _ma_HoaDon; }
            set
            {
                if (value != _ma_HoaDon)
                {
                    SetProperty(value, ref _ma_HoaDon);
                    OnPropertyChanged("Ma_HoadDon");
                }
            }
        }
        public string  Ma_PhieuKham 
        {
            get { return _ma_PhieuKham; }
            set
            {
                if (value != _ma_PhieuKham)
                {
                    SetProperty(value, ref _ma_PhieuKham);
                    OnPropertyChanged("Ma_PhieuKham");
                }
            }
        }
        public string  Ma_BenhNhan  
        {
            get { return _ma_BenhNhan; }
            set
            {
                if (value != _ma_BenhNhan)
                {
                    SetProperty(value, ref _ma_BenhNhan);
                    OnPropertyChanged("Ma_BenhNhan");
                }
            }
        }
        public string  HoTen        
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
        public decimal TienKham     
        {
            get { return _tienKham; }
            set
            {
                if (value != _tienKham)
                {
                    SetProperty(value, ref _tienKham);
                    OnPropertyChanged("TienKham");
                }
            }
        }
        public decimal TienThuoc    
        {
            get { return _tienThuoc; }
            set
            {
                if (value != _tienThuoc)
                {
                    SetProperty(value, ref _tienThuoc);
                    OnPropertyChanged("TienThuoc");
                }
            }
        }
        public string  GhiChu       
        {
            get { return _ghiChu; }
            set
            {
                if (value != _ghiChu)
                {
                    SetProperty(value, ref _ghiChu);
                    OnPropertyChanged("GhiChu");
                    IsSaved = true;
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
                    IsSaved = true;
                }
            }
        }
        
        private bool _isSaved;
        public bool IsSaved
        {
            get { return _isSaved; }
            set
            {
                if (value != _isSaved)
                {
                    SetProperty(value, ref _isSaved);
                    OnPropertyChanged("IsSaved");
                }
            }
        }



        /// <summary>
        /// Ctor
        /// </summary>
        public CTHOADON()
        {

        }



        /// <summary>
        /// Casting HOADON type to CTHOADON
        /// </summary>
        /// <param name="hd"></param>
        public static explicit operator CTHOADON(HOADON hd)
        {
            var cthd = new CTHOADON
            {
                Ma_HoaDon    = hd.Ma_HoaDon,
                Ma_PhieuKham = hd.Ma_PhieuKham,
                Ma_BenhNhan  = hd.PHIEUKHAMBENH.Ma_BenhNhan,
                HoTen        = hd.PHIEUKHAMBENH.HOSOBENHNHAN.Hoten,
                TienKham     = hd.TienKham,
                TienThuoc    = hd.TienThuoc,
                GhiChu       = hd.GhiChu,
                NgayKham     = hd.PHIEUKHAMBENH.NgayKham
            };
            return cthd;
        }

        /// <summary>
        /// Casting CTHOADON type to HOADON
        /// </summary>
        /// <param name="cthd"></param>
        public static implicit operator HOADON(CTHOADON cthd)
        {
            var hd = new HOADON
            {
                Ma_HoaDon = cthd.Ma_HoaDon,
                Ma_PhieuKham = cthd.Ma_PhieuKham,
                TienKham = cthd.TienKham,
                TienThuoc = cthd.TienThuoc,
                GhiChu = cthd.GhiChu
            };
            return hd;
        }

        public override string ToString()
        {
            return Ma_HoaDon + " " + Ma_BenhNhan + " " + HoTen + " " + TienKham.ToString() + " " + TienThuoc + " " + GhiChu;
        }
    }
}
