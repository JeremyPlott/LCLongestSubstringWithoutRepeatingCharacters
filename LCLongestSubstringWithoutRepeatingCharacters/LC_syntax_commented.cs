An uncommented version can be found after this

**Commented solution**
```
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {

        //we will use this hash set to store the letters that have been used in our current substring
        HashSet<char> usedLetters = new HashSet<char>();

        //this will be used to track the longest substring we have found so far
        int longestSubstring = 0;

        //now we can start to iterate through the string, checking each letter 
        for (int startingLetter = 0; startingLetter < s.Length; startingLetter++)
        {
            //this while-loop will immediately skip over any repeated letters. It is NOT required.
            //while we are not at the end AND the current letter == the next letter...
            //we use length - 1 because we are using index + 1 to check the next index and will
            //get out-of-range exceptions otherwise.
            //with the test cases this made pretty much no difference with time and memory, but if
            //we had different test cases this kind of optimization can make a big difference.
            while (startingLetter < s.Length - 1 && s[startingLetter].Equals(s[startingLetter + 1]))
            {
                startingLetter++;
            }

            //this will track the length of our current substring
            int substringLength = 0;

            //this is another unnecessary optimization that made it run about 15% faster.
            //if our current longest substring is longer than the remaining letters to check, we can
            //immediately return our longest substring since it is impossible to get a longer one.
            if (longestSubstring > s.Length - startingLetter) return longestSubstring;

            //our first for-loop is iterating through each potential start of the substring, so now
            //we need to actually check how long the substring is.
            //we want to start from our starting letter so we set it to that, and then iterate like normal
            for (int newestLetter = startingLetter; newestLetter < s.Length; newestLetter++)
            {
                //if we encounter a letter that has already been seen we can stop this for-loop and iterate our starting letter
                if (usedLetters.Contains(s[newestLetter]))
                {
                    break;
                }

                //add each new letter to our set of used letters
                usedLetters.Add(s[newestLetter]);

                //and then add one to our substring length
                substringLength++;
            }

            //once our unique substring has been built we can check if it is the new longest, and if so, save that value
            if (substringLength > longestSubstring)
            {
                longestSubstring = substringLength;
            }

            //now we want to clear out our used letter set so we can start fresh with the next starting letter
            usedLetters.Clear();
        }

        //return the tracked value of our longest substring
        return longestSubstring;
    }
}
```

** Uncommented solution**
```
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {

        HashSet<char> usedLetters = new HashSet<char>();
        int longestSubstring = 0;

        for (int startingLetter = 0; startingLetter < s.Length; startingLetter++)
        {
            while (startingLetter < s.Length - 1 && s[startingLetter].Equals(s[startingLetter + 1]))
            {
                startingLetter++;
            }

            int substringLength = 0;

            if (longestSubstring > s.Length - startingLetter) return longestSubstring;

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

        return longestSubstring;
    }
}
```