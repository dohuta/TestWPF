using MahApps.Metro.Controls;
using PM_QLPM.Core;
using PM_QLPM.Model;
using PM_QLPM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PM_QLPM.View
{
    /// <summary>
    /// Interaction logic for View_ThemBenhNhan.xaml
    /// </summary>
    public partial class View_ThemBenhNhan : MetroWindow
    {
        public View_ThemBenhNhan()
        {
            InitializeComponent();
            DataContext = new View_ThemBenhNhan_ViewModel();
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if (!Equals(eventArgs.Parameter, true)) return;

            var hoso         = new HOSOBENHNHAN();

            hoso.Ma_BenhNhan = Helper.GetNewID(hoso);
            hoso.Hoten       = txt_Hoten.Text;
            hoso.GioiTinh    = rad_Nam.IsChecked == true ? true : false;
            hoso.NamSinh     = txt_NgaySinh.SelectedDate != null ? txt_NgaySinh.SelectedDate.Value : DateTime.Today;
            hoso.DiaChi      = txt_DiaChi.Text;

            ((View_ThemBenhNhan_ViewModel)DataContext).DS_HoSo.Add(hoso);
            ((View_ThemBenhNhan_ViewModel)DataContext).ViewSource.Refresh();
            ((View_ThemBenhNhan_ViewModel)DataContext).SaveNewHoSo(hoso);
        }

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
