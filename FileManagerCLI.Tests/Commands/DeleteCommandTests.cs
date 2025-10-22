using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Tests.Commands
{
    public class DeleteCommandTests
    {
        private readonly string _tempDir;

        public DeleteCommandTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
        }


        [Fact]
        public void DeleteCommand_Should_Delete_File_Successfully()
        {
            // Arrange
            string source = Path.Combine(_tempDir, "source.txt");
            File.WriteAllText(source, "test data");

            var cmd = new DeleteCommand(new FileService(), new DirectoryService());

            // Act
            var result = cmd.Execute(new CommandContext(), new[] { source });

            // Assert
            Assert.Equal(CommandStatus.Success, result.Status);
            Assert.True(!File.Exists(source));
        }

        [Fact]
        public void DeleteCommand_Should_Delete_Directory_Successfully()
        {
            // Arrange
            string source = Path.Combine(_tempDir, "newDir");
            Directory.CreateDirectory(source);

            var cmd = new DeleteCommand(new FileService(), new DirectoryService());

            // Act
            var result = cmd.Execute(new CommandContext(), new[] { source });

            // Assert
            Assert.Equal(CommandStatus.Success, result.Status);
            Assert.True(!Directory.Exists(source));
        }

        public void Dispose()
        {
            if (Directory.Exists(_tempDir))
                Directory.Delete(_tempDir, true);
        }
    }
}
