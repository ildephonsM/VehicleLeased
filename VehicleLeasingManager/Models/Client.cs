using System;
using System.Collections.Generic;


namespace VehicleLeasingManager.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string CompanyName { get; set; }
        public string ContactDetails { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}