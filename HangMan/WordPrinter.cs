using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class WordPrinter
    {
        public static int PrintWord(List<char> guessLetters, String randomWord)
        {
            int counter = 0;
            int rightLetter = 0;
            Console.WriteLine("\r\n");
            foreach (char c in randomWord) 
            {
                if (guessLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetter++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return rightLetter;

        }
    }
}
