using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using FileManagerCLI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Commands
{
    internal class HelpCommand
    {
        public string Name => "help";
        public string Description => "Displays a list of available commands.";

        public void Execute(string[] args)
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("ls       - List directory contents");
            Console.WriteLine("cd       - Change directory");
            Console.WriteLine("cp       - Copy file or directory");
            Console.WriteLine("rm       - Remove file or directory");
            Console.WriteLine("help     - Show this help message");
            Console.WriteLine("exit     - Exit the program");
        }
    }
}
