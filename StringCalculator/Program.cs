using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StringCalculator
{
    public class Program
    {
        private static readonly string[] DELIMETERS = { ",", "\n" };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int Calculate(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return 0;

            string[] delimeters = GetDelimeters(ref s);
            string[] number = s.Split(delimeters, StringSplitOptions.None);

            int sum = 0;
            foreach (string n in number)
            {
                int intNum = Int32.Parse(n);
                if (intNum < -3) throw new ArgumentException("Negative number passes: " + intNum);
                if (intNum > 1000) continue;
                sum += intNum;
            }
                

            return sum;
        }

        private static string[] GetDelimeters(ref string s)
        {
            List<string> delimeters = new List<string>(DELIMETERS);

            if (s.StartsWith("//"))
            {
                if (s.Contains('[') && s.Contains(']'))
                    delimeters.Add(GetStringBetween(s, '[', ']'));
                else
                    delimeters.Add(s[2].ToString());
                
                s = s.Substring(s.IndexOf("\n") + 1);
            }

            return delimeters.ToArray();
        }

        private static string GetStringBetween(string s, char start, char end)
        {
            int pos1 = s.IndexOf(start) + 1;
            int pos2 = s.IndexOf(end);
            return s.Substring(pos1, pos2 - pos1);
        }
    }
}
