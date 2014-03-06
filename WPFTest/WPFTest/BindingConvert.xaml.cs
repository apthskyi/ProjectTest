using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for BindingConvert.xaml
    /// </summary>
    public partial class BindingConvert : UserControl
    {
        public BindingConvert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> infos = new List<Plane>() {   
            new Plane(){ category= Category.Bomber,name="B-1", state= State.Unknown},  
            new Plane(){ category= Category.Bomber,name="B-2", state= State.Unknown},  
            new Plane(){ category= Category.Fighter,name="F-22", state= State.Locked},  
            new Plane(){ category= Category.Fighter,name="Su-47", state= State.Unknown},  
            new Plane(){ category= Category.Bomber,name="B-52", state= State.Available},  
            new Plane(){ category= Category.Fighter,name="J-10", state= State.Unknown},  
            };
            this.listBox1.ItemsSource = infos;
        }
        /// <summary>  
        /// Save按钮事件处理器  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Plane item in listBox1.Items)
            {
                sb.AppendLine(string.Format("Categroy={0},State={1},Name={2}", item.category, item.state, item.name));
            }
            File.WriteAllText(@"D:\PlaneList.text", sb.ToString());
        }  
    }
    public enum Category
    {
        Bomber,
        Fighter
    }

    public enum State
    {
        Available,
        Locked,
        Unknown
    }

    public class Plane
    {
        public Category category { get; set; }
        public State state { get; set; }
        public string name { get; set; }
    }

    public class CategoryToSourceConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            Category category = (Category)value;
            switch (category)
            {
                case Category.Bomber:
                    return @"ICON/Bomber.jpg";

                case Category.Fighter:
                    return @"ICON/Fighter.jpg";

                default:
                    return null;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StateToNullableBoolConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            State state = (State)value;
            switch (state)
            {
                case State.Available:
                    return true;

                case State.Locked:
                    return false;
                case State.Unknown:

                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameters, System.Globalization.CultureInfo culture)
        {
            bool? nb = (bool?)value;
            switch (nb)
            {
                case true:
                    return State.Available;
                case false:
                    return State.Locked;
                case null:
                default:
                    return State.Unknown;

            }
        }
    }
}
