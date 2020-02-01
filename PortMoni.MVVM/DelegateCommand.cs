using System;
using System.Windows.Input;

namespace PortMoni.MVVM
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute;
        private Func<bool> _canExecute;

        public DelegateCommand(Action<object> execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
