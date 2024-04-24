using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System.Commands
{
    public class RelayCommand: ICommand
    {
        //is called when conditions for whether the command can be executed or not
        public event EventHandler? CanExecuteChanged;

        //use action because the method should return void, and take in object
        private Action<object> _execute { get; set; }

        //use predicate because the method should return a boolean, and take in an object
        private Predicate<object> _canExecute { get; set; }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        //parameter comes from the command,
        //in our UI, when we invoke a command, we can pass an object
        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
