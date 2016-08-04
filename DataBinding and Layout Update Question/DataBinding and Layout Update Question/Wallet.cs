using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding_and_Layout_Update_Question
{
    public class Wallet : INotifyPropertyChanged
    {
        private ObservableCollection<WalletAddress> _address;
        public ObservableCollection<WalletAddress> address
        {
            get { return _address; }
            set { _address = value; RaisePropertyChanged("address"); }
        }
        private double _value;
        public double value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChanged("value"); }
        }
        private DateTime _updateTime;
        public DateTime updateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; RaisePropertyChanged("updateTime"); }
        }

        // Property Changed Event Handlers
        protected void RaisePropertyChanged(string propertyName)
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
        public event PropertyChangedEventHandler PropertyChanged;

    }

    public class WalletAddress
    {
        public string address { get; set; }
        public double value { get; set; }
    }
}
