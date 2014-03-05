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
        private int age;
        public int Age
        {
            set
            {
                age = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));
                }
            }
            get { return age; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Id"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
