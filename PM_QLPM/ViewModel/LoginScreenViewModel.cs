using MaterialDesignThemes.Wpf;
using PM_QLPM.Core;
using PM_QLPM.Dialog;
using PM_QLPM.Model;
using PM_QLPM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PM_QLPM.ViewModel
{
    public class LoginScreenViewModel : PropertyChangedBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                if (value != _username)
                {
                    SetProperty(value, ref _username);
                    OnPropertyChanged("Username");
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    SetProperty(value, ref _password);
                    OnPropertyChanged("Password");
                }
            }
        }

        public LoginScreenViewModel()
        {
            Username = "";
            Password = "";
        }

        private RelayCommand _cm_Login;
        public RelayCommand CM_Login => _cm_Login ?? (_cm_Login = new RelayCommand(async parameter =>
                                                      {
                                                          using (var dc = new QLPM_ModelDataContext())
                                                          {
                                                              PasswordBox pwBox = parameter as PasswordBox;
                                                              var nv = dc.NHANVIENs.Single(x => x.Username == Username);
                                                              var encryptPass = Helper.EncryptPassword(pwBox.Password).ToUpper();
                                                              if (nv.Password.Trim() == encryptPass)
                                                              {
                                                                  var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                                                                  var mainWindow = new MainWindow() { DataContext = new MainWindowViewModel(nv) };
                                                                  mainWindow.Show();
                                                                  window.Hide();
                                                              }
                                                              else
                                                              {
                                                                  var messageDialog = new MessageDialog() { DataContext = new MessageDialog_ViewModel("Sai Username hoặc mật khẩu") };
                                                                  await DialogHost.Show(messageDialog, "RootDialog");
                                                                  return;
                                                              }
                                                          }
                                                      }));

    }
}
