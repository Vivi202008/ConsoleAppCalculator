using System;
using Xunit;
//using ConsoleAppCalculator;


namespace ConsoleAppCalculator.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void AddTest()
        {
            double num1 = 99;
            double num2 = 0;

            double result = Program.Add(num1, num2);
            Assert.Equal(99, result);
        }

        [Fact]
        public void SubtractTest()
        {
            double num1 = 99;
            double num2 = 45.5;

            double result = Program.Subtract(num1, num2);
            Assert.Equal(53.5, result);
        }
        [Fact]
        public void MultiplyTest()
        {
            double num1 = 8;
            double num2 = 5.5;

            double result = Program.Multiply(num1, num2);
            Assert.Equal(44, result);
        }
        [Fact]
        public void DivideTest()
        {
            double num1 = 99;
            double num2 = 1.1;

            double result = Program.Divide(num1, num2);
            Assert.Equal(num1 / num2, result);
        }
        [Fact]
        public void RootTest()
        {
            double num1 = 9.09;
            double num2 = 2;

            double result = Program.Root(num1, num2);
            Assert.Equal(Math.Pow(num1, 1 / num2), result);
        }
        [Fact]
        public void ExponetTest()
        {
            double num1 = 5;
            double num2 = 3;

            double result = Program.Exponet(num1, num2);
            Assert.Equal(125, result);
        }

        [Fact]
        public void DividionIs0Test()
        {
            //Arange
            double num1 = 99;
            double num2 = 0;

            //Act
            DivideByZeroException result = Assert.Throws<DivideByZeroException>(
                 () => Program.Divide(num1, num2));

            //Assert
            Assert.Equal("Divisor cannot be 0!", result.Message);
        }

        [Fact]
        public void RootNumberIs0Test()
        {
            //Arange
            double num1 = 9;
            double num2 = 0;

            //Act
            DivideByZeroException result = Assert.Throws<DivideByZeroException>(
                 () => Program.Root(num1, num2));

            //Assert
            Assert.Equal("The root number cannot be 0!", result.Message);
        }

        [Fact]
        public void RootNumberLessthan0Test()
        {
            //Arange
            double num1 = -4;
            double num2 = 4;

            //Act
            ArgumentException result = Assert.Throws<ArgumentException>(
                 () => Program.Root(num1, num2));

            //Assert
            Assert.Equal("If the rootnumber is even, the base must be bigger than 0! ", result.Message);
        }

        [Fact]
        public void ExpontNumbersAre0Test()
        {
            //Arange
            double num1 = 0;
            double num2 = 0;

            //Act
            ArgumentException result = Assert.Throws<ArgumentException>(
                 () => Program.Exponet(num1, num2));

            //Assert
            Assert.Equal("The exponent and base cannot be 0 at the same time!", result.Message);
        }

        [Theory]
        [InlineData(new double[3] { 1, 2, 3 })]
        [InlineData(new double[4] { -1, -2, -3, -10 })]
        [InlineData(new double[5] { 1, -4.2, 1.5, 1, -2.3 })]
        public void AddMoreTest(double[] numbers)
        {
            //Arrange
            double result;
            double resultTest = 0;

            //Act
            for (int i = 0; i < numbers.Length; i++)
            {
                resultTest += numbers[i];
            }
            result = Program.AddMore(numbers);

            //Assert
            Assert.Equal(resultTest, result);
        }

        [Theory]
        [InlineData(new double[3] { 10, 2, 3 })]
        [InlineData(new double[4] { -1, -2, -3, -10 })]
        [InlineData(new double[5] { 10, -4.2, 1.5, 1, -2.3 })]
        public void SubtractMoreTest(double[] numbers)
        {
            //Arrange
            double result;
            double resultTest = numbers[0];

            //Act
            for (int i = 1; i < numbers.Length; i++)
            {
                resultTest -= numbers[i];
            }
            result = Program.SubtractMore(numbers);

            //Assert
            Assert.Equal(resultTest, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData(" ")]
        [InlineData(".")]
        [InlineData("7.8")]  //Right is 7,8
        public void RightInputTest(string userInput)
        {
            //Arrange
            bool inputRight;

            //Act
            inputRight=Program.RightInput(userInput);

            //Assert
            Assert.False (inputRight);

        }

       
    }
}

