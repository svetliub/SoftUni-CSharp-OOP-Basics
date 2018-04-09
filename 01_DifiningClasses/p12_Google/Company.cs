﻿public class Company
{
    private string name;
    private string department;
    private decimal salary;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public Company(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"\n{this.Name} {this.department} {this.salary:f2}";
    }
}