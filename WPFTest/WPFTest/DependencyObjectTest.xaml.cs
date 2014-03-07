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
    /// Interaction logic for DependencyObjectTest.xaml
    /// </summary>
    public partial class DependencyObjectTest : UserControl
    {
        Student stu;
        public DependencyObjectTest()
        {
            InitializeComponent();
            stu = new Student();
            Binding bind=new Binding();
            bind.Path = new PropertyPath("Text");
            bind.Source=this.textBox1;
            bind.Mode = BindingMode.TwoWay;

            stu.SetBinding(Student.NameProperty, bind);
            textBox2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu });
            //Binding bind = new Binding("Text") { Source = textBox1 };
            //BindingOperations.SetBinding(stu, Student.NameProperty, bind); 
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Student stu = new Student();
            //stu.SetValue(Student.NameProperty, textBox1.Text);
            textBox2.SetValue(TextBox.TextProperty, stu.GetValue(Student.NameProperty));
        }  
    }
    public class Student : DependencyObject
    {
        public string Name
        { 
            set { SetValue(NameProperty, value); } 
            get { return (string)GetValue(NameProperty); } 
        }
        
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Student));
        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase bind)
        {
            return BindingOperations.SetBinding(this, dp, bind);
        }  
    }
}
