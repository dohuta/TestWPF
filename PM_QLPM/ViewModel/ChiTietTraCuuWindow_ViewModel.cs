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
    public class ChiTietTraCuuWindow_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<CTTRACUU> DS_PhieuKham { get; set; }


        private ICollectionView _viewSource;
        public ICollectionView ViewSource
        {
            get { return _viewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_PhieuKham); }
        }


        private CTTRACUU _selectedItem;
        public CTTRACUU SelectedItem
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




        public ChiTietTraCuuWindow_ViewModel()
        {
            DS_PhieuKham = new ObservableCollection<CTTRACUU>();
        }

        public ChiTietTraCuuWindow_ViewModel(string maBenhNhan)
        {
            DS_PhieuKham = new ObservableCollection<CTTRACUU>();
            GetData(maBenhNhan);
        }




        /// <summary>
        /// Load Data from DB
        /// </summary>
        /// <param name="maBenhNhan"></param>
        private void GetData(string maBenhNhan)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.PHIEUKHAMBENHs.Where(x => x.Ma_BenhNhan == maBenhNhan).ToList().ForEach(x =>
                {
                    DS_PhieuKham.Add(new CTTRACUU()
                    {
                        PhieuKham = (PHIEUKHAM)x,
                        HoaDon = (CTHOADON)(x.HOADONs.Single(y => y.Ma_PhieuKham == x.Ma_PhieuKham))
                    });
                });
            }
        }


    }

    public class CTTRACUU : PropertyChangedBase
    {
        private PHIEUKHAM _phieuKham;
        public PHIEUKHAM PhieuKham
        {
            get { return _phieuKham; }
            set
            {
                if (value != _phieuKham)
                {
                    SetProperty(value, ref _phieuKham);
                    OnPropertyChanged("PhieuKham");
                }
            }
        }

        private CTHOADON _hoaDon;
        public CTHOADON HoaDon
        {
            get { return _hoaDon; }
            set
            {
                if (value != _hoaDon)
                {
                    SetProperty(value, ref _hoaDon);
                    OnPropertyChanged("HoaDon");
                }
            }
        }


        public CTTRACUU()
        {
            //
        }
    }
}
