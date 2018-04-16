using PM_QLPM.Core;
using PM_QLPM.Model;
using PM_QLPM.View;
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
    public class View_ThemBenhNhan_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<HOSOBENHNHAN> DS_HoSo { get; set; }


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


        private HOSOBENHNHAN _selectedBenhNhan;
        public HOSOBENHNHAN SelectedBenhNhan
        {
            get { return _selectedBenhNhan; }
            set
            {
                if (value != _selectedBenhNhan)
                {
                    SetProperty(value, ref _selectedBenhNhan);
                    OnPropertyChanged("SelectedBenhNhan");
                }
            }
        }



        /// <summary>
        /// Ctor
        /// </summary>
        public View_ThemBenhNhan_ViewModel()
        {
            DS_HoSo = new ObservableCollection<HOSOBENHNHAN>();
            LoadDS_HoSo();
        }



        /// <summary>
        /// Load list of profiles from DB
        /// </summary>
        private void LoadDS_HoSo()
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                (from hs in dc.HOSOBENHNHANs
                 select hs).ToList().ForEach(x => DS_HoSo.Add(x));
            }
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_HoSo);
        }

        /// <summary>
        /// Save new data to DB
        /// </summary>
        /// <param name="hoso"></param>
        public void SaveNewHoSo(HOSOBENHNHAN hoso)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.HOSOBENHNHANs.InsertOnSubmit(hoso);
                dc.SubmitChanges();
            }
        }
    }
}

namespace PM_QLPM.Model
{
    public partial class HOSOBENHNHAN
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Ma_BenhNhan + " ");
            sb.Append(Hoten + " ");
            sb.Append(GioiTinh == true ? "Nam" : "Nữ");
            sb.Append(" " + NamSinh.ToShortDateString() + " ");
            sb.Append(DiaChi);
            return sb.ToString();
        }
    }
}
