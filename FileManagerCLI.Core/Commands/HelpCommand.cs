using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Services;
using System.Text;

namespace FileManagerCLI.Core.Commands
{
    public class HelpCommand : BaseCommand
    {
        public override string Name => "help";
        public override string Description => "Displays a list of available commands.";

        private List<ICommand> _commands;

        public HelpCommand(List<ICommand> commands, IFileService fileService, IDirectoryService directoryService) : base(fileService, directoryService)
        {
            _commands = commands;
        }

        public override CommandResult Execute(CommandContext context, string[] args)
        {          
            StringBuilder sb = new StringBuilder();
            sb.Append("--help: \n");
            foreach (var item in _commands) {
                sb.Append(item.Name + " - " + item.Description + "\n");
            }
            return new CommandResult() { Success = true, Message = sb.ToString() };
        }
    }
}
