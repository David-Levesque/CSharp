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

            //enter roman numeral 1-4000
            //ex:3345
            var convertedNumber = rNumeralConverter.ParseRomanNumeral("MMMCCCXLV");
            Console.WriteLine(convertedNumber.ToString());
            #endregion

            //calculate Network Address and broadcast address with an ip and mask in CIDR
            #region Ip

            CalculateIpMask calculateIpMask = new CalculateIpMask();
            //ex:"192.168.0.5/24","09.45.000.2/18"
            calculateIpMask.Display("192.168.0.5/24");
            #endregion
        }
    }
}
