using System.Linq;
using System.Web.Mvc;
using VehicleLeasingManager.Models;

namespace VehicleLeasingManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly VehicleLeasingContext context = new VehicleLeasingContext();

        public ActionResult Index()
        {
            var context = new VehicleLeasingContext();

            /// Supplier stats with their totals
            var supplierStatsRaw = context.Vehicles
                .GroupBy(v => new { v.Supplier.SupplierName, v.Manufacturer })
                .Select(g => new SupplierStat
                {
                    Supplier = g.Key.SupplierName,
                    Manufacturer = g.Key.Manufacturer,
                    Count = g.Count()
                }).ToList();

            var supplierStats = supplierStatsRaw
                .GroupBy(s => s.Supplier)
                .SelectMany(group => group.Concat(new[]
                {
            new SupplierStat
            {
                Supplier = group.Key,
                Manufacturer = "TOTAL",
                Count = group.Sum(x => x.Count)
            }
                })).ToList();

            // Branch stats with their totals
            var branchStatsRaw = context.Vehicles
                .GroupBy(v => new { v.Branch.BranchName, v.Manufacturer })
                .Select(g => new BranchStat
                {
                    Branch = g.Key.BranchName,
                    Manufacturer = g.Key.Manufacturer,
                    Count = g.Count()
                }).ToList();

            var branchStats = branchStatsRaw
                .GroupBy(b => b.Branch)
                .SelectMany(group => group.Concat(new[]
                {
            new BranchStat
            {
                Branch = group.Key,
                Manufacturer = "TOTAL",
                Count = group.Sum(x => x.Count)
            }
                })).ToList();

            // Client stats with their totals
            var clientStatsRaw = context.Vehicles
                .GroupBy(v => new { v.Client.CompanyName, v.Manufacturer })
                .Select(g => new ClientStat
                {
                    Client = g.Key.CompanyName,
                    Manufacturer = g.Key.Manufacturer,
                    Count = g.Count()
                }).ToList();

            var clientStats = clientStatsRaw
                .GroupBy(c => c.Client)
                .SelectMany(group => group.Concat(new[]
                {
            new ClientStat
            {
                Client = group.Key,
                Manufacturer = "TOTAL",
                Count = group.Sum(x => x.Count)
            }
                })).ToList();

            var model = new SummaryReport
            {
                SupplierStats = supplierStats,
                BranchStats = branchStats,
                ClientStats = clientStats
            };

            return View("Summary", model); // Load Summary.cshtml as homepage
        }

    }
}