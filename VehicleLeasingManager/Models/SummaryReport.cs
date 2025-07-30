
using System.Collections.Generic;


namespace VehicleLeasingManager.Models
{
    public class SummaryReport
    {
        public List<SupplierStat> SupplierStats { get; set; }
        public List<BranchStat> BranchStats { get; set; }
        public List<ClientStat> ClientStats { get; set; }
    }
    public class SupplierStat
    {
        public string Supplier { get; set; }
        public string Manufacturer { get; set; }
        public int Count { get; set; }
    }

    public class BranchStat
    {
        public string Branch { get; set; }
        public string Manufacturer { get; set; }
        public int Count { get; set; }
    }

    public class ClientStat
    {
        public string Client { get; set; }
        public string Manufacturer { get; set; }
        public int Count { get; set; }
    }
}