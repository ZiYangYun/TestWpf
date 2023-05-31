using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUIListTest
{
    public class EventListBaseModel: ViewModelBase,IDisposable
    {
        public UINodeTypeEnum NodeType;

        private string _Color = "#333333";
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (_Color == value)
                {
                    return;
                }
                _Color = value;
                RaisePropertyChanged("Color");
            }
        }

        private string _BackgroundColor = "Transparent";
        public string BackgroundColor
        {
            get
            {
                return _BackgroundColor;
            }
            set
            {
                if (_BackgroundColor == value)
                {
                    return;
                }
                _BackgroundColor = value;
                RaisePropertyChanged("BackgroundColor");
            }
        }
        private string _NodeValue;
        public string NodeValue
        {
            get
            {
                return _NodeValue;
            }
            set
            {
                if (_NodeValue == value)
                {
                    return;
                }
                _NodeValue = value;
                RaisePropertyChanged("NodeValue");
            }
        }
        public void Dispose()
        {
            
        }
    }
}
