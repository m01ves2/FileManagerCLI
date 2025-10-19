using FileManagerCLI.App.Infrastructure;

namespace FileManagerCLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleUI consoleUI = new ConsoleUI();
            consoleUI.Start();
        }
    }
}