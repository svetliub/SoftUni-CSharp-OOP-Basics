using System;
using System.Collections.Generic;
using System.Text;

public class Family
{
    private List<Person> people;

    public List<Person> People { get; set; }

    public Family()
    {
        this.People = new List<Person>();
    }
}

