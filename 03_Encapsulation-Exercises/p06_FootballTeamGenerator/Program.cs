using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<FootballTeam> teams;
    static void Main(string[] args)
    {
        string command;
        teams = new List<FootballTeam>();
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string teamName = tokens[1];

                ValidateTeamName(tokens, teamName);

                if (tokens.Length == 8)
                {
                    TryToAddPlayer(tokens, teamName);
                }
                else if (tokens.Length == 2)
                {
                    if (tokens[0] == "Team")
                    {
                        AddNewTeam(tokens);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        PrintTeamRating(teamName);
                    }
                }
                else if (tokens.Length == 3)
                {
                    TryToRemovePlayer(tokens, teamName);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void AddNewTeam(string[] tokens)
    {
        FootballTeam team = new FootballTeam(tokens[1]);
        teams.Add(team);
    }

    private static void PrintTeamRating(string teamName)
    {
        FootballTeam tempTeam = teams.FirstOrDefault(t => t.Name == teamName);
        Console.WriteLine(tempTeam.ShowTeamRating(teamName, tempTeam));
    }

    private static void ValidateTeamName(string[] tokens, string teamName)
    {
        if (tokens[0] != "Team" && !teams.Any(t => t.Name == teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }

    private static void TryToAddPlayer(string[] tokens, string teamName)
    {
        string playerName = tokens[2];
        Player player = new Player(playerName);

        for (int i = 3; i < tokens.Length; i++)
        {
            int stat = int.Parse(tokens[i]);
            int index = i - 3;
            player.AddStat(stat, index);
        }

        FootballTeam tempTeam = teams.First(t => t.Name == teamName);
        tempTeam.AddPlayer(player);
    }

    private static void TryToRemovePlayer(string[] tokens, string teamName)
    {
        string playerName = tokens[2];
        FootballTeam tempTeam = teams.First(t => t.Name == teamName);
        tempTeam.RemovePlayer(playerName);
    }
}
