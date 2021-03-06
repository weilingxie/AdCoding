﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCodingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                try
                {
                    if (!File.Exists(line))
                    {
                        Console.WriteLine("File does not exist.");
                    }
                    else
                    {
                        // Read the file as one string.
                        string text = File.ReadAllText(line);
                        List<string> sList = text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();
                        Console.WriteLine($"Strings in the file: {String.Join(", ", sList)}");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine($"Common String is: {CommonString.FindCommonString(sList)}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
