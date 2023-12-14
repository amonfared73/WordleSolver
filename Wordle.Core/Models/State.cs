using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Core.Models
{
    public enum State
    {
        Incorrect = 0,
        Misplaced = 1,
        Correct = 2,
    }
}
