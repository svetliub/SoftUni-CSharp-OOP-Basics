using System;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public CorpsTypeEnum CorpsType { get; set; }

    public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corpsType) : base(id, firstName, lastName, salary)
    {
        ValidateCorps(corpsType);
    }

    void ValidateCorps(string corps)
    {
        if (!Enum.IsDefined(typeof(CorpsTypeEnum), corps))
        {
            throw new ArgumentException("Invalid corp");
        }
        this.CorpsType = Enum.Parse<CorpsTypeEnum>(corps);
    }
}