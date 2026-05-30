using System;
using System.Collections.Generic;

namespace CybersecurityAwarenessBot
{
    public class ResponseManager
    {
        private static readonly Random random = new Random();

        private Dictionary<string, int> topicResponseIndex;
        private string lastTopic;
        private int followUpCount;
        private string lastResponse = "";

        private Dictionary<string, List<string>> basicResponses;
        private Dictionary<string, List<string>> detailedResponses;
        private Dictionary<string, List<string>> tipResponses;
        private Dictionary<string, List<string>> exampleResponses;
        private Dictionary<string, List<string>> advancedResponses;
        private Dictionary<string, List<string>> funFactResponses;
        private List<string> defaultResponses;
        private List<string> greetingResponses;

        public ResponseManager()
        {
            topicResponseIndex = new Dictionary<string, int>();
            basicResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            detailedResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            tipResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            exampleResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            advancedResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            funFactResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            // ═══════════════════════════════════════════════════════════════
            //  PHISHING
            // ═══════════════════════════════════════════════════════════════

            basicResponses["phishing"] = new List<string>
            {
                "🎣 WHAT IS PHISHING?\n\n" +
                "Phishing is a type of cyberattack where criminals disguise themselves as " +
                "trustworthy organisations to steal your sensitive information.\n\n" +
                "Imagine receiving an email that looks EXACTLY like it came from your bank, " +
                "complete with the logo, colours and official looking layout. " +
                "But it is actually a trap designed to steal your password!\n\n" +
                "The word 'phishing' comes from 'fishing' — just like a fisherman uses bait " +
                "to catch fish, cybercriminals use fake emails and websites as bait to catch victims.\n\n" +
                "📌 Key facts:\n" +
                "• 91% of all cyberattacks begin with a phishing email\n" +
                "• A phishing attack happens every 11 seconds worldwide\n" +
                "• Phishing costs businesses over 1.7 billion dollars every year\n\n" +
                "Type 'tell me more' to learn about different types of phishing attacks!",

                "🎣 PHISHING EXPLAINED:\n\n" +
                "Phishing is when cybercriminals send fraudulent messages pretending to be " +
                "from legitimate sources like banks, PayPal, Microsoft, Amazon, or even your employer.\n\n" +
                "Their goal is to trick you into:\n" +
                "• Clicking a malicious link that takes you to a fake website\n" +
                "• Downloading malware disguised as a legitimate file\n" +
                "• Entering your username and password on a fake login page\n" +
                "• Providing credit card or banking information\n" +
                "• Transferring money to a fraudulent account\n\n" +
                "🚨 WARNING SIGNS of a phishing email:\n" +
                "• Generic greeting like 'Dear Customer' instead of your name\n" +
                "• Urgent or threatening language like 'Act now or lose access!'\n" +
                "• Spelling mistakes and poor grammar\n" +
                "• Suspicious links or email addresses with slight misspellings\n" +
                "• Requests for sensitive information like passwords or card numbers\n\n" +
                "Type 'give me a tip' to learn how to protect yourself!"
            };

            tipResponses["phishing"] = new List<string>
            {
                "💡 PHISHING TIP 1 — CHECK THE SENDER ADDRESS:\n\n" +
                "Before opening any email always check the sender's email address carefully.\n\n" +
                "Hackers use addresses that look almost identical to real ones:\n" +
                "❌ support@paypa1.com (fake — '1' instead of 'l')\n" +
                "✅ support@paypal.com (real)\n\n" +
                "❌ security@amaz0n.com (fake — '0' instead of 'o')\n" +
                "✅ security@amazon.com (real)\n\n" +
                "One tiny character difference is all it takes to fool you. Always look carefully!",

                "💡 PHISHING TIP 2 — HOVER BEFORE YOU CLICK:\n\n" +
                "Never click a link in an email without first hovering your mouse over it.\n\n" +
                "When you hover over a link the real destination URL appears at the bottom " +
                "of your browser. If the URL looks suspicious or does not match the company " +
                "being mentioned DO NOT CLICK IT!\n\n" +
                "Example:\n" +
                "The email says: 'Click here to verify your Nedbank account'\n" +
                "But hovering shows: 'http://steal-your-info.ru/nedbank-fake'\n\n" +
                "That is a massive red flag! Never click suspicious links!",

                "💡 PHISHING TIP 3 — NEVER GIVE PASSWORDS VIA EMAIL:\n\n" +
                "This is the golden rule of cybersecurity:\n\n" +
                "🚫 NO legitimate company will EVER ask for your password via email!\n\n" +
                "Not your bank. Not PayPal. Not Microsoft. Not Google. Nobody.\n\n" +
                "If you receive an email asking for your password it is 100% a scam. " +
                "Report it as phishing and delete it immediately!\n\n" +
                "Real companies reset passwords through secure verified processes " +
                "on their official websites — never through email requests.",

                "💡 PHISHING TIP 4 — BEWARE OF URGENCY:\n\n" +
                "Phishing emails almost always create a sense of urgency to panic you " +
                "into acting without thinking.\n\n" +
                "Watch out for language like:\n" +
                "⚠️ 'Your account will be closed in 24 hours!'\n" +
                "⚠️ 'Unusual activity detected — verify immediately!'\n" +
                "⚠️ 'You have won a prize — claim now before it expires!'\n" +
                "⚠️ 'Final warning — your payment is overdue!'\n\n" +
                "Whenever you feel pressured or panicked STOP and take a breath. " +
                "Real companies give you time to verify. Scammers create fake deadlines!",

                "💡 PHISHING TIP 5 — USE TWO FACTOR AUTHENTICATION:\n\n" +
                "Two Factor Authentication (2FA) is your best defence against phishing.\n\n" +
                "Even if a phisher successfully steals your password they CANNOT log in " +
                "without the second verification step — usually a code sent to your phone.\n\n" +
                "How to enable 2FA:\n" +
                "1. Go to your account security settings\n" +
                "2. Look for 'Two Factor Authentication' or '2-Step Verification'\n" +
                "3. Choose SMS code or an authenticator app like Google Authenticator\n" +
                "4. Follow the setup steps\n\n" +
                "Enable 2FA on your email, bank, social media and any other important accounts TODAY!",

                "💡 PHISHING TIP 6 — VERIFY DIRECTLY WITH THE COMPANY:\n\n" +
                "If you receive a suspicious email claiming to be from your bank or any " +
                "company do NOT click any links in the email.\n\n" +
                "Instead:\n" +
                "1. Open a new browser tab\n" +
                "2. Type the company's official website address manually\n" +
                "3. Log in directly on their official site\n" +
                "4. Check if there are any real alerts on your account\n\n" +
                "Or call the company directly using the number on their official website " +
                "NOT the number provided in the suspicious email!\n\n" +
                "This simple habit can save you from losing thousands of rands!",

                "💡 PHISHING TIP 7 — REPORT PHISHING ATTEMPTS:\n\n" +
                "Do not just delete phishing emails — REPORT them!\n\n" +
                "How to report phishing:\n" +
                "📧 Gmail: Click the three dots next to reply and select 'Report phishing'\n" +
                "📧 Outlook: Click 'Junk' then 'Phishing'\n" +
                "📧 Forward the email to the real company being impersonated\n" +
                "📧 Report to your country's cybercrime unit\n\n" +
                "By reporting phishing you help protect others from falling for the same scam. " +
                "Together we can make the internet safer for everyone!"
            };

            detailedResponses["phishing"] = new List<string>
            {
                "🔍 TYPES OF PHISHING ATTACKS:\n\n" +
                "1. EMAIL PHISHING — The most common type. Fake emails sent to thousands " +
                "of people hoping some will fall for the trap.\n\n" +
                "2. SPEAR PHISHING — Targeted attacks on specific individuals. " +
                "The attacker researches you on social media to make the attack personal and convincing.\n\n" +
                "3. WHALING — Attacks targeting high profile executives like CEOs or CFOs. " +
                "These attacks can result in millions being stolen from companies.\n\n" +
                "4. SMISHING — Phishing via SMS text messages. " +
                "Example: 'Your FNB account is locked. Click here to unlock: bit.ly/fake'\n\n" +
                "5. VISHING — Phishing via phone calls. " +
                "A fake 'bank employee' calls asking you to confirm your account details.\n\n" +
                "6. CLONE PHISHING — Attackers copy a legitimate email you previously received " +
                "and replace the links with malicious ones.\n\n" +
                "7. PHARMING — Redirects you from a real website to a fake one " +
                "without you clicking any link — extremely dangerous!\n\n" +
                "Type 'give me an example' to see real phishing examples!",

                "🔍 HOW PHISHING ATTACKS WORK — STEP BY STEP:\n\n" +
                "Step 1: RECONNAISSANCE — The attacker researches their target, " +
                "gathering information from social media, company websites and data breaches.\n\n" +
                "Step 2: CRAFTING THE ATTACK — They create a convincing fake email or website " +
                "that closely mimics a legitimate organisation.\n\n" +
                "Step 3: DELIVERY — The fake email is sent to thousands or specifically targeted individuals.\n\n" +
                "Step 4: THE TRAP — The victim clicks the link and lands on a fake website " +
                "that looks identical to the real one.\n\n" +
                "Step 5: HARVESTING — The victim enters their credentials which are immediately " +
                "captured by the attacker.\n\n" +
                "Step 6: EXPLOITATION — The attacker uses the stolen information to access " +
                "accounts, steal money or sell the data on the dark web.\n\n" +
                "Understanding how attacks work helps you recognise and stop them!"
            };

            exampleResponses["phishing"] = new List<string>
            {
                "📖 REAL PHISHING EXAMPLE 1 — THE BANK EMAIL SCAM:\n\n" +
                "Scenario: You receive this email:\n\n" +
                "From: security@firstnationaI-bank.com\n" +
                "Subject: URGENT: Suspicious activity on your account\n\n" +
                "'Dear Valued Customer,\n" +
                "We have detected unusual login activity on your account from Nigeria.\n" +
                "Your account has been temporarily locked for your protection.\n" +
                "Please click the link below within 2 hours to restore access:\n" +
                "[Verify My Account Now]\n" +
                "Failure to verify will result in permanent account closure.'\n\n" +
                "🚩 RED FLAGS:\n" +
                "• 'firstnationaI-bank' uses capital 'I' instead of lowercase 'l'\n" +
                "• Generic greeting instead of your real name\n" +
                "• Extreme urgency with a 2 hour deadline\n" +
                "• Threatening language about permanent closure\n" +
                "• Link goes to a fake website not the real bank\n\n" +
                "✅ WHAT TO DO: Delete the email and call your real bank directly!",

                "📖 REAL PHISHING EXAMPLE 2 — THE TWITTER HACK OF 2020:\n\n" +
                "In July 2020 hackers targeted Twitter employees with a spear phishing attack.\n\n" +
                "The attackers called Twitter employees pretending to be from Twitter's IT department. " +
                "They convinced employees to provide their internal system login credentials.\n\n" +
                "With these credentials hackers gained access to internal Twitter tools and " +
                "took over accounts of Barack Obama, Elon Musk, Bill Gates, Apple, Uber and others.\n\n" +
                "The hackers posted bitcoin scam messages from these verified accounts, " +
                "collecting over 100,000 dollars in bitcoin before being stopped.\n\n" +
                "Three people were arrested including a 17 year old from Florida.\n\n" +
                "💡 Lesson: Even the biggest tech companies and their employees fall for " +
                "phishing attacks. No one is immune — always verify before trusting!",

                "📖 REAL PHISHING EXAMPLE 3 — COVID-19 VACCINE SCAM:\n\n" +
                "During the COVID-19 pandemic millions of people received text messages like:\n\n" +
                "'URGENT: You are eligible for a FREE COVID-19 vaccine.\n" +
                "Register now at: www.covid-vacc1ne-register.com\n" +
                "Offer expires in 24 hours. Bring your ID and banking details.'\n\n" +
                "🚩 RED FLAGS:\n" +
                "• Unsolicited message about a sensitive topic\n" +
                "• Fake website address with '1' instead of 'i' in vaccine\n" +
                "• Unnecessary request for banking details for a free vaccine\n" +
                "• Artificial urgency with 24 hour deadline\n\n" +
                "Thousands of South Africans lost personal and financial information to this scam.\n\n" +
                "💡 Lesson: Scammers exploit fear and major world events to make attacks more believable!"
            };

            funFactResponses["phishing"] = new List<string>
            {
                "🤯 FUN FACTS ABOUT PHISHING:\n\n" +
                "• The term 'phishing' was first used in 1995 by hackers targeting AOL users\n" +
                "• The 'ph' spelling comes from 'phone phreaking' — early phone hacking from the 1970s\n" +
                "• Nigeria is infamous for '419 scams' — phishing emails claiming you inherited millions\n" +
                "• The most successful phishing emails have a 45% click rate\n" +
                "• Google blocks over 100 million phishing emails every single day\n" +
                "• The most impersonated brands are Microsoft, Google, PayPal, Apple and Amazon\n" +
                "• During the 2022 FIFA World Cup phishing attacks increased by 300%\n\n" +
                "Stay informed and stay safe out there! 🔒"
            };

            // ═══════════════════════════════════════════════════════════════
            //  PASSWORD
            // ═══════════════════════════════════════════════════════════════

            basicResponses["password"] = new List<string>
            {
                "🔐 WHAT IS PASSWORD SAFETY?\n\n" +
                "Password safety is the practice of creating and managing strong, secure " +
                "passwords to protect your online accounts from unauthorised access.\n\n" +
                "Think of your password like a key to your house. A weak password is like " +
                "leaving your front door key under the mat — everyone knows to look there!\n\n" +
                "A STRONG password must be:\n" +
                "✅ At least 12 characters long (longer is always better)\n" +
                "✅ A mix of UPPERCASE and lowercase letters\n" +
                "✅ Contains numbers (0-9)\n" +
                "✅ Contains special symbols (!@#$%^&*)\n" +
                "✅ Unique — never reused across different accounts\n" +
                "✅ Not based on personal information\n\n" +
                "📊 Password strength comparison:\n" +
                "❌ 'password' — cracked in less than 1 second\n" +
                "❌ 'Password1' — cracked in 3 minutes\n" +
                "✅ 'P@ssw0rd!2024' — takes months to crack\n" +
                "✅ 'PurpleDinosaur!EatsPizza@3am' — takes centuries to crack!\n\n" +
                "Type 'give me a tip' to learn more about creating strong passwords!",

                "🔐 WHY PASSWORD SAFETY MATTERS:\n\n" +
                "Your passwords protect everything that matters to you online:\n" +
                "💰 Your bank account and money\n" +
                "📧 Your email and personal messages\n" +
                "📱 Your social media and reputation\n" +
                "🏥 Your medical and personal records\n" +
                "🛒 Your shopping accounts and saved card details\n\n" +
                "If a hacker gets your password they can:\n" +
                "• Drain your bank account\n" +
                "• Send emails pretending to be you\n" +
                "• Lock you out of your own accounts\n" +
                "• Steal your identity\n" +
                "• Access every account where you used the same password\n\n" +
                "📊 Shocking statistics:\n" +
                "• 81% of data breaches are caused by weak or stolen passwords\n" +
                "• The most common password in 2023 was still '123456'\n" +
                "• A hacker attempts to crack accounts every 39 seconds\n" +
                "• 65% of people reuse passwords across multiple accounts\n\n" +
                "Type 'tell me more' to learn about password managers!"
            };

            tipResponses["password"] = new List<string>
            {
                "💡 PASSWORD TIP 1 — USE A PASSPHRASE:\n\n" +
                "Instead of a complex hard to remember password try using a passphrase!\n\n" +
                "A passphrase combines 4 or more random words into one long password:\n\n" +
                "🔑 Example: 'PurpleDinosaur!EatsPizza@3am'\n\n" +
                "Why passphrases are great:\n" +
                "✅ Easy for YOU to remember\n" +
                "✅ Extremely hard for hackers to crack\n" +
                "✅ Long enough to be very secure\n" +
                "✅ Can include numbers and symbols naturally\n\n" +
                "Try creating your own passphrase using 4 random words that paint a funny picture!",

                "💡 PASSWORD TIP 2 — NEVER REUSE PASSWORDS:\n\n" +
                "Using the same password on multiple sites is one of the most dangerous habits online.\n\n" +
                "Here is why it is so dangerous:\n\n" +
                "Imagine your password is 'MyDog2024!' and you use it on:\n" +
                "• Your email\n" +
                "• Your bank\n" +
                "• Facebook\n" +
                "• An online shopping site\n\n" +
                "If that shopping site gets hacked and your password is leaked, " +
                "hackers will immediately try 'MyDog2024!' on your email, bank and Facebook.\n\n" +
                "This is called CREDENTIAL STUFFING and it is extremely common!\n\n" +
                "✅ Solution: Use a unique password for every single account!",

                "💡 PASSWORD TIP 3 — USE A PASSWORD MANAGER:\n\n" +
                "A password manager is software that creates and stores all your passwords securely.\n\n" +
                "How it works:\n" +
                "1. You create ONE strong master password\n" +
                "2. The manager generates unique strong passwords for every site\n" +
                "3. It stores them all in an encrypted vault\n" +
                "4. It automatically fills in your passwords when you visit sites\n\n" +
                "Top free password managers:\n" +
                "🥇 BITWARDEN — Free, open source, highly trusted\n" +
                "🥈 KEEPASS — Free, stores passwords offline\n" +
                "🥉 LASTPASS — Free tier available\n\n" +
                "A password manager means you only need to remember ONE password " +
                "while having unique strong passwords for every account!",

                "💡 PASSWORD TIP 4 — ENABLE TWO FACTOR AUTHENTICATION:\n\n" +
                "Two Factor Authentication (2FA) adds a second lock to your account.\n\n" +
                "Even if a hacker has your EXACT password they cannot get in " +
                "without the second factor — usually a code sent to your phone.\n\n" +
                "Types of 2FA:\n" +
                "📱 SMS Code — a code is texted to your phone\n" +
                "📱 Authenticator App — Google Authenticator generates codes\n" +
                "🔑 Hardware Key — a physical USB key like YubiKey\n" +
                "👆 Biometric — fingerprint or face recognition\n\n" +
                "Enable 2FA on these accounts FIRST:\n" +
                "• Email (most important — it resets all other passwords!)\n" +
                "• Banking and financial accounts\n" +
                "• Social media accounts\n" +
                "• Work accounts",

                "💡 PASSWORD TIP 5 — AVOID PERSONAL INFORMATION:\n\n" +
                "Many people create passwords using personal information because " +
                "it is easy to remember. But hackers know this too!\n\n" +
                "NEVER use in your passwords:\n" +
                "❌ Your name or nickname\n" +
                "❌ Your birthday or anniversary\n" +
                "❌ Your pet's name\n" +
                "❌ Your phone number\n" +
                "❌ Your ID or passport number\n" +
                "❌ Your street address\n" +
                "❌ Your favourite sports team\n\n" +
                "Why? All this information is often publicly available on your social media!\n\n" +
                "A hacker who follows your Facebook can easily guess passwords like:\n" +
                "'Max2010' (your dog's name and birth year) or 'Chiefs2024!' (your favourite team)",

                "💡 PASSWORD TIP 6 — CHANGE PASSWORDS AFTER BREACHES:\n\n" +
                "Data breaches happen every day. Major companies like LinkedIn, Facebook " +
                "and Adobe have all had breaches where millions of passwords were stolen.\n\n" +
                "How to check if YOUR password has been leaked:\n" +
                "1. Visit www.haveibeenpwned.com\n" +
                "2. Enter your email address\n" +
                "3. See if it appears in any known data breaches\n" +
                "4. If it does — change those passwords IMMEDIATELY!\n\n" +
                "Set a reminder to check this website every 3 months. " +
                "Your password could have been leaked without you even knowing!",

                "💡 PASSWORD TIP 7 — CREATE A STRONG MASTER PASSWORD:\n\n" +
                "If you use a password manager you need one VERY strong master password.\n\n" +
                "Here is a formula for creating an uncrackable master password:\n\n" +
                "Step 1: Think of a sentence you will never forget\n" +
                "Example: 'I started Grade 1 at Rosebank Primary in 2005!'\n\n" +
                "Step 2: Take the first letter of each word\n" +
                "Result: 'IsG1aRPi2005!'\n\n" +
                "Step 3: Add symbols and numbers\n" +
                "Final: 'IsG1@RPi#2005!'\n\n" +
                "This password is 14 characters, includes uppercase, lowercase, " +
                "numbers and symbols, and only YOU know the sentence it came from!"
            };

            detailedResponses["password"] = new List<string>
            {
                "🔍 HOW HACKERS STEAL PASSWORDS:\n\n" +
                "1. BRUTE FORCE ATTACK\n" +
                "   Hackers use software that tries billions of password combinations per second.\n" +
                "   'password' is cracked in under 1 second.\n" +
                "   'P@ssw0rd1' is cracked in about 3 minutes.\n" +
                "   'PurpleDinosaur!3am' would take over 1 trillion years!\n\n" +
                "2. DICTIONARY ATTACK\n" +
                "   Software tries every word in the dictionary plus common substitutions.\n" +
                "   'p@ssw0rd' is still vulnerable because hackers know these tricks.\n\n" +
                "3. CREDENTIAL STUFFING\n" +
                "   Hackers buy leaked password lists from data breaches on the dark web.\n" +
                "   They automatically try these on banking and email sites.\n\n" +
                "4. KEYLOGGING\n" +
                "   Malware installed on your device records every keystroke you type.\n" +
                "   Your password is stolen the moment you type it!\n\n" +
                "5. SHOULDER SURFING\n" +
                "   Someone physically watches you type your password in public.\n\n" +
                "Understanding these methods helps you defend against them!",

                "🔍 PASSWORD MANAGERS EXPLAINED IN DETAIL:\n\n" +
                "A password manager works like a secure digital vault for all your passwords.\n\n" +
                "HOW IT KEEPS YOU SAFE:\n" +
                "• Creates unique 20+ character random passwords for every site\n" +
                "• Encrypts all passwords with military grade AES-256 encryption\n" +
                "• Only YOU can unlock the vault with your master password\n" +
                "• Alerts you if a site you use has been hacked\n" +
                "• Warns you if you are reusing passwords\n" +
                "• Auto fills passwords so you never type them (prevents keylogging!)\n\n" +
                "COMMON CONCERNS:\n\n" +
                "Q: What if the password manager gets hacked?\n" +
                "A: Even if hackers get the encrypted vault they cannot read it " +
                "without your master password. The encryption is practically unbreakable.\n\n" +
                "Q: What if I forget my master password?\n" +
                "A: Most managers offer recovery options. This is why your master " +
                "password must be both strong AND memorable!"
            };

            exampleResponses["password"] = new List<string>
            {
                "📖 PASSWORD EXAMPLE 1 — THE LINKEDIN BREACH:\n\n" +
                "In 2012 LinkedIn was hacked and 6.5 million passwords were stolen.\n" +
                "In 2016 it emerged the real number was 117 million passwords!\n\n" +
                "What happened to people who reused their LinkedIn password:\n" +
                "• Their email accounts were accessed\n" +
                "• Their Facebook and Twitter were hijacked\n" +
                "• Their online shopping accounts were used for fraud\n" +
                "• Some had their bank accounts compromised\n\n" +
                "What happened to people with unique passwords:\n" +
                "• Only their LinkedIn was affected\n" +
                "• All other accounts remained completely safe\n\n" +
                "💡 One data breach. Two completely different outcomes. " +
                "Unique passwords for every account is not optional — it is essential!",

                "📖 PASSWORD EXAMPLE 2 — THE FACEBOOK DATA BREACH:\n\n" +
                "In 2019 Facebook accidentally stored over 600 million user passwords " +
                "in plain text (not encrypted) on their internal servers.\n\n" +
                "This means thousands of Facebook employees could see user passwords!\n\n" +
                "Facebook claimed no passwords were misused but the incident showed:\n" +
                "• Even giant tech companies make serious security mistakes\n" +
                "• You cannot fully trust any company to protect your password\n" +
                "• Using unique passwords limits the damage of any single breach\n\n" +
                "💡 Never rely solely on a company to protect your security. " +
                "Use unique passwords and 2FA so that even if a company fails you, " +
                "your other accounts remain safe!",

                "📖 PASSWORD EXAMPLE 3 — WEAK VS STRONG PASSWORDS:\n\n" +
                "Time it takes to crack different passwords:\n\n" +
                "❌ '123456' .............. Less than 1 second\n" +
                "❌ 'password' ............ Less than 1 second\n" +
                "❌ 'qwerty123' ........... Less than 1 second\n" +
                "❌ 'John1990' ............ 4 minutes\n" +
                "❌ 'P@ssword1' ........... 3 hours\n" +
                "✅ 'T!g3r$unset99' ....... 400 years\n" +
                "✅ 'PurpleDino!Eats3am' .. 34 million years\n" +
                "✅ 'xK#9mP$vL2@nQ!w5' ... Longer than the universe has existed!\n\n" +
                "The difference between a weak and strong password is the difference " +
                "between being hacked in seconds and being safe for a lifetime!"
            };

            funFactResponses["password"] = new List<string>
            {
                "🤯 FUN FACTS ABOUT PASSWORDS:\n\n" +
                "• The first computer password was created at MIT in 1961\n" +
                "• '123456' has been the world's most common password for 8 years in a row\n" +
                "• There are over 15 billion stolen login credentials on the dark web right now\n" +
                "• A computer can try 350 billion password combinations per second\n" +
                "• The average person has 100 different online accounts\n" +
                "• 13% of people use the same password for ALL their accounts\n" +
                "• Password managers reduce the risk of being hacked by over 80%\n" +
                "• The longest password ever created was 265 characters long!\n\n" +
                "Strong unique passwords are your best defence against cybercriminals! 🔒"
            };

            // ═══════════════════════════════════════════════════════════════
            //  SAFE BROWSING
            // ═══════════════════════════════════════════════════════════════

            basicResponses["safe browsing"] = new List<string>
            {
                "🌐 WHAT IS SAFE BROWSING?\n\n" +
                "Safe browsing means taking smart precautions to protect yourself, " +
                "your data and your device while using the internet.\n\n" +
                "The internet is like a busy city — most places are safe and wonderful, " +
                "but some areas are dangerous if you are not careful!\n\n" +
                "CORE SAFE BROWSING HABITS:\n" +
                "🔒 Always check for HTTPS and the padlock icon before entering personal info\n" +
                "🔒 Keep your browser updated to the latest version\n" +
                "🔒 Use a reliable ad blocker to block malicious advertisements\n" +
                "🔒 Avoid public WiFi for sensitive activities like banking\n" +
                "🔒 Never download files from untrusted or unknown websites\n" +
                "🔒 Clear your cookies and browsing history regularly\n" +
                "🔒 Use a VPN when connecting to public networks\n\n" +
                "📊 Why it matters:\n" +
                "• Over 30,000 websites are hacked every single day\n" +
                "• Malicious ads can infect your device even without clicking\n" +
                "• 1 in 13 web requests lead to malware\n\n" +
                "Type 'give me a tip' for specific safe browsing tips!",

                "🌐 WHY SAFE BROWSING MATTERS:\n\n" +
                "Every time you go online you face potential threats:\n\n" +
                "🦠 MALWARE — Malicious software that can damage your device or steal data\n" +
                "🕵️ SPYWARE — Software that secretly monitors your activity\n" +
                "💰 RANSOMWARE — Locks your files and demands payment to unlock them\n" +
                "🎣 PHISHING SITES — Fake websites designed to steal your credentials\n" +
                "📢 ADWARE — Floods your screen with unwanted and potentially harmful ads\n" +
                "👣 TRACKERS — Follow your activity across websites to build profiles on you\n\n" +
                "Safe browsing habits protect you from ALL of these threats!\n\n" +
                "The good news is that with the right knowledge and tools, " +
                "browsing safely is easy and becomes second nature.\n\n" +
                "Type 'tell me more' to learn about specific browsing threats in detail!"
            };

            tipResponses["safe browsing"] = new List<string>
            {
                "💡 SAFE BROWSING TIP 1 — CHECK FOR HTTPS:\n\n" +
                "Before entering ANY personal information on a website always check:\n\n" +
                "✅ The URL starts with HTTPS (not HTTP)\n" +
                "✅ There is a padlock icon in the address bar\n" +
                "✅ The padlock is not broken or crossed out\n\n" +
                "What HTTPS means:\n" +
                "HTTP = Your data is sent as plain text — anyone can read it!\n" +
                "HTTPS = Your data is encrypted — only you and the website can read it.\n\n" +
                "Example:\n" +
                "❌ http://www.mybank.co.za — NOT safe (no encryption)\n" +
                "✅ https://www.mybank.co.za — Safe (encrypted)\n\n" +
                "⚠️ Important: HTTPS means your connection is encrypted but it does NOT " +
                "guarantee the site is legitimate. Fake sites can also have HTTPS! " +
                "Always verify the full URL carefully!",

                "💡 SAFE BROWSING TIP 2 — AVOID PUBLIC WIFI FOR SENSITIVE TASKS:\n\n" +
                "Public WiFi at coffee shops, airports, hotels and malls is extremely risky!\n\n" +
                "Threats on public WiFi:\n" +
                "👿 MAN IN THE MIDDLE — Hacker sits between you and the website, reading everything\n" +
                "👿 EVIL TWIN — Hacker creates a fake 'Free WiFi' hotspot with the same name\n" +
                "👿 PACKET SNIFFING — Hacker captures and reads all unencrypted data on the network\n\n" +
                "What NOT to do on public WiFi:\n" +
                "❌ Online banking or financial transactions\n" +
                "❌ Entering passwords or credit card numbers\n" +
                "❌ Accessing work emails or confidential documents\n\n" +
                "What you CAN safely do on public WiFi:\n" +
                "✅ General browsing of public websites\n" +
                "✅ Watching videos on legitimate streaming sites\n" +
                "✅ Using a VPN for ANY activity on public WiFi",

                "💡 SAFE BROWSING TIP 3 — USE A VPN:\n\n" +
                "A VPN (Virtual Private Network) is like a secure invisible tunnel " +
                "between your device and the internet.\n\n" +
                "What a VPN does:\n" +
                "🔒 Encrypts ALL your internet traffic\n" +
                "🔒 Hides your real IP address and location\n" +
                "🔒 Protects you on public WiFi networks\n" +
                "🔒 Prevents your internet provider from seeing what you do online\n" +
                "🔒 Helps bypass geographic content restrictions\n\n" +
                "Recommended free VPNs:\n" +
                "• PROTON VPN — best free VPN with no data limits\n" +
                "• WINDSCRIBE — 10GB free per month\n" +
                "• TUNNELBEAR — easy to use with 500MB free\n\n" +
                "⚠️ Avoid completely free VPNs with no reputation — " +
                "some actually sell your browsing data to third parties!",

                "💡 SAFE BROWSING TIP 4 — INSTALL AN AD BLOCKER:\n\n" +
                "Malvertising (malicious advertising) is one of the most dangerous " +
                "online threats because you can be infected WITHOUT clicking anything!\n\n" +
                "How malvertising works:\n" +
                "1. Hackers buy legitimate ad space on real websites\n" +
                "2. The ad contains hidden malicious code\n" +
                "3. Simply LOADING the page can trigger the malware download\n" +
                "4. Your device is infected before you even know it!\n\n" +
                "Best ad blockers:\n" +
                "🥇 UBLOCK ORIGIN — Free, lightweight, extremely effective (highly recommended)\n" +
                "🥈 ADBLOCK PLUS — Popular and easy to use\n" +
                "🥉 BRAVE BROWSER — Built in ad blocker in the browser itself\n\n" +
                "Installing uBlock Origin takes 30 seconds and dramatically improves " +
                "both your security AND browsing speed!",

                "💡 SAFE BROWSING TIP 5 — KEEP YOUR BROWSER UPDATED:\n\n" +
                "Your browser is your gateway to the internet and must always be up to date.\n\n" +
                "Why browser updates matter:\n" +
                "• Each update patches security vulnerabilities that hackers could exploit\n" +
                "• Outdated browsers are a major entry point for malware\n" +
                "• Updates improve privacy features and tracking protection\n\n" +
                "How to check if your browser is updated:\n" +
                "Chrome: Click three dots → Help → About Google Chrome\n" +
                "Firefox: Click menu → Help → About Firefox\n" +
                "Edge: Click three dots → Help → About Microsoft Edge\n\n" +
                "Enable automatic updates so you are always protected without even thinking about it!",

                "💡 SAFE BROWSING TIP 6 — RECOGNISE DANGEROUS DOWNLOADS:\n\n" +
                "Downloads are one of the most common ways malware gets onto your device.\n\n" +
                "NEVER download:\n" +
                "❌ Software from unofficial or unknown websites\n" +
                "❌ Cracked or pirated games and software\n" +
                "❌ Email attachments from unknown senders\n" +
                "❌ Files that require you to disable your antivirus to install\n" +
                "❌ 'Urgent' downloads like 'Your device is infected — download now!'\n\n" +
                "SAFE download practices:\n" +
                "✅ Only download software from official websites or app stores\n" +
                "✅ Scan all downloads with antivirus before opening\n" +
                "✅ Check file extensions — a music file ending in .exe is suspicious!\n" +
                "✅ Read reviews and check ratings before downloading any app",

                "💡 SAFE BROWSING TIP 7 — MANAGE YOUR PRIVACY SETTINGS:\n\n" +
                "Websites and apps collect enormous amounts of data about you.\n\n" +
                "Steps to improve your online privacy:\n\n" +
                "🔒 Clear cookies and cache regularly (at least monthly)\n" +
                "🔒 Use private/incognito mode on shared computers\n" +
                "🔒 Review and limit app permissions on your phone\n" +
                "🔒 Use a privacy focused search engine like DuckDuckGo instead of Google\n" +
                "🔒 Install Privacy Badger to block invisible trackers\n" +
                "🔒 Regularly review which apps have access to your camera, microphone and location\n" +
                "🔒 Use different email addresses for different purposes\n\n" +
                "Privacy is not about hiding — it is about controlling who has access to YOUR information!"
            };

            detailedResponses["safe browsing"] = new List<string>
            {
                "🔍 UNDERSTANDING ONLINE TRACKING:\n\n" +
                "Every time you browse the internet dozens of invisible trackers " +
                "are building a detailed profile about you.\n\n" +
                "HOW THEY TRACK YOU:\n\n" +
                "🍪 COOKIES — Small files stored by websites to remember you.\n" +
                "   First party cookies from the site you visit are mostly harmless.\n" +
                "   Third party cookies from advertisers follow you across different sites!\n\n" +
                "👆 BROWSER FINGERPRINTING — Websites can identify your unique device " +
                "by combining your browser type, screen size, fonts, timezone and more.\n" +
                "Even in incognito mode you can be fingerprinted!\n\n" +
                "📍 IP TRACKING — Your IP address reveals your rough location " +
                "and internet provider to every website you visit.\n\n" +
                "📧 EMAIL TRACKING PIXELS — Invisible images in emails that tell " +
                "senders when you opened the email, what device you used and where you are.\n\n" +
                "Use Firefox with uBlock Origin and Privacy Badger to block most tracking!",

                "🔍 THE DANGERS OF MALWARE FROM BROWSING:\n\n" +
                "RANSOMWARE — Encrypts all your files and demands payment:\n" +
                "• WannaCry ransomware in 2017 infected 200,000 computers in 150 countries\n" +
                "• Hospitals could not access patient records during the attack\n" +
                "• The NHS in UK lost over 100 million dollars\n" +
                "• It spread through an unpatched Windows vulnerability\n\n" +
                "SPYWARE — Secretly monitors everything you do:\n" +
                "• Records keystrokes to steal passwords\n" +
                "• Activates webcam without your knowledge\n" +
                "• Reads your emails and messages\n" +
                "• Tracks your location\n\n" +
                "ADWARE — Floods your device with ads:\n" +
                "• Slows down your device significantly\n" +
                "• Can redirect you to dangerous websites\n" +
                "• Often bundled with free software downloads\n\n" +
                "Prevention: Keep software updated, use ad blockers, only download from trusted sources!"
            };

            exampleResponses["safe browsing"] = new List<string>
            {
                "📖 SAFE BROWSING EXAMPLE 1 — THE EVIL TWIN ATTACK:\n\n" +
                "Scenario: You arrive at OR Tambo International Airport.\n" +
                "You see these WiFi networks:\n" +
                "• 'OR Tambo Free WiFi' — the real official network\n" +
                "• 'OR_Tambo_FreeWiFi' — a hacker's fake network sitting nearby\n\n" +
                "If you connect to the fake network:\n" +
                "• The hacker sees every website you visit\n" +
                "• Your email login details are captured\n" +
                "• Your banking session is intercepted\n" +
                "• Every message you send is read\n\n" +
                "Protection:\n" +
                "✅ Always ask official staff for the correct network name\n" +
                "✅ Use a VPN on ALL public networks\n" +
                "✅ Use your mobile data for anything sensitive\n" +
                "✅ Enable your device's firewall",

                "📖 SAFE BROWSING EXAMPLE 2 — THE FAKE ONLINE STORE:\n\n" +
                "Scenario: You search Google for 'cheap Nike shoes South Africa'\n" +
                "You find: www.nike-sa-discount-shoes.co.za\n\n" +
                "The site looks professional with Nike logos and great prices.\n" +
                "You enter your credit card details and place an order.\n\n" +
                "What actually happened:\n" +
                "• The site was a complete fake\n" +
                "• Your credit card details were stolen\n" +
                "• No shoes will ever arrive\n" +
                "• Your card is now being used for fraud\n\n" +
                "🚩 Red flags you missed:\n" +
                "• URL was not the official nike.com\n" +
                "• Prices were unrealistically low\n" +
                "• Site had no verifiable contact details\n" +
                "• Payment page did not have proper HTTPS certification\n\n" +
                "✅ Always buy from official websites or verified retailers only!",

                "📖 SAFE BROWSING EXAMPLE 3 — DRIVE BY DOWNLOAD:\n\n" +
                "Scenario: You visit a legitimate news website to read an article.\n" +
                "Unknown to you the site is displaying a malicious advertisement.\n\n" +
                "Without clicking ANYTHING:\n" +
                "• The malicious ad code runs automatically in your browser\n" +
                "• It detects your browser version has a security vulnerability\n" +
                "• Malware is silently downloaded and installed on your device\n" +
                "• Your device is now infected with spyware\n\n" +
                "This is called a DRIVE BY DOWNLOAD — you did nothing wrong!\n\n" +
                "Protection:\n" +
                "✅ Install uBlock Origin ad blocker\n" +
                "✅ Keep your browser updated at all times\n" +
                "✅ Enable click to play for browser plugins\n" +
                "✅ Use a browser with built in malware protection"
            };

            funFactResponses["safe browsing"] = new List<string>
            {
                "🤯 FUN FACTS ABOUT INTERNET SAFETY:\n\n" +
                "• The internet has over 5.4 billion users worldwide\n" +
                "• Over 30,000 websites are hacked every single day\n" +
                "• A new malware sample is created every 4 seconds\n" +
                "• Google Chrome has over 70% of the browser market share\n" +
                "• The first computer virus was created in 1971 — it was called 'The Creeper'\n" +
                "• 43% of cyberattacks target small businesses\n" +
                "• The global cost of cybercrime is expected to reach 10 trillion dollars by 2025\n" +
                "• Using HTTPS encrypts your data with 256-bit encryption — " +
                "the same level used by banks and governments!\n\n" +
                "Stay safe out there — knowledge is your best protection! 🔒"
            };

            // ═══════════════════════════════════════════════════════════════
            //  GREETINGS
            // ═══════════════════════════════════════════════════════════════

            greetingResponses = new List<string>
            {
                "👋 Hello there! Great to see you! I am your Cybersecurity Awareness Bot, " +
                "here to help you stay safe in the digital world!\n\n" +
                "I can teach you about:\n" +
                "🎣 Phishing attacks and how to avoid them\n" +
                "🔐 Password safety and strong password creation\n" +
                "🌐 Safe browsing habits and online privacy\n\n" +
                "What would you like to learn about today?",

                "👋 Welcome back! Ready to level up your cybersecurity knowledge? 💪\n\n" +
                "Ask me anything about phishing, passwords or safe browsing!\n" +
                "You can also ask for tips, examples or fun facts on any topic!",

                "👋 Hey there, cyber explorer! 🔒\n\n" +
                "I am packed with cybersecurity knowledge and ready to share it with you.\n" +
                "Try asking me:\n" +
                "• 'What is phishing?'\n" +
                "• 'Give me a password tip'\n" +
                "• 'Tell me about safe browsing'\n" +
                "• 'Give me a fun fact'\n\n" +
                "What would you like to know?"
            };

            basicResponses["how are you"] = new List<string>
            {
                "I am doing absolutely fantastic, thank you for asking! 😊\n" +
                "Every day I get to help people stay safer online which is incredibly rewarding.\n" +
                "What cybersecurity topic can I help you with today?",

                "All systems running at full capacity! 🚀\n" +
                "I am charged up and ready to share cybersecurity knowledge with you.\n" +
                "Ask me about phishing, passwords, safe browsing or anything else!",

                "I am wonderful! 🌟 Nothing makes me happier than helping people " +
                "protect themselves online. What would you like to learn about today?"
            };

            basicResponses["purpose"] = new List<string>
            {
                "🎯 MY PURPOSE:\n\n" +
                "I am the Cybersecurity Awareness Bot — your personal digital safety guide!\n\n" +
                "My mission is to educate and empower you with the knowledge to:\n" +
                "🎣 Recognise and avoid phishing attacks\n" +
                "🔐 Create and manage strong passwords\n" +
                "🌐 Browse the internet safely and privately\n" +
                "🛡️ Understand and defend against cyber threats\n\n" +
                "I provide definitions, tips, real examples and fun facts to make " +
                "cybersecurity education engaging and memorable!\n\n" +
                "What would you like to learn about today?"
            };

            // ═══════════════════════════════════════════════════════════════
            //  DEFAULT RESPONSES (Question 7 — Error Handling)
            // ═══════════════════════════════════════════════════════════════

            defaultResponses = new List<string>
            {
                "🤔 I am not sure I understood that — could you try rephrasing?\n\n" +
                "Here are things I can help you with:\n" +
                "🎣 Type 'what is phishing' — to learn about phishing attacks\n" +
                "🔐 Type 'what is password safety' — to learn about passwords\n" +
                "🌐 Type 'what is safe browsing' — to learn about browsing safely\n" +
                "💡 Type 'give me a tip' — for practical safety tips\n" +
                "📖 Type 'give me an example' — for real world examples\n" +
                "🤯 Type 'give me a fun fact' — for interesting cybersecurity facts\n" +
                "🧠 Type 'what have we talked about' — to see our conversation history\n" +
                "📋 Type 'help' — to see everything I can do!",

                "🤔 Hmm I did not quite catch that!\n\n" +
                "I specialise in cybersecurity topics. Try asking me:\n" +
                "• 'Define phishing'\n" +
                "• 'Give me a password tip'\n" +
                "• 'How do I browse safely?'\n" +
                "• 'Give me a phishing example'\n" +
                "• 'Tell me a fun fact'\n\n" +
                "Or tell me how you are feeling and I will offer support! 😊",

                "🤔 I am not sure I understand what you mean — could you rephrase that?\n\n" +
                "I am best at answering questions about:\n" +
                "• Phishing attacks and scams\n" +
                "• Password safety and management\n" +
                "• Safe browsing and online privacy\n\n" +
                "Type 'help' to see everything I can do!",

                "🤔 That one is outside my knowledge area!\n\n" +
                "But I am an expert in cybersecurity! Ask me:\n" +
                "• 'What is phishing?'\n" +
                "• 'How do I create a strong password?'\n" +
                "• 'What is safe browsing?'\n" +
                "• 'Give me a tip'\n" +
                "• 'Give me an example'\n" +
                "• 'Give me a fun fact'"
            };
        }

        public string GetResponse(string userInput)
        {
            try
            {
                string input = userInput.ToLower().Trim();
                input = FixMisspellings(input);

                // ── Help command (Question 7) ─────────────────────────────
                if (input == "help" || input == "what can i ask" || input == "commands")
                    return "📋 HERE IS EVERYTHING YOU CAN ASK ME:\n\n" +
                           "🎣 PHISHING:\n" +
                           "   • 'What is phishing?'\n" +
                           "   • 'Give me a phishing tip'\n" +
                           "   • 'Give me a phishing example'\n" +
                           "   • 'Tell me more about phishing'\n\n" +
                           "🔐 PASSWORDS:\n" +
                           "   • 'What is password safety?'\n" +
                           "   • 'Give me a password tip'\n" +
                           "   • 'Give me a password example'\n" +
                           "   • 'Tell me more about passwords'\n\n" +
                           "🌐 SAFE BROWSING:\n" +
                           "   • 'What is safe browsing?'\n" +
                           "   • 'Give me a browsing tip'\n" +
                           "   • 'Give me a browsing example'\n" +
                           "   • 'Tell me more about safe browsing'\n\n" +
                           "🧠 MEMORY:\n" +
                           "   • 'What have we talked about?'\n" +
                           "   • 'Do you remember what I asked?'\n\n" +
                           "🤯 FUN:\n" +
                           "   • 'Give me a fun fact'\n" +
                           "   • 'How are you?'\n\n" +
                           "💬 FEELINGS:\n" +
                           "   • Tell me if you are worried, confused, curious or frustrated!\n\n" +
                           "🚪 Type 'bye' or 'exit' to leave.";

                // Greetings
                if (input.Contains("hello") || input.Contains("hi ") ||
                    input == "hi" || input.Contains("hey") ||
                    input.Contains("good morning") || input.Contains("good evening") ||
                    input.Contains("good afternoon"))
                    return PickRandom(greetingResponses);

                if (input.Contains("how are you"))
                    return PickRandom(basicResponses["how are you"]);

                if (input.Contains("purpose") || input.Contains("what can you do") ||
                    input.Contains("what do you do") || input.Contains("who are you") ||
                    input.Contains("what are you"))
                    return PickRandom(basicResponses["purpose"]);

                // Fun facts
                if (input.Contains("fun fact") || input.Contains("interesting fact") ||
                    input.Contains("did you know"))
                {
                    string factTopic = ExtractTopic(input) ?? lastTopic;
                    if (factTopic != null && funFactResponses.ContainsKey(factTopic))
                        return PickRandom(funFactResponses[factTopic]);
                    return PickRandom(funFactResponses["phishing"]);
                }

                // Follow up questions
                if (IsFollowUpQuestion(input))
                    return HandleFollowUp();

                // Tip requests
                if (IsTipRequest(input))
                {
                    string tipTopic = ExtractTopic(input) ?? lastTopic;
                    if (tipTopic != null && tipResponses.ContainsKey(tipTopic))
                    {
                        lastTopic = tipTopic;
                        return GetNextTip(tipTopic);
                    }
                }

                // Example requests
                if (IsExampleRequest(input))
                {
                    string exTopic = ExtractTopic(input) ?? lastTopic;
                    if (exTopic != null && exampleResponses.ContainsKey(exTopic))
                    {
                        lastTopic = exTopic;
                        return PickRandom(exampleResponses[exTopic]);
                    }
                }

                // Topic based response
                string topic = ExtractTopic(input);
                if (topic != null)
                {
                    lastTopic = topic;
                    followUpCount = 0;
                    return PickRandom(basicResponses[topic]);
                }

                // Default response (Question 7)
                return PickRandom(defaultResponses);
            }
            catch (Exception)
            {
                // Question 7 — never crash!
                return "🤔 Something unexpected happened. Could you try rephrasing?\n" +
                       "Try asking about phishing, passwords or safe browsing!";
            }
        }

        private string HandleFollowUp()
        {
            if (lastTopic == null)
                return "Please ask me about a cybersecurity topic first!\n" +
                       "Try asking about phishing, passwords, or safe browsing.";

            followUpCount++;

            if (followUpCount == 1 && detailedResponses.ContainsKey(lastTopic))
                return PickRandom(detailedResponses[lastTopic]);

            if (followUpCount == 2 && exampleResponses.ContainsKey(lastTopic))
                return PickRandom(exampleResponses[lastTopic]);

            if (followUpCount >= 3 && advancedResponses.ContainsKey(lastTopic))
                return PickRandom(advancedResponses[lastTopic]);

            followUpCount = 0;
            return GetNextTip(lastTopic);
        }

        private string GetNextTip(string topic)
        {
            if (!topicResponseIndex.ContainsKey(topic))
                topicResponseIndex[topic] = 0;

            var tips = tipResponses[topic];
            string tip = tips[topicResponseIndex[topic] % tips.Count];
            topicResponseIndex[topic]++;
            return tip;
        }

        private bool IsTipRequest(string input)
        {
            return input.Contains("tip") || input.Contains("advice") ||
                   input.Contains("suggest") || input.Contains("recommend") ||
                   input.Contains("another tip") || input.Contains("give me a tip") ||
                   input.Contains("more tip") || input.Contains("next tip");
        }

        private bool IsExampleRequest(string input)
        {
            return input.Contains("example") || input.Contains("show me") ||
                   input.Contains("demonstrate") || input.Contains("real life") ||
                   input.Contains("real world") || input.Contains("case study");
        }

        private bool IsFollowUpQuestion(string input)
        {
            string[] phrases =
            {
                "tell me more", "elaborate", "explain more", "more details",
                "go on", "continue", "what else", "more info", "explain further",
                "further", "give me more", "more about", "keep going",
                "and then", "expand on", "what about", "how about"
            };
            foreach (var p in phrases)
                if (input.Contains(p)) return true;
            return false;
        }

        private string ExtractTopic(string input)
        {
            if (input.Contains("phish") || input.Contains("scam") ||
                input.Contains("spam") || input.Contains("fake email") ||
                input.Contains("spear") || input.Contains("vishing") ||
                input.Contains("smishing"))
                return "phishing";

            if (input.Contains("password") || input.Contains("passphrase") ||
                input.Contains("2fa") || input.Contains("two factor") ||
                input.Contains("authentication") || input.Contains("credential") ||
                input.Contains("login") || input.Contains("log in"))
                return "password";

            if (input.Contains("browsing") || input.Contains("browse") ||
                input.Contains("https") || input.Contains("vpn") ||
                input.Contains("wifi") || input.Contains("wi-fi") ||
                input.Contains("privacy") || input.Contains("tracker") ||
                input.Contains("website") || input.Contains("internet") ||
                input.Contains("malware") || input.Contains("virus") ||
                input.Contains("adware") || input.Contains("spyware"))
                return "safe browsing";

            return null;
        }

        private string FixMisspellings(string input)
        {
            var fixes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "phising",        "phishing"      },
                { "pasword",        "password"      },
                { "passowrd",       "password"      },
                { "cyber security", "cybersecurity" },
                { "safe broswing",  "safe browsing" },
                { "browsin",        "browsing"      },
                { "paswword",       "password"      },
                { "fising",         "phishing"      }
            };

            foreach (var pair in fixes)
                if (input.Contains(pair.Key))
                    input = input.Replace(pair.Key, pair.Value);

            return input;
        }

        // ── Never repeat same response twice (Question 7) ─────────────────
        private string PickRandom(List<string> list)
        {
            if (list.Count == 1)
                return list[0];

            string picked;
            int attempts = 0;
            do
            {
                picked = list[random.Next(list.Count)];
                attempts++;
            }
            while (picked == lastResponse && attempts < 10);

            lastResponse = picked;
            return picked;
        }
    }
}