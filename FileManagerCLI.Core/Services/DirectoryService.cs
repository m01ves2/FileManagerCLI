using FileManagerCLI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//реализация работы с файлами и каталогами.
namespace FileManagerCLI.Core.Services
{
    public class DirectoryService : IDirectoryService
    {
        public void CopyDirectory(string source, string destination)
        {
            Directory.CreateDirectory(destination);

            foreach (var file in Directory.GetFiles(source))
                File.Copy(file, Path.Combine(destination, Path.GetFileName(file)), true);

            foreach (var dir in Directory.GetDirectories(source))
                CopyDirectory(dir, Path.Combine(destination, Path.GetFileName(dir)));
        }

        public void CreateDirectory(string path) => Directory.CreateDirectory(path);

        public void DeleteDirectory(string path) => Directory.Delete(path, true);

        public string[] ListDirectory(string path) => Directory.GetFileSystemEntries(path);

        public void MoveDirectory(string source, string destination) => Directory.Move(source, destination);
    }
}
