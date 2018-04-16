using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PM_QLPM.Core
{
    public class UserItem : PropertyChangedBase
    {
        private string _name;
        private string _icon;
        private object _content;
        private ScrollBarVisibility _horizontalScrollbarVisibilityRequirement;
        private ScrollBarVisibility _verticalScrollbarVisibilityRequirement;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    SetProperty(value, ref _name);
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Icon
        {
            get { return _icon; }
            set
            {
                if (value != _icon)
                {
                    SetProperty(value, ref _icon);
                    OnPropertyChanged("Icon");
                }
            }
        }
        public object Content
        {
            get { return _content; }
            set
            {
                if (value != _content)
                {
                    SetProperty(value, ref _content);
                    OnPropertyChanged("Content");
                }
            }
        }
        public ScrollBarVisibility HorizontalScrollbarVisibilityRequirement
        {
            get { return _horizontalScrollbarVisibilityRequirement; }
            set
            {
                if (value != _horizontalScrollbarVisibilityRequirement)
                {
                    SetProperty(value, ref _horizontalScrollbarVisibilityRequirement);
                    OnPropertyChanged("HorizontalScrollbarVisibilityRequirement");
                }
            }
        }
        public ScrollBarVisibility VerticalScrollbarVisibilityRequirement
        {
            get { return _verticalScrollbarVisibilityRequirement; }
            set
            {
                if (value != _verticalScrollbarVisibilityRequirement)
                {
                    SetProperty(value, ref _verticalScrollbarVisibilityRequirement);
                    OnPropertyChanged("VerticalScrollbarVisibilityRequirement");
                }
            }
        }

        public UserItem(string name, string iconPath, object content)
        {
            Icon = iconPath;
            Name = name;
            Content = content;
        }
    }
}
