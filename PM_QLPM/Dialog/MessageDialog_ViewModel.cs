using PM_QLPM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QLPM.Dialog
{
    public class MessageDialog_ViewModel : PropertyChangedBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (value != _message)
                {
                    SetProperty(value, ref _message);
                    OnPropertyChanged("Message");
                }
            }
        }



        public MessageDialog_ViewModel()
        {
            //
        }
        public MessageDialog_ViewModel(string message)
        {
            Message = message;
        }
    }
}
