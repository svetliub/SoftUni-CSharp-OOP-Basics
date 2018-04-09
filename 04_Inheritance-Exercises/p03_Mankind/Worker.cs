using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workingHours;

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ValueMismatch, "weekSalary"));
            }
            this.weekSalary = value;
        }
    }
    
    public decimal WorkingHours
    {
        get { return this.workingHours; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ValueMismatch, "workHoursPerDay"));
            }
            this.workingHours = value;
        }
    }

    private decimal salaryPerHour;

    public decimal SalaryPerHour
    {
        get { return this.salaryPerHour; }
    }


    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
        this.salaryPerHour = this.WeekSalary / (this.WorkingHours * 5);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"First Name: {this.FirstName}");
        stringBuilder.AppendLine($"Last Name: {this.LastName}");
        stringBuilder.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        stringBuilder.AppendLine($"Hours per day: {this.WorkingHours:f2}");
        stringBuilder.AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

        return stringBuilder.ToString().TrimEnd();
    }
}