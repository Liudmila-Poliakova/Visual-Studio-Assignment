// Polymorphism Assignment
// Author: Liudmila Poliakova
// Academy of Learning College

using System;

// Create an abstract class called Person with two string properties
public abstract class Person
{
    // Property to store the first name of the person
    public string firstName { get; set; }

    // Property to store the last name of the person
    public string lastName { get; set; }

    // Abstract method SayName() - must be implemented by any class that inherits Person
    public abstract void SayName();
}

// Requirement 1: Create an interface called IQuittable
// An interface defines a contract - any class that implements it must include the Quit() method
public interface IQuittable
{
    // Define a void method called Quit() inside the interface
    void Quit();
}

// Requirement 2: Have the Employee class inherit from Person AND implement IQuittable
// Employee gets all properties of Person, and must implement both SayName() and Quit()
public class Employee : Person, IQuittable
{
    // Property to store the employee's ID number
    public int Id { get; set; }

    // Implement the SayName() method inherited from the abstract Person class
    public override void SayName()
    {
        // Display the employee's full name to the screen
        Console.WriteLine("Name: " + firstName + " " + lastName);
    }

    // Implement the Quit() method required by the IQuittable interface
    public void Quit()
    {
        // Display a message when the employee quits
        Console.WriteLine(firstName + " " + lastName + " has quit their job. Goodbye!");
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Instantiate an Employee object with firstName and lastName
        Employee sam = new Employee() { firstName = "Sample", lastName = "Student" };

        // Call the SayName() method on the Employee object
        sam.SayName();

        // Requirement 3: Use polymorphism to create an object of type IQuittable
        // This works because Employee implements the IQuittable interface
        IQuittable quittableEmployee = new Employee() { firstName = "Sample", lastName = "Student" };

        // Call the Quit() method on the IQuittable object
        quittableEmployee.Quit();
    }
}
