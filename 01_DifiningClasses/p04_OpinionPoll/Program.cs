using System;
using System.Collections.Generic;
using System.Linq;

namespace p04_OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleNumber; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
