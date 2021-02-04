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
                //string overlap = null;
                //string result = null;
                var maxString = new OverlapString();                
                int maxLength = -1;
                for (int i = 0; i < sList.Count - 1; i++)
                {
                    for (int j = i + 1; j < sList.Count; j++)
                    {
                        var c1 = sList[i];
                        var c2 = sList[j];
                        var result = FindLongestCommonString(c1, c2);
                        if (rd == round && round > 0) Console.WriteLine($"Length:{(result.Overlap==null?"N/A":result.Overlap)} || ({sList[i]}) && ({sList[j]}) = ({(result.Concat == null ? "N/A" : result.Concat)})");

                        var resultLength = (result == null || result.Overlap == null) ? 0 : result.Overlap.Length;
                        maxLength = (maxString == null || maxString.Overlap == null) ? -1 : maxString.Overlap.Length;

                        if (resultLength >= maxLength)
                        {                            
                            s1 = sList[i];
                            s2 = sList[j];                         
                            maxString = result;
                            
                        }
                    }
                }
                //string concatString = ConcatTwoString(s1, s2, overlap);

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
                    logString.AppendLine($"Overlap is ({((maxString != null && maxString.Overlap != null) ? maxString.Overlap : "")})");
                    logString.AppendLine($"concatenate to ({((maxString != null && maxString.Concat != null)?maxString.Concat:"")})");
                    logString.AppendLine($"New String List is:");
                    logString.AppendLine(String.Join("\n", sList));
                    logString.AppendLine("----------------------------");
                    Console.WriteLine(logString.ToString());
                }
            }

            return sList[0];
        }

        public static OverlapString FindLongestCommonString(String s1, String s2)
        {
            int s1Length = s1.Length;
            int s2Length = s2.Length;
            var overlap = new OverlapString();

            if (s1 == null || s2 == null) throw new ArgumentNullException("String shouldn't be null");

            // One string contain another
            if (s1.Contains(s2))
            {
                overlap.Overlap = s1;
                overlap.Concat = s1;
                return overlap; 
            }

            if (s2.Contains(s1))
            {
                overlap.Overlap = s2;
                overlap.Concat = s2;
                return overlap;
            }

            string overlap1 = null;
            string overlap2 = null;
            string concat1 = null;
            string concat2 = null;

            for (int i = s1Length; i > 0; i--)
            {
                for (int j = 0; j < s2Length; j++)
                {
                    while(s1.Substring(0,i).Equals(s2.Substring(j)))
                    {
                        overlap1 = s1.Substring(0, i);
                        concat1 = s2.Substring(0,j) + overlap1 + s1.Substring(i);
                        break;
                    }
                    if (overlap1 != null) break;
                }
                if (overlap1 != null) break;
            }            

            for (int i = s2Length; i > 0; i--)
            {
                for (int j = 0; j < s1Length; j++)
                {

                    while (s2.Substring(0, i).Equals(s1.Substring(j)))
                    {
                        overlap2 = s2.Substring(0, i);
                        concat2 = s1.Substring(0, j) + overlap2 + s2.Substring(i);
                        break;
                    }
                    if (overlap2 != null) break;
                }
                if (overlap2 != null) break;
            }

            int length1 = overlap1 == null ? 0 : overlap1.Length;
            int length2 = overlap2 == null ? 0 : overlap2.Length;

            if(length1 == 0 && length2 == 0)
            {
                overlap.Overlap = null;
                overlap.Concat = s1 + s2;
                return overlap;
            }

            if (length1 >= length2) {
                overlap.Overlap = overlap1;
                overlap.Concat = concat1;
            }
            else
            {
                overlap.Overlap = overlap2;
                overlap.Concat = concat2;
            }

            return overlap;           
        }
    }
}
