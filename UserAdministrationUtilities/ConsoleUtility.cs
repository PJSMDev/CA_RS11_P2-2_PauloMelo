namespace UserAdministrationUtilities
{

    /// <summary>
    /// Provides utility methods for console interactions.
    /// </summary>
    public class ConsoleUtility
    {

        /// <summary>
        /// Sets the console output encoding to UTF-8 to support Unicode characters.
        /// </summary>
        public static void SetUnicodeConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// Writes a formatted title to the console.
        /// </summary>
        /// <param name="title">The title text to display.</param>
        /// <param name="beginTitle">Text to prepend to the title.</param>
        /// <param name="endTitle">Text to append to the title.</param>
        public static void WriteTitle(string title, string beginTitle = "", string endTitle = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(new string('-', title.Length));

            Console.Write(beginTitle);

            Console.WriteLine(title.ToUpper());

            Console.WriteLine(new string('-', title.Length));

            Console.Write(endTitle);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }

        /// <summary>
        /// Writes a message to the console with optional prepended and appended text.
        /// </summary>
        /// <param name="message">The message text to display.</param>
        /// <param name="beginMessage">Text to prepend to the message.</param>
        /// <param name="endMessage">Text to append to the message.</param>
        public static void WriteMessage(string message, string beginMessage = "", string endMessage = "")
        {
            Console.Write($"{beginMessage}{message}{endMessage}");
        }

        /// <summary>
        /// Prompts the user to press a key to terminate the console application.
        /// </summary>
        public static void TerminateConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("\n\n\n\nPrime qualquer tecla para terminar.");

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();

            Console.Clear();
        }

        /// <summary>
        /// Pauses the console application and waits for the user to press any key.
        /// </summary>
        public static void PauseConsole()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            WriteMessage("\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            /*
             * ainda não sei se vou querer isto aqui
            Console.Clear();
            */
        }

        /// <summary>
        /// Reads a password input from the user without displaying it on the screen.
        /// </summary>
        /// <returns>The password entered by the user.
        /// </returns>
        /// <remarks>This method was searched for online and integrated in the library as was.</remarks>
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
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }
    }
}
