using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Image.ML.WPF.Commands;
using Image.ML.WPF.Commands.Base;

namespace Image.ML.WPF.Operations.Base
{
    public abstract class Operation : IOperation
    {
        private LambdaCommandAsync? _ExecuteCommand;
        public ICommand Execute => _ExecuteCommand ??= Command.On(ExecuteAsync, CanExecute);

        public ICommand Cancel { get; }

        public Exception? Error { get; private set; }
        public event EventHandler? ErrorChanged;
        protected virtual void OnErrorChanged(Exception? error)
        {
            if (Equals(Error, error)) return;
            Error = error;
            ErrorChanged?.Invoke(this, EventArgs.Empty);
        }

        public IProgress<double> Progress { get; }
        public IProgress<string?> Status { get; }
        public IProgress<string?> Information { get; }

        protected Operation()
        {
            Progress = new Progress<double>();
            Status = new Progress<string?>();
            Information = new Progress<string?>();
        }

        public async Task ExecuteAsync(object? Parameter)
        {
            OnErrorChanged(null);
            try
            {
                await ExecuteAsync(Parameter, Progress, Status, Information);
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception error)
            {
                OnErrorChanged(error);
            }
        }

        private bool CanExecute(object? Parameter) => true;

        async Task IOperation.CancelAsync() { throw new NotImplementedException(); }

        protected abstract Task ExecuteAsync(
            object? Parameter,
            IProgress<double> Progress,
            IProgress<string?> Status,
            IProgress<string?> Information);
    }
}
