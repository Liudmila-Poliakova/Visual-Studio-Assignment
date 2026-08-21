// Stage 2 - Classes and Methods Assignment
// Author: Liudmila Poliakova
// Academy of Learning College

using System;

// Requirement 1: Create a class called MathHelper
class MathHelper
{
    // Requirement 1: Create a void method that takes two integers as parameters
    // The method squares the first integer and displays the second integer to the screen
    public void ProcessNumbers(int firstNumber, int secondNumber)
    {
        // Do a math operation on the first integer (square it)
        int result = firstNumber * firstNumber;

        // Display the result of the math operation on the first integer
        Console.WriteLine("Math operation on first number (" + firstNumber + " squared): " + result);

        // Display the second integer to the screen
        Console.WriteLine("Second number displayed: " + secondNumber);

        // Print a blank line for readability between calls
        Console.WriteLine();
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message
        Console.WriteLine("=== Classes and Methods Demo ===");
        Console.WriteLine();

        // Requirement 2: Instantiate the MathHelper class
        MathHelper helper = new MathHelper();

        // Requirement 3: Call the method by passing in two numbers as regular arguments
        Console.WriteLine("Calling method with regular parameters:");
        helper.ProcessNumbers(5, 10);

        // Requirement 4: Call the method again, this time specifying the parameters by name
        Console.WriteLine("Calling method with named parameters:");
        helper.ProcessNumbers(firstNumber: 7, secondNumber: 20);
    }
}
