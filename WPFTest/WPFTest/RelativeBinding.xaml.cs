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
    /// Interaction logic for RelativeBinding.xaml
    /// </summary>
    public partial class RelativeBinding : UserControl
    {
        public RelativeBinding()
        {
            InitializeComponent();
            RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            rs.AncestorLevel = 1;
            rs.AncestorType = typeof(Grid);
            Binding bind = new Binding("Name") { RelativeSource = rs };
            this.textBox1.SetBinding(TextBox.TextProperty, bind);  
        }
    }
}
