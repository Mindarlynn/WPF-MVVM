using System;
using System.Windows.Input;

namespace WpfApp1.Command
{
    internal class DelegateCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action<object> execute_params;
        private readonly Action execute_void;

        public DelegateCommand(Action execute) : this(execute, null) { }

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {

        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute_void = execute;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute, Func<bool> canExecute)
        {
            this.execute_params = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            if (canExecute == null)
            {
                return true;
            }
            return canExecute();
        }

        public void Execute(object o)
        {
            if (execute_void != null)
                execute_void();
            if(execute_params != null) 
                execute_params(o);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}