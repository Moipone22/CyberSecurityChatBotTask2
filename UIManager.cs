using System;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    public class UIManager
    {
        public void DisplayAsciiArt()
        {
            string asciiArt = @"
╔══════════════════════════════════════════════════════════════════════════════╗
║                                                                              ║
║      ██████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗  ██████╗ ████████╗  ║
║     ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝  ║
║     ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ██████╔╝██║   ██║   ██║     ║
║     ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ██╔══██╗██║   ██║   ██║     ║
║     ╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ██████╔╝╚██████╔╝   ██║     ║
║      ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝    ╚═╝     ║
║                                                                              ║
║                    █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗                ║
║                   ██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝                ║
║                   ███████║██║ █╗ ██║███████║██████╔╝█████╗                  ║
║                   ██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝                  ║
║                   ██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████╗                ║
║                   ╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝                ║
║                                                                              ║
║                                                                              ║
║            C Y B E R S E C U R I T Y   A W A R E N E S S   B O T            ║
║                                                                              ║
╚══════════════════════════════════════════════════════════════════════════════╝
";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

        public void DisplayWelcomeBorder()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("  🔒 WELCOME TO THE CYBERSECURITY AWARENESS BOT 🔒");
            Console.WriteLine("  Your personal guide to staying safe online!");
            Console.WriteLine(new string('=', 70));

            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public void DisplayPersonalizedWelcome(string userName)
        {
            DisplaySectionHeader("PERSONALIZED GREETING");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n✨ Hello {userName}! ✨");
            Console.ResetColor();

            Console.WriteLine("I'm here to help you learn about online safety practices.");
            Console.WriteLine("Feel free to ask me about passwords, phishing, safe browsing, and more!\n");

            DisplaySeparator();
        }

        public void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"\n╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  ★ {title} ★".PadRight(63) + "║");
            Console.WriteLine($"╚════════════════════════════════════════════════════════════════╝");

            Console.ResetColor();
        }

        public void DisplaySeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('─', 70));
            Console.ResetColor();
        }

        public void DisplayHelpMessage()
        {
            DisplaySectionHeader("HELP & TOPICS");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  📚 You can ask me about:");
            Console.WriteLine("     • Password safety");
            Console.WriteLine("     • Phishing attacks");
            Console.WriteLine("     • Safe browsing habits");
            Console.WriteLine("\n     💬 Or ask 'How are you?' or 'What is your purpose?'");
            Console.WriteLine("     🚪 Type 'exit' or 'goodbye' to leave.");
            Console.ResetColor();

            DisplaySeparator();
        }

        public void DisplayPrompt(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n[{userName}] ➜ ");
            Console.ResetColor();
        }

        public void DisplayBotResponse(string response)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n[BOT] ➜ ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;

            int maxWidth = 80;

            if (response.Length <= maxWidth)
            {
                Console.WriteLine(response);
            }
            else
            {
                string[] words = response.Split(' ');
                string line = "";

                foreach (string word in words)
                {
                    // keep the original word-wrap behavior
                    if ((line + word).Length > maxWidth)
                    {
                        Console.WriteLine(line);
                        line = word + " ";
                    }
                    else
                    {
                        line += word + " ";
                    }
                }

                Console.WriteLine(line);
            }

            Console.ResetColor();
        }

        public void DisplayColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public void DisplayTypingEffect()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write("\n[BOT is typing");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }

            Console.WriteLine("]");
            Console.ResetColor();

            Thread.Sleep(200);
        }

        public void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {message}");
            Console.ResetColor();
        }

        public void DisplayWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[⚠️] {message}");
            Console.ResetColor();
        }

        public void DisplayExitMessage(string userName)
        {
            DisplaySectionHeader("GOODBYE");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  👋 Goodbye {userName}! Stay safe online! 👋");
            Console.WriteLine("  Remember: Strong passwords + 2FA = Better Security!");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Thank you for using Cybersecurity Awareness Bot!");
            Console.WriteLine("  Keep learning and stay protected! 🔒");
            Console.ResetColor();

            DisplaySeparator();
            Thread.Sleep(1500);
        }
    }
}