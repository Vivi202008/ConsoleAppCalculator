using System;

namespace ConsoleAppCalculator
{
    public class Program
    {
        //This is a basic calculator that is able to perform basic mathematical operations. + - X /
        static double number1 = 0, number2 = 0, result = 0;
        static string operatorString = "";
        static int count = 0;


        public static double[] numbers = new double[count];
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to my calculator");
            int userSelection;

            do
            {
                Console.WriteLine();
                Console.WriteLine("----- Menu -----");
                Console.WriteLine("1: Addition.");
                Console.WriteLine("2: Subtraction.");
                Console.WriteLine("3: Multiplication.");
                Console.WriteLine("4: Division.");
                Console.WriteLine("5: Root.");
                Console.WriteLine("6: Exponentiation..");
                Console.WriteLine("7: Addition of multiple numbers.");
                Console.WriteLine("8: Subtraction of multiple numbers.");

                Console.WriteLine("0: Quit.");
                Console.WriteLine();
                userSelection = Convert.ToInt32(GetNumberFromUser("Menu selection"));
                result = 0;
                switch (userSelection)
                {
                    case 1:
                        Console.WriteLine("1: Addition.\tInput 2 numbers.");
                        number1 = GetNumberFromUser("first");
                        number2 = GetNumberFromUser("second");
                        result = Add(number1, number2);
                        printResult();
                        break;
                    case 2:
                        Console.WriteLine("2: Subtraction.\tInput 2 numbers.");
                        number1 = GetNumberFromUser("first");
                        number2 = GetNumberFromUser("second");
                        result = Subtract(number1, number2);
                        printResult();
                        break;
                    case 3:
                        Console.WriteLine("3: Multiplication.\tInput 2 numbers.");
                        number1 = GetNumberFromUser("first");
                        number2 = GetNumberFromUser("second");
                        result = Multiply(number1, number2);
                        printResult();
                        break;
                    case 4:
                        Console.WriteLine("4: Division.\tInput 2 numbers.");
                        number1 = GetNumberFromUser("first");
                        number2 = GetNumberFromUser("second");
                        //Divisor cannot be 0
                        do
                        {
                            try
                            {
                                result = Divide(number1, number2);
                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("Attempted to divide by zero. Input again!");
                                number2 = GetNumberFromUser("second");
                            }
                        } while (number2 == 0);
                        result = Divide(number1, number2);
                        printResult();
                        break;
                    case 5:
                        Console.WriteLine("5: Root. The nth root of a number\tInput 2 number.");
                        number1 = GetNumberFromUser("first");
                        number2 = GetNumberFromUser("second");

                        do
                        {
                            try
                            {
                                result = Root(number1, number2);
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("If the rootnumber is even, the base must be bigger than 0!!  Input again!");
                                number1 = GetNumberFromUser("first");
                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("!!The root number cannot be 0!   Input again!");
                                number2 = GetNumberFromUser("second");
                            }
                        } while ((number2 == 0) || (number2 % 2 == 0 && number1 < 0));

                        result = Root(number1, number2);
                        printResult();
                        break;
                    case 6:
                        Console.WriteLine("6.Exponentiation. Raised to the power of n.\tInput 2 number.");
                        number1 = GetNumberFromUser("first");
                        number2 = GetNumberFromUser("second");

                        do
                        {
                            try
                            {
                                result = Exponet(number1, number2);
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("The exponent and base cannot be 0 at the same time! Input again!");
                                number1 = GetNumberFromUser("first");
                            }
                        } while (number2 == 0 && number1 == 0);

                        result = Exponet(number1, number2);
                        printResult();
                        break;

                    case 7:
                        Console.WriteLine("7: Addition of multiple numbers .\t How many numbers should we add?  ");
                        count = GetCountNumbersFromUser();
                        numbers = GetNumbersFromUser(count);
                        result = AddMore(numbers);
                        break;
                    case 8:
                        Console.WriteLine("8: Subtraction of multiple numbers.\tHow many numbers should we subtract?  ");
                        count = GetCountNumbersFromUser();
                        numbers = GetNumbersFromUser(count);
                        result = SubtractMore(numbers);
                        break;

                    case 0:
                        Console.WriteLine("Thanks for using this program.");
                        Console.WriteLine("Press any key to close program.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Not a valid selection.");
                        break;
                }
            } while (userSelection != 0);
        }  //End of Main

        public static double Add(double number1, double number2)
        {
            double result;
            result = number1 + number2;
            operatorString = "+";
            return result;
        }

        public static double AddMore(double[] numbers)
        {
            double resultAddMore = 0;
            string resultString = "The result is: ";
            for (int i = 0; i < numbers.Length; i++)
            {
                resultAddMore = Add(numbers[i], resultAddMore);
                resultString = resultString + numbers[i] + " + ";
            }
            Console.WriteLine(resultString.Substring(0, resultString.Length - 3) + " = " + resultAddMore);
            return resultAddMore;
        }
        public static double Subtract(double number1, double number2)
        {
            double result;
            result = number1 - number2;
            operatorString = "-";
            return result;
        }

        public static double SubtractMore(double[] numbers)
        {
            string resultString = "The result is: ";
            double resultSubtractMore = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i > 0)
                {
                    resultSubtractMore = Subtract(resultSubtractMore, numbers[i]);
                }
                else
                {
                    resultSubtractMore = numbers[i];
                }
                resultString = resultString + numbers[i] + " - ";
            }

            Console.WriteLine(resultString.Substring(0, resultString.Length - 3) + " = " + resultSubtractMore);
            return resultSubtractMore;
        }
        public static double Multiply(double number1, double number2)
        {
            double result;
            result = number1 * number2;
            operatorString = "*";
            return result;
        }

        public static void printResult()
        {
            Console.WriteLine("The result is: {0} {1} {2} = {3}", number1, operatorString, number2, result);
        }

        public static double Divide(double number1, double number2)
        {
            if (number2 == 0)
                throw new DivideByZeroException("Divisor cannot be 0!");
            result = number1 / number2;
            operatorString = "/";
            return result;
        }

        public static double Root(double number1, double number2)
        {
            if (number2 == 0)
                throw new DivideByZeroException("The root number cannot be 0!");
            if (number2 % 2 == 0 && number1 < 0)
                throw new ArgumentException("If the rootnumber is even, the base must be bigger than 0! ");

            result = Math.Pow(number1, 1 / number2);
            operatorString = " root ";
            return result;
        }

        public static double Exponet(double number1, double number2)
        {
            if (number1 == 0 && number2 == 0)
                throw new ArgumentException("The exponent and base cannot be 0 at the same time!");

            result = Math.Pow(number1, number2);
            operatorString = " Raise the power of ";
            return result;
        }

        public static double[] GetNumbersFromUser(int count)
        {
            double[] numbers = new double[count];
            Console.WriteLine("Input {0} numbers.", count);

            for (int i = 0; i < count; i++)
            {
                numbers[i] = GetNumberFromUser("No." + (i + 1));
            }
            return numbers;
        }
        public static int GetCountNumbersFromUser()
        {
            int count = 0;
            do
            {
                try
                {
                    count = Convert.ToInt32(GetNumberFromUser("count of addends"));
                    if (count < 3)
                    {
                        Console.WriteLine("Input an integer more than 2");
                        throw new ArgumentException();
                    }

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Input an integer more than 2");
                }
            } while (count <= 2);
            return count;
        }

        public static double GetNumberFromUser(string forWhat)
        {
            double number;
            Console.Write("Enter " + forWhat + " number: ");
            string userInput = Console.ReadLine();
            while (!RightInput(userInput)) {
                userInput = Console.ReadLine();
            }
            number = double.Parse(userInput);
            return number;
        }

        public static bool RightInput(string userInput)
        {
            double number;
            bool inputRight=false;
             try
                {
                    number = double.Parse(userInput);
                    inputRight = true;
                }
                catch (Exception ex)
                {
                    string output = ex.Message;
                    Console.Write(output + " Input a right number.");
                }
           
            return inputRight;
        }
    }
}
