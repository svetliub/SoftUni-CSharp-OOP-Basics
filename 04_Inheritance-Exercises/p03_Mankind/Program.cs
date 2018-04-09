using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] studentInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        string studentFirstName = studentInput[0];
        string studentLastName = studentInput[1];
        string facultyNum = studentInput[2];

        string[] workerInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        string workerFirstName = workerInput[0];
        string workerLastName = workerInput[1];
        decimal weekSalary = decimal.Parse(workerInput[2]);
        decimal hoursPerDay = decimal.Parse(workerInput[3]);

        try
        {
            Student student = new Student(studentFirstName, studentLastName, facultyNum);
            Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, hoursPerDay);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}