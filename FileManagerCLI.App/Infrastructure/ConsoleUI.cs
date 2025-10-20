using FileManagerCLI.App.Interfaces;
using FileManagerCLI.Core.Infrastructure;
using System.Text;

namespace FileManagerCLI.App.Infrastructure
{
    //вывод текста, ошибок, меню - создаёт команды из текста (связывает App и Core)
    internal class ConsoleUI : IUI
    {
        public void PrintResult(CommandResult commandResult)
        {
            Console.WriteLine(commandResult.Message);
        }

        public string ReadInput(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(prompt);
            Console.ResetColor();

            string input = (Console.ReadLine() ?? "").Trim().ToLower();
            return input;
        }
    }

}
