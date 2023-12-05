using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ghjdjlybr
{
    public class Pach
    {
        public string PachFillName {  get; set; } //имена файлов 
        public int CopyIndex { get; set; } //индексы копирвоания файлов

        public EventArgs eventArgs { get; set; } = new EventArgs();
        public RoutedEventArgs RoutedEventArgs { get; set; }

        public class RoutedPropertyChangedEventArgs<T> : System.Windows.RoutedEventArgs { }
    }
}