using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

using PierresTracker.Models;

namespace PierresTracker.Controllers
{
  public class VendorController : Controller
  {
    private readonly PierresTrackerContext _db;
    public VendorController(PierresTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Vendor> model = _db.Vendors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Vendor vendor)
    {
      _db.Vendors.Add(vendor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Vendor thisVendor = _db.Vendors
        .Include(vendor => vendor.Orders)
        .FirstOrDefault(vendor => vendor.VendorId == id);
      return View(thisVendor);
    }

    public ActionResult Edit(int id)
    {
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      return View(thisVendor);
    }

    [HttpPost]
    public ActionResult Edit(Vendor vendor)
    {
      _db.Vendors.Update(vendor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      return View(thisVendor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      _db.Vendors.Remove(thisVendor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}