namespace PierresTracker.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    private static int nextId = 1;
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Date { get; set; }

    public Order()
    {
    }
    public Order(string title, string description, int price, string date)
    {
      Title = title;
      Description = description;
      Price = price;
      Date = date;
      OrderId = nextId++;
    }
  }
}