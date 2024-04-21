using Exceptions.Exceptions;
using System;

namespace Exceptions
{
    static class Program
    {
        public static void Main2(string[] args)
        {
            Console.WriteLine("\t Welcome Our Calculator");

            while (true)
            {
                Console.WriteLine("1. Multiplication");
                Console.WriteLine("2. Addition");
                Console.WriteLine("3. Substraction");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");
                Console.Write("Input: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {

                    Console.WriteLine("Please enter the numbers:");
                    try
                    {
                        Console.Write("Number 1: ");
                        int number1 = int.Parse(Console.ReadLine());// input: ilkin => throw new FormatException("...")
                        Console.Write("Number 2: ");
                        int number2 = int.Parse(Console.ReadLine());// 0

                        switch (result)
                        {
                            case 1:
                                Console.WriteLine(number1 * number2);
                                break;
                            case 2:
                                Console.WriteLine(number1 + number2);
                                break;
                            case 3:
                                Console.WriteLine(number1 - number2);
                                break;
                            case 4:
                                if (number2 == 0)
                                {
                                    throw new DividedByZeroException("Number can not divided by zero!!!!");
                                }
                                Console.WriteLine(number1 / number2);
                                break;
                            case 5:
                                Console.WriteLine("\t Program has been stopped!");
                                return;
                            default:
                                Console.WriteLine("You must enter number between 1-4");
                                break;

                        }
                    }
                    catch (DividedByZeroException exdivide)
                    {
                        Console.WriteLine();
                        Console.WriteLine(exdivide.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You must enter a number to input!");
                        Console.WriteLine();
                    }
                    finally
                    {

                    }
                }
                else
                {
                    Console.WriteLine("You must enter numbers");
                }
            }
        }
    }

    public static class Type
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };
            //        0x344000, 0x400300, 0x500400
 
            Console.WriteLine(numbers[1]);
        }
    }
}