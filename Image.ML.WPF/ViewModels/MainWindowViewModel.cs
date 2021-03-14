namespace Image.ML.WPF.ViewModels.Base
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок

        /// <summary>Заголовок</summary>
        private string _Title = "Машинное обучение";

        /// <summary>Заголовок</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion
    }
}
