using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Core.Models;
using Wordle.Core.Services;
using Wordle.Core.Tools;
using static System.Net.Mime.MediaTypeNames;

namespace Wordle.Solver.Services
{
    public static class Entropy 
    {
        public static IEnumerable<EntropyItem> GetAllEntropies()
        {
            var entropyItems = new List<EntropyItem>();

            var words = WordList.GettAllWords();
            var wordsCount = words.Count();
            var patterns = Guess.GetAllPatterns();

            double probablity = 0;
            double information = 0;

            IEnumerable<string> selectiveWords;
            int selectiveWordsCount;

            int i = 0;
            foreach (var word in words)
            {
                information = 0;
                foreach (var pattern in patterns)
                {
                    selectiveWords = WordList.FilterWords(words, word, pattern);
                    selectiveWordsCount = selectiveWords.Count();
                    probablity = (double)selectiveWordsCount / (double)wordsCount;
                    if (probablity > 0)
                        information += -1 * probablity * Math.Log2(probablity);
                }
                entropyItems.Add(new EntropyItem()
                {
                    Word = word,
                    Information = Math.Round(information, 3),
                });
                Console.WriteLine(string.Format("{0}: {1}, Information: {2} bits", i.ToString(), word, Math.Round(information, 3).ToString()));
                i++;
            }
            return entropyItems;
        }

        public static IEnumerable<EntropyItem> GetEntropies(IEnumerable<string> selectedWords)
        {
            var entropyItems = new List<EntropyItem>();

            var words = WordList.GettAllWords();
            var filteredWords = from word in words join selectedWord in selectedWords on word.ToString() equals selectedWord.ToString() select word;

            double filteredWordsCount = filteredWords.Count();
            double wordsCount = words.Count();
            var patterns = Guess.GetAllPatterns();

            double probablity = 0;
            double information = 0;

            IEnumerable<string> selectiveWords;
            int selectiveWordsCount;

            int i = 0;
            foreach (var filteredWord in filteredWords)
            {
                information = 0;
                foreach (var pattern in patterns)
                {
                    selectiveWords = WordList.FilterWords(filteredWords, filteredWord, pattern);
                    selectiveWordsCount = selectiveWords.Count();
                    probablity = (double)selectiveWordsCount / (double)filteredWordsCount;
                    if (probablity > 0)
                        information += -1 * probablity * Math.Log2(probablity);
                }
                entropyItems.Add(new EntropyItem()
                {
                    Word = filteredWord,
                    Information = Math.Round(information, 3),
                });
                i++;

                Console.Write("\r{0}  ", i);
                Console.Write("out of {0} words", filteredWordsCount.ToString());
            }


            return entropyItems;
        }
    }
}
