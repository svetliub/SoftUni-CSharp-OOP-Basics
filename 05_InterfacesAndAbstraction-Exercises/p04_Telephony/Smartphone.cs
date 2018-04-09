using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : ISmartphone, IConnectable
{
    public List<string> PhoneNumbers { get; set; }

    public List<string> WebAddresses { get; set; }

    public Smartphone()
    {
        this.PhoneNumbers = new List<string>();
        this.WebAddresses = new List<string>();
    }

    public void AddAddresss(string webAddress)
    {
        if (webAddress.Any(c => Char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid URL!");
        }
        this.WebAddresses.Add(webAddress);
    }

    public void AddNumber(string number)
    {
        if (number.Any(c => Char.IsLetter(c)))
        {
            throw new ArgumentException("Invalid number!");
        }
        this.PhoneNumbers.Add(number);
    }

    public void BrowseAddress(string webAddress)
    {
        Console.WriteLine($"Browsing: {webAddress}!");
    }

    public void CallNumber(string number)
    {
        Console.WriteLine($"Calling... {number}");
    }
}