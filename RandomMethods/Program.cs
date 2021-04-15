using System;

namespace RandomMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //comment out regions you dont want to see by selecting them and pressing ctrl+k+c, uncomment with ctrl+k+u


            //Roman numeral converting function
            #region Roman numeral
            RomanNumerals rNumeralConverter = new RomanNumerals();
            //ex:3345
            var convertedNumber = rNumeralConverter.ParseRomanNumeral("MMMCCCXLV");
            Console.WriteLine(convertedNumber.ToString());
            #endregion



            //calculate Network Address and broadcast address with an ip and mask in CIDR
            #region Ip
            CalculateIpMask calculateIpMask = new CalculateIpMask();
            //ex:"192.168.0.5/24","09.45.000.2/18"
            var ipData = calculateIpMask.Display("192.168.0.5/24");
            foreach (var item in ipData)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            #endregion



            //Return string representing the Prime Factorization of a positive intiger 1 to 1_000_000_000
            #region Prime Factorization
            PrimeFactorization primeFactorization = new PrimeFactorization();
            //ex: 2 X 3 X 5 = 115
            var factorized = primeFactorization.ExpessFactors(115);
            Console.WriteLine(factorized);
            #endregion
        }
    }
}
