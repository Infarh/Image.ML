using System;
using System.Linq;
using System.Windows;
using Image.ML.WPF.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Image.ML.WPF
{
    public partial class App
    {
        public static Window? FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

        public static Window? ActiveWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

        public static Window? CurrentWindow => FocusedWindow ?? ActiveWindow;

        private static IHost? __Hosting;

        public static IHost Hosting => __Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
           .CreateDefaultBuilder()
           .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<ServiceLocator>();
        }
    }
}
