using System;

namespace CybersecurityAwarenessBot
{
    public class Chatbot
    {
        private string userName;
        private bool isRunning;

        private ResponseManager responseManager;
        private UIManager uiManager;
        private AudioManager audioManager;

        private int invalidInputCount;

        public Chatbot()
        {
            responseManager = new ResponseManager();
            uiManager = new UIManager();
            audioManager = new AudioManager();

            isRunning = true;
            invalidInputCount = 0;
        }

        public void Run()
        {
            try
            {
                audioManager.PlayGreeting();

                uiManager.DisplayAsciiArt();
                uiManager.DisplayWelcomeBorder();

                GetUserName();
                uiManager.DisplayPersonalizedWelcome(userName);

                MainChatLoop();

                uiManager.DisplayExitMessage(userName);
            }
            catch (Exception ex)
            {
                uiManager.DisplayErrorMessage($"Unexpected error: {ex.Message}");
                uiManager.DisplayColoredText("\nThe bot will exit. Please restart.\n", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        private void GetUserName()
        {
            uiManager.DisplayColoredText("\n[?] May I have your name? ", ConsoleColor.Cyan);
            userName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userName))
            {
                uiManager.DisplayColoredText("[!] I didn't catch that. Please enter your name: ", ConsoleColor.Yellow);
                userName = Console.ReadLine();
            }

            userName = CapitalizeName(userName);
        }

        private string CapitalizeName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            if (name.Length == 1) return name.ToUpper();

            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        private void MainChatLoop()
        {
            uiManager.DisplayHelpMessage();

            while (isRunning)
            {
                try
                {
                    uiManager.DisplayPrompt(userName);
                    string userInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        HandleEmptyInput();
                        continue;
                    }

                    invalidInputCount = 0;

                    string response = ProcessUserInput(userInput);
                    uiManager.DisplayTypingEffect();
                    uiManager.DisplayBotResponse(response);
                }
                catch (Exception ex)
                {
                    uiManager.DisplayErrorMessage($"Error: {ex.Message}");
                    uiManager.DisplayColoredText("I'm still here! Let's continue.\n", ConsoleColor.Yellow);
                }
            }
        }

        private void HandleEmptyInput()
        {
            invalidInputCount++;

            uiManager.DisplayWarningMessage("Please type something. I'd love to chat with you!");

            if (invalidInputCount >= 3)
            {
                uiManager.DisplayColoredText(
                    "\n[💡 Tip] Try asking me about 'passwords', 'phishing', or 'safe browsing'!\n",
                    ConsoleColor.Cyan
                );

                invalidInputCount = 0;
            }
        }

        private string ProcessUserInput(string input)
        {
            string lowerInput = input.ToLower().Trim();

            if (IsExitCommand(lowerInput))
            {
                isRunning = false;
                return "Thank you for chatting with me! Stay safe online! 🔒";
            }

            if (IsHelpCommand(lowerInput))
            {
                uiManager.DisplayHelpMessage();
                return "Here are some topics you can ask me about! What would you like to know?";
            }

            string response = responseManager.GetResponse(input);
            return response.Replace("{user}", userName);
        }

        private bool IsExitCommand(string text)
        {
            return text == "exit" || text == "quit" || text == "goodbye" || text == "bye";
        }

        private bool IsHelpCommand(string text)
        {
            return text == "help" || text == "what can i ask" || text == "commands";
        }
    }
}