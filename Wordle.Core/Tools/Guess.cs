using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Core.Models;

namespace Wordle.Core.Tools
{
    public static class Guess
    {
        private static List<Pattern> _patterns = new List<Pattern>();
        public static List<Pattern> GetAllPatterns()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            for (int m = 0; m < 3; m++)
                            {
                                _patterns.Add(new Pattern()
                                {
                                    First = (State)i,
                                    Second = (State)j,
                                    Third = (State)k,
                                    Fourth = (State)l,
                                    Fifth = (State)m
                                });
                            }
                        }
                    }
                }
            }
            return _patterns;
        }
    }
}
