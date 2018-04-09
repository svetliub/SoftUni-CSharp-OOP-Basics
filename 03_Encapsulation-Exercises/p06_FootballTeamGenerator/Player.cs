using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private const int MIN_VALUE_STAT = 0;
    private const int MAX_VALUE_STAT = 100;

    private string name;
    private List<int> stats;
    public StatType statType;

    public string Name
    {
        get { return this.name; }
        set
        {
            DataValidator.ValidateName(value);
            this.name = value.Trim();
        }
    }
    
    public int AverageStats => (int)Math.Round(stats.Select(s => s).Average());

    public Player(string name)
    {
        this.Name = name;
        this.stats = new List<int>();
    }

    public void AddStat(int valueStat, int indexStat)
    {
        if (valueStat < MIN_VALUE_STAT || valueStat > MAX_VALUE_STAT)
        {
            throw new ArgumentException($"{Enum.GetName(typeof(StatType), indexStat)} should be between 0 and 100.");
        }

        this.stats.Add(valueStat);
    }
}