using System;
using System.Diagnostics;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputResult(5);
            OutputResult(10);
            OutputResult(20);
        }

        static ulong GetFibonacciCycle(int number)
        {
            if (number < 3)
            {
                return 1;
            }

            int firstPrevious = 1;
            int secondPrevious = 1;
            int current = 0;

            for (int i = 3; i <= number; i++)
            {
                current = firstPrevious + secondPrevious;
                firstPrevious = secondPrevious;
                secondPrevious = current;
            }

            return (ulong)current;
        }

        static ulong GetFibonacciRecursion(int number)
        {
            switch (number)
            {
                case 1:
                    return 1;
                case 2:
                    return 1;
            }

            return GetFibonacciRecursion(number - 1) + GetFibonacciRecursion(number - 2);
        }

        static int CheckedInput(int integer)
        {
            if (integer <= 0)
            {
                Console.WriteLine("Некорректный аргумент. Будет возвращена 1");
                return 1;
            }

            return integer;
        }

        static void OutputResult(int integer)
        {
            int checkedNumber = CheckedInput(integer);

            Stopwatch recursion = new Stopwatch();
            Stopwatch cycle = new Stopwatch();

            Console.WriteLine($"Элемент чисел Фибоначчи - {integer}");
            recursion.Start();
            Console.WriteLine($"Результат рекурсии: {GetFibonacciRecursion(checkedNumber)}");
            recursion.Stop();
            TimeSpan recursionTime = recursion.Elapsed;
            Console.WriteLine($"Время выполнения: {recursionTime}");
            Console.WriteLine();

            cycle.Start();
            Console.WriteLine($"Результат цикла: {GetFibonacciCycle(checkedNumber)}");
            cycle.Stop();
            TimeSpan cicleTime = cycle.Elapsed;
            Console.WriteLine($"Время выполнения: {cicleTime}");
            Console.WriteLine("----------");
            Console.WriteLine();
        }

    }
}
