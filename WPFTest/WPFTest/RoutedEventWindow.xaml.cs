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
    /// Interaction logic for RoutedEventWindow.xaml
    /// </summary>
    public partial class RoutedEventWindow : Window
    {
        public RoutedEventWindow()
        {
            InitializeComponent();
            //this.gridRoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));  

            this.gd_1.AddHandler(TimeButton.reprotTimeEvent, new RoutedEventHandler(ReportTimeHandle));
            this.gd_2.AddHandler(TimeButton.reprotTimeEvent, new RoutedEventHandler(ReportTimeHandle));
            this.gd_3.AddHandler(TimeButton.reprotTimeEvent, new RoutedEventHandler(ReportTimeHandle));
            this.sp_1.AddHandler(TimeButton.reprotTimeEvent, new RoutedEventHandler(ReportTimeHandle));

            this.gd_1.AddHandler(Button.ClickEvent, new RoutedEventHandler(ReportTimeHandle));
            this.gd_2.AddHandler(Button.ClickEvent, new RoutedEventHandler(ReportTimeHandle));
            this.gd_3.AddHandler(Button.ClickEvent, new RoutedEventHandler(ReportTimeHandle));
            this.sp_1.AddHandler(Button.ClickEvent, new RoutedEventHandler(ReportTimeHandle));
        }

        private void Button_Click(object obj, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as FrameworkElement).Name);
        }

        public void ReportTimeHandle(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = (e is ReportTimeEventArgs) ? (e as ReportTimeEventArgs).ClickTime.ToLongTimeString() : "temp";
            string content = string.Format("{0}到达{1}", timeStr, element.Name);
            this.lb_view.Items.Add(content);
        }  
    }

    public class ReportTimeEventArgs : RoutedEventArgs 
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }

        public DateTime ClickTime { get; set; }

    }

    public class TimeButton : Button
    {
        //声明和注册路由事件  
        public static readonly RoutedEvent reprotTimeEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));
        //CLR事件包装器  
        public event RoutedEventHandler ReprortTime
        {
            add { this.AddHandler(reprotTimeEvent, value); }
            remove { this.RemoveHandler(reprotTimeEvent, value); }
        }
        //激发路由事件，借用Click事件的激活方法  
        protected override void OnClick()
        {
            ReportTimeEventArgs args = new ReportTimeEventArgs(reprotTimeEvent, this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args);
            //base.OnClick();//保证Button的原有功可以正常使用、Click事件能被激发。  
        }
    }  
}
