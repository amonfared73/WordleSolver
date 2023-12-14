using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wordle.Core.Models;

namespace Wordle.Core.Tools
{
    public class WordList
    {
        private static readonly string jsonPath = @"..\..\..\..\Wordle.Core\Resources\words.json";
        public static int Count = GettAllWords().Count();
        public static IEnumerable<string> GettAllWords()
        {
            return JsonSerializer.Deserialize<IEnumerable<string>>(File.ReadAllText(jsonPath));
        }
        public static List<EntropyItem> GetTopWords()
        {
            var topWords = new List<EntropyItem>();
            topWords.Add(new EntropyItem() { Word = "tares", Information = 6.215 });
            topWords.Add(new EntropyItem() { Word = "lares", Information = 6.167 });
            topWords.Add(new EntropyItem() { Word = "rales", Information = 6.132 });
            topWords.Add(new EntropyItem() { Word = "rates", Information = 6.116 });
            topWords.Add(new EntropyItem() { Word = "nares", Information = 6.086 });
            topWords.Add(new EntropyItem() { Word = "tales", Information = 6.069 });
            topWords.Add(new EntropyItem() { Word = "teras", Information = 6.066 });
            topWords.Add(new EntropyItem() { Word = "arles", Information = 6.049 });
            topWords.Add(new EntropyItem() { Word = "tears", Information = 6.037 });
            topWords.Add(new EntropyItem() { Word = "tores", Information = 6.030 });
            return topWords;
        }
        public static IEnumerable<string> FilterWords(IEnumerable<string> words, string word, Pattern pattern)
        {
            var states = new List<KeyValuePair<string, State>>()
            {
                new KeyValuePair<string, State>(word[0].ToString(),pattern.First),
                new KeyValuePair<string, State>(word[1].ToString(),pattern.Second),
                new KeyValuePair<string, State>(word[2].ToString(),pattern.Third),
                new KeyValuePair<string, State>(word[3].ToString(),pattern.Fourth),
                new KeyValuePair<string, State>(word[4].ToString(),pattern.Fifth),
            }.Select((kvp, index) => new { kvp, index });
            foreach (var state in states)
            {
                if (state.kvp.Value == State.Incorrect)
                    words = words.Where(w => !w.Contains(state.kvp.Key));
                else if (state.kvp.Value == State.Misplaced)
                    words = words.Where(w => w.Contains(state.kvp.Key) && w.IndexOf(state.kvp.Key) != state.index);
                else
                    words = words.Where(w => w.Contains(state.kvp.Key) && w.IndexOf(state.kvp.Key) == state.index);
            }
            return words;
        }
    }
}
