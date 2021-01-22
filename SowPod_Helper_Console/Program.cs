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
                Console.WriteLine(keyPressed.KeyChar);
                if (keyPressed.KeyChar == 'q') {
                    helperRunning = false;
                }
            }
            Console.WriteLine("Thanks for Using the SowPod Helper");
            Console.WriteLine("Enjoy the rest of your day");
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
