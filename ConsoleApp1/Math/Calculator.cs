

namespace ConsoleApp1.Math
{
    internal class Calculator
    {
        public static int Add(int a, int b) {
            return a + b;
        }

        // Method with the params keyword for accepting a variable number of integers
        public static int Add(params int[] numbers)
        {
            int sum = 0;

            // Iterate through the array of numbers and add them
            foreach (int num in numbers)
            {
                sum += num;
            }

            return sum;
        }
    }
}
