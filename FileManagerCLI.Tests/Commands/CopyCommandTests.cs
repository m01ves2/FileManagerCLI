using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Tests.Commands
{
    public class CopyCommandTests : IDisposable
    {
        private readonly string _tempDir;

        public CopyCommandTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
        }

        [Fact]
        public void CopyCommand_Should_Return_Error_If_Missing_Args()
        {
            var cmd = new CopyCommand(new FileService(), new DirectoryService());
            var result = cmd.Execute(new CommandContext(), Array.Empty<string>());

            Assert.Equal(CommandStatus.Error, result.Status);
            Assert.Contains("required", result.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void CopyCommand_Should_Copy_File_Successfully()
        {
            // Arrange
            string source = Path.Combine(_tempDir, "source.txt");
            string destination = Path.Combine(_tempDir, "dest.txt");
            File.WriteAllText(source, "test data");

            var cmd = new CopyCommand(new FileService(), new DirectoryService());

            // Act
            var result = cmd.Execute(new CommandContext(), new[] { source, destination });

            // Assert
            Assert.Equal(CommandStatus.Success, result.Status);
            Assert.True(File.Exists(destination));
            Assert.Equal("test data", File.ReadAllText(destination));
        }

        public void Dispose()
        {
            if (Directory.Exists(_tempDir))
                Directory.Delete(_tempDir, true);
        }
    }
}
