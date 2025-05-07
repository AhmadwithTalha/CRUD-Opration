using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 10, 20, 30, 40, 50, 60, 70 };
            int start = 2;
            int length = 3;

            int[] slice = new int[length];
            Array.Copy(numbers, start, slice, 0, length);

            foreach (int value in slice)
            {
                Console.WriteLine(value);
            }
        }
    }
}