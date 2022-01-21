# Parmonic_Technical_Assessment
Parmonic Technical Assessment
1 Unit Testing

Write a C# console application that accepts an integer i, and prints an output based on the following:

i is divisible by 3 Print Fizz

i is divisible by 5 Print Buzz

i is divisible by both 3 and 5 Print FizzBuzz

Write unit tests. i could take any legal integer value.


Amit S - 1. Numbers are divisible by 3 if the sum of all the individual digits is divisible by 3. 
Method DivisiblebBy3 takes sum of digit for given number and checks its divisibility.

2. Check if any given number is divisible by 5, for this check last digit if its 0 or 5 then is divisible by 5.
Method DivisiblebBy5 checks last digit of given number to find if its divisible by 5.