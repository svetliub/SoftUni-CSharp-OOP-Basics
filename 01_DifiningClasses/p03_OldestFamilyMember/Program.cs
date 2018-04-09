using System;
using System.Linq;

namespace p03_OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < peopleNumber; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                AddMember(person, family);
            }

            Console.WriteLine(GetOldestMember(family));
        }

        private static void AddMember(Person member, Family family)
        {
            family.People.Add(member);
        }

        static Person GetOldestMember(Family family)
        {
            return family.People.OrderByDescending(a => a.Age).FirstOrDefault();
        }
    }
}
