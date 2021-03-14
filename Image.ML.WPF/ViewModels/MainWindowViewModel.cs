using Image.ML.WPF.Services.Interfaces;

namespace Image.ML.WPF.ViewModels.Base
{
    public class MainWindowViewModel : TitledViewModel
    {
        private IUserDialog UserDialog { get; }

        public MainWindowViewModel(IUserDialog UserDialog)
        {
            Title = "Машинное обучение";
            this.UserDialog = UserDialog;
        }
    }
}
