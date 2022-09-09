using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpf
{
    public class MainWindowVM : ViewModelBase
    {
        private int IDIndes;
        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                if (value == "张三")
                {
                    _Name = value + "法外狂徒";
                }
                RaisePropertyChanged("Name");
            }
        }

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
                    if (People == null)
                    {
                        return;
                    }
                    People.Add(new Superman { ID = IDIndes++.ToString(), Name = "张三",Fly="飞" });
                }));
            }
        }
    }
}
