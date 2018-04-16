using PM_QLPM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QLPM.Model
{
    public class BENHNHAN : PropertyChangedBase
    {
        private bool _isSelected;
        private string _ma_BenhNhan;
        private string _hoTen;
        private bool _gioiTinh;
        private DateTime _namSinh;
        private string _diaChi;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    SetProperty(value, ref _isSelected);
                    OnPropertyChanged("IsSelected");
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
        public DateTime NamSinh
        {
            get { return _namSinh; }
            set
            {
                if (value != _namSinh)
                {
                    SetProperty(value, ref _namSinh);
                    OnPropertyChanged("NamSinh");
                }
            }
        }        
        public string DiaChi
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


        public BENHNHAN()
        {
            //
        }


        /// <summary>
        /// Casting HOSOBENHNHAN type to BENHNHAN
        /// </summary>
        /// <param name="hosobenhnhan"></param>
        public static explicit operator BENHNHAN(HOSOBENHNHAN hosobenhnhan)
        {
            var bn = new BENHNHAN
            {
                IsSelected  = false,
                Ma_BenhNhan = hosobenhnhan.Ma_BenhNhan,
                HoTen       = hosobenhnhan.Hoten,
                GioiTinh    = hosobenhnhan.GioiTinh,
                NamSinh     = hosobenhnhan.NamSinh,
                DiaChi      = hosobenhnhan.DiaChi
            };
            return bn;
        }
        
        /// <summary>
        /// Casting BENHNHAN type to HOSOBENHNHAN
        /// </summary>
        /// <param name="bn"></param>
        public static implicit operator HOSOBENHNHAN(BENHNHAN bn)
        {
            var hosobenhnhan = new HOSOBENHNHAN
            {
                Ma_BenhNhan = bn.Ma_BenhNhan,
                Hoten       = bn.HoTen,
                GioiTinh    = bn.GioiTinh,
                NamSinh     = bn.NamSinh,
                DiaChi      = bn.DiaChi
            };
            return hosobenhnhan;
        }

        public override string ToString()
        {
            var gt = GioiTinh == true ? "Nam" : "Nữ";
            return "" + Ma_BenhNhan + " " + HoTen + " " + gt + " " + DiaChi;
        }
    }
}
