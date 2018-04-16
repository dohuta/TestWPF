using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace PM_QLPM.View
{
    /// <summary>
    /// Interaction logic for View_ThemSuaThuoc.xaml
    /// </summary>
    public partial class View_ThemSuaThuoc : MetroWindow
    {
        public View_ThemSuaThuoc()
        {
            InitializeComponent();
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
