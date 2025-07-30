using System;
using System.Collections.Generic;


namespace VehicleLeasingManager.Models
{
    public class Branch
    {
        public Guid BranchId { get; set; }
        public string BranchName    { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}