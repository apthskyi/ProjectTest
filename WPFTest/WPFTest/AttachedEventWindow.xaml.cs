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
    /// Interaction logic for AttachedEventWindow.xaml
    /// </summary>
    public partial class AttachedEventWindow : Window
    {
        public AttachedEventWindow()
        {
            InitializeComponent();
            Person.AddNameChangedHandle(this.grid_A, new RoutedEventHandler(PersonNameChanged));
            //this.grid_A.AddHandler(Person.NameChangedEvent, new RoutedEventHandler(PersonNameChanged));
            //在窗体的构造器中为Grid元素添加了对Student.NameChangedEvent的侦听，这与添加对路由事件的侦听没有任何区别。
        }


        private void PersonNameChanged(object obj, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Person).Name);
        }
        //因为Student不是UIElement的派生类，所以它不具备RaiseEvent这个方法，为了发送路由事件就不得不借用一下Button的RaiseEvent方法
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Person persion = new Person();
            persion.Id = 0;
            persion.Name = "Darren";
            //准备事件消息并发送路由事件  
            RoutedEventArgs arg = new RoutedEventArgs(Person.NameChangedEvent, persion);
            this.button1.RaiseEvent(arg);  
        }
    }

    //设计一个名为Student的类，如果Studen的Name属性发生了变化就激发一个路由事件，我会用界面元素来捕捉这个事件
    public class Person
    {
        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Person));
        //为界面添加路由侦听  
        public static void AddNameChangedHandle(DependencyObject d, RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (null != e)
            {
                e.AddHandler(NameChangedEvent, h);
            }
        }
        //移除侦听  
        public static void RemoveNameChangedHandle(DependencyObject d, RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (null != e)
            {
                e.RemoveHandler(NameChangedEvent, h);
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
