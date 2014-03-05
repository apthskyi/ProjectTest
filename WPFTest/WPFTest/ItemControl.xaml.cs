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
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        public ItemControl()
        {
            InitializeComponent();

            List<Human> infos = new List<Human>() {   
            new Human(){ Age=11, Name="Tom"},  
            new Human(){ Age=12, Name="Darren"},  
            new Human(){ Age=13, Name="Jacky"},  
            new Human(){ Age=14, Name="Andy"}  
            };
            this.lb.ItemsSource = infos;
            //this.lb.DisplayMemberPath = "Name";

            this.tb.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Age") { Source = lb });
        }
    }
}
