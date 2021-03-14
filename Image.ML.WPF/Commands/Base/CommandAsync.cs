using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Image.ML.WPF.Commands.Base
{
    public abstract class CommandAsync : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object? parameter) => CanExecute(parameter);

        private Task? _ExecutionTask;
        void ICommand.Execute(object? parameter)
        {
            if (!((ICommand) this).CanExecute(parameter)) return;

            var task = ExecuteAsync(parameter);
            _ = task.ContinueWith(OnExecuteAsyncCompleted);
            _ExecutionTask = task;

            CommandManager.InvalidateRequerySuggested();
        }

        protected virtual bool CanExecute(object? parameter) => _ExecutionTask != null;

        protected abstract Task ExecuteAsync(object? parameter);

        protected virtual void OnExecuteAsyncCompleted(Task ExecuteTask)
        {
            if (ExecuteTask.IsFaulted)
                throw new InvalidOperationException("Ошибка при выполнении команды", ExecuteTask.Exception);

            _ExecutionTask = null;
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
