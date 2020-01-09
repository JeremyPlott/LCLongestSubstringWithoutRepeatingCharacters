using System;
using System.Collections.Generic;

namespace LCLongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "pwwkew";

            HashSet<char> substringHash = new HashSet<char>();

            int longestSubstring = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int substringLength = 0;

                for (int j = i; j < s.Length; j++)
                {
                    if (substringHash.Contains(s[j]))
                    {
                        break;
                    }
                    substringHash.Add(s[j]);
                    substringLength++;
                }
                if (substringLength > longestSubstring)
                {
                    longestSubstring = substringLength;
                }
                substringHash.Clear();
            }

            Console.WriteLine(longestSubstring);

        }
    }
}
