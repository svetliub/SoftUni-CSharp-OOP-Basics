﻿using System;
using System.Collections.Generic;
using System.Text;

public class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int NumberOfBadges
    {
        get { return this.numberOfBadges; }
        set { this.numberOfBadges = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public Trainer(string name)
    {
        this.Name = name;
        this.NumberOfBadges = 0;
        this.Pokemons = new List<Pokemon>();
    }
}

