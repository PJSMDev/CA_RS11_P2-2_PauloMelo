using System;

namespace UserManagementLibrary.Utility
{
    public static class ConsoleUtility
    {
        public static void SetUnicodeConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public static void WriteTitle(string title, ConsoleColor titleColor = ConsoleColor.Green, string beginTitle = "", string endTitle = "")
        {
            Console.ForegroundColor = titleColor;
            Console.Write(beginTitle);
            Console.WriteLine(new string('-', title.Length));
            Console.WriteLine(title.ToUpper());
            Console.WriteLine(new string('-', title.Length));
            Console.Write(endTitle);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void WriteMessage(string message, ConsoleColor messageColor = ConsoleColor.White, string beginMessage = "", string endMessage = "")
        {
            Console.ForegroundColor = messageColor;
            Console.Write($"{beginMessage}{message}{endMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void TerminateConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n\n\nPress any key to exit.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        public static void PauseConsole()
        {
            Console.Clear();  // Limpa o console para preparar o próximo menu
            Console.ForegroundColor = ConsoleColor.Red;
            WriteMessage("\nPress any key to continue...", ConsoleColor.Red);  // Mensagem em vermelho
            Console.ReadKey();  // Aguarda uma tecla
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;  // Restaura a cor padrão
        }

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }
    }
}
