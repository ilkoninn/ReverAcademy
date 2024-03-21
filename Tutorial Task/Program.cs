// Polindrom Task

namespace Tutorial_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 1211, digit, sum = 0;
            int temp = number;

            while (number > 0)
            {
                digit = number % 10; 

                sum = sum * 10 + digit;

                number = number / 10; 
            }

            if(temp == sum)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

        }
    }
}
