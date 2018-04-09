public class GoldenEditionBook : Book
{
    private decimal price;

    public override decimal Price
    {
        get { return base.Price * 1.3m; }
    }

    public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
    {
    }
}