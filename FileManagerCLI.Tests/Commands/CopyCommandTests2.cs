using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Tests.TestUtils;

namespace FileManagerCLI.Tests.Commands
{
    public class CopyCommandTests2
    {
        [Fact]
        public void CopyCommand_Should_Copy_File_Using_Fake_Services()
        {
            // Arrange
            var fileService = new FakeFileService();
            var dirService = new FakeDirectoryService();
            var cmd = new CopyCommand(fileService, dirService);

            fileService.CreateFile("source.txt");

            // Act
            var result = cmd.Execute(new CommandContext(), new[] { "source.txt", "dest.txt" });

            // Assert
            Assert.Equal(CommandStatus.Success, result.Status);
            Assert.True(fileService.Exists("dest.txt"));
            Assert.Equal("Hello, world!", fileService.Read("dest.txt"));
        }
    }
}