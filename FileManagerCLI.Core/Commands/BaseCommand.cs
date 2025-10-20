using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Core.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        protected IFileService _fileService;
        protected IDirectoryService _directoryService;

        public BaseCommand(IFileService fileService, IDirectoryService directoryService)
        {
            _fileService = fileService;
            _directoryService = directoryService;
        }

        public abstract CommandResult Execute(CommandContext context, string[] args);
    }
}
