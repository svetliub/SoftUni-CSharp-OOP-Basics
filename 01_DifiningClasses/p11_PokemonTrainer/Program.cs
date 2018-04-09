using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string inputLine;
        List<Trainer> trainers = new List<Trainer>();

        while ((inputLine = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            Trainer trainer = new Trainer(trainerName);
            
            if (trainers.All(t => t.Name != trainerName))
            {
                trainers.Add(trainer);
            }

            trainer = trainers.FirstOrDefault(p => p.Name == trainerName);
            trainer.AddPokemon(pokemon);
        }

        while ((inputLine = Console.ReadLine()) != "End")
        {
            string element = inputLine;

            for (int i = 0; i < trainers.Count; i++)
            {
                if (trainers[i].Pokemons.Any(p => p.Element == element))
                {
                    trainers[i].NumberOfBadges++;
                }
                else
                {
                    for (int j = 0; j < trainers[i].Pokemons.Count; j++)
                    {
                        trainers[i].Pokemons[j].Health -= 10;
                        if (trainers[i].Pokemons[j].Health <= 0)
                        {
                            trainers[i].Pokemons.RemoveAt(j);
                        }
                    }
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
        }
    }
}

