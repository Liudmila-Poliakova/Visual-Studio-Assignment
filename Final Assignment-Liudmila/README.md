# Entity Framework Code-First Student Database

This console application completes the Code-First portion of the Final Assignment.

It:
- defines a Student C# class;
- defines a SchoolContext derived from DbContext;
- exposes DbSet<Student> Students;
- creates the database from the model;
- adds one student;
- calls SaveChanges() to persist the student.

## Run

Open `EF6_CodeFirst_Student.sln` in Visual Studio 2022.

Restore the EntityFramework NuGet package if prompted, make sure SQL Server LocalDB is installed, then build and run with Ctrl+F5.

Expected output includes:
Student database created successfully.
Student added: Bill
Student ID: 1

The ID may be different if the database already contains a record.

The assignment instructions say to stop after the basic Code-First example and not continue into Code-First Conventions or DB Initialization. This project follows that requirement.
