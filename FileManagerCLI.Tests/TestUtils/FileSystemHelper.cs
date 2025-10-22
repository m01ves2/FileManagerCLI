using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Tests.TestUtils
{
    public static class FileSystemHelper
    {
        public static string CreateTempFile(string content = "")
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, content);
            return path;
        }

        public static string CreateTempDir()
        {
            string dir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(dir);
            return dir;
        }
    }
}
