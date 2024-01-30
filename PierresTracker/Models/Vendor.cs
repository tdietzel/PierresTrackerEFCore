using System.Collections.Generic;

namespace PierresTracker.Models
{
  public class Vendor
  {
    public static List<Vendor> _instances = new List<Vendor> {};
    public List<Order> Orders { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int VendorId { get; set; }
    private static int nextId = 1;

    public Vendor(){}
    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      VendorId = nextId++;
      _instances.Add(this);
      Orders = new List<Order> ();
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static Vendor Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public static void ResetNextId()
    {
      nextId = 1;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}