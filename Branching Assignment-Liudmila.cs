// Package Express - Shipping Quote Calculator
// Author: Liudmila Poliakova
// Academy of Learning College

using System;

class Program
{
    static void Main(string[] args)
    {
        // Requirement 1: Display the welcome message as the first line
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Requirement 2: Prompt the user to enter the package weight
        Console.WriteLine("Please enter the package weight (lbs):");

        // Read the weight input from the user and convert it to a decimal number
        double weight = Convert.ToDouble(Console.ReadLine());

        // Requirement 3: Check if the weight is greater than 50
        // If so, display an error message and end the program
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return; // Exit the program early
        }

        // Requirement 4: Prompt the user to enter the package width
        Console.WriteLine("Please enter the package width (cm):");

        // Read the width input from the user and convert it to a decimal number
        double width = Convert.ToDouble(Console.ReadLine());

        // Requirement 5: Prompt the user to enter the package height
        Console.WriteLine("Please enter the package height (cm):");

        // Read the height input from the user and convert it to a decimal number
        double height = Convert.ToDouble(Console.ReadLine());

        // Requirement 6: Prompt the user to enter the package length
        Console.WriteLine("Please enter the package length (cm):");

        // Read the length input from the user and convert it to a decimal number
        double length = Convert.ToDouble(Console.ReadLine());

        // Requirement 7: Check if the total of all three dimensions is greater than 50
        // If so, display an error message and end the program
        if (width + height + length > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return; // Exit the program early
        }

        // Requirement 8: Calculate the shipping quote
        // Multiply the three dimensions together, then multiply by the weight, then divide by 100
        double quote = (height * width * length * weight) / 100;

        // Requirement 10: Display the quote to the user as a dollar amount
        // {quote:F2} formats the number to 2 decimal places (e.g. $528.00)
        Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("F2"));

        // Display a closing thank you message
        Console.WriteLine("Thank you!");
    }
}
