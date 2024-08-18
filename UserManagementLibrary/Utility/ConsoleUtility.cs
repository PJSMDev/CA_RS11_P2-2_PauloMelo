using System;

namespace UserManagementLibrary.Utility
{

    /// <summary>
    /// Provides utility methods for console operations.
    /// </summary>
    public static class ConsoleUtility
    {

        #region Console Output Methods 

        /// <summary>
        /// Sets up the terminal for UTF8 encoding.
        /// </summary>
        public static void SetUnicodeConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// Writes a title to the console.
        /// </summary>
        /// <param name="title">The title to write.</param>
        /// <param name="titleColor">The color of the title.</param>
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

        /// <summary>
        /// Writes a message to the console with a specific color.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="messageColor">The color of the message.</param>
        /// <param name="beginMessage">Text to prepend before the message.</param>
        /// <param name="endMessage">Text to append after the message.</param>
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

        /// <summary>
        /// Pauses the console until a key is pressed.
        /// </summary>
        public static void PauseConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteMessage("\nPress any key to continue...", ConsoleColor.Red);  // Mensagem em vermelho
            Console.ReadKey();  // Aguarda uma tecla
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;  // Restaura a cor padrão
        }


        /// <summary>
        /// Reads a password from the console without displaying it.
        /// </summary>
        /// <returns>The password entered by the user.</returns>
        /// <remarks>This soluion was found online and used as it.</remarks>
        /// <seealso href="https://stackoverflow.com/questions/29201697/hide-replace-when-typing-a-password-c"/>
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

        #endregion
    }
}
