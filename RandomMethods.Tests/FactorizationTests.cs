using System;
using Xunit;
using FluentAssertions;
using RandomMethods;


namespace RandomMethods.Tests
{
    public class FactorizationTests
    {
        [Fact]
        public void FactorsTestSinglePrime()
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
        public void FactorsTestNoExponants()
        {
            //arrange
            PrimeFactorization pm = new PrimeFactorization();
            //act
            var num14 = pm.ExpessFactors(14);
            var num30 = pm.ExpessFactors(30);
            var num115 = pm.ExpessFactors(115);
            var num34114 = pm.ExpessFactors(34114);
            //assert
            num14.Should().Be("2 X 7");
            num30.Should().Be("2 X 3 X 5");
            num115.Should().Be("5 X 23");
            num34114.Should().Be("2 X 37 X 461");
        }


    }
}
