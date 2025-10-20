using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using System.Text;

namespace FileManagerCLI.Core.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name => "help";
        public string Description => "Displays a list of available commands.";

        private List<ICommand> _commands;

        public HelpCommand(List<ICommand> commands) 
        { 
            _commands = commands;
        }

        public CommandResult Execute(CommandContext context, string[] args)
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
