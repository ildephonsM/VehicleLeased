using System;

namespace VehicleLeasingManager.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }

        // Foreign keys and navigation properties
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public Guid BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        public Guid DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}