using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Commands
{
    public class ExitCommand : BaseCommand
    {
        public override string Name => "exit";
        public override string Description => "Close application";

        public ExitCommand(IFileService fileService, IDirectoryService directoryService) : base(fileService, directoryService)
        {
        }

        public override CommandResult Execute(CommandContext context, string[] args)
        {
            return new CommandResult() { Status = CommandStatus.Exit, Message = "Exiting..." };
        }
    }
}
