using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public class CreateCommand : ICommand
    {
        public string Name => "create";
        public string Description => "Creates file or directory";

        public CommandResult Execute(CommandContext context, string[] args)
        {
            try {
                if (args.Length < 1)
                    return new CommandResult { Success = false, Message = "Source path required" };

                string source = args[0];

                bool isFile = ((ICommand)this).IsFile(source);

                if (isFile) {
                    (new FileService()).CreateFile(source);
                }
                else {
                    (new DirectoryService()).CreateDirectory(source);
                }

                return new CommandResult { Success = true, Message = $"Created {source}" };
            }
            catch (Exception ex) {
                return new CommandResult { Success = false, Message = ex.Message };
            }

        }
    }
}
