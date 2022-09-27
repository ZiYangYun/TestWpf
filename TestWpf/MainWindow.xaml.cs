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

namespace TestWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
