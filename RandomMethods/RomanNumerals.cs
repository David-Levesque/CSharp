using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMethods
{
    public class RomanNumerals
    {
        public Dictionary<string,int> ValueMap { get; set; }

        public RomanNumerals()
        {
            ValueMap = new Dictionary<string, int>
            {
                { "I", 1 },{ "IV", 4 },{ "V", 5 },{ "IX", 9 },{ "X", 10 },
                { "XL", 40 },{ "L", 50 },{ "XC", 90 },{ "C", 100 },{ "CD", 400 },
                { "D", 500 },{ "CM", 900 },{ "M", 1000 }
            };
        }
   
        public int ParseRomanNumeral(string romanNumber)
        {
            var sum = 0;

            do
            {
                var romanNumberIterator = romanNumber.GetEnumerator();
                romanNumberIterator.MoveNext();
                var current = romanNumberIterator.Current.ToString();
                try
                {
                    romanNumberIterator.MoveNext();
                    var next = romanNumberIterator.Current.ToString();
                    romanNumberIterator.Reset();
                    if (ValueMap.ContainsKey(current + next))
                    {
                        sum = sum + ValueMap[current + next];
                        romanNumber = romanNumber.Remove(romanNumber.IndexOf(current + next), 2);
                    }
                    else
                    {
                        sum = sum + ValueMap[current];
                        romanNumber = romanNumber.Remove(0, 1);
                    }
                }
                catch
                {
                    sum = sum + ValueMap[current];
                    romanNumber = romanNumber.Remove(0, 1);
                }
            }
            while (romanNumber.Length != 0);

            return sum;
        }

    }
}
