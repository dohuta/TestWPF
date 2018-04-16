using PM_QLPM.Core;
using PM_QLPM.Model;
using PM_QLPM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PM_QLPM.ViewModel
{
    public class MainWindowViewModel
    {
        public UserItem[] ListItem { get; private set; }
        public NHANVIEN NhanVien { get; set; }

        public MainWindowViewModel()
        {
            AdminContext();
        }
        public MainWindowViewModel(NHANVIEN nv)
        {
            SelectDataContext(nv);
            NhanVien = nv;
        }

        private void SelectDataContext(NHANVIEN nv)
        {
            switch (nv.Role)
            {
                case 0:
                    AdminContext();
                    break;
                case 1:
                    ManagerContext();
                    break;
                default:
                    UserContext();
                    break;
            }
        }
        private void UserContext()
        {
            ListItem = new[]
            {
                new UserItem( "HOME",
                              "..//..//Resources/Icons/home.png",
                              new Home()),

                new UserItem( "DANH SÁCH KHÁM BỆNH",
                              "..//..//Resources/Icons/list.png",
                              new View_DSKhamBenh { DataContext = new View_DSKhamBenh_ViewModel()})
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "PHIẾU KHÁM BỆNH",
                              "..//..//Resources/Icons/form.png",
                              new View_PhieuKhamBenh { DataContext = new View_PhieuKhamBenh_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "TRA CỨU",
                              "..//..//Resources/Icons/search.png",
                              new View_TraCuu { DataContext = new View_TraCuu_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "LẬP HOÁ ĐƠN",
                              "..//..//Resources/Icons/bill.png",
                              new View_HoaDon { DataContext = new View_HoaDon_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                }
            };
        }
        private void ManagerContext()
        {
            ListItem = new[]
            {
                new UserItem( "HOME",
                              "..//..//Resources/Icons/home.png",
                              new Home()),

                new UserItem( "DANH SÁCH KHÁM BỆNH",
                              "..//..//Resources/Icons/list.png",
                              new View_DSKhamBenh { DataContext = new View_DSKhamBenh_ViewModel()})
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "PHIẾU KHÁM BỆNH",
                              "..//..//Resources/Icons/form.png",
                              new View_PhieuKhamBenh { DataContext = new View_PhieuKhamBenh_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "TRA CỨU",
                              "..//..//Resources/Icons/search.png",
                              new View_TraCuu { DataContext = new View_TraCuu_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "LẬP HOÁ ĐƠN",
                              "..//..//Resources/Icons/bill.png",
                              new View_HoaDon { DataContext = new View_HoaDon_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "BÁO CÁO DOANH THU",
                              "..//..//Resources/Icons/report.png",
                              new View_BaoCaoDoanhThu { DataContext = new View_BaoCaoDoanhThu_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "BÁO CÁO SỬ DỤNG THUỐC",
                              "..//..//Resources/Icons/report1.png",
                              new View_BaoCaoSuDungThuoc { DataContext = new View_BaoCaoSuDungThuoc_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                }
            };
        }
        private void AdminContext()
        {
            ListItem = new[]
            {
                new UserItem( "HOME",
                              "..//..//Resources/Icons/home.png",
                              new Home()),

                new UserItem( "DANH SÁCH KHÁM BỆNH",
                              "..//..//Resources/Icons/list.png",
                              new View_DSKhamBenh { DataContext = new View_DSKhamBenh_ViewModel()})
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "PHIẾU KHÁM BỆNH",
                              "..//..//Resources/Icons/form.png",
                              new View_PhieuKhamBenh { DataContext = new View_PhieuKhamBenh_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "TRA CỨU",
                              "..//..//Resources/Icons/search.png",
                              new View_TraCuu { DataContext = new View_TraCuu_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "LẬP HOÁ ĐƠN",
                              "..//..//Resources/Icons/bill.png",
                              new View_HoaDon { DataContext = new View_HoaDon_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "BÁO CÁO DOANH THU",
                              "..//..//Resources/Icons/report.png",
                              new View_BaoCaoDoanhThu { DataContext = new View_BaoCaoDoanhThu_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "BÁO CÁO SỬ DỤNG THUỐC",
                              "..//..//Resources/Icons/report1.png",
                              new View_BaoCaoSuDungThuoc { DataContext = new View_BaoCaoSuDungThuoc_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                },
                new UserItem( "QUẢN LÝ NGƯỜI DÙNG",
                              "..//..//Resources/Icons/settings.png",
                              new View_AccountManagement { DataContext = new View_AccountManagement_ViewModel() })
                {
                    HorizontalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Auto,
                    VerticalScrollbarVisibilityRequirement = System.Windows.Controls.ScrollBarVisibility.Disabled
                }
            };
        }


        private RelayCommand _cm_LogOut;

        public RelayCommand CM_LogOut
        {
            get
            {
                return _cm_LogOut ?? (_cm_LogOut = new RelayCommand(parameter =>
                {
                    var mainWindow = parameter as Window;
                    mainWindow.Close();
                }));
            }
        }

    }
}
