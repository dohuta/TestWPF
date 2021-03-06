﻿using PM_QLPM.ViewModel;
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
    /// Interaction logic for View_TraCuu.xaml
    /// </summary>
    public partial class View_TraCuu : UserControl
    {
        public View_TraCuu()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var instance = this.DataContext as View_TraCuu_ViewModel;
            instance.CM_ItemClicked.Execute(null);
        }
    }
}
