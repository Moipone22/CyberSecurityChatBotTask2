# Cybersecurity Awareness Bot – Part 1

## My Project

This is my Part 1 submission for the Cybersecurity Awareness Bot assignment. I built a command-line chatbot that teaches users about online safety. The bot plays a voice greeting, shows an ASCII logo, asks for my name, and answers questions about password safety, phishing, and safe browsing. It can also "elaborate more" and give examples when I ask.

## What I Did Step by Step

### Step 1. Setting Up the Project
I created a new Console App in Visual Studio using .NET 6.0. I named the project `CybersecurityAwarenessBot`. Then I created five C# classes: `Program.cs`, `Chatbot.cs`, `ResponseManager.cs`, `UIManager.cs`, and `AudioManager.cs`.

### Step 2. Voice Greeting (Question 1)
I recorded a short voice message saying "Hello! Welcome to the Cybersecurity Awareness Bot…" and saved it as `chatbot.wav`. In `AudioManager.cs`, I wrote code that searches for the file and plays it when the bot starts. If the file is missing, the bot still runs without crashing.

### Step 3. ASCII Art Logo (Question 2)
In `UIManager.cs`, I added a large ASCII art drawing that spells out "CYBERSECURITY AWARENESS BOT" at the bottom. I used cyan colour to make it stand out.

### Step 4. Text Greeting and User Name (Question 3)
The bot first asks for my name. It checks that I don't leave it empty. Then it personalises the welcome message, for example "Hello Maria!".

### Step 5. Basic Responses (Question 4)
I programmed the bot to answer:
- "How are you?" – gives a random friendly reply.
- "What is your purpose?" – explains the bot's mission.
- "What can I ask you about?" – lists topics.
- Password safety, phishing, and safe browsing – each has a clear definition.

### Step 6. Input Validation (Question 5)
If I type nothing, the bot asks me to try again. If I type something it doesn't understand, it says "I didn't quite understand that. Could you rephrase?" I also added try-catch blocks everywhere so the bot never crashes.

### Step 7. Enhanced Console UI (Question 6)
I used `Console.ForegroundColor` to add colours: cyan for the logo, green for borders, yellow for warnings, magenta for help. I added borders made of `=` and `?`, section headers with `????`, and a typing effect that shows "[BOT is typing...]" before each response.

### Step 8. Code Structure (Question 7)
I split the code into five classes, each with its own responsibility. In `ResponseManager.cs`, I used a `Dictionary` to store keywords and their responses, and `List`s for random selection. This makes it easy to add more topics later.

### Step 9. Making the Bot Smarter (Follow?ups)
I wanted the bot to remember what we were talking about. So I added a `lastTopic` variable. When I ask "elaborate more" or "tell me more", the bot gives extra details. If I ask again, it gives real?life examples. I also added typo correction: "phising" becomes "phishing", "satey" becomes "safety".

### Step 10. Testing
I tested many inputs:
- `define password safety` ? works
- `elaborate more` ? gives more tips
- `give examples` ? shows strong/weak password examples
- `define phishing` ? works
- `tell me more` ? gives phishing details
- `define safe browsing` ? works
- `how are you` ? random reply each time
- `what is your purpose` ? correct answer
- `exit` ? closes nicely

### 11. GitHub and CI
I made a GitHub repository and committed my code after each major feature (at least 6 commits). I set up GitHub Actions to automatically build the project on every push – this checks for any errors.

### 12. Video Presentation
I recorded an 8?minute video showing the bot running, explaining my code, and demonstrating all the features. I used my own voice (no AI voice) and uploaded it as an unlisted YouTube link.

## How to Run My Project

1. Place your `chatbot.wav` file in the `bin\Debug\net6.0\` folder (or the output folder after building).
2. Open the solution in Visual Studio.
3. Press F5 to run.

## My Files

- `Program.cs` – starts the chatbot.
- `Chatbot.cs` – main loop, asks for name, handles exit.
- `ResponseManager.cs` – stores all responses, handles follow?ups and typos.
- `UIManager.cs` – all console colours, ASCII art, borders, typing effect.
- `AudioManager.cs` – plays the voice greeting.

## What I Learned

I learned how to use dictionaries for keyword matching, how to add a typing effect, how to play sound in C#, and how to make a console app look professional with colours and borders. I also got practice with Git and GitHub Actions.

---

**Thank you for reviewing my project.**  
*April 2026*
# 🔒 Cybersecurity Awareness Chatbot — Part 2


## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Part 1 Features](#part-1-features)
- [Part 2 Features](#part-2-features)
- [How to Run the Project](#how-to-run-the-project)
- [How to Use the Chatbot](#how-to-use-the-chatbot)
- [Example Conversations](#example-conversations)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [GitHub and Releases](#github-and-releases)

---

## 📖 Project Overview

The **Cybersecurity Awareness Chatbot** is an interactive educational tool
designed to help users learn about online safety and cybersecurity best
practices. The chatbot provides information about phishing attacks, password
safety, and safe browsing habits through an engaging conversational interface.

Part 2 expands on Part 1 by adding a full **Graphical User Interface (GUI)**
built using **Windows Forms (WinForms)** in C#. The GUI is styled in a
WhatsApp-inspired chat layout, making it intuitive and user-friendly.

---

## ✅ Part 1 Features

The following features were implemented in Part 1 (console application):

- **Voice Greeting** — Plays an audio greeting when the chatbot starts
- **ASCII Art Display** — Displays a custom ASCII art logo on startup
- **Personalized Welcome** — Asks for the user's name and greets them personally
- **Keyword Recognition** — Recognises cybersecurity keywords and responds
  with relevant information
- **Topics Covered:**
  - 🎣 Phishing attacks
  - 🔐 Password safety
  - 🌐 Safe browsing
  - 🛡️ General cybersecurity
- **Random Responses** — Randomly selects from multiple responses to keep
  conversations varied
- **Follow-up Questions** — Handles follow-up questions like
  "tell me more" and "give me an example"
- **Error Handling** — Handles empty input and unrecognised keywords
  gracefully
- **OOP Design** — Uses classes and methods for clean code organisation

---

## ✅ Part 2 Features

The following features were added in Part 2 (GUI application):

### 1. GUI Design and Implementation
- WhatsApp-inspired chat interface
- Dark teal green header with bot name and online status
- Profile picture displayed in the top left corner
- User messages displayed on the RIGHT in green bubbles
- Bot messages displayed on the LEFT in white bubbles
- Timestamps displayed under every message
- Double tick (✓✓) on user messages like WhatsApp
- Voice greeting plays automatically on startup
- ASCII art from Part 1 displayed in the chat on startup

### 2. Keyword Recognition
- Recognises cybersecurity keywords in user input
- Responds with detailed relevant information
- Recognises at least 3 keywords:
  - **password** — provides password safety tips
  - **phishing / scam** — provides phishing awareness information
  - **safe browsing / privacy** — provides browsing safety tips

### 3. Random Responses
- Randomly selects from multiple predefined responses
- Uses Lists and Dictionaries to manage responses
- Never repeats the same response twice in a row
- Keeps conversations varied and engaging

### 4. Conversation Flow
- Handles follow-up questions naturally:
  - "tell me more"
  - "give me an example"
  - "give me a tip"
  - "give me a fun fact"
  - "elaborate"
- Maintains conversation context without restarting
- Provides increasingly detailed information with each follow-up

### 5. Memory and Recall
- Remembers the user's name throughout the conversation
- Remembers the user's favourite cybersecurity topic
- Stores every topic discussed during the conversation
- Recalls conversation history when asked:
  - "what have we talked about?"
  - "do you remember what I asked?"
  - "what topics did we cover?"
- Shows a full summary of topics covered when the user exits

### 6. Sentiment Detection
- Detects 7 different emotional states:
  - 😟 Worried / scared / afraid
  - 😤 Frustrated / annoyed / angry
  - 😕 Confused / lost / unclear
  - 🤔 Curious / interested
  - 😩 Overwhelmed / complicated
  - 😊 Happy / excited / awesome
  - 🙏 Grateful / thankful
- Responds with emotional support and encouragement
- Automatically provides a relevant cybersecurity tip after
  the support message
- User does not need to ask again after sentiment is detected

### 7. Error Handling and Edge Cases
- Handles empty input with a warning message
- After 3 empty inputs shows a helpful tip
- Default responses guide the user when input is not recognised
- Help command shows all available topics and commands
- Try-catch blocks prevent crashes from unexpected input
- Never repeats the same default response twice

### 8. Code Optimisation
- Uses Dictionaries to organise keyword responses
- Uses Lists to manage random response selections
- Follows OOP principles with separate classes:
  - `Chatbot` — main chatbot logic
  - `ResponseManager` — manages all responses
  - `AudioManager` — handles voice greeting
  - `UIManager` — handles console UI (Part 1)
  - `Form1` — handles GUI (Part 2)
- Methods are small, focused and well commented
- Code is ready for further expansion in Part 3

---

## 🚀 How to Run the Project

### Requirements
- Windows 10 or 11
- Visual Studio 2022
- .NET Framework 4.8
- .NET Desktop Development workload installed

### Steps

**1. Clone the repository:**
