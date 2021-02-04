using System;
using System.Collections.Generic;
using System.Text;

namespace AdCodingApp
{
    public static class CommonStringObsoleted
    {

        public static bool isLogOn = false; // Whether turn log on
        public static int round = 0;  // Show the log for this round

        /// <summary>
        /// The wrapper method, accept a string list and return the common string
        /// </summary>
        /// <param name="sList">A list of strings to be compared</param>
        /// <returns>The common string of strings in sList</returns>
        public static string FindCommonString(List<string> sList)
        {
           

            if (sList == null || sList.Count == 0) throw new ArgumentNullException("String List shouldn't be null or empty");
            int rd = 0; //Round
            while (sList.Count > 1)
            {
                rd += 1;
                string s1 = null; //Compare string1
                string s2 = null; //Compare string2
                string overlap = null;
                //string result = null;
                int maxLength = -1;
                for (int i = 0; i < sList.Count - 1; i++)
                {
                    for (int j = i + 1; j < sList.Count; j++)
                    {
                        var c1 = sList[i];
                        var c2 = sList[j];
                        var result = FindLongestSubstring(c1, c2);
                        if(rd == round && round > 0) Console.WriteLine($"Length:{result.Length} || ({sList[i]}) && ({sList[j]}) = ({result})");

                        var resultLength = result == null ? 0 : result.Length;

                        if (resultLength > maxLength)
                        {
                            maxLength = resultLength;
                            s1 = sList[i];
                            s2 = sList[j];
                            overlap = result;
                        }else if (resultLength == maxLength)
                        {
                            string concatString1 = ConcatTwoString(s1, s2, overlap);
                            string concatString2 = ConcatTwoString(c1, c2, result);
                            //Console.WriteLine($"S {s1}  &&     {s2}     =   {concatString1}");
                            //Console.WriteLine($"C {c1}  &&     {c2}     =   {concatString2}");
                            if (concatString2.Length > concatString1.Length)
                            {
                                maxLength = resultLength;
                                s1 = sList[i];
                                s2 = sList[j];
                                overlap = result;
                            }
                        }
                    }
                }
                string concatString = ConcatTwoString(s1, s2, overlap);
                                
                //Add concatenated string and remove 2 originated strings
                sList.Add(concatString);
                sList.Remove(s1);
                sList.Remove(s2);

                //Show log or not
                if (isLogOn) {
                    var logString = new StringBuilder();
                    logString.AppendLine($"Round {rd}:");
                    logString.AppendLine($"({s1}) && ({s2})");
                    logString.AppendLine($"Overlap is ({overlap})");
                    logString.AppendLine($"concatenate to ({concatString})");
                    logString.AppendLine($"New String List is:");
                    logString.AppendLine(String.Join("\n", sList));
                    logString.AppendLine("----------------------------");
                    Console.WriteLine(logString.ToString());
                }
            }
            
            return sList[0];
        }

        /// <summary>
        /// Method that finds the maximum overlapped string of two strings
        /// </summary>
        /// <param name="s1">The first string</param>
        /// <param name="s2">The second string</param>
        /// <returns>Maximum overlapped string of s1 and s2</returns>
        public static String FindLongestSubstring(String s1, String s2)
        {
            if (s1 == null || s2 == null) throw new ArgumentNullException("String shouldn't be null");

            // One string contain another
            if (s1.Contains(s2)) return s2;
            if (s2.Contains(s1)) return s1;

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
            int s2Position = 0; //The start position of the overlapped substring in s1

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

                        if (!(i == s1.Length && j == s2.Length) && !(i == LCStuff[i, j] && j == LCStuff[i, j]))
                        {
                            if (LCStuff[i, j] > maxOverlapLength)
                            {
                            //maxOverlapLength = LCStuff[i, j];
                            
                                maxOverlapLength = LCStuff[i, j];
                                s1Position = i;
                                s2Position = j;
                            }                            
                        }
                    }
                    else
                        LCStuff[i, j] = 0;
                }
            }

            if (maxOverlapLength == 0) return null;

            //if((s1Position==0 && (s2Position+maxOverlapLength)==s2.Length) || (s2Position == 0 && (s1Position + maxOverlapLength) == s1.Length))
            if ((s1Position == s1.Length && s2Position == maxOverlapLength) || (s2Position == s2.Length && s1Position == maxOverlapLength))
            {
                longestOverlapString = s1.Substring(s1Position - maxOverlapLength, maxOverlapLength);
                return longestOverlapString;
            }

            return longestOverlapString;

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
            if (s1 == overlap) return s2;
            else if (s2 == overlap) return s1;            

            // Two strings DO NOT have overlap
            if (overlap == null) return s1 + s2;   // Here just simply concatenate s1 as the former and s2 as latter            

            var maxString = new MaxString();

            var s1Length = GetPrefixAndSuffix(s1,overlap);
                
            var s2Length = GetPrefixAndSuffix(s2, overlap);
            
            int prefixLength = 0;
            string prefixString;
            int suffixLength = 0;
            string suffixString;
            int stringLength = 0;
            s1Length.ForEach(sl1 => {
                s2Length.ForEach(sl2=> { 
                    if(sl1["prefix"]>= sl2["prefix"])
                    {
                        prefixLength = sl1["prefix"];
                        prefixString = s1.Substring(0, sl1["prefix"]);
                    }
                    else
                    {
                        prefixLength = sl2["prefix"];
                        prefixString = s2.Substring(0,sl2["prefix"]);
                    }

                    if (sl1["suffix"] >= sl2["suffix"])
                    {
                        suffixLength = sl1["suffix"];
                        suffixString = s1.Substring(s1.Length - sl1["suffix"]);
                    }
                    else
                    {
                        suffixLength = sl2["suffix"];
                        suffixString = s2.Substring(s2.Length - sl2["suffix"]);
                    }
                    stringLength = prefixLength + suffixLength;
                    if (stringLength > maxString.maxLength)
                    {
                        maxString.maxLength = stringLength;
                        maxString.maxString = prefixString + overlap + suffixString;
                    }
                });
            });

            return maxString.maxString;
        }

        /// <summary>
        /// Find all prefix length and suffix length pairs according to all overlap positions in string s
        /// </summary>
        /// <param name="s">Input string</param>
        /// <param name="overlap">Overlap that need to locate in string s</param>
        /// <returns>A list of dictonary that each dictionary represents one position of overlap in the string, and includes the length of both prefix and suffix</returns>
        public static List<Dictionary<string,int>> GetPrefixAndSuffix(string s, string overlap)
        {
            var result = new List<Dictionary<string, int>>();
            int StartIndex = 0;

            while (s.IndexOf(overlap, StartIndex) != -1)
            {
                int prefixLength = s.IndexOf(overlap, StartIndex);
                int suffixLength = s.Length - overlap.Length - prefixLength;
                var dictionary = new Dictionary<string, int>();
                dictionary.Add("prefix", prefixLength);
                dictionary.Add("suffix", suffixLength);
                result.Add(dictionary);
                StartIndex = prefixLength + 1;
            }

            return result;
        }
    }
}
