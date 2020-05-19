using System;
using System.Windows.Input;
using FunnyWaterCarrier.DAL.Entities;

namespace FunnyWaterCarrier.Commands {
    public class UpdateCommand : ICommand {
        private readonly Action<object> execute;

        public UpdateCommand(Action<object> execute) {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            if (parameter == null) {
                return false;
            }

            var entity = parameter as BaseEntity;
            return entity.Verify();
        }

        public void Execute(object parameter) {
            execute(parameter);
        }
    }
}