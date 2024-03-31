namespace Methods
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //string[] arr1 = { "a", "b", "h" };
            //string[] arr2 = { "Ilkin", "Altun", "Babek",  "Tural" };

            //SameCharacters(arr1, arr2);

            //PrintPrimeNumbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11); 

            //char el = 'a';

            //string[] result = CheckCharInArray(el, "Anar", "Nihad", "Eli", "Yusif", "Arif");
            //string[] result = newStrArr;

            //foreach (string c in result)
            //{
            //    Console.WriteLine(c);
            //}

        }

        public static string[] CheckCharInArray(char el, params string[] strArr)
        {
            // Contains search by char
            string[] newStrArr = new string[0];// null 

            for (int i = 0; i < strArr.Length; i++)
            {
                for (int j = 0; j < strArr[i].Length; j++)
                {
                    if (strArr[i].ToLower()[j] == el)
                    {
                        Array.Resize(ref newStrArr, newStrArr.Length + 1);
                        newStrArr[newStrArr.Length - 1] = strArr[i];
                        break;
                    }
                }
            }

            return newStrArr;
        }



        public static bool IsPrime(int n)
        {
            // Prime Checker
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void PrintPrimeNumbers(params int[] numbers)
        {
            Console.WriteLine("Prime Numbers: ");

            for (int i = 1; i < numbers.Length; i++)
            {
                if (IsPrime(numbers[i]))
                {
                    Console.Write(numbers[i] + " ");
                }
            }

        }

        public static void SameCharacters(string[] firstStrArr, string[] secondStrArr)
        {
            Console.WriteLine("Same chars in arrays: ");
            bool check = true;
            var count = 1;


            for (int i = 0; i < firstStrArr.Length; i++)
            {
                for (int j = 0; j < secondStrArr.Length; j++)
                {
                    if (secondStrArr[j].Contains(firstStrArr[i]))
                    {
                        if (check)
                        {
                            Console.Write(firstStrArr[i] + ": ");
                            check = false;
                        }
                        Console.Write(secondStrArr[j]);
                        if (count <= secondStrArr.Length - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    count++;
                }
                Console.WriteLine();
                check = true;
            }

        }
    }
}
