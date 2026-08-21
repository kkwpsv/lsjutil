using System;
using System.Windows.Input;

namespace Lsj.Util.WPF.Commands
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> execute)
        {
            ExecuteAction = execute;
        }

        private readonly Action<object> ExecuteAction;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => ExecuteAction(parameter);
    }
}
