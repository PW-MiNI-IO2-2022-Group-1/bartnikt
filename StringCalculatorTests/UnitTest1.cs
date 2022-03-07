using System;
using Xunit;

namespace StringCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestShouldReturn0OnEmptyString()
        {
            int actual = StringCalculator.Program.Calculate("");
            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("25", 25)]
        [InlineData("5", 5)]
        [InlineData("3", 3)]
        public void TestShouldReturnSingleValueEqualToPassedString(string data, int expected)
        {
            int actual = StringCalculator.Program.Calculate(data);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2,5", 7)]
        [InlineData("0,0", 0)]
        [InlineData("111,11", 122)]
        public void TestShouldReturnSumOfTwoCommaDelimetedNumbers(string data, int expected)
        {
            int actual = StringCalculator.Program.Calculate(data);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2\n5", 7)]
        [InlineData("0\n0", 0)]
        [InlineData("111\n11", 122)]
        public void TestShouldReturnSumOfTwoNewLineDelimetedNumbers(string data, int expected)
        {
            int actual = StringCalculator.Program.Calculate(data);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2\n5\n1", 8)]
        [InlineData("0\n0,1", 1)]
        [InlineData("111,11,3", 125)]
        [InlineData("10,5\n3", 18)]
        public void TestShouldReturnSumOfThreeDelimetedNumbers(string data, int expected)
        {
            int actual = StringCalculator.Program.Calculate(data);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("-2\n5\n1")]
        [InlineData("-1")]
        [InlineData("111,11,-3")]
        public void TestShouldThrowAnExceptionOnNegativeNumber(string data)
        {
            _ = Assert.Throws<ArgumentException>(
                () => StringCalculator.Program.Calculate(data)
            );
        }

        [Theory]
        [InlineData("1001\n5\n1", 6)]
        [InlineData("1002", 0)]
        public void TestShouldIgnoreNumbersBiggerThan1000(string data, int expected)
        {
            int actual = StringCalculator.Program.Calculate(data);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//$\n3$3,5", 11)]
        [InlineData("//#\n1#2#3", 6)]
        public void TestShouldAllowToDefineCustomSeparator(string data, int expected)
        {
            int actual = StringCalculator.Program.Calculate(data);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//[$:]\n3$:3,5", 11)]
        [InlineData("//[##]\n1##2##3", 6)]
        public void TestShouldAllowToDefineCustomMultiCharsSeparator(string data, int expected)
        {
            int actual = StringCalculator.Program.Calculate(data);
            Assert.Equal(expected, actual);
        }
    }
}
