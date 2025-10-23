using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Tests.Commands
{
    public class UnknownCommandTests
    {
        [Fact]
        public void UnknownCommand_Should_Return_Error_Status()
        {
            var cmd = new UnknownCommand("", new FileService(), new DirectoryService());
            var result = cmd.Execute(new CommandContext(), Array.Empty<string>());

            Assert.Equal(CommandStatus.Error, result.Status);
        }
    }
}
