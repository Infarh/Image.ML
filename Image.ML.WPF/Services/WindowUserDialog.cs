using System.IO;

using Image.ML.WPF.Services.Interfaces;
using Image.ML.WPF.ViewModels;
using Image.ML.WPF.Views;
using Microsoft.Win32;

namespace Image.ML.WPF.Services
{
    public class WindowUserDialog : IUserDialog
    {
        public FileInfo? SelectFile(string Title, string? Filter = "Все файлы (*.*)|*.*", string? DefaultPath = null)
        {
            var dialog = new OpenFileDialog
            {
                Title = Title,
                Filter = Filter is { Length: > 0 } ? Filter : "Все файлы (*.*)|*.*",
            };
            if (DefaultPath is { Length: > 0 })
                dialog.Filter = DefaultPath;

            return dialog.ShowDialog(App.CurrentWindow) is true 
                ? new(dialog.FileName) 
                : null;
        }

        public string? GetString(string Title, string? Default = null, string Message = "Введите текст")
        {
            var dialog_model = new StringDialogViewModel
            {
                Title = Title,
                Message = Message,
                Value = Default,
            };
            var dialog = new StringDialog
            {
                DataContext = dialog_model,
                Owner = App.CurrentWindow,
            };
            dialog_model.Completed += (_, e) =>
            {
                dialog.DialogResult = e;
                dialog.Close();
            };
            return dialog.ShowDialog() is true 
                ? dialog_model.Value 
                : Default;
        }
    }
}
