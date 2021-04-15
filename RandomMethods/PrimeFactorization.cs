using System;
using System.Collections.Generic;

namespace RandomMethods
{
    //im aware there are much better algorithms out there. i did this without looking anything up as practice. 
    public class PrimeFactorization
    {
        public string ExpessFactors(int number)
        {
            var factors = GetFactors(number);
            var primeFactors = GetPrimeFactors(factors);
            var factorization = GetFactorization(primeFactors, number);
            var exponantForm = Display(factorization);

            return Display(factorization);
        }

        private string Display(SortedDictionary<int, int> factorization)
        {
            var str = "";
            var counter = 1;
            foreach (var item in factorization)
            {
                if (item.Value > 1)// if exponant 2 or more 
                {
                    if (counter == factorization.Count)
                    {
                        str += item.Key.ToString() + "^" + item.Value.ToString();
                    }
                    else
                    {
                        str += item.Key.ToString() + "^" + item.Value.ToString() + " X ";
                    }
                }
                else
                {
                    if (counter == factorization.Count)
                    {
                        str += item.Key.ToString();
                    }
                    else
                    {
                        str += item.Key.ToString() + " X ";
                    }
                }
                counter += 1;
            }
            return str;
        }

        private SortedDictionary<int, int> GetFactorization(Stack<int> primeFactors, int number)
        {
            var dictionary = new SortedDictionary<int, int>();//sorted so the displayed string will be in correct order
            while (primeFactors.Count != 0)
            {
                var currentNumber = primeFactors.Peek();
                double decimalChecker = (double)number / (double)currentNumber;
                int wholeNumber = number / currentNumber;
                if (decimalChecker == wholeNumber)//if there is a decimal remainder, it means the number doesnt divide perfectly and its time to move on
                {
                    if (!dictionary.ContainsKey(currentNumber))
                    {
                        dictionary.Add(currentNumber, 1);
                    }
                    else
                    {
                        dictionary[currentNumber] += 1;
                    }
                    number = wholeNumber;
                }
                else
                {
                    primeFactors.Pop();
                }
            }
            return dictionary;
        }

        private Stack<int> GetPrimeFactors(List<int> factors)
        {
            var primes = new Stack<int>();// a stack so im sure i get the biggest primes first in decreasing order
            var comparer = factors;
            foreach (var factor in factors)
            {
                var counter = 0;
                foreach (var compareItem in comparer)
                {
                    if (factor % compareItem == 0)
                    {
                        counter += 1;
                    }
                }
                if (counter == 2)//1 or itself
                {
                    primes.Push(factor);
                }
            }
            return primes;
        }

        private List<int> GetFactors(int number)
        {
            var factors = new List<int>();
            for (int i = 1; i < number + 1; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors;
        }
    }
}
