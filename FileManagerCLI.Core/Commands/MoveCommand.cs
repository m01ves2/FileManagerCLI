using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class MoveCommand : ICommand
    {
        public string Name => "move";
        public string Description => "Move file or directory";
        public CommandResult Execute(CommandContext context, string[] args)
        {
            try {               
              
                if (args.Where(t => !t.StartsWith('-')).Count() < 2)
                    return new CommandResult { Success = false, Message = "Source and Destination paths required" };

                IEnumerable<string> keysCommand = args.Where(t => t.StartsWith('-'));
                string source = args.Where(t => !t.StartsWith('-')).ElementAt(0);
                string destination = args.Where(t => !t.StartsWith('-')).ElementAt(1);

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
