using Image.ML.WPF.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Image.ML.WPF
{
    public class ServiceLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
