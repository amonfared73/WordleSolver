using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Core.Models
{
    public class EntropyItem
    {
        public string Word { get; set; }
        public double Information { get; set; }

        public override string ToString()
        {
            return string.Format("word: {0}, Information given: {1} bits", Word, Information.ToString());
        }
    }
}
