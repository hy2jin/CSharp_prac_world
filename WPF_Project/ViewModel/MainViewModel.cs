using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Model.MainModel? model = null;
        public Command btn_cmd { get; set; }
        public MainViewModel()
        {
            model = new Model.MainModel();
            btn_cmd = new Command(Execute_func, CanExecute_func);
        }
        public Model.MainModel Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged("Model"); }
        }

        private void Execute_func(object obj)
        {
            model.Num2 = model.Num * 2;
        }
        private bool CanExecute_func(object obj)
        {
            return true;
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
