using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Infrastructure
{
    public class CommandContext
    {
        public string CurrentDirectory { get; set; } = Directory.GetCurrentDirectory();
    }
}
