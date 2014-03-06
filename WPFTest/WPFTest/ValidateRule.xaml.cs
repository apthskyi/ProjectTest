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
    /// Interaction logic for ValidateRule.xaml
    /// </summary>
    public partial class ValidateRule : UserControl
    {
        public ValidateRule()
        {
            InitializeComponent();
            Binding bind = new Binding("Value") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Source = s1, Mode = BindingMode.TwoWay };
            ValidationRule rule = new RangeValidationRule();
            rule.ValidatesOnTargetUpdated = true;
            bind.ValidationRules.Add(rule);
            bind.NotifyOnValidationError = true;
            this.t1.SetBinding(TextBox.TextProperty, bind);
            this.t1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(ValidationError));  
        }
        private void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(t1).Count > 0)
            {
                this.t1.ToolTip = Validation.GetErrors(t1)[0].ErrorContent.ToString();
            }
            else
            {
                this.t1.ToolTip = "";
            }
        }
    }
    public class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double d = 0;
            if (double.TryParse(value.ToString(), out d))
            {
                if (d >= 0 && d <= 10)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "ErrorContent");
        }
    }  
}
