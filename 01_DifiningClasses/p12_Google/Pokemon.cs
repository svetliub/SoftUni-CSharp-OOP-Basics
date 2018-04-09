public class Pokemon
{
    private string pokemonName;
    private string pokemonType;

    public string PokemonName
    {
        get { return this.pokemonName; }
        set { this.pokemonName = value; }
    }

    public string PokemonType
    {
        get { return this.pokemonType; }
        set { this.pokemonType = value; }
    }

    public Pokemon(string pokemonName, string pokemonType)
    {
        this.PokemonName = pokemonName;
        this.PokemonType = pokemonType;
    }
}