using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

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

    public decimal Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public List<Product> BagOfProducts
    {
        get { return this.bagOfProducts; }
        set { this.bagOfProducts = value; } 
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.BagOfProducts = new List<Product>();
    }

    public void BuyProduct(Product product)
    {
        if (this.Money < product.Price)
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
        else
        {
            this.BagOfProducts.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
            this.Money -= product.Price;
        }
    }
}
