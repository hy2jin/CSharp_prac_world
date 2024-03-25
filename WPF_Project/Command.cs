using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Project
{
    public class Command : ICommand
    {
        Action<object> ExecuteMethod;
        Func<object, bool> CanExecuteMethod;

        public Command(Action<object> execute_Method, Func<object, bool> canexecute_Method)
        {
            this.ExecuteMethod = execute_Method;
            this.CanExecuteMethod = canexecute_Method;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object? parameter)
        {
            return this.CanExecute == null || this.CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.ExecuteMethod(parameter);
        }
    }
}
