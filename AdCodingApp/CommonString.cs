using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCodingApp
{
    public static class CommonString
    {
        public static bool isLogOn = false; // Whether turn log on
        public static int round = 0;  // Show the log for this round

        /// <summary>
        /// The wrapper method, accept a string list and return the unique concatenated string
        /// </summary>
        /// <param name="sList">A list of strings to be compared and concatenated</param>
        /// <returns>The unique concatenated string of strings in sList</returns>
        public static String FindCommonString(List<string> sList)        
        {            
            if (sList == null || sList.Count == 0) throw new ArgumentNullException("String List shouldn't be null or empty");
            int rd = 0; //Round
            while (sList.Count > 1)
            {
                rd += 1;
                string s1 = null; //Compare string1
                string s2 = null; //Compare string2
                var maxString = new OverlapString();                

                for (int i = 0; i < sList.Count - 1; i++)
                {
                    for (int j = i + 1; j < sList.Count; j++)
                    {
                        var c1 = sList[i];
                        var c2 = sList[j];
                        var result = FindLongestSubstring(c1, c2);
                        if (rd == round && round > 0) Console.WriteLine($"Length:{(result.Overlap ?? "N/A")} || ({sList[i]}) && ({sList[j]}) = ({(result.Concat ?? "N/A")})");

                        var resultLength = (result == null || result.Overlap == null) ? 0 : result.Overlap.Length;
                        int maxLength = (maxString == null || maxString.Overlap == null) ? -1 : maxString.Overlap.Length;

                        if (resultLength >= maxLength)
                        {                            
                            s1 = sList[i];
                            s2 = sList[j];                         
                            maxString = result;
                            
                        }
                    }
                }                

                //Add concatenated string and remove 2 originated strings
                if (maxString != null && maxString.Concat != null)
                {
                    sList.Add(maxString.Concat);
                    sList.Remove(s1);
                    sList.Remove(s2);
                }
                

                //Show log or not
                if (isLogOn)
                {
                    var logString = new StringBuilder();
                    logString.AppendLine($"Round {rd}:");
                    logString.AppendLine($"({s1}) && ({s2})");
                    logString.AppendLine($"Overlap is ({(maxString.Overlap ?? "")})");
                    logString.AppendLine($"concatenate to ({(maxString.Concat ?? "")})");
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
        /// <returns>Object OverlapString that includes maximum overlapped string and concatenated string of s1 and s2 </returns>
        public static OverlapString FindLongestSubstring(String s1, String s2)
        {            
            if (s1 == null || s2 == null) throw new ArgumentNullException("String shouldn't be null");

            int s1Length = s1.Length;
            int s2Length = s2.Length;
            var overlap = new OverlapString();

            // One string contain another
            if (s1.Contains(s2))
            {
                overlap.Overlap = s2;
                overlap.Concat = s1;
                return overlap; 
            }

            if (s2.Contains(s1))
            {
                overlap.Overlap = s1;
                overlap.Concat = s2;
                return overlap;
            }

            var overlapString1 = new OverlapString();
            var overlapString2 = new OverlapString();

            // match from beginning of s1 and end of s2
            for (int i = s1Length; i > 0; i--)
            {
                for (int j = 0; j < s2Length; j++)
                {
                    while(s1.Substring(0,i).Equals(s2.Substring(j)))
                    {
                        overlapString1.Overlap = s1.Substring(0, i); ;
                        overlapString1.Concat = s2.Substring(0, j) + overlapString1.Overlap + s1.Substring(i);
                        break;
                    }
                    if (overlapString1.Overlap != null) break;
                }
                if (overlapString1.Overlap != null) break;
            }
            // match from beginning of s2 and end of s1
            for (int i = s2Length; i > 0; i--)
            {
                for (int j = 0; j < s1Length; j++)
                {

                    while (s2.Substring(0, i).Equals(s1.Substring(j)))
                    {
                        overlapString2.Overlap = s2.Substring(0, i);
                        overlapString2.Concat = s1.Substring(0, j) + overlapString2.Overlap + s2.Substring(i);
                        break;
                    }
                    if (overlapString2.Overlap != null) break;
                }
                if (overlapString2.Overlap != null) break;
            }

            int length1 = overlapString1.Overlap == null ? 0 : overlapString1.Overlap.Length;
            int length2 = overlapString2.Overlap == null ? 0 : overlapString2.Overlap.Length;

            //If there is no overlpa, directly concatenate them
            if (length1 == 0 && length2 == 0)
            {
                overlap.Overlap = null;
                overlap.Concat = s1 + s2;
                return overlap;
            }

            if (length1 >= length2) {
                overlap = overlapString1;
            }
            else
            {
                overlap = overlapString2;
            }

            return overlap;           
        }
    }
}
