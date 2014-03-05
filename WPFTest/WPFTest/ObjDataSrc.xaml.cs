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
    /// Interaction logic for ObjDataSrc.xaml
    /// </summary>
    public partial class ObjDataSrc : UserControl
    {
        public ObjDataSrc()
        {
            InitializeComponent();
            SetBinding();
        }
        private void SetBinding()
        {
            ObjectDataProvider objpro = new ObjectDataProvider();
            objpro.ObjectInstance = new Caculate();
            objpro.MethodName = "Add";
            objpro.MethodParameters.Add("0");
            objpro.MethodParameters.Add("0");
            Binding bindingToArg1 = new Binding("MethodParameters[0]") { Source = objpro, BindsDirectlyToSource = true, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            Binding bindingToArg2 = new Binding("MethodParameters[1]") { Source = objpro, BindsDirectlyToSource = true, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            Binding bindToResult = new Binding(".") { Source = objpro };
            this.arg1.SetBinding(TextBox.TextProperty, bindingToArg1);
            this.arg2.SetBinding(TextBox.TextProperty, bindingToArg2);
            this.result.SetBinding(TextBox.TextProperty, bindToResult);
        }  
    }
}
