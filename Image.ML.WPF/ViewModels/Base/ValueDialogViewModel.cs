namespace Image.ML.WPF.ViewModels.Base
{
    public class ValueDialogViewModel<T> : DialogViewModel
    {
        #region Value : string - Значение

        /// <summary>Значение</summary>
        private T? _Value;

        /// <summary>Значение</summary>
        public T? Value { get => _Value; set => Set(ref _Value, value); }

        #endregion
    }
}
