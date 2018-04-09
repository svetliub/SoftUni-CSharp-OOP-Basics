using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());

        Dictionary<string, List<Employee>> employeesByDepartment = new Dictionary<string, List<Employee>>();

        for (int i = 0; i < people; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = tokens[0];
            decimal salary = decimal.Parse(tokens[1]);
            string position = tokens[2];
            string department = tokens[3];
            string email = "n/a";
            int age = -1;

            if (tokens.Length == 6)
            {
                email = tokens[4];
                age = int.Parse(tokens[5]);
            }
            else if (tokens.Length == 5)
            {
                bool tryParse = int.TryParse(tokens[4], out age);

                if (tryParse)
                {
                    age = int.Parse(tokens[4]);
                }
                else
                {
                    email = tokens[4];
                    age = -1;
                }
            }

            Employee employee = new Employee(name, salary, position, department, email, age);

            if (!employeesByDepartment.ContainsKey(department))
            {
                employeesByDepartment.Add(department, new List<Employee>());
            }
           
            employeesByDepartment[department].Add(employee);
        }

        foreach (var department in employeesByDepartment.OrderByDescending(e => e.Value.Average(v => v.Salary)).Take(1))
        {
            Console.WriteLine($"Highest Average Salary: {department.Key}");
            foreach (var employee in department.Value.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}

