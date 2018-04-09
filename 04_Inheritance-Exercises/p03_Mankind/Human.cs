using System;

public class Human
{
    private const int MIN_FIRSTNAME_LENGTH = 4;
    private const int MIN_LASTNAME_LENGTH = 3;

    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException(ExceptionMessages.UpperCaseLetter + "firstName");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NameLength, MIN_FIRSTNAME_LENGTH, "firstName"));
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException(ExceptionMessages.UpperCaseLetter + "lastName");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NameLength, MIN_LASTNAME_LENGTH, "lastName"));
            }
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}