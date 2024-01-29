using Microsoft.AspNetCore.Mvc;
using PierresTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierresTracker.Controllers
{
  public class OrderController : Controller
  {
    private readonly PierresTrackerContext _db;

    public OrderController(PierresTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Order> model = _db.Orders.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Order order)
    {
      _db.Orders.Add(order);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    public ActionResult Edit(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    [HttpPost]
    public ActionResult Edit(Order order)
    {
      _db.Orders.Update(order);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      _db.Orders.Remove(thisOrder);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}