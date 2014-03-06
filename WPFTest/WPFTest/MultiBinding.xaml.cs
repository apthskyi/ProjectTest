using System;
using System.Collections.Generic;
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
    /// Interaction logic for MultiBinding.xaml
    /// </summary>
    public partial class MultiBindings : UserControl
    {
        public MultiBindings()
        {
            InitializeComponent();
            SetBinding();
        }

        private void SetBinding()
        {
            //准备基础Binding  
            Binding bind1 = new Binding("Text") { Source = textBox1 };
            Binding bind2 = new Binding("Text") { Source = textBox2 };
            Binding bind3 = new Binding("Text") { Source = textBox3 };
            Binding bind4 = new Binding("Text") { Source = textBox4 };

            //准备MultiBinding  
            MultiBinding mb = new MultiBinding() { Mode = BindingMode.OneWay };
            mb.Bindings.Add(bind1);//注意，MultiBinding对子元素的顺序是很敏感的。  
            mb.Bindings.Add(bind2);
            mb.Bindings.Add(bind3);
            mb.Bindings.Add(bind4);
            mb.Converter = new MultiBindingConverter();
            ///将Binding和MultyBinding关联  
            this.btnSubmit.SetBinding(Button.IsVisibleProperty, mb);
        }
    }

    public class MultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!values.Cast<string>().Any(text => string.IsNullOrEmpty(text)) && values[0].ToString() == values[1].ToString() && values[3].ToString() == values[4].ToString())
            {
                return true;
            }
            return false;
        }
        /// <summary>  
        /// 该方法不会被调用  
        /// </summary>  
        /// <param name="value"></param>  
        /// <param name="targetTypes"></param>  
        /// <param name="parameter"></param>  
        /// <param name="culture"></param>  
        /// <returns></returns>  
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
