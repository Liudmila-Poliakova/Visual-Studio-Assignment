# Code-First Research

## What is Code-First?

Code-First is an Entity Framework approach in which the application's data model is first defined using C# classes. Entity Framework then uses those classes and the DbContext to create the corresponding database structure.

Microsoft's EF6 Code First to a New Database walkthrough describes defining the model using C# or VB.NET classes and targeting a new database so Code First can create it. It also explains that a DbContext represents a session with the database and exposes typed DbSet properties for the model classes. citeturn0search1

## How this application uses Code-First

The Student class is the model:

```csharp
public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
}
```

The SchoolContext class derives from DbContext and contains a DbSet for Student:

```csharp
public class SchoolContext : DbContext
{
    public SchoolContext() : base("SchoolContext")
    {
    }

    public DbSet<Student> Students { get; set; }
}
```

The application then creates a Student object, adds it to the Students set, and calls SaveChanges():

```csharp
var student = new Student
{
    StudentName = "Bill"
};

ctx.Students.Add(student);
ctx.SaveChanges();
```

This basic sequence is also shown in the EntityFrameworkTutorial Code-First example. citeturn0search3

## Sources

Microsoft Learn — Code First to a New Database - EF6:
https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database

EntityFrameworkTutorial — Simple Code-First Example:
https://www.entityframeworktutorial.net/code-first/simple-code-first-example.aspx

Microsoft Learn — Get Started with Entity Framework 6 Code First:
https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
