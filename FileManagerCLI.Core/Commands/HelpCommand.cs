using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using System.Text;

namespace FileManagerCLI.Core.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name => "help";
        public string Description => "Displays a list of available commands.";

        public CommandResult Execute(CommandContext context, string[] args)
        {
            StringBuilder sb = new StringBuilder(); //TODO get command list from App-layer/Register
            sb.Append("Available commands:");
            sb.Append("ls       - List directory contents");
            sb.Append("cd       - Change directory");
            sb.Append("cp       - Copy file or directory");
            sb.Append("rm       - Remove file or directory");
            sb.Append("help     - Show this help message");
            sb.Append("exit     - Exit the program");

            return new CommandResult() { Success = true, Message = sb.ToString() };
        }
    }
}
