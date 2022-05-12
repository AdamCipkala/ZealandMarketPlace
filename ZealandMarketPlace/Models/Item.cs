namespace ZealandMarketPlace.Models;

public class Item
{
    public string? Name { get; set; }

    public string? Id { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Id})";
    }
}