using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleLeasingManager.Models;

namespace VehicleLeasingManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Summary()
        {
            var context = new VehicleLeasingContext();

            var supplierStats = context.Vehicles
                .GroupBy(v => new { v.Supplier.SupplierName, v.Manufacturer })
                .Select(g => new
                {
                    Supplier = g.Key.SupplierName,
                    Make = g.Key.Manufacturer,
                    Count = g.Count()
                }).ToList();

            var branchStats = context.Vehicles
                .GroupBy(v => new { v.Branch.BranchName, v.Manufacturer })
                .Select(g => new
                {
                    Branch = g.Key.BranchName,
                    Make = g.Key.Manufacturer,
                    Count = g.Count()
                }).ToList();

            var clientStats = context.Vehicles
                .GroupBy(v => new { v.Client.CompanyName, v.Manufacturer })
                .Select(g => new
                {
                    Client = g.Key.CompanyName,
                    Make = g.Key.Manufacturer,
                    Count = g.Count()
                }).ToList();

            ViewBag.SupplierStats = supplierStats;
            ViewBag.BranchStats = branchStats;
            ViewBag.ClientStats = clientStats;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}