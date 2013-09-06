using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Q3
    {
        public int a;
        public static void guessLetters(String guessString)
        {
            guessString = guessString.ToUpper();
            char[] cArr = guessString.ToCharArray();
            bool[] guessed = new bool[cArr.Length];
            Random r = new Random();
            HashSet<char> guessedWords = new HashSet<char>();
            while (!isDoneGuessing(guessed))
            {
                int value = writeInfo(cArr, guessed);
                char newGuess = guessNewLetter(value, r, guessedWords);
                guessedWords.Add(newGuess);
                for (int i = 0; i < cArr.Length; i++)
                {
                    if (newGuess == cArr[i])
                        guessed[i] = true;

                }
            }
            writeInfo(cArr, guessed);
        }


        public static bool isDoneGuessing(bool[] guessed)
        {
            foreach (bool b in guessed)
            {
                if (!b)
                    return false;

            }
            return true;


        }

        public static char guessNewLetter(int value, Random r, HashSet<char> guessedWords)
        {
            int guessRange = 26;
            if (value < 26)
                guessRange = value;

            char newGuess = (char)r.Next(guessRange);
            newGuess = (char)(newGuess + 'A');
            while (guessedWords.Contains(newGuess))
            {
                newGuess = (char)r.Next(guessRange);
                newGuess = (char)(newGuess + 'A');
            }
            return newGuess;

        }

        public static int writeInfo(char[] cArr, bool[] guessed)
        {
            int value = 0;
            for (int i = 0; i < cArr.Length; i++)
            {
                if (guessed[i])
                    Console.Write(cArr[i] + " ");
                else
                {
                    Console.Write("_ ");
                    value += (cArr[i] - 'A' + 1);
                }
            }
            Console.WriteLine(value);
            return value;

        }
    }
}
