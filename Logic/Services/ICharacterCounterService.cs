using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface ICharacterCounterService
    {
        public Dictionary<char, int> CountCharacterOccurrences(string input);
    }
}
