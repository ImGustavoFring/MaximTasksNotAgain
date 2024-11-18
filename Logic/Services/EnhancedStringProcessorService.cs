using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Services;

namespace Logic.Services
{
    public class EnhancedStringProcessorService : IStringProcessorService
    {
        private readonly List<string> _blackList;
        private readonly string _validChars = "abcdefghijklmnopqrstuvwxyz";

        public EnhancedStringProcessorService(List<string> blackList)
        {
            _blackList = blackList;
        }

        public string ProcessString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            foreach (var blackListItem in _blackList)
            {
                if (input.Contains(blackListItem))
                {
                    throw new ArgumentException($"Input contains invalid substring: '{blackListItem}'");
                }
            }

            var invalidCharacters = CheckInvalidCharacters(input);
            if (invalidCharacters.Any())
            {
                throw new ArgumentException($"Input contains invalid characters: {string.Join(", ", invalidCharacters)}");
            }

            if (input.Length % 2 == 0)
            {
                int mid = input.Length / 2;
                string firstHalf = Reverse(input.Substring(0, mid));
                string secondHalf = Reverse(input.Substring(mid));
                return firstHalf + secondHalf;
            }
            else
            {
                string reversed = Reverse(input);
                return reversed + input;
            }
        }

        private string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private List<char> CheckInvalidCharacters(string input)
        {
            return input.Where(c => !_validChars.Contains(c)).ToList();
        }
    }
}
