using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCodingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> sList = new List<string>() { "abc", "def", "ghi" };
            String s1 = null;
            String s2 = null;
            String overlap = null;
            Console.WriteLine(CommonString.FindCommonString(sList));
            //while (sList.Count > 1)
            //{
            //for (int i = 0; i < sList.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < sList.Count; j++)
            //    {
            //        Console.WriteLine($"i={i},j={j}");
            //        Console.WriteLine(CommonString.FindLongestSubstring(sList[i], sList[j]));
            //    }
            //}
            //    sList.RemoveAt(0);
            //    Console.WriteLine($"sList Length={sList.Count}");
            //}
            Console.ReadLine();
        }
    }
}
