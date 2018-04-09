public class Robot
{
    public string Name { get; set; }

    public string Id { get; set; }

    public Robot(string name, string id)
    {
        this.Name = name;
        this.Id = id;
    }
}