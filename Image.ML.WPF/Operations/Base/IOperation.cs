using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Image.ML.WPF.Operations.Base
{
    public interface IOperation
    {
        ICommand Execute { get; }

        ICommand Cancel { get; }

        Exception? Error { get; }
        event EventHandler? ErrorChanged;

        IProgress<double> Progress { get; }

        IProgress<string> Status { get; }

        IProgress<string> Information { get; }

        Task ExecuteAsync(object? Parameter);

        Task CancelAsync();
    }
}
