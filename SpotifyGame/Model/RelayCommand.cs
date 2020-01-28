using System;
using System.Windows.Input;

namespace SpotifyGame.Model
{
    public class RelayCommand : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute = () => true;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter = null)
        {
            return _canExecute();
        }

        public void Execute(object parameter = null)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}