using System;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            // Try to resize the console (some terminals may block this)
            try
            {
                Console.SetWindowSize(120, 50);
            }
            catch
            {
                // ignore if resizing isn't supported
            }

            try
            {
                var bot = new Chatbot();
                bot.Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nFATAL ERROR: {ex.Message}");
                Console.WriteLine("Please restart the application.");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}