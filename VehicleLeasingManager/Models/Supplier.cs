using System;
using System.Collections.Generic;


namespace VehicleLeasingManager.Models
{
    public class Supplier
    {
        public Guid SupplierId { get; set; } 
        public string SupplierName { get; set; } 
        public string ContactInfo   { get; set; } 
        // Navigation property: Supplier can have multiple Vehicles
        public virtual ICollection <Vehicle> Vehicles { get; set; }
    }
}