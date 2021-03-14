using System.Windows;
using Image.ML.WPF.Commands.Base;

namespace Image.ML.WPF.Commands
{
    public class CloseWindow : Command
    {
        protected override bool CanExecute(object? parameter) => parameter is Window || App.CurrentWindow is not null;

        protected override void Execute(object? parameter) => (parameter as Window ?? App.CurrentWindow)?.Close();
    }
}
