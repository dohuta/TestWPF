using PM_QLPM.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PM_QLPM.Model
{   
    public class PHIEUKHAM : PropertyChangedBase
    {
        private string _ma_PhieuKham;
        private string _ma_BenhNhan;
        private string _hoTen;
        private DateTime _ngayKham;
        private string _trieuChung;
        private string _ma_Benh;
        private bool _gioiTinh;


        public string Ma_PhieuKham
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
        public string Ma_BenhNhan
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
        public string TrieuChung
        {
            get { return _trieuChung; }
            set
            {
                if (value != _trieuChung)
                {
                    SetProperty(value, ref _trieuChung);
                    OnPropertyChanged("TrieuChung");
                    IsSaved = true;
                }
            }
        }
        public string Ma_Benh
        {
            get { return _ma_Benh; }
            set
            {
                if (value != _ma_Benh)
                {
                    SetProperty(value, ref _ma_Benh);
                    OnPropertyChanged("Ma_Benh");
                    IsSaved = true;
                }
            }
        }
        public bool GioiTinh
        {
            get { return _gioiTinh; }
            set
            {
                if (value != _gioiTinh)
                {
                    SetProperty(value, ref _gioiTinh);
                    OnPropertyChanged("GioiTinh");
                }
            }
        }
        

        private ObservableCollection<CT_DONTHUOC> _donthuoc;
        public ObservableCollection<CT_DONTHUOC> DONTHUOC
        {
            get { return _donthuoc; }
            set
            {
                _donthuoc = value;
                IsSaved = true;
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
        

        private ICollectionView _viewSource;
        public ICollectionView ViewSource
        {
            get { return _viewSource = (CollectionView)CollectionViewSource.GetDefaultView(DONTHUOC); }
        }



        public PHIEUKHAM()
        {
            //
        }
        public PHIEUKHAM(string ma_PhieuKham)
        {
            DONTHUOC = ReadScript(ma_PhieuKham);
        }



        /// <summary>
        /// Read the script from an Ma_PhieuKham
        /// </summary>
        /// <param name="ma_PhieuKham"></param>
        /// <returns></returns>
        private ObservableCollection<CT_DONTHUOC> ReadScript(string ma_PhieuKham)
        {
            var donthuoc = new ObservableCollection<CT_DONTHUOC>();
            using (var dc = new QLPM_ModelDataContext())
            {
                (from ctpk in dc.CT_PHIEUKHAMBENHs
                 join t in dc.THUOCs on ctpk.Ma_Thuoc equals t.Ma_Thuoc
                 join cd in dc.CACHDUNGs on ctpk.Ma_CachDung equals cd.Ma_CachDung
                 where ctpk.Ma_PhieuKham == ma_PhieuKham
                 select new CT_DONTHUOC()
                 {
                     Ma_PhieuKham = ctpk.Ma_PhieuKham,
                     Ma_Thuoc = ctpk.Ma_Thuoc,
                     TenThuoc = t.TenThuoc,
                     Ma_CachDung = ctpk.Ma_CachDung,
                     TenCachDung = cd.TenCachDung,
                     DonGia = ctpk.DonGia,
                     GhiChu = ctpk.GhiChu
                 }).ToList().ForEach(x => donthuoc.Add(x));
            }
            return donthuoc;
        }


        /// <summary>
        /// Casting PHIEUKHAMBENH type obj to PHIEUKHAM type obj
        /// </summary>
        /// <param name="phieukhambenh"></param>
        public static explicit operator PHIEUKHAM(PHIEUKHAMBENH phieukhambenh)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var pk = new PHIEUKHAM
                {
                    Ma_PhieuKham  = phieukhambenh.Ma_PhieuKham,
                    Ma_BenhNhan   = phieukhambenh.Ma_BenhNhan,
                    HoTen         = phieukhambenh.HOSOBENHNHAN.Hoten,
                    NgayKham      = phieukhambenh.NgayKham,
                    TrieuChung    = phieukhambenh.TrieuChung,
                    Ma_Benh       = phieukhambenh.Ma_Benh,
                    GioiTinh      = phieukhambenh.HOSOBENHNHAN.GioiTinh,
                    DONTHUOC      = new ObservableCollection<CT_DONTHUOC>()
                };

                (from ctpk in dc.CT_PHIEUKHAMBENHs
                 join t in dc.THUOCs on ctpk.Ma_Thuoc equals t.Ma_Thuoc
                 join cd in dc.CACHDUNGs on ctpk.Ma_CachDung equals cd.Ma_CachDung
                 where ctpk.Ma_PhieuKham == phieukhambenh.Ma_PhieuKham
                 select new CT_DONTHUOC()
                 {
                     Ma_PhieuKham = ctpk.Ma_PhieuKham,
                     Ma_Thuoc     = ctpk.Ma_Thuoc,
                     TenThuoc     = t.TenThuoc,
                     Ma_CachDung  = ctpk.Ma_CachDung,
                     TenCachDung  = cd.TenCachDung,
                     SoLuong      = ctpk.SoLuong,
                     Ma_DonVi     = t.Ma_DonVi,
                     TenDonVi     = t.DONVI.TenDonVi,
                     DonGia       = ctpk.DonGia,
                     GhiChu       = ctpk.GhiChu
                 }).ToList().ForEach(x => pk.DONTHUOC.Add(x));

                return pk;
            }
        }

        /// <summary>
        /// Casting PHIEUKHAM type obj to PHIEUKHAMBENH type obj
        /// </summary>
        /// <param name="phieukhambenh"></param>
        public static implicit operator PHIEUKHAMBENH(PHIEUKHAM phieukhambenh)
        {
            using (var dc = new QLPM_ModelDataContext())
            {
                var pk = new PHIEUKHAMBENH
                {
                    Ma_PhieuKham = phieukhambenh.Ma_PhieuKham,
                    Ma_BenhNhan  = phieukhambenh.Ma_BenhNhan,
                    NgayKham     = phieukhambenh.NgayKham,
                    TrieuChung   = phieukhambenh.TrieuChung,
                    Ma_Benh      = phieukhambenh.Ma_Benh
                };

                return pk;
            }
        }



        public override string ToString()
        {
            return Ma_PhieuKham + " " + Ma_BenhNhan + " " + HoTen + " " + 
                NgayKham.ToString() + " " + TrieuChung;
        }
    }

    public class CT_DONTHUOC : PropertyChangedBase
    {
        private string _ma_PhieuKham;
        private string _ma_Thuoc;
        private string _tenThuoc;
        private string _ma_CachDung;
        private string _tenCachDung;
        private short _soLuong;
        private decimal _donGia;
        private string _ghiChu;
        private string _ma_DonVi;
        private string _tenDonVi;
        private string _diaChi;


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
        public string  Ma_Thuoc    
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
        public string  TenThuoc    
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
        public string  Ma_CachDung 
        {
            get { return _ma_CachDung; }
            set
            {
                if (value != _ma_CachDung)
                {
                    SetProperty(value, ref _ma_CachDung);
                    OnPropertyChanged("Ma_CachDung");
                }
            }
        }
        public string  TenCachDung 
        {
            get { return _tenCachDung; }
            set
            {
                if (value != _tenCachDung)
                {
                    SetProperty(value, ref _tenCachDung);
                    OnPropertyChanged("TenCachDung");
                }
            }
        }
        public short   SoLuong      
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
        public decimal DonGia      
        {
            get { return _donGia; }
            set
            {
                if (value != _donGia)
                {
                    SetProperty(value, ref _donGia);
                    OnPropertyChanged("DonGia");
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
                }
            }
        }
        public string  Ma_DonVi    
        {
            get { return _ma_DonVi; }
            set
            {
                if (value != _ma_DonVi)
                {
                    SetProperty(value, ref _ma_DonVi);
                    OnPropertyChanged("Ma_DonVi");
                }
            }
        }
        public string  TenDonVi    
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
        public string  DiaChi      
        {
            get { return _diaChi; }
            set
            {
                if (value != _diaChi)
                {
                    SetProperty(value, ref _diaChi);
                    OnPropertyChanged("DiaChi");
                }
            }
        }
        

        private bool _isSelected;
        public bool IsSelectd
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    SetProperty(value, ref _isSelected);
                    OnPropertyChanged("IsSelectd");
                }
            }
        }



        /// <summary>
        /// Ctor
        /// </summary>
        public CT_DONTHUOC()
        {
            //
        }


        /// <summary>
        /// Casting CT_PHIEUKHAMBENH to CT_DONTHUOC
        /// </summary>
        /// <param name="ctpk"></param>
        public static explicit operator CT_DONTHUOC(CT_PHIEUKHAMBENH ctpk)
        {
            var ctdt = new CT_DONTHUOC
            {
                Ma_PhieuKham = ctpk.Ma_PhieuKham,
                Ma_Thuoc     = ctpk.Ma_Thuoc,
                TenThuoc     = ctpk.THUOC.TenThuoc,
                Ma_CachDung  = ctpk.Ma_CachDung,
                TenCachDung  = ctpk.CACHDUNG.TenCachDung,
                SoLuong      = ctpk.SoLuong,
                DonGia       = ctpk.DonGia,
                GhiChu       = ctpk.GhiChu,
                Ma_DonVi     = ctpk.THUOC.Ma_DonVi,
                TenDonVi     = ctpk.THUOC.DONVI.TenDonVi,
                DiaChi       = ctpk.PHIEUKHAMBENH.HOSOBENHNHAN.DiaChi
            };
            return ctdt;
        }

        /// <summary>
        /// Casting CT_DONTHUOC to CT_PHIEUKHAMBENH
        /// </summary>
        /// <param name="ctdt"></param>
        public static implicit operator CT_PHIEUKHAMBENH(CT_DONTHUOC ctdt)
        {
            var ctpk = new CT_PHIEUKHAMBENH()
            {
                Ma_PhieuKham = ctdt.Ma_PhieuKham,
                Ma_Thuoc     = ctdt.Ma_Thuoc,
                Ma_CachDung  = ctdt.Ma_CachDung,
                SoLuong      = ctdt.SoLuong,
                DonGia       = ctdt.DonGia,
                GhiChu       = ctdt.GhiChu,
            };
            return ctpk;
        }


        public override string ToString()
        {
            return Ma_PhieuKham + " " + Ma_PhieuKham + " " + TenThuoc + " " +
                Ma_CachDung + " " + TenCachDung + " " + SoLuong + " " + DonGia + " " + GhiChu;
        }
    }
}
