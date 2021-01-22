using System;
using System.Linq;
using System.Collections.Generic;


namespace SowPod_Helper_Console
{
    class Program
    {
        static string[] words;
        static void Main(string[] args)
        {
            words = Properties.Resources.sowpods.Replace("\r", "").Split('\n');
            Console.WriteLine("SOWPOD Helper\nWritten By Todd Teese");
            Console.ReadKey();
            bool helperRunning = true;
            while (helperRunning) {
                PrintHelpText();
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                switch (keyPressed.KeyChar) {
                    case '1':
                        ValidateAWord();
                        break;
                    case '2':
                        FindAWord();
                        break;
                    case 'q':
                        helperRunning = false; 
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Thanks for Using the SowPod Helper\nEnjoy the rest of your day");
            Console.ReadKey();
        }

        static void ValidateAWord() {
            string userInput = null;
            while (userInput == null){
                Console.Clear();
                Console.WriteLine("Validate a Word\nPlease Enter a Word to Validate");
                userInput = Console.ReadLine();
                if (userInput == "") {
                    Console.WriteLine("Please enter a valid word");
                    Console.ReadKey(true);
                    userInput = null;
                }
            }
            bool isValid = words.Contains(userInput.ToLower());
            Console.WriteLine(userInput.ToLower() + " is" + (isValid ? "" : " not") + " a word");
            Console.ReadKey();
        }

        static void FindAWord() {
            Dictionary<int, List<String>> validWords = new Dictionary<int, List<string>>(); // find the valid words in the list, then relay those to the user
            string userInput = null;
            while (userInput == null)
            {
                Console.Clear();
                Console.WriteLine("Find a Word\nPlease Enter a Sequence of Letters to Search");
                userInput = Console.ReadLine();
                if (userInput == "")
                {
                    Console.WriteLine("Please enter a valid sequence of letters");
                    Console.ReadKey(true);
                    userInput = null;
                }
            }
            string letters = userInput.ToLower();
            foreach (string word in words) {
                if (CheckPossibleWord(letters, word.ToCharArray())) {
                    if (!validWords.ContainsKey(word.Length)) {
                        validWords[word.Length] = new List<String>();
                    }

                    List<String> wordsByLength = validWords[word.Length];
                    wordsByLength.Add(word);
                    validWords[word.Length] = wordsByLength;
                    
                    
                }
            }

            for (int i = 1; i < 10; i++) {
                if (validWords.ContainsKey(i)) {
                    List<String> wordsByLength = validWords[i];
                    Console.WriteLine("There are " + wordsByLength.Count + " words of length " + i + "\n");
                    string organisedWords = "";
                    for (int x = 0; x < wordsByLength.Count; x++) {
                        organisedWords += wordsByLength[x].PadLeft(10);
                    }
                    Console.WriteLine(organisedWords + "\n");

                }
            }
            Console.ReadKey();
        }

        static bool CheckPossibleWord(string userLetters, char[] wordLetters) {
            bool possible = true;
            string scopeLetters = userLetters;
            foreach (char letter in wordLetters) {
                if (scopeLetters.Contains(letter)) {
                    scopeLetters = scopeLetters.Remove(scopeLetters.IndexOf(letter),1); // to make sure we take into consideration multiple letters in target word
                } 
                else {
                    possible = false;
                }
            }
            return possible;
        }

        static void PrintHelpText() {
            Console.Clear();
            Console.WriteLine("1. Validate a Word");
            Console.WriteLine("2. Find a word using letters");
            Console.WriteLine("Q. Quit");
            Console.WriteLine(">>");
        }
    }
}
