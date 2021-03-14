using System;
using System.Threading.Tasks;
using Image.ML.WPF.Commands.Base;
using Image.ML.WPF.Infrastructure;

namespace Image.ML.WPF.Commands
{
    public class LambdaCommandAsync : CommandAsync
    {
        private readonly ActionAsync<object?> _Execute;
        private readonly Func<object?, bool>? _CanExecute;

        public LambdaCommandAsync(ActionAsync Execute, Func<bool>? CanExecute = null)
            : this(
                Execute is { } execute ? _ => execute() : throw new ArgumentNullException(nameof(Execute)),
                CanExecute is { } can_execute ? _ => can_execute() : null)
        {

        }

        public LambdaCommandAsync(ActionAsync<object?> Execute, Func<bool> CanExecute)
            : this(Execute, _ => CanExecute())
        {

        }

        public LambdaCommandAsync(ActionAsync<object?> Execute, Func<object?, bool>? CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        protected override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;

        protected override async Task ExecuteAsync(object? parameter) => await _Execute(parameter).ConfigureAwait(true);
    }
}
