using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using PierresTracker.Models;

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
      List<Order> model = _db.Orders
        .Include(order => order.Vendor)
        .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.VendorId = new SelectList(_db.Vendors, "VendorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Order order)
    {
      if (order.VendorId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Orders.Add(order);
      _db.SaveChanges();
      return RedirectToAction("Index", "Vendor");
    }

    public ActionResult Details(int id)
    {
      Order thisOrder = _db.Orders
        .Include(order => order.Vendor)
        .FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    public ActionResult Edit(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      ViewBag.VendorId = new SelectList(_db.Vendors, "VendorId", "Name");
      return View(thisOrder);
    }

    [HttpPost]
    public ActionResult Edit(Order order)
    {
      _db.Orders.Update(order);
      _db.SaveChanges();
      return RedirectToAction("Index", "Vendor");
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
      return RedirectToAction("Index", "Vendor");
    }
  }
}