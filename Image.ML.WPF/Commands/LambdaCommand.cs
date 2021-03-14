#nullable enable
using System;
using Image.ML.WPF.Commands.Base;

namespace Image.ML.WPF.Commands
{
    public class LambdaCommand : Command
    {
        private readonly Action<object?> _Execute;
        private readonly Func<object?, bool>? _CanExecute;

        public LambdaCommand(Action Execute, Func<bool>? CanExecute = null)
            :this(
                Execute is { } execute ? _ => execute() : throw new ArgumentNullException(nameof(Execute)), 
                CanExecute is { } can_execute ? _ => can_execute() : null)
        {
            
        }

        public LambdaCommand(Action<object?> Execute, Func<bool> CanExecute)
            :this(Execute, _ => CanExecute())
        {
            
        }

        public LambdaCommand(Action<object?> Execute, Func<object?, bool>? CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        protected override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;

        protected override void Execute(object? parameter) => _Execute(parameter);
    }
}
