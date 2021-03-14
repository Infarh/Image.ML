using System;
using System.Windows.Input;
using Image.ML.WPF.Commands;
using Image.ML.WPF.Commands.Base;
using Image.ML.WPF.Infrastructure;

namespace Image.ML.WPF.ViewModels.Base
{
    public abstract class DialogViewModel : TitledViewModel
    {
        public event EventHandler<EventArgs<bool?>>? Completed;
        protected virtual void OnCompleted(bool? completed = null) => Completed?.Invoke(this, completed);

        #region Command CompleteCommand - Завершение диалога

        /// <summary>Завершение диалога</summary>
        private LambdaCommand? _CompleteCommand;

        /// <summary>Завершение диалога</summary>
        public ICommand CompleteCommand => _CompleteCommand ??= Command.On(OnCompleteCommandExecuted, CanCompleteCommandExecute);

        /// <summary>Проверка возможности выполнения - Завершение диалога</summary>
        protected virtual bool CanCompleteCommandExecute(object? p) => true;

        /// <summary>Логика выполнения - Завершение диалога</summary>
        protected virtual void OnCompleteCommandExecuted(object? p) =>
            OnCompleted(p switch
            {
                null => null,
                bool result => result,
                _ => Convert.ToBoolean(p)
            });

        #endregion

        #region Command OkCommand - Подтверждение

        /// <summary>Подтверждение</summary>
        private LambdaCommand? _OkCommand;

        /// <summary>Подтверждение</summary>
        public ICommand OkCommand => _OkCommand ??= Command.On(OnOkCommandExecuted, CanOkCommandExecute);

        /// <summary>Проверка возможности выполнения - Подтверждение</summary>
        protected virtual bool CanOkCommandExecute() => true;

        /// <summary>Логика выполнения - Подтверждение</summary>
        protected virtual void OnOkCommandExecuted() => OnCompleteCommandExecuted(true);

        #endregion

        #region Command CancelCommand - Подтверждение

        /// <summary>Подтверждение</summary>
        private LambdaCommand? _CancelCommand;

        /// <summary>Подтверждение</summary>
        public ICommand CancelCommand => _CancelCommand ??= Command.On(OnCancelCommandExecuted, CanCancelCommandExecute);

        /// <summary>Проверка возможности выполнения - Подтверждение</summary>
        protected virtual bool CanCancelCommandExecute() => true;

        /// <summary>Логика выполнения - Подтверждение</summary>
        protected virtual void OnCancelCommandExecuted() => OnCompleteCommandExecuted(false);

        #endregion
    }
}
