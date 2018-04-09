using System;
using System.Text;

public class Book
{
    private const int MIN_TITLE_LENGTH = 3;

    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < MIN_TITLE_LENGTH)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }
    
    public string Author
    {
        get { return this.author; }
        set
        {
            var tokens = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length > 1 && Char.IsDigit(tokens[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }
    
    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Type: {this.GetType().Name}");
        stringBuilder.AppendLine($"Title: {this.Title}");
        stringBuilder.AppendLine($"Author: {this.Author}");
        stringBuilder.AppendLine($"Price: {this.Price:f2}");

        return stringBuilder.ToString().Trim();
    }
}

