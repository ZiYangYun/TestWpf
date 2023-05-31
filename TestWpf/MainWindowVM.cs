using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestWpf
{
    public class MainWindowVM : ViewModelBase, IDisposable
    {
        private int IDIndes;

        private ObservableCollection<MainPeople> _People;
        public ObservableCollection<MainPeople> People
        {
            get => _People;
            set
            {
                _People = value;
                RaisePropertyChanged("People");
            }
        }

        private RelayCommand<string> _AddPerson;
        public RelayCommand<string> AddPerson
        {
            get
            {
                return _AddPerson ?? (_AddPerson = new RelayCommand<string>(s =>
                {
                    
                }));
            }
        }

        private string _Image;

        public string Image
        {
            get => _Image;
            set
            {
                _Image = value;
                RaisePropertyChanged("Image");
            }
        }
        private string _wifi;

        public string wifi
        {
            get => _wifi;
            set
            {
                _wifi = value;
                RaisePropertyChanged("wifi");
            }
        }
        private string _wifi1;

        public string wifi1
        {
            get => _wifi1;
            set
            {
                _wifi1 = value;
                RaisePropertyChanged("wifi1");
            }
        }
        private string _wifi2;

        public string wifi2
        {
            get => _wifi2;
            set
            {
                _wifi2 = value;
                RaisePropertyChanged("wifi2");
            }
        }

        
        public MainWindowVM()
        {
            
        }

        
        public string ImagePath(string image)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", image);

                return path;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddResult(ObservableCollection<MainPeople> result)
        {
            People = result;
        }
        
        private RelayCommand<string> _Delete;
        public RelayCommand<string> Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand<string>((ID) =>
                {
                    HandleDelete(ID);
                }));
            }
        }

        public void HandleDelete(string id)
        {
            var peo = People.FirstOrDefault(s => s.ID == id);
            People.Remove(peo);
        }

        public void Dispose()
        {

        }
    }
    public class MainPeople : ViewModelBase
    {
        private string _ID;
        public string ID
        {
            get => _ID;
            set
            {
                _ID = value;
                RaisePropertyChanged("ID");
            }
        }
        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        private RelayCommand<string> _Delete;
        public RelayCommand<string> Delete
        {
            get => _Delete;
            set
            {
                _Delete = value;
                RaisePropertyChanged("Delete");
            }
        }
    }
}


//// 创建Timer实例并设置调用的回调函数和间隔时间 
//Timer timer = new Timer(new TimerCallback(TimerCallBack), null, 0, 1000);
// Timer回调函数
//private void TimerCallBack(object state)
//{
//    // 在此处实现每五秒钟刷新一次操作
//    // ……
//    //远程服务器IP
//    IPHostEntry hostEntry = Dns.GetHostEntry("www.example.com");
//    //构造Ping实例
//    Ping pingSender = new Ping();
//    //调用同步 send 方法发送数据,将返回结果保存至PingReply实例
//    PingReply reply = pingSender.Send(hostEntry.AddressList[0]);

//    wifi = "答复的主机地址：" + reply.Address.ToString();
//    wifi1 = "延迟：" + reply.RoundtripTime;
//}
