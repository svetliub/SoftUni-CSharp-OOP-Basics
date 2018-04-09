using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string mainPersonInput = Console.ReadLine();
            FamilyTreeBuilder familyTreeBuilder = new FamilyTreeBuilder(mainPersonInput);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                ParseInput(command, familyTreeBuilder);
            }

            Console.WriteLine(familyTreeBuilder.Build());
        }

        private static void ParseInput(string command, FamilyTreeBuilder familyTreeBuilder)
        {
            string[] tokens = command.Split(" - ");
            if (tokens.Length > 1)
            {
                string parentInput = tokens[0];
                string childInput = tokens[1];
                familyTreeBuilder.SetParentChildRelation(parentInput, childInput);
            }
            else
            {
                tokens = tokens[0].Split();
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];
                familyTreeBuilder.SetFullInfo(name, birthday);
            }
        }
    }
}
