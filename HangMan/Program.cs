using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.Runtime.CompilerServices;
using HangMan;

Console.WriteLine("Welcome to hangman!");
Console.WriteLine("--------------------------");

Random random = new Random();
List<String> wordDictionary = new List<String>{"jedi","television", "coding", "hustle","linkedin", "resume", "confused"};
int index = random.Next(wordDictionary.Count);
String randomWord = wordDictionary[index];

foreach(char x in randomWord)
{
    Console.Write("_ ");
}

int lengthOfWordToGuess = randomWord.Length;
int amountOfTimesWrong = 0;
List<char> currentLettersGuessed = new List<char>();
int currentLettersRight = 0;

while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
{
    Console.Write("\nLetters guessed so far: ");
    foreach (char letter in currentLettersGuessed)
    {
        Console.Write(letter + " ");
    }
    Console.Write("\nGuess a letter: ");
    char letterGuessed = Console.ReadLine().ToLower()[0];
    if (currentLettersGuessed.Contains(letterGuessed))
    {
        Console.WriteLine("\nYou have already guessed this letter.");
        HangmanPrinter.PrintHangman(amountOfTimesWrong);
        currentLettersRight = WordPrinter.PrintWord(currentLettersGuessed, randomWord);
        LinePrinter.PrintLines(randomWord);
    }
    else
    {
        bool right = false;
        for (int i = 0; i < randomWord.Length; i++)
        {
            if (letterGuessed == randomWord[i])
            {
                right = true;
            }
        }
        if (right)
        {
            HangmanPrinter.PrintHangman(amountOfTimesWrong);
            currentLettersGuessed.Add(letterGuessed);
            currentLettersRight = WordPrinter.PrintWord(currentLettersGuessed, randomWord);
            Console.Write("\r\n");
            LinePrinter.PrintLines(randomWord);
        }
        else
        {
            amountOfTimesWrong++;
            currentLettersGuessed.Add(letterGuessed);
            HangmanPrinter.PrintHangman(amountOfTimesWrong);
            currentLettersRight = WordPrinter.PrintWord(currentLettersGuessed, randomWord);
            Console.Write("\r\n");
            LinePrinter.PrintLines(randomWord);
        }
    }
}
Console.WriteLine("\r\nGame Over! Thanks for Playing!");
