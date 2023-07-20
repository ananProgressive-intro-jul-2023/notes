

namespace StringCalculatorKata
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            var calculator= new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);

        }


        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("108", 108)]
        public void SingleDigit(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);



            Assert.Equal(expected, result);
        }



        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,3", 6)]
        [InlineData("8,2", 10)]
        [InlineData("10,2", 12)]
        public void TwoDigits(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);



            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("1,2,3", 6)]
       
        public void ArbitraryNumbers(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);



            Assert.Equal(expected, result);
        }



        [Theory]
        [InlineData("1\n2,3", 6)]

        public void NewLineDelimiter(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);



            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("//;\n1;2", 3)]

        public void ReplaceDelimiter(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);



            Assert.Equal(expected, result);
        }



    }
}
