#nullable enable
using System;
using System.Windows.Input;
using Image.ML.WPF.Infrastructure;

namespace Image.ML.WPF.Commands.Base
{
    public abstract class Command : ICommand
    {
        public static LambdaCommand On(Action Execute, Func<bool>? CanExecute = null) => new(Execute, CanExecute);
        public static LambdaCommand On(Action<object?> Execute, Func<bool> CanExecute) => new(Execute, CanExecute);
        public static LambdaCommand On(Action<object?> Execute, Func<object?, bool>? CanExecute = null) => new(Execute, CanExecute);

        public static LambdaCommandAsync On(ActionAsync Execute, Func<bool>? CanExecute = null) => new(Execute, CanExecute);
        public static LambdaCommandAsync On(ActionAsync<object?> Execute, Func<bool> CanExecute) => new(Execute, CanExecute);
        public static LambdaCommandAsync On(ActionAsync<object?> Execute, Func<object?, bool>? CanExecute = null) => new(Execute, CanExecute);

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object? parameter) => CanExecute(parameter);

        void ICommand.Execute(object? parameter)
        {
            if(((ICommand)this).CanExecute(parameter))
                Execute(parameter);
        }

        protected virtual bool CanExecute(object? parameter) => true;

        protected abstract void Execute(object? parameter);
    }
}
