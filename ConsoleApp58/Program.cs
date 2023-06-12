using System;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numere separate prin virgula:");
            string input = Console.ReadLine();

            int[] numbers = ParseNumbers(input);

            Console.WriteLine("Numerele introduse sunt:");
            PrintNumbers(numbers);

            Console.WriteLine("Numerele ordonate crescator sunt:");
            int[] sortedNumbers = SortNumbers(numbers);
            PrintNumbers(sortedNumbers);

            Console.WriteLine("Suma numerelor este: " + CalculateSum(sortedNumbers));

            Console.WriteLine("Media numerelor este: " + CalculateAverage(sortedNumbers));

            Console.WriteLine("Cel mai mare numar este: " + GetMaxNumber(sortedNumbers));

            Console.WriteLine("Cel mai mic numar este: " + GetMinNumber(sortedNumbers));

            int[] primeNumbers = GetPrimeNumbers(sortedNumbers);
            Console.WriteLine("Numerele prime sunt:");
            PrintNumbers(primeNumbers);

            Console.WriteLine("Numerele distincte sunt:");
            int[] distinctNumbers = GetDistinctNumbers(sortedNumbers);
            PrintNumbers(distinctNumbers);

            Console.WriteLine("Numerele duplicate sunt:");
            int[] duplicateNumbers = GetDuplicateNumbers(sortedNumbers);
            PrintNumbers(duplicateNumbers);

            Console.WriteLine("Numerele palindrom sunt:");
            int[] palindromicNumbers = GetPalindromicNumbers(sortedNumbers);
            PrintNumbers(palindromicNumbers);

            Console.WriteLine("Numerele pătrate perfecte sunt:");
            int[] perfectSquareNumbers = GetPerfectSquareNumbers(sortedNumbers);
            PrintNumbers(perfectSquareNumbers);
        }

        static int[] ParseNumbers(string input)
        {
            string[] numberStrings = input.Split(',');
            int[] numbers = new int[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (!int.TryParse(numberStrings[i], out numbers[i]))
                {
                    Console.WriteLine("Valoarea introdusa '" + numberStrings[i] + "' nu este un numar valid. Aceasta va fi ignorata.");
                }
            }

            return numbers;
        }

        static void PrintNumbers(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        static int[] SortNumbers(int[] numbers)
        {
            Array.Sort(numbers);
            return numbers;
        }

        static int CalculateSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static double CalculateAverage(int[] numbers)
        {
            int sum = CalculateSum(numbers);
            return (double)sum / numbers.Length;
        }

        static int GetMaxNumber(int[] numbers)
        {
            return numbers[numbers.Length - 1];
        }

        static int GetMinNumber(int[] numbers)
        {
            return numbers[0];
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static int[] GetPrimeNumbers(int[] numbers)
        {
            int count = 0;
            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    count++;
                }
            }

            int[] primeNumbers = new int[count];
            int index = 0;
            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primeNumbers[index] = number;
                    index++;
                }
            }

            return primeNumbers;
        }

        static int[] GetDistinctNumbers(int[] numbers)
        {
            int count = 1;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] != numbers[i - 1])
                {
                    count++;
                }
            }

            int[] distinctNumbers = new int[count];
            distinctNumbers[0] = numbers[0];
            int index = 1;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] != numbers[i - 1])
                {
                    distinctNumbers[index] = numbers[i];
                    index++;
                }
            }

            return distinctNumbers;
        }

        static int[] GetDuplicateNumbers(int[] numbers)
        {
            int count = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    count++;
                }
            }

            int[] duplicateNumbers = new int[count];
            int index = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    duplicateNumbers[index] = numbers[i];
                    index++;
                }
            }

            return duplicateNumbers;
        }

        static bool IsPalindrome(int number)
        {
            string numberString = number.ToString();
            int left = 0;
            int right = numberString.Length - 1;

            while (left < right)
            {
                if (numberString[left] != numberString[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        static int[] GetPalindromicNumbers(int[] numbers)
        {
            int count = 0;
            foreach (int number in numbers)
            {
                if (IsPalindrome(number))
                {
                    count++;
                }
            }

            int[] palindromicNumbers = new int[count];
            int index = 0;
            foreach (int number in numbers)
            {
                if (IsPalindrome(number))
                {
                    palindromicNumbers[index] = number;
                    index++;
                }
            }

            return palindromicNumbers;
        }

        static bool IsPerfectSquare(int number)
        {
            int squareRoot = (int)Math.Sqrt(number);
            return squareRoot * squareRoot == number;
        }

        static int[] GetPerfectSquareNumbers(int[] numbers)
        {
            int count = 0;
            foreach (int number in numbers)
            {
                if (IsPerfectSquare(number))
                {
                    count++;
                }
            }

            int[] perfectSquareNumbers = new int[count];
            int index = 0;
            foreach (int number in numbers)
            {
                if (IsPerfectSquare(number))
                {
                    perfectSquareNumbers[index] = number;
                    index++;
                }
            }

            return perfectSquareNumbers;
        }
    }
}
