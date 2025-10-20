using FileManagerCLI.App.Interfaces;
using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.App.Infrastructure
{
    //вывод текста, ошибок, меню - создаёт команды из текста (связывает App и Core)
    internal class ConsoleUI
    {
        private readonly ICommandHandler _commandHandler;

        public ConsoleUI(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        internal void Start()
        {
            CommandParser parser = new CommandParser();

            PrintMenu();
            while (true) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(_commandHandler.GetCLIPrompt());
                Console.ResetColor();

                string input = (Console.ReadLine() ?? "").Trim().ToLower();

                if (string.IsNullOrEmpty(input)) {
                    continue;
                }
                else if (input.Equals("exit")) {
                    break;
                }
                else if (input.Equals("help")) {
                    PrintMenu();
                    continue;
                }

                    string result = _commandHandler.Execute(input).Message;

                Console.WriteLine(result);
            }
        }

        private void PrintMenu()
        {
            StringBuilder sb = new StringBuilder(); //TODO get command list from App-layer/Register
            sb.Append("Available commands:\n");
            sb.Append("ls       - List directory contents\n");
            sb.Append("cd       - Change directory\n");
            sb.Append("cp       - Copy file or directory\n");
            sb.Append("rm       - Remove file or directory\n");
            sb.Append("help     - Show this help message\n");
            sb.Append("exit     - Exit the program\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
         
        }
    }

}
