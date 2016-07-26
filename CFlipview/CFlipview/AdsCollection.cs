using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFlipview
{
    public class AdsCollection : INotifyCollectionChanged
    {
        private ObservableCollection<AdsInfo> _adsColl = new ObservableCollection<AdsInfo>();

        public ObservableCollection<AdsInfo> AdsDataCollection
        {
            get { return _adsColl; }
        }

        public void AddAdv(AdsInfo ad)
        {
            _adsColl.Add(ad);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, ad));
        }

        public void RemoveAdv(AdsInfo ad)
        {
            _adsColl.Remove(ad);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, ad));
        }

        public void Clear()
        {
            _adsColl.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void Copy(ObservableCollection<AdsInfo> collection)
        {
            _adsColl = collection;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public string getSwitchAdStringAt(int idx)
        {
            return _adsColl[idx].adSwitch;
        }

        public double getSwitchAdDoubleAt(int idx)
        {
            return double.Parse(getSwitchAdStringAt(idx));
        }

        public string getLinkAdAt(int idx)
        {
            return _adsColl[idx].link;
        }

        public int Count
        {
            get { return _adsColl.Count; }
        }


        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, args);
        }
    }
}
