public class Citizen : Inhabitant
{
    public string Id { get; set; }

    public string BirthDate { get; set; }

    public Citizen(string name, int age, string id, string birthDate) : base(name, age)
    {
        this.Id = id;
        this.BirthDate = birthDate;
    }

    public override void BuyFood()
    {
        this.Food += 10;
    }
}