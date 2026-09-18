using System;
using System.Data.Entity;

namespace EF6_CodeFirst_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var student = new Student
                {
                    StudentName = "Bill"
                };

                ctx.Students.Add(student);
                ctx.SaveChanges();

                Console.WriteLine("Student database created successfully.");
                Console.WriteLine("Student added: " + student.StudentName);
                Console.WriteLine("Student ID: " + student.StudentID);
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
