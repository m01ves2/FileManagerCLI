using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Infrastructure
{
    //универсальный результат выполнения команды (успех/ошибка, сообщение, данные). Мост между Core и App.
    public class CommandResult
    {
        public bool Success { get; set; } //команда выполнилась или нет.
        public string Message { get; set; } = string.Empty; //текстовое сообщение для App (UI).
        // при необходимости можно добавить данные, например, список файлов
        public object? Data { get; set; } //если команда возвращает что-то, например, список файлов (List<FileItem>).
    }
}
