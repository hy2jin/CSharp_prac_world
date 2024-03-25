using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Model
{
    class MainModel : INotifyPropertyChanged
    {
        private int num = 2;
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
                //Num2 = value * 2;
                OnPropertyChanged("Num");
            }
        }

        private int num2 = 1;
        public int Num2
        {
            get
            {
                return num2;
            }
            set
            {
                num2 = value;
                OnPropertyChanged("Num2");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
