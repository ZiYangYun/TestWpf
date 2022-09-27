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
                    Add(AddResult);
                }));
            }
        }
        public void AddResult(ObservableCollection<MainPeople> result)
        {
            People = result;
        }
        public void Add(Action<ObservableCollection<MainPeople>> mainpeople)
        {
            Task.Run(() =>
            {
                if (People == null)
                {
                    return;
                }
                ObservableCollection<MainPeople> mainPeoples = new ObservableCollection<MainPeople>();
                for (int i = 0; i < 100; i++)
                {
                    mainPeoples.Add(new Superman
                    {
                        //ID = IDIndes++.ToString(),
                        ID = i.ToString(),
                        Name = "张三",
                        Fly = "飞",
                        Delete = Delete
                    });
                }

                mainpeople(mainPeoples);
            });
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
