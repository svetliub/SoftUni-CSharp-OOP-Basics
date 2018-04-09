using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(x => char.IsLetterOrDigit(x)))
            {
                throw new ArgumentException(ExceptionMessages.FacultyNumber);
            }
            
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"First Name: {this.FirstName}");
        stringBuilder.AppendLine($"Last Name: {this.LastName}");
        stringBuilder.AppendLine($"Faculty number: {this.FacultyNumber}");

        return stringBuilder.ToString().TrimEnd();
    }
}