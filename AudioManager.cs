using System;
using System.IO;
using System.Media;

namespace CybersecurityAwarenessBot
{
    public class AudioManager
    {
        public void PlayGreeting()
        {
            try
            {
                string audioPath = FindGreetingFile();

                if (audioPath == null)
                {
                    Console.WriteLine("[Audio] Greeting file 'chatbot.wav' not found. Continuing in text-only mode.");
                    return;
                }

                using (var player = new SoundPlayer(audioPath))
                {
                    player.Load();
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio] Could not play greeting: {ex.Message}");
            }
        }

        private string FindGreetingFile()
        {
            string[] possiblePaths =
            {
                "chatbot.wav",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chatbot.wav"),
                Path.Combine(Directory.GetCurrentDirectory(), "chatbot.wav")
            };

            foreach (var path in possiblePaths)
            {
                if (File.Exists(path))
                    return path;
            }

            return null;
        }
    }
}