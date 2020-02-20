using System;
using System.Collections.Generic;

namespace LCLongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "pppppppppppppppppwwkew";

            HashSet<char> usedLetters = new HashSet<char>();

            int longestSubstring = 0;

            for (int startingLetter = 0; startingLetter < s.Length; startingLetter++)
            {
                while (startingLetter < s.Length - 1 && s[startingLetter].Equals(s[startingLetter + 1])) startingLetter++;

                int substringLength = 0;

                if (longestSubstring > s.Length - startingLetter) Console.WriteLine(longestSubstring);

                for (int newestLetter = startingLetter; newestLetter < s.Length; newestLetter++)
                {
                    if (usedLetters.Contains(s[newestLetter])) break;

                    usedLetters.Add(s[newestLetter]);
                    substringLength++;
                }
                if (substringLength > longestSubstring)
                {
                    longestSubstring = substringLength;
                }

                usedLetters.Clear();
            }

            Console.WriteLine(longestSubstring);

        }
    }
}
