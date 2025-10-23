﻿using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;

namespace FileManagerCLI.Core.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        protected readonly IFileService _fileService;
        protected readonly IDirectoryService _directoryService;

        public BaseCommand(IFileService fileService, IDirectoryService directoryService)
        {
            _fileService = fileService;
            _directoryService = directoryService;
        }
        
        protected (IEnumerable<string> commandKeys, string source, string destination) ParseArgs(string[] args)
        {
            IEnumerable<string> commandKeys = args.Where(t => t.StartsWith('-'));
            var positionalArgs = args.Where(t => !t.StartsWith('-')).ToArray();
            string source = positionalArgs.ElementAtOrDefault(0) ?? "";
            string destination = positionalArgs.ElementAtOrDefault(1) ?? "";

            return (commandKeys, source, destination);
        }

        public abstract CommandResult Execute(CommandContext context, string[] args);
    }
}
