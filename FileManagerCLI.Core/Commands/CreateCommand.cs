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
                if (args.Where(t => !t.StartsWith('-')).Count() < 1)
                    return new CommandResult { Success = false, Message = "Source path required" };

                IEnumerable<string> commandKeys = args.Where(t => t.StartsWith('-'));
                string source = args.Where(t => !t.StartsWith('-')).FirstOrDefault() ?? "";

                bool isFile = !(commandKeys.Contains("-d") || commandKeys.ElementAt(0).Contains('d'));

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
