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
using System.Xml;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for XmlBinding.xaml
    /// </summary>
    public partial class XmlBinding : UserControl
    {
        public XmlBinding()
        {
            InitializeComponent();
            string xml = @"<StudentList>
                              <Student id='1'>
                                <Name>Andy</Name>
                              </Student>
                              <Student id='2'>
                                <Name>Jacky</Name>
                              </Student>
                              <Student id='3'>
                                <Name>Darren</Name>
                              </Student>
                              <Student id='4'>
                                <Name>DK</Name>
                              </Student>
                              <Student id='1'>
                                <Name>Jim</Name>
                              </Student>
                           </StudentList>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlDataProvider dp = new XmlDataProvider();
            dp.Document = doc;
            dp.XPath = @"StudentList/Student";
            this.abc.DataContext = dp;
            this.abc.SetBinding(ListView.ItemsSourceProperty, new Binding());  
        }
    }
}
