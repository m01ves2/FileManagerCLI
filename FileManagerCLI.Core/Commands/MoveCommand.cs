using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    internal class MoveCommand : ICommand
    {
        public string Name => "move";
        public string Description => "Move file or directory";
        public CommandResult Execute(CommandContext context, string[] args)
        {
            try {               
                if (args.Length < 2)
                    return new CommandResult { Success = false, Message = "Source and Destination paths required" };

                string source = args[0];
                string destination = args[1];

                bool isFile = ((ICommand)this).IsFile(source);

                if (isFile) {
                    (new FileService()).MoveFile(source, destination);
                }
                else {
                    (new DirectoryService()).MoveDirectory(source, destination);
                }

                return new CommandResult { Success = true, Message = $"Moved to {destination}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }
        }
    }
}
