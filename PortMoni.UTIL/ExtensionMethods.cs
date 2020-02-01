using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PortMoni.UTIL
{
    public static class ExtensionMethods
    {
        public static void AddAsync<T>(this ObservableCollection<T> a, T item)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                a.Add(item);
            });
        }
    }
}
