using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Test = "明月松间照，清泉石上流。";
        Human hu;
        public MainWindow()
        {
            InitializeComponent();
            hu = new Human();
            hu.Name = "1";
            Binding binding = new Binding();
            binding.Source = hu;
            binding.Path = new PropertyPath("Name");
            this.text0.SetBinding(TextBox.TextProperty, binding);

            Binding tsB = new Binding();
            //tsB.ElementName = "slider1";
            tsB.Path = new PropertyPath("Value");
            tsB.Source = this.slider1;
            tsB.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            tsB.Mode = BindingMode.TwoWay;
            this.textBox1.SetBinding(TextBox.TextProperty, tsB);

            List<string> infos = new List<string>() { "Jim", "Darren", "Jacky" };
            Binding lB = new Binding("/");
            lB.Source = infos;
            lB.Mode = BindingMode.OneWay;
            this.textList.SetBinding(TextBox.TextProperty, lB);
        }
        public Type MyWindowType { get; set; } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human human = (Human)this.FindResource("human");
            //MessageBox.Show(human.Child.Name);
            object obj = this.FindResource("myString");
            object obj1 = this.FindResource(typeof(Button));

            Window myWin = Activator.CreateInstance(this.MyWindowType) as Window;
            if (myWin != null)
            {
                myWin.Show();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            
            hu.Name += "f";
        }
    }

    public class StringToHumanTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                Human human = new Human();
                human.Name = value as string;
                return human;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
