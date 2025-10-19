using FileManagerCLI.Core.Infrastructure;
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
        public CommandResult Execute(CommandContext context, string[] args)
        {
            try {

                string source = ".";
                if (args.Where(t => !t.StartsWith('-')).Count() > 0)
                    source = args.Where(t => !t.StartsWith("-")).FirstOrDefault() ?? ".";

                string commandKeys = args.Where(t => t.StartsWith('-')).FirstOrDefault() ?? "";
                //var path = args.FirstOrDefault() ?? context.CurrentDirectory;

                bool isFile = ((ICommand)this).IsFile(source);

                if (isFile) {
                    FileInfo fileInfo = (new FileService()).GetFileInfo(source);
                    return new CommandResult()
                    {
                        Success = true,
                        Message = $"{fileInfo.CreationTime}\t{fileInfo.Attributes}\t{fileInfo.Length}"
                    };
                }
                else {
                    string[] items = (new DirectoryService()).ListDirectory(source);
                    StringBuilder sb = new StringBuilder();
                    foreach (string i in items) {
                        sb.Append(i + "\n");
                    }
                    return new CommandResult() { Success = true, Message = sb.ToString() };
                }

            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }
    }
}