using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Core.Models;

namespace Wordle.Core.Extensions
{
    public static class StringExtensions
    {
        public static Pattern ToPattern(this string str)
        {
            var chars = new List<string>()
            {
                str[0].ToString(),
                str[1].ToString(),
                str[2].ToString(),
                str[3].ToString(),
                str[4].ToString(),
            };
            var pattern = new Pattern()
            {
                First = chars[0] == "c" ? State.Correct : chars[0] == "m" ? State.Misplaced : State.Incorrect,
                Second = chars[1] == "c" ? State.Correct : chars[1] == "m" ? State.Misplaced : State.Incorrect,
                Third = chars[2] == "c" ? State.Correct : chars[2] == "m" ? State.Misplaced : State.Incorrect,
                Fourth = chars[3] == "c" ? State.Correct : chars[3] == "m" ? State.Misplaced : State.Incorrect,
                Fifth = chars[4] == "c" ? State.Correct : chars[4] == "m" ? State.Misplaced : State.Incorrect,
            };
            return pattern;
        }
    }
}
