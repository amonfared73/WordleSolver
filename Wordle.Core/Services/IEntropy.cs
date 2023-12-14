using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Core.Models;

namespace Wordle.Core.Services
{
    public interface IEntropy
    {
        IEnumerable<EntropyItem> GetAllEntropies();
    }
}
