using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<ISoldier> soldiers;

    static void Main(string[] args)
    {
        soldiers = new List<ISoldier>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var possition = tokens[0];
            var id = int.Parse(tokens[1]);
            var firstName = tokens[2];
            var lastName = tokens[3];

            ISoldier soldier = new Soldier(id, firstName, lastName);

            switch (possition)
            {
                case "Private":
                    var salary = double.Parse(tokens[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                    break;
                case "LeutenantGeneral":
                    var salaryGeneral = double.Parse(tokens[4]);
                    List<ISoldier> privates = new List<ISoldier>();

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        var privateId = int.Parse(tokens[i]);
                        ISoldier newPrivate =
                            soldiers.FirstOrDefault(s => s.GetType().Name == "Private" && s.Id == privateId);
                        if (newPrivate != null)
                        {
                            privates.Add((Private)newPrivate);
                        }
                    }

                    soldier = new LeutenantGeneral(id, firstName, lastName, salaryGeneral, privates);
                    break;
                case "Engineer":
                    var salaryEngineer = double.Parse(tokens[4]);
                    var corps = tokens[5];
                    List<IRepair> repairs = new List<IRepair>();

                    for (int i = 6; i < tokens.Length; i+=2)
                    {
                        var partName = tokens[i];
                        var hours = int.Parse(tokens[i + 1]);
                        Repair repair = new Repair(partName, hours);
                        repairs.Add(repair);
                    }

                    try
                    {
                        soldier = new Engineer(id, firstName, lastName, salaryEngineer, corps, repairs);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                    break;
                case "Commando":
                    var salaryCommando = double.Parse(tokens[4]);
                    var corpsCommando = tokens[5];

                    List<Mission> missions = new List<Mission>();
                    for (int i = 6; i < tokens.Length; i+=2)
                    {
                        var missionName = tokens[i];
                        var missionState = tokens[i + 1];
                        try
                        {
                            Mission mission = new Mission(missionName, missionState);
                            missions.Add(mission);
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                        
                    }

                    try
                    {
                        soldier = new Commando(id, firstName, lastName, salaryCommando, corpsCommando, missions);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                    break;
                case "Spy":
                    var codeNumber = int.Parse(tokens[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                    break;
                default:
                    throw new ArgumentException("Invalid possition!");
            }

            soldiers.Add(soldier);
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}