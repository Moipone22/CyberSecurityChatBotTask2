using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CybersecurityAwarenessBot;

namespace CybersecurityChatbotGUI
{
    public partial class Form1 : Form
    {
        // Core services
        private ResponseManager _responseManager;
        private AudioManager _audioManager;

        // Conversation info (memory)
        private string _userName = "";
        private string _favouriteTopic = "";
        private readonly List<string> _topicsDiscussed = new List<string>();
        private readonly Dictionary<string, string> _conversationMemory = new Dictionary<string, string>();

        // Conversation state flags
        private int _invalidInputCount = 0;
        private bool _nameEntered = false;
        private bool _topicEntered = false;

        // WhatsApp-ish colors
        private readonly Color _userBubbleColor = Color.FromArgb(220, 248, 198);
        private readonly Color _botBubbleColor = Color.White;
        private readonly Color _timeStampColor = Color.FromArgb(150, 150, 150);
        private readonly Color _chatBackgroundColor = Color.FromArgb(236, 229, 221);

        public Form1()
        {
            InitializeComponent();

            _responseManager = new ResponseManager();
            _audioManager = new AudioManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAvatarImage();

            _audioManager.PlayGreeting();

            // Splash / header messages
            AddBotMessage(GetAsciiArt(), Color.Black);

            AddBotMessage(
                "🔒 WELCOME TO THE CYBERSECURITY AWARENESS BOT. YOUR PERSONAL GUIDE TO STAYING SAFE ONLINE! 🔒",
                Color.Black);

            AddBotMessage(
                "👋 Hello! I'm your Cybersecurity Awareness Bot.How can I help you stay safe online today?But first — may I please have your name? 😊",
                Color.Black);
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            if (picAvatar.Image == null)
            {
                MessageBox.Show(
                    "No profile picture found.\n\nPlace a file named 'profile.jpg' in the same folder as the application to set a profile picture.",
                    "Profile Picture",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var preview = new Form
            {
                Text = "Profile Picture",
                Size = new Size(300, 340),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(18, 140, 126)
            };

            var big = new PictureBox
            {
                Size = new Size(220, 220),
                Location = new Point(40, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = picAvatar.Image,
                BackColor = Color.FromArgb(37, 211, 102)
            };

            var title = new Label
            {
                Text = "Cybersecurity Awareness Bot",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(260, 24),
                Location = new Point(20, 255),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var subtitle = new Label
            {
                Text = "online",
                ForeColor = Color.FromArgb(200, 255, 200),
                Font = new Font("Segoe UI", 9F),
                Size = new Size(260, 20),
                Location = new Point(20, 280),
                TextAlign = ContentAlignment.MiddleCenter
            };

            preview.Controls.Add(big);
            preview.Controls.Add(title);
            preview.Controls.Add(subtitle);

            preview.ShowDialog(this);
        }

        private void btnSend_Click(object sender, EventArgs e) => SendMessage();

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            SendMessage();
        }

        private void SendMessage()
        {
            string userInput = txtInput.Text.Trim();
            txtInput.Clear();

            // 1) Empty input handling
            if (string.IsNullOrWhiteSpace(userInput))
            {
                _invalidInputCount++;
                AddBotMessage("⚠️ Please type something!", Color.Black);

                if (_invalidInputCount >= 3)
                {
                    AddBotMessage("💡 Try asking about passwords, phishing, or safe browsing!", Color.Black);
                    _invalidInputCount = 0;
                }
                return;
            }

            _invalidInputCount = 0;

            // Show the user's message
            AddUserMessage(userInput);

            // Normalize once
            string lower = userInput.ToLower().Trim();

            // 2) Ask for name
            if (!_nameEntered)
            {
                _userName = CapitalizeName(userInput);
                _nameEntered = true;

                lblStatus.Text = "🟢 " + _userName + " is chatting...";

                AddBotMessage(
                    "Hello " + _userName + "! Welcome! 👋\n\n" +
                    "What is your favourite cybersecurity topic?\n" +
                    "(e.g. phishing, passwords, safe browsing)",
                    Color.Black);

                return;
            }

            // 3) Ask for topic
            if (!_topicEntered)
            {
                _favouriteTopic = userInput;
                _topicEntered = true;

                AddBotMessage(
                    "Great! I'll remember that you're interested in " + _favouriteTopic + ". 🔒\n\n" +
                    "It's a crucial part of staying safe online!\n\n" +
                    "Feel free to ask me anything about cybersecurity!\n\n" +
                    "You can also ask me:\n" +
                    "• 'what have we talked about' — to see our conversation history\n" +
                    "• 'give me a tip' — for safety tips\n" +
                    "• 'give me an example' — for real world examples\n" +
                    "• 'give me a fun fact' — for interesting facts",
                    Color.Black);

                return;
            }

            // 4) Exit commands
            if (IsExitCommand(lower))
            {
                AddBotMessage(
                    "Goodbye " + _userName + "! Stay safe online! 🔒\n" +
                    "Remember: keep learning about " + _favouriteTopic + "!",
                    Color.Black);

                if (_topicsDiscussed.Count > 0)
                {
                    string summary = "Here is a summary of what we covered today:\n\n";
                    foreach (string topic in _topicsDiscussed)
                        summary += "✅ " + topic.ToUpper() + "\n";

                    AddBotMessage(summary, Color.Black);
                }

                btnSend.Enabled = false;
                txtInput.Enabled = false;
                lblStatus.Text = "⚫ offline";
                return;
            }

            // 5) Memory recall
            if (IsMemoryQuestion(lower))
            {
                AddBotMessage(HandleMemoryRecall(), Color.Black);
                return;
            }

            // 6) Sentiment detection (comfort + optional tip)
            string sentimentResponse = DetectSentiment(lower);
            if (sentimentResponse != null)
            {
                AddBotMessage(sentimentResponse, Color.Black);

                string sentimentTopic = DetectTopicFromInput(lower) ?? _favouriteTopic;
                if (!string.IsNullOrEmpty(sentimentTopic))
                {
                    string tip = _responseManager.GetResponse("give me a tip " + sentimentTopic);
                    tip = tip.Replace("{user}", _userName);

                    AddBotMessage(
                        "Here is something that might help you " + _userName + ":\n\n" + tip,
                        Color.Black);
                }

                AddBotMessage(
                    "Remember " + _userName + ", you are doing great by learning about cybersecurity! " +
                    "Feel free to keep asking me anything! 💪",
                    Color.Black);

                return;
            }

            // 7) Main response
            string response = _responseManager.GetResponse(userInput);
            response = response.Replace("{user}", _userName);

            // Save topic memory if we detect a known topic
            string detectedTopic = DetectTopicFromInput(lower);
            if (detectedTopic != null)
            {
                if (!_topicsDiscussed.Contains(detectedTopic))
                    _topicsDiscussed.Add(detectedTopic);

                _conversationMemory[detectedTopic] = userInput;
            }

            // Personalization: if we mention cybersecurity but user didn't ask the same topic as their preference
            if (!string.IsNullOrEmpty(_favouriteTopic) &&
                response.Contains("cybersecurity") &&
                !lower.Contains(_favouriteTopic.ToLower()))
            {
                response += "\n\n💡 As someone interested in " + _favouriteTopic +
                            ", you might want to explore that topic further too!";
            }

            AddBotMessage(response, Color.Black);
        }

        // -------------------- Chat UI --------------------

        // User bubble (right, green)
        private void AddUserMessage(string message)
        {
            string time = DateTime.Now.ToString("HH:mm");

            rtbChat.AppendText("\n");

            // Right align spacing
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;
            rtbChat.SelectionAlignment = HorizontalAlignment.Right;
            rtbChat.SelectionBackColor = _chatBackgroundColor;
            rtbChat.SelectionColor = _chatBackgroundColor;
            rtbChat.AppendText("          "); // padding indent

            // Bubble content
            rtbChat.SelectionAlignment = HorizontalAlignment.Right;
            rtbChat.SelectionBackColor = _userBubbleColor;
            rtbChat.SelectionColor = Color.Black;
            rtbChat.SelectionFont = new Font("Segoe UI", 10F);
            rtbChat.AppendText("  " + message + "  ");

            // Timestamp
            rtbChat.AppendText("\n");
            rtbChat.SelectionAlignment = HorizontalAlignment.Right;
            rtbChat.SelectionBackColor = _chatBackgroundColor;
            rtbChat.SelectionColor = _timeStampColor;
            rtbChat.SelectionFont = new Font("Segoe UI", 8F);
            rtbChat.AppendText(time + " ✓✓\n");

            // Reset
            rtbChat.SelectionAlignment = HorizontalAlignment.Left;
            rtbChat.SelectionBackColor = _chatBackgroundColor;
            rtbChat.ScrollToCaret();
        }

        // Bot bubble (left, white)
        private void AddBotMessage(string message, Color textColor)
        {
            string time = DateTime.Now.ToString("HH:mm");

            rtbChat.AppendText("\n");

            // Message bubble
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;
            rtbChat.SelectionAlignment = HorizontalAlignment.Left;
            rtbChat.SelectionBackColor = _botBubbleColor;
            rtbChat.SelectionColor = textColor;
            rtbChat.SelectionFont = new Font("Courier New", 9F, FontStyle.Bold);
            rtbChat.AppendText("  " + message + "  ");

            // Timestamp
            rtbChat.AppendText("\n");
            rtbChat.SelectionAlignment = HorizontalAlignment.Left;
            rtbChat.SelectionBackColor = _chatBackgroundColor;
            rtbChat.SelectionColor = _timeStampColor;
            rtbChat.SelectionFont = new Font("Segoe UI", 8F);
            rtbChat.AppendText(time + "\n");

            // Reset
            rtbChat.SelectionAlignment = HorizontalAlignment.Left;
            rtbChat.SelectionBackColor = _chatBackgroundColor;
            rtbChat.ScrollToCaret();
        }

        // -------------------- Logic helpers --------------------

        private bool IsExitCommand(string lowerInput)
        {
            return lowerInput == "exit" ||
                   lowerInput == "quit" ||
                   lowerInput == "bye" ||
                   lowerInput == "goodbye";
        }

        // Sentiment detection (simple keyword matching)
        private string DetectSentiment(string input)
        {
            if (ContainsAny(input, "worried", "scary", "scared", "afraid", "nervous", "anxious", "unsafe", "not safe"))
                return "💙 It is completely understandable to feel worried " + _userName + "!\n\n" +
                       "The fact that you are here learning about it means you are already " +
                       "taking the RIGHT steps to protect yourself!\n\n" +
                       "Let me help ease your worries with some helpful information!";

            if (ContainsAny(input, "frustrated", "annoyed", "angry", "useless", "not helping",
                              "dont get it", "don't get it", "makes no sense"))
                return "💙 I am really sorry to hear you are feeling frustrated " + _userName + "!\n\n" +
                       "Cybersecurity topics can be tricky at first — even professionals find some " +
                       "concepts difficult!\n\nPlease do not give up — you are doing better than you think! 😊";

            if (ContainsAny(input, "confused", "dont understand", "don't understand", "lost",
                              "no idea", "not sure", "unclear"))
                return "💙 No worries at all " + _userName + "!\n\n" +
                       "Confusion just means we need to explain it differently.\n\n" +
                       "Ask me to explain anything step by step and I will make it clearer!";

            if (ContainsAny(input, "curious", "interesting", "want to know", "want to learn"))
                return "🌟 I love your curiosity " + _userName + "!\n\n" +
                       "That is exactly the mindset that keeps people safe online!\n\n" +
                       "Let me feed that curiosity with some great information!";

            if (ContainsAny(input, "overwhelmed", "too much", "complicated", "difficult", "lot to learn"))
                return "💙 I completely understand " + _userName + "!\n\n" +
                       "You do not need to learn everything at once.\n\n" +
                       "Start with one small habit like using stronger passwords and build from there. " +
                       "Small steps lead to big protection! 🔒";

            if (ContainsAny(input, "happy", "excited", "great", "awesome", "love this", "amazing"))
                return "🎉 That is wonderful to hear " + _userName + "!\n\n" +
                       "People who enjoy learning about cybersecurity are the ones who stay safest online.\n\n" +
                       "Let us keep that momentum going!";

            if (ContainsAny(input, "thank", "thanks", "appreciate", "helpful"))
                return "😊 You are so welcome " + _userName + "!\n\n" +
                       "Your safety matters and you deserve to feel confident in the digital world.\n\n" +
                       "Keep asking questions — there is always more to learn!";

            return null;
        }

        private bool ContainsAny(string input, params string[] keywords)
        {
            foreach (var keyword in keywords)
                if (input.Contains(keyword))
                    return true;

            return false;
        }

        private bool IsMemoryQuestion(string input)
        {
            return input.Contains("remember") ||
                   input.Contains("recall") ||
                   input.Contains("what did i ask") ||
                   input.Contains("what have we talked") ||
                   input.Contains("what did we talk") ||
                   input.Contains("what have we discussed") ||
                   input.Contains("what topics") ||
                   input.Contains("our conversation") ||
                   input.Contains("history") ||
                   input.Contains("previously") ||
                   input.Contains("what did we cover") ||
                   input.Contains("earlier");
        }

        private string HandleMemoryRecall()
        {
            if (_topicsDiscussed.Count == 0)
            {
                return "We have not discussed any cybersecurity topics yet " + _userName +
                       "! Ask me about phishing, passwords or safe browsing!";
            }

            string memory =
                "🧠 Here is what I remember about our conversation " + _userName + ":\n\n" +
                "👤 Your name: " + _userName + "\n" +
                "⭐ Your favourite topic: " + _favouriteTopic + "\n\n" +
                "📚 Topics we have discussed so far:\n";

            foreach (string topic in _topicsDiscussed)
            {
                memory += "\n   ✅ " + topic.ToUpper() + "\n";

                if (_conversationMemory.ContainsKey(topic))
                    memory += "      You asked: '" + _conversationMemory[topic] + "'\n";
            }

            memory += "\n💡 As someone interested in " + _favouriteTopic +
                      ", you might also want to explore the other topics!\n" +
                      "Just type any topic name to continue learning!";

            return memory;
        }

        private string DetectTopicFromInput(string input)
        {
            if (input.Contains("phish") || input.Contains("scam") || input.Contains("spam"))
                return "phishing";

            if (input.Contains("password") || input.Contains("passphrase") || input.Contains("2fa"))
                return "password";

            if (input.Contains("browsing") || input.Contains("vpn") || input.Contains("https") ||
                input.Contains("wifi") || input.Contains("privacy"))
                return "safe browsing";

            return null;
        }

        private string CapitalizeName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            if (name.Length == 1) return name.ToUpper();

            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        private string GetAsciiArt()
        {
            return
                "==========================================\n" +
                "\n" +
                "  #####  #   #  ####  ####  ####\n" +
                "  #       # #   #  #  #     #  #\n" +
                "  #        #    ####  ###   ####\n" +
                "  #        #    #  #  #     #  #\n" +
                "  #####    #    #  #  ####  #  #\n" +
                "\n" +
                "  ####   ###  #####\n" +
                "  #  #  #  #  #\n" +
                "  ####  #  #  #\n" +
                "  #  #  #  #  #\n" +
                "  ####   ###   #\n" +
                "\n" +
                "==========================================\n" +
                "   CYBERSECURITY AWARENESS BOT\n" +
                "==========================================";
        }
    }
}