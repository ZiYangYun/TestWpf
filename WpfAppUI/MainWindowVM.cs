using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfAppUI
{
    public class MainWindowVM : ViewModelBase
    {

        private IDialogCoordinator _dialogCoordinator;
        public MainWindowVM(IDialogCoordinator dialogCoordinator)
        {
            // 添加一些示例项
            Items.Add(new Item { ID = 1, Name = "Apple", Quantity = 10 });
            Items.Add(new Item { ID = 2, Name = "Banana", Quantity = 20 });
            Items.Add(new Item { ID = 3, Name = "Orange", Quantity = 15 });
            _dialogCoordinator = dialogCoordinator;
        }
        public ICommand ShowNotificationCommand => new RelayCommand(ShowConfirmationDialog);

        private async void ShowNotification()
        {
            await _dialogCoordinator.ShowMessageAsync(this, "Notification", "This is a notification message.");
        }
        private async void ShowConfirmationDialog()
        {
            var result = await _dialogCoordinator.ShowMessageAsync(this, "Confirmation", "Are you sure you want to perform this action?", MessageDialogStyle.AffirmativeAndNegative);

            if (result == MessageDialogResult.Affirmative)
            {
                // 用户点击了确认按钮
                lstGreetings = Items.Count().ToString();
            }
            else
            {
                // 用户点击了取消按钮
            }
        }
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
        public MainWindowVM()
        {
            
        }

        
        public async void DeleteMessage(int ID)
        {
            var result = await _dialogCoordinator.ShowMessageAsync(this, "注意", "确定要删除这条数据吗", MessageDialogStyle.AffirmativeAndNegative);

            if (result == MessageDialogResult.Affirmative)
            {

            }
            else
            {
                return;
            }
        }
        private string _TxtName;
        public string TxtName
        {
            get { return _TxtName; }
            set
            {
                _TxtName = value;
                RaisePropertyChanged("TxtName");
            }
        }
        private int _TxtQuantity;
        public int TxtQuantity
        {
            get { return _TxtQuantity; }
            set
            {
                _TxtQuantity = value;
                RaisePropertyChanged("TxtQuantity");
            }
        }
        private string _lstGreetings;
        public string lstGreetings
        {
            get { return _lstGreetings; }
            set
            {
                _lstGreetings = value;
                RaisePropertyChanged("lstGreetings");
            }
        }
        private RelayCommand<string> _SayHello;
        public RelayCommand<string> SayHello
        {
            get
            {
                return _SayHello ?? (_SayHello = new RelayCommand<string>(s =>
                {
                    string name = TxtName;
                    int a = TxtQuantity;
                    Items.Add(new Item { ID = 1, Name = name, Quantity = a });
                }));
            }
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Quantity { get; set; }

        private RelayCommand<int> _Delete;
        public RelayCommand<int> Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand<int>((ID) =>
                {
                    
                }));
            }
        }
    }
}
