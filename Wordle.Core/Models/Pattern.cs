using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Core.Models
{
    public class Pattern
    {
        public State First { get; set; }
        public State Second { get; set; }
        public State Third { get; set; }
        public State Fourth { get; set; }
        public State Fifth { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", First.ToString(), Second.ToString(), Third.ToString(), Fourth.ToString(), Fifth.ToString());
        }
    }
}
