using System;
using System.Collections.Generic;
using System.Linq;

public class FootballTeam
{
    private string name;
    private List<Player> players;

    public string Name
    {
        get { return this.name; }
        set
        {
            DataValidator.ValidateName(value);
            this.name = value.Trim();
        }
    }

    public int TeamRating => players.Count > 0 ? (int)Math.Round(players.Select(p => p.AverageStats).Average()) : 0;

    public FootballTeam(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player tempPlayer = this.players.FirstOrDefault(x => x.Name == playerName);
        if (tempPlayer == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        
        this.players.Remove(tempPlayer);
    }

    public string ShowTeamRating(string teamName, FootballTeam team)
    {
        return $"{team.Name} - {team.TeamRating}";
    }
}