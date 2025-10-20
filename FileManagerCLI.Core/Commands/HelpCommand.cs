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
            sb.AppendLine("FileManagerCLI v0.1");
            sb.AppendLine("Available commands:");
            sb.AppendLine("ls       - List directory contents");
            sb.AppendLine("cd       - Change directory");
            sb.AppendLine("cp       - Copy file or directory");
            sb.AppendLine("rm       - Remove file or directory");
            sb.AppendLine("help     - Show this help message");
            sb.AppendLine("exit     - Exit the program");

            return new CommandResult() { Success = true, Message = sb.ToString() };
        }
    }
}
