using System;
using System.Windows.Input;

namespace FunnyWaterCarrier.Commands {
    public class AddCommand : ICommand {
        private readonly Action<object> execute;

        public AddCommand(Action<object> execute) {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            execute(parameter);
        }
    }
}