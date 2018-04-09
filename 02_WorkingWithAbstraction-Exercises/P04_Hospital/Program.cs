using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        private static Dictionary<string, List<string>> departments;
        private static Dictionary<string, List<string>> doctors;
        public static void Main(string[] args)
        {
            departments = new Dictionary<string, List<string>>();
            doctors = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                var tokens = ReadParameters(input);
                AddDepartmentsInfo(tokens);
                AddDoctorsInfo(tokens);
            }

            string commandsArgs;
            while ((commandsArgs = Console.ReadLine()) != "End")
            {
                PrintPatients(commandsArgs);
            }
        }

        private static string[] ReadParameters(string input)
        {
            string[] parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return parameters;
        }

        private static void AddDoctorsInfo(string[] tokens)
        {
            string doctorFullname = $"{tokens[1]} {tokens[2]}";
            string patient = tokens[3];

            if (!doctors.ContainsKey(doctorFullname))
            {
                doctors.Add(doctorFullname, new List<string>());
            }

            doctors[doctorFullname].Add(patient);
        }

        private static void AddDepartmentsInfo(string[] tokens)
        {
            string department = tokens[0];
            string patient = tokens[3];

            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new List<string>());
            }

            if (departments[department].Count < 60)
            {
                departments[department].Add(patient);
            }
        }

        private static void PrintPatients(string commandsArgs)
        {
            var inputCommand = ReadParameters(commandsArgs);
            if (inputCommand.Length == 1)
            {
                PrintDepartmentPatients(inputCommand[0]);
            }
            else
            {
                if (int.TryParse(inputCommand[1], out int number))
                {
                    int skipPatients = (int.Parse(inputCommand[1]) - 1) * 3;
                    PrintPatientsByRoom(skipPatients, inputCommand[0]);
                }
                else
                {
                    string doctorName = inputCommand[0] + " " + inputCommand[1];
                    PrintDoctorPatients(doctorName);
                }
            }
        }

        private static void PrintPatientsByRoom(int skipPatients, string department)
        {
            foreach (var patient in departments[department].Skip(skipPatients).Take(3).OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDoctorPatients(string doctorName)
        {
            foreach (var patient in doctors[doctorName].OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDepartmentPatients(string department)
        {
            foreach (var patient in departments[department])
            {
                Console.WriteLine(patient);
            }
        }
    }
}
