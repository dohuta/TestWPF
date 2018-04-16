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
    public class View_ThemSuaThuoc_ViewModel : PropertyChangedBase
    {
        public ObservableCollection<THUOC> DS_Thuoc { get; set; }
        public ObservableCollection<CACHDUNG> DS_CachDung { get; set; }


        private THUOC _pickedThuoc;
        public THUOC PickedThuoc
        {
            get { return _pickedThuoc; }
            set
            {
                if (value != _pickedThuoc)
                {
                    SetProperty(value, ref _pickedThuoc);
                    OnPropertyChanged("PickedThuoc");
                }
            }
        }


        private CT_DONTHUOC _thuoc;
        public CT_DONTHUOC Thuoc
        {
            get { return _thuoc; }
            set
            {
                if (value != _thuoc)
                {
                    SetProperty(value, ref _thuoc);
                    OnPropertyChanged("Thuoc");
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




        public View_ThemSuaThuoc_ViewModel()
        {
            PickedThuoc = new THUOC();
            Thuoc = new CT_DONTHUOC();
            DS_Thuoc = new ObservableCollection<THUOC>();
            DS_CachDung = new ObservableCollection<CACHDUNG>();
            ViewSource = (CollectionView)CollectionViewSource.GetDefaultView(DS_Thuoc);
            LoadLists();
        }



        private void LoadLists()
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                dc.THUOCs.Select(x => x).ToList().ForEach(x => DS_Thuoc.Add(x));
                dc.CACHDUNGs.Select(x => x).ToList().ForEach(x => DS_CachDung.Add(x));
            }
            ViewSource.Refresh();
        }
    }
}
namespace PM_QLPM.Model
{ 
    public partial class THUOC
    {
        public override string ToString()
        {
            return Ma_Thuoc + " " + TenThuoc;
        }
    }
}
