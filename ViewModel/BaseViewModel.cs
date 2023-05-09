using System;
using System.ComponentModel;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PageButton
    {
        public String PageString { get; set; }
        public int PageInt { get; set; }
    }
}
