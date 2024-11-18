using System;
using System.Collections.Generic;

namespace Logic.Services
{
    public class LongestVowelSubstringService : ILongestVowelSubstringService
    {
        private readonly HashSet<char> _vowels = new() { 'a', 'e', 'i', 'o', 'u', 'y' };

        public string FindLongestVowelSubstring(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            int maxLength = 0;
            string longestSubstring = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (_vowels.Contains(input[i]))
                {
                    for (int j = input.Length - 1; j > i; j--)
                    {
                        if (_vowels.Contains(input[j]))
                        {
                            string substring = input.Substring(i, j - i + 1);
                            if (substring.Length > maxLength)
                            {
                                maxLength = substring.Length;
                                longestSubstring = substring;
                            }
                            break;
                        }
                    }
                }
            }

            return longestSubstring;
        }
    }
}