using Image.ML.WPF.ViewModels.Base;

namespace Image.ML.WPF.ViewModels
{
    public class StringDialogViewModel : ValueDialogViewModel<string>
    {
        #region Message : string - Сообщение

        /// <summary>Сообщение</summary>
        private string _Message = "Введите текст";

        /// <summary>Сообщение</summary>
        public string Message { get => _Message; set => Set(ref _Message, value); }

        #endregion

    }
}
