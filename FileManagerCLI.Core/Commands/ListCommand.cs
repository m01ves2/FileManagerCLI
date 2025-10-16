using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;
using System.Text;

namespace FileManagerCLI.Core.Commands
{
    //команды не являются сущностями, но живут в Core, потому что реализуют бизнес-логику работы с сущностями
    public class ListCommand : ICommand
    {
        public string Name => "list";
        public string Description => "List files and folders in a directory";

        public CommandResult Execute(IItem item, string[] args)
        {
            try {
                if (item is FileItem) {
                    FileInfo fileInfo = (new FileService()).GetFileInfo(item.Path);
                    return new CommandResult() { 
                        Success = true, 
                        Message = $"{fileInfo.CreationTime}\t{fileInfo.Attributes}\t{fileInfo.Length}" };        
                }
                else if(item is DirectoryItem) {
                    string[] items = (new DirectoryService()).ListDirectory(item.Path);
                    StringBuilder sb = new StringBuilder();
                    foreach(string i in items) {
                        sb.Append(i + "\n");
                    }
                    return new CommandResult() { Success = true, Message = sb.ToString() };
                }
                else {
                    return new CommandResult { Success = false, Message = "Unknown item type" };
                }
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }

        //public ListCommand(IFileService fileService)
        //{
        //    _fileService = fileService;
        //}

        //public void Execute(string[] args)
        //{
        //    var path = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
        //    var items = _fileService.ListDirectory(path);
        //    foreach (var item in items) {
        //        Console.WriteLine(item);
        //    }
        //}

        //void Execute(IItem item, params string[] args);
        //void Execute(IItem source, IItem? destination = null);

    }
}