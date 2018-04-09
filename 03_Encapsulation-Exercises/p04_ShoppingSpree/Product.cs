using System;

public class Product
{
    private string name;
    private decimal price;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.price = value;
        }
    }

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}