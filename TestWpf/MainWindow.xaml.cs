using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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
using System.Threading;

namespace TestWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, string> PathContentPairs = new Dictionary<int, string>();
        public MainWindow()
        {
            InitializeComponent();
            ce();
            ce1();
            //Timer timer = new Timer(new TimerCallback(ce2), null, 0, 1000);
            //System.Timers.Timer timer = new System.Timers.Timer(1000);
            //timer.Elapsed += async (sender, e) => await ce2();
            //timer.Start();
            System.Timers.Timer t = new System.Timers.Timer(100); //实例化Timer类，设置时间间隔
            t.Elapsed += new System.Timers.ElapsedEventHandler(ce2); //到达时间的时候执行事件
            t.AutoReset = true; //设置是执行一次（false）还是一直执行(true)
            t.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件
        }
        Random random = new Random();
        public void ce()
        {
            Task.Run(() =>
            {

                for (int i = 0; i < 5000; i++)
                {
                    Thread.Sleep(random.Next(1,20));
                    lock (PathContentPairs)
                    {
                        PathContentPairs.Add(i, "第一个添加");
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            wifi.Text = i.ToString();
                        });
                    }
                }
            });
        }
        public void ce1()
        {
            Task.Run(() =>
            {

                for (int i = 5000; i < 10000; i++)
                {
                    Thread.Sleep(random.Next(1, 20));
                    lock (PathContentPairs)
                    {
                        PathContentPairs.Add(i, "er");
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            wifi1.Text = i.ToString();
                        });
                    }
                }
            });
        }
        public void  ce2(object state , System.Timers.ElapsedEventArgs e)
        {
            Task.Run(() =>
            {
                lock (PathContentPairs)
                {
                    foreach (KeyValuePair<int, string> item in PathContentPairs)
                    {
                        
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            wifi2.Text = $"结果 {item.Key} 值{item.Value}";
                        });
                    }
                }
            });
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowVM mainWindowVM = new MainWindowVM();
            this.DataContext = mainWindowVM;

            List<MainPeople> people = new List<MainPeople>
            {
                new MainPeople { ID = "001", Name = "张三" ,Delete = mainWindowVM.Delete},
                new MainPeople { ID = "002", Name = "李四" ,Delete = mainWindowVM.Delete},
                new MainPeople { ID = "003", Name = "王五" ,Delete = mainWindowVM.Delete},
                new MainPeople { ID = "004", Name = "赵六" ,Delete = mainWindowVM.Delete}
            };
            people = people.OrderBy(p => p.ID).ToList();
            mainWindowVM.People = new System.Collections.ObjectModel.ObservableCollection<MainPeople>(people);
        }
    }
}
