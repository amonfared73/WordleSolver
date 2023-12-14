using Wordle.Core.Models;
using Wordle.Core.Tools;
using System.Collections.Generic;
using Wordle.Solver.Services;
using Wordle.Core.Extensions;

namespace Wordle.Solver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string guess;
            Pattern pattern;
            string response = "n";

            Console.WriteLine("This app solves the Wordle game through Information theory");
            Console.WriteLine("Here are the top 10 words to reach maximum information about the answer");
            var topwords = WordList.GetTopWords();
            var words = WordList.GettAllWords().ToList();

            foreach (var word in topwords)
            {
                Console.WriteLine(word);
            }

            int i = 1;
            while (response != "y")
            {
                Console.WriteLine("Guess number " + i.ToString());
                Console.Write("Write your guess: ");
                guess = Console.ReadLine().ToLower();
                Console.WriteLine("Write your pattern: i: incorrect, m: misplaced, c:correct: ");
                pattern = Console.ReadLine().ToLower().ToPattern();

                var selectedWords = WordList.FilterWords(words, guess, pattern);
                var selectedEntropies = Entropy.GetEntropies(selectedWords).ToList().OrderByDescending(w => w.Information);
                words.Clear();
                words = selectedWords.ToList();



                Console.WriteLine("Words matching your pattern: ");
                foreach (var w in selectedEntropies)
                {
                    Console.WriteLine(@"{0}:", w);
                }


                Console.WriteLine("Exit? (Y/N): ");
                response = Console.ReadLine().ToLower();
                i++;

            }
            Console.WriteLine("GoodBye!");

        }
    }
}