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
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for Property.xaml
    /// </summary>
    public partial class Property : Window
    {
        public Property()
        {
            InitializeComponent();
            Human11 human = new Human11();
            School.SetGrade(human, 15);
            int grade = School.GetGrade(human);
            MessageBox.Show(grade.ToString());  
        }
    }
    public class School : DependencyObject
    {

        public static int GetGrade(DependencyObject obj)
        {
            return (int)obj.GetValue(GradeProperty);
        }

        public static void SetGrade(DependencyObject obj, int value)
        {
            obj.SetValue(GradeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Grade.  This enables animation, styling, binding, etc...  
        public static readonly DependencyProperty GradeProperty =
            DependencyProperty.RegisterAttached("Grade", typeof(int), typeof(School), new UIPropertyMetadata(0));

    }
    public class Human11 : DependencyObject
    {

    }  
}
