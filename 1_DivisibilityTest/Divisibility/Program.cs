using System;

namespace Divisibility
{
    public class Program
    {
        public string Division(string Value)
        {
            string result = string.Empty;
            bool isDivisibleBy3 = false;
            bool isDivisibleBy5 = false;
            if (string.IsNullOrEmpty(Value) || Value.Length <= 0)
            {
                result = "Fail";
                return result;
            }
            if (DivisiblebBy3(Value))
            {
                isDivisibleBy3 = true;
                result = "Fizz";
            }
            if (DivisiblebBy5(Value))
            {
                isDivisibleBy5 = true;
                result = "Buzz";
            }
            if (isDivisibleBy3 && isDivisibleBy5)
            {
                result = "FizzBuzz";
            }
            if ((!isDivisibleBy3 && !isDivisibleBy5))
            { result = "Fail"; }
            return result;

        }

        static bool DivisiblebBy3(string str)
        {
            // Compute sum of digits
            int n = str.Length;
            int digitSum = 0;

            for (int i = 0; i < n; i++)
                digitSum += (str[i] - '0');

            // Check if sum of digits is
            // divisible by 3.
            return (digitSum % 3 == 0);
        }

        static bool DivisiblebBy5(string str)
        {
            // Function to find that number divisible
            // by 5 or not. The function assumes that
            // string length is at least one.

            int n = str.Length;

            return (((str[n - 1] - '0') == 0) ||
                    ((str[n - 1] - '0') == 5));

        }

    }
}
