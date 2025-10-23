using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Services;

namespace FileManagerCLI.Tests.Commands
{
    public class CreateCommandTests : IDisposable
    {
        private readonly string _tempDir;

        public CreateCommandTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
        }


        [Fact]
        public void CreateCommand_Should_Create_File_Successfully()
        {
            // Arrange
            string source = Path.Combine(_tempDir, "source.txt");
            var cmd = new CreateCommand(new FileService(), new DirectoryService());

            // Act
            var result = cmd.Execute(new CommandContext(), new[] { source });
            File.WriteAllText(source, "test data");

            // Assert
            Assert.Equal(CommandStatus.Success, result.Status);
            Assert.True(File.Exists(source));
            Assert.Equal("test data", File.ReadAllText(source));
        }

        [Fact]
        public void CreateCommand_Should_Create_Directory_Successfully()
        {
            // Arrange
            string source = Path.Combine(_tempDir, "source");

            var cmd = new CreateCommand(new FileService(), new DirectoryService());

            // Act
            var result = cmd.Execute(new CommandContext(), new[] { "-d", source });

            // Assert
            Assert.Equal(CommandStatus.Success, result.Status);
            Assert.True(Directory.Exists(source));
        }

        public void Dispose()
        {
            if (Directory.Exists(_tempDir))
                Directory.Delete(_tempDir, true);
        }
    }
}
