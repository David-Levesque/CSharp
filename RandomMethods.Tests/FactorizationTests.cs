using System;
using Xunit;
using FluentAssertions;
using RandomMethods;


namespace RandomMethods.Tests
{
    public class FactorizationTests
    {
        [Fact]
        public void SinglePrime()
        {
            //arrange
            PrimeFactorization pm = new PrimeFactorization();
            //act
            var num1 = pm.ExpessFactors(2);
            var num13 = pm.ExpessFactors(13);
            var num347 = pm.ExpessFactors(347);
            var num63443 = pm.ExpessFactors(63443);
            //assert
            num1.Should().Be("2");
            num13.Should().Be("13");
            num347.Should().Be("347");
            num63443.Should().Be("63443");
        }
        [Fact]
        public void NoExponants()
        {
            //arrange
            PrimeFactorization pm = new PrimeFactorization();
            //act
            var num14 = pm.ExpessFactors(14);
            var num30 = pm.ExpessFactors(30);
            var num115 = pm.ExpessFactors(115);
            var num7854 = pm.ExpessFactors(7854);
            var num34114 = pm.ExpessFactors(34114);
            //assert
            num14.Should().Be("2 X 7");
            num30.Should().Be("2 X 3 X 5");
            num115.Should().Be("5 X 23");
            num7854.Should().Be("2 X 3 X 7 X 11 X 17");
            num34114.Should().Be("2 X 37 X 461");
        }
        [Fact]
        public void OnlyExponants()
        {
            //arrange
            PrimeFactorization pm = new PrimeFactorization();
            //act
            var num36 = pm.ExpessFactors(36);
            var num900 = pm.ExpessFactors(900);
            var num40500 = pm.ExpessFactors(40500);
            var num8000 = pm.ExpessFactors(8000);

            //assert
            num36.Should().Be("2^2 X 3^2");
            num900.Should().Be("2^2 X 3^2 X 5^2");
            num40500.Should().Be("2^2 X 3^4 X 5^3");
            num8000.Should().Be("2^6 X 5^3");
        }

        [Fact]
        public void ExponantsAndPrimes()
        {
            //arrange
            PrimeFactorization pm = new PrimeFactorization();
            //act
            var num342 = pm.ExpessFactors(342);
            var num837 = pm.ExpessFactors(847);
            var num57400 = pm.ExpessFactors(57400);
            //assert
            num342.Should().Be("2 X 3^2 X 19");
            num837.Should().Be("7 X 11^2");
            num57400.Should().Be("2^3 X 5^2 X 7 X 41");
        }

    }
}
