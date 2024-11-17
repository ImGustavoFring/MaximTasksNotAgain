using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class CharacterCounterService : ICharacterCounterService
    {
        public Dictionary<char, int> CountCharacterOccurrences(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            return input.GroupBy(c => c)
                        .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
