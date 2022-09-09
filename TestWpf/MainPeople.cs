using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpf
{
    public class MainPeople : ViewModelBase
    {
        private string _ID;
        public string ID
        {
            get=>_ID;
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
    }
}
