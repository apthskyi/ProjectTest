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
    /// Interaction logic for LinqBinding.xaml
    /// </summary>
    public partial class LinqBinding : UserControl
    {
        public LinqBinding()
        {
            InitializeComponent();
            List<Human> infos = new List<Human>()  
            {  
                new Human(){Id=1, Age=29, Name="Tim"},  
                new Human(){Id=1, Age=28, Name="Tom"},  
                new Human(){Id=1, Age=27, Name="Kyle"},  
                new Human(){Id=1, Age=26, Name="Tony"},  
                new Human(){Id=1, Age=25, Name="Vina"},  
                new Human(){Id=1, Age=24, Name="Mike"}  
            };
            this.listView1.ItemsSource = from stu in infos where stu.Name.StartsWith("T") select stu;
        }
    }
}
