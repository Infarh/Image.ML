using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image.ML.WPF.Services.Interfaces
{
    public interface IUserDialog
    {
        FileInfo? SelectFile(string Title, string? Filter = "Все файлы (*.*)|*.*", string? DefaultPath = null);
        string? GetString(string Title, string? Default = null, string Message = "Введите текст");
    }
}
