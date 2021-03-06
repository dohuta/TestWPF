﻿using PM_QLPM.Core;
using PM_QLPM.Model;
using PM_QLPM.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PM_QLPM.View
{
    /// <summary>
    /// Interaction logic for View_AccountManagement.xaml
    /// </summary>
    public partial class View_AccountManagement : UserControl
    {
        public View_AccountManagement()
        {
            InitializeComponent();
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if (!Equals(eventArgs.Parameter, true)) return;

            var nv         = new NHANVIEN();

            nv.Ma_NV       = Helper.GetNewID(nv);
            nv.HoTen       = txt_Hoten.Text;
            nv.Username    = txt_Username.Text;
            nv.Password    = Helper.EncryptPassword(pwb_Password.Password);
            int.TryParse(txt_VaiTro.Text, out int role);
            nv.Role        = (short)role;

            ((View_AccountManagement_ViewModel)DataContext).DS_NV.Add(nv);
            ((View_AccountManagement_ViewModel)DataContext).ViewSource.Refresh();
            ((View_AccountManagement_ViewModel)DataContext).SaveNewNV(nv);
        }
    }
}
