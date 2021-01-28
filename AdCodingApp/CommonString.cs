using System;
using System.Collections.Generic;
using System.Text;

namespace AdCodingApp
{
    public static class CommonString
    {
        /// <summary>
        /// The wrapper method, accept a string list and return the common string
        /// </summary>
        /// <param name="sList">A list of strings to be compared</param>
        /// <returns>The common string of strings in sList</returns>
        public static string FindCommonString(List<string> sList)
        {

            if (sList == null || sList.Count == 0) throw new ArgumentNullException("String List shouldn't be null or empty");

            String s1 = null; //Originated string1
            String s2 = null; //Originated string2
            String overlap = null;
            int maxLength = -1;

            while (sList.Count > 1)
            {
                for (int i = 0; i < sList.Count - 1; i++)
                {
                    for (int j = i + 1; j < sList.Count; j++)
                    {
                        overlap = FindLongestSubstring(sList[i], sList[j]);
                        if ((overlap == null ? 0 : overlap.Length) >= maxLength)
                        {
                            maxLength = overlap == null ? 0 : overlap.Length;
                            s1 = sList[i];
                            s2 = sList[j];
                        }
                    }
                }
                String concatString = ConcatTwoString(s1, s2, overlap);

                //Add concatenated string and remove 2 originated strings
                sList.Add(concatString);
                sList.Remove(s1);
                sList.Remove(s2);
            }

            String finalComonString = sList[0];
            return finalComonString;
        }

        /// <summary>
        /// Method that finds the maximum overlapped string of two strings
        /// </summary>
        /// <param name="s1">The first string</param>
        /// <param name="s2">The second string</param>
        /// <returns>Maximum overlapped string of s1 and s2</returns>
        public static String FindLongestSubstring(String s1, String s2)
        {
            if(s1 == null || s2 == null) throw new ArgumentNullException("String shouldn't be null");            

            String longestOverlapString = null;
            int m = s1.Length;
            int n = s2.Length;

            /* Create a table to store lengths of longest common suffixes of substrings.
               Note that LCSuff[i][j] contains length of longest common suffix of X[0..i-1] and Y[0..j-1]. 
               The first row and first column entries have no logical meaning,
               they are used only for simplicity of program
            */
            int[,] LCStuff = new int[m + 1, n + 1];

            // To store length of the longest common substring
            int maxOverlapLength = 0;

            int s1Position = 0; //The start position of the overlapped substring in s1

            // Following steps build LCSuff[m+1][n+1] in bottom up fashion
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        LCStuff[i, j] = 0;
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        LCStuff[i, j] = LCStuff[i - 1, j - 1] + 1;

                        if (LCStuff[i, j] > maxOverlapLength)
                        {
                            maxOverlapLength = LCStuff[i, j];
                            s1Position = i;
                        }
                        
                    }
                    else
                        LCStuff[i, j] = 0;
                }
            }

            if (maxOverlapLength == 0)
            {
                return null;
            }
            else
            {
                longestOverlapString = s1.Substring(s1Position - maxOverlapLength, maxOverlapLength);
                return longestOverlapString;
            }
                      
        }

        /// <summary>
        /// Method that concatenates 2 strings by providing overlapped string between them
        /// </summary>
        /// <param name="s1">The first string</param>
        /// <param name="s2">The second string</param>
        /// <param name="overlap">The overlap substring bewteen s1 and s2</param>
        /// <returns>The concatenated string of s1 and s2</returns>
        public static string ConcatTwoString(string s1, string s2, string overlap)
        {
            if (s1 == null || s2 == null) throw new ArgumentNullException("String shouldn't be null");

            // One string contains another
            if (s1 == overlap) {
                return s2;
            } else if (s2 == overlap)
            {
                return s1;
            }

            // Two strings DO NOT have overlap
            if (overlap == null)
            {
                return s1 + s2;   // Here just simply concatenate s1 as the former and s2 as latter
            }

            String prefix; // Prefix of the concatenated string
            String suffix; // Suffix of the concatenated string
            int s1StartPosition = s1.IndexOf(overlap);  //Start position of the overlap substring in s1
            int s2StartPosition = s2.IndexOf(overlap);  //Start position of the overlap substring in s2

            // Two strings both have prefix, choose the shorter one, if they are the same length, choose s1
            if (s1StartPosition > 0  && s2StartPosition > 0 ) prefix = s1StartPosition <= s2StartPosition ? s1.Substring(0, s1StartPosition) : s2.Substring(0, s2StartPosition);                
            else prefix = s1StartPosition == 0? s2.Substring(0, s2StartPosition): s1.Substring(0, s1StartPosition);

            // Two strings both have suffix, choose the shorter one, if they are the same length, choose s1
            if (s1StartPosition < (s1.Length - overlap.Length) && s2StartPosition < (s2.Length - overlap.Length)) suffix = (s1.Length - s1StartPosition) <= (s2.Length - s2StartPosition)? s1.Substring((s1StartPosition + overlap.Length)): s2.Substring((s2StartPosition + overlap.Length));
            else suffix = (s1StartPosition + overlap.Length) == s1.Length ? s2.Substring((s2StartPosition + overlap.Length)) : s1.Substring((s1StartPosition + overlap.Length));                

            // Assemble the string
            String concatString = prefix + overlap + suffix;
            return concatString;
        }        
    }
}
