using FileManagerCLI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Models
{
    public class FileItem : IItem
    {
        public string Path { get; }
        public string Name => System.IO.Path.GetFileName(Path);

        public FileItem(string path) => Path = path;
        public bool Exists() => File.Exists(Path);
    }
}
