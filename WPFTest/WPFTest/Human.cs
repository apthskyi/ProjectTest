using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    [TypeConverterAttribute(typeof(StringToHumanTypeConverter))]
    public class Human : INotifyPropertyChanged
    {
        public Human Child { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
