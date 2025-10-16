using FileManagerCLI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Services
{
    public class FileService : IFileService
    {
        public void CreateFile(string path) => File.Create(path).Dispose();

        public void DeleteFile(string path) => File.Delete(path);

        public void CopyFile(string source, string destination) => File.Copy(source, destination, true);

        public void MoveFile(string source, string destination) => File.Move(source, destination);

        public FileInfo GetFileInfo(string path) => new FileInfo(path);
    }
}
