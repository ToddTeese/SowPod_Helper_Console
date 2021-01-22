using System;

namespace SowPod_Helper_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOWPOD Helper");
            Console.WriteLine("Written By Todd Teese");
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
            Console.WriteLine("Thanks for Using the SowPod Helper");
            Console.WriteLine("Enjoy the rest of your day");
            Console.ReadKey();

        }

        static void ValidateAWord() {
            Console.WriteLine("Validate a Word");
            Console.ReadKey();
        }

        static void FindAWord() {
            Console.WriteLine("Find a Word");
            Console.ReadKey();
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
