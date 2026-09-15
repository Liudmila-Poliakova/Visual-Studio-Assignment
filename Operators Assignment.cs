// Operator Overloading Assignment
// Author: Liudmila Poliakova
// Academy of Learning College

using System;

// Requirement 1: Create an Employee class with Id, FirstName and LastName properties
class Employee
{
    // Property to store the employee's ID number
    public int Id { get; set; }

    // Property to store the employee's first name
    public string FirstName { get; set; }

    // Property to store the employee's last name
    public string LastName { get; set; }

    // Requirement 2: Overload the "==" operator to compare two Employee objects by their Id
    // Comparison operators must be overloaded in pairs (== and !=)
    public static bool operator ==(Employee firstEmployee, Employee secondEmployee)
    {
        // Return true if both employees have the same Id, otherwise return false
        return firstEmployee.Id == secondEmployee.Id;
    }

    // Overload the "!=" operator as required (must be overloaded together with ==)
    public static bool operator !=(Employee firstEmployee, Employee secondEmployee)
    {
        // Return true if the employees have different Ids, otherwise return false
        return firstEmployee.Id != secondEmployee.Id;
    }

    // Override Equals() method - required by C# when overloading == operator
    public override bool Equals(object obj)
    {
        // Check if the passed object is an Employee, then compare by Id
        if (obj is Employee other)
            return this.Id == other.Id;
        return false;
    }

    // Override GetHashCode() method - required by C# when overriding Equals()
    public override int GetHashCode()
    {
        // Use the Id as the hash code since we compare employees by Id
        return Id.GetHashCode();
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message
        Console.WriteLine("=== Employee Operator Overloading Demo ===");
        Console.WriteLine();

        // Requirement 3: Instantiate the first Employee object and assign values
        Employee employee1 = new Employee() { Id = 1, FirstName = "Sample", LastName = "Student" };

        // Instantiate the second Employee object with a different Id
        Employee employee2 = new Employee() { Id = 2, FirstName = "John", LastName = "Doe" };

        // Instantiate a third Employee object with the same Id as employee1
        Employee employee3 = new Employee() { Id = 1, FirstName = "Different", LastName = "Name" };

        // Display the details of all three employees
        Console.WriteLine("Employee 1 - Id: " + employee1.Id + ", Name: " + employee1.FirstName + " " + employee1.LastName);
        Console.WriteLine("Employee 2 - Id: " + employee2.Id + ", Name: " + employee2.FirstName + " " + employee2.LastName);
        Console.WriteLine("Employee 3 - Id: " + employee3.Id + ", Name: " + employee3.FirstName + " " + employee3.LastName);
        Console.WriteLine();

        // Use the overloaded == operator to compare employee1 and employee2 (different Ids)
        Console.WriteLine("Is Employee 1 == Employee 2? " + (employee1 == employee2));

        // Use the overloaded != operator to compare employee1 and employee2
        Console.WriteLine("Is Employee 1 != Employee 2? " + (employee1 != employee2));

        Console.WriteLine();

        // Use the overloaded == operator to compare employee1 and employee3 (same Id)
        Console.WriteLine("Is Employee 1 == Employee 3? " + (employee1 == employee3));

        // Use the overloaded != operator to compare employee1 and employee3
        Console.WriteLine("Is Employee 1 != Employee 3? " + (employee1 != employee3));

        // Keep the console window open until the user presses Enter
        Console.ReadLine();
    }
}
