using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Person
{
    private string fullName;
    private string birthDay;
    private Company company;
    private Car car;
    private List<Person> parents;
    private List<Person> children;
    private List<Pokemon> pokemons;

    public string FullName
    {
        get { return this.fullName; }
        set { this.fullName = value; }
    }

    public string BirthDay
    {
        get { return this.birthDay; }
        set { this.birthDay = value; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public List<Person> Parents
    {
        get { return this.parents; }
        private set { this.parents = value; }
    }

    public List<Person> Children
    {
        get { return this.children; }
        private set { this.children = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        private set { this.pokemons = value; }
    }

    public Person(string fullName)
    {
        this.FullName = fullName;
        this.Children = new List<Person>();
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Person>();
    }

    public Person(string fullName, string birthDay)
    {
        this.FullName = fullName;
        this.BirthDay = birthDay;
    }

    public Person(string fullName, Company company)
    {
        this.FullName = fullName;
        this.Company = company;
    }

    public Person(string fullName, Car car)
    {
        this.FullName = fullName;
        this.Car = car;
    }

    public void AddParent(Person parent)
    {
        this.Parents.Add(parent);
    }

    public void AddChild(Person child)
    {
        this.Children.Add(child);
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.Pokemons.Add(pokemon);
    }
}

