using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpf
{
    public class Superman : MainPeople
    {
        private string _Fly;
        public string Fly
        {
            get => _Fly;
            set
            {
                _Fly = value;
                RaisePropertyChanged("Fly");
            }
        }
    }
}
